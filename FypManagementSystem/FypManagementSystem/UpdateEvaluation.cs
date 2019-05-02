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
    public partial class UpdateEvaluation : Form
    {
        public UpdateEvaluation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string query;
            if(attribute == "Name")
            {
                query = "UPDATE Evaluation SET [Name] = @NewName, [TotalMarks] = @NewMarks, [TotalWeightage] = @newWeightage WHERE Name = @Value";
            }
            else
            {
                query = "UPDATE Evaluation SET [Name] = @NewName, [TotalMarks] = @NewMarks, [TotalWeightage] = @newWeightage WHERE TotalMarks = @Value";
            }
            
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Value", textBox1.Text);
            command.Parameters.AddWithValue("@NewTitle", textBox2.Text);
            command.Parameters.AddWithValue("@NewDescription", textBox3.Text);
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
