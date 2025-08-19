using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static SharpAlert.ProgramWorker.HaidaWorker;

namespace SharpAlert.AlertComponents
{
    public static class DiscordWebhook
    {
        private static readonly WebClient discordClient = new WebClient();

		/// <summary>
		/// Sends data to a webhook after converting the string to a byte array using UTF8.
		/// </summary>
		/// <param name="webhook">The webhook to send data to.</param>
		/// <param name="payload">The payload to send to the webhook.</param>
		private static void UploadData(string webhook, string payload)
        {
            UploadData(webhook, Encoding.UTF8.GetBytes(payload));
        }

        /// <summary>
        /// Sends data to a webhook.
        /// </summary>
        /// <param name="webhook">The webhook to send data to.</param>
        /// <param name="data">The data to send to the webhook.</param>
        private static void UploadData(string webhook, byte[] data)
        {
            ThreadDrool.StartAndForget(() =>
            {
                lock (discordClient)
                {
                    try
                    {
                        Thread.Sleep(1000 + 100);
                        discordClient.UploadData(webhook, data);
                        Console.WriteLine("[Discord Webhook] Request completed.");
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Discord Webhook] {ex.Message}");
                        try
                        {
                            Thread.Sleep(2000 + 100);
                            discordClient.UploadData(webhook, data);
							Console.WriteLine("[Discord Webhook] Request completed.");
							return;
                        }
                        catch (Exception exx)
                        {
                            Console.WriteLine($"[Discord Webhook] {exx.Message}");
                            try
                            {
                                Console.WriteLine($"[Discord Webhook] Rate limited or bad connection. Pausing for 15 seconds to cool down.");
                                Thread.Sleep((15 * 1000) + 100);
                                discordClient.UploadData(webhook, data);
								Console.WriteLine("[Discord Webhook] Request completed.");
								return;
                            }
                            catch (Exception exxx)
                            {
                                Console.WriteLine($"[Discord Webhook] Request failed after multiple retries. {exxx.Message}");
                            }
                        }
                    }
                    return;
                }
            });
        }

        public static void SendUnformattedMessage(string message)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (discordClient)
                    {
                        var payloadObject = new { content = message };
                        string payloadJson = JsonSerializer.Serialize(payloadObject);
                        discordClient.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                        discordClient.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                        UploadData(webhook, payloadJson);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Discord Webhook] {ex.Message}");
            }
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static void SendFormattedMessage(string message, int color = 16777215)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (discordClient)
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
                        discordClient.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                        discordClient.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                        UploadData(webhook, payloadJson);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Discord Webhook] {ex.Message}");
            }
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static void SendFormattedMessage(string message, string description, string normal, int color = 16777215)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (discordClient)
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
                        discordClient.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                        discordClient.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                        UploadData(webhook, payloadJson);
                    }
                }
            }
            catch (Exception ex)
            {
				Console.WriteLine($"[Discord Webhook] {ex.Message}");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static void SendEmbeddedMessage(string message, string title, string description1, string description2, string URL, List<string> AudioFileURL, List<string> ImageFileURL, int color = 16711680)
        {
            try
            {
                string webhook = $"{QuickSettings.Instance.DiscordWebhook}";
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    lock (discordClient)
                    {
                        string boundary = "----SharpBoundary" + DateTime.Now.Ticks;
                        discordClient.Headers.Set(HttpRequestHeader.ContentType, $"multipart/form-data; boundary={boundary}");
                        discordClient.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);

                        string AudioURL = string.Empty;
                        string ImageURL = string.Empty;

                        if (AudioFileURL.Any()) AudioURL = AudioFileURL[0];
                        if (ImageFileURL.Any()) ImageURL = ImageFileURL[0];

                        string AlertCompiled;
                        //if (QuickSettings.Instance.weaOnly) AlertCompiled = "## WIRELESS EMERGENCY ALERT\r\n";
                        //else AlertCompiled = "# EMERGENCY ALERT\r\n";
                        AlertCompiled = "## Alert Message\r\n" +
                            $"{description1}\r\n\r\n{description2}";

                        if (AlertCompiled.Length >= 3600)
                        {
                            AlertCompiled = AlertCompiled.Substring(0, 3600) + "...(truncuated)";
                            Console.WriteLine("[Discord Webhook] The length of the message has been truncuated.");
                        }

                        //string AuthorName = $"{VersionInfo.FriendlyVersion}";
                        //if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.StationIdentifier)) AuthorName += $"\x20| Relaying from {QuickSettings.Instance.StationIdentifier} ({QuickSettings.Instance.StationName}).";

                        var payloadObject = new
                        {
                            content = message,
                            embeds = new[]
                            {
                                new
                                {
                                    title = title,
                                    description = AlertCompiled,
                                    url = URL,
                                    color = color,
                                    author = new
                                    {
                                        name = $"Powered by SharpAlert",
                                        url = "https://bunnytub.com/SharpAlert",
                                        icon_url = "https://bunnytub.com/media/SharpAlert_Small.png"
                                    },
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

                                Task<byte[]> task = client.GetByteArrayAsync(AudioURL);
                                task.Wait(10000);
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
            }
            catch (Exception ex)
            {
				Console.WriteLine($"[Discord Webhook] {ex.Message}");
			}
        }
    }
}
