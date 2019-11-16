using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        private int maHoaDon;
        private int maKhachHang;
        private int maNhanVien;
        private DateTime ngayTao;
        private double thanhTien;

        public HoaDon(DataRow row)
        {
            this.maHoaDon = (int)row["maHoaDon"];
            this.maKhachHang = (int)row["maKhachHang"];
            this.maNhanVien = (int)row["maNhanVien"];
            this.ngayTao = (DateTime)row["ngayTao"];
            this.thanhTien = (double)row["thanhTien"];
        }

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public DateTime NgayTao { get => ngayTao; set => ngayTao = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
    } 
}
