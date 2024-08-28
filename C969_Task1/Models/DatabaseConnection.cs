using C969_Task1.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Models
{
    public class DatabaseConnection
    {
        //public string connstring = "datasource=127.0.0.1; port=3306; Username=root; Password=Giants12!";
        public string connstring = "server=localhost; user=sqlUser; pwd=Passw0rd!; Database=client_schedule";

        public string mainTableString = "SELECT customer.customerID as \"Customer ID\",\r\ncustomer.customerName as \"Customer Name\",\r\ncustomer.active as \"Active\", \r\naddress.address as \"Address 1\", \r\naddress.address2 as \"Address 2\",\r\naddress.PostalCode as \"Postal Code\",\r\naddress.Phone as \"Phone Number\"\r\n\r\nFROM client_schedule.address, client_schedule.customer\r\n\r\nWhere customer.addressId = address.addressId;";

        public MySqlConnection GetConnection()
        {
            MySqlConnection cnn = new MySqlConnection(connstring);
            //MySqlConnection conn = new MySqlConnection(connstring)

            return cnn;
        }

        public static DataTable MainCustomerData()
        {
            DatabaseConnection db = new DatabaseConnection();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.mainTableString, db.connstring);

            adapter.Fill(dt);

            return dt;
        }


        public void OpenConnection()
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
        }

        public void CloseConnection()
        {
            MySqlConnection conn = GetConnection();
            conn.Close();
        }

        public MySqlCommand DBCommand(string query)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();



            return command;
        }

        public void RefreshData(string dataQuery, DataGridView dataGridView)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(dataQuery, connstring);
            DataSet ds = new DataSet();
            MySqlConnection conn = GetConnection();
            conn.Open();
            adapter.Fill(ds, "customer");
            dataGridView.DataSource = ds.Tables["customer"];
            conn.Close();

        }

        //Delete Functions

        /// <summary>
        /// Deletes a customer from the database and refreshes the data grid view to show the changes
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public void DeleteCustomer(string column, string value)
        {
            List<string> Query = new List<string>
            {
                "DELETE FROM client_schedule.customer WHERE " + column + " = '" + value + "'",
                "DELETE FROM client_schedule.address WHERE addressId = '" + value + "'",
                "DELETE FROM client_schedule.appointment WHERE " + column + " = '" + value + "'"
            };

            MySqlConnection conn = GetConnection();
            conn.Open();
            foreach (string query in Query)
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// Adds a customer to the database and refreshes the data grid view to show the changes
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="customerName"></param>
        /// <param name="AddressID"></param>
        /// <param name="active"></param>
        /// <param name="createDate"></param>
        /// <param name="createdBy"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="lastUpdateBy"></param>
        public void AddCustomer(int customerID, string customerName, int active, string address1, string address2, string cityId, string postal, string number)
        {
            MainCustomerForm main = new MainCustomerForm();

            List<string> Query = new List<string>
            {
                $"INSERT INTO client_schedule.address VALUES('" + customerID.ToString() + "','" + address1 + "' ,'" + address2 + "', '" + cityId +"', '" + postal + "', '" + number +"', now(), '" + User.userName + "', now(), '" + User.userName + "')",
                "INSERT INTO client_schedule.customer VALUES('" + customerID.ToString() + "', '" + customerName + "', '" + customerID.ToString() + "', '" + active + "', current_date(), '" + User.userName + "', current_date(), '" + User.userName + "')"
            };

            MySqlConnection conn = GetConnection();
            conn.Open();
            foreach (string query in Query)
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }

        }
    }
}