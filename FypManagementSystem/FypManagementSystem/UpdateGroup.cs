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
    public partial class UpdateGroup : Form
    {
        public UpdateGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            string query = "UPDATE Group SET [GroupName] = @NewName, [Created_On] = @NewDate WHERE GroupName = 'Name'";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Name", textBox1.Text);
            command.Parameters.AddWithValue("@NewName", textBox2.Text);
            command.Parameters.AddWithValue("@NewDate", dateTimePicker1.Value);
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
