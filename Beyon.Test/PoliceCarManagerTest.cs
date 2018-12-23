using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.WebService.Local;
using Beyon.Domain.Local;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beyon.Test
{
    [TestClass()]
    public class PoliceCarManagerTest
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

        [TestMethod()]
        public void Get4GVideoOfPoliceCarTest() 
        {
            PoliceCarManager target = new PoliceCarManager();
            List<KedaVideo> actual = target.Get4GVideoOfPoliceCar("甘A1853警");
            Assert.AreEqual(actual.Count >= 1, true);
        }
    }
}
