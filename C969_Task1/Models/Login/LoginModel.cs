using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Models
{
    public static class LoginModel
    {
        public static TimeZoneInfo localZone = TimeZoneInfo.Local;
        public static DateTime localDataTime = DateTime.Now;
        public static TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(localDataTime);
        public static CultureInfo currentCulture = CultureInfo.CurrentCulture;


       
        public static void UserLocationString(LoginForm loginForm)
        {
            loginForm.userLocationLBL.Text = currentCulture.DisplayName;
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
