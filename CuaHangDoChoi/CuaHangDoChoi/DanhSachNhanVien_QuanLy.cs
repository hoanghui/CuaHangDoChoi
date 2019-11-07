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
        }

        private void DanhSachNhanVien_Load(object sender, EventArgs e)
        {
            lvDanhSachNhanVien.View = View.Details;
            lvDanhSachNhanVien.GridLines = true;
            

            lvDanhSachNhanVien.Columns.Add("Mã nhân viên", 100);
            lvDanhSachNhanVien.Columns.Add("Tên nhân viên", 300);
        }

        private void lvDanhSachNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachNhanVien.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem item = lvDanhSachNhanVien.SelectedItems[0];
                lvDanhSachNhanVien.Text = item.SubItems[0].Text;
                lvDanhSachNhanVien.Text = item.SubItems[1].Text;
            }
        }

        void LoadListView()
        {
            lvDanhSachNhanVien.Columns.Add("Mã nhân viên");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
