using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab04_01
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
        private bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
        private bool check()
        {
            string facultyID = textBox1.Text;
            string facultyName = textBox2.Text.Trim();
            string totalProfessor = textBox3.Text;

            // Kiểm tra mã số sinh viên
            if (string.IsNullOrEmpty(facultyID) || !IsNumeric(facultyID) )
            {
                MessageBox.Show("Ma khoa khong hop le. Vui long nhap lai(phai la so va ko co ki tu dac biet)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra họ tên
            if (string.IsNullOrEmpty(facultyName) || facultyName.Length < 3 || facultyName.Length > 30)
            {
                MessageBox.Show("Ten khoa khong hop le. Vui long nhap lai (tu 3 den 30 ky tu, ko chua ky tu dac biet).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra điểm trung bình
            if (!IsNumeric(totalProfessor))
            {
                MessageBox.Show("Tong so giao su khong hop le. Vui long nhap lai (phai la so khong chua ki tu dac biet).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
