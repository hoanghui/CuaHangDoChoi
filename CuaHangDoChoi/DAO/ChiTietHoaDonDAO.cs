using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        public static ChiTietHoaDonDAO Instance
        {
            get 
            {
                if (instance == null)
                    instance = new ChiTietHoaDonDAO();
                return ChiTietHoaDonDAO.instance;
            }
            private set { ChiTietHoaDonDAO.instance = value; }
        }

        private ChiTietHoaDonDAO() { }

        public List<ChiTietHoaDon> layCTHD(int id)
        {
            List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ChiTietHoaDon WHERE maHoaDon = " + id);

            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDon chiTiet = new ChiTietHoaDon(item);
                cthd.Add(chiTiet);
            }

            return cthd;
        }

        public bool themChiTietHoaDon(int maHoaDon, int maSanPham, float donGia, int soLuong)
        {
            string query = "INSERT INTO dbo.ChiTietHoaDon VALUES(" + maHoaDon + "," + maSanPham + "," + donGia + "," + soLuong + ")";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
