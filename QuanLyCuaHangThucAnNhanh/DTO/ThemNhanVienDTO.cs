using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
    class ThemNhanVienDTO
    {
        public string Manv;
        public string TenNV;
        public string NgaySinh;
        public string GioiTinh;
        public int Chucvu;
        public string DiaChi;

        

        public ThemNhanVienDTO(string manv, string tenvn, string ngaysinh, string gioitinh, int chucvu, string diachi)
        {
            this.Manv = manv;
            this.TenNV = tenvn;
            this.NgaySinh = ngaysinh;
            this.Chucvu = chucvu;
            this.GioiTinh = gioitinh;
            this.DiaChi = diachi;
        }

        public ThemNhanVienDTO(DataRow row)
        {
            this.Manv = row["MASP"].ToString();
            this.TenNV = row["TENSP"].ToString();
            this.NgaySinh = row["MALOAISP"].ToString();
            this.GioiTinh = row["TENSP"].ToString();
            this.DiaChi = row["MALOAISP"].ToString();
            this.Chucvu = (int)row["TENSP"];
        }
    }
}
