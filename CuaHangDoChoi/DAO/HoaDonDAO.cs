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

        public double LayDanhSachHoaDonTheoThangNam(int thang, int nam)
        {
            List<HoaDon> hd = new List<HoaDon>();
            string query = "SELECT SUM(thanhTien) FROM dbo.HoaDon WHERE MONTH(ngayTao) = "+thang+" AND YEAR(ngayTao)= "+ nam ;
            DataTable table= DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                return double.Parse(row[0].ToString());
            }
            return -1.0;
        }
    }
}
