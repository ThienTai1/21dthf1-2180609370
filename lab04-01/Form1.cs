using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab04_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                var studentID = textBox1.Text;
                var fullname = textBox2.Text;
                var facultyID = (int)comboBox1.SelectedValue;
                var averageScore = textBox3.Text;

                Model1 context = new Model1();

                Student student = new Student()
                {
                    FullName = fullname,
                    FacultyID = facultyID,
                    AverageScore = double.Parse(averageScore),
                    StudentID = studentID
                };

                context.Students.Add(student);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                BindGrid(context.Students.ToList());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            var updateStudent = db.Students.SingleOrDefault(c => c.StudentID.Equals(textBox1.Text));
            if (updateStudent == null)
            {
                MessageBox.Show("Không tồn tại sinh viên có MSSV {0}", textBox1.Text);
                return;
            }
            updateStudent.FullName = textBox1.Text;
            updateStudent.AverageScore = double.Parse(textBox3.Text);
            updateStudent.FacultyID = (int)comboBox1.SelectedValue;

            db.SaveChanges();
            BindGrid(db.Students.ToList());
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void chucNangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timKiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }

        private void quanLyKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            this.Hide();
            frm.ShowDialog();
            frm = null;
            this.Show();
        }
        private bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
        }

        private bool IsValidName(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }

        private bool check()
        {
            string studentID = textBox1.Text;
            string fullname = textBox2.Text.Trim();
            string averageScore = textBox3.Text.Trim();

            // Kiểm tra mã số sinh viên
            if (string.IsNullOrEmpty(studentID) || !IsNumeric(studentID) || studentID.Length != 10)
            {
                MessageBox.Show("Mã số sinh viên không hợp lệ. Vui lòng nhập lại (phải là số và có đủ 10 ký tự).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra họ tên
            if (string.IsNullOrEmpty(fullname) || fullname.Length < 3 || fullname.Length > 100 || !IsValidName(fullname))
            {
                MessageBox.Show("Họ tên không hợp lệ. Vui lòng nhập lại (từ 3 đến 100 ký tự, không chứa ký tự đặc biệt hoặc số).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra điểm trung bình
            if (!float.TryParse(averageScore, out float score) || score < 0 || score > 10)
            {
                MessageBox.Show("Điểm trung bình không hợp lệ. Vui lòng nhập lại (phải là số từ 0 đến 10).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
