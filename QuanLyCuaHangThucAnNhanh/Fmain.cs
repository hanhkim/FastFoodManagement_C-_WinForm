
using QuanLyCuaHangThucAnNhanh.DAO;
using QuanLyCuaHangThucAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;//Sử dụng thư viện này để làm việc với Stream


namespace QuanLyCuaHangThucAnNhanh
{
    // Định nghĩa giá trị
    
    public partial class fmain : Form
    {
        //public string connect = "Data Source=DESKTOP-8IAU9DP;Initial Catalog = QUAN_LY_CUA_HANG_THUC_AN_NHANH; Integrated Security = True";
        string vitri0 = "Trong nhà";
        string vitri1 = "Tầng một";
        string vitri2 = "Tầng hai";
        string vitri3 = "Phòng Vip";

        public fmain(string[] arr)
        {
            InitializeComponent();
            int width = lvHoaDon.Width / 4;
            lvHoaDon.Columns.Add("Tên món", width + 30);
            lvHoaDon.Columns.Add("Số lượng", width - 30);
            lvHoaDon.Columns.Add("Đơn giá", width);
            lvHoaDon.Columns.Add("Thành tiền", width);
            // textbox tiêu đề vị trí
            loadTextBox();
            // load button bàn ăn
            loadTable();
            // load combobox loại sản ph
            //loadLoaiSP();

            // GetListCategory();
            txtdisplay.Text = arr[4] +": "+ arr[3];
            
            if (arr[4] == "Quản Lý")
                tàiKhoảnToolStripMenuItem.Enabled = false;
            else
                adminToolStripMenuItem.Enabled = false;
        }

        void loadTextBox()
        {
            for (int i = 0; i <= 3; i++)
            {
                TextBox txb = new TextBox() { Width = 350, Height = 30, BackColor = Color.BlanchedAlmond };
                if (i == 0)
                {
                    txb.Text = "Khu vực: " + vitri0;
                    flpTrongNha.Controls.Add(txb);
                }
                if (i == 1)
                {
                    txb.Text = "Khu vực: " + vitri1;
                    flpTangMot.Controls.Add(txb);
                }
                if (i == 2)
                {
                    txb.Text = "Khu vực: " + vitri2;
                    flpTanghai.Controls.Add(txb);
                }
                if (i == 3)
                {
                    txb.Text = "Khu vực: " + vitri3;
                    flpVip.Controls.Add(txb);
                }
            }
        }

        void refreshFLV()
        {
            flpTrongNha.Controls.Clear();
            flpVip.Controls.Clear();
            flpTangMot.Controls.Clear();
            flpTanghai.Controls.Clear();
            loadTextBox();
        }


        void loadTable()
        {
            refreshFLV();
            List<Table> tableList = TableDAO.Instance.Load_Table_List();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                //btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.Text = item.tenban + "\n" + item.tinhtrang;
                if (item.tinhtrang == "Trống")
                {
                    //btn.BackgroundImage = Properties.Resources.trong;
                    btn.BackColor = Color.Aqua;
                }
                else
                {
                    //btn.BackgroundImage = Properties.Resources.i1;
                    btn.BackColor = Color.Red;
                }
                // tạo event khi click chuột vào button
                btn.Click += Btn_Click;
                btn.Tag = item;
                // xét vị trí và add btn vào flowlayoutpanel phù hợp
                if (item.vitri == vitri0)
                {
                    flpTrongNha.Controls.Add(btn);
                }
                else if (item.vitri == vitri1)
                {
                    flpTangMot.Controls.Add(btn);
                }
                else if (item.vitri == vitri2)
                {
                    flpTanghai.Controls.Add(btn);
                }
                else if (item.vitri == vitri3)
                {
                    flpVip.Controls.Add(btn);
                }
            }
        }
        // load dữ liệu vào txt khách hàng
        void ThongTinKhachHang(string mahd)
        {
            //Connect vào sql
            using (SqlConnection connection = new SqlConnection(DAO.DataProvider.Instance.ConnectionStr))
            {
                connection.Open();
                //Truy vấn tới server
                string query = "select * from KHACHHANG where MAHOADON = '" + mahd + "'";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //CHO VÀO DATATABLE
                da.Fill(dt);

                //txtTenKH.DisplayMember = "TENLOAISP";
                //txtTenKH.DataSource = da;
                connection.Close();
                if (dt.Rows.Count > 0)
                {
                    txtTenKH.Text = dt.Rows[0]["TenKH"].ToString().Trim();
                    txtSDT.Text = dt.Rows[0]["SDT"].ToString().Trim();
                }
            }
        }

