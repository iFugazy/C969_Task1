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

            SqlConnection sqlConnection = new SqlConnection();
            
            try
            {
                sqlConnection.cnn.Open();
                MessageBox.Show("It still works");
                sqlConnection.cnn.Close();
            }
            catch
            {
                MessageBox.Show("No connection");
            }
        }


    }
}
