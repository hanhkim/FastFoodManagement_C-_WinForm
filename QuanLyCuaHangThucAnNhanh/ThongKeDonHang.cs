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
    public partial class ThongKeDonHang : Form
    {
        
        BindingSource ThongKe = new BindingSource();
        public ThongKeDonHang()
        {
            // khai bao câu  query để load form thống kê. từ câu query này. gán lại giá trị query để lấy database lên datagridview

            InitializeComponent();
            // load datagridview thong ke
            dtgThongKe.DataSource = ThongKe;
            string query = "select hd.mahoadon as N'Mã Hóa Đơn', info.MActHOADON as N'Chi Tiết Hóa Đơn', info.masp N'Mã Sản Phẩm', sp.TENSP N'Tên Sản Phẩm', sp.DONGIA 'Đơn Giá', info.SOLUONG 'Số Lượng', hd.GIAMGIA 'Giảm Giá', (sp.DONGIA*info.SOLUONG)- (sp.DONGIA*info.SOLUONG)*hd.GIAMGIA/100 as N'Thành Tiền' from HOADON hd, THONGTINCHITIETHOADON info, sanpham sp where hd.mahoadon= info.mahoadon and sp.masp=info.masp and hd.TINHTRANG=N'Đã thanh toán'";

            loadForm(query);
            AddBinding();
            dtBatDau.CustomFormat = "MM/dd/yyyy";
            dtKetThuc.CustomFormat = "MM/dd/yyyy";
            dtBatDau.Text = "01/01/2017";
            dtKetThuc.Text = "31/12/2017";            
        }

                 

        DataSet GetTableThongKe(string query)                           // Lấy danh sách 
        {
            DataSet data = new DataSet();

            
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8IAU9DP;Initial Catalog=QUAN_LY_CUA_HANG_THUC_AN_NHANH;Integrated Security=True"))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        void loadForm(string q)
        {
            string query = q;
            dtgThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //  dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ThongKe.DataSource = GetTableThongKe(query).Tables[0];
            
        }

        void AddBinding()
        {
            txtMaSP.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Mã Sản Phẩm", true, DataSourceUpdateMode.Never));
            txtDonGia.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Đơn Giá", true, DataSourceUpdateMode.Never));
            txtTenSP.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Tên Sản Phẩm", true, DataSourceUpdateMode.Never));
            txtThanhTien.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Thành Tiền", true, DataSourceUpdateMode.Never));
            txtGiamGia.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Giảm Giá", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Số Lượng", true, DataSourceUpdateMode.Never));
            txtMaHD.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Mã Hóa Đơn", true, DataSourceUpdateMode.Never));
            txtCTMaHd.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Chi Tiết Hóa Đơn", true, DataSourceUpdateMode.Never));
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
           
            string NgayBD, NgayKT;
           
            NgayBD = dtBatDau.Value.ToString("MM/dd/yyyy").Split(' ')[0];
            NgayKT = dtKetThuc.Value.ToString("MM/dd/yyyy").Split(' ')[0];
       
            string query =string.Format("select hd.mahoadon as N'Mã Hóa Đơn', info.MActHOADON as N'Chi Tiết Hóa Đơn', info.masp N'Mã Sản Phẩm', sp.TENSP N'Tên Sản Phẩm', sp.DONGIA 'Đơn Giá', info.SOLUONG 'Số Lượng', hd.GIAMGIA 'Giảm Giá', (sp.DONGIA*info.SOLUONG)- (sp.DONGIA*info.SOLUONG)*hd.GIAMGIA/100 as N'Thành Tiền' from HOADON hd, THONGTINCHITIETHOADON info, sanpham sp where hd.mahoadon= info.mahoadon and sp.masp=info.masp and hd.TINHTRANG=N'Đã thanh toán' and hd.CHECKIN<=hd.CHECKOUT and hd.CHECKIN>='{0}' and hd.CHECKOUT<='{1}'",NgayBD,NgayKT);
            loadForm(query);
            //AddBinding();
        }
    }
}
