namespace SharpAlertPluginBase
{
    /// <summary>
    /// This interface is the current sole way for plugins to receive alert data.
    /// </summary>
    public interface IPlugHandler
    {
        /// <summary>
        /// The UUID of your plugin.
        /// </summary>
        /// <remarks>No plugins should ever have matching UUIDs.</remarks>
        public Guid PluginUUID { get; }
        /// <summary>
        /// The name of your plugin.
        /// </summary>
        /// <remarks>This string will be visible to the user.</remarks>
        string FriendlyName { get; }
        /// <summary>
        /// The description of your plugin.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The entry point to your plugin. It is called only once, and only when SharpAlert is starting up.
        /// </summary>
        /// <returns><c>True</c> if the plugin initialized successfully. <c>False</c> if the plugin failed to initialize properly.</returns>
        /// <remarks>If your plugin fails to initialize, SharpAlert will not use try to use any part of your plugin.</remarks>
        bool Initialize(int VersionMajor, int VersionMinor, bool VersionIsBeta, string PluginFolder);

        /// <summary>
        /// This method is called right before SharpAlert tries to relay an alert.
        /// </summary>
        /// <param name="AlertInfoJSON">Contains a JSONified AlertInfo class.</param>
        /// <returns><c>True</c> if the alert should be relayed. <c>False</c> if the alert should not be relayed.</returns>
        bool AlertTBR(string AlertInfoJSON); // alert TO BE RELAYED

        /// <summary>
        /// Invoke this event to relay an alert through SharpAlert.
        /// </summary>
        /// <remarks>SharpAlert will be listening for this event, but it will never invoke it. This event should not be subscribed to.</remarks>
        event Action<AlertContents.AlertInfo>? AlertOutbound;
    }
}
