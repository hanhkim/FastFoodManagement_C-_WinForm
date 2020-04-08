using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangThucAnNhanh.DTO;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    class ThemNhanVienDAO
    {
        private static ThemNhanVienDAO instance;

        public static ThemNhanVienDAO Instance
        {
            get
            {
                if (instance == null) instance = new ThemNhanVienDAO();
                return instance;
            }
            set { ThemNhanVienDAO.instance = value; }
        }

        public object Menulist { get; private set; }

        public ThemNhanVienDAO() { }







        public bool InsertNhanVien(string manv, string tennv, string ngaysinh, string gioitinh, string chucvu, string diachi)
        {
            string query = string.Format("insert into NHANVIEN(MANV, TENNV, NGAYSINH, GIOITINH, CHUCVU, DIACHI) values ( N'{0}', N'{1}', N'{2}', N'{3}', {4}, N'{5}')",
                                                             manv, tennv, ngaysinh, gioitinh, chucvu, diachi);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }

        public bool EditNhanVien(string manv, string tennv, string ngaysinh, string gioitinh, string chucvu, string diachi)
        {
            string query = string.Format("update NHANVIEN set MANV= N'{0}' , TENNV = N'{1}', NGAYSINH = '{2}', GIOITINH = N'{3}', CHUCVU = {4}, DIACHI = N'{5}' where MANV = N'{6}'",
                                                             manv, tennv, ngaysinh, gioitinh,chucvu, diachi, manv );
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteNhanVien(string manv)
        {
            string query = string.Format("DELETE NHANVIEN where MANV = N'{0}'", manv);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }


    }
}
