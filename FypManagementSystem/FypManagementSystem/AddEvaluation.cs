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
    public partial class AddEvaluation : Form
    {
        public AddEvaluation()
        {
            InitializeComponent();
        }

        public String Error;
        /*public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[0-9]"))
            {
                Error = "Incorrect Marks!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[0-9]"))
            {
                Error = "Incorrect Weightage!";
                return false;
            }
            else
            {
                return true;
            }
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            /*if (InputValidation())
            {*/
                String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conURL);
                String query = "INSERT INTO Evaluation(Name, TotalMarks, TotalWeightage) Values(@Name, @TotalMarks, @TotalWeightage)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Name", textBox1.Text);
                command.Parameters.AddWithValue("@TotalMarks", textBox2.Text);
                command.Parameters.AddWithValue("@TotalWeightage", textBox3.Text);
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
