using Beyon.Domain.Zhdd.zjjg;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Dao.ZhddPlatform.zzjgInfo
{
    [TestClass()]
    public class CyberBarManagerTest
    {
        [TestMethod()]
        public void GetAllWBsTest()
        {
            CyberBarManager target = new CyberBarManager();
            var list = target.GetAllWBs();
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void FindCyberBarsBySearchTest()
        {
            CyberBarManager target = new CyberBarManager();
            var list = target.FindCyberBarsBySearch("网络星空网吧");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetAllWBsByExtentTest()
        {
            CyberBarManager target = new CyberBarManager();
            var list = target.GetAllWBsByExtent(103.8,103.9,35.8,35.9);
            Assert.AreNotEqual(list.Count, 0);
        }


    }
}
