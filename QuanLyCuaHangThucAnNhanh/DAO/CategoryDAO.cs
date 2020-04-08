using QuanLyCuaHangThucAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private string connectionStr;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }
            set { CategoryDAO.instance = value; }
        }

        public object Menulist { get; private set; }

        public CategoryDAO() { }

        public List<Category> GetListCategoryByTable()
        {
            string query = "SELECT * FROM LOAISP";
            List<Category> list = new List<Category>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }

        ////////////////////////////////////////////////
        // sử dụng cbx.displaymember
        //        public SqlDataReader dr;
        //        private object cbxLoaiSP;

        //        public void GetListCategory()
        //        {
        //            string query = "select * from LOAISP";
        //            DataTable data = new DataTable();

        //            using (SqlConnection connection = new SqlConnection(connectionStr))
        //            {
        //                connection.Open();
        //                SqlCommand command = new SqlCommand(query, connection);
        //                dr = command.ExecuteReader();
        //                data.Load(dr);
        //                cbxLoaiSP.DisplayMember = "TENLOAISP";

        //                connection.Close();
        //            }
        //        }
        //}

    }

}