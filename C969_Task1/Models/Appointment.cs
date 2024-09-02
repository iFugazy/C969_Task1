﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class Appointment
    {
        public int appointmentID { get; set; }
        public int customerID { get; set; }
        public int userID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string url { get; set; }
        public string Type { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }


        public static DataTable appointmentInfo = new DataTable();
        public static DataTable userAppointmentInfo = new DataTable();
        public static DataTable calendarAppointmentInfo = new DataTable();


        public Appointment(int appointmentID, int customerID, int userID, string title, string description, string location, string Type,string contact, string url, DateTime start, DateTime end)
        {
            this.appointmentID = appointmentID;
            this.customerID = customerID;
            this.userID = userID;
            this.title = title;
            this.description = description;
            this.contact = contact;
            this.url = url;
            this.start = start;
            this.end = end;
            this.location = location;
            this.Type = Type;
         
        }

        public Appointment()
        {
        }

        public static DateTime dateToHighlight()
        {
            DatabaseConnection db = new DatabaseConnection();
            string Query = "SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment";
            MySqlDataReader rdr = db.DBCommand(Query).ExecuteReader();
            DateTime date = new DateTime();
            while (rdr.Read())
            {
                date = Convert.ToDateTime(rdr["start"]);
            }
            return date;

        }
        public static DataTable AllAppointments()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            foreach (DataRow row in appointmentInfo.Rows)
            {

                DateTime start = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();
            }

            return appointmentInfo;
        }

        public static DataTable AppointmentsByMonth()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title,type, description, contact, url, start, end FROM appointment WHERE MONTH(start) = MONTH(CURRENT_DATE())";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            foreach (DataRow row in appointmentInfo.Rows)
            {

                DateTime start = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();
            }

            return appointmentInfo;
        }

        public static DataTable AppointmentsByWeek()
        {
            DatabaseConnection db = new DatabaseConnection();

            appointmentInfo.Clear();

            string Query = "SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment WHERE WEEK(start) = WEEK(CURRENT_DATE())";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(appointmentInfo);

            foreach (DataRow row in appointmentInfo.Rows)
            {

                DateTime start = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentInfo.Rows[0]["start"];
                appointmentInfo.Rows[0]["start"] = start.ToLocalTime();
            }

            return appointmentInfo;
        }

        public static DataTable AppointmentsByUser(int userID)
        {
            DatabaseConnection db = new DatabaseConnection();

            userAppointmentInfo.Clear();

            string Query = $"SELECT appointmentID, customerID, userID, title, type, description, location, contact, url, start, end FROM appointment WHERE userID = {userID}";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(userAppointmentInfo);

            foreach (DataRow row in userAppointmentInfo.Rows)
            {

                DateTime start = (DateTime)userAppointmentInfo.Rows[0]["start"];
                userAppointmentInfo.Rows[0]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)userAppointmentInfo.Rows[0]["start"];
                userAppointmentInfo.Rows[0]["start"] = start.ToLocalTime();
            }

            return userAppointmentInfo;
        }

        public static DataTable AppointmentsByCalendar(string selectedDate)
        {
            DatabaseConnection db = new DatabaseConnection();

            calendarAppointmentInfo.Clear();

            string Query = $"SELECT appointmentID, customerID, userID, title, type, description, contact, url, start, end FROM appointment WHERE start = '{selectedDate}'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(db.DBCommand(Query));

            adapter.Fill(calendarAppointmentInfo);

            foreach (DataRow row in calendarAppointmentInfo.Rows)
            {

                DateTime start = (DateTime)calendarAppointmentInfo.Rows[0]["start"];
                calendarAppointmentInfo.Rows[0]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)calendarAppointmentInfo.Rows[0]["end"];
                calendarAppointmentInfo.Rows[0]["end"] = end.ToLocalTime();
            }

            return calendarAppointmentInfo;
        }




        public static void AddAppointment(Appointment appointment)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = $"INSERT INTO appointment (appointmentID, customerID, userID, title, description, location, type, contact, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy ) VALUES ({appointment.appointmentID},{appointment.customerID}, {appointment.userID}, '{appointment.title}', '{appointment.description}', '{appointment.location}', '{appointment.Type}', '{appointment.contact}', '{appointment.url}', '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', Now(), 'test', Now(), 'test')";

            db.DBCommand(Query);
        }

        public static void UpdateAppointment(Appointment appointment)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = $"UPDATE appointment SET customerID = {appointment.customerID}, userID = {appointment.userID}, title = '{appointment.title}', description = '{appointment.description}', contact = '{appointment.contact}', url = '{appointment.url}', start = '{appointment.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', end = '{appointment.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' WHERE appointmentID = {appointment.appointmentID}";

            db.DBCommand(Query);
        }

        public static void DeleteAppointment(int appointmentID)
        {
            DatabaseConnection db = new DatabaseConnection();

            string Query = $"DELETE FROM appointment WHERE appointmentID = {appointmentID}";

            db.DBCommand(Query);


        }

        public static int NewAppointmentID()
        {
            DatabaseConnection db = new DatabaseConnection();

            int newAppointmentID = 0;

            string query = "SELECT MAX(appointmentId) FROM appointment";

            MySqlDataReader rdr = db.DBCommand(query).ExecuteReader();
            while (rdr.Read())
            {
                newAppointmentID = Convert.ToInt32(rdr.GetValue(0)) + 1;
            }

            rdr.Close();

            return newAppointmentID;

        }

        public static void RefreshData(DataTable table, System.Windows.Forms.DataGridView dataGridView)
        {

            dataGridView.DataSource = table;
        }

    }
}
