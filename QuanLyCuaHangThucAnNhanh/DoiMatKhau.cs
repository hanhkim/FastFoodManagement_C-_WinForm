using QuanLyCuaHangThucAnNhanh.DAO;
using QuanLyCuaHangThucAnNhanh.DTO;
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


namespace QuanLyCuaHangThucAnNhanh
{
    public partial class DoiMatKhau : Form
    {

        public DoiMatKhau(string User, string Pass)
        {
            InitializeComponent();

            label4.Text = User;
            label5.Text = Pass;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra
            if (txtOldPass.Text == "") MessageBox.Show("Chưa nhập pass cũ");
            else if (txtNewPass.Text == "") MessageBox.Show("Chưa nhập pass mới");
            else if (txtPassAgain.Text == "") MessageBox.Show("Chưa nhập lại pass");
            else if (txtOldPass.Text != label5.Text) MessageBox.Show("Nhập sai Pass cũ");
            else if (txtNewPass.Text != txtPassAgain.Text) MessageBox.Show("Nhập lại mật khẩu chưa đúng");
            else
            {
                // Đổi pass
                string query = "update DANGNHAP set MATKHAU ='" + txtNewPass.Text + "' where TENDANGNHAP = '" + label4.Text + "' ";

                using (SqlConnection connection = new SqlConnection(DAO.DataProvider.Instance.ConnectionStr))
                {
                    connection.Open();
                    // SqlCommand command = new SqlCommand(query, connection);
                    int result = DataProvider.Instance.subExcuteNonQuery(query);
                    if (result > 0)
                    {

                        MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Thay đổi mật khẩu thất bại", "Thông báo");
                    }

                    connection.Close();

                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            // Kiểm tra
            if (txtOldPass.Text == "") MessageBox.Show("Chưa nhập pass cũ");
            else if (txtNewPass.Text == "") MessageBox.Show("Chưa nhập pass mới");
            else if (txtPassAgain.Text == "") MessageBox.Show("Chưa nhập lại pass");
            else if (txtOldPass.Text != label5.Text) MessageBox.Show("Nhập sai Pass cũ");
            else if (txtNewPass.Text != txtPassAgain.Text) MessageBox.Show("Nhập lại mật khẩu chưa đúng");
            else
            {
                // Đổi pass
                string query = "update DANGNHAP set MATKHAU ='" + txtNewPass.Text + "' where TENDANGNHAP = '" + label4.Text + "' ";

                using (SqlConnection connection = new SqlConnection(DAO.DataProvider.Instance.ConnectionStr))
                {
                    connection.Open();
                    // SqlCommand command = new SqlCommand(query, connection);
                    int result = DataProvider.Instance.subExcuteNonQuery(query);
                    if (result > 0)
                    {

                        MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Thay đổi mật khẩu thất bại", "Thông báo");
                    }

                    connection.Close();

                }

            }
        }

    }
}
