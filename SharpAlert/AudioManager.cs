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
using NAudio.CoreAudioApi;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;

namespace SharpAlert
{
    public static class AudioManager
    {
        /// <summary>
        /// Please do not change this value during runtime other than the very beginning of execution.
        /// </summary>
        public static bool UsingLegacyAudioPlayer
        {
            get;
            private set;
        } = Settings.Default.LegacyAudioPlayer;
        private static readonly SoundPlayer LegacyAudioPlayer = new SoundPlayer(); 
        private static readonly List<WasapiOut> Outputs = new List<WasapiOut>();
        private static readonly List<WasapiOut> TTSOutputs = new List<WasapiOut>();
        private static readonly SpeechSynthesizer engine = new SpeechSynthesizer();
        private static bool HoldIt = false;
        private static bool TTSHoldIt = false;
        private static bool DeviceTreeFetched = false;

        public static readonly List<MMDevice> AudioDevicesList = new List<MMDevice>();

        private static readonly object DeviceLock = new object();

        private static MMDevice _CurrentAudioDevice = null;
        //private static bool _Refresh = false;

        public static MMDevice CurrentAudioDevice
        {
            get
            {
                if (UsingLegacyAudioPlayer) return null;
                lock (DeviceLock)
                {
                    if (_CurrentAudioDevice != null && _CurrentAudioDevice.State == DeviceState.Active)
                    {
                        return _CurrentAudioDevice;
                    }

                    var devices = RefreshAudioDevices(); // Will set CurrentAudioDevice if needed
                    //_Refresh = true;

                    return _CurrentAudioDevice; // Return after refresh
                }
            }
            set
            {
                if (UsingLegacyAudioPlayer) return;
                lock (DeviceLock)
                {
                    _CurrentAudioDevice = value;
                }
            }
        }


        //public static void RefreshCallLoop()
        //{
        //}

        public static void StopAllAudio(bool NoEOM)
        {
            ThreadDrool.StartAndForget(() =>
            {
                try
                {
                    ConsoleExt.WriteLine("[Audio Manager] Preparing to stop all audio.");

                    if (UsingLegacyAudioPlayer)
                    {
                        LegacyAudioPlayer.Stop();
                        engine.SpeakAsyncCancelAll();
                    }
                    else
                    {
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
                                    output?.Dispose();
                                }
                                lock (Outputs) Outputs.Remove(output);
                            }
                            catch (Exception ex)
                            {
                                ConsoleExt.WriteLine($"{ex.Message}");
                            }
                        }

                        Thread.Sleep(1000);
                        HoldIt = false;
                    }

                    ConsoleExt.WriteLine("[Audio Manager] Attempted to stop all audio.");
                }
                catch (Exception ex)
                {
                    ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
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
                if (UsingLegacyAudioPlayer)
                {
                    LegacyAudioPlayer.Stop();
                    engine.SpeakAsyncCancelAll();
                }
                else
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
                            ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
                        }
                    }

