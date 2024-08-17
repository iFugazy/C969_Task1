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
        public string connstring = "datasource=127.0.0.1; port=3306; Username=root; Password=Giants12!";
        //public string connstring = "server=localhost; user=sqlUser; pwd=Passw0rd!; Database=client_schedule";

        public string mainTableString = "SELECT customer.customerID as \"Customer ID\",\r\ncustomer.customerName as \"Customer Name\", \r\naddress.address as \"Address\",\r\naddress.PostalCode as \"Postal Code\",\r\naddress.Phone as \"Phone Number\"\r\n\r\nFROM client_schedule.address, client_schedule.customer\r\n\r\nWhere customer.addressId = address.addressId;";


        public MySqlConnection GetConnection()
        {
            MySqlConnection cnn = new MySqlConnection(connstring);
            //MySqlConnection conn = new MySqlConnection(connstring)

            return cnn;
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

        public void DeleteCustomer(string column, string value)
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            string deleteCustomerQuery = "DELETE FROM client_schedule.customer WHERE customerId = '" + value + "'";
            string deleteAddressQuery = "DELETE FROM client_schedule.address WHERE addressId = '" + value + "'";
            string deleteAppointmentQuery = "DELETE FROM client_schedule.appointment WHERE customerId = '" + value + "'";
            MySqlCommand command = new MySqlCommand(deleteCustomerQuery, conn);
            MySqlCommand command2 = new MySqlCommand(deleteAddressQuery, conn);
            MySqlCommand command3 = new MySqlCommand(deleteAppointmentQuery, conn);
            command3.ExecuteNonQuery();

            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
        }

        public void AddCustomer( string customerID, string customerName, string AddressID, bool active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy )
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            string insertQuery = "INSERT INTO client_schedule.customer VALUES('" + customerID + "', '" + customerName+ "', '" + AddressID + "', '" + active + "', '" + createDate + "', '" + createdBy + "', '" + lastUpdate + "', '" + lastUpdateBy + "')";
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            command.ExecuteNonQuery();
            
        }
    }
}
