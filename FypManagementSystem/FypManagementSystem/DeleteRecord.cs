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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FypManagementSystem
{
    public partial class DeleteRecord : Form
    {
        public DeleteRecord()
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
            string relation = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (relation == "Student")
            {
                label2.Show();
                label5.Show();
                comboBox2.Show();
                textBox2.Show();
                label3.Hide();
                label4.Hide();
                comboBox3.Hide();
                textBox1.Hide();
            }
            else
            {
                label2.Hide();
                label5.Hide();
                comboBox2.Hide();
                textBox2.Hide();
                label3.Show();
                label4.Show();
                comboBox3.Show();
                textBox1.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string relation = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (relation == "Student")
            {
                String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conURL);
                string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string query;
                if (attribute == "RegistrationNo")
                {
                    query = "DELETE FROM Student WHERE RegistrationNo = @value;" +
                        "DELETE FROM Person WHERE Id = (SELECT Id FROM Student WHERE RegistrationNo = @value)";
                }
                else if (attribute == "FirstName")
                {
                    query = "DELETE FROM Student WHERE Id = (SELECT Id FROM Person WHERE FirstName = @value);" +
                        "DELETE FROM Person WHERE FirstName = @value";
                }
                else
                {
                    query = "DELETE FROM Student WHERE Id = (SELECT Id FROM Person WHERE Contact = @value;" +
                        "DELETE FROM Person WHERE Contact = @value";
                }
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Value", textBox1.Text);
                conn.Open();
                command.ExecuteNonQuery();
            }
            else
            {
                String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conURL);
                string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string query;
                if (attribute == "FirstName")
                {
                    query = "DELETE FROM Advisor WHERE Id = (SELECT Id FROM PErson WHERE FirstName = @value);" +
                        "DELETE FROM Person WHERE FirstName = @value";
                }
                else if (attribute == "Contact")
                {
                    query = "DELETE FROM Person WHERE contact = @value;" +
                        "DELETE FROM Advisor WHERE Id = (SELECT Id FROM Person WHERE Contact = @value)";
                }
                else
                {
                    query = "DELETE FROM Advisor WHERE Id = (SELECT Id FROM Person WHERE Email = @value;" +
                        "DELETE FROM Person WHERE Email = @value";
                }
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Value", textBox1.Text);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
