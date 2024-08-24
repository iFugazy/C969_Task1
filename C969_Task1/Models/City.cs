using C969_Task1.Forms.Customer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Models
{
    public class City
    {
        List<String> cities = new List<String>();
        public string enteredCity { get; set; }
        AddCustomer addCustomer = new AddCustomer();
        DatabaseConnection db = new DatabaseConnection();
        public City(string enteredCity) 
        {
            this.enteredCity = enteredCity;

            string query = "SELECT * FROM city";
            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                cities.Add(rdr.GetValue(1).ToString());
            }
        }

        public void CheckCities()
        {
            
            foreach (string city in cities)
            {
               if (enteredCity == city)
                {
                    MessageBox.Show("City already exists");
                    return;
                }
                else
                {
                    AddCity;
                   
                }


            }
        }

        public int GetCityID()
        {
            string query = $"SELECT cityID FROM city WHERE city = '{enteredCity}'";
            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            rdr.Read();
            if(rdr.HasRows)
            {
                return Convert.ToInt32(rdr.GetValue(0));
            }
            else
            {
                return 0;
            }
            
        }

        public void AddCity()
        {
            string query = $"INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{NewCityID()}','{enteredCity}', 1, '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{User.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{User.userName}')";
            try
            {
                db.DBCommand(query).ExecuteNonQuery();

            }
            catch 
            {
                
            }
        }

        public int NewCityID()
        {

            int newAddressID = 0;

            string query = "SELECT MAX(cityId) FROM city";

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
