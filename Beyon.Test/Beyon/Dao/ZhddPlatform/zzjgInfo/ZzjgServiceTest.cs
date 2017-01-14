using Beyon.Service.ZhddPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Dao.ZhddPlatform.zzjgInfo
{
    [TestClass()]
    public class ZzjgServiceTest
    {
        [TestMethod()]
        public void GetAllHotels()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetAllHotels();
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void FindHotelsBySearchTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.FindHotelsBySearch("6201020049");
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetAllHotelsByExtenTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetAllHotelsByExtent(103.83694, 103.83694, 36.02119, 36.02119);
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetAllCyberBarsTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetAllCyberBars();
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void FindCyberBarsBySearchTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.FindCyberBarsBySearch("网络星空网吧");
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetAllCyberBarsByExtentTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetAllCyberBarsByExtent(103.8, 103.9, 35.8, 35.9);
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetAllPoliceOrgs()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetAllPoliceOrgs();
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetAllPoliceOrgsByExtentTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetAllPoliceOrgsByExtent(103.83732, 103.83732, 36.05426, 36.05426);
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetPcsPoliceOrgsTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetNPcsPoliceOrgs();
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetPcsPoliceOrgsByExtent()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetPcsPoliceOrgsByExtent(103.80209, 103.80209, 36.09253, 36.09253);
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetNPcsPoliceOrgsTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetNPcsPoliceOrgs();
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetNPcsPoliceOrgsByExtentTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetNPcsPoliceOrgsByExtent(103.83732, 103.83732, 36.05426, 36.05426);
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void FindPoliceOrgsBySearchTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.FindPoliceOrgsBySearch("甘肃省公安厅");
            Assert.AreNotEqual(list, 0);
        }

        [TestMethod()]
        public void GetAllTemplesByExtentTest()
        {
            ZzjgServiceImpl target = new ZzjgServiceImpl();
            var list = target.GetAllTemplesByExtent(103.876288, 103.876288, 35.927792, 35.927792);
            Assert.AreNotEqual(list, 0);
        }
    }
}
