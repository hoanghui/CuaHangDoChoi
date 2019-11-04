using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoanDAO
    {
        //biến singleton, khởi tạo 1 lần duy nhất
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set => instance = value;
        }

        private TaiKhoanDAO() { }

        public TaiKhoan layTaiKhoan(string tenDangNhap)
        {
            string query = "SELECT * FROM dbo.TaiKhoan WHERE tenDangNhap= '" + tenDangNhap + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                return new TaiKhoan(row);
            }
            return null;
        }
    }
}
