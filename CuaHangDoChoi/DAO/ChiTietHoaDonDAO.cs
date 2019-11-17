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
            
            if (maHoaDon < 0)
            {
                return false;
            }
            else
            {
                List<ChiTietHoaDon> ds = new List<ChiTietHoaDon>();
                string query = "SELECT * FROM dbo.ChiTietHoaDon WHERE maHoaDon= " + maHoaDon + "";
                DataTable table = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    ds.Add(new ChiTietHoaDon(row));
                }
                int result = ds.Count;

                if (result == 0)
                {
                    string query2 = "INSERT INTO dbo.ChiTietHoaDon VALUES(" + maHoaDon + "," + maSanPham + "," + donGia + "," + soLuong + ")";
                    int result2 = DataProvider.Instance.ExecuteNonQuery(query2);
                    return result2 > 0;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
