using QuanLyCuaHangThucAnNhanh.DTO;
using QuanLyCuaHangThucAnNhanh.DAO;
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
    public partial class MonAn : Form


    {
        BindingSource foodList = new BindingSource();       // biến binding lúc ấn button Xem 

        public MonAn()
        {
            InitializeComponent();
            

            dataGridView1.DataSource = foodList;

            LoadListFood();
            AddFoodBinding();

            LoadFoodCategoryIntoCombobox(cbCategory);

        }


        //------------------------------------- LOAD LIST FOODS --------------------------------------------     
        void AddFoodBinding()
        {
            txtMaSP.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Mã Sản Phẩm", true, DataSourceUpdateMode.Never));
            txtDonGia.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Đơn Giá", true, DataSourceUpdateMode.Never));
            txtTenSP.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Tên Sản Phẩm", true, DataSourceUpdateMode.Never));
            txtLoaiSP.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Mã Loại SP", true, DataSourceUpdateMode.Never));
        }

        void LoadListFood()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //  dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            foodList.DataSource = GetListFood().Tables[0];
        }

        DataSet GetListFood()                           // Lấy danh sách món ăn
        {
            DataSet data = new DataSet();

            string query = "select sp.MASP as N'Mã Sản Phẩm', sp.TENSP N'Tên Sản Phẩm', sp.DONGIA N'Đơn Giá', sp.MALOAISP N'Mã Loại SP' from SANPHAM sp";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8IAU9DP;Initial Catalog=QUAN_LY_CUA_HANG_THUC_AN_NHANH;Integrated Security=True"))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        // --------------------------------- LOAD CATEGORY : LOẠI MÓN ĂN ------------------------------------------

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void LoadFoodCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategoryByTable();

            cb.DisplayMember = "MALOAISP";
        }

        // ----------------------------- BẮT SỰ KIỆN BUTTON  -----------------------------------------------------
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        void cleartextbox()
        {
            txtTenSP.Text = null;
            txtMaSP.Text = null;
            txtMaSP.Text = null;
            txtDonGia.Text = null;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            //cleartextbox();
            //btnHoanTat.Enabled = true;
            string name = txtTenSP.Text;
            string maSP = txtMaSP.Text;
            string maLoaiSP = txtLoaiSP.Text;
            int donGia = Convert.ToInt32(txtDonGia.Text);


            if (SanPhamDAO.Instance.InsertFood(maSP, name, maLoaiSP, donGia))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!\n Lưu ý: Mã SP phải khác SP đã có!");
            }

        }

        

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            if (SanPhamDAO.Instance.DeleteFood(maSP))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Xóa món thất bại!");
            }
        }

        private void btnChinhSua_Click_1(object sender, EventArgs e)
        {
            //cleartextbox();
            string name = txtTenSP.Text;
            string maSP = txtMaSP.Text;
            string maLoaiSP = txtLoaiSP.Text;
            int donGia = Convert.ToInt32(txtDonGia.Text);


            if (SanPhamDAO.Instance.EditFood(maSP, name, maLoaiSP, donGia))
            {
                MessageBox.Show("Sửa món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Sửa món thất bại!");
            }
        }
    }
}
