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
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FypManagementSystem
{
    public partial class AddRecord : Form
    {
        public AddRecord()
        {
            InitializeComponent();
        }

        public String Error;
        /*public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect First Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Last Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$"))
            {
                Error = "Incorrect Registration Number!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox4.Text) && !Regex.IsMatch(textBox4.Text, @"^[0-9]{4}-[0-9]{7}$"))
            {
                Error = "Incorrect Contact Number!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox5.Text) && !Regex.IsMatch(textBox5.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                Error = "Incorrect Email!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox6.Text) && !Regex.IsMatch(textBox6.Text, "^[0-9]"))
            {
                Error = "Incorrect Salary!";
                return false;
            }
            else
            {
                return false;
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        /*private void AddRecord_Load(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            checkBox1.Hide();
            checkBox2.Hide();
            checkBox3.Hide();
            checkBox4.Hide();
            checkBox5.Hide();
            textBox6.Hide();
        }*/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string relation = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (relation == "Student")
            {
                label10.Hide();
                label11.Hide();
                checkBox1.Hide();
                checkBox2.Hide();
                checkBox3.Hide();
                checkBox4.Hide();
                checkBox5.Hide();
                textBox6.Hide();
                label2.Show();
                textBox1.Show();
            }
            else
            {
                label10.Show();
                label11.Show();
                checkBox1.Show();
                checkBox2.Show();
                checkBox3.Show();
                checkBox4.Show();
                checkBox5.Show();
                textBox6.Show();
                label2.Hide();
                textBox1.Hide();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            string relation = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (relation == "Student")
            {
                /*if(InputValidation())
                {*/
                    String query = "INSERT INTO Person(FirstName, LastName, Contact, Email, DateOfBirth, Gender) " +
                    "Values(@FirstName, @LastName, @Contact, @Email, @DateOfBirth, (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender));" +
                    "INSERT INTO Student(Id, RegistrationNo) " +
                    "Values((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName = @LastName AND Contact = @Contact AND Email = @Email AND DateOfBirth = @DateOfBirth), @RegistrationNo)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@RegistrationNo", textBox1.Text);
                    command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    command.Parameters.AddWithValue("@LastName", textBox3.Text);
                    command.Parameters.AddWithValue("@Contact", textBox4.Text);
                    command.Parameters.AddWithValue("@Email", textBox5.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                    if (radioButton1.Checked)
                        command.Parameters.AddWithValue("@Gender", "Male");
                    else
                        command.Parameters.AddWithValue("@Gender", "Female");
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Your data is entered successfully!");
                /*}
                else
                {
                   MessageBox.Show("Please Enter Data");
                }*/
                    
            }

            else
            {
                /*if (InputValidation())
                {*/
                    String query = "INSERT INTO Person(FirstName, LastName, Contact, Email, DateOfBirth, Gender) " +
                    "Values(@FirstName, @LastName, @Contact, @Email, @DateOfBirth, (SELECT Id FROM Lookup WHERE Category = 'Gender' AND Value = @Gender));" +
                    "INSERT INTO Advisor(Id, Designation, Salary) " +
                    "Values((SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName = @LastName AND Contact = @Contact AND Email = @Email AND DateOfBirth = @DateOfBirth), " +
                    "(SELECT Id FROM Lookup WHERE Category = 'Designation' AND Value = @Designation), @Salary)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    command.Parameters.AddWithValue("@LastName", textBox3.Text);
                    command.Parameters.AddWithValue("@Contact", textBox4.Text);
                    command.Parameters.AddWithValue("@Email", textBox5.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@Salary", textBox6.Text);
                    if (radioButton1.Checked)
                    {
                        command.Parameters.AddWithValue("@Gender", "Male");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Gender", "Female");
                    }

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
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Your data is entered successfully!");
                /*}
                else
                {
                    MessageBox.Show("Please Enter Data");
                }*/

            }
        }

        private void AddRecord_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }
    }
}
