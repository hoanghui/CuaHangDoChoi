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
    }
}
