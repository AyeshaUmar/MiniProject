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
    public partial class UpdateAdvisor : Form
    {
        public UpdateAdvisor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string query;
            if (attribute == "FirstName")
            {
                query = "UPDATE Advisor SET [Designation] = @Designation, [Salary] = @Salary WHERE Id = (SELECT Id From Person WHERE FirstName = @value);" +
                    "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact, [Email] = @Email, [DateOfBirth] = @DateOfBirth" +
                    "[Gender] = (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender) WHERE FirstName = @value)";
            }
            else if (attribute == "Contact")
            {
                query = "UPDATE Advisor SET [Designation] = @Designation, [Salary] = @Salary WHERE Id = (SELECT Id From Person WHERE Contact = @value);" +
                    "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact, [Email] = @Email, [DateOfBirth] = @DateOfBirth" +
                    "[Gender] = (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender) WHERE Contact = @value)";
            }
            else
            {
                query = "UPDATE Advisor SET [Designation] = @Designation, [Salary] = @Salary WHERE Id = (SELECT Id FROM Person WHERE Email = @value);" +
                    "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact, [Email] = @Email, [DateOfBirth] = @DateOfBirth" +
                    "[Gender] = (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender) WHERE Email = @value";
            }
           SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Value", textBox1.Text);
            command.Parameters.AddWithValue("@FirstName", textBox2.Text);
            command.Parameters.AddWithValue("@LastName", textBox3.Text);
            command.Parameters.AddWithValue("@Contact", textBox4.Text);
            command.Parameters.AddWithValue("@Email", textBox5.Text);
            command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
            if (radioButton1.Checked)
                command.Parameters.AddWithValue("@Gender", "Male");
            else
                command.Parameters.AddWithValue("@Gender", "Female");
            if (checkBox1.Checked)
            {
                command.Parameters.AddWithValue("@Designation", "Professor");
            }
            else if (checkBox2.Checked)
            {
                command.Parameters.AddWithValue("@Designation", "Associate Professor");
            }
            else if (checkBox3.Checked)
            {
                command.Parameters.AddWithValue("@Designation", "Assisstant Professor");
            }
            else if (checkBox5.Checked)
            {
                command.Parameters.AddWithValue("@Designation", "Lecturer");
            }
            else
            {
                command.Parameters.AddWithValue("@Designation", "Industry Professional");
            }
            command.Parameters.AddWithValue("@DateOfBirth", textBox7.Text);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
