using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Task1.Forms.Customer;
using C969_Task1.Models;
using MySql.Data.MySqlClient;

namespace C969_Task1.Forms
{
    public partial class MainCustomerForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public string userName { get; set; }
        public static int customerID { get; set; }


        public MainCustomerForm()
        {
            InitializeComponent();
            
           

        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            
           
            db.RefreshData(db.mainTableString, dataGridView1);
            

        }

        /// <summary>
        /// Deletes a customer from the database and refreshes the data grid view to show the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you would like to delete these customers?", "Delete Customers", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow drv in dataGridView1.SelectedRows)
                    {
                        db.DeleteCustomer("customerID", drv.Cells[0].Value.ToString());
                        db.RefreshData(db.mainTableString, dataGridView1);
                        return;

                    }
                }
                
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you would like to delete this customer?", "Delete Customer", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                {
                    db.DeleteCustomer("customerID", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    db.RefreshData(db.mainTableString, dataGridView1);
                    return;
                }
            }
            
        }

        private void editBTN_Click(object sender, EventArgs e)
        {
            customerID = GetCustomerID();
            EditCustomer editCustomer = new EditCustomer(customerID);
            if(dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please only select one row", "Too many rows are selected");
            }
            else
            {
                this.Hide();
                editCustomer.Show();
                
            }
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
            this.Hide();
        }

        public int GetCustomerID()
        {
            int id = 0;
            db.OpenConnection();
            string query = "SELECT customerID FROM client_schedule.customer";
            MySqlDataReader dr = db.DBCommand(query).ExecuteReader();
            while (dr.Read())
            {
                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == dr.GetValue(0).ToString())
                {
                   
                    id = int.Parse(dr.GetValue(0).ToString());
                }
            }
            db.CloseConnection();
            return id;
        }

        public int GetRowCount()
        {
            return dataGridView1.Rows.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
