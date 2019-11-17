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
    public partial class DanhSachKhachHang_NhanVien : Form
    {
        BindingSource bd = new BindingSource();

        public int makh { get; private set; }
        public string hoten { get; private set; }
        public int cmnd { get; private set; }
        public string ngaysinh { get; private set; }
        public string gioitinh { get; private set; }
        public int sodienthoai { get; private set; }

        public DateTime birthday { get; private set; }

        public DanhSachKhachHang_NhanVien()
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
            dgvKhachHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvKhachHang.Columns[1].HeaderText = "Họ tên khách hàng";

            dgvKhachHang.Columns[1].Width = 150; // set độ rộng cho cột

            dgvKhachHang.Columns[2].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvKhachHang.Columns[3].HeaderText = "CMND";
            dgvKhachHang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvKhachHang.Columns[4].HeaderText = "Giới tính";

            dgvKhachHang.Columns[5].HeaderText = "Ngày sinh";
            dgvKhachHang.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvKhachHang.Columns[6].HeaderText = "Trạng thái";



            GanDuLieu();

        }

        void GanDuLieu()
        {
            txtMaKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtSex.DataBindings.Clear();
           
            dtpNgaySinh.DataBindings.Clear();
            txtCMND.DataBindings.Clear();

            txtMaKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "maKhachHang", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvKhachHang.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add("Text", dgvKhachHang.DataSource, "soDienThoai", true, DataSourceUpdateMode.Never);
            dtpNgaySinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never);
            txtSex.DataBindings.Add("Text", dgvKhachHang.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            

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
            
            txtTenKhachHang.Enabled = true;
            txtSex.Enabled = true;
            txtCMND.Enabled = true;
            
            txtSDT.Enabled = true;
            dgvKhachHang.Enabled = true;
            btnCapNhat.Visible = true;
            btThemKH.Enabled = false;
            btXoaKH.Enabled = false;


        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtpNgaySinh.Value.Year > 2000)
            {
                MessageBox.Show("Năm sinh không đúng, bạn chưa đủ tuổi!", "Lỗi năm sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    makh = int.Parse(txtMaKhachHang.Text);
                    ngaysinh = dtpNgaySinh.Value.Month + "/" + dtpNgaySinh.Value.Day + "/" + dtpNgaySinh.Value.Year;
                    hoten = txtTenKhachHang.Text;
                    cmnd = int.Parse(txtCMND.Text);
                    gioitinh = txtSex.Text;
                    sodienthoai = int.Parse(txtSDT.Text);
                }
                catch
                {
                    MessageBox.Show("Nhập chưa đúng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //bool sexNew;
                bool result = KhachHangDAO.Instance.SuaKH(makh, hoten, sodienthoai, cmnd, ngaysinh, gioitinh);
                if (result)
                {
                    MessageBox.Show("Sửa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKhachHang.DataBindings.Clear();
                    txtTenKhachHang.DataBindings.Clear();
                    txtSDT.DataBindings.Clear();
                    txtSex.DataBindings.Clear();
                    
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
               



            }



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
                    MessageBox.Show("Vui lòng nhập mã khách hàng", "Tìm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                {
                    bd.DataSource = KhachHangDAO.Instance.TimKH(int.Parse(txtTimKiem.Text.ToString()));
                    if (bd.Count == 0)
                    {
                        MessageBox.Show("Tìm không có", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtMaKhachHang.DataBindings.Clear();
                txtTenKhachHang.DataBindings.Clear();
                txtSex.DataBindings.Clear();
                dtpNgaySinh.DataBindings.Clear();
                txtCMND.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
              

                HienThiDanhSach();
            }
        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            panelThem.Visible = true;
            btThemKH.Enabled = false;
            btXoaKH.Enabled = false;
            btnChinhSua.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dtpNgaySinh_New.Value.Year > 2000)
            {
                MessageBox.Show("Năm sinh không đúng, bạn chưa đủ tuổi!", "Lỗi năm sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // bắt ngoại lệ khi người dùng nhập k đúng kiểu dữ liệu
                try
                {
                    ngaysinh = dtpNgaySinh_New.Value.Month + "-" + dtpNgaySinh_New.Value.Day + "-" + dtpNgaySinh_New.Value.Year;
                    sodienthoai = int.Parse(txtSoDienThoai_New.Text);
                    hoten = txtTenKhachHang_New.Text;
                    cmnd = int.Parse(txtCMND_New.Text);
                    //Bắt lỗi giới tính
                    gioitinh = txtGioiTinh_New.Text;
                }
                catch
                {
                    MessageBox.Show("Nhập chưa đúng định dạng!Nhập lại", "Lỗi đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool result2;
                
                    if (txtGioiTinh_New.Text != "Nam")
                    {
                        result2 = KhachHangDAO.Instance.ThemKH(hoten, sodienthoai, cmnd, ngaysinh, "Nu");
                    }
                    else
                    {
                        result2 = KhachHangDAO.Instance.ThemKH(hoten,sodienthoai, cmnd, ngaysinh, "Nam");

                    }
                    if (result2)
                    {
                        //txtNhanVienIDNew.DataBindings.Clear();
                        //txtNameNew.DataBindings.Clear();
                        //txtSexNew.DataBindings.Clear();
                        //dtpBirthdayNew.DataBindings.Clear();
                        //txtCMNDNew.DataBindings.Clear();
                        //txtNhanVienIDNew.DataBindings.Clear();

                        txtMaKhachHang.DataBindings.Clear();
                        txtTenKhachHang.DataBindings.Clear();
                        txtSex.DataBindings.Clear();
                        dtpNgaySinh.DataBindings.Clear();
                        txtCMND.DataBindings.Clear();


                        MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panelThem.Visible = false;
                        txtTenKhachHang_New.Clear();
                        txtGioiTinh_New.Clear();
                        //dtpBirthdayNew.Visible = false;
                        dtpNgaySinh_New.ResetText();
                        txtCMND_New.Clear();
                        

                        // bật enabled các nút thêm, xóa, sửa, cập nhật
                        btThemKH.Enabled = true;
                        btXoaKH.Enabled = true;
                        btnChinhSua.Enabled = true;
                        btnCapNhat.Enabled = true;

                        HienThiDanhSach();

                    }
                    //else
                    //{
                    //    MessageBox.Show("Mã nhân viên phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                



            }
        }

        private void btXoaKH_Click(object sender, EventArgs e)
        {
            bool result = KhachHangDAO.Instance.XoaKH(int.Parse(txtMaKhachHang.Text));
            if (result)
            {
                MessageBox.Show("Xóa thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhachHang.DataBindings.Clear();
                txtTenKhachHang.DataBindings.Clear();
                txtSex.DataBindings.Clear();
                dtpNgaySinh.DataBindings.Clear();
                txtCMND.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
                HienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Xóa không thành công", "Sử thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn khỏi thêm khách hàng? ", "Thoát khỏi thêm khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                // bật enabled các nút thêm, xóa, sửa, cập nhật
                btXoaKH.Enabled = true;
                btThemKH.Enabled = true;
                btnChinhSua.Enabled = true;
                btnCapNhat.Enabled = true;

                panelThem.Visible = false;
                txtTenKhachHang_New.Clear();
                txtGioiTinh_New.Clear();
                //dtpBirthdayNew.Visible = false;
                dtpNgaySinh_New.ResetText();
                txtCMND_New.Clear();
             
            
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ThanhToan tt = new ThanhToan();
            tt.Show();
            this.Dispose(false);
        }


        // bắt ngoại lệ khi người dùng nhập k đúng kiểu dữ liệu


    }
}

