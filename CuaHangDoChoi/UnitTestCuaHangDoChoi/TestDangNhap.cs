using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using DAO;

namespace UnitTestCuaHangDoChoi
{
    /// <summary>
    /// Summary description for TestDangNhap
    /// </summary>
    [TestClass]
    public class TestDangNhap
    {
        public TestDangNhap()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        public void TestDangNhapVoiTenDangNhapKhongTonTai()
        {
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("adadsads");
            TaiKhoan expected = null;
            TaiKhoan actual = tk;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDangNhapVoiTenDangNhapRong()
        {
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("");
            TaiKhoan expected = null;
            TaiKhoan actual = tk;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDangNhapVoiTenDangNhapCoKhoangCachDau()
        {
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan(" admin");
            TaiKhoan expected = null;
            TaiKhoan actual = tk;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDangNhapVoiTenDangNhapCoKhoangCachCuoi()
        {
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("giahuy      ");
            TaiKhoan expected = null;
            TaiKhoan actual = tk;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDangNhapVoiTenDangNhapCoKhoangCachBatKi()
        {
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("adm in");
            TaiKhoan expected = null;
            TaiKhoan actual = tk;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDangNhapVoiTenDangNhapInHoaKiTuDau()
        {
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("Giahuy");
            TaiKhoan expected = null;
            TaiKhoan actual = tk;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDangNhapVoiTenDangNhapInHoa()
        {
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("GIAHUY");
            TaiKhoan expected = null;
            TaiKhoan actual = tk;
            Assert.AreEqual(expected, actual);
        }


    }
}
