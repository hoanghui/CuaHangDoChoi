using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuaHangDoChoi
{
    public partial class ThanhToan : Form
    {
        BindingSource bd = new BindingSource();
        public ThanhToan()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        void HienThiDanhSach()
        {
            bd.DataSource = SanPhamDAO.Instance.LaySanPham();
            dgvSanPham.DataSource = bd;

            // set tên cột
            dgvSanPham.Columns[0].HeaderText = "Mã Sản Phẩm";

            dgvSanPham.Columns[1].HeaderText = "Tên Sản Phẩm";

            dgvSanPham.Columns[1].Width = 150; // set độ rộng cho cột

            dgvSanPham.Columns[2].HeaderText = "Xuất Xứ";

            dgvSanPham.Columns[4].HeaderText = "Ngày Nhập";

            dgvSanPham.Columns[3].HeaderText = "Giá Bán";

            dgvSanPham.Columns[5].Visible = false;
        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            bd.DataSource = SanPhamDAO.Instance.TimSP(int.Parse(txtTimKiem.Text));
            if (bd.Count == 0)
            {
                MessageBox.Show("Tìm không có", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btThem.Visible = true;
            btXoa.Visible = true;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            bd.DataSource = SanPhamDAO.Instance.LaySanPham();
            dgvThanhToan.DataSource = bd;
            dgvThanhToan.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvThanhToan.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvThanhToan.Columns[2].HeaderText = "Xuất Xứ";
            dgvThanhToan.Columns[3].HeaderText = "Giá Bán";
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Dispose(false);
        }
    }
}
