using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonDAO();
                return instance;
            }
            set { HoaDonDAO.instance = value; }
        }

        public HoaDonDAO() { }

        //// đang chỉnh sửa ở bài số 9//21:50
        // getuncheckBillByTableID(int id)
        public string getMaHDByTable(string maban, string vitri)
        {
            string query = "select * from HOADON where MABAN ='" + maban + "' and CHECKOUT is null and vitri=N'" + vitri +"'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd.MaHoaDon;
            }
            else return null;
        }

        public string getViTriUncheckBillByTable(string maban, string vitri)
        {
            string query = "select * from HOADON where MABAN ='" + maban + "' and VITRI= '" + vitri + "' and CHECKOUT is null";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd.ViTri;
            }

            return null;
        }

        public void InsertHoaDon(string mahoadon, string maban, string vitri)
        {
            string q = @"DECLARE @return_value int EXEC @return_value = [USP_InsertBill] @maHD ='"+mahoadon+ @"',@MABAN = '"+ maban +@"',@VITRI = N'"+vitri+ @"'";
            DataProvider.Instance.subExcuteNonQuery(q);
        }

        public string getHoaDon()
        {
            string mahoadon = "HD";
            string query = "select count(*) from HOADON";
            int num = 1;
            num+=(int)DataProvider.Instance.ExecuteScalar(query);
            if (num < 10)
                mahoadon += "00" + num.ToString();
            else
                if (num >= 10 && num < 100)
                mahoadon += "0" + num.ToString();
            else
                mahoadon += num.ToString();
            return mahoadon;
        }

        public string getCTmaHD()
        {
            string CTMaHD = "BL";
            string query = "select count(*) from THONGTINCHITIETHOADON";
            int num = 1;
            num+=(int)DataProvider.Instance.ExecuteScalar(query);
            if (num < 10)
                CTMaHD += "00" + num.ToString();
            else
                if (num >= 10 && num < 100)
                CTMaHD += "0" + num.ToString();
            else
                CTMaHD += num.ToString();
            return CTMaHD;
        }


        public void CheckOut(string mahd, int giamgia)
        {
            string query = "update HOADON set CHECKOUT=getdate(), TINHTRANG = N'Đã thanh toán', GIAMGIA = '" + giamgia.ToString() + "' where MAHOADON = '" + mahd+"'" ;
            DataProvider.Instance.subExcuteNonQuery(query);
        }

    }   
}
