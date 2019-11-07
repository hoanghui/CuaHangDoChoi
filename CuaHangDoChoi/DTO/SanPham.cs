using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        private int maSanPham;
        private string tenSanPham;
        private string xuatXu ;
        private int giaBan;
        private DateTime ngayNhap;
        private int soLuong;

        public SanPham(DataRow row)
        {
            this.maSanPham = (int)row["maSanPham"];
            this.tenSanPham = row["hoTen"].ToString();
            this.xuatXu = row["xuatXu"].ToString();
            this.giaBan = (int)row["CMND"];
            this.ngayNhap = (DateTime)row["ngayNhap"];
            this.soLuong = (int)row["ngaySinh"];
           
        }

        public int MaSanPham { get => maSanPham; set => maSanPham= value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        
    }
}
