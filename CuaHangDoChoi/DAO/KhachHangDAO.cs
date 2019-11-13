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
       

        public List<KhachHang> LayDSKhachHang()
        {
            List<KhachHang> kh = new List<KhachHang>();
            string query = "SELECT * FROM dbo.KhachHang";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                kh.Add(new KhachHang(row));
            }
            return kh;
        }

        public bool SuaKH(int makhachhang, string hoten, int cmnd, int sdt, DateTime ngaysinh, string gioitinh, string diachi)
        {
            string query = "UPDATE dbo.KhachHang SET maKhachHang = " + makhachhang + ", hoTen = N'" + hoten + "', " +
                           "CMND = " + cmnd + ", soDienThoai = " + sdt + ", ngaySinh = '" + ngaysinh + "', gioiTinh = '" + gioitinh + "', diaChi = N'" + diachi + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
