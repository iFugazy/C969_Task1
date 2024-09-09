using C969_Task1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using C969_Task1.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace C969_Task1
{
    public partial class LoginForm : Form
    {
        public string connstring;
        public MySqlConnection cnn;
        DatabaseConnection db = new DatabaseConnection();

        public LoginForm()
        {
            InitializeComponent();


        }



        private void loginBTN_Click(object sender, EventArgs e)
        {
            int i = 0;
            string query = "select * from client_schedule.user where userName='" + usernameTB.Text + "' and password= '" + passwordTB.Text + "'";
            /*MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from client_schedule.user where userName='" + usernameTB.Text + "' and password= '" + passwordTB.Text + "'";
            db.DBCommand(query);
            cmd.ExecuteNonQuery();*/
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(db.DBCommand(query));
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            Appointment.checkUserReminders(User.userID);


            if (i == 0)
            {
                var regKeyGeoId = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\International\Geo");
                var geoID = (string)regKeyGeoId.GetValue("Nation");
                var allRegions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.ToString()));
                var regionInfo = allRegions.FirstOrDefault(r => r.GeoId == Int32.Parse(geoID));

                if (regionInfo.Name != "United States")
                {
                    MessageBox.Show("El nombre de usuario y la contraseña no coinciden", "Error de inicio de sesión");

                }
                else
                {
                    MessageBox.Show("The username and password do not match", "Login Error");
                }
            }
            else
            {
                User.CheckUser(usernameTB.Text, passwordTB.Text);

                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();

                return;

            }
            


        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            User.UserLocationString(this);
            User.LoginTranslator(this);
        }
    }
}
