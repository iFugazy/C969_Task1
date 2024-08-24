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

        public int userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int active { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }


        public async static void UserLocationString(LoginForm loginForm)
        {
            var client = new IpDataClient(ipdataAPIKey);
            var ipInfo = await client.Lookup();
            
            
            loginForm.userLocationLBL.Text = ipInfo.City + "/" + ipInfo.Region;
            
            
        }

        public  User()
        {
        }

        public void CheckUser(string userName, string password)
        {


            string qry = $"SELECT * FROM user WHERE userName = '{userName}' and password = '{password}'";

            MySqlDataReader rdr = db.DBCommand(qry).ExecuteReader();


            

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    this.userID = Convert.ToInt32(rdr["userId"]);
                    this.userName = rdr["userName"].ToString();
                    this.password = rdr["password"].ToString();
                    this.active = Convert.ToInt32(rdr["active"]);
                    this.createDate = Convert.ToDateTime(rdr["createDate"]);
                    this.createdBy = rdr["createdBy"].ToString();
                    this.lastUpdate = Convert.ToDateTime(rdr["lastUpdate"]);
                    this.lastUpdateBy = rdr["lastUpdateBy"].ToString();
                }
            }
        }

        private static void LoginTranslator(LoginForm loginForm)
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
