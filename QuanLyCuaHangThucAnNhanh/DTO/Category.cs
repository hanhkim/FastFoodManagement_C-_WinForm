using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
    public class Category
    {
        public string TenSP { get; set; }
        public string MaLoaiSP { get; set; }

        public Category(string maloaisp, string tensp)
        {
            this.TenSP = tensp;
            this.MaLoaiSP = maloaisp;
        }

        public Category(DataRow row)
        {
            this.MaLoaiSP = row["MALOAISP"].ToString();
            this.TenSP = row["TENLOAISP"].ToString();            
        }
    }
}
