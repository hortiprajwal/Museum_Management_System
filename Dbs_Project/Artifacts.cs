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
    public partial class Artifacts : Form
    {
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Artifacts()
        {
            InitializeComponent();
        }

        private void Artifacts_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            comm = new MySqlCommand();
            comm.CommandText = "select z_id from zone";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new MySqlDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_zone");
            dt = ds.Tables["Tbl_zone"];
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "z_id";
            conn.Close();
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
            comm.CommandText = "select * from artifacts";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new MySqlDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_artifacts");
            dt = ds.Tables["Tbl_artifacts"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_artifacts";
            conn.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            MySqlCommand cm = new MySqlCommand();
            cm.Connection = conn;
            cm.CommandText = "insert into artifacts values ( "+ textBox1.Text + ", '" + textBox4.Text + "', '" + textBox3.Text + "', " + comboBox1.Text + ")";
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
            cm.CommandText = "delete from artifacts where a_id = " + textBox1.Text;
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            conn.Close();
        }
    }
}
