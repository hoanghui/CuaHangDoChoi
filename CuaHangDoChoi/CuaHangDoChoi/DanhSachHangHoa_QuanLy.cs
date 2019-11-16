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
            if (txtTimKiem.Text != "")
            {
                try
                {
                    int.Parse(txtTimKiem.Text);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                {
                    bd.DataSource = SanPhamDAO.Instance.TimSP(int.Parse(txtTimKiem.Text.ToString()));
                    if (bd.Count == 0)
                    {
                        MessageBox.Show("Tìm không có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtMaSanPham.DataBindings.Clear();
                txtTenSanPham.DataBindings.Clear();
                txtSoLuong.DataBindings.Clear();
                txtGiaBan.DataBindings.Clear();
                dtpNgayNhap.DataBindings.Clear();
                txtXuatXu.DataBindings.Clear();

                HienThiDanhSach();
            }
            //bd.DataSource = SanPhamDAO.Instance.TimSP(int.Parse(txtTimKiem.Text.ToString()));
            //if (bd.Count == 0)
            //{
            //    MessageBox.Show("Tìm không có", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btThemSP_Click(object sender, EventArgs e)
        {
            panelThemSanPham.Visible = true;
            btnCapNhat.Enabled = false;
            btnChinhSua.Enabled = false;
            btThemSP.Enabled = false;
            btXoaSP.Enabled = false;

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

            btnCapNhat.Visible = true;
            btThemSP.Enabled = false;
            btXoaSP.Enabled = false;
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

            bool result = SanPhamDAO.Instance.CapNhatSanPham(masanpham, tensanpham, xuatxu, ngaynhap, giaban, soluong);
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

            btnCapNhat.Visible = false;
            btThemSP.Enabled = true;
            btXoaSP.Enabled = true;
            txtMaSanPham.Enabled = false;
            txtTenSanPham.Enabled = false;
            txtXuatXu.Enabled = false;
            txtSoLuong.Enabled = false;
            dtpNgayNhap.Enabled = false;
            txtGiaBan.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                masanpham = int.Parse(txtMaSanPham_New.Text);
                tensanpham = txtTenSanPham_New.Text;
                soluong = int.Parse(txtSoLuong_New.Text);
                giaban = double.Parse(txtGiaBan_New.Text);
                xuatxu = txtXuatXu_New.Text;
                ngaynhap = dtpNgayNhap_New.Value;
            }
            catch
            {
                MessageBox.Show("Nhập chưa đúng định dạng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = SanPhamDAO.Instance.ThemSP(masanpham, tensanpham, xuatxu, ngaynhap, giaban, soluong);
            if (result)
            {
                //txtNhanVienIDNew.DataBindings.Clear();
                //txtNameNew.DataBindings.Clear();
                //txtSexNew.DataBindings.Clear();
                //dtpBirthdayNew.DataBindings.Clear();
                //txtCMNDNew.DataBindings.Clear();
                //txtNhanVienIDNew.DataBindings.Clear();

                txtMaSanPham.DataBindings.Clear();
                txtTenSanPham.DataBindings.Clear();

                txtXuatXu.DataBindings.Clear();
                txtSoLuong.DataBindings.Clear();
                dtpNgayNhap.DataBindings.Clear();
                txtGiaBan.DataBindings.Clear();


                MessageBox.Show("Thêm nhân viên thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMaSanPham_New.DataBindings.Clear();
                txtTenSanPham_New.DataBindings.Clear();

                txtXuatXu_New.DataBindings.Clear();
                txtSoLuong_New.DataBindings.Clear();
                dtpNgayNhap_New.DataBindings.Clear();
                txtGiaBan_New.DataBindings.Clear();

                btThemSP.Enabled = true;
                btXoaSP.Enabled = true;


                HienThiDanhSach();
                panelThemSanPham.Visible = false;
            }
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập mã sản phẩm...")
                txtTimKiem.Clear();
        }

        private void DanhSachHangHoa_QuanLy_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "Nhập mã sản phẩm...";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn khỏi thêm sản phẩm? ", "Thoát khỏi thêm nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                // bật enabled các nút thêm, xóa, sửa, cập nhật
                btXoaSP.Enabled = true;
                btThemSP.Enabled = true;
                btnChinhSua.Enabled = true;
                btnCapNhat.Enabled = true;

                panelThemSanPham.Visible = false;
                txtTenSanPham_New.Clear();
                txtMaSanPham_New.Clear();
                txtXuatXu_New.Clear();
                txtSoLuong_New.Clear();
                txtGiaBan_New.Clear();
                dtpNgayNhap_New.ResetText();
            }
        }

        private void txtMaSanPham_New_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMaSanPham_TextChanged(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text != "")
            {
                try
                {
                    pbSanPham.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachHangHoa\" + int.Parse(txtMaSanPham.Text) + ".jpg");

                }
                catch
                {
                    pbSanPham.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachHangHoa\none.jpg");
                }


            }
        }
    }
}



