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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C969_Task1.Forms.Customer
{
    public partial class EditAppointment : Form
    {
        DatabaseConnection db = new DatabaseConnection(); 
        MainAppointmentForm mainAppointmentForm = new MainAppointmentForm();
        public int appointmentID { get; set; }

        public EditAppointment()
        {
            InitializeComponent();
        }

        public EditAppointment(int AppointmentId)
        {
            InitializeComponent();
            this.appointmentID = AppointmentId;
        }

        private void EditAppointment_Load(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM client_schedule.appointment where appointmentID = '{appointmentID}'";

            MySqlDataReader dr = db.DBCommand(query).ExecuteReader();

            while (dr.Read())
            {
                startDateTimePicker.Format = DateTimePickerFormat.Custom;
                startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";

                endDataTimePicker.Format = DateTimePickerFormat.Custom;
                endDataTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";

                customerIDTB.Text = (dr.GetValue(1).ToString());
                userIDTB.Text = dr.GetValue(2).ToString();
                titleTB.Text = dr.GetValue(3).ToString();
                descriptionTB.Text = dr.GetValue(4).ToString();
                locationTB.Text = dr.GetValue(5).ToString();
                typeTB.Text = dr.GetValue(6).ToString();
                contactTB.Text = dr.GetValue(7).ToString();
                urlTB.Text = dr.GetValue(8).ToString();
                startDateTimePicker.Value = Convert.ToDateTime(dr.GetValue(9));
                endDataTimePicker.Value = Convert.ToDateTime(dr.GetValue(10));
              
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Appointment appointmentToUpdate = new Appointment(appointmentID, int.Parse(customerIDTB.Text), int.Parse(userIDTB.Text), titleTB.Text, descriptionTB.Text, locationTB.Text, typeTB.Text, contactTB.Text, urlTB.Text, startDateTimePicker.Value, endDataTimePicker.Value);
            Appointment.UpdateAppointment(appointmentToUpdate);
            Appointment.RefreshData(Appointment.AppointmentsByUser(1), mainAppointmentForm.dataGridView1);

            this.Close();
            mainAppointmentForm.Show();
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            mainAppointmentForm.Show();
        }
    }
}
