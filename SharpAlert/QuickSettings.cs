using System;
using System.Collections.Specialized;
using System.IO;
using System.Text.Json;

namespace SharpAlert
{
    public class QuickSettings
    {
        private static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SharpAlert", "configuration.json");

        private static QuickSettings _instance;

        public static QuickSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

#pragma warning disable IDE1006 // Naming Styles
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
        public StringCollection AllowedSAMELocations_Geocodes { get; set; } = new StringCollection();
        public StringCollection AllowedCAPCPLocations_Geocodes { get; set; } = new StringCollection();
        // Blacklist
        public StringCollection EnforceEventBlacklist { get; set; } = new StringCollection();
        public StringCollection EnforceSAMEEventBlacklist { get; set; } = new StringCollection();
        // Alert Stuff
        public int AlertCheckInterval { get; set; } = 30;
        public bool weaOnly { get; set; } = false;
        public bool discardFirstAlerts { get; set; } = false;
        // Alert Dialogs
        public int alertDisplayType { get; set; } = 0;
        public int WindowLocation { get; set; } = 0;
        public int alertTimeout { get; set; } = 5;
        public bool alertFullscreenIdle { get; set; } = true;
        public int alertFullscreenDisplay { get; set; } = 0;
        public int alertDeadInterval { get; set; } = 1;
        public bool alertCompatibilityMode { get; set; } = false;
        public bool statusWindow { get; set; } = false;
        public bool showExpiryMessages { get; set; } = false;
        public bool alertNoGUI { get; set; } = false;
        // "alertNoRelay" disables USB relays. It doesn't prevent relaying.]
        public bool alertNoRelay { get; set; } = false;
        public bool DisableDialogs { get; set; } = false;
        public bool alertIncreaseSize { get; set; } = false;
        public bool alertTitlebarControls { get; set; } = false;
        public bool alertTimeZoneUTC { get; set; } = false;
        public bool alertTTSonly { get; set; } = false;
        public bool alertPlayStartToneTwice { get; set; } = false;
        public bool alertPlayEndTone { get; set; } = false;
        public bool LegacyAudioPlayer { get; set; } = false;
        public int alertVolume { get; set; } = 8;
        public string StartToneLocation { get; set; } = string.Empty;
        public string EndToneLocation { get; set; } = string.Empty;
        public string ProgramVoice { get; set; } = string.Empty;
        public string ProgramAudioOutput { get; set; } = string.Empty;
        // "MakiVersion" is unused.
        public string MakiVersion { get; set; } = string.Empty;
        // Data Structure
        public int storedMaxSize { get; set; } = 500;
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
        // Discord
        public string DiscordWebhook { get; set; } = string.Empty;
        public string DiscordWebhookAppend { get; set; } = string.Empty;
        public bool DiscordWebhookConfirmAlerts { get; set; } = true;
        public bool DiscordWebhookRelayLocally { get; set; } = false;
        // Categories
        public bool categoryGeophysical { get; set; } = true;
        public bool categorySecurity { get; set; } = true;
        public bool categoryMedical { get; set; } = true;
        public bool categoryUtilites { get; set; } = true;
        public bool categoryMeterological { get; set; } = true;
        public bool categoryRescue { get; set; } = true;
        public bool categoryEnvironmental { get; set; } = true;
        public bool categoryToxicThreat { get; set; } = true;
        public bool categoryGeneralSafety { get; set; } = true;
        public bool categoryFire { get; set; } = true;
        public bool categoryTransportation { get; set; } = true;
        public bool categoryOtherUnknown { get; set; } = true;
        // Language
        public bool AllowNonEnglishAlerts { get; set; } = false;
#pragma warning restore IDE1006 // Naming Styles

        public void Save()
        {
            var dir = Path.GetDirectoryName(ConfigPath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigPath, json);
        }

        public static QuickSettings Load()
        {
            if (File.Exists(ConfigPath))
            {
                var json = File.ReadAllText(ConfigPath);
                return JsonSerializer.Deserialize<QuickSettings>(json) ?? new QuickSettings();
            }
            return new QuickSettings();
        }

        public void Reload()
        {
            _instance = Load();
        }
    }

}
