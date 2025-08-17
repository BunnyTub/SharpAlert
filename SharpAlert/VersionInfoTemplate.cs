using System.Globalization;
using System;

namespace SharpAlert
{
    public static class VersionInfoTemplate
    {
        // This file contains the version information. It should not be modified at runtime.
        // You can change the release, minor, and cutting edge variables.
        // ---
        // Do not change consts!
        public const int BuildNumber = 0;
        public const string BuiltOnDate = "";
        public const string BuiltOnTime = "";
        public const string BuiltTimeZone = "";
        public static int MajorVersion { get; } = 10;
        public static int MinorVersion { get; } = 2;
        public static bool IsBetaVersion { get; } = false;
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