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

namespace FypManagementSystem
{
    public partial class DisplayProjectAdvisor : Form
    {
        public DisplayProjectAdvisor()
        {
            InitializeComponent();
        }

        SqlDataAdapter dataAdapter;
        private void button1_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source=DESKTOP-EI0JVT5\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(conURL);
            String query = "SELECT [FirstName] + [LastName] as Advisor ,[Title], [AdvisorRole], [AssignmentDate] FROM [Person] JOIN[ProjectAdvisor] ON Person.Id = ProjectAdvisor.AdvisorId JOIN Project ON ProjectAdvisor.ProjectId = Project.Id";
            SqlCommand command = new SqlCommand(query, conn);

            conn.Open();

            command.Connection = conn;
            DataTable table = new DataTable();
            dataAdapter = new SqlDataAdapter("SELECT [FirstName] + [LastName] as Advisor ,[Title], [AdvisorRole], [AssignmentDate] FROM [Person] JOIN[ProjectAdvisor] ON Person.Id = ProjectAdvisor.AdvisorId JOIN Project ON ProjectAdvisor.ProjectId = Project.Id", conn);
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menus menu = new Menus();
            this.Hide();
            menu.Show();
        }
    }
}
