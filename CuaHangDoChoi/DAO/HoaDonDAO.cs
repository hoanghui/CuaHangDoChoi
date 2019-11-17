using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDonDAO
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

        public int layhoadon(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HoaDon WHERE maNhanVien = " + id + "");

            if (data.Rows.Count > 0)
            {
                HoaDon hoaDon = new HoaDon(data.Rows[0]);
                return hoaDon.MaHoaDon;
            }
            return -1;
        }

        public List<HoaDon> LayDanhSachHoaDon()
        {
            List<HoaDon> hd = new List<HoaDon>();
            string query = "SELECT * FROM dbo.HoaDon";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                hd.Add(new HoaDon(row));
            }
            return hd;
        }

        public bool ThemHD(int maHD, int maKH, int maNV, DateTime ngayTao, float thanhTien )
        {
            if ( maNV <= 0)
            {
                return false;
            }
            else
            {
                List<HoaDon> ds = new List<HoaDon>();
                string query = "SELECT * FROM dbo.HoaDon WHERE maHoaDon= " + maHD + "";
                DataTable table = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    ds.Add(new HoaDon(row));
                }
                int result = ds.Count;
         
                if (result == 0)
                {
                    string query2 = "INSERT INTO dbo.HoaDon VALUES("+maHD+"," + maKH + "," + maNV + ",'" + ngayTao + "', " + thanhTien + ")";
                    int result2 = DataProvider.Instance.ExecuteNonQuery(query2);
                    return result2 > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public int layHDlonnhat()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(maHoaDon) FROM dbo.HoaDon");
            }
            catch
            {
                return 1;
            }
        }

        public double LayDanhSachHoaDonTheoThangNam(int thang, int nam)
        {
            List<HoaDon> hd = new List<HoaDon>();
            string query1 = "SELECT * FROM dbo.HoaDon WHERE MONTH(ngayTao) = " + thang + " AND YEAR(ngayTao)= " + nam;
            string query = "SELECT SUM(thanhTien) FROM dbo.HoaDon WHERE MONTH(ngayTao) = "+thang+" AND YEAR(ngayTao)= "+ nam ;
            DataTable table1= DataProvider.Instance.ExecuteQuery(query1);
            if( table1.Rows.Count > 0)
            {
                DataTable table = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    return double.Parse(row[0].ToString());
                }
            }
            return -1.0;
          
        }

        public bool themHoaDon(int maHoaDon, int maKH, int maNV, DateTime ngayTao)
        {
            string query = "INSERT INTO dbo.HoaDon VALUES(" + maHoaDon + "," + maKH + "," + maNV + "," + ngayTao + ")";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        
    }
}
