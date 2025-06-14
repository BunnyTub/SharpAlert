using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static SharpAlert.IceBearWorker;

namespace SharpAlert
{
    public static class DiscordWebhook
    {
        private static readonly WebClient client = new WebClient();

        /// <summary>
        /// Sends data to a webhook after converting the string to a byte array using UTF8.
        /// </summary>
        private static bool UploadData(string webhook, string payload)
        {
            return UploadData(webhook, Encoding.UTF8.GetBytes(payload));
        }

        /// <summary>
        /// Sends data to a webhook.
        /// </summary>
        /// <param name="webhook">The webhook to send data to.</param>
        /// <param name="data">The data to send to the webhook.</param>
        /// <returns>Returns True if the upload is successful.</returns>
        private static bool UploadData(string webhook, byte[] data)
        {
            lock (client)
            {
                try
                {
                    Thread.Sleep(1000 + 100);
                    client.UploadData(webhook, data);
                    return true;
                }
                catch (Exception ex)
                {
                    ConsoleExt.WriteLine($"[Discord Webhook] {ex.Message}");
                    try
                    {
                        Thread.Sleep(2000 + 100);
                        client.UploadData(webhook, data);
                        return true;
                    }
                    catch (Exception exx)
                    {
                        ConsoleExt.WriteLine($"[Discord Webhook] {exx.Message}");
                        try
                        {
                            ConsoleExt.WriteLine($"[Discord Webhook] Rate limiting possibly occurring. Pausing for 15 seconds to cool down.");
                            Thread.Sleep((15 * 1000) + 100);
                            client.UploadData(webhook, data);
                            return true;
                        }
                        catch (Exception exxx)
                        {
                            ConsoleExt.WriteLine($"[Discord Webhook] {exxx.Message}");
                        }
                    }
                }
                return false;
            }
        }

        public static bool SendUnformattedMessage(string message)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (client)
                    {
                        var payloadObject = new { content = message };
                        string payloadJson = JsonSerializer.Serialize(payloadObject);
                        client.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                        client.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                        return UploadData(webhook, payloadJson);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine(ex.Message);
                return false;
            }
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static bool SendFormattedMessage(string message, int color = 16777215)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (client)
                    {
                        var payloadObject = new
                        {
                            embeds = new[]
                            {
                                new
                                {
                                    title = message,
                                    color = color
                                }
                            }
                        };
                        string payloadJson = JsonSerializer.Serialize(payloadObject);
                        client.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                        client.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                        return UploadData(webhook, payloadJson);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine(ex.Message);
                return false;
            }
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static bool SendFormattedMessage(string message, string description, string normal, int color = 16777215)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (client)
                    {
                        var payloadObject = new
                        {
                            embeds = new[]
                            {
                                new
                                {
                                    title = message,
                                    description = description,
                                    color = color
                                }
                            },
                            content = normal
                        };
                        string payloadJson = JsonSerializer.Serialize(payloadObject);
                        client.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                        client.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                        UploadData(webhook, payloadJson);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine(ex.Message);
                return false;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static bool SendEmbeddedMessage(string message, string title, string description1, string description2, SharpDataItem item, List<string> AudioFileURL, List<string> ImageFileURL, int color = 16711680)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (client)
                    {
                        string boundary = "----SharpBoundary" + DateTime.Now.Ticks;
                        client.Headers.Set(HttpRequestHeader.ContentType, $"multipart/form-data; boundary={boundary}");
                        client.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);

                        string AudioURL = string.Empty;
                        string ImageURL = string.Empty;

                        if (AudioFileURL.Any()) AudioURL = AudioFileURL[0];
                        if (ImageFileURL.Any()) ImageURL = ImageFileURL[0];

                        string AlertCompiled;
                        //if (QuickSettings.Instance.weaOnly) AlertCompiled = "## WIRELESS EMERGENCY ALERT\r\n";
                        //else AlertCompiled = "# EMERGENCY ALERT\r\n";
                        AlertCompiled = "## Alert Message\r\n" +
                            $"{description1}\r\n\r\n{description2}";

                        if (AlertCompiled.Length >= 3800)
                        {
                            AlertCompiled = AlertCompiled.Substring(0, 3800) + "...(truncuated)";
                            ConsoleExt.WriteLine("[Discord Webhook] The length of the message has been truncuated.");
                        }

                        string AuthorName = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | Safety is never a non-priority.";
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.StationIdentifier)) AuthorName += $"\x20| Relaying from {QuickSettings.Instance.StationIdentifier} ({QuickSettings.Instance.StationName}).";

                        var payloadObject = new
                        {
                            content = message,
                            embeds = new[]
                            {
                                new
                                {
                                    author = new
                                    {
                                        name = $"",
                                        url = "https://sharpalert.bunnytub.com",
                                        icon_url = "https://bunnytub.com/media/SharpAlert.png"
                                    },
                                    title = title,
                                    description = AlertCompiled,
                                    color = color,
                                    image = new
                                    {
                                        url = ImageURL
                                    }
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

                        //if (!string.IsNullOrEmpty(item.Name) && !string.IsNullOrEmpty(item.Data))
                        //{
                        //    requestBody.AppendLine($"--{boundary}");
                        //    requestBody.AppendLine($"Content-Disposition: form-data; name=\"file\"; filename=\"{item.Name}.cap\"");
                        //    requestBody.AppendLine("Content-Type: application/octet-stream");
                        //    requestBody.AppendLine();
                        //    requestBody.AppendLine(item.Data);
                        //}

                        if (!string.IsNullOrWhiteSpace(AudioURL))
                        {
                            requestBody.AppendLine($"--{boundary}");
                            requestBody.AppendLine($"Content-Disposition: form-data; name=\"file\"; filename=\"SharpAlert_Attachment.wav\"");
                            requestBody.AppendLine("Content-Type: audio/wav");
                            requestBody.AppendLine();
                        }

                        byte[] preFileBytes = Encoding.UTF8.GetBytes(requestBody.ToString());

                        // combine, because we have binary data here. If even a bit gets flipped, we're most likely fucked.
                        var stream = new MemoryStream();
                        stream.Write(preFileBytes, 0, preFileBytes.Length);

                        if (!string.IsNullOrWhiteSpace(AudioURL))
                        {
                            try
                            {
                                //var targetFormat = new WaveFormat(44100, 16, 1);

                                Task<byte[]> task = IceBearWorker.client.GetByteArrayAsync(AudioURL);
                                if (task.IsFaulted) throw task.Exception;

                                var audio = new MemoryStream(task.Result)
                                {
                                    Position = 0
                                };

                                audio.CopyTo(stream);

                                //using (var ttsReader = new WaveFileReader(audio))
                                //using (var resampled = new MediaFoundationResampler(ttsReader, targetFormat))
                                //{
                                //    resampled.ResamplerQuality = 60;
                                //}
                            }
                            catch (Exception)
                            {

                            }
                        }

                        //MemoryStream audio = AudioManager.CreateCombinedAudio(AudioFileURL, description1, description2);
                        //audio.CopyTo(stream);

                        string closing = $"\r\n--{boundary}--\r\n";
                        byte[] postFileBytes = Encoding.UTF8.GetBytes(closing);
                        stream.Write(postFileBytes, 0, postFileBytes.Length);

                        UploadData(webhook, stream.ToArray());
                    }
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