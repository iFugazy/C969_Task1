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
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm tt";

                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm tt";

                textBox5.Text = (dr.GetValue(1).ToString());
                address1TB.Text = dr.GetValue(2).ToString();
                address2TB.Text = dr.GetValue(3).ToString();
                textBox1.Text = dr.GetValue(4).ToString();
                textBox3.Text = dr.GetValue(5).ToString();
                textBox4.Text = dr.GetValue(6).ToString();
                postalCodeTB.Text = dr.GetValue(7).ToString();
                textBox2.Text = dr.GetValue(8).ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr.GetValue(9));
                dateTimePicker2.Value = Convert.ToDateTime(dr.GetValue(10));

               

            }
        }
    }
}
