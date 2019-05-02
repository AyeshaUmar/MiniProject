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
    public partial class ManageProjectAdvisor : Form
    {
        public ManageProjectAdvisor()
        {
            InitializeComponent();
        }

        public String Error;
        public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Marks!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Weightage!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if (InputValidation())
            {*/
                String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conURL);
                String query = "INSERT INTO PRojectAdvisor(AdvisorID, ProjectId, AdvisorRole, AssignmentDate) " +
                    "Values((SELECT ID FROM Person WHERE FirstName = @FirstName AND LastName = @LastName), (SELECT Id FROM Project WHERE Title = @ProjectName), " +
                    "(SELECT Id FROM Lookup WHERE Category = 'ADVISOR_ROLE' AND Value = @AdvisorRole), @AssignmentDate)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@FirstName", textBox1.Text);
                command.Parameters.AddWithValue("@LastName", textBox2.Text);
                command.Parameters.AddWithValue("@ProjectName", textBox3.Text);
                command.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
                if (radioButton1.Checked)
                    command.Parameters.AddWithValue("@AdvisorRole", "Main Advisor");
                else if (radioButton2.Checked)
                    command.Parameters.AddWithValue("@AdvisorRole", "Co Advisror");
                else
                    command.Parameters.AddWithValue("@AdvisorRole", "Industry Advisor");
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

        private void button2_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }
    }
}

