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
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }

        public String Error;
        /*public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Description!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Title!";
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
                String query = "INSERT INTO Project(Description, Title) Values(@Description, @Title)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Description", textBox1.Text);
                command.Parameters.AddWithValue("@Title", textBox2.Text);
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

        private void label3_Click(object sender, EventArgs e)
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
