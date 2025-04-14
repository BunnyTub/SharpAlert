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
                        PlayFromManagedSource(new MemoryStream(client.GetByteArrayAsync(url).Result));
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

        public static void PlayStartToneFile()
        {
            ToneDone = false;
            try
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    string path = Settings.Default.StartToneLocation;
                    //if (!string.IsNullOrWhiteSpace(path))
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(path)) throw new Exception("No audio file specified inside the configuration.");
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
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                            PlayFromUnmanagedSourceAndWait(Resources.ui_warning_1);
                        }
                        ToneDone = true;
                    }
                });
                Console.WriteLine($"[Audio Manager] Queued audio.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
                ToneDone = true;
            }
        }
        
        public static void PlayEndToneFile()
        {
            ToneDone = false;
            try
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    string path = Settings.Default.EndToneLocation;
                    //if (!string.IsNullOrWhiteSpace(path))
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(path)) throw new Exception("No audio file specified inside the configuration.");
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
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                            PlayFromUnmanagedSourceAndWait(Resources.ui_warning_1);
                        }
                        ToneDone = false;
                    }
                });
                Console.WriteLine($"[Audio Manager] Queued audio.");
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

        public static void PlayFromManagedSource(MemoryStream stream)
        {
            try
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Console.WriteLine("[Audio Manager] Queued unmanaged audio.");
                    try
                    {
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

        //public static MemoryStream GenerateFSKStream(string inputString)
        //{
        //    const int SampleRate = 44100;
        //    const double BitDuration = 0.015625;  // in seconds
        //    const int Tone0Frequency = 640;  // 0 bit (Space)
        //    const int Tone1Frequency = 1024;  // 1 bit (Mark)

        //    string binaryString = string.Concat(inputString.Select(c => Convert.ToString(c, 2).PadLeft(8, '0')));

        //    var audioData = binaryString.SelectMany(bit =>
        //    {
        //        int frequency = (bit == '0') ? Tone0Frequency : Tone1Frequency;
        //        int totalSamples = (int)(SampleRate * BitDuration);
        //        var samples = new short[totalSamples];
        //        for (int i = 0; i < totalSamples; i++)
        //        {
        //            samples[i] = (short)(Math.Sin(2 * Math.PI * frequency * i / SampleRate) * short.MaxValue);
        //        }
        //        var toneData = new byte[totalSamples * 2];
        //        Buffer.BlockCopy(samples, 0, toneData, 0, toneData.Length);
        //        return toneData;
        //    }).ToArray();

        //    byte[] header = CreateWavHeader(audioData.Length, SampleRate);

        //    var finalStream = new MemoryStream();
        //    finalStream.Write(header, 0, header.Length);
        //    finalStream.Write(audioData, 0, audioData.Length);

        //    return finalStream;
        //}

        private static byte[] CreateWavHeader(int dataSize, int sampleRate)
        {
            byte[] header = new byte[44];

            // RIFF header
            header[0] = (byte)'R';
            header[1] = (byte)'I';
            header[2] = (byte)'F';
            header[3] = (byte)'F';
            BitConverter.GetBytes(36 + dataSize).CopyTo(header, 4);  // ChunkSize
            header[8] = (byte)'W';
            header[9] = (byte)'A';
            header[10] = (byte)'V';
            header[11] = (byte)'E';

            // fmt subchunk
            header[12] = (byte)'f';
            header[13] = (byte)'m';
            header[14] = (byte)'t';
            header[15] = (byte)' ';
            BitConverter.GetBytes(16).CopyTo(header, 16);  // Subchunk1Size
            BitConverter.GetBytes((short)1).CopyTo(header, 20);  // AudioFormat
            BitConverter.GetBytes((short)1).CopyTo(header, 22);  // NumChannels
            BitConverter.GetBytes(sampleRate).CopyTo(header, 24);  // SampleRate
            BitConverter.GetBytes(sampleRate * 2).CopyTo(header, 28);  // ByteRate
            BitConverter.GetBytes((short)2).CopyTo(header, 32);  // BlockAlign
            BitConverter.GetBytes((short)16).CopyTo(header, 34);  // BitsPerSample

            // data subchunk
            header[36] = (byte)'d';
            header[37] = (byte)'a';
            header[38] = (byte)'t';
            header[39] = (byte)'a';
            BitConverter.GetBytes(dataSize).CopyTo(header, 40);  // Subchunk2Size

            return header;
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
    }
}
