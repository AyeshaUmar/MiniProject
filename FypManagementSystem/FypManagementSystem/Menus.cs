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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FypManagementSystem
{
    public partial class Menus : Form
    {
        public Menus()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateRecord newStudent = new UpdateRecord();
            this.Hide();
            newStudent.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DisplayProject record = new DisplayProject();
            this.Hide();
            record.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Index homepage = new Index();
            this.Hide();
            homepage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRecord newStudent = new AddRecord();
            this.Hide();
            newStudent.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddProject newProject = new AddProject();
            this.Hide();
            newProject.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AddEvaluation newEvaluation = new AddEvaluation();
            this.Hide();
            newEvaluation.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayRecord record = new DisplayRecord();
            this.Hide();
            record.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DisplayEvaluation record = new DisplayEvaluation();
            this.Hide();
            record.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateProject newProject = new UpdateProject();
            this.Hide();
            newProject.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UpdateEvaluation newEvaluation = new UpdateEvaluation();
            this.Hide();
            newEvaluation.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateAdvisor newAdvisor = new UpdateAdvisor();
            this.Hide();
            newAdvisor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRecord over = new DeleteRecord();
            this.Hide();
            over.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DeleteProject over = new DeleteProject();
            this.Hide();
            over.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DeleteEvaluation over = new DeleteEvaluation();
            this.Hide();
            over.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            AddGroup group = new AddGroup();
            this.Hide();
            group.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            DeleteGroup group = new DeleteGroup();
            this.Hide();
            group.Show();

        }

        private void button23_Click(object sender, EventArgs e)
        {
            DisplayGroup group = new DisplayGroup();
            this.Hide();
            group.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            UpdateGroup group = new UpdateGroup();
            this.Hide();
            group.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ManageEvaluation manage = new ManageEvaluation();
            this.Hide();
            manage.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageGroups group = new ManageGroups();
            this.Hide();
            group.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ManageGroupProject project = new ManageGroupProject();
            this.Hide();
            project.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DisplayGroupProject groupProject = new DisplayGroupProject();
            this.Hide();
            groupProject.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DeleteGroupProject delete = new DeleteGroupProject();
            this.Hide();
            delete.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            UpdateGroupProject groupProject = new UpdateGroupProject();
            this.Hide();
            groupProject.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DisplayGroupStudent groupStudent = new DisplayGroupStudent();
            this.Hide();
            groupStudent.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteFromGroup delete = new DeleteFromGroup();
            this.Hide();
            delete.Show();
        }

        private void Menus_Load(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            DisplayGroupEvaluation display = new DisplayGroupEvaluation();
            this.Hide();
            display.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            DeleteGroupEvaluation delete = new DeleteGroupEvaluation();
            this.Hide();
            delete.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ManageProjectAdvisor advisor = new ManageProjectAdvisor();
            this.Hide();
            advisor.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            DisplayProjectAdvisor advisor = new DisplayProjectAdvisor();
            this.Hide();
            advisor.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            DeleteProjectAdvisor delete = new DeleteProjectAdvisor();
            this.Hide();
            delete.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("E:/Report.pdf", FileMode.Create));
            document.Open();
            //PdfPTable table = new PdfPTable(3);
            //PdfPCell cell = new PdfPCell(new Phrase("Header Spanning 3 columns"));
            document.Add(new Phrase("Ayesha is stupid"));
            document.Close();
        }
    }
}
