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
        BindingSource bd = new BindingSource();

        public int manv { get; private set; }
        public string hoten { get; private set; }
        public int cmnd { get; private set; }
        public string ngaysinh { get; private set; }
        public string gioitinh { get; private set; }
        public string tendangnhap { get; private set; }
        public string matkhau { get; private set; }
        public DateTime BirthDay { get; private set; }

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
            dgvNhanVien.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvNhanVien.Columns[1].HeaderText = "Họ tên nhân viên";

            dgvNhanVien.Columns[1].Width = 150; // set độ rộng cho cột

            dgvNhanVien.Columns[2].HeaderText = "CMND";
            dgvNhanVien.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNhanVien.Columns[3].HeaderText = "Giới tính";

            dgvNhanVien.Columns[5].HeaderText = "Tên đăng nhập";

            dgvNhanVien.Columns[6].HeaderText = "Trạng thái";

            

            GanDuLieu();
        }

        void GanDuLieu()
        {

            txtNhanVienID.DataBindings.Add("Text", dgvNhanVien.DataSource, "maNhanVien", true, DataSourceUpdateMode.Never);
            txtName.DataBindings.Add("Text", dgvNhanVien.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvNhanVien.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            dtpNgaySinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
            txtSex.DataBindings.Add("Text", dgvNhanVien.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            txtUserName.DataBindings.Add("Text", dgvNhanVien.DataSource, "tenDangNhap", true, DataSourceUpdateMode.Never);

            
        }

        private void DanhSachNhanVien_QuanLy_Load(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            btnCapNhat.Visible = false;
            txtCMND.Enabled = false;
            txtSex.Enabled = false;
            txtNhanVienID.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtUserName.Enabled = false;
            HienThiDanhSach();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(dtpNgaySinh.Value.Year > 2000)
            {
                MessageBox.Show("Năm sinh không đúng, bạn chưa đủ tuổi!", "Lỗi năm sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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
                bool sexNew;
                
                if (result)
                {
                    MessageBox.Show("Sửa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNhanVienID.DataBindings.Clear();
                    txtName.DataBindings.Clear();

                    txtSex.DataBindings.Clear();
                    txtUserName.DataBindings.Clear();
                    dtpNgaySinh.DataBindings.Clear();
                    txtCMND.DataBindings.Clear();

                    btnXacNhan.Enabled = true;
                    btnThoat.Enabled = true;
                    btnCapNhat.Visible = false;


                    HienThiDanhSach();
                }
                else
                {
                    if (txtSex.Text != "Nam")
                    {
                        sexNew = NhanVienDAO.Instance.CapNhat(manv, hoten, cmnd, ngaysinh, "Nu", tendangnhap);
                    }
                    else
                    {
                        sexNew = NhanVienDAO.Instance.CapNhat(manv, hoten, cmnd, ngaysinh, "Nam", tendangnhap);

                    }
                    MessageBox.Show("Sửa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



                txtName.Enabled = false;

                txtCMND.Enabled = false;
                txtSex.Enabled = false;
                txtNhanVienID.Enabled = false;
                dtpNgaySinh.Enabled = false;
                txtUserName.Enabled = false;

                btXoaNV.Enabled = true;
                btThemNV.Enabled = true;
                btnSua.Enabled = true;
                btnCapNhat.Enabled = true;
            }
           
            
            
        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            //if (this.dgvNhanVien.SelectedRows.Count > 0)
            //{
            //    dgvNhanVien.Rows.RemoveAt(this.dgvNhanVien.SelectedRows[0].Index);
            //}
            
            
                bool result = NhanVienDAO.Instance.XoaNV(int.Parse(txtNhanVienID.Text));
                if (result)
                {
                    MessageBox.Show("Xóa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information); txtNhanVienID.DataBindings.Clear();
                    txtName.DataBindings.Clear();

                    txtSex.DataBindings.Clear();
                    txtUserName.DataBindings.Clear();
                    dtpNgaySinh.DataBindings.Clear();
                    txtCMND.DataBindings.Clear();
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
            if (MessageBox.Show("Bạn có chắc muốn thoát? ", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                
            }
        }

        private void txtNhanVienID_TextChanged(object sender, EventArgs e)
        {
            //if(txtNhanVienID.Enabled == false)
            //{
            if (txtNhanVienID.Text != "")
            {
                if (int.Parse(txtNhanVienID.Text.ToString()) != 0)
                    {
                        txtName.Visible = true;
                        pbNhanVien.Visible = true;

                        txtCMND.Visible = true;
                        txtSex.Visible = true;
                        txtNhanVienID.Visible = true;
                        dtpNgaySinh.Visible = true;
                        txtUserName.Visible = true;
                        try
                        {
                            pbNhanVien.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachNhanVien\" + int.Parse(txtNhanVienID.Text) + ".jpg");

                        }
                        catch
                        {
                            pbNhanVien.Image = Image.FromFile(Application.StartupPath + @"\Image\DanhSachNhanVien\default.jpg");
                        }
                }
                else
                {
                    if (int.Parse(txtNhanVienID.Text.ToString()) == 0)
                    {
                            txtNhanVienID.Clear();
                            txtName.Visible = false;
                            pbNhanVien.Visible = false;

                            txtCMND.Visible = false;
                            txtSex.Visible = false;
                            txtNhanVienID.Visible = false;
                            dtpNgaySinh.Visible = false;
                            txtUserName.Visible = false;
                    }
                }
            }

            //}

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnCapNhat.Visible = true;
            txtName.Enabled = true;
            txtCMND.Enabled = true;
            txtSex.Enabled = true;
            //txtNhanVienID.Enabled = true;
            dtpNgaySinh.Enabled = true;
            //txtUserName.Enabled = true;

            // tắt các nút thêm, xóa, xác nhận, thoát
            btThemNV.Enabled = false;
            btXoaNV.Enabled = false;
            btnXacNhan.Enabled = false;
            btnThoat.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //dgvNhanVien.DataSource = null ;
            //txtNhanVienID.Clear();
            //txtName.Clear();
            //txtSex.Clear();
            //dtpNgaySinh.Visible = false;
            //txtCMND.Clear();
            //txtUserName.Clear();
            //HienThiDanhSach();
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
                    MessageBox.Show("Vui lòng nhập mã nhân viên", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                {
                    bd.DataSource = NhanVienDAO.Instance.TimNV(int.Parse(txtTimKiem.Text.ToString()));
                    if (bd.Count == 0)
                    {
                        MessageBox.Show("Tìm không có", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtNhanVienID.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtSex.DataBindings.Clear();
                txtUserName.DataBindings.Clear();
                dtpNgaySinh.DataBindings.Clear();
                txtCMND.DataBindings.Clear();

                HienThiDanhSach();
            }
        }
         
        private void btThemNV_Click(object sender, EventArgs e)
        {
            panelThemNhanVien.Visible = true;
            btThemNV.Enabled = false;
            btXoaNV.Enabled = false;
            btnSua.Enabled = false;
            btnCapNhat.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dtpBirthdayNew.Value.Year > 2000)
            {
                MessageBox.Show("Năm sinh không đúng, bạn chưa đủ tuổi!", "Lỗi năm sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // bắt ngoại lệ khi người dùng nhập k đúng kiểu dữ liệu
                try
                {

                    ngaysinh = dtpBirthdayNew.Value.Month + "/" + dtpBirthdayNew.Value.Day + "/" + dtpBirthdayNew.Value.Year;
                    BirthDay = dtpBirthdayNew.Value;
                    hoten = txtNameNew.Text;
                    cmnd = int.Parse(txtCMNDNew.Text);
                    //Bắt lỗi giới tính
                    gioitinh = txtSexNew.Text;
                    tendangnhap = txtUserNameNew.Text;
                    matkhau = txtMatKhau.Text;
                }
                catch
                {
                    MessageBox.Show("Nhập chưa đúng định dạng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool result1 = NhanVienDAO.Instance.KiemTraNhanVienTonTaiVoiTenDangNhap(tendangnhap);
                bool result2;
                if (result1)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtSexNew.Text != "Nam")
                    {
                        result2 = NhanVienDAO.Instance.ThemNV(hoten, cmnd, ngaysinh, "Nu", tendangnhap, matkhau);
                    }
                    else
                    {
                        result2 = NhanVienDAO.Instance.ThemNV(hoten, cmnd, ngaysinh, "Nam", tendangnhap, matkhau);

                    }
                    if (result2)
                    {
                        //txtNhanVienIDNew.DataBindings.Clear();
                        //txtNameNew.DataBindings.Clear();
                        //txtSexNew.DataBindings.Clear();
                        //dtpBirthdayNew.DataBindings.Clear();
                        //txtCMNDNew.DataBindings.Clear();
                        //txtNhanVienIDNew.DataBindings.Clear();

                        txtNhanVienID.DataBindings.Clear();
                        txtName.DataBindings.Clear();
                        txtSex.DataBindings.Clear();
                        txtUserName.DataBindings.Clear();
                        dtpNgaySinh.DataBindings.Clear();
                        txtCMND.DataBindings.Clear();


                        MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panelThemNhanVien.Visible = false;
                        txtNhanVienIDNew.Clear();
                        txtNameNew.Clear();
                        txtSexNew.Clear();
                        //dtpBirthdayNew.Visible = false;
                        dtpBirthdayNew.ResetText();
                        txtCMNDNew.Clear();
                        txtUserNameNew.Clear();

                        // bật enabled các nút thêm, xóa, sửa, cập nhật
                        btThemNV.Enabled = true;
                        btXoaNV.Enabled = true;
                        btnSua.Enabled = true;
                        btnCapNhat.Enabled = true;

                        HienThiDanhSach();

                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }



            }
        }

        private void btnDSKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang kh = new DanhSachKhachHang();
            kh.Show();
            this.Dispose(false);
        }

        private void btnDSSanPham_Click(object sender, EventArgs e)
        {
            DanhSachHangHoa_QuanLy hh = new DanhSachHangHoa_QuanLy();
            hh.Show();
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn khỏi thêm nhân viên? ", "Thoát khỏi thêm nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                // bật enabled các nút thêm, xóa, sửa, cập nhật
                btXoaNV.Enabled = true;
                btThemNV.Enabled = true;
                btnSua.Enabled = true;
                btnCapNhat.Enabled = true;

                panelThemNhanVien.Visible = false;
                txtNhanVienIDNew.Clear();
                txtNameNew.Clear();
                txtSexNew.Clear();
                //dtpBirthdayNew.Visible = false;
                dtpBirthdayNew.ResetText();
                txtCMNDNew.Clear();
                txtUserNameNew.Clear();
                panelThemNhanVien.Visible = false;
            }
                
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "Nhập mã nhân viên...")
            {
                txtTimKiem.Clear();
            }
        }

        private void DanhSachNhanVien_QuanLy_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "Nhập mã nhân viên...";
            }
        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
