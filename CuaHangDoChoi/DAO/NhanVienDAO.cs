using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVienDAO
    {
        //biến singleton, khởi tạo 1 lần duy nhất
        //biến instance để lấy dữ liệu từ csdl lên từ lần đầu, những lần sau khỏi phải xuống csdl nữa

        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set => instance = value;
        }

        private NhanVienDAO() { }

        // đổ data vào 
        //public NhanVien layMaNhanVien(string maNhanVien)
        //{
        //    string query = "SELECT * FROM dbo.NhanVien WHERE ma= '" + maNhanVien+ "'";
        //    DataTable table = DataProvider.Instance.ExecuteQuery(query);
        //    foreach (DataRow row in table.Rows)
        //    {
        //        return new NhanVien(row);
        //    }
        //    return null;
        //}

        public List<NhanVien> LayDanhSachKH()
        {
            List<NhanVien> ds = new List<NhanVien>();
            string query = "SELECT * FROM dbo.NhanVien";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                ds.Add(new NhanVien(row));
            }
            return ds;
        }


    }
}
