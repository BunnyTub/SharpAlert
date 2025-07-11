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
        public const int BuildNumber = 1292;
        public const string BuiltOnDate = "2025-07-11";
        public const string BuiltOnTime = "13:00";
        public const string BuiltTimeZone = "Eastern Standard Time";
        public static int MajorVersion { get; } = 10;
        public static int MinorVersion { get; } = 0;
        public static readonly bool IsBetaVersion = true;
        public static string FriendlyVersion
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
            "7/27/2025",
            "M/d/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
        );
    }
}
