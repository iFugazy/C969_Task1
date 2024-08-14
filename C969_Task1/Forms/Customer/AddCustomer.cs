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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO client_schedule.customer(customerID, customerName, addressId, active, createDate, createdBy, lastUpdate ) VALUES('" + main.dataGridView1.RowCount + 1 + "','" + textBox1.Text + "','" + 1 + "','" + 1 + "','" + "admin" + "','" + DateTime.Now + "')";
            db.DBCommand(insertQuery);
        }

    }
}
    