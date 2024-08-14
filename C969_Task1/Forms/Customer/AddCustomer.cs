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
        MySqlConnection conn = new MySqlConnection("server=localhost; user=sqlUser; pwd=Passw0rd!; Database=client_schedule");
        MainCustomerForm main = new MainCustomerForm();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO client_schedule.customer(customerID, customerName, addressId, active, createDate, createdBy, lastUpdate ) VALUES('" + main.dataGridView1.RowCount + 1 + "','" + textBox1.Text + "','" + 1 + "','" + 1 + "','" + DateTime.Now + "','" + "admin" + "','" + DateTime.Now + "')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

    }
}
