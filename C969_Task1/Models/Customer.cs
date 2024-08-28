using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class Customer
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public int addressID { get; set; }
        public int active { get; set; }
        public string createdBy { get; set; }
        public string lastUpdateBy { get; set; }

        public static DataTable CustomerData = new DataTable();
        public Customer(int customerID, string customerName, int addressID, int active, string createdBy, string lastUpdateBy)
        {
            this.customerID = customerID;
            this.customerName = customerName;
            this.addressID = addressID;
            this.active = active;
            this.createdBy = createdBy;
            this.lastUpdateBy = lastUpdateBy;
        }

        public Customer()
        {
        }

        public static DataTable SimpleCustomerData()
        {
            DatabaseConnection db = new DatabaseConnection();

            CustomerData.Clear();

            string Query = "SELECT customerID, customerName, addressID, active FROM customer";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(CustomerData);

            return CustomerData;
        }

        public static DataTable FullCustomerList()
        {
            DatabaseConnection db = new DatabaseConnection();

            CustomerData.Clear();

            string Query = "SELECT * FROM customer";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(CustomerData);

            return CustomerData;    
        }

        public static void AddCustomer(Customer customer)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = "INSERT INTO customer (customerID, customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('" + customer.customerID + "', '" + customer.customerName + "', '" + customer.addressID + "', '" + customer.active + "', NOW(), '" + customer.createdBy + "', NOW(), '" + customer.lastUpdateBy + "')";

            db.DBCommand(Query).ExecuteNonQuery();
        }

        public static void UpdateCustomer(Customer customer)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = "UPDATE customer SET customerName = '" + customer.customerName + "', addressID = '" + customer.addressID + "', active = '" + customer.active + "', createDate = 'NOW()', createdBy = '" + customer.createdBy + "', lastUpdate = 'NOW()', lastUpdateBy = '" + customer.lastUpdateBy + "' WHERE customerID = '" + customer.customerID + "'";

            db.DBCommand(Query).ExecuteNonQuery();
        }

        public static void DeleteCustomer(int CustomerID)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = "DELETE FROM customer WHERE customerID = '" + CustomerID + "'";

            db.DBCommand(Query).ExecuteNonQuery();
        }

        public static int NewCustomerID()
        {
            DatabaseConnection db = new DatabaseConnection();

            int newCustomerID = 0;

            string query = "SELECT MAX(customerId) FROM customer";

            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                newCustomerID = Convert.ToInt32(rdr.GetValue(0)) + 1;
            }

            rdr.Close();

            return newCustomerID;
        }

        public static void RefreshData(DataTable table, System.Windows.Forms.DataGridView dataGridView)
        {

            dataGridView.DataSource = table;
        }
    }
}
