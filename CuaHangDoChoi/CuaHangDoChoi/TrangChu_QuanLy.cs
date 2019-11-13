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
                txtNgaySinh.DataBindings.Add("Text", bd.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
                txtChucVu.Text = "QUẢN LÝ";
                //pbQuanLy.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachNhanVien\" + txtNhanVienId.Text.ToString() + ".jpg ");
                //pbQuanLy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }

        private void TrangChu_QuanLy_Load(object sender, EventArgs e)
        {
            GanDuLieu();
        }

        private void TrangChu_QuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất? ", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
