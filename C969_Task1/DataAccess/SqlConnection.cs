using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Task1.Forms;
using MySql.Data.MySqlClient;

namespace C969_Task1.Models
{
    public class SqlConnection
    {
        
        public string connstring;
        public MySqlConnection cnn;
        
        public SqlConnection() 
        {            
            connstring = @"server=127.0.0.1; database=client_schedule; userid=sqlUser; password=Passw0rd!";
            cnn = new MySqlConnection(connstring);
            cnn.Open();

        }

        public void LoginAuthentication(string username, string password, LoginForm loginForm, AddCustomerForm addCustomerForm)
        {
            int i = 0;
            

            
            MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from client_schedule.user where userName='"+username+"' and password= '"+password+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                if (loginForm.spanishRBTN.Checked is true)
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
                addCustomerForm.Show();
                loginForm.Hide();

                return;                                            
            }
        }
    }
}
