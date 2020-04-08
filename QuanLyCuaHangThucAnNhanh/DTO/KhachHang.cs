using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
    class KhachHang
    {
        

        public int MaKH;
        public string TenKH;
        public string SDT;
        public string MaHD;

        public KhachHang(int makh, string tenkh, string sdt, string mahd)
        {
            this.MaKH = MaKH;
            this.TenKH = tenkh;
            this.SDT = sdt;
            this.MaHD = mahd;
        }

        public KhachHang(DataRow row)
        {
            this.MaKH = (int)row["MAKH"];
            this.TenKH = row["TENKH"].ToString();
            this.SDT = row["SDT"].ToString();
            this.MaHD = row["DONGIA"].ToString();
        }

    }
}
