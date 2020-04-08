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
using System.IO;

namespace QuanLyCuaHangThucAnNhanh
{
    public partial class flogin : Form
    {
        //public string connect = @"Data Source=.\;Initial Catalog = QUAN_LY_CUA_HANG_THUC_AN_NHANH; Integrated Security = True";//chạy đi nó như nhau à
        //ủa cái file design đâu?

        public flogin()
        {
            InitializeComponent();
            txbID.Controls.Clear();
            txtpass.Controls.Clear();
        }
        

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string tenTK = txbID.Text;
            string mk = txtpass.Text;
            int type = 2;

            if (radioQuanLy.Checked == true)
            {
                type = 0;
            }
            else if (radioNhanVien.Checked == true)
            {
                type = 1;
            }
            else type = 2;


            string query = "select* from DANGNHAP where TENDANGNHAP = '" + tenTK + "' and MATKHAU = '" + mk + "' and CHUCVU = " + type + " ";
           
            using (SqlConnection connection = new SqlConnection(DAO.DataProvider.Instance.ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader data = command.ExecuteReader();
                if (data.Read() == true)
                {
                    //////////////////////////////////////////////////////////////////////////////////////
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    connection.Close();
                    //CHO VÀO DATATABLE
                    da.Fill(dt);

                    String chucvu = type == 1 ? "Nhân Viên" : "Quản Lý";


                    /////////////////////////////////////////////////////////////////////////////////////
                    //MessageBox.Show("Bạn đăng nhập thành công", "Thông báo");
                    string[] arr = new string[5]; // MaNV - TenDangNhap - MatKhau - TenNv - ChucVu
                    arr[0] = dt.Rows[0]["MANV"].ToString().Trim();
                    arr[1] = dt.Rows[0]["TENDANGNHAP"].ToString().Trim();
                    arr[2] = dt.Rows[0]["MATKHAU"].ToString().Trim();
                    arr[3] = dt.Rows[0]["TENNV"].ToString().Trim();
                    arr[4] = chucvu.ToString();

                    fmain f = new fmain(arr);

                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại, vui lòng kiểm tra lại", "Thông báo");
                }

                
            }
        }
    
       


        private void btnexit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void flogin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void cbx1_CheckedChanged_1(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !txtpass.UseSystemPasswordChar;
        }

        private void ckbQuanLy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flogin_Load(object sender, EventArgs e)
        {
            using (StreamReader rd = new StreamReader("config.inf"))
            {
                DAO.DataProvider.Instance.ConnectionStr = rd.ReadLine();
            }
        }
    }
}
