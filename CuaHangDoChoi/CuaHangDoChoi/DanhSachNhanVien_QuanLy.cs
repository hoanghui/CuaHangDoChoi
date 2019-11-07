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
        public DanhSachNhanVien_QuanLy()
        {
            InitializeComponent();
            HienThiDanhSach();
            GanDuLieu();
        }

       void HienThiDanhSach()
        {
            bd.DataSource = NhanVienDAO.Instance.LayDanhSachKH();
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
            //txtName.DataBindings.Add("Text", dgvNhanVien, "tenDangNhap", true, DataSourceUpdateMode.Never);
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
    }
}