        void ThongTinNhanVien(string mahd)
        {
            //Connect vào sql
            using (SqlConnection connection = new SqlConnection(DAO.DataProvider.Instance.ConnectionStr))
            {
                connection.Open();
                //Truy vấn tới server
                string query = "select * from KHACHHANG where MAHOADON = '" + mahd + "'";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //CHO VÀO DATATABLE
                da.Fill(dt);

                //txtTenKH.DisplayMember = "TENLOAISP";
                //txtTenKH.DataSource = da;
                connection.Close();
                if (dt.Rows.Count > 0)
                {
                    txtTenKH.Text = dt.Rows[0]["TenKH"].ToString().Trim();
                    txtSDT.Text = dt.Rows[0]["SDT"].ToString().Trim();
                }
            }
        }
        //==================================================================
        // event when you click in the button
        private void Btn_Click(object sender, EventArgs e)
        {
            lbtenban.Text = "";
            //(sender as Button).BackColor = Color.DarkBlue;
            string vitri = ((sender as Button).Tag as Table).vitri;
            string MaBanAn = ((sender as Button).Tag as Table).maban;
            string tenban = ((sender as Button).Tag as Table).tenban;
            lbtenban.Text += "Chi Tiết Hóa Đơn " + tenban+" - "+vitri;
            lvHoaDon.Tag = (sender as Button).Tag;
            Table tb = lvHoaDon.Tag as Table;
            if (tb.tinhtrang == "Trống")
            {
                txtTenKH.Text = "";
                txtSDT.Text = "";
            }
            else
                ThongTinKhachHang(HoaDonDAO.Instance.getMaHDByTable(tb.maban, tb.vitri));

            HienThiHoaDon(MaBanAn, vitri);
        }

        // show bill khi click vào button
        void HienThiHoaDon(string MaBanAn, string vitri)
        {
            float tongtien = 0;
            lvHoaDon.Items.Clear();
            List<DTO.Menu> DSHoaDon = MenuDAO.Instance.GetListMenuByTable(MaBanAn, vitri);
            foreach (DTO.Menu item in DSHoaDon)
            {
                ListViewItem lvItem = new ListViewItem(item.TENSP.ToString());
                lvItem.SubItems.Add(item.SOLUONG.ToString());
                lvItem.SubItems.Add(item.DONGIA.ToString());
                lvItem.SubItems.Add(item.THANHTIEN.ToString());
                tongtien += item.THANHTIEN;
                lvHoaDon.Items.Add(lvItem);
            }  
            
            txbTongTien.Text = tongtien.ToString();
            
        }
        //==================================================================
        //Thêm sản phẩm vào Hóa đơn



