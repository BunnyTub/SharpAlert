using System.Globalization;
using System;

namespace SharpAlert
{
    public static class VersionInfo
    {
        // This file contains the version information. It should not be modified at runtime.
        // You can change the release, minor, and cutting edge variables.
        // ---
        // Use VersionInfoTemplate.cs!
        public const int BuildNumber = 1866;
        public const string BuiltOnDate = "2025-09-06";
        public const string BuiltOnTime = "00:23";
        public const string BuiltTimeZone = "Eastern Standard Time";
        public static int MajorVersion { get; } = 12;
        public static int MinorVersion { get; } = 0;
        public static bool IsBetaVersion { get; } = true;
        public static string ShortFriendlyVersion
        {
            get
            {
                if (!IsBetaVersion)
                {
                    //return $"SharpAlert | Release v{MajorVersion}.{MinorVersion} (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SharpAlert v{MajorVersion}.{MinorVersion} (Build {BuildNumber})";
                }
                else
                {
                    //return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SharpAlert v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber})";
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
                    return $"SharpAlert | Release v{MajorVersion}.{MinorVersion} (Build {BuildNumber}) | Safety is never a non-priority";
                }
                else
                {
                    //return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber}) | Safety is never a non-priority";
                }
            }
        }

        public static readonly DateTime BetaTimeEnd = DateTime.ParseExact(
            "8/16/2025",
            "M/d/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
        );
    }
}
