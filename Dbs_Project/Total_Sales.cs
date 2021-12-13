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

namespace Dbs_Project
{
    public partial class Total_Sales : Form
    {
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Total_Sales()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void show_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "call TotalSalesOnDate (" + textBox1.Text + ")";
            com.CommandType = CommandType.Text;
            comm = new MySqlCommand();
            comm.CommandText = "SELECT * from SALES";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new MySqlDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_sales");
            dt = ds.Tables["Tbl_sales"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_sales";
            conn.Close();
        }

    }
}
