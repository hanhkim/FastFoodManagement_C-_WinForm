using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
    public class Menu
    {
        public string TENSP;
        public float THANHTIEN;
        public int SOLUONG;
        public  float DONGIA;

        public Menu(string tenmonan, int soluong, float dongia, float thanhtien)
        {
            this.TENSP = tenmonan;
            this.SOLUONG = soluong;
            this.DONGIA = dongia;
            this.THANHTIEN = thanhtien;
        }

        public Menu(DataRow row)
        {
            this.TENSP = row["TENSP"].ToString();
            this.SOLUONG = (int)row["SOLUONG"];
            this.DONGIA = (float)Convert.ToDouble(row["DONGIA"].ToString());
            this.THANHTIEN = (float)Convert.ToDouble(row["THANHTIEN"].ToString());
        }

    }
}
