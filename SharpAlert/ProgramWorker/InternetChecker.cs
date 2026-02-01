using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SharpAlert.ProgramWorker
{
    public static class InternetChecker
    {
        public static async Task<bool> IsConnectedToInternetAsync()
        {
            int maxHops = 30;
            string ipAddr1 = "8.8.8.8";

            for (int ttl = 1; ttl <= maxHops; ttl++)
            {
                byte[] buffer = new byte[32];

                PingReply reply;

                try
                {
                    using var pinger = new Ping();
                    reply = await pinger.SendPingAsync(ipAddr1, 10000, buffer, new PingOptions(ttl, true));
                }
                catch (PingException ex)
                {
                    Console.WriteLine($"[Internet Checker] Ping failed: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Internet Checker] Something failed: {ex.Message}");
                    return false;
                }

                Console.WriteLine($"[Internet Checker] Hop {ttl} is {reply.Address?.ToString() ?? "not known"}: {reply.Status}");

                if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.Success)
                {
                    Console.WriteLine($"[Internet Checker] Hop {ttl} is {reply.Status}, an internet connection may not be possible.");
                    return false;
                }

                if (IsRoutableAddress(reply.Address))
                {
                    Console.WriteLine($"[Internet Checker] An internet connection is likely available.");
                    return true;
                }
            }

            return false;
        }

        private static bool IsRoutableAddress(IPAddress addr)
        {
            if (addr == null)
            {
                return false;
            }
            else if (addr.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return !addr.IsIPv6LinkLocal && !addr.IsIPv6SiteLocal;
            }
            else
            {
                byte[] bytes = addr.GetAddressBytes();
                if (bytes[0] == 10) return false;
                else if (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] <= 31) return false;
                else if (bytes[0] == 192 && bytes[1] == 168) return false;
                else return true;
            }
        }
    }
}
