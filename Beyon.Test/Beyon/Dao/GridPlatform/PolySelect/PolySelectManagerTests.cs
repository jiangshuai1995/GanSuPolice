using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.GridSelect;
using Beyon.Dao.GridPlatform.PolySelect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beyon.Dao.GridPlatform.PolySelect.Tests
{
    [TestClass()]
    public class PolySelectManagerTests
    {
        [TestMethod()]
        public void GetCSCountByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            long count = target.GetCSCountByPoly("CS_TYCS_PT", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(count, 0);
        }

        [TestMethod()]
        public void GetCSListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            var result = target.GetCSListByPoly("CS_TYCS_PT", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(result.Count, 0);
        }

        [TestMethod()]
        public void GetCSPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            var result = target.GetCSPageListByPoly("CS_TYCS_PT", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))",1,100);
            Assert.AreNotEqual(result.Count, 0);
        }

        [TestMethod()]
        public void GetFWListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            var result = target.GetFWListByPoly("派出所", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(result.fw, 0);
        }

        [TestMethod()]
        public void GetFWPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            var result = target.GetFWPageListByPoly("派出所", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))", 1, 100);
            Assert.AreNotEqual(result.fw, 0);
        }

        [TestMethod()]
        public void GetFWCountByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            long count = target.GetFWCountByPoly( "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(count, 0);
        }

        [TestMethod()]
        public void GetAJCountByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            var dictionary = target.GetAjCountByPoly( "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(dictionary.Count, 0);
        }

        [TestMethod()]
        public void GetAnJianListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetAnJianListByPoly("jj", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetAnJianPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetAnJianPageListByPoly("jj", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))",1,100);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetJSListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetJSListByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetJSPersonListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetJSPersonListByPoly("1");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetJSPersonDetailByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var jsp = target.GetJSPersonDetailByPoly("2");
            Assert.AreNotEqual(jsp, 0);
        }

        [TestMethod()]
        public void GetJSDetailByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var js = target.GetJSPersonDetailByPoly("3");
            Assert.AreNotEqual(js, 0);
        }

        [TestMethod()]
        public void GetCZRenKouListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetCZRenKouListByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetFQInfoByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var ps = target.GetCZRenKouListByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(ps, 0);
        }

        [TestMethod()]
        public void GetPcsZrqCountByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var dictionary = target.GetPcsZrqCountByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(dictionary.Count, 0);
        }

        [TestMethod()]
        public void GetPcsZrqListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetPcsZrqListByPoly("pcs","POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetPcsZrqPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetPcsZrqPageListByPoly("pcs", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))",1,100);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetPcsDetailByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var pcsd = target.GetPcsDetailByPoly("1");
            Assert.AreNotEqual(pcsd, 0);
        }
        [TestMethod()]
        public void GetZrqDetailByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var zrq = target.GetZrqDetailByPoly("10");
            Assert.AreNotEqual(zrq, 0);
        }

        [TestMethod()]
        public void GetPoliceManCountByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var count =target.GetPoliceManCountByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(count, 0);
        }

        [TestMethod()]
        public void GetPoliceManListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetPoliceManListByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetPoliceManPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetPoliceManPageListByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))", 1, 100);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetPoliceCarListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetPoliceCarListByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetRenKouCountByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var count = target.GetRenKouCountByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(count, 0);
        }

        [TestMethod()]
        public void GetRenKouListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetRenKouListByPoly("czrk", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetRenKouPageListByPolyText()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetRenKouPageListByPoly("czrk", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))", 1, 100);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetSpjkCountByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var dictionary = target.GetSpjkCountByPoly("POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(dictionary.Count, 0);
        }
        [TestMethod()]
        public void GetSpjkListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetSpjkListByPoly("ggcs", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetSpjkPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            var list = target.GetSpjkPageListByPoly("ggcs", "POLYGON((103.8 36,103.8 37,103.9 37,103.9 36, 103.8 36))",1,100);
            Assert.AreNotEqual(list.Count, 0);
        }
    }
}
