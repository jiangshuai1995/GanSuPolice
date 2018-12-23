using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.WebService.ZhddPlatform.zzjgInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beyon.Domain.Zhdd.zjjg;


namespace Beyon.Test
{
    [TestClass()]
    public class BarrierManagerTest
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
        public void GetAllBarriersByExtentTest()
        {
            BarrierManager target = new BarrierManager();
            var list = target.GetAllBarrierByExtent(102.06916479819719,34.411004748036675,105.26451464664198,36.208389037786873);
            Assert.AreNotEqual(list.Count, 0);
        }

        //[TestMethod()]
        //public void GetBarrierByIDTest() 
        //{
        //    BarrierManager target = new BarrierManager();
        //    Barrier barrier = target.GetBarrierByID("ID123456");
        //    Assert.IsNotNull(barrier);
        //}
    }
}
