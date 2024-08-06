using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969_Task1.Forms
{
    public partial class AddCustomerForm : Form
    {

        

        public AddCustomerForm()
        {
            InitializeComponent();
            


            

        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("datasource=127.0.0.1; port=3306; Username=sqlUser; Password=Passw0rd!");
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM client_schedule.customer", cnn);
            DataSet ds = new DataSet();

            cnn.Open();
            adapter.Fill(ds, "customer");
            dataGridView1.DataSource = ds.Tables["customer"];
            cnn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
