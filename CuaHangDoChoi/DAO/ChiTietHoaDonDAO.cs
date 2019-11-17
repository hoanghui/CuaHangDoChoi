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

        public void InsertChiTietHoaDon(int maHoaDon, int maSanPham, float donGia, int soLuong)
        {
            DataProvider.Instance.ExecuteNonQuery("InsertChiTietHoaDon @maHoaDon , @maSanPham , @donGia , @soLuong", new object[] { maHoaDon, maSanPham, donGia, soLuong });
        }
    }
}
