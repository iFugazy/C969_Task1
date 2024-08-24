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
        MainCustomerForm addCustomerForm = new MainCustomerForm();

        public LoginForm()
        {
            InitializeComponent();
            User.UserLocationString(this);           
        }



        private void loginBTN_Click(object sender, EventArgs e)
        {
            int i = 0;

           /* MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from client_schedule.user where userName='" + usernameTB.Text + "' and password= '" + passwordTB.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());*/


            /*if (i == 0)
            {
                if (spanishRBTN.Checked is true)
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

                MainForm main = new MainForm(usernameTB.Text);
                addCustomerForm.userName = usernameTB.Text;
                main.Show();
                this.Hide();
                

                return;

            }*/

            User user = new User();
            user.CheckUser(usernameTB.Text, passwordTB.Text);

            MessageBox.Show("Welcome " + user.userName + "!");

            MainCustomerForm main = new MainCustomerForm();
            main.Show();
            this.Hide();
        }

        private void spanishRBTN_CheckedChanged(object sender, EventArgs e)
        {
            /*User.LoginTranslator(this);*/
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {            
            connstring = @"server=127.0.0.1; database=client_schedule; userid=sqlUser; password=Passw0rd!";
            cnn = new MySqlConnection(connstring);
            cnn.Open();
        }
    }
}
