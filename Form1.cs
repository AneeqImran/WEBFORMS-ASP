using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEBFORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_Load() called...");
            richTextBox1.Text = "Startup..."; try
            {
                System.Diagnostics.Debug.WriteLine("within the try");
                SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                connection.Open();
                richTextBox1.Text = "Connection Successful";
                connection.Close();
            }
            catch (Exception ex)
            {
                richTextBox1.Text = "Error, " + ex;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IQ0VQUV\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            richTextBox1.Text = "Counting Records...";
            command.Connection = connection;
            command.CommandText = "select count(*) from Customers";
            int count = (int)command.ExecuteScalar();
            richTextBox1.Text = "Number of records: " + count;
            connection.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IQ0VQUV\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            richTextBox1.Text = "Inserting Record...";
            command.Connection = connection;
            command.CommandText = "insert into Customers (ID, Company) values('" +
           txtID.Text + "','" + txtCompany.Text + "')";
            command.ExecuteNonQuery();
            richTextBox1.Text = "Record Inserted...";
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IQ0VQUV\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            connection.Open();
            richTextBox1.Text = "Retrieving Records...";
            command.Connection = connection;
            command.CommandText = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            richTextBox1.Text = "Retrieval Successful!";
            connection.Close();

        }
    }
}
