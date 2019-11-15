using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using System.Globalization;

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

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            GanDuLieu();
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

        public void funData(TextBox txtName)
        {
            lbUserName.Text = txtName.Text;
        }
        void GanDuLieu()
        {
            BindingSource bd1 = new BindingSource();
            if (lbUserName.Text != "")
            {
                bd1.DataSource = NhanVienDAO.Instance.Lay1nhanvien(lbUserName.Text.ToString()); 
                lbMaNhanVien.DataBindings.Add("Text", bd1.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
                lbHoTen.DataBindings.Add("Text", bd1.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
                lbUserName.DataBindings.Add("Text", bd1.DataSource, "tenDangNhap", true, DataSourceUpdateMode.Never);
            }
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


        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Dispose(false);
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            //Đỗ dữ liệu từ datagrid sang listview
            ListViewItem lsvItem;
            float tongTien = 0;
            if (dgvSanPham.SelectedCells.Count >= 0)
            {
                foreach (DataGridViewRow row in dgvSanPham.SelectedRows) 
                {
                    lsvItem = new ListViewItem(row.Cells["maSanPham"].Value.ToString());
                    lsvItem.SubItems.Add(row.Cells["tenSanPham"].Value.ToString());
                    lsvItem.SubItems.Add(row.Cells["xuatXu"].Value.ToString());
                    lsvItem.SubItems.Add(nudCount.Value.ToString());
                    lsvItem.SubItems.Add(row.Cells["giaBan"].Value.ToString());
                    tongTien += float.Parse(row.Cells["giaBan"].Value.ToString());
                    lvThanhToan.Items.Add(lsvItem);
                }
            }            
            CultureInfo culture = new CultureInfo("vi-VN");//chinh Currency ve dang VND
            lbTongTien.Text = tongTien.ToString("c", culture);//Hien thi string dang Currency
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //Chỉ xóa sản phẩm khi click vào mã sản phẩm ở listview
            foreach (ListViewItem eachItem in lvThanhToan.SelectedItems)
            {
                lvThanhToan.Items.Remove(eachItem);
            }
        }

     
    }
}