                    HoldIt = false;
                    TTSHoldIt = false;
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
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
                if (UsingLegacyAudioPlayer)
                {
                    engine.SpeakAsyncCancelAll();
                }
                else
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
                            lock (Outputs) Outputs.Remove(output);
                            lock (output)
                            {
                                output?.Stop();
                                output?.Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
                        }
                    }

                    TTSHoldIt = false;
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
                //lock (notify)
                //{
                //    notify.BalloonTipTitle = "SharpAlert is having issues";
                //    notify.BalloonTipText = "Audio playback is not working as expected. Please check your audio devices!";
                //    notify.BalloonTipIcon = ToolTipIcon.Warning;
                //    notify.ShowBalloonTip(5000);
                //}
            }
        }

        public static MMDeviceCollection RefreshAudioDevices()
        {
            if (UsingLegacyAudioPlayer)
            {
                Console.WriteLine("[Audio Manager] The refresh devices list method does nothing while using the legacy audio player.");
                return null;
            }

            switch (Thread.CurrentThread.GetApartmentState())
            {
                case ApartmentState.STA:
                case ApartmentState.Unknown:
                    Console.WriteLine("[Audio Manager] Cannot refresh audio devices from an STA (Single Threaded Apartment) thread.");
                    return null;
            }

            lock (AudioDevicesList)
            {
                ConsoleExt.WriteLine("[Audio Manager] Preparing to refresh the audio device tree.");
                DeviceTreeFetched = true;
                AudioDevicesList.Clear();

                using (var enumerator = new MMDeviceEnumerator())
                {
                    var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

                    bool deviceConnected = _CurrentAudioDevice?.State == DeviceState.Active;

                    foreach (var device in devices)
                    {
                        ConsoleExt.WriteLine($"[Audio Manager] Found audio device: {device.FriendlyName}");
                        AudioDevicesList.Add(device);
                    }

                    if (!deviceConnected && devices.Count > 0)
                    {
                        if (_CurrentAudioDevice != null)
                        {
                            ConsoleExt.WriteLine("[Audio Manager] The audio device object will be reset, because the previous one wasn't found.");
                        }
                        CurrentAudioDevice = devices[0];
                    }

                    if (devices.Count == 0)
                    {
                        ConsoleExt.WriteLine("[Audio Manager] No audio device found.");
                        CurrentAudioDevice = null;
                        return devices;
                    }

                    MMDevice cad = AudioDevicesList.FirstOrDefault(device =>
                        string.Equals(device.FriendlyName, Settings.Default.ProgramAudioOutput, StringComparison.OrdinalIgnoreCase));

                    if (cad == null)
                    {
                        ConsoleExt.WriteLine("[Audio Manager] The specified device name in the app configuration was not found.");
                    }
                    else
                    {
                        CurrentAudioDevice = cad;
                    }

                    ConsoleExt.WriteLine("[Audio Manager] Finished audio device tree refresh.");
                    return devices;
                }
            }
        }

        private static WasapiOut AudioDeviceSpecificWasapiOut()
        {
            if (UsingLegacyAudioPlayer)
            {
                Console.WriteLine("[Audio Manager] Device specific WASAPIOUT cannot be used with the legacy audio player.");
                return null;
            }

            lock (AudioDevicesList)
            {
                if (!DeviceTreeFetched)
                {
                    RefreshAudioDevices();
                }
                MMDevice selectedDevice = CurrentAudioDevice;
                return new WasapiOut(selectedDevice, AudioClientShareMode.Shared, false, 20);
            }
        }

        public static void PlayWithFailoverToTTS(string url, string text)
        {
            if (!Settings.Default.alertTTSonly)
            {
                if (!string.IsNullOrWhiteSpace(url) && !UsingLegacyAudioPlayer)
                {
                    try
                    {
                        PlayFromRemoteSource(url);
                    }
                    catch (Exception ex)
                    {
                        ConsoleExt.WriteLine($"[Audio Manager] Failed to play remote audio. TTS will be played instead. {ex.Message}");
                        PlayFromTTSEngine(StringIntoTTSFriendly(text), false);
                    }
                }
                else
                {
                    ConsoleExt.WriteLine("[Audio Manager] No remote audio or the legacy audio player is active. TTS will be played instead.");
                    PlayFromTTSEngine(StringIntoTTSFriendly(text), false);
                }
            }
            else
            {
                ConsoleExt.WriteLine($"[Audio Manager] User settings prohibit remote audio. TTS will be played instead.");
                PlayFromTTSEngine(StringIntoTTSFriendly(text), false);
            }
        }

        public static void PlayFromRemoteSource(string url)
        {
            try
            {
                if (UsingLegacyAudioPlayer)
                {
                    Console.WriteLine("[Audio Manager] Remote sources cannot be used with the legacy audio player.");
                    return;
                }

                //IceBearWorker.client.GetByteArrayAsync(url).Result;
                ThreadDrool.StartAndForget(() =>
                {
                    ConsoleExt.WriteLine("[Audio Manager] Queued remote audio.");
                    try
                    {
                        PlayFromManagedSource(new MemoryStream(client.GetByteArrayAsync(url).Result), true);
                        //using (var mf = new AudioFileReader(url))
                        //{
                        //    lock (AudioOutputLock)
                        //    {
                        //        ConsoleExt.WriteLine("[Audio Manager] Audio queue locked.");
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
                        //            ConsoleExt.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                        //            return;
                        //        }
                        //        Outputs.Remove(AudioOutput);
                        //        if (eom) PlayFromUnmanagedSourceAndWait(Resources.ui_end_1);
                        //        AudioOutput.Dispose();
                        //    }
                        //    ConsoleExt.WriteLine("[Audio Manager] Audio queue unlocked.");
                        //}
                    }
                    catch (Exception ex)
                    {
                        ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
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
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
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
                if (UsingLegacyAudioPlayer)
                {
                    lock (LegacyAudioPlayer)
                    {
                        LegacyAudioPlayer.Stream = Resources.ui_warning_1;
                        if (wait) LegacyAudioPlayer.PlaySync();
                        else LegacyAudioPlayer.Play();
                    }
                    ConsoleExt.WriteLine("[Audio Manager] Playing start tone audio (legacy).");
                }
                else
                {
                    void playAudio()
                    {
                        string path = Settings.Default.StartToneLocation;
                        //if (!string.IsNullOrWhiteSpace(path))
                        try
                        {
                            if (string.IsNullOrWhiteSpace(path))
                            {
                                ConsoleExt.WriteLine("[Audio Manager] No audio file specified inside the configuration.");
                                PlayFromUnmanagedSourceAndWait(Resources.ui_warning_1, false);
                                if (Settings.Default.alertPlayStartToneTwice && !HoldIt) PlayFromUnmanagedSourceAndWait(Resources.ui_warning_1, false);
                            }
                            else
                            {
                                using (var reader = new MediaFoundationReader(path))
                                {
                                    lock (AudioOutputLock)
                                    {
                                        ConsoleExt.WriteLine("[Audio Manager] Audio queue locked.");

                                        int ExecuteTimes = 1;

                                        if (Settings.Default.alertPlayStartToneTwice) ExecuteTimes++;

                                        ConsoleExt.WriteLine($"[Audio Manager] Audio will be played {ExecuteTimes} time(s).");

                                        for (int e = 0; e < ExecuteTimes; e++)
                                        {
                                            WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                            float volume = Settings.Default.alertVolume / 10f;
                                            AudioOutput.Init(reader);
                                            for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++)
                                                AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);

                                            AudioOutput.Play();
                                            Outputs.Add(AudioOutput);
                                            while (AudioOutput.PlaybackState == PlaybackState.Playing && !HoldIt)
                                            {
                                                Thread.Sleep(25);
                                            }
                                        }

                                        if (HoldIt)
                                        {
                                            ConsoleExt.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                            return;
                                        }
                                    }
                                    ConsoleExt.WriteLine("[Audio Manager] Audio queue unlocked.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
                        }
                        ToneDone = true;
                    }
                    if (wait) playAudio();
                    else ThreadDrool.StartAndForget(() => playAudio());
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
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
                if (UsingLegacyAudioPlayer)
                {
                    lock (LegacyAudioPlayer)
                    {
                        LegacyAudioPlayer.Stream = Resources.ui_end_1;
                        if (wait) LegacyAudioPlayer.PlaySync();
                        else LegacyAudioPlayer.Play();
                    }
                    ConsoleExt.WriteLine("[Audio Manager] Playing end tone audio (legacy).");
                }
                else
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
                                    ConsoleExt.WriteLine("[Audio Manager] No audio file specified inside the configuration.");
                                    PlayFromUnmanagedSource(Resources.ui_end_1);
                                }
                                else
                                {
                                    using (var reader = new MediaFoundationReader(path))
                                    {
                                        lock (AudioOutputLock)
                                        {
                                            ConsoleExt.WriteLine("[Audio Manager] Audio queue locked.");
                                            WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                            float volume = Settings.Default.alertVolume / 10f;
                                            AudioOutput.Init(reader);
                                            for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++)
                                                AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);

                                            AudioOutput.Play();
                                            Outputs.Add(AudioOutput);
                                            // && !HoldIt
                                            while (AudioOutput.PlaybackState == PlaybackState.Playing)
                                            {
                                                Thread.Sleep(50);
                                            }

                                            if (HoldIt)
                                            {
                                                ConsoleExt.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                                return;
                                            }
                                        }
                                        ConsoleExt.WriteLine("[Audio Manager] Audio queue unlocked.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
                            }
                            ToneDone = true;
                        }
                    }
                    if (wait) playAudio();
                    else ThreadDrool.StartAndForget(() => playAudio());
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
                ToneDone = true;
            }
        }

        public static void PlayFromUnmanagedSource(UnmanagedMemoryStream unmanaged, bool ignoreinterrupt = false)
        {
            try
            {
                if (UsingLegacyAudioPlayer)
                {
                    lock (LegacyAudioPlayer)
                    {
                        LegacyAudioPlayer.Stream = unmanaged;
                        LegacyAudioPlayer.Play();
                    }
                    ConsoleExt.WriteLine("[Audio Manager] Playing unmanaged audio (legacy).");
                }
                else
                {
                    ThreadDrool.StartAndForget(() =>
                    {
                        ConsoleExt.WriteLine("[Audio Manager] Queued unmanaged audio.");
                        try
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                unmanaged.CopyTo(stream);
                                using (var mf = new StreamMediaFoundationReader(stream))
                                {
                                    lock (AudioOutputLock)
                                    {
                                        ConsoleExt.WriteLine("[Audio Manager] Audio queue locked.");
                                        WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                        Outputs.Add(AudioOutput);
                                        float volume = Settings.Default.alertVolume / 10f;
                                        AudioOutput.Init(mf);
                                        for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                        AudioOutput.Play();
                                        Outputs.Add(AudioOutput);
                                        while (AudioOutput.PlaybackState == PlaybackState.Playing & !(HoldIt & ignoreinterrupt))
                                        {
                                            Thread.Sleep(50);
                                        }
                                        if (HoldIt)
                                        {
                                            ConsoleExt.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                            return;
                                        }
                                    }
                                    ConsoleExt.WriteLine("[Audio Manager] Audio queue unlocked.");
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
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        public static void PlayFromManagedSource(MemoryStream managed, bool TTS = false)
        {
            try
            {
                if (UsingLegacyAudioPlayer)
                {
                    lock (LegacyAudioPlayer)
                    {
                        LegacyAudioPlayer.Stream = managed;
                        LegacyAudioPlayer.Play();
                    }
                    ConsoleExt.WriteLine("[Audio Manager] Playing managed audio (legacy).");
                }
                else
                {
                    ThreadDrool.StartAndForget(() =>
                    {
                        ConsoleExt.WriteLine("[Audio Manager] Queued managed audio.");
                        try
                        {
                            using (var mf = new StreamMediaFoundationReader(managed))
                            {
                                lock (AudioOutputLock)
                                {
                                    ConsoleExt.WriteLine("[Audio Manager] Audio queue locked.");
                                    WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                    float volume = Settings.Default.alertVolume / 10f;
                                    AudioOutput.Init(mf);
                                    for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                    
                                    AudioOutput.Play();
                                    if (TTS) TTSOutputs.Add(AudioOutput);
                                    else Outputs.Add(AudioOutput);

                                    while (AudioOutput.PlaybackState == PlaybackState.Playing & !HoldIt)
                                    {
                                        Thread.Sleep(50);
                                    }
                                    if (HoldIt)
                                    {
                                        ConsoleExt.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                        return;
                                    }
                                    //if (TTS) TTSOutputs.Remove(AudioOutput);
                                    //else Outputs.Remove(AudioOutput);
                                    //AudioOutput.Dispose();
                                }
                                ConsoleExt.WriteLine("[Audio Manager] Audio queue unlocked.");
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
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
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        public static void PlayFromUnmanagedSourceAndWait(UnmanagedMemoryStream unmanaged, bool ignoreinterrupt = false)
        {
            try
            {
                if (UsingLegacyAudioPlayer)
                {
                    ConsoleExt.WriteLine("[Audio Manager] Preparing to play unmanaged audio in the current thread (legacy).");
                    lock (LegacyAudioPlayer)
                    {
                        LegacyAudioPlayer.Stream = unmanaged;
                        LegacyAudioPlayer.Play();
                    }
                }
                else
                {
                    ConsoleExt.WriteLine("[Audio Manager] Preparing to play in the current thread.");
                    using (MemoryStream stream = new MemoryStream())
                    {
                        unmanaged.CopyTo(stream);
                        using (var mf = new StreamMediaFoundationReader(stream))
                        {
                            WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                            float volume = Settings.Default.alertVolume / 10f;
                            AudioOutput.Init(mf);
                            for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                            AudioOutput.Play();
                            Outputs.Add(AudioOutput);
                            while (AudioOutput.PlaybackState == PlaybackState.Playing & !(HoldIt & ignoreinterrupt))
                            {
                                Thread.Sleep(50);
                            }
                            if (HoldIt)
                            {
                                ConsoleExt.WriteLine("[Audio Manager] Audio closed.");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
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
            tts = StringIntoTTSFriendly(tts);
            try
            {
                if (UsingLegacyAudioPlayer)
                {
                    bool EngineSpeaking = true;

                    ThreadDrool.StartAndForget(() =>
                    {
                        try
                        {
                            lock (engine)
                            {
                                engine.SetOutputToDefaultAudioDevice();
                                engine.Speak(tts);
                            }
                            EngineSpeaking = false;
                        }
                        catch (Exception)
                        {
                        }
                    });

                    if (wait)
                    {
                        while (EngineSpeaking) Thread.Sleep(100);
                    }
                }
                else
                {
                    void playAudio()
                    {
                        ConsoleExt.WriteLine("[Audio Manager] Queued TTS audio.");
                        try
                        {
                            lock (AudioOutputLock)
                            {
                                //LockedQueue = true;
                                ConsoleExt.WriteLine("[Audio Manager] Audio queue locked.");
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    //bool UseMaki = false;
                                    lock (engine)
                                    {
                                        if (!string.IsNullOrWhiteSpace(Settings.Default.ProgramVoice))
                                        {
                                            try
                                            {
                                                engine.SelectVoice(Settings.Default.ProgramVoice);
                                            }
                                            catch (Exception ex)
                                            {
                                                ConsoleExt.WriteLine(ex.Message);
                                                //UseMaki = true;
                                            }
                                        }

                                        //bool MakiSuccess = false;

                                        //if (UseMaki)
                                        //{
                                        //    //$"{AssemblyDirectory}\\Maki.exe", $"--voice-syntax-console \"{Settings.Default.ProgramVoice}|{tts.Replace("|", "_")}\""
                                        //    ProcessStartInfo maki = new ProcessStartInfo
                                        //    {
                                        //        FileName = $"{AssemblyDirectory}\\Maki.exe",
                                        //        Arguments = $"--voice-syntax-console \"{Settings.Default.ProgramVoice}|{tts.Replace("|", "_")}\"",
                                        //        RedirectStandardOutput = true
                                        //    };
                                        //    Process MakiProcess = Process.Start(maki);
                                        //    MakiProcess.WaitForExit();
                                        //    if (MakiProcess.ExitCode == 0)
                                        //    {
                                        //        using (var MakiOut = MakiProcess.StandardOutput.BaseStream)
                                        //        {
                                        //            MakiOut.CopyTo(stream);
                                        //        }
                                        //    }

                                        //    MakiSuccess = true;
                                        //}

                                        //if (!MakiSuccess)
                                        {
                                            engine.SetOutputToWaveStream(stream);
                                            engine.Speak(tts);
                                        }

                                        using (var mf = new StreamMediaFoundationReader(stream))
                                        {
                                            WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                            float volume = Settings.Default.alertVolume / 10f;
                                            AudioOutput.Init(mf);
                                            for (int i = 0; i < AudioOutput.AudioStreamVolume.ChannelCount; i++) AudioOutput.AudioStreamVolume.SetChannelVolume(i, volume);
                                            AudioOutput.Play();
                                            TTSOutputs.Add(AudioOutput);
                                            while (AudioOutput.PlaybackState == PlaybackState.Playing & !TTSHoldIt)
                                            {
                                                Thread.Sleep(50);
                                            }
                                            if (TTSHoldIt)
                                            {
                                                ConsoleExt.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
                            lock (notify)
                            {
                                notify.BalloonTipTitle = "SharpAlert is having issues";
                                notify.BalloonTipText = "TTS playback is not working as expected. Please make sure your audio devices are working!";
                                notify.BalloonTipIcon = ToolTipIcon.Warning;
                                notify.ShowBalloonTip(5000);
                            }
                        }
                        ConsoleExt.WriteLine("[Audio Manager] Audio queue unlocked.");
                    }
                    if (wait) playAudio();
                    else ThreadDrool.StartAndForget(() => playAudio());
                }

            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }
    }
}
