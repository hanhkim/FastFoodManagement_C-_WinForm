using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyCuaHangThucAnNhanh.DTO
{
   public class Table
    {
        public Table(string MaBan,string ViTri, string TenBan, string tinhtrang)
        {
            this.maban = MaBan;
            this.vitri = ViTri;
            this.tenban = TenBan;
            this.tinhtrang = tinhtrang;
        }
        public string maban;
        public string vitri;
        public string tenban;
        public string tinhtrang;

        public Table(DataRow data)
        {
            this.maban = data["maban"].ToString();
            this.vitri = data["vitri"].ToString();
            this.tenban = data["tenban"].ToString();
            this.tinhtrang = data["tinhtrang"].ToString();
        }


    }
}
