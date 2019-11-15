using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            private set {
                ChiTietHoaDonDAO.instance = value;
            }
        }

        private ChiTietHoaDonDAO() { }

        public List<ChiTietHoaDonDAO> layChiTietHoaDon(int id)
        {
            List<ChiTietHoaDonDAO> cthd = new List<ChiTietHoaDonDAO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.ChiTietHoaDon WHERE maHoaDon =" + id);

            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDonDAO info = new ChiTietHoaDonDAO(item);
                cthd.Add(info);
            }
            return cthd;
        }
    }
}
