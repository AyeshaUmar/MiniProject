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
    public partial class UpdateGroupProject : Form
    {
        public UpdateGroupProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string query;
            if (attribute == "Group Name")
            {
                query = "UPDATE GroupProject SET [ProjectId] = (SELECT Id FROM [Project] Where Title = @NewProject), " +
                    "[GroupId] = (SELECT Id FROM [Group] WHERE GroupName = @NewGroup), [AssignmentDate] = @AssignmentDate " +
                    "WHERE GroupId = (SELECT Id FROM [Group] WHERE GroupName = @value)";
            }
            else
            {
                query = "UPDATE GroupProject SET [ProjectId] = (SELECT Id FROM [Project] Where Title = @NewProject), " +
                    "[GroupId] = (SELECT Id FROM [Group] WHERE GroupName = @NewGroup), [AssignmentDate] = @AssignmentDate " +
                    "WHERE ProjectId = (SELECT Id FROM [Project] WHERE Title = @value)";
            }
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Value", textBox1.Text);
            command.Parameters.AddWithValue("@NewProject", textBox2.Text);
            command.Parameters.AddWithValue("@NewGroup", textBox3.Text);
            command.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
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
