using SharpAlert.ProgramWorker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.HaidaWorker;
using System.Threading;
using System.Windows.Forms;

namespace SharpAlert.AlertComponents
{
    public static class DiscordWebhook
    {
        public class DiscordWebhookData
        {
            public DiscordWebhookData(string webhook, byte[] data, string contentType)
            {
                Webhook = webhook;
                Data = data;
                ContentType = contentType;
            }

            public string Webhook;
            public byte[] Data;
            public string ContentType;
        }

        private static readonly WebClient discordClient = new();
        private static List<DiscordWebhookData> DiscordWebhookDataQueue = [];

        public static void ServiceRun()
        {
            while (AllowThreadRestarts)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (DiscordWebhookDataQueue.Count != 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    lock (discordClient)
                    {
                        string webhook;
                        byte[] data;
                        string contentType;

                        lock (DiscordWebhookDataQueue)
                        {
                            var varData = DiscordWebhookDataQueue[0];
                            DiscordWebhookDataQueue.RemoveAt(0);
                            webhook = varData.Webhook;
                            data = varData.Data;
                            contentType = varData.ContentType;
                        }

                        //Client.GetStringAsync("https://bunnytub.com/SharpAlert/BanList.txt");

                        //Console.WriteLine($"[Discord Webhook] Cannot process request, account is banned -> {webhook}");
                        
                        Console.WriteLine($"[Discord Webhook] Processing request -> {webhook}");

                        try
                        {
                            discordClient.Headers.Set(HttpRequestHeader.UserAgent, SelfUserAgent);
                            discordClient.Headers.Set(HttpRequestHeader.ContentType, contentType);

                            Thread.Sleep(1000 + 100);
                            byte[] bytes = discordClient.UploadData(webhook, data);
                            Console.WriteLine("[Discord Webhook] Sent message to webhook.");
                            Console.WriteLine($"[Discord Webhook] Returned body: {Encoding.UTF8.GetString(bytes)}");
                        }
                        catch (Exception ex)
                        {
                            if (ex is WebException webex)
                            {
                                Console.WriteLine($"[Discord Webhook] {webex.Status}");

                                if (webex.Response is HttpWebResponse response)
                                {
                                    Console.WriteLine($"[Discord Webhook] Returned status code: {(int)response.StatusCode} {response.StatusDescription}");

                                    using var stream = response.GetResponseStream();
                                    using var reader = new StreamReader(stream);
                                    Console.WriteLine($"[Discord Webhook] Returned body: {reader.ReadToEnd()}");
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

                        Thread.Sleep(10);
                    }
                }
                Thread.Sleep(10);
            }
        }

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
            if (string.IsNullOrWhiteSpace(webhook))
            {
                Console.WriteLine($"[Discord Webhook] Missing webhook -x {webhook}");
                return;
            }

            if (QuickSettings.Instance.DiscordWebhookFeaturesLocked) return;

            DiscordWebhookDataQueue.Add(new DiscordWebhookData(webhook, data, contentType));
            Console.WriteLine($"[Discord Webhook] Queued request -> {webhook}");
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
            List<string> AudioFileDeref,
            List<string> ImageFileURL,
            int color = 16711680)
        {
            try
            {
                Console.WriteLine("[Discord Webhook] Preparing to send an alert message to a Discord webhook.");

                string webhook = $"{GetDiscordWebhookURLFromSourceName(FeedSource).URL}";
                if (string.IsNullOrWhiteSpace(webhook))
                {
                    //webhook = Settings.Default.DiscordWebhook;
                    Console.WriteLine("[Discord Webhook] No webhook found (somehow).");
                    return;
                }

                lock (discordClient)
                {
                    string boundary = "----SharpBoundary" + DateTime.UtcNow.Ticks;

                    string AudioURL = (AudioFileURL != null && AudioFileURL.Count != 0) ? AudioFileURL[0] : null;
                    string AudioDeref = (AudioFileDeref != null && AudioFileDeref.Count != 0) ? AudioFileDeref[0] : null;
                    string ImageURL = (ImageFileURL != null && ImageFileURL.Count != 0) ? ImageFileURL[0] : null;

                    //if (!string.IsNullOrEmpty(title) && description1.Length >= 128)
                    //{
                    //    title = title.Substring(0, 128) + "...(truncated)";
                    //    Console.WriteLine("[Discord Webhook] The length of the title text has been truncated.");
                    //}

                    int TruncuationLengthPerDescription = 1780;
                    bool TruncationOccurred = false;

                    string truncMessage = message;
                    string truncDescription1 = description1;
                    string truncDescription2 = description2;

                    try
                    {
                        if (!string.IsNullOrEmpty(title) && title.Length >= 118)
                        {
                            title = string.Concat(title.AsSpan(0, 108), "\x20...(truncated)");
                            TruncationOccurred = true;
                            Console.WriteLine("[Discord Webhook] The length of the title text has been truncated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Discord Webhook] Truncation error. {ex.Message}");
                        title = "Unknown";
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(message) && message.Length >= 950)
                        {
                            truncMessage = string.Concat(message.AsSpan(0, 950), "\x20...(see txt file)");
                            TruncationOccurred = true;
                            Console.WriteLine("[Discord Webhook] The length of the message text has been truncated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Discord Webhook] Truncation error. {ex.Message}");
                        message = "Unknown";
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(description1) && description1.Length >= TruncuationLengthPerDescription)
                        {
                            truncDescription1 = string.Concat(description1.AsSpan(0, TruncuationLengthPerDescription), "\x20...(see txt file)");
                            TruncationOccurred = true;
                            Console.WriteLine("[Discord Webhook] The length of the intro text has been truncated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Discord Webhook] Truncation error. {ex.Message}");
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(description2) && description2.Length >= TruncuationLengthPerDescription)
                        {
                            truncDescription2 = string.Concat(description2.AsSpan(0, TruncuationLengthPerDescription), "\x20...(see txt file)");
                            TruncationOccurred = true;
                            Console.WriteLine("[Discord Webhook] The length of the body text has been truncated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Discord Webhook] Truncation error. {ex.Message}");
                    }

                    string Fields = string.Empty;

                    if (QuickSettings.Instance.AddIntroText && !string.IsNullOrWhiteSpace(truncDescription1))
                    {
                        Fields += $"**Alert Info**\r\n" +
                            $"\r\n{truncDescription1}\r\n" +
                            $"\r\n";
                    }

                    Fields += $"**Alert Text**\r\n" +
                        $"\r\n{truncDescription2}\r\n";

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

                    var EventDecode = AlertDetails.SAME_AlertCodes.Find(t => t.Name == title);

                    string ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Misc/UNK.png";

                    if (EventDecode != null)
                    {
                        switch (EventDecode.EventLevel)
                        {
                            case AlertDetails.SAME_EventLevel.None:
                            default:
                                //ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Misc/UNK.png";
                                break;
                            case AlertDetails.SAME_EventLevel.Other:
                                ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Other/{EventDecode.ID.ToUpperInvariant()}.png";
                                break;
                            case AlertDetails.SAME_EventLevel.Test:
                                ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Tests/{EventDecode.ID.ToUpperInvariant()}.png";
                                break;
                            case AlertDetails.SAME_EventLevel.Advisory:
                                ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Advisories/{EventDecode.ID.ToUpperInvariant()}.png";
                                break;
                            case AlertDetails.SAME_EventLevel.Watch:
                                ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Watches/{EventDecode.ID.ToUpperInvariant()}.png";
                                break;
                            case AlertDetails.SAME_EventLevel.Warning:
                                ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Warnings/{EventDecode.ID.ToUpperInvariant()}.png";
                                break;

                        }
                    }

                    try
                    {
                        var task = Client.GetAsync(ThumbnailURL);
                        task.Wait(15000);
                        if (!task.IsFaulted && task.Result != null)
                        {
                            task.Result.EnsureSuccessStatusCode();
                        }
                        else
                        {
                            throw new Exception("Unknown fault, or result is still null.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[Discord Webhook] Failed to fetch asset (fallback will be used): " + ex.Message);
                        ThumbnailURL = $"https://bunnytub.com/SharpAlert-Assets/Misc/UNK.png";
                    }

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
                                thumbnail = new { url = ThumbnailURL },
                                footer = new { text = "Identifier: " + Identifier },
                                timestamp = $"{DateTimeOffset.UtcNow:s}"
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

                    if (TruncationOccurred)
                    {
                        var sbFile = new StringBuilder();
                        sbFile.Append("\r\n--").Append(boundary).Append("\r\n");
                        sbFile.Append("Content-Disposition: form-data; name=\"file\"; filename=\"Full_Alert_Text.txt\"").Append("\r\n");
                        sbFile.Append("Content-Type: text/plain; charset=utf-8").Append("\r\n");
                        sbFile.Append("\r\n");

                        TextFileHeaderBytes = Encoding.UTF8.GetBytes(sbFile.ToString());

                        // Convert the truncated text to bytes
                        string text = "SharpAlert determined the message is too big to fully display as a message.\r\n\r\n" +
                            "--- Alert Info ---\r\n\r\n" +
                            $"{description1}\r\n\r\n" +
                            "--- Alert Text ---\r\n\r\n" +
                            $"{description2}";
                        textBytes = Encoding.UTF8.GetBytes(text);
                    }

                    if (!string.IsNullOrWhiteSpace(AudioDeref))
                    {
                        var sbFile = new StringBuilder();
                        sbFile.Append("\r\n--").Append(boundary).Append("\r\n");
                        sbFile.Append("Content-Disposition: form-data; name=\"file\"; filename=\"Audio_Attachment.mp3\"").Append("\r\n"); // just give up
                        sbFile.Append("Content-Type: audio/mpeg").Append("\r\n");
                        sbFile.Append("\r\n");
                        AudioFileHeaderBytes = Encoding.UTF8.GetBytes(sbFile.ToString());

                        try
                        {
                            audioBytes = Convert.FromBase64String(AudioDeref);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("[Discord Webhook] Failed to decode audio: " + ex.Message);
                            audioBytes = null;
                        }
                    }
                    else
                    {
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
                                var task = Client.GetByteArrayAsync(AudioURL);
                                task.Wait(15000);
                                if (!task.IsFaulted && task.Result != null)
                                {
                                    audioBytes = task.Result;
                                }
                                else
                                {
                                    throw new Exception("Unknown fault, or result is still null.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("[Discord Webhook] Failed to fetch audio: " + ex.Message);
                                audioBytes = null;
                            }
                        }
                    }

                    byte[] closingBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                    using var ms = new MemoryStream();
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
            catch (Exception ex)
            {
                Console.WriteLine("[Discord Webhook] Fault during message processing. " + ex.Message);
            }
        }
    }
}
