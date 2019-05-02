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
    public partial class DeleteFromGroup : Form
    {
        public DeleteFromGroup()
        {
            InitializeComponent();
        }

        public String Error;
        public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Group Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$") || !String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, @"^[0-9]{4}-[0-9]{7}$") || !String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                Error = "Incorrect Input!";
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
                string attribute = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string query;
                if (attribute == "RegistrationNo")
                {
                    query = "UPDATE GroupStudent SET [Status] = (SELECT Id FROM [Lookup] WHERE [Category] = 'STATUS' AND [Value] = 'InActive') " +
                        "WHERE StudentId = (SELECT Id FROM [Student] WHERE RegistrationNo = @value)";
                }
                else if (attribute == "Contact")
                {
                    query = "UPDATE GroupStudent SET [Status] = (SELECT Id FROM [Lookup] WHERE [Category] = 'STATUS' AND [Value] = 'InActive') " +
                        "WHERE StudentId = (SELECT Id FROM [Person] WHERE Contact = @value)";
                }
                else
                {
                    query = "UPDATE GroupStudent SET [Status] = (SELECT Id FROM [Lookup] WHERE [Category] = 'STATUS' AND [Value] = 'InActive') " +
                        "WHERE StudentId = (SELECT Id FROM [Person] WHERE Email = @value)";
                }
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Value", textBox1.Text);
                command.Parameters.AddWithValue("@GroupName", textBox3.Text);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Your data is deleted successfully!");
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
