using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class Country
    {
        List<String> countries = new List<String>();
        public string enteredCountry { get; set; }
        DatabaseConnection db = new DatabaseConnection();


        public Country(string enteredCountry)
        {
            this.enteredCountry = enteredCountry;

            string query = "SELECT * FROM country";
            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                countries.Add(rdr.GetValue(1).ToString());
            }
        }

        public void CheckCountries()
        {

            foreach (string country in countries)
            {
                if (enteredCountry == country)
                {
                    break;
                }
                else
                {
                    AddCountry();
                    return;

                }
            }
        }

        public int GetCountryID()
        {
            string query = $"SELECT countryID FROM country WHERE country = '{enteredCountry}'";
            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                return Convert.ToInt32(rdr.GetValue(0));
            }
            else
            {
                return 0;
            }

        }

        public void AddCountry()
        {
            string query = $"INSERT INTO country (countryId, country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{NewCountryID()}','{enteredCountry}', now(), '{User.userName}', now(), '{User.userName}')";
            db.DBCommand(query).ExecuteNonQuery();
        }

        public int NewCountryID()
        {
            int newCountryID = 0;

            string query = "SELECT MAX(cityId) FROM city";

            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                newCountryID = Convert.ToInt32(rdr.GetValue(0)) + 1;
            }

            rdr.Close();


            return newCountryID;
        }
    }
}
