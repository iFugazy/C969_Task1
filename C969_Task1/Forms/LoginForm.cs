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

namespace C969_Task1
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
            UserLocation.UserLocationString(this);

            string connstring = null;
            MySqlConnection cnn;

            connstring = @"server=127.0.0.1; database=client_schedule; userid=sqlUser; password=Passw0rd!";
            cnn = new MySqlConnection(connstring);

            try
            {
                cnn.Open();
                string query = "SELECT * FROM address;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "address");
                DataTable dt = ds.Tables["address"];

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        MessageBox.Show(row[col] + "\t");
                    }

                    MessageBox.Show("\n");
                }
            }
            catch
            {
                MessageBox.Show("No connection");
            }
        }


    }
}
