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
    public partial class EditCustomer : Form
    {
        MySqlConnection cnn = new MySqlConnection("datasource=127.0.0.1; port=3306; Username=sqlUser; Password=Passw0rd!");

        MainCustomerForm main;
        public EditCustomer(MainCustomerForm mainCustomerForm)
        {
            InitializeComponent();
            this.main = mainCustomerForm;
            cnn.Open();
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            textBox1.Text = main.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = main.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = main.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = main.dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = main.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string updateQuery = "UPDATE client_schedule.address, client_schedule.customer SET customer.CustomerName = '" + textBox1.Text + "', address.address = '" + textBox2.Text + "', address.PostalCode = '" + textBox3.Text + "', address.Phone = '" + textBox4.Text + "' WHERE customer.CustomerName = '" + id + "'";
            
           
            MySqlCommand command = new MySqlCommand(updateQuery, cnn);

            this.Close();
            MySqlDataReader reader = command.ExecuteReader();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
