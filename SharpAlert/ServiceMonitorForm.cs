using System;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpAlert.ProgramWorker.ServiceThreads;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using SharpAlert.SourceCapturing;

namespace SharpAlert
{
    public partial class ServiceMonitorForm : Form
    {
        public ServiceMonitorForm()
        {
            InitializeComponent();
        }

        void UpdateStatus(ThreadState threadState, Label statusLabel, WinFormsControls.ToolboxStuff.BorderPanel borderPanel, string SpecialText = "")
        {
            switch (threadState)
            {
                case ThreadState.Running:
                    if (string.IsNullOrEmpty(SpecialText)) statusLabel.Text = "Running";
                    else statusLabel.Text = SpecialText;
                    borderPanel.BorderColor = Color.Lime;
                    break;
                case ThreadState.WaitSleepJoin:
                    if (string.IsNullOrEmpty(SpecialText)) statusLabel.Text = "Idle";
                    else statusLabel.Text = SpecialText;
                    borderPanel.BorderColor = Color.Orange;
                    break;
                case ThreadState.Unstarted:
                    statusLabel.Text = "Not Running";
                    borderPanel.BorderColor = Color.White;
                    break;
                case ThreadState.Stopped:
                    statusLabel.Text = "Stopped";
                    borderPanel.BorderColor = Color.Red;
                    break;
                default:
                    statusLabel.Text = "Unknown";
                    borderPanel.BorderColor = Color.Yellow;
                    break;
            }
        }

        private bool AlertFirstRun = true;

        private async void UpdateStatusPage_Tick(object sender, EventArgs e)
        {
            UpdateStatus(feedThread.ThreadState, FeedCaptureStatusText, FeedCapturePanel); // HTTP
            UpdateStatus(atomfeedThread.ThreadState, AtomFeedCaptureStatusText, AtomFeedCapturePanel); // ATOM
            UpdateStatus(idapfeedThread.ThreadState, IDAPCaptureStatusText, IDAPCapturePanel); // IDAP

            // moved DirectFeedCapture to separate timer

            UpdateStatus(cacheThread.ThreadState, CacheCaptureStatusText, CacheCapturePanel); // CACHE
            UpdateStatus(dataProcThread.ThreadState, DataProcessorStatusText, DataProcessorPanel); // DATA
            UpdateStatus(historyProcThread.ThreadState, HistoryProcessorStatusText, HistoryProcessorPanel); // HISTORY

            bool AlertProc = false;

            if (dataproc != null)
            {
                if (dataproc.ap != null)
                {
                    AlertProc = dataproc.ap.AlertInProcessing;
                }
            }
            else
            {
                UpdateStatus(ThreadState.Unstarted, AlertProcessorStatusText, AlertProcessorPanel); // ALERT
            }

            if (AlertFirstRun)
            {
                UpdateStatus(ThreadState.Unstarted, AlertProcessorStatusText, AlertProcessorPanel); // ALERT
            }

            if (AlertProc)
            {
                AlertFirstRun = false;
                UpdateStatus(ThreadState.Running, AlertProcessorStatusText, AlertProcessorPanel); // ALERT
            }
            else
            {
                if (!AlertFirstRun)
                {
                    UpdateStatus(ThreadState.WaitSleepJoin, AlertProcessorStatusText, AlertProcessorPanel); // HISTORY
                }
            }
            await Task.Delay(1);
        }

        private async void UpdateDirectFeedCapture_Tick(object sender, EventArgs e)
        {
            switch (directfeedThread.ThreadState)
            {
                case ThreadState.Running:
                    DirectFeedCaptureStatusText.Text = "Running";
                    DirectFeedCapturePanel.BorderColor = Color.Lime;
                    break;
                case ThreadState.WaitSleepJoin:
                    DirectFeedCaptureStatusText.Text = "Idle";
                    DirectFeedCapturePanel.BorderColor = Color.Orange;
                    break;
                case ThreadState.Unstarted:
                    DirectFeedCaptureStatusText.Text = "Not Running";
                    DirectFeedCapturePanel.BorderColor = Color.White;
                    return;
                case ThreadState.Stopped:
                    DirectFeedCaptureStatusText.Text = "Stopped";
                    DirectFeedCapturePanel.BorderColor = Color.Red;
                    return;
                default:
                    DirectFeedCaptureStatusText.Text = "Unknown";
                    DirectFeedCapturePanel.BorderColor = Color.Yellow;
                    return;
            }

            if (directfeedThread.ThreadState != ThreadState.Stopped)
            {
                bool Running = false;

                lock (DirectFeedCapture.CaptureThreads)
                {
                    foreach (Thread thread in DirectFeedCapture.CaptureThreads)
                    {
                        if (thread.ThreadState == ThreadState.Running)
                        {
                            Running = true;
                            break;
                        }
                    }
                }

                //Task.Delay(500);
                if (Running) UpdateStatus(ThreadState.Running, DirectFeedCaptureStatusText, DirectFeedCapturePanel); // TCP
                else UpdateStatus(ThreadState.WaitSleepJoin, DirectFeedCaptureStatusText, DirectFeedCapturePanel); // TCP

                await Task.Delay(1);
            }
        }

        private void ServiceMonitorForm_Load(object sender, EventArgs e)
        {

        }
    }
}

