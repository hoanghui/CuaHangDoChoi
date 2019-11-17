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

            if (txtTimKiem.Text == " ")
            {
                MessageBox.Show("Tìm không có", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.ResetText();
            }
            else
            {
                try
                {
                    bd.DataSource = SanPhamDAO.Instance.TimSP(int.Parse(txtTimKiem.Text));

                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTimKiem.ResetText();
                    return;
                }
                if (bd.Count == 0)
                {
                    MessageBox.Show("Tìm không có", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }       

        //Gán ngày
        public DateTime ganngay(string date)
        {
            char[] kitutach = {'/'};
            string[] hientai = dateTimePicker1.Text.Split(kitutach);
            
            DateTime ngayhientai = new DateTime(int.Parse(hientai[2]), int.Parse(hientai[0]), int.Parse(hientai[1]));
            return ngayhientai;
        }

        //THanh toán
        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if (lvThanhToan.Items.Count > 0)
            {
                MessageBox.Show("Thanh toán thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvThanhToan = taomoisauthanhtoan();
                lbMaKH = maKhachHangTaoMoi();
                //addHD();
            }
            else
            {
                MessageBox.Show("Thanh toán không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //tạo mã khách hàng mới
        Label maKhachHangTaoMoi()
        {
            int maKH ;
            int a = 1;
            maKH = int.Parse(lbMaKH.Text);
            a += maKH;
            lbMaKH.Dispose();
            Label lbKH = new Label();
            lbKH.Location = new Point(774, 162);
            lbKH.Size = new Size(200, 27);
            lbKH.BackColor = Color.Transparent;
            lbKH.AutoSize = false;
            lbKH.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            lbKH.TabIndex = 15;
            lbKH.Parent = this;
            lbKH.Text = a.ToString();
            return lbKH;
        }

        //load lại khung thanh toán
        ListView taomoisauthanhtoan()
        {
            lvThanhToan.Dispose(); //xóa hết dữ liệu cũ
            ListView lvnew = new ListView();
            lvnew.Location = new Point(609, 197);
            lvnew.Size = new Size(365, 232);
            lvnew.Columns.Add("Mã Sản Phẩm");
            lvnew.Columns.Add("Tên Sản Phẩm");
            lvnew.Columns.Add("Xuất Xứ");
            lvnew.Columns.Add("Số Lượng");
            lvnew.Columns.Add("Giá Bán");
            lvnew.FullRowSelect = true;
            lvnew.GridLines = true;
            lvnew.Parent = this;
            lvnew.View = View.Details;
            lbTongTien.Text = "0";
            tongtien = 0;
            return lvnew;
        }

        float tongtien = 0;//biến tổng tiền cục bộ
        void hienthibill()
        {           
            //Đỗ dữ liệu từ datagrid sang listview
            ListViewItem lsvItem;
            
            if (dgvSanPham.SelectedCells.Count >= 0)
            {
                foreach (DataGridViewRow row in dgvSanPham.SelectedRows)
                {
                    string m = row.Cells["giaBan"].Value.ToString();
                    int giabansaukhitang = int.Parse(m) * int.Parse(nudCount.Value.ToString()); //giá bán sau khi tăng
                    lsvItem = new ListViewItem(row.Cells["maSanPham"].Value.ToString());
                    lsvItem.SubItems.Add(row.Cells["tenSanPham"].Value.ToString());
                    lsvItem.SubItems.Add(row.Cells["xuatXu"].Value.ToString());
                    lsvItem.SubItems.Add(nudCount.Value.ToString());
                    lsvItem.SubItems.Add(giabansaukhitang.ToString());
                    tongtien += giabansaukhitang;
                    lvThanhToan.Items.Add(lsvItem);
                }                
            }
            lbTongTien.Text = tongtien.ToString();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            hienthibill();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //Chỉ xóa sản phẩm khi click vào mã sản phẩm ở listview
            foreach (ListViewItem eachItem in lvThanhToan.SelectedItems)
            {
                lvThanhToan.Items.Remove(eachItem);
            }
        }

        private void btInhoadon_Click(object sender, EventArgs e)
        {
            if (lvThanhToan.Items.Count > 0)
            {
                MessageBox.Show("In hóa đơn thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("In hóa đơn không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Dispose(false);
        }

    }
}
