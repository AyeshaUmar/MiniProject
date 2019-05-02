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
    public partial class Evaluation : Form
    {
        public Evaluation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            String query = "INSERT INTO Evaluation(Nmae, TotalMarks, TotalWeightage) Values(@Name, @Marks, @Weightage)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Name", textBox1.Text);
            command.Parameters.AddWithValue("@Marks", textBox2.Text);
            command.Parameters.AddWithValue("@Weightage", textBox4.Text);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }
    }
}
