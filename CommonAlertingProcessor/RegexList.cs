using System;
using System.Text.RegularExpressions;

namespace CommonAlertingProcessor
{
	public static class RegexList
	{
        public static string MatchOrDefault(this Regex regex, string input, string defaultValue = "")
        {
            if (regex == null) throw new ArgumentNullException(nameof(regex));
            if (input == null) return defaultValue;

            var match = regex.Match(input);
            return match.Success ? match.Groups[1].Value : defaultValue;
        }

        //public static string[] MatchesOrDefault(this Regex regex, string input, string defaultValue = "")
        //{
        //    if (regex == null) throw new ArgumentNullException(nameof(regex));
        //    if (input == null) return defaultValue;

        //    var match = regex.Match(input);
        //    return match.Success ? match.Groups[1].Value : defaultValue;
        //}

        // for some reason, the Regex engine ignores forward slashes as syntax. It does make things a little cleaner though.

        public static readonly Regex HrefRegex = new Regex(
			@"<a\s+[^>]*?href\s*=\s*[""']([^""']+)[""']", // yeah I just copied this, I can't even read it, but at least it works.
			RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex LinkRegex = new Regex(
			@"<link\s+[^>]*?href\s*=\s*[""']([^""']+)[""']", //<link rel="alternate" href="https://api.weather.gov/alerts/urn:oid:2.49.0.1.840.0-KEEPALIVE-57752.cap"/>
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex ReplayedAlertRegex = new Regex(
            @"<SharpAlertReplay>\s*(.*?)\s*</SharpAlertReplay>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex SourceRegex = new Regex(
            @"<SharpAlertSource>\s*(.*?)\s*</SharpAlertSource>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex AlertTitleRegex = new Regex(
            @"<SharpAlert-AlertTitle>\s*(.*?)\s*</SharpAlert-AlertTitle>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex AlertIntroRegex = new Regex(
            @"<SharpAlert-AlertIntro>\s*(.*?)\s*</SharpAlert-AlertIntro>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex AlertBodyRegex = new Regex(
            @"<SharpAlert-AlertBody>\s*(.*?)\s*</SharpAlert-AlertBody>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex LanguageRegex = new Regex(
			@"<language>\s*(.*?)\s*</language>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex StatusRegex = new Regex(
			@"<status>\s*(.*?)\s*</status>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex MessageTypeRegex = new Regex(
			@"<msgType>\s*(.*?)\s*</msgType>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex UrgencyRegex = new Regex(
			@"<urgency>\s*(.*?)\s*</urgency>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex CategoryRegex = new Regex(
			@"<category>\s*(.*?)\s*</category>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WirelessImmediateRegex = new Regex(
            @"<parameter><valueName>layer:SOREM:2\.0:WirelessImmediate</valueName><value>\s*(.*?)\s*</value></parameter>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex SeverityRegex = new Regex(
			@"<severity>\s*(.*?)\s*</severity>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex InfoRegex = new Regex(
			@"<info>\s*(.*?)\s*</info>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex URLRegex = new Regex(
			@"<url>\s*(.*?)\s*</url>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WebRegex = new Regex(
			@"<web>\s*(.*?)\s*</web>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex SentRegex = new Regex(
            @"<sent>\s*(.*?)\s*</sent>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EffectiveRegex = new Regex(
			@"<effective>\s*(.*?)\s*</effective>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex OnsetRegex = new Regex(
            @"<onset>\s*(.*?)\s*</onset>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex ExpiresRegex = new Regex(
			@"<expires>\s*(.*?)\s*</expires>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		/// <summary>
		///		<cap:sent>2025-05-26T05:15:00-05:00</cap:sent>
        ///		<cap:effective>2025-05-26T05:15:00-05:00</cap:effective>
        ///		<cap:onset>2025-05-26T05:15:00-05:00</cap:onset>
        ///		<cap:expires>2025-05-26T05:45:00-05:00</cap:expires>
		/// </summary>

		public static readonly Regex AtomEffectiveRegex = new Regex(
            @"<cap:effective>\s*(.*?)\s*</cap:effective>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex AtomExpiresRegex = new Regex(
            @"<cap:expires>\s*(.*?)\s*</cap:expires>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EntryRegex = new Regex(
            @"<entry>\s*(.*?)\s*</entry>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex EntryLinkRegex = new Regex(
            @"<link rel=""alternate"" href=""\s*(.*?)\s*""/>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EventRegex = new Regex(
			@"<event>\s*(.*?)\s*</event>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex EventCodeRegex = new Regex(
            @"<eventcode><valueName>SAME</valueName><value>\s*(.*?)\s*</value></eventcode>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex BroadcastImmediatelyRegex = new Regex(
            @"<parameter><valueName>layer:SOREM:1\.0:Broadcast_Immediately</valueName><value>\s*(.*?)\s*</value></parameter>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex ResourceRegex = new Regex(
            @"<resource>\s*(.*?)\s*</resource>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex ResourceDescRegex = new Regex(
            @"<resourceDesc>\s*(.*?)\s*</resourceDesc>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex MIMETypeRegex = new Regex(
            @"<mimeType>\s*(.*?)\s*</mimeType>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex SizeRegex = new Regex(
            @"<size>\s*(.*?)\s*</size>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex URIRegex = new Regex(
            @"<uri>\s*(.*?)\s*</uri>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex DerefURIRegex = new Regex(
            @"<derefUri>\s*(.*?)\s*</derefUri>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex DigestSecureHashAlgorithmOneRegex = new Regex(
            @"<digest>\s*(.*?)\s*</digest>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex SenderNameRegex = new Regex(
			@"<senderName>\s*(.*?)\s*</senderName>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex SenderRegex = new Regex(
			@"<sender>\s*(.*?)\s*</sender>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex AuthorNameRegex = new Regex(
            @"<name>\s*(.*?)\s*</name>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex DescriptionRegex = new Regex(
			@"<description>\s*(.*?)\s*</description>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex InstructionRegex = new Regex(
			@"<instruction>\s*(.*?)\s*</instruction>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex BroadcastTextRegex = new Regex(
            @"<parameter><valueName>layer:SOREM:1\.0:Broadcast_Text</valueName><value>\s*(.*?)\s*</value></parameter>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WirelessTextRegex = new Regex(
            @"<parameter><valueName>layer:SOREM:2\.0:WirelessText</valueName><value>\s*(.*?)\s*</value></parameter>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex AreaDescriptionRegex = new Regex(
			@"<areaDesc>\s*(.*?)\s*</areaDesc>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex TypeURIRegex = new Regex(
			@"<uri>\s*(.*?)\s*</uri>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex MimeRegex = new Regex(
			@"<mimeType>\s*(.*?)\s*</mimeType>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex IdentifierRegex = new Regex(
			@"<identifier>\s*(.*?)\s*</identifier>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex ReferencesRegex = new Regex(
			@"<references>\s*(.*?)\s*</references>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex TimeCorrectionRegex = new Regex(
            @"\b(\d{1,4})\s*(AM|PM)\b",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex AlertRegex = new Regex(
			@"<alert[^>]*>\s*(.*?)\s*</alert>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex CMAMRegex = new Regex(
            @"<valueName>CMAMtext</valueName>\s*<value>\s*(.*?)\s*</value>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex CMAMLongRegex = new Regex(
            @"<valueName>CMAMlongtext</valueName>\s*<value>\s*(.*?)\s*</value>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WEAHandlingRegex = new Regex(
            @"<valueName>WEAHandling</valueName>\s*<value>\s*(.*?)\s*</value>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex GeocodeSpecificAreaMessageEncodingRegex = new Regex(
            @"<geocode>\s*<valueName>SAME</valueName>\s*<value>\s*(.*?)\s*</value>\s*</geocode>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex GeocodeCommonAlertingProtocolCanadaLocationCodeRegex = new Regex(
            @"<geocode>\s*<valueName>profile:CAP-CP:Location:0.3</valueName>\s*<value>\s*(.*?)\s*</value>\s*</geocode>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex GeocodeCommonAlertingProtocolCanadaEventCodeRegex = new Regex(
            @"<geocode>\s*<valueName>profile:CAP-CP:Event:0.4</valueName>\s*<value>\s*(.*?)\s*</value>\s*</geocode>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static Regex GeocodeRegex = new Regex(
             @"<geocode>\s*(.*?)\s*</geocode>",
             RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static Regex ValueNameRegex = new Regex(
             @"<valueName>\s*(.*?)\s*</valueName>",
             RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static Regex ValueRegex = new Regex(
             @"<value>\s*(.*?)\s*></value>",
             RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
    }
}


