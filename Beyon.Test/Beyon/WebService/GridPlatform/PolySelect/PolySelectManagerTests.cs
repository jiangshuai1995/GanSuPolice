using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.GridSelect;
using Beyon.WebService.GridPlatform.PolySelect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Beyon.WebService.GridPlatform.PolySelect.Tests
{
    [TestClass()]
    public class PolySelectManagerTests
    {
        [TestMethod()]
        public void GetPoliceCarListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            string id = string.Empty; // TODO: 初始化为适当的值
            List<PoliceCar> actual;
            //actual = target.GetPoliceCarListByPoly(new List<System.Windows.Point>());
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
