using System;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    public class HoaDon
    {
        public HoaDon(DataRow row)
        {
            this.MaHoaDon = row["MaHoaDon"].ToString();
            this.CheckIn = (DateTime?)row["CheckIn"];
            var CheckOutTemp = row["CheckOut"];

            if (CheckOutTemp.ToString() != "")
                this.CheckOut = (DateTime?)CheckOutTemp;
            this.MaBan = row["MaBan"].ToString();
            this.TinhTrang = row["TinhTrang"].ToString();
            this.GiamGia = 0;// (int)row["GiamGia"];
            this.ViTri = row["ViTri"].ToString();

        }



        public HoaDon(string mahoadon, DateTime? checkin, DateTime? checkout, string maban,string vitri, string tinhtrang, int giamgia)
        {
            this.MaHoaDon = mahoadon;
            this.CheckIn = checkin;
            this.CheckOut = checkout;
            this.GiamGia = giamgia;
            this.ViTri = vitri;
            this.TinhTrang = tinhtrang;
            this.MaBan = maban;
        }

        public string MaBan;
        public string MaHoaDon;
        public DateTime? CheckIn;
        public DateTime? CheckOut;
        public int GiamGia;
        public string ViTri;
        public string TinhTrang;

      
    }
}