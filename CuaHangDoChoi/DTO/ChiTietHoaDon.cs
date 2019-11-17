using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDon
    {
        private int maSanPham;
        private int maHoaDon;
        private double donGia;
        private int soLuong;

        public ChiTietHoaDon(DataRow row)
        {
            this.MaHoaDon =(int)row["maHoaDon"];
            this.MaSanPham = (int)row["maSanPham"];
            this.DonGia = (double)row["donGia"];
            this.SoLuong = (int)row["soLuong"];
        }

        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
