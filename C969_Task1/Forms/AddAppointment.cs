using C969_Task1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Forms.Customer
{
    public partial class AddAppointment : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public AddAppointment()
        {
            InitializeComponent();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Appointment appointmentToAdd = new Appointment(Appointment.NewAppointmentID(), int.Parse(comboBox1.Text), User.userID, address2TB.Text, textBox1.Text, textBox3.Text, textBox4.Text,postalCodeTB.Text, textBox2.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            if(Appointment.OverlappingAppointment(appointmentToAdd) == true)
            {
                MessageBox.Show("Appointment overlaps with another appointment. Please select a different time.");
                return;
            }
            else if(Appointment.WithinBusinessHours(appointmentToAdd) == true)
            {
                MessageBox.Show("Appointment is outside of business hours. Please select a different time.");
                return;
            }
            else
            {
                Appointment.AddAppointment(appointmentToAdd);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Appointment.NewAppointmentID().ToString());
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM client_schedule.customer";

            MySqlDataReader dr = db.DBCommand(query).ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue(0).ToString());

            }

            address1TB.Text = "1";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm tt";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm tt";

            //Add data to datagrids
            //CHANGE TO ACTUAL LOGGED IN USER
            dataGridView1.DataSource = Appointment.AppointmentsByUser(1);
            dataGridView2.DataSource = Models.Customer.SimpleCustomerData();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
