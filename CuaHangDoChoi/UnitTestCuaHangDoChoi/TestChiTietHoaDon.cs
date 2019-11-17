using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DTO;

namespace UnitTestCuaHangDoChoi
{
    /// <summary>
    /// Summary description for TestChiTietHoaDon
    /// </summary>
    [TestClass]
    public class TestChiTietHoaDon
    {
        public TestChiTietHoaDon()
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
        public void TestLayChiTietHoaDon()
        {
            
            List<ChiTietHoaDon> tk = ChiTietHoaDonDAO.Instance.layCTHD(100);
            int expected = 1;
            int actual = tk.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThemChiTietHoaDon()
        {
            bool expected = true;
            bool actual = ChiTietHoaDonDAO.Instance.themChiTietHoaDon(100, 1000, 200000, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThemChiTietHoaDonVoiMaHoaDonNhoHon0()
        {
            bool expected = false;
            bool actual = ChiTietHoaDonDAO.Instance.themChiTietHoaDon(-4, 1006, 200000, 5);
            Assert.AreEqual(expected, actual);
        }

    }
}
