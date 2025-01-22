using System;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SharpAlert
{
    public static class AlertToWebhook
    {
        private static readonly WebClient client = new WebClient();

        public static bool SendUnformattedMessage(string message, string webhook)
        {
            try
            {
                var payloadObject = new { content = message };
                string payloadJson = JsonSerializer.Serialize(payloadObject);
                client.Headers.Set(HttpRequestHeader.ContentType, "application/json");
                client.UploadData(webhook, Encoding.UTF8.GetBytes(payloadJson));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}