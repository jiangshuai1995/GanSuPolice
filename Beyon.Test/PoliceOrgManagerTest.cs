using Beyon.WebService.ZhddPlatform.zzjgInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Beyon.Domain.Zhdd.zjjg;
using System.Collections.Generic;
using System.Windows;

namespace Beyon.Test
{
    
    
    /// <summary>
    ///这是 PoliceOrgManagerTest 的测试类，旨在
    ///包含所有 PoliceOrgManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class PoliceOrgManagerTest
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
        ///GetAllPoliceOrgs 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllPoliceOrgsTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            List<PoliceOrg> expected = null;
            List<PoliceOrg> actual = target.GetAllPoliceOrgs();
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///GetPcsPoliceOrgs 的测试
        ///</summary>
        [TestMethod()]
        public void GetPcsPoliceOrgsTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            List<PoliceOrg> actual = target.GetPcsPoliceOrgs();
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///FindPoliceOrgsBySearch 的测试
        ///</summary>
        [TestMethod()]
        public void FindPoliceOrgsBySearchTest()
        {
            PoliceOrgManager target = new PoliceOrgManager(); 
            string exp = "嘉峪关"; 
            List<PoliceOrg> actual = target.FindPoliceOrgsBySearch(exp);
            Assert.AreEqual(actual.Count >= 1, true);
        }




        /// <summary>
        ///GetAllPoliceOrgsByExtent 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllPoliceOrgsByExtentTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();

            //甘肃省
            Point gsPointMin = new Point(90.509461722222213, 31.096875999999998);
            Point gsPointMax = new Point(111.68560927777777, 43.008459);

            //兰州市
            Point lzPointMin = new Point(103.5583, 35.9109);
            Point lzPointMax = new Point(104.0321, 36.1774);

            List<PoliceOrg> actual = target.GetAllPoliceOrgsByExtent(gsPointMin.X, gsPointMin.Y, gsPointMax.X,gsPointMax.Y);
            Assert.AreEqual(actual.Count >= 1, true);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
