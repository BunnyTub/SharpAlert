using NAudio.Wave;
using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.AlertProcessor;
using static SharpAlert.IceBearWorker;
using System.Diagnostics;
using System.Text;

namespace SharpAlert
{
    public static class AudioManager
    {
        private static readonly List<WasapiOut> Outputs = new List<WasapiOut>();
        private static readonly List<WasapiOut> TTSOutputs = new List<WasapiOut>();
        private static bool HoldIt = false;
        private static bool TTSHoldIt = false;

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
                                output?.Stop();
                                //output?.Dispose();
                            }
                            lock (Outputs) Outputs.Remove(output);
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
                catch (Exception ex)
                {
                    Console.WriteLine($"[Audio Manager] {ex.Message}");
                    //lock (notify)
                    //{
                    //    notify.BalloonTipTitle = "SharpAlert is having issues";
                    //    notify.BalloonTipText = "Audio playback is not working as expected. Please check your audio devices!";
                    //    notify.BalloonTipIcon = ToolTipIcon.Warning;
                    //    notify.ShowBalloonTip(5000);
                    //}
                }
            });
        }
        
        public static void StopAllAudioSilently()
        {
            try
            {
                HoldIt = true;
                TTSHoldIt = true;

                List<WasapiOut> Outs = new List<WasapiOut>();
                lock (Outputs)
                {
                    foreach (WasapiOut output in Outputs)
                    {
                        Outs.Add(output);
                    }
                    
                    foreach (WasapiOut output in TTSOutputs)
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
                            output?.Stop();
                            //output?.Dispose();
                        }
                        lock (Outputs) Outputs.Remove(output);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] {ex.Message}");
                    }
                }

                HoldIt = false;
                TTSHoldIt = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
                //lock (notify)
                //{
                //    notify.BalloonTipTitle = "SharpAlert is having issues";
                //    notify.BalloonTipText = "Audio playback is not working as expected. Please check your audio devices!";
                //    notify.BalloonTipIcon = ToolTipIcon.Warning;
                //    notify.ShowBalloonTip(5000);
                //}
            }
        }

        public static void StopTTSAudioSilently()
        {
            try
            {
                TTSHoldIt = true;

                List<WasapiOut> Outs = new List<WasapiOut>();
                lock (Outputs)
                {
                    foreach (WasapiOut output in TTSOutputs)
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
                            output?.Stop();
                            //output?.Dispose();
                        }
                        lock (Outputs) Outputs.Remove(output);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] {ex.Message}");
                    }
                }

                TTSHoldIt = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
                //lock (notify)
                //{
                //    notify.BalloonTipTitle = "SharpAlert is having issues";
                //    notify.BalloonTipText = "Audio playback is not working as expected. Please check your audio devices!";
                //    notify.BalloonTipIcon = ToolTipIcon.Warning;
                //    notify.ShowBalloonTip(5000);
                //}
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
                        PlayFromRemoteSource(url);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] Failed to play remote audio. TTS will be played instead. {ex.Message}");
                        PlayFromTTSEngine(StringIntoTTSFriendly(text), false);
                    }
                }
                else
                {
                    PlayFromTTSEngine(StringIntoTTSFriendly(text), false);
                }
            }
            else
            {
                Console.WriteLine($"[Audio Manager] User settings prohibit remote audio. TTS will be played instead.");
                PlayFromTTSEngine(StringIntoTTSFriendly(text), false);
            }
        }

        public static void PlayFromRemoteSource(string url)
        {
            try
            {
                //IceBearWorker.client.GetByteArrayAsync(url).Result;
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Console.WriteLine("[Audio Manager] Queued remote audio.");
                    try
                    {
                        PlayFromManagedSource(new MemoryStream(client.GetByteArrayAsync(url).Result), true);
                        //using (var mf = new AudioFileReader(url))
                        //{
                        //    lock (AudioOutputLock)
                        //    {
                        //        Console.WriteLine("[Audio Manager] Audio queue locked.");
                        //        WasapiOut AudioOutput = new WasapiOut();
                        //        Outputs.Add(AudioOutput);
                        //        float volume = Settings.Default.alertVolume / 10f;
                        //        AudioOutput.Init(mf);
                        //        for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                        //        AudioOutput.Play();
                        //        while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                        //        {
                        //            Thread.Sleep(50);
                        //        }
                        //        if (HoldIt)
                        //        {
                        //            Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                        //            return;
                        //        }
                        //        Outputs.Remove(AudioOutput);
                        //        if (eom) PlayFromUnmanagedSourceAndWait(Resources.ui_end_1);
                        //        AudioOutput.Dispose();
                        //    }
                        //    Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                        //}
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] {ex.Message}");
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

        public static bool ToneDone = true;

        public static void PlayStartToneFile(bool wait = false)
        {
            StopAllAudioSilently();
            ToneDone = false;

            //if (!Settings.Default.alertPlayStartTone)
            //{
            //    ToneDone = true;
            //    return;
            //}

            try
            {
                void playAudio()
                {
                    string path = Settings.Default.StartToneLocation;
                    //if (!string.IsNullOrWhiteSpace(path))
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(path))
                            {
                                Console.WriteLine("[Audio Manager] No audio file specified inside the configuration.");
                                PlayFromUnmanagedSourceAndWait(Resources.ui_warning_1, false);
                            }
                            else
                            {
                                using (var reader = new MediaFoundationReader(path))
                                {
                                    lock (AudioOutputLock)
                                    {
                                        Console.WriteLine("[Audio Manager] Audio queue locked.");
                                        WasapiOut AudioOutput = new WasapiOut();
                                        Outputs.Add(AudioOutput);
                                        float volume = Settings.Default.alertVolume / 10f;
                                        AudioOutput.Init(reader);
                                        for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++)
                                            AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);

                                        AudioOutput.Play();
                                        while (AudioOutput.PlaybackState == PlaybackState.Playing && !HoldIt)
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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                        }
                        ToneDone = true;
                    }
                }
                if (wait) playAudio();
                else ThreadPool.QueueUserWorkItem(_ => playAudio());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
                ToneDone = true;
            }
        }
        
        public static void PlayEndToneFile(bool wait = false)
        {
            StopAllAudioSilently();
            ToneDone = false;

            if (!Settings.Default.alertPlayEndTone)
            {
                ToneDone = true;
                return;
            }

            try
            {
                void playAudio()
                {
                    string path = Settings.Default.EndToneLocation;
                    //if (!string.IsNullOrWhiteSpace(path))
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(path))
                            {
                                Console.WriteLine("[Audio Manager] No audio file specified inside the configuration.");
                                PlayFromUnmanagedSource(Resources.ui_end_1);
                            }
                            else
                            {
                                using (var reader = new MediaFoundationReader(path))
                                {
                                    lock (AudioOutputLock)
                                    {
                                        Console.WriteLine("[Audio Manager] Audio queue locked.");
                                        WasapiOut AudioOutput = new WasapiOut();
                                        Outputs.Add(AudioOutput);
                                        float volume = Settings.Default.alertVolume / 10f;
                                        AudioOutput.Init(reader);
                                        for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++)
                                            AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);

                                        AudioOutput.Play();
                                        // && !HoldIt
                                        while (AudioOutput.PlaybackState == PlaybackState.Playing)
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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                        }
                        ToneDone = true;
                    }
                }

                if (wait) playAudio();
                else ThreadPool.QueueUserWorkItem(_ => playAudio());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
                ToneDone = true;
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
                        using (MemoryStream stream = new MemoryStream())
                        {
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

        public static void PlayFromManagedSource(MemoryStream stream, bool TTS = false)
        {
            try
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Console.WriteLine("[Audio Manager] Queued managed audio.");
                    try
                    {
                        using (var mf = new StreamMediaFoundationReader(stream))
                        {
                            lock (AudioOutputLock)
                            {
                                Console.WriteLine("[Audio Manager] Audio queue locked.");

                                WasapiOut AudioOutput = new WasapiOut();
                                if (TTS) TTSOutputs.Add(AudioOutput);
                                else Outputs.Add(AudioOutput);
                                float volume = Settings.Default.alertVolume / 10f;
                                AudioOutput.Init(mf);
                                for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                AudioOutput.Play();

                                Console.WriteLine("A");

                                while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                                {
                                    Thread.Sleep(50);
                                    Console.WriteLine("B");
                                }
                                if (HoldIt)
                                {
                                    Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                    return;
                                }
                                if (TTS) TTSOutputs.Remove(AudioOutput);
                                else Outputs.Remove(AudioOutput);
                                AudioOutput.Dispose();
                            }
                            Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] {ex.Message}");
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

        public static void PlayFromUnmanagedSourceAndWait(UnmanagedMemoryStream unmanaged, bool ignoreinterrupt)
        {
            try
            {
                Console.WriteLine("[Audio Manager] Preparing to play in the current thread.");
                using (MemoryStream stream = new MemoryStream())
                {
                    unmanaged.CopyTo(stream);
                    using (var mf = new StreamMediaFoundationReader(stream))
                    {
                        WasapiOut AudioOutput = new WasapiOut();
                        Outputs.Add(AudioOutput);
                        float volume = Settings.Default.alertVolume / 10f;
                        AudioOutput.Init(mf);
                        for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                        AudioOutput.Play();
                        while (AudioOutput.PlaybackState == PlaybackState.Playing & !(HoldIt & ignoreinterrupt))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
                lock (notify)
                {
                    notify.BalloonTipTitle = "SharpAlert is having issues";
                    notify.BalloonTipText = "Audio playback is not working as expected. Please make sure your audio devices are working!";
                    notify.BalloonTipIcon = ToolTipIcon.Warning;
                    notify.ShowBalloonTip(5000);
                }
            }
        }

        public static void PlayFromTTSEngine(string tts, bool wait)
        {
            try
            {
                void playAudio()
                {
                    Console.WriteLine("[Audio Manager] Queued TTS audio.");
                    try
                    {
                        lock (AudioOutputLock)
                        {
                            Console.WriteLine("[Audio Manager] Audio queue locked.");
                            using (MemoryStream stream = new MemoryStream())
                            {
                                bool UseMaki = false;

                                if (!string.IsNullOrWhiteSpace(Settings.Default.ProgramVoice))
                                {
                                    try
                                    {
                                        engine.SelectVoice(Settings.Default.ProgramVoice);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        UseMaki = true;
                                    }
                                }

                                bool MakiSuccess = false;

                                if (UseMaki)
                                {
                                    //$"{AssemblyDirectory}\\Maki.exe", $"--voice-syntax-console \"{Settings.Default.ProgramVoice}|{tts.Replace("|", "_")}\""
                                    ProcessStartInfo maki = new ProcessStartInfo
                                    {
                                        FileName = $"{AssemblyDirectory}\\Maki.exe",
                                        Arguments = $"--voice-syntax-console \"{Settings.Default.ProgramVoice}|{tts.Replace("|", "_")}\"",
                                        RedirectStandardOutput = true
                                    };
                                    Process MakiProcess = Process.Start(maki);
                                    MakiProcess.WaitForExit();
                                    if (MakiProcess.ExitCode == 0)
                                    {
                                        using (var MakiOut = MakiProcess.StandardOutput.BaseStream)
                                        {
                                            MakiOut.CopyTo(stream);
                                        }
                                    }

                                    MakiSuccess = true;
                                }

                                if (!MakiSuccess)
                                {
                                    engine.SetOutputToWaveStream(stream);
                                    engine.Speak(tts);
                                }

                                using (var mf = new StreamMediaFoundationReader(stream))
                                {
                                    WasapiOut AudioOutput = new WasapiOut();
                                    TTSOutputs.Add(AudioOutput);
                                    float volume = Settings.Default.alertVolume / 10f;
                                    AudioOutput.Init(mf);
                                    for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                    AudioOutput.Play();
                                    while (AudioOutput.PlaybackState == PlaybackState.Playing & !TTSHoldIt)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    if (TTSHoldIt)
                                    {
                                        Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                        return;
                                    }
                                    TTSOutputs.Remove(AudioOutput);
                                    AudioOutput.Dispose();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Audio Manager] {ex.Message}");
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "TTS playback is not working as expected. Please make sure your audio devices are working!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                    Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                }

                if (wait) playAudio();
                else ThreadPool.QueueUserWorkItem(_ => playAudio());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        //private static readonly int sampleRate = 44100;
        //private static readonly int baudRate = 1200;
        //private static readonly double freqMark = 646.0;   // '1'
        //private static readonly double freqSpace = 1033.0; // '0'

        //public static MemoryStream EncodeToWave(string bitString)
        //{
        //    int samplesPerBit = sampleRate / baudRate;
        //    var rawStream = new MemoryStream();

        //    using (var writer = new BinaryWriter(rawStream, Encoding.ASCII, leaveOpen: true))
        //    {
        //        foreach (char bit in bitString)
        //        {
        //            double freq = bit == '1' ? freqMark : freqSpace;

        //            for (int i = 0; i < samplesPerBit; i++)
        //            {
        //                double t = (double)i / sampleRate;
        //                short sample = (short)(Math.Sin(2 * Math.PI * freq * t) * short.MaxValue);
        //                writer.Write(sample);
        //            }
        //        }
        //    }

        //    //rawStream.Position = 0;

        //    var waveFormat = new WaveFormat(sampleRate, 16, 1);
        //    var waveData = new MemoryStream();
        //    var waveWriter = new WaveFileWriter(waveData, waveFormat);
        //    //rawStream.Position = 0;
        //    rawStream.CopyTo(waveWriter);
        //    //waveData.Position = 0;
        //    Console.WriteLine(waveData.Length);
        //    return waveData;
        //}
    }
}
