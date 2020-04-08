using QuanLyCuaHangThucAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null) instance = new MenuDAO();
                return instance;
            }
            set { MenuDAO.instance = value; }
        }

        public object Menulist { get; private set; }

        public MenuDAO() { }

        public List<Menu> GetListMenuByTable(string MaBanAn, string vitri)
        {   
            string query = "SELECT SP.TENSP, HD_iF.SOLUONG, SP.DONGIA, SP.DONGIA* HD_iF.SOLUONG AS THANHTIEN FROM SANPHAM AS SP, HOADON AS HD, THONGTINCHITIETHOADON AS HD_iF WHERE HD.MAHOADON = HD_iF.MAHOADON AND HD_iF.MASP = SP.MASP AND HD.TINHTRANG =N'Chưa thanh toán' AND HD.MABAN = '" + MaBanAn + "'  AND HD.VITRI = N'" + vitri+"'";

            List<Menu> MenuList = new List<Menu>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                MenuList.Add(menu);
            }

            return MenuList;
        }
    }
}
