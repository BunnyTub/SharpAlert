using System;
using System.IO;
using System.Media;
using System.Reflection;
using SharpAlert.ProgramWorker;

namespace SharpAlert
{
    public static class SpeakingManager
    {
        private static bool BasicSpeakingInit = false;

        private static void Init()
        {
            Console.WriteLine("[Speaking Manager] Basic Speaking has been deprecated.");
            BasicSpeakingInit = true;

            if (BasicSpeakingInit) return;
            BasicSpeakingInit = true;

            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            foreach (string resourceName in resources)
            {
                if (resourceName.StartsWith("SharpAlert.SpeakingAssets."))
                {
                    if (resourceName.ToLowerInvariant().EndsWith(".wav"))
                    {
                        string[] parts = resourceName.Split('.');
                        int count = parts.Length;

                        if (count >= 2)
                        {
                            string fileName = $"{parts[count - 2]}.{parts[count - 1]}";
                            Console.WriteLine($"[Speaking Manager] Available asset: {fileName}");
                        }
                    }
                }
            }
        }

        private static readonly SoundPlayer Speaker = new();

#pragma warning disable CS0162 // Unreachable code detected
        private static void PlaySoundFileFromLocalFolder(string SafeFileName, bool DisableSettingsCheck = false)
        {
            return;
            ThreadDrool.StartAndForget(() =>
            {
                PlaySoundFileFromLocalFolderNoThreading(SafeFileName, DisableSettingsCheck);
            });
        }
        
        private static void PlaySoundFileFromLocalFolderNoThreading(string SafeFileName, bool DisableSettingsCheck = false)
        {
            return;
            Init();
            Console.WriteLine($"[Speaking Manager] Function called.");
            if (!DisableSettingsCheck) if (!QuickSettings.Instance.EnableBasicSpeaking) return;
            lock (Speaker)
            {
                try
                {
                    Stream memstream = new MemoryStream();

                    if (File.Exists($"{MainEntryPoint.AssemblyDirectory}\\{SafeFileName}.wav"))
                    {
                        Console.WriteLine($"[Speaking Manager] Getting the data for \"{SafeFileName}\".");
                        Speaker.SoundLocation = $"{MainEntryPoint.AssemblyDirectory}\\{SafeFileName}.wav";
                    }
                    else
                    {
                        Console.WriteLine($"[Speaking Manager] Getting the data for \"{SafeFileName}\".");
                        try
                        {
                            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SharpAlert.SpeakingAssets." + SafeFileName + ".wav"))
                            {
                                if (stream == null)
                                {
                                    Console.WriteLine($"[Speaking Manager] Cannot grab the data for \"{SafeFileName}\".");
                                    return;
                                }

                                stream.CopyTo(memstream);
                                memstream.Position = 0;
                                Speaker.Stream = memstream;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Speaking Manager] Cannot grab the data for \"{SafeFileName}\". {ex.Message}");
                            return;
                        }
                    }

                    Console.WriteLine($"[Speaking Manager] Starting speaking \"{SafeFileName}\".");
                    Speaker.PlaySync();
                    Console.WriteLine($"[Speaking Manager] Finished speaking \"{SafeFileName}\".");

                    memstream.Close();
                    memstream.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Speaking Manager] Couldn't speak \"{SafeFileName}\". {ex.Message}");
                }
            }
        }
#pragma warning restore CS0162 // Unreachable code detected

        // Statement
        public static void EnabledBasicSpeaking()
        {
            PlaySoundFileFromLocalFolder("EnabledBasicSpeaking", true);
        }

        // Statement
        public static void DisabledBasicSpeaking()
        {
            PlaySoundFileFromLocalFolder("DisabledBasicSpeaking", true);
        }
        
        // Question
        public static void ForwardThisMessageToDiscord()
        {
            PlaySoundFileFromLocalFolder("ForwardThisMessageToDiscord");
        }
        
        // Statement
        public static void DismissingWindow()
        {
            PlaySoundFileFromLocalFolder("DismissedWindow");
        }
        
        // Statement
        public static void ProgramRunning()
        {
            PlaySoundFileFromLocalFolder("ProgramRunning");
        }
        
        // Statement
        public static void BetaVersionInUse()
        {
            PlaySoundFileFromLocalFolder("BetaVersionInUse");
        }
        
        // Statement
        public static void UpdatesFound()
        {
            PlaySoundFileFromLocalFolder("UpdatesFound");
        }
        
        // Statement
        public static void TopOfTheHour()
        {
            PlaySoundFileFromLocalFolder("TopOfTheHour");
        }

        // Statement
        public static void ModerateOrLower()
        {
            PlaySoundFileFromLocalFolderNoThreading("ModerateOrLower");
        }

        // Statement
        public static void SevereOrHigher()
        {
            PlaySoundFileFromLocalFolderNoThreading("SevereOrHigher");
        }

        // Statement
        public static void FullDaySinceQueuedAlert()
        {
            PlaySoundFileFromLocalFolder("FullDaySinceQueuedAlert");
        }

        // Statement
        public static void HalfDaySinceQueuedAlert()
        {
            PlaySoundFileFromLocalFolder("HalfDaySinceQueuedAlert");
        }

        // Statement
        public static void SettingsSaved()
        {
            PlaySoundFileFromLocalFolder("SettingsSaved");
        }

        // Statement
        public static void SetupComplete()
        {
            PlaySoundFileFromLocalFolder("SetupComplete");
        }

        // Statement
        public static void EnabledDoNotDisturb()
        {
            PlaySoundFileFromLocalFolder("EnabledDoNotDisturb");
        }

        // Statement
        public static void DisabledDoNotDisturb()
        {
            PlaySoundFileFromLocalFolder("DisabledDoNotDisturb");
        }
    }
}
