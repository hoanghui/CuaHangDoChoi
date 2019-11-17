using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
        public class SanPhamDAO
        {
        //biến singleton, khởi tạo 1 lần duy nhất
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            private set => instance = value;
        }

        private SanPhamDAO() { }

        // đổ data vào 
        public List<SanPham> LaySanPham()
        {
            List<SanPham> sp = new List<SanPham>();
            string query = "SELECT * FROM dbo.SanPham";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                sp.Add(new SanPham(row));
            }
            return sp;
        }

        public List<SanPham> TimSP(int masanpham)
        {
            List<SanPham> nv = new List<SanPham>();
            string query = "SELECT * FROM dbo.SanPham WHERE maSanPham = " + masanpham + "";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                nv.Add(new SanPham(row));
            }
            return nv;
        }

        public List<SanPham> TimSPtheoten(string tensanpham)
        {
            List<SanPham> nv = new List<SanPham>();
            string query = "SELECT * FROM dbo.SanPham WHERE tenSanPham = N'" + tensanpham + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                nv.Add(new SanPham(row));
            }
            return nv;
        }

        public bool CapNhatSanPham(int masp, string tensp, string xuatxu, DateTime ngaynhap, double giaban, int soluong)
        {
            //string query = "SELECT * FROM NhanVien IF EXISTS(SELECT maNhanVien FROM NhanVien WHERE maNhanVien = " + manv + ") BEGIN UPDATE  dbo.NhanVien SET  hoTen = N'" + hoten + "', gioiTinh = '" + gioitinh + "', CMND = " + cmnd + " WHERE maNhanVien = '" + manv + "' END" ;
            string query = "UPDATE  dbo.SanPham SET tenSanPham = N'" + tensp + "', xuatXu= '" + xuatxu + "',ngayNhap ='"+ngaynhap+"', giaBan = "+giaban+", soLuong ="+soluong+" WHERE maSanPham = " + masp + "";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool XoaSP(int masanpham)
        {
            string query = "DELETE FROM dbo.SanPham WHERE maSanPham = '" + masanpham + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ThemSP( string tensp, string xuatxu, DateTime ngaynhap, double giaban, int soluong)
        {
            //List<SanPham> sp = new List<SanPham>();   
            //string query = "SELECT * FROM dbo.SanPham WHERE maSanPham = " + masp + "";
            //DataTable table = DataProvider.Instance.ExecuteQuery(query);
            //foreach (DataRow row in table.Rows)
            //{
            //    sp.Add(new SanPham(row));
            //}
            //if(sp.Count > 0)
            //{
            //    return false;
            //}
            if (giaban > 0 && soluong >0)
            {
                string query1 = "INSERT INTO dbo.SanPham (tenSanPham,xuatXu, ngayNhap,giaBan, soLuong) VALUES(N'" + tensp + "','" + xuatxu + "','" + ngaynhap + "', " + giaban + "," + soluong + ")";
                int result = DataProvider.Instance.ExecuteNonQuery(query1);
                return result > 0;
            }
            else
            {
                return false;
            }
                
        }
    }
}
