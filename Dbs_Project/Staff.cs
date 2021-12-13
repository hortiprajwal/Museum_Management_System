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
    public partial class Staff : Form
    {
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Staff()
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
            comm = new MySqlCommand();
            comm.CommandText = "select * from staff";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new MySqlDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_staff");
            dt = ds.Tables["Tbl_staff"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_staff";
            conn.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //STR_TO_DATE('" + textBox5.Text + "','%d-%m-%Y')
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            MySqlCommand cm = new MySqlCommand();
            cm.Connection = conn;
            cm.CommandText = "insert into staff values ( " + textBox1.Text + ", '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "' , STR_TO_DATE('" + textBox6.Text + "','%d-%m-%Y'), '" + textBox7.Text + "')";
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            conn.Close();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            MySqlCommand cm = new MySqlCommand();
            cm.Connection = conn;
            cm.CommandText = "delete from staff where s_id = " + textBox1.Text;
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Staff_Load(object sender, EventArgs e)
        {

        }
    }
}
