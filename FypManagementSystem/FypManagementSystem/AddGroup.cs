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
    public partial class AddGroup : Form
    {
        public AddGroup()
        {
            InitializeComponent();
        }

        public String Error;
        /*public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox2.Text) && !Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Group Name!";
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
                string query = "INSERT INTO [dbo].[Group] ([GroupName], [Created_On]) VALUES(@Name, @CreatedOn)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Name", textBox2.Text);
                command.Parameters.AddWithValue("@CreatedOn", dateTimePicker1.Value);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }
    }
}
