using QuanLyCuaHangThucAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    class HoaDonInfoDAO
    {
        private static HoaDonInfoDAO instance;

        public static HoaDonInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonInfoDAO();
                return instance;
            }
            set { HoaDonInfoDAO.instance = value; }
        }

        public HoaDonInfoDAO() { }

        public List<HoaDonInfo> GetListHoaDonInfo(string mahoadon)
        {

            string query= "SELECT * FROM THONGTINCHITIETHOADON where MActHOADON = '" + mahoadon + "'";

            List<HoaDonInfo> listhoadon = new List<HoaDonInfo>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoaDonInfo info = new HoaDonInfo(item);
                listhoadon.Add(info);
            }
            return listhoadon;
        }

        public void InsertHoaDonInfo(string CTmaHD, string mahoadon, string masp, int soluong)
        {
            string s = @"DECLARE	@return_value int EXEC	@return_value = USP_InsertBillInfo @CTmaHD = '"+ CTmaHD + @"' ,@MAHOADON ='"+ mahoadon +@"' ,@MASP='"+ masp + @"' ,	@SOLUONG ='"+ soluong.ToString() + @"'";
            DataProvider.Instance.subExcuteNonQuery(s);
        }

    }
}
