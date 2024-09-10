using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpData;
using IpData.Models;

namespace C969_Task1.Models
{
    public static class User
    {
        public static TimeZoneInfo localZone = TimeZoneInfo.Local;
        public static DateTime localDataTime = DateTime.Now;
        public static TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(localDataTime);
        public static CultureInfo currentCulture = CultureInfo.CurrentCulture;

        static string ipdataAPIKey = "ba3ee9df74076016dd30fdcbf4f68d15aff80eaec98e3fdc45b5243b";



        public async static void UserLocationString(LoginForm loginForm)
        {
            var client = new IpDataClient(ipdataAPIKey);
            var ipInfo = await client.Lookup();
            var regKeyGeoId = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\International\Geo");
            var geoID = (string)regKeyGeoId.GetValue("Nation");
            var allRegions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.ToString()));
            var regionInfo = allRegions.FirstOrDefault(ref => ref.GeoId == Int32.Parse(geoID));
            
            loginForm.userLocationLBL.Text = regionInfo;
            
            
        }

        public static void LoginTranslator(LoginForm loginForm)
        {
            if (loginForm.spanishRBTN.Checked is true)
            {
                loginForm.locationLBL.Text = "Ubicación:";
                loginForm.usernameLBL.Text = "Nombre de usuario:";
                loginForm.passwordLBL.Text = "Contraseña:";
                loginForm.loginBTN.Text = "Acceso";
                loginForm.cancelBTN.Text = "Cancelar";


            }
            else
            {
                loginForm.locationLBL.Text = "Location:";
                loginForm.usernameLBL.Text = "Username:";
                loginForm.passwordLBL.Text = "Password:";
                loginForm.loginBTN.Text = "Login";
                loginForm.cancelBTN.Text = "Cancel";
            }
        }
    }
}
