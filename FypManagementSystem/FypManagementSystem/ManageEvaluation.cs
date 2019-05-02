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
    public partial class ManageEvaluation : Form
    {
        public ManageEvaluation()
        {
            InitializeComponent();
        }

        public String Error;
        public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Group Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Evaluation Nmae!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[0-9]"))
            {
                Error = "Incorrect Marks!";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (InputValidation())
            {*/
                String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conURL);
                String query = "INSERT INTO GroupEvaluation(GroupId, EvaluationId, ObtainedMarks, EvaluationDate) " +
                    "Values(SELECT Id FROM Group WHERE GroupName = @GroupName, SELECT Id FROM Evaluation WHERE Name = @EvaluationName, @ObtainedMarks, @EvaluationDate)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@GroupName", textBox1.Text);
                command.Parameters.AddWithValue("@EvaluationName", textBox2.Text);
                command.Parameters.AddWithValue("@ObtainedMarks", textBox3.Text);
                command.Parameters.AddWithValue("@EvaluationDate", dateTimePicker1.Value);
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
