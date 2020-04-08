using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangThucAnNhanh.DTO;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    class khachHangDAO
    {
        private static khachHangDAO instance;

        public static khachHangDAO Instance
        {
            get
            {
                if (instance == null) instance = new khachHangDAO();
                return instance;
            }
            set { khachHangDAO.instance = value; }
        }

        public object Menulist { get; private set; }

        public khachHangDAO() { }

        public int InsertNhanVien(string tenKH, string sdt, string mahd)
        {
            string query = string.Format("insert into KHACHHANG(TenKH, SDT, MAHOADON) values ( N'{0}', '{1}', '{2}')", tenKH, sdt, mahd);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result;
        }


    }
}
