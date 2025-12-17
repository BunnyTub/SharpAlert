using NAudio.CoreAudioApi;
using Open.Nat;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class ShareAlertsForm : Form
    {
        public ShareAlertsForm()
        {
            InitializeComponent();
        }

        private NatDevice device;
        private readonly int port = 5577;

        private async void ShareAlertsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var discoverer = new NatDiscoverer();
                var cts = new CancellationTokenSource(5000);
                device = await discoverer.DiscoverDeviceAsync(PortMapper.Upnp | PortMapper.Pmp, cts);

                await device.CreatePortMapAsync(new Mapping(Protocol.Tcp, port, port, "SharpAlert Sharing"));

                //var listener = new TcpListener(IPAddress.Any, port);
                //listener.Start();

                StatusText.Text = "Waiting for a connection...";

                MessageBox.Show($"Started peer-to-peer sharing.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                cts.Dispose();
            }
            catch (NatDeviceNotFoundException)
            {
                MessageBox.Show($"Your router doesn't appear to have UPnP or NAT-PMP available. To use peer-to-peer sharing, turn on UPnP or NAT-PMP in your router's settings.\r\n\r\nIf neither features are available, you may need to port forward a port ({port}) in your router's firewall settings.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StatusText.Text = "No connection available.";
                MessageBox.Show($"Could not start peer-to-peer sharing. {ex.Message}", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ShareAlertsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await device?.DeletePortMapAsync(new Mapping(Protocol.Tcp, port, port));
            }
            catch (MappingException ex)
            {
                MessageBox.Show($"Could not fully stop peer-to-peer sharing.\r\n{ex.ErrorText} ({ex.ErrorCode})", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not fully stop peer-to-peer sharing.\r\n{ex.Message}", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
