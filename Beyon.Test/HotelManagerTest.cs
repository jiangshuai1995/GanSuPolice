using Beyon.WebService.ZhddPlatform.zzjgInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Beyon.Domain.Zhdd.zjjg;
using System.Collections.Generic;

namespace Beyon.Test
{
    
    
    /// <summary>
    ///这是 HotelManagerTest 的测试类，旨在
    ///包含所有 HotelManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class HotelManagerTest
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
        ///GetAllHotels 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllHotelsTest()
        {
            HotelManager target = new HotelManager();
            List<Hotel> actual = target.GetAllHotels();
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///FindHotelsBySearch 的测试
        ///</summary>
        [TestMethod()]
        public void FindHotelsBySearchTest()
        {
            HotelManager target = new HotelManager(); 
            string exp = "宾馆"; 
            List<Hotel> actual = target.FindHotelsBySearch(exp);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///GetAllHotelsByExtent 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllHotelsByExtentTest()
        {
            HotelManager target = new HotelManager(); // TODO: 初始化为适当的值
            double minX = 90.509461722222213;
            double minY = 31.096876;
            double maxX = 111.68560927777777;
            double maxY = 43.008459;
            List<Hotel> expected = null; // TODO: 初始化为适当的值
            List<Hotel> actual;
            actual = target.GetAllHotelsByExtent(minX, minY, maxX, maxY);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAllHotelsCount 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllHoteCount()
        {
            HotelManager target = new HotelManager(); // TODO: 初始化为适当的值
            List<Hotel> expected = null; // TODO: 初始化为适当的值
            int actual = target.GetAllHotelCount();
            Assert.AreNotEqual(0, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
