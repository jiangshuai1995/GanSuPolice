using Beyon.WebService.PGIS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Beyon.Domain.PGIS;
using System.Collections.Generic;

namespace Beyon.Test
{
    /// <summary>
    ///这是 GpsHistoryTest 的测试类，旨在
    ///包含所有 GpsHistoryTest 单元测试
    ///</summary>
    [TestClass()]
    public class GpsHistoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
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

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///获取GPS轨迹信息列表 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllGpsHistoryInfoTest()
        {
            GpsHistory target = new GpsHistory(); 
            DateTime start = new DateTime(2016, 7, 14, 21, 0, 0); 
            DateTime end = new DateTime(2016, 7, 14, 23, 59, 59); 
            List<GpsTrail> expected = null; 
            List<GpsTrail> actual;
            actual = target.GetAllGpsHistoryInfo(start, end);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetGpsCarHistoryInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetGpsCarHistoryInfoTest()
        {
            GpsHistory target = new GpsHistory();
            DateTime start = new DateTime(2016, 7, 17, 21, 0, 0);
            DateTime end = new DateTime(2016, 7, 17, 23, 59, 59);
            List<GpsTrail> expected = null;
            List<GpsTrail> actual;
            actual = target.GetGpsCarHistoryInfo(start, end);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetGpsDeviceHistoryInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetGpsDeviceHistoryInfoTest()
        {
            GpsHistory target = new GpsHistory();
            DateTime start = new DateTime(2016, 7, 17, 21, 0, 0);
            DateTime end = new DateTime(2016, 7, 17, 23, 59, 59);
            List<GpsTrail> expected = null;
            List<GpsTrail> actual;
            actual = target.GetGpsDeviceHistoryInfo(start, end);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

    }
}
