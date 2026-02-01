namespace SharpAlertPluginBase
{
    /// <summary>
    /// Used for various types of alert information.
    /// </summary>
    public static class AlertContents
    {
        /// <summary>
        /// Contains alert information formatted similarly to the Common Alerting Protocol.
        /// </summary>
        public class AlertInfo
        {
            /// <summary>
            /// The reason an alert was discarded.
            /// </summary>
            /// <remarks>This should only be used when an alert is rejected within SharpAlert.</remarks>
            public string AlertDiscardReason { get; set; } = string.Empty;
            /// <summary>
            /// The source of an alert.
            /// </summary>
            public string AlertSource { get; set; } = string.Empty;
            /// <summary>
            /// The sender of an alert.
            /// </summary>
            public string AlertSender { get; set; } = string.Empty;
            /// <summary>
            /// The unique identification of an alert.
            /// </summary>
            public string AlertID { get; set; } = string.Empty;
            /// <summary>
            /// DATETIME?
            /// </summary>
            public string AlertSentDate { get; set; } = string.Empty;
            /// <summary>
            /// DATETIME?
            /// </summary>
            public string AlertBeginDate { get; set; } = string.Empty;
            /// <summary>
            /// DATETIME?
            /// </summary>
            public string AlertExpiryDate { get; set; } = string.Empty;
            public List<string> AlertFriendlyLocations { get; set; } = [];
            public string AlertEventType { get; set; } = string.Empty;
            public string AlertMessageType { get; set; } = string.Empty;
            public string AlertSeverity { get; set; } = string.Empty;
            public string AlertIntroText { get; set; } = string.Empty;
            public string AlertBodyText { get; set; } = string.Empty;
            public string AlertURL { get; set; } = string.Empty;
            public string AlertAudioURL { get; set; } = string.Empty;
            public string AlertAudioDeref { get; set; } = string.Empty;
            public string AlertImageURL { get; set; } = string.Empty;
        }
    }
}
