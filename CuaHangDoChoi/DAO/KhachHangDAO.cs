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

        private KhachHangDAO()
        {

        }

        // đổ data vào 
       

        public List<KhachHang> LayDSKhachHang()
        {
            List<KhachHang> kh = new List<KhachHang>();
            string query = "SELECT * FROM dbo.KhachHang WHERE trangThai = 1";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                kh.Add(new KhachHang(row));
            }
            return kh;
        }

        public bool SuaKH(int makh, string hoten, int sdt,int cmnd , string ngaysinh, string gioitinh)
        {
            string query = "suaKH " + makh + ", N'" + hoten + "', " + cmnd + ", " + sdt + ", '" + ngaysinh + "', '" + gioitinh + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<KhachHang> TimKH(int makh)
        {
            List<KhachHang> kh = new List<KhachHang>();
            if (makh > 0)
            {

                string query = "SELECT * FROM dbo.KhachHang WHERE maKhachHang = '" + makh + "'";
                DataTable table = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    kh.Add(new KhachHang(row));
                }
                return kh;
            }
            else
            {
                return kh;
            }

        }

        public bool ThemKH( string hoten, int cmnd, int sodienthoai, string ngaysinh, string gioitinh)
        {
            if (cmnd <= 0)
            {
                return false;
            }
            else
            { 
                List<NhanVien> ds1 = new List<NhanVien>();
                string query1 = "SELECT * FROM dbo.KhachHang WHERE CMND = " +cmnd+ " OR soDienThoai = "+sodienthoai;
                DataTable table1 = DataProvider.Instance.ExecuteQuery(query1);
                foreach (DataRow row in table1.Rows)
                {
                    ds1.Add(new NhanVien(row));
                }

                int result1 = ds1.Count;
                if (/*result == 0 &&*/ result1 == 0)
                {
                    string query2 ="INSERT INTO dbo.KhachHang (hoTen,CMND,soDienThoai,ngaySinh,gioiTinh) VALUES( N'" + hoten + "'," + cmnd + ","+sodienthoai+",'" + ngaysinh + "', '" + gioitinh +"')";
                    int result2 = DataProvider.Instance.ExecuteNonQuery(query2);
                    return result2 > 0;
                }
                else
                {
                    return false;
                }
            }


        }

        public bool XoaKH (int makh)
        {
            string query = "UPDATE dbo.KhachHang SET trangThai = 0 WHERE maKhachHang =" + makh;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
