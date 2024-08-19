using C969_Task1.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
        DatabaseConnection db = new DatabaseConnection();
        MainCustomerForm main;
        public EditCustomer(MainCustomerForm mainCustomerForm)
        {
            InitializeComponent();
            this.main = mainCustomerForm;
            db.OpenConnection();

        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            customerIDTB.Text = main.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            customerNameTB.Text = main.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            activeCB.Checked = Convert.ToBoolean(main.dataGridView1.CurrentRow.Cells[2].Value);
            address1TB.Text = main.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            address2TB.Text = main.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            postalCodeTB.Text = main.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            phoneNumberTB.Text = main.dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = main.dataGridView1.CurrentRow.Index + 1;
                string id = num.ToString();
                int active = activeCB.Checked ? 1 : 0;

                List<string> updateQuery = new List<string>
                {
                    "UPDATE client_schedule.customer SET customerName = '" + customerNameTB.Text + "', active = '" + active.ToString() + "' WHERE(customerId = '" + id + "')",
                    "UPDATE client_schedule.address SET address.address = '" + address1TB.Text + "', address.address2 = '" + address2TB.Text + "', address.PostalCode = '" + postalCodeTB.Text + "', address.Phone = '" + phoneNumberTB.Text + "' WHERE address.addressId = '" + id + "'"
                };
               
                foreach(String query in updateQuery)
                {
                    db.DBCommand(query).ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.RefreshData(db.mainTableString, main.dataGridView1);
            }
            
            
            

            
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
