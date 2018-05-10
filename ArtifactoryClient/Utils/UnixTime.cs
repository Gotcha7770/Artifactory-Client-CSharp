using System;

namespace ArtifactoryClient.Utils
{
    internal static class UnixTime
    {
        /// <summary>
        /// Unix Epoch Start (from 1.1.1970 UTC)
        /// </summary>
        public static readonly DateTime UnixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Current time in Unix format (UTC)
        /// </summary>
        /// <returns>amount of seconds</returns>
        public static long Now => DateTime.UtcNow.ToUnixStamp();

        /// <summary>
        /// Convert time to <see cref="long"/> in Unix format (UTC)
        /// </summary>
        /// <returns>amount of seconds</returns>
        public static long ToUnixStamp(this DateTime value)
        {
            return (long)value.Subtract(UnixEpochStart).TotalSeconds;
        }
    }
}
