using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangDoChoi
{
    public partial class DanhSachKhachHang : Form
    {
        public DanhSachKhachHang()
        {
            InitializeComponent();
        }

        //hàm xử lý người dùng chọn một dòng
        private void lvDanhSachKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachKhachHang.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem item = lvDanhSachKhachHang.SelectedItems[0];
                lvDanhSachKhachHang.Text = item.SubItems[0].Text;
                lvDanhSachKhachHang.Text = item.SubItems[1].Text;
            }
        }

        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_QuanLy nv = new DanhSachNhanVien_QuanLy();
            nv.Show();
            this.Dispose(false);
        }

        private void btnDSHoaDon_Click(object sender, EventArgs e)
        {
            DanhSachHoaDon_QuanLy hd = new DanhSachHoaDon_QuanLy();
            hd.Show();
            this.Dispose(false);
        }

        private void btnDSHangHoa_Click(object sender, EventArgs e)
        {
            DanhSachHangHoa_QuanLy hh = new DanhSachHangHoa_QuanLy();
            hh.Show();
            this.Dispose(false);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe_QuanLy tk = new ThongKe_QuanLy();
            tk.Show();
            this.Dispose(false);
        }

        private void DanhSachKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void DanhSachKhachHang_Load(object sender, EventArgs e)
        {
            
        }
    }
}
