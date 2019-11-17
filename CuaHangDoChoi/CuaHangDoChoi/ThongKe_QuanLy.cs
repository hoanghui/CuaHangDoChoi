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
    public partial class ThongKe_QuanLy : Form
    {
        public ThongKe_QuanLy()
        {
            InitializeComponent();
        }

        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien_QuanLy nv = new DanhSachNhanVien_QuanLy();
            nv.Show();
            this.Dispose(false);
        }

        private void btnDSKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang kh = new DanhSachKhachHang();
            kh.Show();
            this.Dispose(false);
        }

        private void btnDSHangHoa_Click(object sender, EventArgs e)
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

        private void ThongKe_QuanLy_Load(object sender, EventArgs e)
        {
            for(int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i);
            }
            for(int j = 1998; j <= DateTime.Now.Year;j++)
            {
                cbNam.Items.Add(j);
            }
             
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
           
            double thanhtien = 0; 
            if(cbNam.Text != "" && cbThang.Text != "")
            {
                thanhtien = HoaDonDAO.Instance.LayDanhSachHoaDonTheoThangNam(int.Parse(cbThang.Text), int.Parse(cbNam.Text));
                if (thanhtien == -1.0)
                {
                    MessageBox.Show("Chọn không hợp lệ", "Thông báo thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    lbDoanhThu.Text = String.Format("{0:0,0} VNĐ", thanhtien);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tháng năm cần thống kê!", "Thông báo thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Dispose(false);
        }
    }
}
