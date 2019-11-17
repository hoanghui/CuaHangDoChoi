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
        BindingSource bd1 = new BindingSource();

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
            dgvHoaDon.Columns[1].HeaderText = "Mã nhân viên";

            dgvHoaDon.Columns[2].HeaderText = "Mã khách hàng";

            dgvHoaDon.Columns[3].HeaderText = "Ngày tạo hóa đơn";

            dgvHoaDon.Columns[4].HeaderText = "Thành tiền";
                
            dgvHoaDon.Columns[0].Width = 150;

            lbMaHoaDon.DataBindings.Clear();
            lbMaNhanVien.DataBindings.Clear();
            lbMaKhachHang.DataBindings.Clear();
            lbNgayTao.DataBindings.Clear();
            lbThanhTien.DataBindings.Clear();

            GanDuLieu();
        }

        void GanDuLieu()
        {
            
            lbMaHoaDon.DataBindings.Add("Text", dgvHoaDon.DataSource, "maHoaDon", true, DataSourceUpdateMode.Never);
            
            lbMaNhanVien.DataBindings.Add("Text", dgvHoaDon.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
            lbMaKhachHang.DataBindings.Add("Text", dgvHoaDon.DataSource, "maKhachHang", true, DataSourceUpdateMode.Never);
            lbNgayTao.DataBindings.Add("Text", dgvHoaDon.DataSource, "ngayTao", true, DataSourceUpdateMode.Never);
            lbThanhTien.DataBindings.Add("Text", dgvHoaDon.DataSource, "thanhTien", true, DataSourceUpdateMode.Never);
            
        }
        
        void HienThiChiTietHoaDon()
        {

            bd1.DataSource = ChiTietHoaDonDAO.Instance.layCTHD(int.Parse(lbMaHoaDon.Text));
            dgvSanPhamBan.DataSource = bd1;

            // set tên cột
            dgvSanPhamBan.Columns[0].HeaderText = "Mã hóa đơn";
            dgvSanPhamBan.Columns[0].Width = 100;
            dgvSanPhamBan.Columns[1].HeaderText = "Mã sản phẩm";

            dgvSanPhamBan.Columns[2].HeaderText = "Đơn giá";

            dgvSanPhamBan.Columns[3].HeaderText = "Số lượng";

           
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
            HienThiDanhSach();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvSanPhamBan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HienThiChiTietHoaDon();
        }

        private void dgvHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HienThiChiTietHoaDon();
        }
    }
}
