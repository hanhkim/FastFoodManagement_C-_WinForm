using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCuaHangThucAnNhanh.DAO;

namespace QuanLyCuaHangThucAnNhanh
{
    public partial class QL_TaiKhoan : Form
    {
        //public string connect = "Data Source=DESKTOP-8IAU9DP;Initial Catalog = QUAN_LY_CUA_HANG_THUC_AN_NHANH; Integrated Security = True";

        public QL_TaiKhoan()
        {
            InitializeComponent();
            LoadTaiKhoan();
            //NhanVienBinding();
        }

        //-- 
        DataSet GetListTaiKhoan()
        {
            DataSet data = new DataSet();

            // string query = "select MANV as N'Mã Nhân Viên', TENNV as N'Tên Nhân Viên', NGAYSINH as N'Ngày Sinh', GIOITINH as N'Giới Tính', CHUCVU as N'Chức Vụ', DIACHI as N'Địa Chỉ' from NHANVIEN";
            string query = "select * from DANGNHAP";
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.ConnectionStr))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        void LoadTaiKhoan()
        {
            dtgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //  dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgvTaiKhoan.DataSource = GetListTaiKhoan().Tables[0];
            TaiKhoanBinding();
        }

        void TaiKhoanBinding()
        {
            txtManv.DataBindings.Clear();
            txtManv.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "MANV"));
            txtManv.Enabled = false;
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "TENNV"));

            txtChucVu.DataBindings.Clear();
            txtChucVu.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "CHUCVU"));

            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "TenDANGNHAP"));

            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "MATKHAU"));

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
           
        }

        private void btSua_Click(object sender, EventArgs e)
        {
           
        }

        private void btthem_Click_1(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tennv = txtTenNV.Text;
            string chucvu = txtChucVu.Text;
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;

            if (QL_TaiKhoanDAO.Instance.InsertTaiKhoan(manv, tennv, tendangnhap, matkhau, chucvu))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!!");
            }
            LoadTaiKhoan();
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tennv = txtTenNV.Text;
            string chucvu = txtChucVu.Text;
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;


            if (QL_TaiKhoanDAO.Instance.EditNhanVien(manv, tennv, tendangnhap, matkhau, chucvu))
            {
                MessageBox.Show("Sửa thông tin tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thông tin tài khoản thất bại!");
            }
            LoadTaiKhoan();
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            if (QL_TaiKhoanDAO.Instance.DeleteTaiKhoan(manv))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại!");
            }
            LoadTaiKhoan();
        }
    }
}