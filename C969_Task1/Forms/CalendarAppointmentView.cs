using C969_Task1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Task1.Forms
{
    public partial class CalendarAppointmentView : Form
    {
        public string selectedDate { get; set; }
        public CalendarAppointmentView(string selectedDate)
        {
            InitializeComponent();
            this.selectedDate = selectedDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Close();
            
        }

        private void CalendarAppointmentView_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Appointment.AppointmentsByCalendar(selectedDate);
        }
    }
}
