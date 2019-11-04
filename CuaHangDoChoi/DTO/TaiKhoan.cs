using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        private string tenDangNhap;
        private string matKhau;
        private int loaiTaiKhoan;
        public TaiKhoan(DataRow row)
        {
            this.tenDangNhap = row["tenDangNhap"].ToString();
            this.matKhau = row["matKhau"].ToString();
            this.LoaiTaiKhoan = (int)row["loaiTaiKhoan"];
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
    }
}
