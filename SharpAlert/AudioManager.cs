using NAudio.Wave;
using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.AlertProcessor;

namespace SharpAlert
{
    public static class AudioManager
    {
        private static readonly List<WasapiOut> Outputs = new List<WasapiOut>();
        private static bool HoldIt = false;

        public static void StopAllAudio(bool NoEOM)
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                try
                {
                    Console.WriteLine("[Audio Manager] Preparing to stop all audio.");

                    HoldIt = NoEOM;

                    List<WasapiOut> Outs = new List<WasapiOut>();
                    lock (Outputs)
                    {
                        foreach (WasapiOut output in Outputs)
                        {
                            Outs.Add(output);
                        }
                    }

                    foreach (WasapiOut output in Outs)
                    {
                        try
                        {
                            lock (output)
                            {
                                //output?.Stop();
                                output?.Dispose();
                                lock (Outputs) Outputs.Remove(output);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                    }

                    Thread.Sleep(1000);
                    HoldIt = false;

                    Console.WriteLine("[Audio Manager] Attempted to stop all audio.");
                }
                catch (Exception)
                {
                    lock (notify)
                    {
                        notify.BalloonTipTitle = "SharpAlert is having issues";
                        notify.BalloonTipText = "Audio playback is not working as expected. Please check your audio devices!";
                        notify.BalloonTipIcon = ToolTipIcon.Warning;
                        notify.ShowBalloonTip(5000);
                    }
                }
            });
        }
        
        public static void StopAllAudioSilently()
        {
            try
            {
                List<WasapiOut> Outs = new List<WasapiOut>();
                lock (Outputs)
                {
                    foreach (WasapiOut output in Outputs)
                    {
                        Outs.Add(output);
                    }
                }

                foreach (WasapiOut output in Outs)
                {
                    try
                    {
                        lock (output)
                        {
                            //output?.Stop();
                            output?.Dispose();
                            lock (Outputs) Outputs.Remove(output);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] {ex.Message}");
                    }
                }

                HoldIt = false;
            }
            catch (Exception)
            {
                lock (notify)
                {
                    notify.BalloonTipTitle = "SharpAlert is having issues";
                    notify.BalloonTipText = "Audio playback is not working as expected. Please check your audio devices!";
                    notify.BalloonTipIcon = ToolTipIcon.Warning;
                    notify.ShowBalloonTip(5000);
                }
            }
        }

