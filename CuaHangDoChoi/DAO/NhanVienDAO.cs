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
        // nonquery: thêm, sửa, xóa
        //biến singleton, khởi tạo 1 lần duy nhất
        //biến instance để lấy dữ liệu từ csdl lên từ lần đầu, những lần sau khỏi phải xuống csdl nữa

        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set => instance = value;
        }

        private NhanVienDAO() { }

        public List<NhanVien> Lay1nhanvien(string username)
        {
            List<NhanVien> nv = new List<NhanVien>();
            string query = "SELECT * FROM dbo.NhanVien WHERE tenDangNhap = '" + username + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                nv.Add(new NhanVien(row));
            }
            return nv;
        }

        public List<NhanVien> laynhanvien()
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

        public bool CapNhat(int manv, string hoten, int cmnd, string ngaysinh, string gioitinh, string tendangnhap)
        {
            //string query = "SELECT * FROM NhanVien IF EXISTS(SELECT maNhanVien FROM NhanVien WHERE maNhanVien = " + manv + ") BEGIN UPDATE  dbo.NhanVien SET  hoTen = N'" + hoten + "', gioiTinh = '" + gioitinh + "', CMND = " + cmnd + " WHERE maNhanVien = '" + manv + "' END" ;
            string query = "UPDATE  dbo.NhanVien SET  hoTen = N'" + hoten + "', gioiTinh = '" + gioitinh + "', CMND = " + cmnd + " WHERE maNhanVien = '" + manv + "'" ;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
        public List<NhanVien> TimNV(int manv)
        {
            List<NhanVien> nv = new List<NhanVien>();
            if(manv > 0)
            {
                
                string query = "SELECT * FROM dbo.NhanVien WHERE maNhanVien = '" + manv + "'";
                DataTable table = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow row in table.Rows)
                {
                    nv.Add(new NhanVien(row));
                }
                return nv;
            }
            else
            {
                return nv;
            }
           
        }

        public bool XoaNV(int manv, string tendangnhap)
        {

            string query1 = "DELETE FROM dbo.NhanVien WHERE maNhanVien = " + manv + "";
            string query2 = "DELETE FROM dbo.TaiKhoan WHERE tenDangNhap = '" + tendangnhap + "'";
            string query3 = "UPDATE dbo.HoaDon SET maNhanVien = null WHERE maNhanVien = " + manv + "";
            DataProvider.Instance.ExecuteNonQuery(query3);
            int result1 = DataProvider.Instance.ExecuteNonQuery(query1);
            DataProvider.Instance.ExecuteNonQuery(query2);

            return result1 > 0;
        }

        public bool ThemNV(int manv, string hoten, int cmnd, string ngaysinh, string gioitinh, string tendangnhap, string matkhau)
        {
            if (manv <= 0)
            {
                return false;
            }
            else
            {
                string query = "INSERT INTO dbo.TaiKhoan VALUES('" + tendangnhap + "','" + matkhau + "',1)" +
                "INSERT INTO dbo.NhanVien VALUES(" + manv + ",N'" + hoten + "'," + cmnd + ",'" + ngaysinh + "', '" + gioitinh + "','" + tendangnhap + "')";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            
        }

        public bool KiemTraNhanVienTonTaiVoiMaNhanVien(int manv)
        {
            List<NhanVien> ds = new List<NhanVien>();
            string query = "SELECT * FROM dbo.NhanVien WHERE maNhanVien = "+manv+"";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                ds.Add(new NhanVien(row));
            }
            int result = ds.Count;
            return result > 0;
        }
        public bool KiemTraNhanVienTonTaiVoiTenDangNhap(string tendangnhap)
        {
            List<NhanVien> ds = new List<NhanVien>();
            string query = "SELECT * FROM dbo.NhanVien WHERE tenDangNhap = '" + tendangnhap + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                ds.Add(new NhanVien(row));
            }
            int result = ds.Count;
            return result > 0;
        }
    }
}
