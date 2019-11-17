using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        private int maKhachHang;
        private string hoTen;
        private int soDienThoai;
        private int cMND;
        private string gioiTinh;
        private DateTime ngaySinh;
        private bool trangThai;


        public KhachHang(DataRow row)
        {
            this.maKhachHang = int.Parse(row["maKhachHang"].ToString());
            this.hoTen = row["hoTen"].ToString();
            this.cMND = (int)row["CMND"];
            this.soDienThoai = (int)row["soDienThoai"];
            this.ngaySinh = (DateTime)row["ngaySinh"];
            this.gioiTinh = row["gioiTinh"].ToString();
            this.trangThai = (bool)row["trangThai"];
        }

        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }

    }
}
