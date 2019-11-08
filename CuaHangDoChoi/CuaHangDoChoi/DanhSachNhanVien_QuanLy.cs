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
    public partial class DanhSachNhanVien_QuanLy : Form
    {
        BindingSource bd = new BindingSource();

        public int manv { get; private set; }
        public string hoten { get; private set; }
        public int cmnd { get; private set; }
        public string ngaysinh { get; private set; }
        public string gioitinh { get; private set; }
        public string tendangnhap { get; private set; }

        public DanhSachNhanVien_QuanLy()
        {
            InitializeComponent();
            HienThiDanhSach();
            GanDuLieu();
        }

       void HienThiDanhSach()
        {
            bd.DataSource = NhanVienDAO.Instance.laynhanvien();
            dgvNhanVien.DataSource = bd;

            // set tên cột
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";

            dgvNhanVien.Columns[1].HeaderText = "Họ tên nhân viên";

            dgvNhanVien.Columns[2].HeaderText = "CMND";

            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";

            dgvNhanVien.Columns[4].HeaderText = "Giới tính";

            dgvNhanVien.Columns[5].HeaderText = "Tên đăng nhập";
        }

        void HienThiDanhSach2(object bd)
        {
            dgvNhanVien.DataSource = bd;

            // set tên cột
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";

            dgvNhanVien.Columns[1].HeaderText = "Họ tên nhân viên";

            dgvNhanVien.Columns[2].HeaderText = "CMND";

            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";

            dgvNhanVien.Columns[4].HeaderText = "Giới tính";

            dgvNhanVien.Columns[5].HeaderText = "Tên đăng nhập";
        }

        void GanDuLieu()
        {
            txtNhanVienID.DataBindings.Add("Text", dgvNhanVien.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
            txtName.DataBindings.Add("Text", dgvNhanVien.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvNhanVien.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtBirthDay.DataBindings.Add("Text", dgvNhanVien.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
            txtSex.DataBindings.Add("Text", dgvNhanVien.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            txtUserName.DataBindings.Add("Text", dgvNhanVien.DataSource, "tenDangNhap", true, DataSourceUpdateMode.Never);
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DanhSachNhanVien_QuanLy_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBirthDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
                // bắt ngoại lệ khi người dùng nhập k đúng kiểu dữ liệu
                try
                {
                    manv = int.Parse(txtNhanVienID.Text);
                    ngaysinh = dtpNgaySinh.Value.Day + "-" + dtpNgaySinh.Value.Month + "-" + dtpNgaySinh.Value.Year;
                    hoten = txtName.Text;
                    cmnd = int.Parse(txtCMND.Text);
                    gioitinh = txtSex.Text;
                    tendangnhap = txtUserName.Text;

                }
                catch
                {
                    MessageBox.Show("Nhập chưa đúng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
           
           
            
            bool ketqua = NhanVienDAO.Instance.SuaThongTinNhanVien(manv, hoten, cmnd, ngaysinh, gioitinh, tendangnhap);
            if (ketqua)
            {
                bd.DataSource = NhanVienDAO.Instance.CapNhat(manv, hoten, cmnd, ngaysinh, gioitinh, tendangnhap);
                HienThiDanhSach2(bd);
                MessageBox.Show("Sửa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Sửa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
