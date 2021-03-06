﻿using System;
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
    public partial class ManageGroupProject : Form
    {
        public ManageGroupProject()
        {
            InitializeComponent();
        }

        public String Error;
        public bool InputValidation()
        {
            if (!String.IsNullOrEmpty(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "^[a-zA-Z]+$"))
            {
                Error = "Incorrect Project Name!";
                return false;
            }
            else if (!String.IsNullOrEmpty(textBox1.Text) && !Regex.IsMatch(textBox1.Text, "^[0-9]"))
            {
                Error = "Incorrect Group Name!";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ManageGroupProject_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if(InputValidation())
            {*/
                String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(conURL);
                String query = "INSERT INTO GroupProject(ProjectId, GroupId, AssignmentDate) " +
                    "Values(SELECT Id FROM Project WHERE Title = @PName, SELECT Id FROM Group WHERE GroupName = @GName, @AssignmentDate)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@PName", textBox3.Text);
                command.Parameters.AddWithValue("@GName", textBox1.Text);
                command.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Value);
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
