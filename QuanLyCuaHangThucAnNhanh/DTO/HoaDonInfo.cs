using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
    public class HoaDonInfo
    {
        public HoaDonInfo(DataRow row)
        {
            this.MactHoaDon = row["macthoadon"].ToString();
            this.MaHoaDon = row["mahoadon"].ToString();
            this.MaSanPham = row["masp"].ToString();
            this.SoLuong = (int)row["soluong"];
        }


        public HoaDonInfo(string macthoadon, string mahoadon, string masp, int soluong)
        {
            this.MactHoaDon = macthoadon;
            this.MaHoaDon = mahoadon;
            this.MaSanPham = masp;
            this.SoLuong = soluong;

        }

        public string MactHoaDon;
        public string MaHoaDon;
        public string MaSanPham;
        public int SoLuong;




    }
}
