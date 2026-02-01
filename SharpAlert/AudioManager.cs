using NAudio.Wave;
using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.AlertComponents.AlertProcessor;
using static SharpAlert.ProgramWorker.NotificationWorker;
using SharpAlert.ProgramWorker;

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
        } = QuickSettings.Instance.LegacyAudioPlayer;
        private static readonly SoundPlayer LegacyAudioPlayer = new SoundPlayer(); 
        private static readonly List<WasapiOut> Outputs = new List<WasapiOut>();
        private static readonly List<WasapiOut> TTSOutputs = new List<WasapiOut>();
        public static readonly SpeechSynthesizer engine = new SpeechSynthesizer();
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
                    Console.WriteLine("[Audio Manager] Preparing to stop all audio.");

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
                                Console.WriteLine($"{ex.Message}");
                            }
                        }

                        Thread.Sleep(1000);
                        HoldIt = false;
                    }

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
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                        }
                    }

                    HoldIt = false;
                    TTSHoldIt = false;
                }
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
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                        }
                    }

                    TTSHoldIt = false;
                }
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
                Console.WriteLine("[Audio Manager] Preparing to refresh the audio device tree.");
                DeviceTreeFetched = true;
                AudioDevicesList.Clear();

                using (var enumerator = new MMDeviceEnumerator())
                {
                    var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

                    bool deviceConnected = _CurrentAudioDevice?.State == DeviceState.Active;

                    foreach (var device in devices)
                    {
                        Console.WriteLine($"[Audio Manager] Found audio device: {device.FriendlyName}");
                        AudioDevicesList.Add(device);
                    }

                    if (!deviceConnected && devices.Count > 0)
                    {
                        if (_CurrentAudioDevice != null)
                        {
                            Console.WriteLine("[Audio Manager] The audio device object will be reset, because the previous one wasn't found.");
                        }
                        CurrentAudioDevice = devices[0];
                    }

                    if (devices.Count == 0)
                    {
                        Console.WriteLine("[Audio Manager] No audio device found.");
                        CurrentAudioDevice = null;
                        return devices;
                    }

                    MMDevice cad = AudioDevicesList.FirstOrDefault(device =>
                        string.Equals(device.FriendlyName, QuickSettings.Instance.ProgramAudioOutput, StringComparison.OrdinalIgnoreCase));

                    if (cad == null)
                    {
                        Console.WriteLine("[Audio Manager] The specified device name in the app configuration was not found.");
                    }
                    else
                    {
                        CurrentAudioDevice = cad;
                    }

                    Console.WriteLine("[Audio Manager] Finished audio device tree refresh.");
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
            if (!QuickSettings.Instance.alertTTSonly)
            {
                if (!string.IsNullOrWhiteSpace(url) && !UsingLegacyAudioPlayer)
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
                    Console.WriteLine("[Audio Manager] No remote audio or the legacy audio player is active. TTS will be played instead.");
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
                if (UsingLegacyAudioPlayer)
                {
                    Console.WriteLine("[Audio Manager] Remote sources cannot be used with the legacy audio player.");
                    return;
                }

                //IceBearWorker.client.GetByteArrayAsync(url).Result;
                ThreadDrool.StartAndForget(() =>
                {
                    Console.WriteLine("[Audio Manager] Queued remote audio.");
                    try
                    {
                        PlayFromManagedSource(new MemoryStream(Client.GetByteArrayAsync(url).Result), true);
                        //using (var mf = new AudioFileReader(url))
                        //{
                        //    lock (AudioOutputLock)
                        //    {
                        //        Console.WriteLine("[Audio Manager] Audio queue locked.");
                        //        WasapiOut AudioOutput = new WasapiOut();
                        //        Outputs.Add(AudioOutput);
                        //        float volume = QuickSettings.Instance.alertVolume / 10f;
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
                        Notify.ShowNotification($"Audio playback is not working as expected. Please make sure your audio devices are working!",
                            "SharpAlert is having issues",
                            ToolTipIcon.Warning);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        public static bool ToneDone = true;

        public static void PlayStartToneFile(string severity, string type, bool wait = false)
        {
            StopAllAudioSilently();
            ToneDone = false;

            //bool UseCancel = false;
            bool UseSevere = false;

            Stream stream;

            if (type.ToLowerInvariant() != "cancel")
            {
                switch (severity.ToLowerInvariant())
                {
                    case "extreme":
                    case "severe":
                        UseSevere = true;
                        stream = Resources.major_alert;
                        break;
                    default:
                        stream = Resources.minor_alert;
                        break;
                }
            }
            else
            {
                //UseCancel = true;
                stream = Resources.cancelled_alert;
            }

            //if (!QuickSettings.Instance.alertPlayStartTone)
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
                        LegacyAudioPlayer.Stream = stream;
                        if (wait) LegacyAudioPlayer.PlaySync();
                        else ThreadDrool.StartAndForget(() =>
                        {
                            LegacyAudioPlayer.PlaySync();
                            ToneDone = true;
                        });
                    }
                    Console.WriteLine("[Audio Manager] Playing start tone audio (legacy).");
                }
                else
                {
                    void playAudio()
                    {
                        string path1 = QuickSettings.Instance.StartToneLocation;
                        string path2 = QuickSettings.Instance.StartToneLowLocation;

                        string path;

                        if (UseSevere)
                        {
                            path = path1;
                        }
                        else
                        {
                            path = path2;
                        }

                        //if (!string.IsNullOrWhiteSpace(path))
                        try
                        {
                            if (string.IsNullOrWhiteSpace(path))
                            {
                                Console.WriteLine("[Audio Manager] No audio file specified inside the configuration.");
                                PlayFromUnmanagedSourceAndWait((UnmanagedMemoryStream)stream, false);
                                if (QuickSettings.Instance.alertPlayStartToneTwice && !HoldIt) PlayFromUnmanagedSourceAndWait((UnmanagedMemoryStream)stream, false);
                            }
                            else
                            {
                                using (var reader = new MediaFoundationReader(path))
                                {
                                    lock (AudioOutputLock)
                                    {
                                        Console.WriteLine("[Audio Manager] Audio queue locked.");

                                        int ExecuteTimes = 1;

                                        if (QuickSettings.Instance.alertPlayStartToneTwice) ExecuteTimes++;

                                        Console.WriteLine($"[Audio Manager] Audio will be played {ExecuteTimes} time(s).");

                                        for (int e = 0; e < ExecuteTimes; e++)
                                        {
                                            WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                            float volume = QuickSettings.Instance.alertVolume / 10f;
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
                                            Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                            return;
                                        }
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
                    if (wait) playAudio();
                    else ThreadDrool.StartAndForget(() => playAudio());
                }
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

            if (!QuickSettings.Instance.alertPlayEndTone)
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
                    Console.WriteLine("[Audio Manager] Playing end tone audio (legacy).");
                }
                else
                {
                    void playAudio()
                    {
                        string path = QuickSettings.Instance.EndToneLocation;
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
                                            WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                            float volume = QuickSettings.Instance.alertVolume / 10f;
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
                                                Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                                return;
                                            }
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
                    else ThreadDrool.StartAndForget(() => playAudio());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
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
                    Console.WriteLine("[Audio Manager] Playing unmanaged audio (legacy).");
                }
                else
                {
                    ThreadDrool.StartAndForget(() =>
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
                                        WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                        Outputs.Add(AudioOutput);
                                        float volume = QuickSettings.Instance.alertVolume / 10f;
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
                                            Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                            return;
                                        }
                                    }
                                    Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Notify.ShowNotification($"Audio playback is not working as expected. Please make sure your audio devices are working!",
                                "SharpAlert is having issues",
                                ToolTipIcon.Warning);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
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
                    Console.WriteLine("[Audio Manager] Playing managed audio (legacy).");
                }
                else
                {
                    ThreadDrool.StartAndForget(() =>
                    {
                        Console.WriteLine("[Audio Manager] Queued managed audio.");
                        try
                        {
                            using (var mf = new StreamMediaFoundationReader(managed))
                            {
                                lock (AudioOutputLock)
                                {
                                    Console.WriteLine("[Audio Manager] Audio queue locked.");
                                    WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                                    float volume = QuickSettings.Instance.alertVolume / 10f;
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
                                        Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                        return;
                                    }
                                    //if (TTS) TTSOutputs.Remove(AudioOutput);
                                    //else Outputs.Remove(AudioOutput);
                                    //AudioOutput.Dispose();
                                }
                                Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                            Notify.ShowNotification($"Audio playback is not working as expected. Please make sure your audio devices are working!",
                                "SharpAlert is having issues",
                                ToolTipIcon.Warning);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }

        public static void PlayFromUnmanagedSourceAndWait(UnmanagedMemoryStream unmanaged, bool ignoreinterrupt = false)
        {
            try
            {
                if (UsingLegacyAudioPlayer)
                {
                    Console.WriteLine("[Audio Manager] Preparing to play unmanaged audio in the current thread (legacy).");
                    lock (LegacyAudioPlayer)
                    {
                        LegacyAudioPlayer.Stream = unmanaged;
                        LegacyAudioPlayer.Play();
                    }
                }
                else
                {
                    Console.WriteLine("[Audio Manager] Preparing to play in the current thread.");
                    using (MemoryStream stream = new MemoryStream())
                    {
                        unmanaged.CopyTo(stream);
                        using (var mf = new StreamMediaFoundationReader(stream))
                        {
                            WasapiOut AudioOutput = AudioDeviceSpecificWasapiOut();
                            float volume = QuickSettings.Instance.alertVolume / 10f;
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
                                Console.WriteLine("[Audio Manager] Audio closed.");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
                Notify.ShowNotification($"Audio playback is not working as expected. Please make sure your audio devices are working!",
                    "SharpAlert is having issues",
                    ToolTipIcon.Warning);
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
                        Console.WriteLine("[Audio Manager] Queued TTS audio.");
                        try
                        {
                            lock (AudioOutputLock)
                            {
                                //LockedQueue = true;
                                Console.WriteLine("[Audio Manager] Audio queue locked.");
                                using (MemoryStream stream = new MemoryStream())
                                {
                                    //bool UseMaki = false;
                                    lock (engine)
                                    {
                                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.ProgramVoice))
                                        {
                                            try
                                            {
                                                engine.SelectVoice(QuickSettings.Instance.ProgramVoice);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                //UseMaki = true;
                                            }
                                        }

                                        //bool MakiSuccess = false;

                                        //if (UseMaki)
                                        //{
                                        //    //$"{AssemblyDirectory}\\Maki.exe", $"--voice-syntax-console \"{QuickSettings.Instance.ProgramVoice}|{tts.Replace("|", "_")}\""
                                        //    ProcessStartInfo maki = new ProcessStartInfo
                                        //    {
                                        //        FileName = $"{AssemblyDirectory}\\Maki.exe",
                                        //        Arguments = $"--voice-syntax-console \"{QuickSettings.Instance.ProgramVoice}|{tts.Replace("|", "_")}\"",
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
                                            float volume = QuickSettings.Instance.alertVolume / 10f;
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
                                                Console.WriteLine("[Audio Manager] Audio cleared from queue and unlocked.");
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Audio Manager] {ex.Message}");
                            Notify.ShowNotification($"TTS playback is not working as expected. Please make sure your audio devices are working!",
                                "SharpAlert is having issues",
                                ToolTipIcon.Warning);
                        }
                        Console.WriteLine("[Audio Manager] Audio queue unlocked.");
                    }
                    if (wait) playAudio();
                    else ThreadDrool.StartAndForget(() => playAudio());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio Manager] {ex.Message}");
            }
        }
    }
}


