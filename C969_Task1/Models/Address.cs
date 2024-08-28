using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class Address
    {
        public int addressID { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public int cityID { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }
        public string createdBy { get; set; }
        public string lastUpdateBy { get; set; }

        public Address(int addressID, string address, string address2, int cityID, string postalCode, string phone, string createdBy, string lastUpdateBy)
        {
            this.addressID = addressID;
            this.address = address;
            this.address2 = address2;
            this.cityID = cityID;
            this.postalCode = postalCode;
            this.phone = phone;
            this.createdBy = createdBy;
            this.lastUpdateBy = lastUpdateBy;
        }

        public Address()
        {
        }

        public static void AddAddress(Address address)
        {
            DatabaseConnection db = new DatabaseConnection();

            string query = "INSERT INTO address ( addressID, address, address2, cityID, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('" + address.addressID + "','" + address.address + "', '" + address.address2 + "', '" + address.cityID + "', '" + address.postalCode + "', '" + address.phone + "', now(), '" + address.createdBy + "', now(), '" + address.lastUpdateBy + "')";
            
            db.DBCommand(query).ExecuteNonQuery();

        }

        public static void UpdateAddress(Address address)
        {
            DatabaseConnection db = new DatabaseConnection();

            string query = "UPDATE address SET address = '" + address.address + "', address2 = '" + address.address2 + "', cityID = '" + address.cityID + "', postalCode = '" + address.postalCode + "', phone = '" + address.phone + "', createDate = now(), createdBy = '" + address.createdBy + "', lastUpdate = now(), lastUpdateBy = '" + address.lastUpdateBy + "' WHERE addressID = '" + address.addressID + "'";

            db.DBCommand(query).ExecuteNonQuery();
        }

        public static void DeleteAddress(int addressID)
        {
            DatabaseConnection db = new DatabaseConnection();

            string query = "DELETE FROM address WHERE addressID = '" + addressID + "'";

            db.DBCommand(query).ExecuteNonQuery();
        }

        public static int NewAddressID()
        {
            DatabaseConnection db = new DatabaseConnection();

            int newAddressID = 0;

            string query = "SELECT MAX(addressId) FROM address";

            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                newAddressID = Convert.ToInt32(rdr.GetValue(0)) + 1;
            }

            rdr.Close();

            return newAddressID;
        }
    }
}
