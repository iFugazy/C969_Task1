using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpData;
using IpData.Models;
using MySql.Data.MySqlClient;

namespace C969_Task1.Models
{
    public class User
    {
        public static DatabaseConnection db = new DatabaseConnection();

        public static TimeZoneInfo localZone = TimeZoneInfo.Local;
        public static DateTime localDataTime = DateTime.Now;
        public static TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(localDataTime);
        public static CultureInfo currentCulture = CultureInfo.CurrentCulture;

        static string ipdataAPIKey = "ba3ee9df74076016dd30fdcbf4f68d15aff80eaec98e3fdc45b5243b";

        public static int userID { get; set; }
        public static string userName { get; set; }
        public static string password { get; set; }
        public static int active { get; set; }
        public static DateTime createDate { get; set; }
        public static string createdBy { get; set; }
        public static DateTime lastUpdate { get; set; }
        public static string lastUpdateBy { get; set; }


        public async static void UserLocationString(LoginForm loginForm)
        {
            try
            {
                var client = new IpDataClient(ipdataAPIKey);
                var ipInfo = await client.Lookup();
                loginForm.userLocationLBL.Text = ipInfo.City + "/" + ipInfo.Region;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error with location API\n\n {ex.Message}", "API Error");
            }
            
            
            
            
            
            
        }

        public  User(string userName, string password)
        {
            User.userName = userName;
            User.password = password;
        }

        public static void CheckUser(string userName, string password)
        {


            string qry = $"SELECT * FROM user WHERE userName = '{userName}' and password = '{password}'";

            MySqlDataReader rdr = db.DBCommand(qry).ExecuteReader();


            

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    User.userID = Convert.ToInt32(rdr["userId"]);
                    User.userName = rdr["userName"].ToString();
                    User.password = rdr["password"].ToString();
                    User.active = Convert.ToInt32(rdr["active"]);
                    User.createDate = Convert.ToDateTime(rdr["createDate"]);
                    User.createdBy = rdr["createdBy"].ToString();
                    User.lastUpdate = Convert.ToDateTime(rdr["lastUpdate"]);
                    User.lastUpdateBy = rdr["lastUpdateBy"].ToString();
                }
            }
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
