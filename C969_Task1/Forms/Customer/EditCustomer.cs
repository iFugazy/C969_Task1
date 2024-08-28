using C969_Task1.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace C969_Task1.Forms.Customer
{
    public partial class EditCustomer : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        MainCustomerForm main = new MainCustomerForm();
        public int CustomerID { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public EditCustomer(int CustomerID)
        {
            InitializeComponent();
            this.CustomerID = CustomerID;
           

        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            string customerQuery = $"SELECT * FROM client_schedule.customer where customerID = '{CustomerID}'";
            string addressQuery = $"SELECT * FROM client_schedule.address where addressId = '{CustomerID}'";
            MySqlDataReader drCustomer = db.DBCommand(customerQuery).ExecuteReader();
            MySqlDataReader drAddress = db.DBCommand(addressQuery).ExecuteReader();

            while (drCustomer.Read())
            {
                customerNameTB.Text = (drCustomer.GetValue(1).ToString());
                activeCB.Checked = Convert.ToBoolean(drCustomer.GetValue(3).ToString());
                

            }

            while (drAddress.Read())
            {
                // cityCB.Text = main.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                //countryCB.Text = main.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                address1TB.Text = (drAddress.GetValue(1).ToString());
                address2TB.Text = (drAddress.GetValue(2).ToString());
                postalCodeTB.Text = (drAddress.GetValue(4).ToString());        
                phoneNumberTB.Text = (drAddress.GetValue(5).ToString());   
                this.CityID = drAddress.GetInt32(3);
            }

            string cityQuery = $"SELECT * FROM client_schedule.city where cityId = '{CityID}'";
            MySqlDataReader drCity = db.DBCommand(cityQuery).ExecuteReader();
            while (drCity.Read())
            {
                cityCB.Text = drCity.GetValue(1).ToString();
                this.CountryID = drCity.GetInt32(2);
            }

            string countryQuery = $"SELECT * FROM client_schedule.country where countryId = '{CountryID}'";
            MySqlDataReader drCountry = db.DBCommand(countryQuery).ExecuteReader();
            while (drCountry.Read())
            {
                countryCB.Text = drCountry.GetValue(1).ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
           
            if (customerNameTB.Text == "" || address1TB.Text == "" || postalCodeTB.Text == "" || phoneNumberTB.Text == "" || cityCB.Text == "" || countryCB.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Missing Fields");
                return;
            }

            City city = new City(cityCB.Text, countryCB.Text);
            Models.Customer customer = new Models.Customer(CustomerID, customerNameTB.Text, CustomerID, activeCB.Checked ? 1 : 0, User.userName, User.userName);
            Address address = new Address(CustomerID, address1TB.Text, address2TB.Text, city.CheckCities(), postalCodeTB.Text, phoneNumberTB.Text, User.userName, User.userName);

            Address.UpdateAddress(address);
            Models.Customer.UpdateCustomer(customer);  
            
            Appointment.RefreshData(DatabaseConnection.MainCustomerData(), main.dataGridView1);  

            this.Close();
            main.Show();
        }


        private void phoneNumberTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9-\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }


        }

        private void cityCB_Leave(object sender, EventArgs e)
        {
            if (cityCB.Text == "")
            {
                cityCB.BackColor = Color.IndianRed;
            }
            else
            {
                cityCB.BackColor = Color.White;
            }
        }

        private void countryCB_Leave(object sender, EventArgs e)
        {
            if (countryCB.Text == "")
            {
                countryCB.BackColor = Color.IndianRed;
            }
            else
            {
                countryCB.BackColor = Color.White;
            }
        }

        private void customerNameTB_Leave(object sender, EventArgs e)
        {
            if (customerNameTB.Text == "")
            {
                customerNameTB.BackColor = Color.IndianRed;
            }
            else
            {
                customerNameTB.BackColor = Color.White;
            }
        }

        private void address1TB_Leave(object sender, EventArgs e)
        {
            if (address1TB.Text == "")
            {
                address1TB.BackColor = Color.IndianRed;
            }
            else
            {
                address1TB.BackColor = Color.White;
            }
        }

        private void postalCodeTB_Leave(object sender, EventArgs e)
        {
            if (postalCodeTB.Text == "")
            {
                postalCodeTB.BackColor = Color.IndianRed;
            }
            else
            {
                postalCodeTB.BackColor = Color.White;
            }
        }

        private void phoneNumberTB_Leave(object sender, EventArgs e)
        {
            if (phoneNumberTB.Text == "")
            {
                phoneNumberTB.BackColor = Color.IndianRed;
            }
            else
            {
                phoneNumberTB.BackColor = Color.White;
            }
        }
    }
}
