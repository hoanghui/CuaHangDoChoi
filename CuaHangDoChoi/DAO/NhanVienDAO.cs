using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class NhanVienDAO
    {
        //biến singleton, khởi tạo 1 lần duy nhất
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set => instance = value;
        }

        private NhanVienDAO() { }

        // đổ data vào 
        public NhanVien layMaNhanVien(string maNhanVien)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE maKhachHang= '" + maNhanVien+ "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                return new NhanVien(row);
            }
            return null;
        }


    }
}
