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

namespace FypManagementSystem
{
    public partial class ManageGroups : Form
    {
        public ManageGroups()
        {
            InitializeComponent();
        }

        public String Error;
        public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$") || !String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{4}-[0-9]{7}$") || !String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                Error = "Incorrect Marks!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if(InputValidation())
            {*/
                String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conURL);
                string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string query;
                if (attribute == "RegistrationNo")
                {
                    query = "INSERT INTO GroupStudent(GroupID, StudentId, Status, AssignmentDate)" +
                        "Values(SELECT Id FROM Group WHERE GroupName = @Name, SELECT Id FROM Student WHERE RegistrationNo = @value," +
                        "SELECT Id FROM Lookup WHERE Category = 'STATUS' AND Value = 'Active', DateTime.Now.ToString())";
                }
                else if (attribute == "Contact")
                {
                    query = "INSERT INTO GroupStudent(GroupID, StudentId, Status, AssignmentDate)" +
                        "Values(SELECT Id FROM Group WHERE GroupName = @Name, SELECT Id FROM Person WHERE Contact = @value," +
                        "SELECT Id FROM Lookup WHERE Category = 'STATUS' AND Value = 'Active', DateTime.Now.ToString())";
                }
                else
                {
                    query = "INSERT INTO GroupStudent(GroupID, StudentId, Status, AssignmentDate)" +
                        "Values(SELECT Id FROM Group WHERE GroupName = @Name, SELECT Id FROM Person WHERE Email = @value," +
                        "SELECT Id FROM Lookup WHERE Category = 'STATUS' AND Value = 'Active', DateTime.Now.ToString())";
                }
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Value", textBox1.Text);
                command.Parameters.AddWithValue("@Name", textBox3.Text);
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

        private void ManageGroups_Load(object sender, EventArgs e)
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
