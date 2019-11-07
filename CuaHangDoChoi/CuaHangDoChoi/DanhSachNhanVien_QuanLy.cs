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
        public DanhSachNhanVien_QuanLy()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        //private void DanhSachNhanVien_Load(object sender, EventArgs e)
        //{
        //    lvDanhSachNhanVien.View = View.Details;
        //    lvDanhSachNhanVien.GridLines = true;
            

        //    lvDanhSachNhanVien.Columns.Add("Mã nhân viên", 100);
        //    lvDanhSachNhanVien.Columns.Add("Tên nhân viên", 300);
        //}

        //private void lvDanhSachNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (lvDanhSachNhanVien.SelectedItems.Count == 0)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        ListViewItem item = lvDanhSachNhanVien.SelectedItems[0];
        //        lvDanhSachNhanVien.Text = item.SubItems[0].Text;
        //        lvDanhSachNhanVien.Text = item.SubItems[1].Text;
        //    }
        //}

        //void LoadListView()
        //{
        //    lvDanhSachNhanVien.Columns.Add("Mã nhân viên");
        //}

       void HienThiDanhSach()
        {
            dgvNhanVien.DataSource = NhanVienDAO.Instance.LayDanhSachKH();

            // set tên cột
            dgvNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";

            dgvNhanVien.Columns[1].HeaderText = "Họ tên nhân viên";

            dgvNhanVien.Columns[2].HeaderText = "CMND";

            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";

            dgvNhanVien.Columns[4].HeaderText = "Giới tính";

            dgvNhanVien.Columns[5].HeaderText = "Tên đăng nhập";
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
