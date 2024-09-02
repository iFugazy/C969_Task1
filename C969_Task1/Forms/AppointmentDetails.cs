using C969_Task1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace C969_Task1.Forms.Customer
{
    public partial class AppointmentDetails : Form
    {
        public string appointmentID { get; set; }
        public string userID { get; set; }
        public string customerID { get; set; }
        public AppointmentDetails(string AppointmentID, string UserID, string CustomerID)
        {
            InitializeComponent();
            this.appointmentID = AppointmentID;
            this.userID = UserID;
            this.customerID = CustomerID;
        }

        private void AppointmentDetails_Load(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            string appointmentquery = $"SELECT * FROM client_schedule.appointment where appointmentID = '{appointmentID}'";
            string userquery = $"SELECT * FROM client_schedule.User where userID = '{userID}'";
            string customerquery = $"SELECT * FROM client_schedule.Customer where CustomerID = '{customerID}'";

            MySqlDataReader drAppointment = db.DBCommand(appointmentquery).ExecuteReader();
            MySqlDataReader drUser = db.DBCommand(userquery).ExecuteReader();
            MySqlDataReader drCustomer = db.DBCommand(customerquery).ExecuteReader();

            while (drAppointment.Read())
            {
                DateTime startdateTime = (DateTime)drAppointment.GetValue(9);
                DateTime enddateTime = (DateTime)drAppointment.GetValue(10);

                appointmentIDTB.Text = drAppointment.GetValue(0).ToString();
                appointmentTitleTB.Text = drAppointment.GetValue(3).ToString();
                appointmentDescriptionTB.Text = drAppointment.GetValue(4).ToString();
                appointmentLocationTB.Text = drAppointment.GetValue(5).ToString();
                appointmentTypeTB.Text = drAppointment.GetValue(7).ToString();
                appointmentContactTB.Text = drAppointment.GetValue(6).ToString();
                appointmentURLTB.Text = drAppointment.GetValue(8).ToString();
                appointmentStartTB.Text = startdateTime.ToLocalTime().ToString();
                appointmentEndTB.Text = enddateTime.ToLocalTime().ToString();
                appointmentCreateTB.Text = drAppointment.GetValue(11).ToString();
                appointmentCreatedTB.Text = drAppointment.GetValue(12).ToString();
                appointmentUpdateTB.Text = drAppointment.GetValue(13).ToString();
                appointmentUpdatedTB.Text = drAppointment.GetValue(14).ToString();

            }

            while (drUser.Read())
            {
                userIDTB.Text = drUser.GetValue(0).ToString();
                userNameTB.Text = drUser.GetValue(1).ToString();
            }

            while (drCustomer.Read())
            {
                customerIDTB.Text = drCustomer.GetValue(0).ToString();
                customerNameTB.Text = drCustomer.GetValue(1).ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
