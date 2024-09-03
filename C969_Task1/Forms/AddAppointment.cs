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

        /// <summary>
        /// Constructor used to initialize the form.
        /// </summary>
        public AddAppointment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the button is clicked, the appointment is checked to see if it overlaps with another appointment and if
        /// it is within business hours. If those are correct, the appointment is added to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            Appointment appointmentToAdd = new Appointment(Appointment.NewAppointmentID(), int.Parse(comboBox1.Text), User.userID, address2TB.Text, textBox1.Text, textBox3.Text, textBox4.Text,postalCodeTB.Text, textBox2.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            if (Appointment.WithinBusinessHours(appointmentToAdd))
            {
                if (Appointment.OverlappingAppointment(appointmentToAdd))
                {
                    Appointment.AddAppointment(appointmentToAdd);
                    dataGridView1.DataSource = Appointment.AppointmentsByUser(User.userID);

                }
                else
                {
                    MessageBox.Show("Appointment times overlap another appointment.");
                }
            }
            else
            {
                MessageBox.Show("Please schedule appoint within business hours (8AM - 5PM / M-F).");
            }
        }

        /// <summary>
        /// This button closes the form and opens the main appointment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MainAppointmentForm main = new MainAppointmentForm();
            main.Show();
        }

        /// <summary>
        /// This method is used to populate the combobox with the customer IDs 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            dataGridView1.DataSource = Appointment.AppointmentsByUser(User.userID);
            dataGridView2.DataSource = Models.Customer.SimpleCustomerData();
        }

        /// <summary>
        /// This method is used to populate the textboxes with the customer's address information when the combobox is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        /// <summary>
        /// This is used to close the form and open the main appointment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            MainAppointmentForm main = new MainAppointmentForm();
            main.Show();
        }
    }
}
