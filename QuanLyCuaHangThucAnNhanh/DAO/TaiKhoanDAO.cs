//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using QuanLyCuaHangThucAnNhanh.DTO;

//namespace QuanLyCuaHangThucAnNhanh.DAO
//{
//    public class TaiKhoanDAO
//    {
//        private static TaiKhoanDAO instance;

//        public static TaiKhoanDAO Instance
//        {
//            get
//            {
//                if (instance == null) instance = new TaiKhoanDAO();
//                return instance;
//            }
//            set { TaiKhoanDAO.instance = value; }
//        }
//        //public TaiKhoanDAO() { }



//        private List<TaiKhoan> taikhoan = new List<TaiKhoan>();
//        public TaiKhoan AC; //chỉ public 1 accout
//        public TaiKhoanDAO()//ham khoi tao la ham load data
//        {
//            string query = "select * from dangnhap";
//            DataTable data = DataProvider.Instance.ExcuteQuery(query);
//            foreach (DataRow item in data.Rows)
//            {
//                TaiKhoan ac = new TaiKhoan(item);
//                this.taikhoan.Add(ac);
//            }
//        }
//        public bool Login(string user, string pass)
//        {
//            foreach (TaiKhoan item in this.taikhoan)
//            {
//                if (user == item.TenDangNhap && pass == item.PassWord) //kiểm tra tên đăng nhập và mật khẩu
//                {
//                    AC = item;//lấy accout hiện tại ra
//                    return true;
//                }
//            }
//            return false;
//        }

//        public DataTable AccData()
//        {
//            DataTable result = new DataTable();

//            result.Columns.Add("TenDangNhap", typeof(string));
//            result.Columns.Add("MatKhau", typeof(string));
//            result.Columns.Add("TenNhanVien", typeof(string));
//            result.Columns.Add("ChucVu", typeof(string));
//            result.Columns.Add("MaNhanVien", typeof(string));

//            foreach (TaiKhoan ac in taikhoan)
//            {
//                result.Rows.Add(ac., ac.PassWord, ac.DisPlayName, ac.ChucVu, ac.Type);
//            }
//            return result;
//        }
//        public bool CheckAcount(string userName)
//        {
//            //nếu userName đã tồn tại thì tạo ko đc
//            foreach (Account a in account)
//            {
//                if (a.UserName == userName)
//                {
//                    return false;
//                }
//            }
//            return true;
//        }
//        public Account GetAccount(string userName)
//        {
//            foreach (Account a in account)
//            {
//                if (a.UserName == userName)
//                {
//                    return a;
//                }
//            }
//            return null;
//        }
//    }
//}
