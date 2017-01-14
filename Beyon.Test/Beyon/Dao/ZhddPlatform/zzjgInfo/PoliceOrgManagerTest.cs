using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Dao.ZhddPlatform.zzjgInfo
{
    [TestClass()]
    public class PoliceOrgManagerTest
    {
        [TestMethod()]
        public void GetAllPoliceOrgsTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            var list = target.GetAllPoliceOrgs();
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetAllPoliceOrgsByExtentTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            var list = target.GetAllPoliceOrgsByExtent(103.83732, 103.83732, 36.05426, 36.05426);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetPcsPoliceOrgs()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            var list = target.GetPcsPoliceOrgs();
            Assert.AreNotEqual(list.Count, 0);
        }
        [TestMethod()]
        public void GetPcsPoliceOrgsByExtentTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            var list = target.GetPcsPoliceOrgsByExtent(103.80209, 103.80209, 36.09253, 36.09253);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetNPcsPoliceOrgsTest() 
        {
            PoliceOrgManager target = new PoliceOrgManager();
            var list = target.GetNPcsPoliceOrgs();
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]

        public void GetNPcsPoliceOrgsByExtentTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            var list = target.GetNPcsPoliceOrgsByExtent(103.83732, 103.83732, 36.05426, 36.05426);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void FindPoliceOrgsBySearchTest()
        {
            PoliceOrgManager target = new PoliceOrgManager();
            var list = target.FindPoliceOrgsBySearch("甘肃省公安厅");
            Assert.AreNotEqual(list.Count, 0);
        }

    }
}
