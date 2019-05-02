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
    public partial class DisplayGroupProject : Form
    {
        public DisplayGroupProject()
        {
            InitializeComponent();
        }

        SqlDataAdapter dataAdapter;
        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            String query = "SELECT [Title], [GroupName], [AssignmentDate] FROM Project JOIN GroupProject ON Project.Id = GroupProject.ProjectID JOIN [Group] ON GroupProject.GroupId = [Group].Id";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();

            command.Connection = conn;
            DataTable table = new DataTable();
            dataAdapter = new SqlDataAdapter("SELECT [Title], [GroupName], [AssignmentDate] FROM Project JOIN GroupProject ON Project.Id = GroupProject.ProjectID JOIN [Group] ON GroupProject.GroupId = [Group].Id", conn);
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

