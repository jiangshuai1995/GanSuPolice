using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Service.ZhddPlatform;
using Beyon.Dao.ZhddPlatform.zzjgInfo;


namespace Beyon.Dao.ZhddPlatform.zzjgInfo
{
    [TestClass()]
    public class TempleManagerTest
    {
        [TestMethod()]
        public void GetAllTemplesByExtentTest()
        {
            TempleManager target = new TempleManager();
            var list = target.GetAllTempleByExtent(103.876288, 103.876288, 35.927792, 35.927792);
            Assert.AreNotEqual(list.Count, 0);
        }
    }
}
