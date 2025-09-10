using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using static SharpAlert.ProgramWorker.HaidaWorker;

namespace SharpAlert.AlertComponents
{
    public static class DiscordWebhook
    {
        private static readonly WebClient discordClient = new WebClient();
        
        /// <summary>
        /// Returns a URL based on the configuration. Good enough.
        /// </summary>
        public static (string URL, string Append) GetDiscordWebhookURLFromSourceName(string SourceName)
        {
            Console.WriteLine($"[Discord Webhook] Getting webhook for source {SourceName}.");

            (string subURL, string subAppend) SubSourceName()
            {
                string source = SourceName.ToUpperInvariant();

                if (source.Contains("EAS"))
                {
                    return (QuickSettings.Instance.DiscordWebhook_FEMA_IPAWS_EAS, QuickSettings.Instance.DiscordWebhookAppend_FEMA_IPAWS_EAS);
                }

                if (source.Contains("WEA"))
                {
                    return (QuickSettings.Instance.DiscordWebhook_FEMA_IPAWS_WEA, QuickSettings.Instance.DiscordWebhookAppend_FEMA_IPAWS_WEA);
                }

                if (source.Contains("SASMEX"))
                {
                    return (QuickSettings.Instance.DiscordWebhook_SASMEX, QuickSettings.Instance.DiscordWebhookAppend_SASMEX);
                }

                if (source.Contains("NAADS PRIMARY"))
                {
                    return (QuickSettings.Instance.DiscordWebhook_NAADS_PRIMARY, QuickSettings.Instance.DiscordWebhookAppend_NAADS_PRIMARY);
                }

                if (source.Contains("NAADS BACKUP"))
                {
                    return (QuickSettings.Instance.DiscordWebhook_NAADS_BACKUP, QuickSettings.Instance.DiscordWebhookAppend_NAADS_BACKUP);
                }

                if (source.Contains("NWS ATOM"))
                {
                    return (QuickSettings.Instance.DiscordWebhook_NWS_ATOM, QuickSettings.Instance.DiscordWebhookAppend_NWS_ATOM);
                }

                if (source.Contains("IDAP"))
                {
                    return (QuickSettings.Instance.DiscordWebhook_IDAP, QuickSettings.Instance.DiscordWebhookAppend_IDAP);
                }

                return (string.Empty, string.Empty);
            }

            var (subURL, subAppend) = SubSourceName();
            if (string.IsNullOrWhiteSpace(subURL))
            {
                Console.WriteLine($"[Discord Webhook] No suitable webhook found for source {SourceName}. Using default.");
                return (QuickSettings.Instance.DiscordWebhook, QuickSettings.Instance.DiscordWebhookAppend);
            }
            else
            {
                Console.WriteLine($"[Discord Webhook] Found suitable webhook found for source {SourceName}.");
                return (subURL, subAppend);
            }
        }

		/// <summary>
		/// Sends data to a webhook after converting the string to a byte array using UTF8.
		/// </summary>
		/// <param name="webhook">The webhook to send data to.</param>
		/// <param name="payload">The payload to send to the webhook.</param>
		private static void UploadData(string webhook, string payload, string contentType)
        {
            UploadData(webhook, Encoding.UTF8.GetBytes(payload), contentType);
        }

