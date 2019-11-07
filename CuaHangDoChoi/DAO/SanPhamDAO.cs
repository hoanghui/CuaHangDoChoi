using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class SanPhamDAO
    {
        //biến singleton, khởi tạo 1 lần duy nhất
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            private set => instance = value;
        }

        private SanPhamDAO() { }

        // đổ data vào 
        public SanPham layMaSanPham(string maSanPham)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE maKhachHang= '" + maSanPham + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                return new SanPham(row);
            }
            return null;
        }

    }
}
