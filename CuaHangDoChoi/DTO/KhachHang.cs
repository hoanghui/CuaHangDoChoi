using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class KhachHang
    {
        private string maKhachHang;
        private string hoTen;
        private int soDienThoai;
        private int cMND;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string diaChi;
    
        public KhachHang(DataRow row)
        {
            this.maKhachHang = row["maKhachHang"].ToString();
            this.hoTen = row["hoTen"].ToString();
            this.soDienThoai = (int)row["soDienThoai"];
        }

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int CMND { get => cMND; set => cMND = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

    }
}
