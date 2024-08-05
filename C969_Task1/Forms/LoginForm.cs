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
        SqlConnection sqlConection = new SqlConnection();
        public LoginForm()
        {
            InitializeComponent();
            LoginModel.UserLocationString(this);
            
            
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            sqlConection.LoginAuthentication(usernameTB.Text,passwordTB.Text);
        }

        private void spanishRBTN_CheckedChanged(object sender, EventArgs e)
        {
            LoginModel.LoginTranslator(this);
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
