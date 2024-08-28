using C969_Task1.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            postalCodeTB.BackColor = Color.IndianRed;
            customerNameTB.BackColor = Color.IndianRed;
            phoneNumberTB.BackColor = Color.IndianRed;
            cityCB.BackColor = Color.IndianRed;
            countryCB.BackColor = Color.IndianRed;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            City city = new City(cityCB.Text, countryCB.Text);
            int addressID = Address.NewAddressID();

            if (customerNameTB.Text == "" || address1TB.Text == "" || phoneNumberTB.Text == "")
            {
                MessageBox.Show("Please fill out all required fields", "Error");
                return;
            }

            try
            {
                Address address = new Address(addressID, address1TB.Text, address2TB.Text, city.CheckCities(), postalCodeTB.Text, phoneNumberTB.Text, User.userName, User.userName);
                Address.AddAddress(address);
            }
            catch { }

            try
            {
                Models.Customer customer = new Models.Customer(Models.Customer.NewCustomerID(), customerNameTB.Text, addressID, activeCB.Checked ? 1 : 0, User.userName, User.userName);
                Models.Customer.AddCustomer(customer);
            }
            catch { }

            

            db.RefreshData(db.mainTableString, dataGridView1);




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
            address1TB.BackColor = Color.White;

        }
        private void postalCodeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            postalCodeTB.BackColor = Color.White;
        }

        private void phoneNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9-\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            phoneNumberTB.BackColor = Color.White;

        }


        private void cityCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            cityCB.BackColor = Color.White;
        }

        private void cityCB_Leave(object sender, EventArgs e)
        {
            if (cityCB.Text == "")
            {
                cityCB.BackColor = Color.IndianRed;
            }
        }

        private void countryCB_Leave(object sender, EventArgs e)
        {
            if (countryCB.Text == "")
            {
                countryCB.BackColor = Color.IndianRed;
            }
        }

        private void countryCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            countryCB.BackColor = Color.White;
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
