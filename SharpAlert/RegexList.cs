using System;
using System.Text.RegularExpressions;

namespace SharpAlert
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

        public static readonly Regex HrefRegex = new(
			@"<a\s+[^>]*?href\s*=\s*[""']([^""']+)[""']", // yeah I just copied this, I can't even read it, but at least it works.
			RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex UrnOidCapRegex = new(
            @"(urn:oid:[^/]+?\.cap)",
			RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex LinkRegex = new(
			@"<link\s+[^>]*?href\s*=\s*[""']([^""']+)[""']", //<link rel="alternate" href="https://api.weather.gov/alerts/urn:oid:2.49.0.1.840.0-KEEPALIVE-57752.cap"/>
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex ReplayedAlertRegex = new(
            @"<SharpAlertReplay>\s*(.*?)\s*</SharpAlertReplay>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex SourceRegex = new(
            @"<SharpAlertSource>\s*(.*?)\s*</SharpAlertSource>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex AlertTitleRegex = new(
            @"<SharpAlert-AlertTitle>\s*(.*?)\s*</SharpAlert-AlertTitle>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex AlertIntroRegex = new(
            @"<SharpAlert-AlertIntro>\s*(.*?)\s*</SharpAlert-AlertIntro>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex AlertBodyRegex = new(
            @"<SharpAlert-AlertBody>\s*(.*?)\s*</SharpAlert-AlertBody>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex LanguageRegex = new(
			@"<language>\s*(.*?)\s*</language>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex StatusRegex = new(
			@"<status>\s*(.*?)\s*</status>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex MessageTypeRegex = new(
			@"<msgType>\s*(.*?)\s*</msgType>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex UrgencyRegex = new(
			@"<urgency>\s*(.*?)\s*</urgency>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex CategoryRegex = new(
			@"<category>\s*(.*?)\s*</category>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WirelessImmediateRegex = new(
            @"<parameter><valueName>layer:SOREM:2\.0:WirelessImmediate</valueName><value>\s*(.*?)\s*</value></parameter>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex SeverityRegex = new(
			@"<severity>\s*(.*?)\s*</severity>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex InfoRegex = new(
			@"<info>\s*(.*?)\s*</info>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex URLRegex = new(
			@"<url>\s*(.*?)\s*</url>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WebRegex = new(
			@"<web>\s*(.*?)\s*</web>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex SentRegex = new(
            @"<sent>\s*(.*?)\s*</sent>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EffectiveRegex = new(
			@"<effective>\s*(.*?)\s*</effective>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex OnsetRegex = new(
            @"<onset>\s*(.*?)\s*</onset>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex ExpiresRegex = new(
			@"<expires>\s*(.*?)\s*</expires>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		/// <summary>
		///		<cap:sent>2025-05-26T05:15:00-05:00</cap:sent>
        ///		<cap:effective>2025-05-26T05:15:00-05:00</cap:effective>
        ///		<cap:onset>2025-05-26T05:15:00-05:00</cap:onset>
        ///		<cap:expires>2025-05-26T05:45:00-05:00</cap:expires>
		/// </summary>

		public static readonly Regex AtomEffectiveRegex = new(
            @"<cap:effective>\s*(.*?)\s*</cap:effective>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex AtomExpiresRegex = new(
            @"<cap:expires>\s*(.*?)\s*</cap:expires>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EntryRegex = new(
            @"<entry>\s*(.*?)\s*</entry>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex EntryLinkRegex = new(
            @"<link rel=""alternate"" href=""\s*(.*?)\s*""/>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex IdRegex = new(
            @"<id>\s*(.*?)\s*</id>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EventRegex = new(
			@"<event>\s*(.*?)\s*</event>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex EventCodeRegex = new(
            @"<eventcode><valueName>SAME</valueName><value>\s*(.*?)\s*</value></eventcode>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex BroadcastImmediatelyRegex = new(
            @"<parameter><valueName>layer:SOREM:1\.0:Broadcast_Immediately</valueName><value>\s*(.*?)\s*</value></parameter>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex ResourceRegex = new(
            @"<resource>\s*(.*?)\s*</resource>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex ResourceDescRegex = new(
            @"<resourceDesc>\s*(.*?)\s*</resourceDesc>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex MIMETypeRegex = new(
            @"<mimeType>\s*(.*?)\s*</mimeType>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex SizeRegex = new(
            @"<size>\s*(.*?)\s*</size>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex URIRegex = new(
            @"<uri>\s*(.*?)\s*</uri>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex DerefURIRegex = new(
            @"<derefUri>\s*(.*?)\s*</derefUri>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex DigestSecureHashAlgorithmOneRegex = new(
            @"<digest>\s*(.*?)\s*</digest>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex SenderNameRegex = new(
			@"<senderName>\s*(.*?)\s*</senderName>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex SenderRegex = new(
			@"<sender>\s*(.*?)\s*</sender>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex AuthorNameRegex = new(
            @"<name>\s*(.*?)\s*</name>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex DescriptionRegex = new(
			@"<description>\s*(.*?)\s*</description>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex InstructionRegex = new(
			@"<instruction>\s*(.*?)\s*</instruction>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex BroadcastTextRegex = new(
            @"<parameter><valueName>layer:SOREM:1\.0:Broadcast_Text</valueName><value>\s*(.*?)\s*</value></parameter>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WirelessTextRegex = new(
            @"<parameter><valueName>layer:SOREM:2\.0:WirelessText</valueName><value>\s*(.*?)\s*</value></parameter>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex AreaDescriptionRegex = new(
			@"<areaDesc>\s*(.*?)\s*</areaDesc>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex TypeURIRegex = new(
			@"<uri>\s*(.*?)\s*</uri>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex MimeRegex = new(
			@"<mimeType>\s*(.*?)\s*</mimeType>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex IdentifierRegex = new(
			@"<identifier>\s*(.*?)\s*</identifier>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex ReferencesRegex = new(
			@"<references>\s*(.*?)\s*</references>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex TimeCorrectionRegex = new(
            @"\b(\d{1,4})\s*(AM|PM)\b",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex AlertRegex = new(
			@"<alert[^>]*>\s*(.*?)\s*</alert>",
			RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex CMAMRegex = new(
            @"<valueName>CMAMtext</valueName>\s*<value>\s*(.*?)\s*</value>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex CMAMLongRegex = new(
            @"<valueName>CMAMlongtext</valueName>\s*<value>\s*(.*?)\s*</value>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex WEAHandlingRegex = new(
            @"<valueName>WEAHandling</valueName>\s*<value>\s*(.*?)\s*</value>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex GeocodeSpecificAreaMessageEncodingRegex = new(
            @"<geocode>\s*<valueName>SAME</valueName>\s*<value>\s*(.*?)\s*</value>\s*</geocode>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static readonly Regex GeocodeCommonAlertingProtocolCanadaLocationCodeRegex = new(
            @"<geocode>\s*<valueName>profile:CAP-CP:Location:0.3</valueName>\s*<value>\s*(.*?)\s*</value>\s*</geocode>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		public static readonly Regex GeocodeCommonAlertingProtocolCanadaEventCodeRegex = new(
            @"<geocode>\s*<valueName>profile:CAP-CP:Event:0.4</valueName>\s*<value>\s*(.*?)\s*</value>\s*</geocode>",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static Regex GeocodeRegex = new(
             @"<geocode>\s*(.*?)\s*</geocode>",
             RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static Regex ValueNameRegex = new(
             @"<valueName>\s*(.*?)\s*</valueName>",
             RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		
		public static Regex ValueRegex = new(
             @"<value>\s*(.*?)\s*></value>",
             RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Singleline);
    }
}


