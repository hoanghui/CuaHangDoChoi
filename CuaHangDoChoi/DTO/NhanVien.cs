using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        private int maNhanVien;
        private string hoTen;
        private int cMND;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string tenDangNhap;
        private bool trangThai;
        public NhanVien()
        {
        }

        public NhanVien(DataRow row)
        {
            this.maNhanVien = (int)row["maNhanVien"];
            this.hoTen = row["hoTen"].ToString();
            this.cMND = (int)row["CMND"];
            this.ngaySinh = (DateTime)row["ngaySinh"];
            this.gioiTinh = row["gioiTinh"].ToString();
            this.tenDangNhap = row["tenDangNhap"].ToString();
            this.trangThai = (bool)row["trangThai"];
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        
    }
}
