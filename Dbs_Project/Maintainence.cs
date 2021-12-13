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
    public partial class Maintainence : Form
    {
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Maintainence()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            comm = new MySqlCommand();
            comm.CommandText = "select * from maintenance";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new MySqlDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_maintenance");
            dt = ds.Tables["Tbl_maintenance"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_maintenance";
            conn.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            int v = int.Parse(textBox1.Text);
            MySqlCommand cm = new MySqlCommand();
            cm.Connection = conn;
            cm.CommandText = "update maintenance set status='Completed' where m_id="+textBox1.Text;
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            MessageBox.Show("Updated");
            conn.Close();
        }

        private void Maintainence_Load(object sender, EventArgs e)
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
            comm.CommandText = "select s_id from staff";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new MySqlDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_staff");
            dt = ds.Tables["Tbl_staff"];
            comboBox2.DataSource = dt.DefaultView;
            comboBox2.DisplayMember = "s_id";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            comm = new MySqlCommand();
            comm.CommandText = "SELECT s_name FROM staff WHERE s_id IN (SELECT s_id FROM maintenance WHERE status = 'Pending');";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new MySqlDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Tbl_staff");
            dt = ds.Tables["Tbl_staff"];
            string msg = "Pending Work For Staff Members :\n";
            for(int i=0; i<dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                msg += dr["s_name"].ToString();
                msg += "\n";
            }
            MessageBox.Show(msg, "Pending Status For Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;database=museum_management_system;password=student";
            conn.Open();
            MySqlCommand cm = new MySqlCommand();
            cm.Connection = conn;
            cm.CommandText = "insert into maintenance values ( " + textBox1.Text + ", STR_TO_DATE('" + textBox2.Text + "','%d-%m-%Y'), '" + comboBox4.Text + "', '" + comboBox3.Text + "', " + comboBox1.Text + ", " + comboBox2.Text + ")";
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            conn.Close();
        }
    }
}
