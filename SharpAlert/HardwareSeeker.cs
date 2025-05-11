//using System;
//using System.Management;
//using System.Text;

//namespace SharpAlert
//{
//    public class HardwareSeeker
//    {
//        private static readonly string _ = "DEFAULT";
//        public readonly string DeviceID = string.Empty;

//        public HardwareSeeker()
//        {
//            string processor = GetProcessorID();
//            string serial = GetSystemSerialNumber();
//            string uuid = GetSystemUUID();

//            uint checksum = CRC32.ComputeChecksum(Encoding.UTF8.GetBytes($"{processor}/{serial}/{uuid}"));
//            DeviceID = checksum.ToString();
//        }

//        private static string GetProcessorID()
//        {
//            try
//            {
//                using (var searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
//                {
//                    foreach (var obj in searcher.Get())
//                    {
//                        return obj["ProcessorId"]?.ToString().Trim();
//                    }
//                }
//            }
//            catch (Exception)
//            {
//            }
            
//            return _;
//        }

//        private static string GetSystemSerialNumber()
//        {
//            try
//            {
//                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
//                {
//                    foreach (var obj in searcher.Get())
//                    {
//                        return obj["SerialNumber"]?.ToString().Trim();
//                    }
//                }
//            }
//            catch (Exception)
//            {
//            }

//            return _;
//        }

//        private static string GetSystemUUID()
//        {
//            try
//            {
//                using (var searcher = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct"))
//                {
//                    foreach (var obj in searcher.Get())
//                    {
//                        return obj["UUID"]?.ToString().Trim();
//                    }
//                }
//            }
//            catch (Exception)
//            {
//            }

//            return _;
//        }

//        private static class CRC32
//        {
//            private static readonly uint[] Table;

//            static CRC32()
//            {
//                Table = new uint[256];
//                const uint polynomial = 0xEDB88320;
//                for (uint i = 0; i < Table.Length; i++)
//                {
//                    uint entry = i;
//                    for (int j = 0; j < 8; j++)
//                    {
//                        if ((entry & 1) == 1)
//                            entry = (entry >> 1) ^ polynomial;
//                        else
//                            entry >>= 1;
//                    }
//                    Table[i] = entry;
//                }
//            }

//            public static uint ComputeChecksum(byte[] bytes)
//            {
//                uint crc = 0xFFFFFFFF;
//                foreach (var b in bytes)
//                {
//                    byte index = (byte)((crc & 0xFF) ^ b);
//                    crc = (crc >> 8) ^ Table[index];
//                }
//                return ~crc;
//            }
//        }

//    }
//}
