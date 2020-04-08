using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangThucAnNhanh.DTO;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    class QL_TaiKhoanDAO
    {
        private static QL_TaiKhoanDAO instance;

        public static QL_TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null) instance = new QL_TaiKhoanDAO();
                return instance;
            }
            set { QL_TaiKhoanDAO.instance = value; }
        }

        public object Menulist { get; private set; }

        public QL_TaiKhoanDAO() { }







        public bool InsertTaiKhoan(string manv, string tennv,string tendangnhap, string matkhau, string chucvu)
        {
            string query = string.Format("insert into DANGNHAP( TENDANGNHAP, MATKHAU, TENNV, CHUCVU) values (  N'{0}', '{1}', N'{2}', '{3}')",
                                                             tendangnhap, matkhau, tennv, chucvu);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }

        public bool EditNhanVien(string manv, string tennv, string tendangnhap, string matkhau, string chucvu)
        {
            string query = string.Format("update DANGNHAP set  TENNV = N'{0}', TENDANGNHAP = '{1}', MATKHAU = N'{2}', CHUCVU = {3} where MANV = N'{4}'",
                                                             tennv, tendangnhap, matkhau, chucvu, manv);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTaiKhoan(string manv)
        {
            string query = string.Format("DELETE DANGNHAP where MANV = N'{0}'", manv);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }


    }
}
