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

namespace C969_Task1
{
    public partial class LoginForm : Form
    {
        SqlConnection sqlConection = new SqlConnection();
        AddCustomerForm addCustomerForm = new AddCustomerForm();
        public LoginForm()
        {
            InitializeComponent();
            LoginModel.UserLocationString(this);
            
            
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {

            sqlConection.LoginAuthentication(usernameTB.Text,passwordTB.Text, this, addCustomerForm);
            
            
           
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