        /// <summary>
        /// Sends data to a webhook.
        /// </summary>
        /// <param name="webhook">The webhook to send data to.</param>
        /// <param name="data">The data to send to the webhook.</param>
        private static void UploadData(string webhook, byte[] data, string contentType)
        {
            if (string.IsNullOrWhiteSpace(webhook)) return;

            Console.WriteLine($"[Discord Webhook] Processing request -> {webhook}");

            ThreadDrool.StartAndForget(() =>
            {
                lock (discordClient)
                {
                    try
                    {
                        discordClient.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                        discordClient.Headers.Set(HttpRequestHeader.ContentType, contentType);

                        Thread.Sleep(1000 + 100);
                        discordClient.UploadData(webhook, data);
                        Console.WriteLine("[Discord Webhook] Sent message to webhook.");
                    }
                    catch (Exception ex)
                    {
                        if (ex is WebException webex)
                        {
                            Console.WriteLine($"[Discord Webhook] {webex.Status}");

                            if (webex.Response is HttpWebResponse response)
                            {
                                Console.WriteLine($"[Discord Webhook] Returned status code: {(int)response.StatusCode} {response.StatusDescription}");

                                using (var stream = response.GetResponseStream())
                                using (var reader = new StreamReader(stream))
                                {
                                    Console.WriteLine($"[Discord Webhook] Returned body: {reader.ReadToEnd()}");
                                }
                            }

                            Console.WriteLine(Encoding.UTF8.GetString(data));
                        }

                        Console.WriteLine($"[Discord Webhook] {ex.Message}");
                        try
                        {
                            Thread.Sleep(3000 + 100);
                            discordClient.UploadData(webhook, data);
							Console.WriteLine("[Discord Webhook] Sent message to webhook.");
                        }
                        catch (Exception exx)
                        {
                            Console.WriteLine($"[Discord Webhook] {exx.Message}");
                            try
                            {
                                Console.WriteLine($"[Discord Webhook] Rate limited or bad connection. Pausing for 15 seconds to cool down.");
                                Thread.Sleep((15 * 1000) + 100);
                                discordClient.UploadData(webhook, data);
								Console.WriteLine("[Discord Webhook] Sent message webhook.");
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
                        UploadData(webhook, payloadJson, "application/json");
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
                        UploadData(webhook, payloadJson, "application/json");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Discord Webhook] {ex.Message}");
            }
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static void SendFormattedMessage(string FeedSource, string message, string description, string normal, int color = 16777215)
        {
            try
            {
                string webhook = $"{GetDiscordWebhookURLFromSourceName(FeedSource).URL}";
                if (!string.IsNullOrWhiteSpace(webhook))
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
                        UploadData(webhook, payloadJson, "application/json");
                    }
                }
            }
            catch (Exception ex)
            {
				Console.WriteLine($"[Discord Webhook] {ex.Message}");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Use inferred member name", Justification = "<Pending>")]
        public static void SendEmbeddedMessage(
            string FeedSource,
            string message,
            string title,
            string description1,
            string description2,
            string URL,
            string Identifier,
            List<string> AudioFileURL,
            List<string> ImageFileURL,
            int color = 16711680)
        {
            try
            {
                Console.WriteLine("[Discord Webhook] Preparing to send an alert message to a Discord webhook.");

                string webhook = $"{GetDiscordWebhookURLFromSourceName(FeedSource).URL}";
                if (string.IsNullOrWhiteSpace(webhook)) return;

                lock (discordClient)
                {
                    string boundary = "----SharpBoundary" + DateTime.Now.Ticks;

                    string AudioURL = (AudioFileURL != null && AudioFileURL.Any()) ? AudioFileURL[0] : null;
                    string ImageURL = (ImageFileURL != null && ImageFileURL.Any()) ? ImageFileURL[0] : null;

                    //if (!string.IsNullOrEmpty(title) && description1.Length >= 128)
                    //{
                    //    title = title.Substring(0, 128) + "...(truncated)";
                    //    Console.WriteLine("[Discord Webhook] The length of the title text has been truncated.");
                    //}

                    int TruncuationLengthPerDescription = 1800;
                    bool TruncuationOccurred = false;

                    string truncMessage = message;
                    string truncDescription1 = description1;
                    string truncDescription2 = description2;

                    if (!string.IsNullOrEmpty(title) && message.Length >= 128)
                    {
                        title = title.Substring(0, 118) + "\x20...(truncuated)";
                        TruncuationOccurred = true;
                        Console.WriteLine("[Discord Webhook] The length of the message text has been truncated.");
                    }
                    
                    if (!string.IsNullOrEmpty(message) && message.Length >= 1000)
                    {
                        truncMessage = message.Substring(0, 1000) + "\x20...(see txt file)";
                        TruncuationOccurred = true;
                        Console.WriteLine("[Discord Webhook] The length of the message text has been truncated.");
                    }
                    
                    if (!string.IsNullOrEmpty(description1) && description1.Length >= TruncuationLengthPerDescription)
                    {
                        truncDescription1 = description1.Substring(0, TruncuationLengthPerDescription) + "\x20...(see txt file)";
                        TruncuationOccurred = true;
                        Console.WriteLine("[Discord Webhook] The length of the intro text has been truncated.");
                    }

                    if (!string.IsNullOrEmpty(description2) && description2.Length >= TruncuationLengthPerDescription)
                    {
                        truncDescription2 = description2.Substring(0, TruncuationLengthPerDescription) + "\x20...(see txt file)";
                        TruncuationOccurred = true;
                        Console.WriteLine("[Discord Webhook] The length of the body text has been truncated.");
                    }

                    string Fields = string.Empty;

                    if (QuickSettings.Instance.AddIntroText & !string.IsNullOrWhiteSpace(truncDescription1))
                    {
                        Fields += $"**Alert Info**\r\n```\r\n{truncDescription1}\r\n```\r\n";
                    }

                    Fields += $"**Alert Text**\r\n```\r\n{truncDescription2}\r\n```";

                    //var fieldsList = new List<object>();

                    //if (QuickSettings.Instance.AddIntroText)
                    //{
                    //    fieldsList.Add(new
                    //    {
                    //        name = "Alert Info",
                    //        value = "```\r\n" + truncDescription1 + "\r\n```",
                    //        inline = false
                    //    });
                    //}

                    //fieldsList.Add(new
                    //{
                    //    name = "Alert Text",
                    //    value = "```\r\n" + truncDescription2 + "\r\n```",
                    //    inline = false
                    //});

                    var payloadObject = new
                    {
                        content = truncMessage,
                        embeds = new[]
                        {
                            new
                            {
                                title = title,
                                url = URL,
                                color = color,
                                author = new
                                {
                                    name = "Powered by SharpAlert",
                                    url = "https://bunnytub.com/SharpAlert",
                                    icon_url = "https://bunnytub.com/media/SharpAlert_Small.png"
                                },
                                description = Fields,
                                //fields = fieldsList.ToArray(),
                                image = new { url = ImageURL },
                                footer = new { text = "Identifier: " + Identifier }
                            }
                        }
                    };

                    string payloadJson = JsonSerializer.Serialize(payloadObject);
                    byte[] payloadJsonBytes = Encoding.UTF8.GetBytes(payloadJson);
                    var sbPre = new StringBuilder();
                    sbPre.Append("--").Append(boundary).Append("\r\n");
                    sbPre.Append("Content-Disposition: form-data; name=\"payload_json\"").Append("\r\n");
                    sbPre.Append("Content-Type: application/json; charset=utf-8").Append("\r\n");
                    sbPre.Append("\r\n");
                    byte[] preFileBytes = Encoding.UTF8.GetBytes(sbPre.ToString());
                    byte[] TextFileHeaderBytes = null;
                    byte[] AudioFileHeaderBytes = null;
                    byte[] textBytes = null;
                    byte[] audioBytes = null;

                    if (TruncuationOccurred)
                    {
                        var sbFile = new StringBuilder();
                        sbFile.Append("\r\n--").Append(boundary).Append("\r\n");
                        sbFile.Append("Content-Disposition: form-data; name=\"file\"; filename=\"Full_Alert_Text.txt\"").Append("\r\n");
                        sbFile.Append("Content-Type: text/plain; charset=utf-8").Append("\r\n");
                        sbFile.Append("\r\n");

                        TextFileHeaderBytes = Encoding.UTF8.GetBytes(sbFile.ToString());

                        // Convert the truncated text to bytes
                        string text = "SharpAlert determined the message is too big to fully display on Discord.\r\n\r\n" +
                            "--- Alert Info ---\r\n\r\n" +
                            $"{description1}\r\n\r\n" +
                            "--- Alert Text ---\r\n\r\n" +
                            $"{description2}";
                        textBytes = Encoding.UTF8.GetBytes(text);
                    }

                    if (!string.IsNullOrWhiteSpace(AudioURL))
                    {
                        var sbFile = new StringBuilder();
                        sbFile.Append("\r\n--").Append(boundary).Append("\r\n");
                        sbFile.Append("Content-Disposition: form-data; name=\"file\"; filename=\"Audio_Attachment.wav\"").Append("\r\n");
                        sbFile.Append("Content-Type: audio/wav").Append("\r\n");
                        sbFile.Append("\r\n");
                        AudioFileHeaderBytes = Encoding.UTF8.GetBytes(sbFile.ToString());

                        try
                        {
                            var task = client.GetByteArrayAsync(AudioURL);
                            task.Wait(15000);
                            if (!task.IsFaulted && task.Result != null)
                            {
                                audioBytes = task.Result;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("[Discord Webhook] Failed to fetch audio: " + ex.Message);
                            audioBytes = null;
                        }
                    }

                    byte[] closingBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                    using (var ms = new MemoryStream())
                    {
                        ms.Write(preFileBytes, 0, preFileBytes.Length);
                        ms.Write(payloadJsonBytes, 0, payloadJsonBytes.Length);

                        if (TextFileHeaderBytes != null && textBytes != null && textBytes.Length > 0)
                        {
                            ms.Write(TextFileHeaderBytes, 0, TextFileHeaderBytes.Length);
                            ms.Write(textBytes, 0, textBytes.Length);
                        }

                        if (AudioFileHeaderBytes != null && audioBytes != null && audioBytes.Length > 0)
                        {
                            ms.Write(AudioFileHeaderBytes, 0, AudioFileHeaderBytes.Length);
                            ms.Write(audioBytes, 0, audioBytes.Length);
                        }

                        ms.Write(closingBytes, 0, closingBytes.Length);

                        Console.WriteLine("[Discord Webhook] Payload size (bytes): " + ms.Length);

                        UploadData(webhook, ms.ToArray(), "multipart/form-data; boundary=" + boundary);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Discord Webhook] " + ex.Message);
            }
        }
    }
}
