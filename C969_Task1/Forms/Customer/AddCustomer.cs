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
    public partial class AddCustomer : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        MainCustomerForm main = new MainCustomerForm();

        public AddCustomer()
        {
            InitializeComponent();
            db.RefreshData(db.mainTableString, dataGridView1);
            address1TB.BackColor = Color.IndianRed;
            customerNameTB.BackColor = Color.IndianRed;
            phoneNumberTB.BackColor = Color.IndianRed;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (customerNameTB.Text == "" || address1TB.Text == "" || phoneNumberTB.Text == "")
            {
                MessageBox.Show("Please fill out all required fields", "Error");
                return;
            }

            db.AddCustomer(
                dataGridView1.Rows.Count + 1,
                customerNameTB.Text,
                activeCB.Checked ? 1 : 0,
                address1TB.Text,
                address2TB.Text,
                postalCodeTB.Text,
                phoneNumberTB.Text);

            db.RefreshData(db.mainTableString, dataGridView1);
*/
            City city = new City(cityCB.Text);
            city.AddCity();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void customerNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            customerNameTB.BackColor = Color.White;
        }

        private void address1TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            customerNameTB.BackColor = Color.White;

        }

        private void phoneNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            customerNameTB.BackColor = Color.White;

        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM client_schedule.city";
            string query2 = "SELECT * FROM client_schedule.country";
     
            MySqlDataReader dr = db.DBCommand(query).ExecuteReader();
            MySqlDataReader dr2 = db.DBCommand(query2).ExecuteReader();

            while (dr.Read())
            {
                cityCB.Items.Add(dr.GetValue(1).ToString());
                
            }

            while (dr2.Read())
            {
                countryCB.Items.Add(dr2.GetValue(1).ToString());
            }
        }
    }
}
    