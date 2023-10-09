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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                List<Faculty> listFacultys = db.Faculties.ToList();
                List<Student> listStudent = db.Students.ToList();
                FillFalcultyCombobox(listFacultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void FillFalcultyCombobox(List<Faculty> listFacultys)
        {
            this.comboBox1.DataSource = listFacultys;
            this.comboBox1.DisplayMember = "FacultyName";
            this.comboBox1.ValueMember = "FacultyID";
        }

        private void BindGrid(List<Student> listStudent)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.StudentID;
                dataGridView1.Rows[index].Cells[1].Value = item.FullName;
                dataGridView1.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dataGridView1.Rows[index].Cells[3].Value = item.AverageScore;
            }
            textBox3.Text = dataGridView1.RowCount.ToString();
        }

        private void Tim_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            List<Student> students = context.Students.ToList();
            List<Student> student = new List<Student>();

            foreach (var item in students)
            {
                if (checkFacultyID(0) == item.FacultyID)
                {
                    if (item.StudentID.Contains(textBox1.Text) && textBox2.Text == "")
                    {
                        student.Add(item);
                    }
                    else if (item.FullName.ToLower().Contains(textBox2.Text.ToLower()) && textBox1.Text == "")
                    {
                        student.Add(item);
                    }
                    else if (item.StudentID.Contains(textBox1.Text) && item.FullName.ToLower().Contains(textBox2.Text))
                    {
                        student.Add(item);
                    }
                    else if (textBox1.Text == "" && textBox2.Text == "")
                    {
                        student.Add(item);
                    }
                }
            }
            BindGrid(student);
        }
        private int checkFacultyID(int a)
        {
            Model1 context = new Model1();
            List<Faculty> listFalcultys = context.Faculties.ToList();
            foreach (var f in listFalcultys)
            {
                if (comboBox1.Text == f.FacultyName)
                {
                    a = f.FacultyID;
                }
            }
            return a;
        }
        private void tro_ve_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 student = new Model1();
                string studentID = textBox1.Text;
                Student selectedStudent = student.Students.FirstOrDefault(s => s.StudentID == studentID);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    student.Students.Remove(selectedStudent);
                    student.SaveChanges();
                    MessageBox.Show("Xoa sinh vien thanh cong");
                    List<Student> listStudents = student.Students.ToList();
                    BindGrid(listStudents);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
