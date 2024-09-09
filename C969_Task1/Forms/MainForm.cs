using C969_Task1.Forms;
using C969_Task1.Forms.Customer;
using C969_Task1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace C969_Task1
{
    public partial class MainForm : Form
    {
        MainCustomerForm mainCustomer = new MainCustomerForm();
        MainAppointmentForm mainAppointment = new MainAppointmentForm();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Appointment.checkUserReminders(User.userID);
            label3.Text = $"Username: {User.userName}";      
            
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

            dataGridView1.DataSource = Appointment.AppointmentsByUser(User.userID);


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

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void customerBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            mainCustomer.Show();
        }

        private void appointmentBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            mainAppointment.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            CalendarAppointmentView calendar = new CalendarAppointmentView(e.Start.ToString("yyyy-MM-dd HH:mm:ss"), e.End.ToString("yyyy-MM-dd HH:mm:ss"));
            calendar.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string foldername = "DataFiles";
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, foldername);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = "login_History.txt";
            string filePath = Path.Combine(folderPath, fileName);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - {User.userName} - {User.userID} logged in";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
            {
                file.WriteLine(logEntry);
            }

            MessageBox.Show("Login history saved to C969_Task1\\bin\\Debug\\DataFiles\\login_History.txt", "Saved Successfully");
        }
    }
}