        public static void PlayWithFailoverToTTS(string url, string text)
        {
            if (!Settings.Default.alertTTSonly)
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    try
                    {
                        PlayFromRemoteSource(url, false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] Failed to play remote audio. TTS will be played instead. {ex.Message}");
                        PlayFromTTSEngine(StringIntoTTSFriendly(text));
                    }
                }
                else
                {
                    PlayFromTTSEngine(StringIntoTTSFriendly(text));
                }
            }
            else
            {
                PlayFromTTSEngine(StringIntoTTSFriendly(text));
            }
        }

        public static void PlayFromRemoteSource(string url, bool eom)
        {
            //throw new Exception("SharpAlert is currently undergoing an audio rewrite, so remote audio is disabled for now.");
            try
            {
                //IceBearWorker.client.GetByteArrayAsync(url).Result;
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Console.WriteLine("[Audio Manager] Queued remote audio.");
                    try
                    {
                        using (var mf = new AudioFileReader(url))
                        {
                            lock (AudioOutputLock)
                            {
                                Console.WriteLine("[Audio Manager] Audio queue locked.");
                                WasapiOut AudioOutput = new WasapiOut();
                                Outputs.Add(AudioOutput);
                                float volume = Settings.Default.alertVolume / 10f;
                                AudioOutput.Init(mf);
                                for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                AudioOutput.Play();
                                while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                                {
                                    Thread.Sleep(50);
                                }
                                if (HoldIt)
                                {
                                    Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                    return;
                                }
                                Outputs.Remove(AudioOutput);
                                if (eom) PlayFromUnmanagedSourceAndWait(Resources.ui_end_1);
                                AudioOutput.Dispose();
                            }
                            Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                        }
                    }
                    catch (Exception)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "Audio playback is not working as expected. Please make sure your audio devices are working!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        public static void PlayFromUnmanagedSource(UnmanagedMemoryStream unmanaged)
        {
            try
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Console.WriteLine("[Audio Manager] Queued unmanaged audio.");
                    try
                    {
                        MemoryStream stream = new MemoryStream();
                        unmanaged.CopyTo(stream);
                        using (var mf = new StreamMediaFoundationReader(stream))
                        {
                            lock (AudioOutputLock)
                            {
                                Console.WriteLine("[Audio Manager] Audio queue locked.");
                                WasapiOut AudioOutput = new WasapiOut();
                                Outputs.Add(AudioOutput);
                                float volume = Settings.Default.alertVolume / 10f;
                                AudioOutput.Init(mf);
                                for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                AudioOutput.Play();
                                while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                                {
                                    Thread.Sleep(50);
                                }
                                if (HoldIt)
                                {
                                    Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                    return;
                                }
                                Outputs.Remove(AudioOutput);
                                AudioOutput.Dispose();
                            }
                            Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                        }
                    }
                    catch (Exception)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "Audio playback is not working as expected. Please make sure your audio devices are working!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        public static void PlayFromUnmanagedSourceAndWait(UnmanagedMemoryStream unmanaged)
        {
            try
            {
                Console.WriteLine("[Audio Manager] Preparing to play in the current thread.");
                MemoryStream stream = new MemoryStream();
                unmanaged.CopyTo(stream);
                using (var mf = new StreamMediaFoundationReader(stream))
                {
                    WasapiOut AudioOutput = new WasapiOut();
                    Outputs.Add(AudioOutput);
                    float volume = Settings.Default.alertVolume / 10f;
                    AudioOutput.Init(mf);
                    for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                    AudioOutput.Play();
                    while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                    {
                        Thread.Sleep(50);
                    }
                    if (HoldIt)
                    {
                        Console.WriteLine("[Audio Manager] Audio closed.");
                        return;
                    }
                    Outputs.Remove(AudioOutput);
                    AudioOutput.Dispose();
                }
            }
            catch (Exception)
            {
                lock (notify)
                {
                    notify.BalloonTipTitle = "SharpAlert is having issues";
                    notify.BalloonTipText = "Audio playback is not working as expected. Please make sure your audio devices are working!";
                    notify.BalloonTipIcon = ToolTipIcon.Warning;
                    notify.ShowBalloonTip(5000);
                }
            }
        }
        

        public static void PlayFromTTSEngine(string tts)
        {
            try
            {
                //IceBearWorker.client.GetByteArrayAsync(url).Result;
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Console.WriteLine("[Audio Manager] Queued TTS audio.");
                    try
                    {
                        lock (AudioOutputLock)
                        {
                            Console.WriteLine("[Audio Manager] Audio queue locked.");
                            MemoryStream stream = new MemoryStream();
                            engine.SetOutputToWaveStream(stream);
                            engine.Speak(tts);
                            using (var mf = new StreamMediaFoundationReader(stream))
                            {
                                WasapiOut AudioOutput = new WasapiOut();
                                Outputs.Add(AudioOutput);
                                float volume = Settings.Default.alertVolume / 10f;
                                AudioOutput.Init(mf);
                                for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                AudioOutput.Play();
                                while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                                {
                                    Thread.Sleep(50);
                                }
                                if (HoldIt)
                                {
                                    Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                    return;
                                }
                                Outputs.Remove(AudioOutput);
                                AudioOutput.Dispose();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "TTS playback is not working as expected. Please make sure your audio devices are working!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                    Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        public static void PlayFromTTSEngineAndWait(string tts)
        {
            try
            {
                Console.WriteLine("[Audio Manager] Preparing to play in the current thread.");
                lock (AudioOutputLock)
                {
                    Console.WriteLine("[Audio Manager] Audio queue locked.");
                    MemoryStream stream = new MemoryStream();
                    engine.SetOutputToWaveStream(stream);
                    engine.Speak(tts);
                    using (var mf = new StreamMediaFoundationReader(stream))
                    {
                        WasapiOut AudioOutput = new WasapiOut();
                        Outputs.Add(AudioOutput);
                        float volume = Settings.Default.alertVolume / 10f;
                        AudioOutput.Init(mf);
                        for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                        AudioOutput.Play();
                        while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                        {
                            Thread.Sleep(50);
                        }
                        if (HoldIt)
                        {
                            Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                            return;
                        }
                        Outputs.Remove(AudioOutput);
                        AudioOutput.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                lock (notify)
                {
                    notify.BalloonTipTitle = "SharpAlert is having issues";
                    notify.BalloonTipText = "Audio playback is not working as expected. Please make sure your audio devices are working!";
                    notify.BalloonTipIcon = ToolTipIcon.Warning;
                    notify.ShowBalloonTip(5000);
                }
            }
        }
    }
}
