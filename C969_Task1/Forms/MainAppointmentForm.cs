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

namespace C969_Task1.Forms.Customer
{
    public partial class MainAppointmentForm : Form
    {
        
        public MainAppointmentForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = Appointment.AppointmentsByUser(1);
            dataGridView2.DataSource = Models.Customer.SimpleCustomerData();
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to delete this appointmnet?", "Delete Appointment", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Appointment.DeleteAppointment(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                Appointment.RefreshData(Appointment.AppointmentsByUser(1), dataGridView1);
                return;
            }
            
        }

        private void addBTN_Click_1(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
            this.Hide();
        }

        private void editBTN_Click(object sender, EventArgs e)
        {
            int appointmentID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            EditAppointment editAppointment = new EditAppointment(appointmentID);
            editAppointment.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var customerID = selectedRow.Cells["CustomerID"].Value.ToString();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["CustomerID"].Value != null && row.Cells["CustomerID"].Value.ToString() == customerID)
                {
                    row.Selected = true;

                    dataGridView2.FirstDisplayedScrollingRowIndex = row.Index;

                    break;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppointmentDetails appointmentDetails = new AppointmentDetails(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[1].Value.ToString());
            appointmentDetails.Show();
        }
    }
}
