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
    public partial class DanhSachNhanVien : Form
    {
        public DanhSachNhanVien()
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

        }

        void LoadListView()
        {
            lvDanhSachNhanVien.Columns.Add("Mã nhân viên");
        }
    }
}
