using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab04_01
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            List<Student> LstStudents = db.Students.ToList();
            List<StudentReport> LstReport = new List<StudentReport>();
            foreach (Student i in LstStudents) {
                StudentReport temp = new StudentReport();
                temp.StudentID = i.StudentID;
                temp.FullName = i.FullName;
                temp.AverageScore = i.AverageScore;
                temp.Faculty = i.Faculty.FacultyName;
                LstReport.Add(temp);
            }
            this.reportViewer1.LocalReport.ReportPath = "G:\\Project C#\\TH-ltwd\\lab04\\lab04-01\\Report1.rdlc";
            var reportDataSource = new ReportDataSource("DataSet2", LstReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
