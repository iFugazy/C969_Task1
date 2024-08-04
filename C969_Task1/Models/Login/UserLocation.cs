using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Models
{
    public static class UserLocation
    {
        public static TimeZoneInfo localZone = TimeZoneInfo.Local;
        public static DateTime localDataTime = DateTime.Now;
        public static TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(localDataTime);
        public static CultureInfo currentCulture = CultureInfo.CurrentCulture;


       
        public static void UserLocationString(LoginForm loginForm)
        {
            loginForm.userLocationLBL.Text = currentCulture.DisplayName;
           /* if (locationMapping.TryGetValue((utcOffset, currentCulture.Name), out string location))
            {
                
                loginForm.userLocationLBL.Text = location;
            }
            else
            {
                MessageBox.Show(location);
            }*/
        }

    }
}
