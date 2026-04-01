using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public class CustomGeocodeValues
    {
        //<geocode>
        //  <valueName>IBGE</valueName>
        //  <value>4205803</value>
        //</geocode>

        public string ValueName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class QuickSettings
    {
        public static bool ReadOnlyMode { get; set; } = false;

        // NEVER CHANGE ANY OF THESE VALUES BELOW!

        // configuration.json
        public static string ConfigPath { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SharpAlert", "configuration.json");
        
        public static string ConfigDirPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SharpAlert");

        public static int CurrentSaveSlot { get; private set; } = 0;

        //private static int ConfigurationSetNumber_ = 0;
        //public static int ConfigurationSetNumber
        //{
        //    get
        //    {
        //        return ConfigurationSetNumber_;
        //    }
        //    set
        //    {
        //        if (_instance == null) throw new NullReferenceException("No instance loaded.");
        //        Instance.LastConfigurationSet = 0;
        //        Instance.Save();
        //        Instance.Reload();

        //        ConfigurationSetNumber_ = value;
        //    }
        //}
        // DO YOU WANT TO FUCK UP THE USER INSTALLATION PATH?

        //public event EventHandler SettingsSaving;

        private static QuickSettings _instance;

        public static QuickSettings Instance
        {
            get
            {
                _instance ??= Load();
                if (_instance == null) throw new NullReferenceException("Loading failed.");
                return _instance;
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        // Info
        public string LastVersionOpened { get; set; } = "v0.0";
        public string LanguageCode { get; set; } = "en";
        // Updating
        public bool AskedForAutomaticUpdates { get; set; } = false;
        public bool AllowPerformingUpdates { get; set; } = false;
        // Discord Rich Presence
        public bool AskedForDiscordRichPresence { get; set; } = false;
        public bool AllowDiscordRichPresence { get; set; } = false;
        public ulong UserDiscordRichPresence { get; set; } = 0;
        // Dashboard
        public bool OpenDashboardAutomatically { get; set; } = false;
        // System
        public bool NoSystemSleep { get; set; } = false;
        public bool PlayChimeOnRun { get; set; } = false;
        // Migration
        public bool MigrationOccurred { get; set; } = false;
        // Status
        public bool statusActual { get; set; } = true;
        public bool statusTest { get; set; } = false;
        public bool statusExercise { get; set; } = false;
        // Message Type
        public bool messageTypeAlert { get; set; } = true;
        public bool messageTypeUpdate { get; set; } = true;
        public bool messageTypeCancel { get; set; } = false;
        public bool messageTypeTest { get; set; } = false;
        // Severity
        public bool severityExtreme { get; set; } = true;
        public bool severitySevere { get; set; } = true;
        public bool severityModerate { get; set; } = true;
        public bool severityMinor { get; set; } = true;
        public bool severityUnknown { get; set; } = false;
        // Urgency
        public bool urgencyImmediate { get; set; } = true;
        public bool urgencyExpected { get; set; } = true;
        public bool urgencyFuture { get; set; } = true;
        public bool urgencyPast { get; set; } = false;
        public bool urgencyUnknown { get; set; } = false;
        // Locations
        public StringCollection AllowedSAMELocations_Geocodes { get; set; } = [];
        public StringCollection AllowedCAPCPLocations_Geocodes { get; set; } = [];
        
        public List<CustomGeocodeValues> AllowedCustomLocations_GeocodesList { get; set; } = [];
        // Blacklist
        public StringCollection EnforceEventBlacklist { get; set; } = [];
        public bool EventWhitelistMode { get; set; } = false;
        public StringCollection EnforceSAMEEventBlacklist { get; set; } = [];
        // Alert Stuff
        public int AlertCheckInterval { get; set; } = 15;
        public bool weaOnly { get; set; } = false;
        public bool UseCMAMTextWhereAvailable { get; set; } = true;
        public bool IgnoreKeepAlive { get; set; } = true;
        // Changed discard to align with region changes
        public bool discardFirstAlerts { get; set; } = true;
        public bool BypassAllFilters { get; set; } = false;
        // Dialogs
        public bool UseAdvancedView { get; set; } = false;
        public int alertDisplayType { get; set; } = 0;
        public int WindowLocation { get; set; } = 0;
        public int alertTimeout { get; set; } = 5;
        public int alertFadeTime { get; set; } = 3;
        public bool alertFullscreenIdle { get; set; } = false;
        public int alertFullscreenDisplay { get; set; } = 0;
        public int AlertDeadInterval { get; set; } = 1;
        public bool alertCompatibilityMode { get; set; } = false;
        public bool statusWindow { get; set; } = false;
        // Removed support for expiry messages.
        //public bool showExpiryMessages { get; set; } = false;
        public bool alertNoGUI { get; set; } = false;
        // "alertNoRelay" disables USB relays. It doesn't prevent relaying.
        // This has been set to false as of v14 to prevent unintended hardware issues. Oops! I did it again!
        public bool alertNoRelay { get; set; } = false;
        public bool DisableDialogs { get; set; } = false;
        public bool DisableAlertProcessing { get; set; } = false;
        public bool PauseDataProcessing { get; set; } = false;
        public bool alertIncreaseSize { get; set; } = false;
        public bool alertTitlebarControls { get; set; } = false;
        public bool alertTimeZoneUTC { get; set; } = false;
        public bool alertTTSonly { get; set; } = false;
        public bool alertPlayStartToneTwice { get; set; } = false;
        public bool alertPlayEndTone { get; set; } = false;
        public bool alertAutoPrintingEnabled { get; set; } = false;
        public bool TryForceWindowFocus { get; set; } = true;
        public bool LegacyAudioPlayer { get; set; } = false;
        public bool DisableSomeStyleAutoplay { get; set; } = false;
        public bool EnableBasicSpeaking { get; set; } = false;
        public int alertVolume { get; set; } = 8;
        public int ScrollSpeed { get; set; } = 10;
        public string StartToneLocation { get; set; } = string.Empty;
        public string StartToneLowLocation { get; set; } = string.Empty;
        public string EndToneLocation { get; set; } = string.Empty;
        public string ProgramVoice { get; set; } = string.Empty;
        public string ProgramAudioOutput { get; set; } = string.Empty;
        // "MakiVersion" is unused.
        //public string MakiVersion { get; set; } = string.Empty;
        // Data Structure
        // storedMaxSize can be any size, but is usually capped to 5000 by the UI.
        public int storedMaxSize { get; set; } = 1000;
        // First-run
        public bool DisclaimerShown { get; set; } = false;
        public bool SetupExperienceComplete { get; set; } = false;
        // Station Info
        public string StationIdentifier { get; set; } = string.Empty;
        public string StationName { get; set; } = string.Empty;
        // Regions
        public bool RegionUnitedStates { get; set; } = false;
        public bool RegionUnitedStatesNWS { get; set; } = false;
        public bool RegionCanada { get; set; } = false;
        public bool RegionMexico { get; set; } = false;
        public bool RegionBrazil { get; set; } = false;
        // Discord Webhooks
        #region Webhooks
        // Default
        public string DiscordWebhook { get; set; } = string.Empty;
        public string DiscordWebhookAppend { get; set; } = string.Empty;
        // FEMA IPAWS (EAS)
        public string DiscordWebhook_FEMA_IPAWS_EAS { get; set; } = string.Empty;
        public string DiscordWebhookAppend_FEMA_IPAWS_EAS { get; set; } = string.Empty;

        public string DiscordWebhook_FEMA_IPAWS_WEA { get; set; } = string.Empty;
        public string DiscordWebhookAppend_FEMA_IPAWS_WEA { get; set; } = string.Empty;
        
        public string DiscordWebhook_NWS_ATOM { get; set; } = string.Empty;
        public string DiscordWebhookAppend_NWS_ATOM { get; set; } = string.Empty;
        
        public string DiscordWebhook_SASMEX { get; set; } = string.Empty;
        public string DiscordWebhookAppend_SASMEX { get; set; } = string.Empty;
        
        public string DiscordWebhook_NAADS_PRIMARY { get; set; } = string.Empty;
        public string DiscordWebhookAppend_NAADS_PRIMARY { get; set; } = string.Empty;

        public string DiscordWebhook_NAADS_BACKUP { get; set; } = string.Empty;
        public string DiscordWebhookAppend_NAADS_BACKUP { get; set; } = string.Empty;
        
        public string DiscordWebhook_IDAP { get; set; } = string.Empty;
        public string DiscordWebhookAppend_IDAP { get; set; } = string.Empty;
        #endregion
        // Discord Settings
        public bool DiscordWebhookFeaturesLocked { get; set; } = false;
        public bool DiscordWebhookNotifications { get; set; } = true;
        public bool DiscordWebhookConfirmAlerts { get; set; } = true;
        public bool DiscordWebhookRelayLocally { get; set; } = false;
        public bool DiscordWebhookDisableHeartbeat { get; set; } = false;
        // This value is inclusive. (example: 20 and under)
        public int BatteryReportingCautionLevel { get; set; } = 20;
        // This value is inclusive. (example: 10 and under)
        public int BatteryReportingCriticalLevel { get; set; } = 10;
        // Server
        public bool EnableServer { get; set; } = false;
        public string ServerUsername { get; set; } = "username";
        public string ServerPassword { get; set; } = "password";
        // Categories
        public bool categoryGeophysical { get; set; } = true;
        public bool categorySecurity { get; set; } = true;
        public bool categoryMedical { get; set; } = true;
        public bool categoryUtilities { get; set; } = true;
        public bool categoryMeterological { get; set; } = true;
        public bool categoryRescue { get; set; } = true;
        public bool categoryEnvironmental { get; set; } = true;
        public bool categoryToxicThreat { get; set; } = true;
        public bool categoryGeneralSafety { get; set; } = true;
        public bool categoryFire { get; set; } = true;
        public bool categoryTransportation { get; set; } = true;
        public bool categoryOtherUnknown { get; set; } = true;
        // Language
        //public bool AllowNonEnglishAlerts { get; set; } = true;
        // Alert Text
        public bool AddIntroText { get; set; } = true;
        public bool AddAlertEffectiveAndEndingTimes { get; set; } = true;
        public bool AddAlertIssuer { get; set; } = true;
        public bool AddSourcedFrom { get; set; } = true;
        public bool AddEventName { get; set; } = true;
        public bool Use24HrTime { get; set; } = false;
        //public bool RemoveNWSDescCode { get; set; } = true;
        //public bool RemoveNWSNewLines { get; set; } = true;
        // Archiving
        public bool ArchivingSaveAllAlerts { get; set; } = false;
        public bool ArchivingDeleteOldAlertsOver48h { get; set; } = true;
        public bool ArchivingAggressiveProcessing { get; set; } = false;
        // Networking
        public bool HideNetworkErrors { get; set; } = true;
#pragma warning restore IDE1006 // Naming Styles

        public void Save()
        {
            if (ReadOnlyMode)
            {
                Console.WriteLine($"[Configuration Handler] The current configuration is not being saved due to read only mode.");
                return;
            }

            lock (this)
            {
                Console.WriteLine($"[Configuration Handler] The current configuration is being saved.");
                var dir = Path.GetDirectoryName(ConfigPath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(ConfigPath, json);
            }
        }

        private static QuickSettings Load() // config loads here aaaaaa
        {
            try
            {
                if (MainEntryPoint.Args.Contains("--alt-config-1"))
                {
                    ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "SharpAlert", "configuration-alt1.json");
                }
                
                if (MainEntryPoint.Args.Contains("--alt-config-2"))
                {
                    ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "SharpAlert", "configuration-alt2.json");
                }
                
                if (MainEntryPoint.Args.Contains("--alt-config-3"))
                {
                    ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "SharpAlert", "configuration-alt3.json");
                }
                
                if (MainEntryPoint.Args.Contains("--alt-config-4"))
                {
                    ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "SharpAlert", "configuration-alt4.json");
                }

                if (CurrentSaveSlot == 0)
                {
                    if (MainEntryPoint.Args.Contains("--set1"))
                    {
                        ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "SharpAlert", "configuration-set1.json");
                        MainEntryPoint.Args.Remove("--set1");
                        CurrentSaveSlot = 1;
                    }

                    if (MainEntryPoint.Args.Contains("--set2"))
                    {
                        ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "SharpAlert", "configuration-set2.json");
                        MainEntryPoint.Args.Remove("--set2");
                        CurrentSaveSlot = 2;
                    }

                    if (MainEntryPoint.Args.Contains("--set3"))
                    {
                        ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "SharpAlert", "configuration-set3.json");
                        MainEntryPoint.Args.Remove("--set3");
                        CurrentSaveSlot = 3;
                    }

                    if (MainEntryPoint.Args.Contains("--set4"))
                    {
                        ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "SharpAlert", "configuration-set4.json");
                        MainEntryPoint.Args.Remove("--set4");
                        CurrentSaveSlot = 4;
                    }

                    if (MainEntryPoint.Args.Contains("--set5"))
                    {
                        ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "SharpAlert", "configuration-set5.json");
                        MainEntryPoint.Args.Remove("--set5");
                        CurrentSaveSlot = 5;
                    }
                }

                if (File.Exists(ConfigPath))
                {
                    var json = File.ReadAllText(ConfigPath);
                    var settings = JsonConvert.DeserializeObject<QuickSettings>(json) ?? new QuickSettings();
                    //if (settings.LastConfigurationSet == 0)
                    {
                        Console.WriteLine($"[Configuration Handler] Using found configuration set.");
                        return settings;
                    }
                    //else
                    //{
                    //    ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    //        "SharpAlert", $"configuration-set{settings.LastConfigurationSet}.json");

                    //    ConfigurationSetNumber = settings.LastConfigurationSet;

                    //    Console.WriteLine($"[Configuration Handler] Using configuration set {settings.LastConfigurationSet}.");

                    //    //var dir = Path.GetDirectoryName(ConfigPath);
                    //    //if (!Directory.Exists(dir))
                    //    //    Directory.CreateDirectory(dir);

                    //    //var json = JsonConvert.SerializeObject(this, Formatting.Indented);
                    //    //File.WriteAllText(ConfigPath, json);

                    //    if (File.Exists(ConfigPath))
                    //    {
                    //        var jsonx = File.ReadAllText(ConfigPath);
                    //        var settingsx = JsonConvert.DeserializeObject<QuickSettings>(json) ?? new QuickSettings();
                    //        return settingsx;
                    //    }
                    //    else
                    //    {

                    //    }
                    //}
                }
                else
                {
                    Console.WriteLine($"[Configuration Handler] No configuration file. Default values will be returned.");
                }
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"Settings could not be loaded. {ex.Message}\r\n\r\n" +
                    $"Click ABORT to open the location of the data.\r\n" +
                    $"Click RETRY to wipe all settings data.\r\n" +
                    $"Click IGNORE to do nothing, and exit.",
                    "SharpAlert",
                    MessageBoxButtons.AbortRetryIgnore,
                    MessageBoxIcon.Error);

                switch (result)
                {
                    case DialogResult.Abort:
                        Process.Start(new ProcessStartInfo { FileName = ConfigDirPath, UseShellExecute = true });
                        break;
                    case DialogResult.Retry:
                        File.Delete(ConfigPath);
                        Environment.Exit(100);
                        break;
                    case DialogResult.Ignore:
                        Environment.Exit(0);
                        break;
                }

                Environment.Exit(9009);
                return null;
            }

            return new QuickSettings();
        }

        public void Reset()
        {
            if (ReadOnlyMode)
            {
                Console.WriteLine($"[Configuration Handler] The current configuration is not being saved due to read only mode.");
                return;
            }

            lock (this)
            {
                var dir = Path.GetDirectoryName(ConfigPath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var json = JsonConvert.SerializeObject(new QuickSettings(), Formatting.Indented);
                File.WriteAllText(ConfigPath, json);

                Console.WriteLine($"[Configuration Handler] The current configuration has been reset.");

                Reload();
            }
        }

        public static void Reload()
        {
            _instance = Load();
        }
    }

}

