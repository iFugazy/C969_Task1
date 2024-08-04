using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public static class UserLocation
    {
        public static TimeZoneInfo localZone = TimeZoneInfo.Local;
        public static DateTime localDataTime = DateTime.Now;
        public static TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(localDataTime);
        public static CultureInfo currentCulture = CultureInfo.CurrentCulture;

        public static Dictionary<string, string> cityMappings = new Dictionary<string, string>
        {
            { "Eastern Standard Time", "Eastern/Atlanta" },
            { "Central Standard Time", "Central/Chicago" },
            { "Mountain Standard Time", "Mountain/Denver" },
            { "Pacific Standard Time", "Pacific/Los Angeles" },
        };

        public static void UserLocationString(LoginForm loginForm)
        {
            if (utcOffset == TimeSpan.FromHours(-5) )
            loginForm.userLocationLBL.Text = currentCulture.Name;
            /*if (cityMappings.TryGetValue(localZone.Id, out string city))
            {
                loginForm.userLocationLBL.Text = city.ToString();
            }
            else
            {
                loginForm.userLocationLBL.Text = "Can't find the location";
            }*/
        }

    }
}
