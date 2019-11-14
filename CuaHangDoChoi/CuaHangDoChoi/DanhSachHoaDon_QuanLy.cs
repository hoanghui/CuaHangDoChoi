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
    
    public partial class DanhSachHoaDon_QuanLy : Form
    {
        BindingSource bd = new BindingSource();
        public DanhSachHoaDon_QuanLy()
        {
            InitializeComponent();
            HienThiDanhSach();
        }
        void HienThiDanhSach()
        {
            bd.DataSource = HoaDonDAO.Instance.LayDanhSachHoaDon();
            dgvHoaDon.DataSource = bd;

            // set tên cột
            dgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dgvHoaDon.Columns[0].Width = 100;
            dgvHoaDon.Columns[1].HeaderText = "Mã khách hàng";

            dgvHoaDon.Columns[2].HeaderText = "Mã nhân viên";

            dgvHoaDon.Columns[3].HeaderText = "Ngày tạo hóa đơn";
            dgvHoaDon.Columns[0].Width = 150;
            //GanDuLieu();
        }

        //void GanDuLieu()
        //{
        //    txtNhanVienID.DataBindings.Add("Text", dgvNhanVien.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
        //    txtName.DataBindings.Add("Text", dgvNhanVien.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
        //    txtCMND.DataBindings.Add("Text", dgvNhanVien.DataSource, "CMND", true, DataSourceUpdateMode.Never);
        //    dtpNgaySinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
        //    txtSex.DataBindings.Add("Text", dgvNhanVien.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
        //    txtUserName.DataBindings.Add("Text", dgvNhanVien.DataSource, "tenDangNhap", true, DataSourceUpdateMode.Never);
        //}
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btListNhanVien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_QuanLy nv = new DanhSachNhanVien_QuanLy();
            nv.Show();
            this.Dispose(false);
        }

        private void btListKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang kh = new DanhSachKhachHang();
            kh.Show();
            this.Dispose(false);
        }

        private void btListHangHoa_Click(object sender, EventArgs e)
        {
            DanhSachHangHoa_QuanLy hh = new DanhSachHangHoa_QuanLy();
            hh.Show();
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

        private void DanhSachHoaDon_QuanLy_Load(object sender, EventArgs e)
        {
             
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pbSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
