using System.Globalization;
using System;

namespace SharpAlert
{
    public static class VersionInfo
    {
        // last build was 1891 before the upgrade to .NET 9
        public static int MajorVersion { get; } = 13;
        public static int MinorVersion { get; } = 0;
        public static bool IsBetaVersion { get; } = false;
        public static string ShortFriendlyVersion
        {
            get
            {
                if (!IsBetaVersion)
                {
                    //return $"SharpAlert | Release v{MajorVersion}.{MinorVersion} (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SharpAlert v{MajorVersion}.{MinorVersion}";
                }
                else
                {
                    //return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SharpAlert v{MajorVersion}.{MinorVersion}-b";
                }
            }
        }
        public static string LongFriendlyVersion
        {
            get
            {
                if (!IsBetaVersion)
                {
                    //return $"SharpAlert | Release v{MajorVersion}.{MinorVersion} (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SharpAlert | Release v{MajorVersion}.{MinorVersion} | Safety is never a non-priority";
                }
                else
                {
                    //return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b | Safety is never a non-priority";
                }
            }
        }

        public static readonly DateTime BetaTimeEnd = DateTime.ParseExact(
            "9/30/2025",
            "M/d/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
        );
    }
}
