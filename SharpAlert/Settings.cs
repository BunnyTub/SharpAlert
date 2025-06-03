using System;

namespace SharpAlert.Properties
{
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings
    {
        public Settings()
        {
            this.SettingChanging += this.SettingChangingEventHandler;
            this.SettingsSaving += this.SettingsSavingEventHandler;
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            ConsoleExt.WriteLine($"[Configuration Handler] The value of \"{e.SettingName}\" is being updated to \"{e.NewValue}\".");

        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ConsoleExt.WriteLine($"[Configuration Handler] The current configuration is being saved.");
        }
    }
}
