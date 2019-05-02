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
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string query;
            if(attribute == "RegistrationNo")
            {
                query = "UPDATE Student SET [RegistrationNo] = @RegistrationNo WHERE RegistrationNo = @value;" +
                    "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact, [Email] = @Email, [DateOfBirth] = @DateOfBirth" +
                    "[Gender] = (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender) WHERE Id = (SELECT Id FROM Student WHERE RegistrationNo = @value)";
            }
            else if(attribute == "FirstName")
            {
                query = "UPDATE Student SET [RegistrationNo] = @RegistrationNo WHERE Id = (SELECT Id FROM Person WHERE FirstName = @value);" +
                    "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact, [Email] = @Email, [DateOfBirth] = @DateOfBirth" +
                    "[Gender] = (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender) WHERE FirstName = @value";        
            }
            else
            {
                query = "UPDATE Student SET [RegistrationNo] = @RegistrationNo WHERE Id = (SELECT Id FROM Person WHERE Contact = @value);" +
                    "UPDATE Person SET [FirstName] = @FirstName, [LastName] = @LastName, [Contact] = @Contact, [Email] = @Email, [DateOfBirth] = @DateOfBirth" +
                    "[Gender] = (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender) WHERE Contact = @value";
            }
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Value", textBox1.Text);
            command.Parameters.AddWithValue("@RegistrationNo", textBox2.Text);
            command.Parameters.AddWithValue("@FirstName", textBox3.Text);
            command.Parameters.AddWithValue("@LastName", textBox4.Text);
            command.Parameters.AddWithValue("@Contact", textBox5.Text);
            command.Parameters.AddWithValue("@Email", textBox6.Text);
            command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
            if (radioButton1.Checked)
                command.Parameters.AddWithValue("@Gender", "Male");
            else
                command.Parameters.AddWithValue("@Gender", "Female");
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
