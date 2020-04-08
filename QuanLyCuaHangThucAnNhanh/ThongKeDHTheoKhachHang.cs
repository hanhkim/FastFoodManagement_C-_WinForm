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
    public partial class ThongKeDHTheoKhachHang : Form
    {
        BindingSource ThongKe = new BindingSource();
        public ThongKeDHTheoKhachHang()
        {
            // khai bao câu  query để load form thống kê. từ câu query này. gán lại giá trị query để lấy database lên datagridview

            InitializeComponent();
            // load datagridview thong ke
            dtgThongKe.DataSource = ThongKe;
            string query = "select kh.TenKH N'Tên Khách Hàng', kh.SDT N'Số Điện Thoại', hd.CHECKIN N'Check In', hd.CHECKOUT 'Check Out', tb.TENBAN + ' ' + tb.VITRI as N'Vị Trí' ,sp.TENSP N'Tên Sản Phẩm', info.SOLUONG N'Số Lượng', (sp.DONGIA*info.SOLUONG)- (sp.DONGIA*info.SOLUONG)*hd.GIAMGIA/100 as N'Thành Tiền' from KHACHHANG KH, HOADON hd, THONGTINCHITIETHOADON info, TABLEINFO tb , SANPHAM sp where  kh.MAHOADON=hd.MAHOADON and hd.MAHOADON=info.MAHOADON and tb.MABAN=hd.MABAN and tb.VITRI=hd.VITRI and sp.MASP=info.MASP and hd.TINHTRANG=N'Đã thanh toán'";

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
            txtCheckIn.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Check In", true, DataSourceUpdateMode.Never));
            txtViTri.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Vị Trí", true, DataSourceUpdateMode.Never));
            txtCheckOut.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Check Out", true, DataSourceUpdateMode.Never));
            txtThanhTien.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Thành Tiền", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Số Lượng", true, DataSourceUpdateMode.Never));
            txtTenSP.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Tên Sản Phẩm", true, DataSourceUpdateMode.Never));
            txtTenKH.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Tên Khách Hàng", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dtgThongKe.DataSource, "Số Điện Thoại", true, DataSourceUpdateMode.Never));
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            //AddBinding();
        }

        private void btThongKe_Click_1(object sender, EventArgs e)
        {
            string NgayBD, NgayKT;

            NgayBD = dtBatDau.Value.ToString("MM/dd/yyyy").Split(' ')[0];
            NgayKT = dtKetThuc.Value.ToString("MM/dd/yyyy").Split(' ')[0];

            string query = string.Format("select kh.TenKH N'Tên Khách Hàng', kh.SDT N'Số Điện Thoại', hd.CHECKIN N'Check In', hd.CHECKOUT 'Check Out', tb.TENBAN + ' ' + tb.VITRI as N'Vị Trí' ,sp.TENSP N'Tên Sản Phẩm', info.SOLUONG N'Số Lượng', (sp.DONGIA*info.SOLUONG)- (sp.DONGIA*info.SOLUONG)*hd.GIAMGIA/100 as N'Thành Tiền' from KHACHHANG KH, HOADON hd, THONGTINCHITIETHOADON info, TABLEINFO tb , SANPHAM sp where  kh.MAHOADON=hd.MAHOADON and hd.MAHOADON=info.MAHOADON and tb.MABAN=hd.MABAN and tb.VITRI=hd.VITRI and sp.MASP=info.MASP and hd.TINHTRANG=N'Đã thanh toán' and hd.CHECKIN<=hd.CHECKOUT and hd.CHECKIN>='{0}' and hd.CHECKOUT<='{1}'", NgayBD, NgayKT);
            loadForm(query);
        }
    }
}
