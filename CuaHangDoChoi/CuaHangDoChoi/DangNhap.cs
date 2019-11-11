using DAO;
using DTO;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignIn()
        {
           
            string tenDangNhap = txtUsername.Text;
            string matKhau = txtPassword.Text;
            TaiKhoan taikhoan = TaiKhoanDAO.Instance.layTaiKhoan(tenDangNhap);
            if (taikhoan != null)
            {
                if (matKhau == taikhoan.MatKhau)
                {
                    if (taikhoan.LoaiTaiKhoan == 1)
                    {
                        TrangChu_QuanLy home = new TrangChu_QuanLy();
                        home.funData(this.txtUsername);
                        home.Show();
                        this.Dispose(false);
                        
                    }
                    else
                    {
                        NhanVien nv = new NhanVien();
                        nv.Show();
                        this.Dispose(false);
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại. Vui lòng nhập lại!", "ĐĂNG NHẬP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng nhập lại!");
            }
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            SignIn();
            //string tenDangNhap = txtUsername.Text;
            //string matKhau = txtPassword.Text;
            //TaiKhoan taikhoan = TaiKhoanDAO.Instance.layTaiKhoan(tenDangNhap);
            //if (taikhoan != null)
            //{
            //    if (matKhau == taikhoan.MatKhau)
            //    {
            //        if (taikhoan.LoaiTaiKhoan == 1)
            //        {
            //            TrangChu_QuanLy tc = new TrangChu_QuanLy();
            //            tc.Show();
            //            this.Dispose(false);
            //        }
            //        else
            //        {
            //            NhanVien nv = new NhanVien();
            //            nv.Show();
            //            this.Dispose(false);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Đăng nhập thất bại. Vui lòng nhập lại!", "ĐĂNG NHẬP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng nhập lại!");
            //}


        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Enter:
                    {
                        SignIn();
                        return true;
                    }
                case Keys.Tab:
                    {
                       
                            return txtPassword.Focus();
          
                    }
            }
            return false;
        }


    }
}
