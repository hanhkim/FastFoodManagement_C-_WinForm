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
    public partial class ThemNhanVien : Form
    {

        //public string connect = "Data Source=DESKTOP-8IAU9DP;Initial Catalog = QUAN_LY_CUA_HANG_THUC_AN_NHANH; Integrated Security = True";

        //BindingSource foodList = new BindingSource();
        public ThemNhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
            //NhanVienBinding();
        }

        //-- 
        DataSet GetListNhanVien()
        {
            DataSet data = new DataSet();

            // string query = "select MANV as N'Mã Nhân Viên', TENNV as N'Tên Nhân Viên', NGAYSINH as N'Ngày Sinh', GIOITINH as N'Giới Tính', CHUCVU as N'Chức Vụ', DIACHI as N'Địa Chỉ' from NHANVIEN";
            string query = "select * from nhanvien";
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.ConnectionStr)) //thay no doi icon thay cai cờ lê ko?
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        void LoadNhanVien()
        {
            dtgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvNhanVien.DataSource = GetListNhanVien().Tables[0];
            NhanVienBinding();
        }

        void NhanVienBinding()
        {
            txtManv.DataBindings.Clear();
            txtManv.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MANV"));

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "TENNV"));

            txtChucVu.DataBindings.Clear();
            txtChucVu.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "CHUCVU"));

            txtNgaySinh.DataBindings.Clear();
            txtNgaySinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NGAYSINH"));

            txtGioiTinh.DataBindings.Clear();
            txtGioiTinh .DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "GIOITINH"));

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "DIACHI"));

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tenvn = txtTenNV.Text;
            
            string ngaysinh = Convert.ToDateTime(txtNgaySinh.Text).ToString("MM/dd/yyyy");
            string gioitinh = txtGioiTinh.Text;
            string chucvu = txtChucVu.Text;
            string diachi = txtDiaChi.Text;

            if (ThemNhanVienDAO.Instance.InsertNhanVien(manv, tenvn, ngaysinh, gioitinh, chucvu, diachi))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!\n Lưu ý: Mã nhân phải khác nhân viên trong danh sách!");
            }
            LoadNhanVien();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            if (ThemNhanVienDAO.Instance.DeleteNhanVien(manv))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại!");
            }
            LoadNhanVien();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tenvn = txtTenNV.Text;
            string ngaysinh = txtNgaySinh.Text.Split(' ')[0];
            string gioitinh = txtGioiTinh.Text;
            string chucvu = txtChucVu.Text;
            string diachi = txtDiaChi.Text;


            if (ThemNhanVienDAO.Instance.EditNhanVien(manv, tenvn, ngaysinh, gioitinh, chucvu, diachi))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên thất bại!");
            }
            LoadNhanVien();
        }
    }
}
