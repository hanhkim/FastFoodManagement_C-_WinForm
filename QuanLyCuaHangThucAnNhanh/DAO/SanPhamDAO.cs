using QuanLyCuaHangThucAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
        public class SanPhamDAO
        {
            private static SanPhamDAO instance;

            public static SanPhamDAO Instance
            {
                get
                {
                    if (instance == null) instance = new SanPhamDAO();
                    return instance;
                }
                set { SanPhamDAO.instance = value; }
            }

            public object Menulist { get; private set; }

            public SanPhamDAO() { }

        public List<SanPham> GetListProductByTable(string MLSP)
        {
            string query = "select * from SANPHAM where MALOAISP= '" + MLSP + "'"; //where MALOAISP= '"+ MLSP + "'
            List<SanPham> list = new List<SanPham>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SanPham sp = new SanPham(item);
                list.Add(sp);
            }
            return list;

        }


        public void ThemSP(string masp, string tensp, int dongia, string maloaisp)
        {
            string query = string.Format("insert SANPHAM (MASP, TENSP, DONGIA, MALOAISP) values('{0}', N'{1}',{2}, '{3}')",masp,tensp,dongia,maloaisp);
            int kq = DataProvider.Instance.subExcuteNonQuery(query);
        }

        /// hạnh code
        public bool InsertFood(string maSP, string tenSP, string maLoaiSP, int donGia)
        {
            string query = string.Format("insert into SANPHAM(MASP, TENSP, MALOAISP, DONGIA) values ( N'{0}', N'{1}', N'{2}', {3})",
                                                            maSP, tenSP, maLoaiSP, donGia);
            int result = DataProvider.Instance.subExcuteNonQuery(query);


            return result > 0;
        }

        public bool EditFood(string maSP, string tenSP, string maLoaiSP, int donGia)
        {
            string query = string.Format("update SANPHAM set TENSP= N'{0}' , MALOAISP = N'{1}', DONGIA = {2} where MASP = N'{3}'",
                                                             tenSP, maLoaiSP, donGia, maSP);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(string maSP)
        {
            string query = string.Format("DELETE SANPHAM where MASP = N'{0}'", maSP);
            int result = DataProvider.Instance.subExcuteNonQuery(query);

            return result > 0;
        }


    }

}
