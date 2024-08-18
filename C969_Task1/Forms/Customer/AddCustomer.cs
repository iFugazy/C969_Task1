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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            db.AddCustomer(
                dataGridView1.Rows.Count + 1,
                customerNameTB.Text,
                activeCB.Checked ? 1 : 0,
                address1TB.Text,
                address2TB.Text,
                postalCodeTB.Text,
                phoneNumberTB.Text);

            db.RefreshData(db.mainTableString, dataGridView1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main.Show();
        }
    }
}
    