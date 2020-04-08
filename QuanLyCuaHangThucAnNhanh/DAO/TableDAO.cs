using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyCuaHangThucAnNhanh.DTO;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    public class TableDAO
    {
        public static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableDAO();
                return TableDAO.instance;
            }
            set { TableDAO.instance = value; }
        }

        //public static int TableHeight { get; internal set; }

        public static int TableWidth = 80;
        public static int TableHeight = 80;

        private TableDAO() { }
        public List<Table> Load_Table_List()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_loadTable");
            foreach(DataRow item in data.Rows)
            {
                Table table= new Table(item);
                tablelist.Add(table);
            }

            return tablelist;
        }

        public void updateSatus(string maban, string vitri)
        {
            string query = string.Format("update TABLEINFO set TINHTRANG=N'Có người' where MABAN='{0}' and VITRI=N'{1}'",maban, vitri);
            int result = DataProvider.Instance.subExcuteNonQuery(query);
        }

    }

}
