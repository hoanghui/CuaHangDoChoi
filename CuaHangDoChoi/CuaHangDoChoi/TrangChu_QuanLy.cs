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
    public partial class TrangChu_QuanLy : Form
    {
        BindingSource bd = new BindingSource();

        public int manv { get; private set; }
        public string hoten { get; private set; }
        public int cmnd { get; private set; }
        public string ngaysinh { get; private set; }
        public string gioitinh { get; private set; }
        public string tendangnhap { get; private set; }
        public string matkhau { get; private set; }
        //public DateTime BirthDay { get; private set; }

        public TrangChu_QuanLy()
        {
            InitializeComponent();
           
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang kh = new DanhSachKhachHang();
            kh.Show();
            this.Dispose(false);
        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_QuanLy nv = new DanhSachNhanVien_QuanLy();
            nv.Show();
            this.Dispose(false);
        }

        private void btSanPham_Click(object sender, EventArgs e)
        {
            DanhSachHangHoa_QuanLy hh = new DanhSachHangHoa_QuanLy();
            hh.Show();
            this.Dispose(false);
        }

        private void btHoaDon_Click(object sender, EventArgs e)
        {
            DanhSachHoaDon_QuanLy hd = new DanhSachHoaDon_QuanLy();
            hd.Show();
            this.Dispose(false);
        }

        private void btThongKe_Click(object sender, EventArgs e)
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

        // lấy dữ liệu username từ Form DangNhap truyền qua Form này
        public void funData(TextBox txtName)
        {
            txtUserName.Text = txtName.Text;
        }

        void GanDuLieu()
        {
            if(txtUserName.Text != "")
            {
                bd.DataSource = NhanVienDAO.Instance.Lay1nhanvien(txtUserName.Text.ToString());
                txtNhanVienId.DataBindings.Add("Text", bd.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
                txtHoTen.DataBindings.Add("Text", bd.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
                dtpNgaySinh.DataBindings.Add("Text", bd.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
                txtCMND.DataBindings.Add("Text", bd.DataSource, "CMND", true, DataSourceUpdateMode.Never);
                txtGioiTinh.DataBindings.Add("Text", bd.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);


                lbGioiTinh.DataBindings.Add("Text", bd.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
                lbCMND.DataBindings.Add("Text", bd.DataSource, "CMND", true, DataSourceUpdateMode.Never);
                lbMaNhanVien.DataBindings.Add("Text", bd.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
                lbHoten.DataBindings.Add("Text", bd.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
                lbNgaySinh.DataBindings.Add("Text", bd.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
                lbTenDangNhap.DataBindings.Add("Text", bd.DataSource, "tenDangNhap", true, DataSourceUpdateMode.Never);
                //pbQuanLy.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachNhanVien\" + txtNhanVienId.Text.ToString() + ".jpg ");
                //pbQuanLy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }

        private void TrangChu_QuanLy_Load(object sender, EventArgs e)
        {
            GanDuLieu();
           
            pbQuanLy.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachNhanVien\" + lbMaNhanVien.Text + ".jpg");

         
            
        }

        private void TrangChu_QuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất? ", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            lbCMND.Visible = false;
            txtCMND.Visible = true;
            lbMaNhanVien.Visible = false;
            lbHoten.Visible = false;
            lbNgaySinh.Visible = false;
            lbTenDangNhap.Visible = false;
            lbGioiTinh.Visible = false;
            dtpNgaySinh.Visible = true;
            txtNhanVienId.Visible = true;
            txtUserName.Visible = true;
            dtpNgaySinh.Visible = true;
            txtHoTen.Visible = true;
            lbNgaySinh.Visible = false;
            btnXacNhan.Visible = true;
            txtGioiTinh.Visible = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                manv = int.Parse(txtNhanVienId.Text);
                ngaysinh = dtpNgaySinh.Value.Month + "/" + dtpNgaySinh.Value.Day + "/" + dtpNgaySinh.Value.Year;
                hoten = txtHoTen.Text;
                cmnd = int.Parse(txtCMND.Text);
                gioitinh = txtGioiTinh.Text;
                tendangnhap = txtUserName.Text;
            }
            catch
            {
                MessageBox.Show("Nhập chưa đúng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool result = NhanVienDAO.Instance.CapNhat(manv, hoten, cmnd, ngaysinh, gioitinh, tendangnhap);
            if (result)
            {
                MessageBox.Show("Sửa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lbCMND.DataBindings.Clear();
                lbHoten.DataBindings.Clear();
                lbGioiTinh.DataBindings.Clear();
                lbTenDangNhap.DataBindings.Clear();
                lbNgaySinh.DataBindings.Clear();
                lbMaNhanVien.DataBindings.Clear();

                txtNhanVienId.DataBindings.Clear();
                txtHoTen.DataBindings.Clear();
                txtGioiTinh.DataBindings.Clear();
                txtUserName.DataBindings.Clear();
                dtpNgaySinh.DataBindings.Clear();
                txtCMND.DataBindings.Clear();

                GanDuLieu();

                btnXacNhan.Visible = false;
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            lbCMND.Visible = true;
            lbHoten.Visible = true;
            lbGioiTinh.Visible = true;
            lbTenDangNhap.Visible = true;
            lbNgaySinh.Visible = true;
            lbMaNhanVien.Visible = true;

            txtHoTen.Visible = false;
            txtCMND.Visible = false;
            txtGioiTinh.Visible = false;
            txtNhanVienId.Visible = false;
            dtpNgaySinh.Visible = false;
            txtUserName.Visible = false;
            
        }

        
    }
}
