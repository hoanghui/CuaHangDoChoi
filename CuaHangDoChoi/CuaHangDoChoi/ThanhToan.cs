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

            btThem.Click += btThem_Click;
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

    //void showSanPham(int id)
    //    {
            
    //    }

        private void btThem_Click(object sender, EventArgs e)
        {
            bd.DataSource = SanPhamDAO.Instance.LaySanPham();
            dgvSanPham.DataSource = bd;
            lvThanhToan.Items.Clear();

            lvThanhToan.View = View.Details;

            lvThanhToan.Columns.Add("masp");

            lvThanhToan.Columns.Add("tensp");

            lvThanhToan.Columns.Add("Gia");

            lvThanhToan.FullRowSelect = true;

            int i = 0;

            foreach (DataRow row in bd)
            {
                lvThanhToan.Items.Add(row["productid"].ToString());
                lvThanhToan.Items[i].SubItems.Add(row["productname"].ToString());
                lvThanhToan.Items[i].SubItems.Add(row["unitprice"].ToString());
                i++;
            }
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
    }
}
