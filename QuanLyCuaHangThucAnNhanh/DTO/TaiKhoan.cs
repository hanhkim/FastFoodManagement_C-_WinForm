using System;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
    public class TaiKhoan
    {
        private string TenDangNhap;
        private string TenNhanVien;
        private string MatKhau;
        private int MaNhanVien;
        private int ChucVu;

        public TaiKhoan(string tendangnhap, string tennhanvien, string matkhau, int manhanvien, int chucvu)
        {
            this.TenDangNhap = tendangnhap;
            this.TenNhanVien = tennhanvien;
            this.MatKhau = matkhau;
            this.MaNhanVien = manhanvien;
            this.ChucVu = chucvu;
        }
        public TaiKhoan(DataRow row)
        {
            this.TenDangNhap = row["TenDangNhap"].ToString();
            this.TenNhanVien = row["TenNhanVien"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.MaNhanVien = (int)row["MaNhanVien"];
            this.ChucVu = (int)row["ChucVu"];
        }
        
    
    }
}
