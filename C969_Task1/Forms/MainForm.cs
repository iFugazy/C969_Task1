using C969_Task1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1
{
    public partial class MainForm : Form
    {

        public string userName { get; set; }
        public MainForm(string username)
        {
            InitializeComponent();

            this.userName = username;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            label1.Text = $"Welcome {userName}!";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainCustomerForm addCustomerForm = new MainCustomerForm();
            addCustomerForm.Show();
        }
    }
}
