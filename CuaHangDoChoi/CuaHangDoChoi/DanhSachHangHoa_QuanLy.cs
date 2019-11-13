using DAO;
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
    public partial class DanhSachHangHoa_QuanLy : Form
    {
        BindingSource bd = new BindingSource();

        public int masanpham { get; private set; }
        public string tensanpham { get; private set; } 
        public string xuatxu { get; private set; }
        public double giaban { get; private set; }
        public int soluong { get; private set; }
        public DateTime ngaynhap { get; private set; }
        public DanhSachHangHoa_QuanLy()
        {
            InitializeComponent();
        }

        void HienThiDanhSach()
        {
            bd.DataSource = SanPhamDAO.Instance.LaySanPham();
            dgvSanPham.DataSource = bd;

            // set tên cột
            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";

            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";

            dgvSanPham.Columns[1].Width = 150; // set độ rộng cho cột

            dgvSanPham.Columns[2].HeaderText = "Xuất xứ";

            dgvSanPham.Columns[4].HeaderText = "Ngày nhập";

            dgvSanPham.Columns[3].HeaderText = "Giá bán";

            dgvSanPham.Columns[5].HeaderText = "Số lượng";

            GanDuLieu();
        }

        void GanDuLieu()
        {
            txtMaSanPham.DataBindings.Add("Text", dgvSanPham.DataSource, "maSanPham", true, DataSourceUpdateMode.Never);
            txtTenSanPham.DataBindings.Add("Text", dgvSanPham.DataSource, "tenSanPham", true, DataSourceUpdateMode.Never);
            txtXuatXu.DataBindings.Add("Text", dgvSanPham.DataSource, "xuatxu", true, DataSourceUpdateMode.Never);
            dtpNgayNhap.DataBindings.Add("Text", dgvSanPham.DataSource, "ngayNhap", true, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings.Add("Text", dgvSanPham.DataSource, "giaBan", true, DataSourceUpdateMode.Never);
            txtSoLuong.DataBindings.Add("Text", dgvSanPham.DataSource, "soLuong", true, DataSourceUpdateMode.Never);
        }

        private void DanhSachHangHoa_Load(object sender, EventArgs e)
        {
            txtMaSanPham.Enabled = false;
            txtTenSanPham.Enabled = false;
            txtXuatXu.Enabled = false;
            txtGiaBan.Enabled = false;
            dtpNgayNhap.Enabled = false;
            txtSoLuong.Enabled = false;
            HienThiDanhSach();
        }

        private void btnListNhanVien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_QuanLy nv = new DanhSachNhanVien_QuanLy();
            nv.Show();
            this.Dispose(false);
        }

        private void btnListKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang kh = new DanhSachKhachHang();
            kh.Show();
            this.Dispose(false);
        }

        private void btnDSHoaDon_Click(object sender, EventArgs e)
        {
            DanhSachHoaDon_QuanLy hd = new DanhSachHoaDon_QuanLy();
            hd.Show();
            this.Dispose(false);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe_QuanLy tk = new ThongKe_QuanLy();
            tk.Show();
            this.Dispose(false);
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Dispose(false);
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            bd.DataSource = SanPhamDAO.Instance.TimSP(int.Parse(txtTimKiem.Text.ToString()));
            if (bd.Count == 0)
            {
                MessageBox.Show("Tìm không có", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThemSP_Click(object sender, EventArgs e)
        {

        }

        private void btXoaSP_Click(object sender, EventArgs e)
        {
            bool result = SanPhamDAO.Instance.XoaSP(int.Parse(txtMaSanPham.Text));
            if (result)
            {
                MessageBox.Show("Xóa sản phẩm thành công", "Xóa sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMaSanPham.DataBindings.Clear();
                txtTenSanPham.DataBindings.Clear();
                txtXuatXu.DataBindings.Clear();
                txtSoLuong.DataBindings.Clear();
                dtpNgayNhap.DataBindings.Clear();
                txtGiaBan.DataBindings.Clear();
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            txtMaSanPham.Enabled = true;
            txtTenSanPham.Enabled = true;
            txtXuatXu.Enabled = true;
            txtGiaBan.Enabled = true;
            dtpNgayNhap.Enabled = true;
            txtSoLuong.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // bắt ngoại lệ khi người dùng nhập k đúng kiểu dữ liệu
            try
            {
                masanpham = int.Parse(txtMaSanPham.Text);
                tensanpham = txtTenSanPham.Text;
                soluong = int.Parse(txtSoLuong.Text);
                giaban = double.Parse(txtGiaBan.Text);
                xuatxu = txtXuatXu.Text;
                ngaynhap = dtpNgayNhap.Value;
            }
            catch
            {
                MessageBox.Show("Nhập chưa đúng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = SanPhamDAO.Instance.CapNhatSanPham(masanpham, tensanpham, xuatxu,ngaynhap,giaban,soluong);
            if (result)
            {
                MessageBox.Show("Sửa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSanPham.DataBindings.Clear();
                txtTenSanPham.DataBindings.Clear();

                txtXuatXu.DataBindings.Clear();
                txtSoLuong.DataBindings.Clear();
                dtpNgayNhap.DataBindings.Clear();
                txtGiaBan.DataBindings.Clear();

                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



            txtMaSanPham.Enabled = false;

            txtTenSanPham.Enabled = false;
            txtXuatXu.Enabled = false;
            txtSoLuong.Enabled = false;
            dtpNgayNhap.Enabled = false;
            txtGiaBan.Enabled = false;
        }
    }


}
