using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    // class phải để public để những cái khác có thể sử dụng
    public class KhachHangDAO
    {
        //biến singleton, khởi tạo 1 lần duy nhất
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set => instance = value;
        }

        private KhachHangDAO() {}

        // đổ data vào 
        public KhachHang layMaKhachHang(string maKhachHang)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE maKhachHang= '" + maKhachHang + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                return new KhachHang(row);
            }
            return null;
        }


    }
}
