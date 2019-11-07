using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class NhanVien
    {
        private string maNhanVien;
        private string hoTen;
        private int soDienThoai;
        private int cMND;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string diaChi;

        public NhanVien(DataRow row)
        {
            this.maNhanVien = row["maKhachHang"].ToString();
            this.hoTen = row["hoTen"].ToString();
            this.soDienThoai = (int)row["soDienThoai"];
            this.cMND = (int)row["CMND"];
            this.gioiTinh = row["gioiTinh"].ToString();
            this.ngaySinh = (DateTime)row["ngaySinh"];
            this.diaChi = row["diaChi"].ToString();
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

    }
}
