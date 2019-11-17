using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DTO;

namespace UnitTestCuaHangDoChoi
{
    /// <summary>
    /// Summary description for NhanVienTest
    /// </summary>
    [TestClass]
    public class TestNhanVien
    {
        public TestNhanVien()
        {
            
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestLayDanhSachNhanVien()
        {
            List<NhanVien> nv = NhanVienDAO.Instance.laynhanvien();
            int expected = 6;
            int actual = nv.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCapNhatNhanVien()
        {
            bool expected = true;
            bool actual = NhanVienDAO.Instance.CapNhat(111,"Nguyễn Cao Kỳ Duyên",1751010046,"19/7/1999","Nu","hoanghuy");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCapNhatNhanVienVoiMaNhanVienKhongTonTai()
        {
            bool expected = false;
            bool actual = NhanVienDAO.Instance.CapNhat(45115, "Nguyễn Cao Kỳ Duyên", 1751010046, "19/7/1999", "Nu", "hoanghuy");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCapNhatNhanVien_SuaTatCaThongTin()
        {
            bool expected = false;
            bool actual = NhanVienDAO.Instance.CapNhat(6, "Hoài Lâm", 175184755, "10/10/1999", "Nam", "hoailam");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThemNhanVien()
        {
            bool expected = true;
            bool actual = NhanVienDAO.Instance.ThemNV("Only C", 123456123, "7/7/1997", "Nam", "ada", "daonhac");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThemNhanVienVoiMaNhanVienTrung()
        {
            bool expected = false;
            bool actual = NhanVienDAO.Instance.ThemNV( "Only C", 123456123, "7/7/1997", "Nam", "cvgbh", "ada");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestXoaNhanVien()
        {
            bool expected = true;
            bool actual = NhanVienDAO.Instance.XoaNV(111);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestXoaNhanVienKhongTonTai()
        {
            bool expected = false;
            bool actual = NhanVienDAO.Instance.XoaNV(48561186);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestXoaNhanVienSaiMaNhanVien()
        {
            bool expected = false;
            bool actual = NhanVienDAO.Instance.XoaNV(48851);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTimNhanVien()
        {
            List<NhanVien> nv = NhanVienDAO.Instance.TimNV(112);
            int expected = 1;
            int actual = nv.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTimNhanVienKhongTonTai()
        {
            List<NhanVien> nv = NhanVienDAO.Instance.TimNV(4852);
            int expected = 0;
            int actual = nv.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLayThongTinMotNhanVien()
        {
            List<NhanVien> nv = NhanVienDAO.Instance.Lay1nhanvien("giahuy");
            int expected = 1;
            int actual = nv.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLayThongTinMotNhanVienKhongTonTai()
        {
            List<NhanVien> nv = NhanVienDAO.Instance.Lay1nhanvien("liuliu");
            int expected = 0;
            int actual = nv.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKiemTraNhanVienTonTaiVoiMaNhanVien()
        {
            bool expected = true;
            bool actual = NhanVienDAO.Instance.KiemTraNhanVienTonTaiVoiMaNhanVien(112);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKiemTraNhanVienTonTaiVoiTenDangNhap()
        {
            bool expected = true;
            bool actual = NhanVienDAO.Instance.KiemTraNhanVienTonTaiVoiTenDangNhap("giahuy");
            Assert.AreEqual(expected, actual);
        }
    }
}
