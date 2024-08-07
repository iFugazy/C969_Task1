using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969_Task1.Forms
{
    public partial class MainCustomerForm : Form
    {

        

        public MainCustomerForm()
        {
            InitializeComponent();
                     
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("datasource=127.0.0.1; port=3306; Username=sqlUser; Password=Passw0rd!");
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT \r\ncustomer.customerName as \"Customer Name\", \r\naddress.address as \"Address\",\r\naddress.PostalCode as \"Postal Code\",\r\naddress.Phone as \"Phone Number\"\r\n\r\nFROM client_schedule.address, client_schedule.customer\r\n\r\nWhere customer.addressId = address.addressId;", cnn);
            DataSet ds = new DataSet();

            cnn.Open();
            adapter.Fill(ds, "customer");
            dataGridView1.DataSource = ds.Tables["customer"];
            cnn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {     
            //textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            
        }
    }
}
