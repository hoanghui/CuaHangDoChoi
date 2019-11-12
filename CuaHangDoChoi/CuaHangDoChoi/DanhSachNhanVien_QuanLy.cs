using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangDoChoi
{
    public partial class DanhSachNhanVien_QuanLy : Form
    {
        static BindingSource bd = new BindingSource();

        public int manv { get; private set; }
        public string hoten { get; private set; }
        public int cmnd { get; private set; }
        public string ngaysinh { get; private set; }
        public string gioitinh { get; private set; }
        public string tendangnhap { get; private set; }

        public DanhSachNhanVien_QuanLy()
        {
            InitializeComponent();
        }

        void HienThiDanhSach()
       {
            bd.DataSource = NhanVienDAO.Instance.laynhanvien();
            dgvNhanVien.DataSource = bd;

            // set tên cột
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            
            dgvNhanVien.Columns[1].HeaderText = "Họ tên nhân viên";

            dgvNhanVien.Columns[1].Width = 150; // set độ rộng cho cột

            dgvNhanVien.Columns[2].HeaderText = "CMND";

            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";

            dgvNhanVien.Columns[3].HeaderText = "Giới tính";

            dgvNhanVien.Columns[5].HeaderText = "Tên đăng nhập";

            GanDuLieu();
        }

        void GanDuLieu()
        {
            txtNhanVienID.DataBindings.Add("Text", dgvNhanVien.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
            txtName.DataBindings.Add("Text", dgvNhanVien.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvNhanVien.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtBirthDay.DataBindings.Add("Text", dgvNhanVien.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
            dtpNgaySinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
            txtSex.DataBindings.Add("Text", dgvNhanVien.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            txtUserName.DataBindings.Add("Text", dgvNhanVien.DataSource, "tenDangNhap", true, DataSourceUpdateMode.Never);
        }

        private void DanhSachNhanVien_QuanLy_Load(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtBirthDay.Enabled = false;
            txtCMND.Enabled = false;
            txtSex.Enabled = false;
            txtNhanVienID.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtUserName.Enabled = false;
            HienThiDanhSach();
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

            
                bool result = NhanVienDAO.Instance.CapNhat(manv, hoten, cmnd, ngaysinh, gioitinh, tendangnhap);
                if (result)
                {
                    MessageBox.Show("Sửa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNhanVienID.DataBindings.Clear();
                    txtName.DataBindings.Clear();
                    txtBirthDay.DataBindings.Clear();
                    txtSex.DataBindings.Clear();
                    txtUserName.DataBindings.Clear();
                    dtpNgaySinh.DataBindings.Clear();
                    txtCMND.DataBindings.Clear();

                    HienThiDanhSach();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
            

            txtName.Enabled = false;
            txtBirthDay.Enabled = false;
            txtCMND.Enabled = false;
            txtSex.Enabled = false;
            txtNhanVienID.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtUserName.Enabled = false;
            
        }

        

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            //if (this.dgvNhanVien.SelectedRows.Count > 0)
            //{
            //    dgvNhanVien.Rows.RemoveAt(this.dgvNhanVien.SelectedRows[0].Index);
            //}
            bool result = NhanVienDAO.Instance.XoaNV(int.Parse(txtNhanVienID.Text));
            if(result)
            {
                MessageBox.Show("Xóa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Dispose(false);
        }

        private void DanhSachNhanVien_QuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất? ", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNhanVienID_TextChanged(object sender, EventArgs e)
        {
            if(txtNhanVienID.Enabled == false)
            {
                if (int.Parse(txtNhanVienID.Text.ToString()) != 0)
                {
                    txtName.Visible = true;
                    pbNhanVien.Visible = true;
                    txtBirthDay.Visible = true;
                    txtCMND.Visible = true;
                    txtSex.Visible = true;
                    txtNhanVienID.Visible = true;
                    dtpNgaySinh.Visible = true;
                    txtUserName.Visible = true;
                    pbNhanVien.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachNhanVien\" + txtNhanVienID.Text.ToString() + ".jpg ");
                    pbNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    if (int.Parse(txtNhanVienID.Text.ToString()) == 0)
                    {
                        txtName.Visible = false;
                        pbNhanVien.Visible = false;
                        txtBirthDay.Visible = false;
                        txtCMND.Visible = false;
                        txtSex.Visible = false;
                        txtNhanVienID.Visible = false;
                        dtpNgaySinh.Visible = false;
                        txtUserName.Visible = false;
                    }
                }
            }
            
        }

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtBirthDay.Enabled = true;
            txtCMND.Enabled = true;
            txtSex.Enabled = true;
            txtNhanVienID.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtUserName.Enabled = true;
        }

        void Refresh()
        {
            DanhSachNhanVien_QuanLy nv = new DanhSachNhanVien_QuanLy();
            nv.Show();
            this.Dispose(false);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //Refresh();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bd.DataSource = NhanVienDAO.Instance.TimNV(int.Parse(txtTimKiem.Text.ToString()));
            }
            catch
            {
                MessageBox.Show("Tìm không có", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
