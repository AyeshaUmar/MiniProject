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
    public partial class DisplayGroupEvaluation : Form
    {
        public DisplayGroupEvaluation()
        {
            InitializeComponent();
        }

        SqlDataAdapter dataAdapter;
        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            String query = "SELECT [GroupName], [Name], [ObtainedMarks], [EvaluationDate] FROM [Group] JOIN GroupEvaluation ON[Group].Id = [GroupEvaluation].GroupId JOIN[Evaluation] ON[GroupEvaluation].EvaluationId = [Evaluation].Id";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();

            command.Connection = conn;
            DataTable table = new DataTable();
            dataAdapter = new SqlDataAdapter("SELECT [GroupName], [Name], [ObtainedMarks], [EvaluationDate] FROM [Group] JOIN GroupEvaluation ON[Group].Id = [GroupEvaluation].GroupId JOIN[Evaluation] ON[GroupEvaluation].EvaluationId = [Evaluation].Id", conn);
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
