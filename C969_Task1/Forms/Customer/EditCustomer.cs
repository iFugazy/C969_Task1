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
        MySqlConnection conn = new MySqlConnection("server=localhost; user=sqlUser; pwd=Passw0rd!; Database=client_schedule");
        MainCustomerForm main;
        public EditCustomer(MainCustomerForm mainCustomerForm)
        {
            InitializeComponent();
            this.main = mainCustomerForm;
            conn.Open();

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
            try
            {
                int num = main.dataGridView1.CurrentRow.Index + 1;
                string id = num.ToString() ;
                string updateQuery = "UPDATE client_schedule.customer SET customer.CustomerName = '" + textBox1.Text +"' WHERE customer.addressId = '" +id+  "'";
                string updateQuery2 = "UPDATE client_schedule.address SET address.address = '" + textBox2.Text + "', address.PostalCode = '" + textBox3.Text + "', address.Phone = '" + textBox4.Text + "' WHERE address.addressId = '" +id+ "'";
                MySqlCommand command = new MySqlCommand(updateQuery, conn);
                MySqlCommand command2 = new MySqlCommand(updateQuery2, conn);
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT \r\ncustomer.customerName as \"Customer Name\", \r\naddress.address as \"Address\",\r\naddress.PostalCode as \"Postal Code\",\r\naddress.Phone as \"Phone Number\"\r\n\r\nFROM client_schedule.address, client_schedule.customer\r\n\r\nWhere customer.addressId = address.addressId;", conn);
                DataSet ds = new DataSet();

                
                adapter.Fill(ds, "customer");
                main.dataGridView1.DataSource = ds.Tables["customer"];
                conn.Close();
            }
            
            
            

            
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
