using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class HoaDonDAO
    {
        //biến singleton, khởi tạo 1 lần duy nhất
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set => instance = value;
        }

        private HoaDonDAO() { }

        // đổ data vào 
        public HoaDon layHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE maKhachHang= '" + maHoaDon + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                return new HoaDon(row);
            }
            return null;
        }
    }
}
