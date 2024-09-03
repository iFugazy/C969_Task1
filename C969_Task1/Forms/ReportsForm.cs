using C969_Task1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Forms
{ 
    public partial class ReportsForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public int userID { get; set; }
        public ReportsForm()
        {
            InitializeComponent();

            List<string> list = new List<string>
            {               
                "Appointments by Type",
                "All User Schedules",
                "All Customers",
            };

            comboBox1.DataSource = list;
            comboBox2.Hide();
        }

        Func<DataTable> getAppointmentTypes = () =>
        {
            DatabaseConnection db = new DatabaseConnection();
            DataTable appointmentTypes = new DataTable();

            string qry = "SELECT MONTHNAME(start) as Month, type as Type, COUNT(*) as 'Total' FROM appointment GROUP BY type, Month;";

            MySqlDataAdapter adp = new MySqlDataAdapter(db.DBCommand(qry));
            adp.Fill(appointmentTypes);

            return appointmentTypes;
        };


        private void ReportsForm_Load(object sender, EventArgs e)
        {
            DataTable appointmentTypes = getAppointmentTypes();
            dataGridView2.DataSource = appointmentTypes;
        }


        Func<int, DataTable> getUserSchedules = (userId) =>
        {
            DatabaseConnection db = new DatabaseConnection();
            DataTable userSchedules = new DataTable();
         
            string qry = $"SELECT userName, start, end FROM appointment JOIN user ON appointment.userID = {userId};";

            MySqlDataAdapter adp = new MySqlDataAdapter(db.DBCommand(qry));
            adp.Fill(userSchedules);

            return userSchedules;
        };

        Func<DataTable> getAllCustomers = () =>
        {
            DatabaseConnection db = new DatabaseConnection();
            DataTable AllCustomers = new DataTable();

            string qry = "SELECT customerId, customerName FROM customer;";

            MySqlDataAdapter adp = new MySqlDataAdapter(db.DBCommand(qry));
            adp.Fill(AllCustomers);

            return AllCustomers;
        };



        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {

            if (comboBox1.Text == "All User Schedules")
            {
                comboBox2.Show();
                comboBox2.Items.Clear();

                string qry = "SELECT userName, userID FROM user;";
                
                MySqlDataReader rdr = db.DBCommand(qry).ExecuteReader();

                while(rdr.Read())
                {
                    userID = rdr.GetInt32(1);

                    string userid = rdr.GetValue(1).ToString();
                    string username = rdr.GetString(0);


                    comboBox2.Items.Add(userid + " - " + username );
                }

            }
            else if (comboBox1.Text == "Appointments by Type")
            {
                DataTable appointmentTypes = getAppointmentTypes();
                dataGridView2.DataSource = appointmentTypes;
                
                comboBox2.Items.Clear();
                comboBox2.Hide();
            }
            else if (comboBox1.Text == "All Customers")
            {
                DataTable AllCustomers = getAllCustomers();
                dataGridView2.DataSource = AllCustomers;
                
                comboBox2.Items.Clear();
                comboBox2.Hide();
            }

        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            DataTable userSchedules = getUserSchedules(User.userID);
            
            if (comboBox2.Text == null)
            {
                dataGridView2.DataSource = null;
            }
            else
            {
                dataGridView2.DataSource = userSchedules;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
