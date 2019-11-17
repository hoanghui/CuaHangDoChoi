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

        public int maSanPham { get; private set; }
        public int maHoaDon { get; private set; }
        public float donGia { get; private set; }
        public float thanhTien { get; private set; }
        public int soluong { get; private set; }
        public int maKH { get; private set; }
        public int maNV { get; private set; }
        public DateTime ngayTao { get; private set; }

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
                HienThiDanhSach();
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
                    HienThiDanhSach();
                    return;
                }
                if (bd.Count == 0)
                {
                    MessageBox.Show("Tìm không có", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HienThiDanhSach();
                }
            }
                
        }       

        //THanh toán
        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if (lvThanhToan.Items.Count > 0)
            {
                if (txtMaKH.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int txtmkh;
                    try
                    {
                        txtmkh = int.Parse(txtMaKH.Text);
                        txtMaKH.Text = txtmkh.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng lại nhập mã khách hàng", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaKH.ResetText();
                    }
                    if (txtMaKH.Text.Length > 10)
                    {
                        MessageBox.Show("Vui lòng nhập lại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaKH.ResetText();
                    }
                    else
                    {
                        addHoaDon();
                        lvThanhToan = taomoisauthanhtoan();
                    }
                }
            }
            else
            {
                MessageBox.Show("Thanh toán không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.ResetText();
            }
        }

        //Gán ngày
        public DateTime ganngay(string date)
        {
            char[] kitutach = { '/' };
            string[] hientai = dateTimePicker1.Text.Split(kitutach);

            DateTime ngayhientai = new DateTime(int.Parse(hientai[2]), int.Parse(hientai[0]), int.Parse(hientai[1]));
            return ngayhientai;
        }


        void addHoaDon()
        {
            try
            {
                maHoaDon = int.Parse(lbmaHoaDon.Text);
                maKH = int.Parse(txtMaKH.Text);
                maNV = int.Parse(lbMaNhanVien.Text);
                ngayTao = ganngay(dateTimePicker1.ToString());
                thanhTien = float.Parse(lbTongTien.Text);
            }
            catch
            {
                MessageBox.Show("Thanh toán không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (HoaDonDAO.Instance.ThemHD(maHoaDon, maKH, maNV, ngayTao, thanhTien))
            {
                addChiTietHoaDon();
            }
            else
            {
                MessageBox.Show("Thanh toán không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Label maHoaDonTaoMoi()
        {            
            int maHD;
            int b = 1;
            maHD = int.Parse(lbmaHoaDon.Text);
            b += maHD;
            lbmaHoaDon.Text = b.ToString();
            lbmaHoaDon.Dispose();
            Label lbHD = new Label();
            lbHD.Location = new Point(755, 133);
            lbHD.Size = new Size(99, 27);
            lbHD.BackColor = Color.Transparent;
            lbHD.AutoSize = false;
            lbHD.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            lbHD.TabIndex = 16;
            lbHD.Parent = this;
            lbHD.Text = b.ToString();
            return lbHD;
        }

        void addChiTietHoaDon()
        {            
            maSanPham = int.Parse(lvThanhToan.Items[0].Text);
            donGia = float.Parse(lvThanhToan.Items[0].SubItems[4].Text);
            soluong = int.Parse(lvThanhToan.Items[0].SubItems[3].Text);

            if (ChiTietHoaDonDAO.Instance.themChiTietHoaDon(maHoaDon, maSanPham, donGia, soluong))
            {
                MessageBox.Show("Thanh toán thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbmaHoaDon = maHoaDonTaoMoi();//test thêm dữ liệu                
            }
            else
            {
                MessageBox.Show("Thanh toán không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        string m;
        void hienthibill()
        {           
            //Đỗ dữ liệu từ datagrid sang listview
            ListViewItem lsvItem;
            
            if (dgvSanPham.SelectedCells.Count >= 0)
            {
                foreach (DataGridViewRow row in dgvSanPham.SelectedRows)
                {
                    m = row.Cells["giaBan"].Value.ToString();
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

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang_NhanVien kh = new DanhSachKhachHang_NhanVien();
            kh.Show();
            this.Dispose(false);
        }
    }
}
