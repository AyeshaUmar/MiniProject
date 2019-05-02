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
    public partial class UpdateProject : Form
    {
        public UpdateProject()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            string query = "UPDATE Project SET [Description] = @NewDescription, [Title] = @NewTitle WHERE Title = @Title";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Title", textBox1.Text);
            command.Parameters.AddWithValue("@NewTitle", textBox2.Text);
            command.Parameters.AddWithValue("@NewDescription", textBox3.Text);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
   