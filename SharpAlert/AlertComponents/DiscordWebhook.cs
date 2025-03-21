using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static SharpAlert.IceBearWorker;

namespace SharpAlert
{
    public static class DiscordWebhook
    {
        private static readonly WebClient client = new WebClient();

        public static bool SendUnformattedMessage(string message, string webhook)
        {
            try
            {
                lock (client)
                {
                    var payloadObject = new { content = message };
                    string payloadJson = JsonSerializer.Serialize(payloadObject);
                    client.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                    client.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                    client.UploadData(webhook, Encoding.UTF8.GetBytes(payloadJson));
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static bool SendEmbeddedMessage(string title, string description, SharpDataItem item, string webhook)
        {
            try
            {
                lock (client)
                {
                    string boundary = "----SharpBoundary" + DateTime.Now.Ticks;
                    client.Headers.Set(HttpRequestHeader.ContentType, $"multipart/form-data; boundary={boundary}");
                    client.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);

                    // Construct the JSON payload (embed)
                    var payloadObject = new
                    {
                        embeds = new[]
                        {
                            new
                            {
                                author = new
                                {
                                    name = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | Safety is never a non-priority",
                                    url = "https://sharpalert.bunnytub.com",
                                    icon_url = "https://bunnytub.com/media/SharpAlert.png"
                                },
                                title = title,
                                description = description,
                                color = 16711680
                            }
                        }
                    };

                    string payloadJson = JsonSerializer.Serialize(payloadObject);
                    StringBuilder requestBody = new StringBuilder();

                    requestBody.AppendLine($"--{boundary}");
                    requestBody.AppendLine("Content-Disposition: form-data; name=\"payload_json\"");
                    requestBody.AppendLine("Content-Type: application/json");
                    requestBody.AppendLine();
                    requestBody.AppendLine(payloadJson);

                    if (!string.IsNullOrEmpty(item.Name) && !string.IsNullOrEmpty(item.Data))
                    {
                        requestBody.AppendLine($"--{boundary}");
                        requestBody.AppendLine($"Content-Disposition: form-data; name=\"file\"; filename=\"{item.Name}.xml\"");
                        requestBody.AppendLine("Content-Type: application/octet-stream");
                        requestBody.AppendLine();
                        requestBody.AppendLine(item.Data);
                    }

                    requestBody.AppendLine($"--{boundary}--");
                    client.UploadData(webhook, Encoding.UTF8.GetBytes(requestBody.ToString()));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}