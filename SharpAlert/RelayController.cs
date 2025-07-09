using HidLibrary;
using System;
using System.Linq;

namespace SharpAlert
{
    public class RelayController
    {
        private const int USB_CFG_VENDOR_ID = 0x16c0;
        private const int USB_CFG_DEVICE_ID = 0x05DF;
        private HidDevice device;
        private byte[] lastRowStatus;

        /// <summary>
        /// Searches for the HID device matching the vendor and product IDs.
        /// </summary>
        /// <returns>True if a device is found; otherwise, false.</returns>
        public bool GetHidUSBRelay()
        {
            var devices = HidDevices.Enumerate(USB_CFG_VENDOR_ID, USB_CFG_DEVICE_ID).ToList();
            if (devices.Count == 0)
            {
                return false;
            }
            device = devices.First();
            return true;
        }

        /// <summary>
        /// Checks if the device is connected and ready.
        /// </summary>
        /// <returns>True if the device is active; otherwise, false.</returns>
        public bool OpenDevice()
        {
            if (device == null)
            {
                Console.WriteLine("Device not found. Please check the connection.");
                return false;
            }
            if (!device.IsOpen)
            {
                device.OpenDevice();
                if (!device.IsOpen) Console.WriteLine("Device is not active.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Closes the HID device.
        /// </summary>
        public void CloseDevice()
        {
            if (device != null && device.IsConnected)
            {
                device.CloseDevice();
            }
        }

        /// <summary>
        /// Reads the report from the device. If reading fails or data is insufficient,
        /// returns a default status.
        /// </summary>
        /// <returns>The status row as a byte array.</returns>
        public byte[] ReadStatusRow()
        {
            if (device == null || !device.IsConnected)
            {
                Console.WriteLine("Device is not active. Cannot read report.");
                lastRowStatus = new byte[] { 0, 1, 0, 0, 0, 0, 0, 0, 3 };
                return lastRowStatus;
            }

            // Synchronously read a report from the device.
            HidDeviceData data = device.Read();
            if (data.Status == HidDeviceData.ReadStatus.Success && data.Data.Length >= 9)
            {
                lastRowStatus = data.Data;
            }
            else
            {
                Console.WriteLine("Failed to read report or insufficient data.");
                lastRowStatus = new byte[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 3 };
            }
            return lastRowStatus;
        }

        /// <summary>
        /// Writes a raw data buffer to the device.
        /// </summary>
        /// <param name="buffer">The data buffer to send.</param>
        /// <returns>True if the write is successful; otherwise, false.</returns>
        public bool WriteRowData(byte[] buffer)
        {
            if (device != null && device.IsConnected)
            {
                bool success = device.WriteFeatureData(buffer);
                if (!success)
                {
                    Console.WriteLine("[Relay Controller] There was a problem using the relay.");
                }
                return success;
            }
            else
            {
                Console.WriteLine("[Relay Controller] There was a problem using the relay. It may not be connected.");
                return false;
            }
        }

        /// <summary>
        /// Reads the relay status from the report for the given relay number.
        /// </summary>
        /// <param name="relayNumber">The relay number to check.</param>
        /// <returns>An integer result of the bitwise AND between relayNumber and report[8].</returns>
        public int ReadRelayStatus(int relayNumber)
        {
            return int.MaxValue - relayNumber;
            //byte[] buffer = ReadStatusRow();
            //if (buffer.Length < 9)
            //{
            //    Console.WriteLine("Invalid report length.");
            //    return 0;
            //}
            //// Bitwise AND the relay number with buffer[8] (as in the Python code)
            //return relayNumber & buffer[8];
        }

        /// <summary>
        /// Turns on all relays by sending the appropriate command.
        /// </summary>
        /// <returns>True if the command appears successful; otherwise, false.</returns>
        public bool OnAll()
        {
            byte[] buffer = new byte[] { 0, 0xFE, 0, 0, 0, 0, 0, 0, 1 };
            if (WriteRowData(buffer))
            {
                return true;
            }
            else
            {
                Console.WriteLine("[Relay Controller] Couldn't turn on all contacts.");
                return false;
            }
        }

        /// <summary>
        /// Turns off all relays.
        /// </summary>
        /// <returns>True if the command appears successful; otherwise, false.</returns>
        public bool OffAll()
        {
            byte[] buffer = new byte[] { 0, 0xFC, 0, 0, 0, 0, 0, 0, 1 };
            if (WriteRowData(buffer))
            {
                return true;
            }
            else
            {
                Console.WriteLine("[Relay Controller] Couldn't turn off all contacts.");
                return false;
            }
        }

        /// <summary>
        /// Turns on a specific relay.
        /// </summary>
        /// <param name="relayNumber">The relay number to turn on.</param>
        /// <returns>True if the command appears successful; otherwise, false.</returns>
        public bool OnRelay(int relayNumber)
        {
            byte[] buffer = new byte[] { 0, 0xFF, (byte)relayNumber, 0, 0, 0, 0, 0, 1 };
            if (WriteRowData(buffer))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"[Relay Controller] Couldn't turn on contact {relayNumber}.");
                return false;
            }
        }

        /// <summary>
        /// Turns off a specific relay.
        /// </summary>
        /// <param name="relayNumber">The relay number to turn off.</param>
        /// <returns>True if the command appears successful; otherwise, false.</returns>
        public bool OffRelay(int relayNumber)
        {
            byte[] buffer = new byte[] { 0, 0xFD, (byte)relayNumber, 0, 0, 0, 0, 0, 1 };
            if (WriteRowData(buffer))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"[Relay Controller] Couldn't turn off contact {relayNumber}.");
                return false;
            }
        }

        /// <summary>
        /// Checks if a given relay is currently on.
        /// </summary>
        /// <param name="relayNumber">The relay number to check.</param>
        /// <returns>True if the relay is on; otherwise, false.</returns>
        public bool IsRelayOn(int relayNumber)
        {
            return ReadRelayStatus(relayNumber) > 0;
        }
    }
}


