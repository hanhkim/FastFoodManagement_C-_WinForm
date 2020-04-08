using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangThucAnNhanh.DAO
{
    public class DataProvider
    {
        public static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }
            set { DataProvider.instance = value; }
        }

        public string ConnectionStr { get => connectionStr; set => connectionStr = value; } //m ddongs goi kieu nay la no se tro thanh cai bien toan cu het r
        //cái đóng góa là để chuột lên  cái biến cần đóng góp rồi bấm ctrl + R + E
        public DataProvider() { }

        private string connectionStr;//= @"Data Source=DESKTOP-8IAU9DP;Initial Catalog=QUAN_LY_CUA_HANG_THUC_AN_NHANH;Integrated Security=True";

        public DataTable ExcuteQuery(string Query, object[] parameter = null)
        {
            
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                if (parameter != null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) 
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
                return data;
            }
        }

        // trả ra số dòng có kq là thành công
        public int subExcuteNonQuery(string Query)
        {
            int data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(Query, connection);
                    data = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thất bại!");
            }
            return data;
        }

        // đếm số lượng bộ
        public object ExecuteScalar(string Query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                if (parameter != null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@')) 
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
                return data;
            }
        }

    }
}
