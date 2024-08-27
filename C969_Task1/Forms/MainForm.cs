using C969_Task1.Forms;
using C969_Task1.Models;
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

            dataGridView1.DataSource = Appointment.AppointmentsByWeek();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            //label1.Text = $"Welcome {userName}!";

            List<string> comboboxItems = new List<string>
            {
                "All",
                "By Week",
                "By Month",
                "By User"
            };


            foreach (var item in comboboxItems)
            {
                comboBox1.Items.Add(item);
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainCustomerForm addCustomerForm = new MainCustomerForm();
            addCustomerForm.Show();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All")
            {
                dataGridView1.DataSource = Appointment.AllAppointments();
            }
            else if (comboBox1.Text == "By Week")
            {
                dataGridView1.DataSource = Appointment.AppointmentsByWeek();
            }
            else if (comboBox1.Text == "By Month")
            {
                dataGridView1.DataSource = Appointment.AppointmentsByMonth();
            }
            else if (comboBox1.Text == "By User")
            {
                dataGridView1.DataSource = Appointment.AppointmentsByUser(User.userID);
            }
        }
    }
}
