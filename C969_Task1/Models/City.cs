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
        public string enteredCountry { get; set; }  
        
        AddCustomer addCustomer = new AddCustomer();
        DatabaseConnection db = new DatabaseConnection();
        public City(string enteredCity, string enteredCountry)
        {
            this.enteredCity = enteredCity;
            this.enteredCountry = enteredCountry;
  
            Country country = new Country(enteredCountry);
            string query = "SELECT * FROM city";
            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                cities.Add(rdr.GetValue(1).ToString());
            }
        }

        public int CheckCities()
        {

            foreach (string city in cities)
            {
                if (enteredCity == city)
                {
                    
                    return GetCityID();
                }

            }
            int cityID = NewCityID();
            AddCity();
            return cityID;
        }

        public int GetCityID()
        {

            string query = $"SELECT cityID FROM city WHERE city = '{enteredCity}'";
            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                return Convert.ToInt32(rdr.GetValue(0));
            }

            return 0;




        }

        public void AddCity()
        {
            
            Country country = new Country(enteredCountry);
            string query = $"INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{NewCityID()}','{enteredCity}', '{country.CheckCountries()}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{User.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{User.userName}')";
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

            int newCityID = 0;

            string query = "SELECT MAX(cityId) FROM city";

            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                newCityID = Convert.ToInt32(rdr.GetValue(0)) + 1;
            }

            rdr.Close();
            
            return newCityID;
        }


    }
}
