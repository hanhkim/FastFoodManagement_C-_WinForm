using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
    public class SanPham
    {
        public string MaSP;
        public string  TenSP;
        public string MaLoaiSP;
        public float DonGia;

        public SanPham(string masp, string tensp, string maloaisp, float dongia)
        {
            this.MaSP = masp;
            this.TenSP = tensp;
            this.MaLoaiSP = maloaisp;
            this.DonGia = dongia;
        }

        public SanPham(DataRow row)
        {
            this.MaSP = row["MASP"].ToString();
            this.TenSP = row["TENSP"].ToString();
            this.MaLoaiSP = row["MALOAISP"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["DONGIA"].ToString());
        }
         

    }
}
