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
    public partial class DanhSachKhachHang : Form
    {
        BindingSource bd = new BindingSource();

        public int makh { get; private set; }
        public string hoten { get; private set; }
        public int cmnd { get; private set; }
        public DateTime ngaysinh { get; private set; }
        public string gioitinh { get; private set; }
        public string diachi { get; private set; }
        public int sodienthoai { get; private set; }

    

        public DanhSachKhachHang()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        void HienThiDanhSach()
        {
            bd.DataSource = KhachHangDAO.Instance.LayDSKhachHang();
            dgvKhachHang.DataSource = bd;

            // set tên cột
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";

            dgvKhachHang.Columns[1].HeaderText = "Họ tên khách hàng";

            dgvKhachHang.Columns[1].Width = 150; // set độ rộng cho cột

            dgvKhachHang.Columns[2].HeaderText = "Số điện thoại";

            dgvKhachHang.Columns[3].HeaderText = "CMND";

            dgvKhachHang.Columns[4].HeaderText = "Giới tính";

            dgvKhachHang.Columns[5].HeaderText = "Ngày sinh";

            dgvKhachHang.Columns[6].HeaderText = "Địa chỉ";

            txtMaKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtSex.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            txtCMND.DataBindings.Clear();

            GanDuLieu();

        }

        void GanDuLieu()
        {
            txtMaKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "maKhachHang", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvKhachHang.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add("Text", dgvKhachHang.DataSource, "soDienThoai", true, DataSourceUpdateMode.Never);
            dtpNgaySinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
            txtSex.DataBindings.Add("Text", dgvKhachHang.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", dgvKhachHang.DataSource, "diaChi", true, DataSourceUpdateMode.Never);
        }

     
        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_QuanLy nv = new DanhSachNhanVien_QuanLy();
            nv.Show();
            this.Dispose(false);
        }

        private void btnDSHoaDon_Click(object sender, EventArgs e)
        {
            DanhSachHoaDon_QuanLy hd = new DanhSachHoaDon_QuanLy();
            hd.Show();
            this.Dispose(false);
        }

        private void btnDSHangHoa_Click(object sender, EventArgs e)
        {
            DanhSachHangHoa_QuanLy hh = new DanhSachHangHoa_QuanLy();
            hh.Show();
            this.Dispose(false);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe_QuanLy tk = new ThongKe_QuanLy();
            tk.Show();
            this.Dispose(false);
        }

        private void DanhSachKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void DanhSachKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKhachHang.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtSex.Enabled = false;
            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            dgvKhachHang.Enabled = false;

            HienThiDanhSach();
        }

        private void btnDSKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Enabled = true;
            txtTenKhachHang.Enabled = true;
            txtSex.Enabled = true;
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            dgvKhachHang.Enabled = true;
            btnCapNhat.Visible = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // bắt ngoại lệ khi người dùng nhập k đúng kiểu dữ liệu
            try
            {
                makh = int.Parse(txtMaKhachHang.Text);
                ngaysinh = dtpNgaySinh.Value;
                hoten = txtTenKhachHang.Text;
                cmnd = int.Parse(txtCMND.Text);
                gioitinh = txtSex.Text;
                sodienthoai = int.Parse(txtSDT.Text);
                diachi = txtDiaChi.Text;
            }
            catch
            {
                MessageBox.Show("Nhập chưa đúng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool result = KhachHangDAO.Instance.SuaKH(makh, hoten, cmnd,sodienthoai, ngaysinh, gioitinh, diachi);
            if (result)
            {
                MessageBox.Show("Sửa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhachHang.DataBindings.Clear();
                txtTenKhachHang.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
                txtSex.DataBindings.Clear();
                txtDiaChi.DataBindings.Clear();
                dtpNgaySinh.DataBindings.Clear();
                txtCMND.DataBindings.Clear();

                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



            txtMaKhachHang.Enabled = false;
            txtSDT.Enabled = false;
            txtCMND.Enabled = false;
            txtSex.Enabled = false;
            txtTenKhachHang.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;

        }
    }
}