        // sử dụng tạm (Bài 11)
        public SqlDataReader dr;
        //------------------ bắt sự kiện cho 2 cbx danh mục sp và tên sản phẩm------------------------------------------------- 
        // cbx1. load danh mục thức ăn
        public void GetListCategory()
        {
            string query = "select * from LOAISP";
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(DAO.DataProvider.Instance.ConnectionStr))
            {
                List<Category> listCategory = CategoryDAO.Instance.GetListCategoryByTable();

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                dr = command.ExecuteReader();

                data.Load(dr);

                cbxLoaiSP.DisplayMember = "TENLOAISP";
                cbxLoaiSP.DataSource = data;
                connection.Close();
            }
        }

        ///////////////////////////////////////
        // cbx2 load tên sản phẩm theo danh mục thức ăn được chọn
        void loadFoodListByLoaiSP(string MLSP)
        {
            cbxSanPham.ResetText();
            
            string query = @"select sp.MASP, sp.tensp from SANPHAM sp where MALOAISP='"+ MLSP + @"'";
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(DAO.DataProvider.Instance.ConnectionStr))
            {
               // List<SanPham> listSanPham = SanPhamDAO.Instance.GetListProductByTable(MLSP);

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                dr = command.ExecuteReader();
                data.Load(dr);

                cbxSanPham.DataSource =data;
                cbxSanPham.DisplayMember = "TENSP";
                
                connection.Close();
            }

        }

        bool isLoadData = false;
        private void cbxLoaiSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoadData == false) return;
            string maloaisp = "";
            DataRowView dtrv = cbxLoaiSP.SelectedValue as DataRowView;
            object[] a = dtrv.Row.ItemArray;
            maloaisp = (string)a[0];

            loadFoodListByLoaiSP(maloaisp);
        }

        private void cbxLoaiSP_Click(object sender, EventArgs e)
        {
            GetListCategory();
            isLoadData = true;
        }
        //---------------------------------------------------------------------


        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Table tb = lvHoaDon.Tag as Table;
            string mahoadon = HoaDonDAO.Instance.getMaHDByTable(tb.maban, tb.vitri);
            string maban = tb.maban.ToString();
            string vitri = tb.vitri.ToString();
            string CTmaHD = HoaDonDAO.Instance.getCTmaHD();
            // nhập tên khách hàng
            string tenKH = "";
            string sdt = "";
            if (tb.tinhtrang == "Trống")
            {

                {
                    tenKH = txtTenKH.Text;
                    sdt = txtSDT.Text;
                    if (tenKH == "" || sdt == "")
                    {
                        MessageBox.Show("Phải nhập tên và số điện thoại của khách hàng", "Thông báo");
                        return;
                    }
                }
            }


            // lấy masp từ cbx
            string masp = "";
            {
                if (isLoadData == false) return;
                DataRowView dtrv = cbxSanPham.SelectedValue as DataRowView;
                object[] a = dtrv.Row.ItemArray;
                masp = (string)a[0];
            }
            int soluong = int.Parse(nmSoLuong.Text);

            if (mahoadon == null)
            {
                mahoadon = HoaDonDAO.Instance.getHoaDon();
                HoaDonDAO.Instance.InsertHoaDon(mahoadon, maban, vitri);
                HoaDonInfoDAO.Instance.InsertHoaDonInfo(CTmaHD, mahoadon, masp, soluong);
            }
            else
                HoaDonInfoDAO.Instance.InsertHoaDonInfo(CTmaHD, mahoadon, masp, soluong);

            int kq = -1;

            if (tb.tinhtrang == "Trống")
            {
                //string query = string.Format("insert into KHACHHANG(TenKH, SDT, MAHD) values ( N'{0}', '{1}', {2}) ", tenKH, sdt, mahoadon);
                kq = khachHangDAO.Instance.InsertNhanVien(tenKH, sdt, mahoadon);
                TableDAO.instance.updateSatus(tb.maban, tb.vitri);
            }

            HienThiHoaDon(maban, vitri);
            loadTable();
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            flogin login = new flogin();
            login.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            flogin login = new flogin();
            login.ShowDialog();
            this.Show();
        }

        private void bntGiamGia_Click(object sender, EventArgs e)
        {
            

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = lvHoaDon.Tag as Table;

            string mahoadon = HoaDonDAO.Instance.getMaHDByTable(table.maban, table.vitri);
            int giamgia = (int)nmGiamGia.Value;

            if (mahoadon != null)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn bàn " + table.tenban, "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    float tien = float.Parse(txbTongTien.Text.Split(',')[0]);
                    if (giamgia>0)
                    {
                            float a =tien - (tien * giamgia / 100);
                            MessageBox.Show("Hóa đơn của bạn được giảm " + giamgia + "%\n Tổng số tiền bạn phải trả là: " + a.ToString(), "Thông Báo");
                    }
                    else
                    { MessageBox.Show("Tổng số tiền bạn phải trả là: " + tien.ToString(), "Thông Báo"); }
                    HoaDonDAO.Instance.CheckOut(mahoadon, giamgia);
                    HienThiHoaDon(table.maban, table.vitri);
                    loadTable();
                }
            }
            lvHoaDon.Refresh();
        }

        private void mónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonAn f = new MonAn();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void fmain_Load(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemNhanVien f = new ThemNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void theoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDonHang f = new ThongKeDonHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void theoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDHTheoKhachHang f = new ThongKeDHTheoKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QL_TaiKhoan f = new QL_TaiKhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void aboutTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nhóm 12 (lớp 3):" + Environment.NewLine
                             + "Nguyễn Khánh Hòa (1512182): Nhóm trưởng." + Environment.NewLine
                             + "Chu Minh Đức (1512119)" + Environment.NewLine
                             + "Lê Thị Kim Hạnh (1512148)" + Environment.NewLine
                             + "Nguyễn Văn Hoàn (1512183)" + Environment.NewLine
                             + "Lê Văn Hưng (1512221)" + Environment.NewLine, "Team 4HD");
        }

        private void aboutVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang dùng phần mềm quản lý cửa hàng thức ăn nhanh verson 1.0 do nhóm 4HD thực hiện", "Version");
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau(label1.Text, label5.Text);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đổiMậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau(label1.Text, label5.Text);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
       






  
