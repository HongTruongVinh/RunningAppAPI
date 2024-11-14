using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppServices.CommonFunction
{
    public static class TimeZoneService
    {
        private static readonly TimeZoneInfo Gmt7TimeZone = TimeZoneInfo.FindSystemTimeZoneById(
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "SE Asia Standard Time" : "Asia/Ho_Chi_Minh");

        /// <summary>
        /// Get Current Gmt7 Time
        /// </summary>
        /// <returns></returns>
        public static DateTime Now()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Gmt7TimeZone);
        }
    }
}
