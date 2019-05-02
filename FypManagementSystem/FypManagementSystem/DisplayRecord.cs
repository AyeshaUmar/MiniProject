using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FypManagementSystem
{
    public partial class DisplayRecord : Form
    {
        public DisplayRecord()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        SqlDataAdapter dataAdapter;
        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            String query = "SELECT [RegistrationNo],[FirstName],[LastName],[Contact],[Email],[DateOfBirth],[Gender] FROM Person JOIN Student ON Person.Id = Student.Id";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();

            command.Connection = conn;
            DataTable table = new DataTable();
            dataAdapter = new SqlDataAdapter("SELECT [RegistrationNo],[FirstName],[LastName],[Contact],[Email],[DateOfBirth],[Gender] FROM Person JOIN Student ON Person.Id = Student.Id", conn);
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            String query = "SELECT [FirstName],[LastName],[Contact],[Email],[DateOfBirth],[Gender], [Designation], [Salary] FROM Person JOIN Advisor ON Person.Id = Advisor.Id";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();

            command.Connection = conn;
            DataTable table = new DataTable();
            dataAdapter = new SqlDataAdapter("SELECT [FirstName],[LastName],[Contact],[Email],[DateOfBirth],[Gender], [Designation], [Salary] FROM Person JOIN Advisor ON Person.Id = Advisor.Id", conn);
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }
    }
}
