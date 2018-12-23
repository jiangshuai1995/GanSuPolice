using System;
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
        
    }
}
