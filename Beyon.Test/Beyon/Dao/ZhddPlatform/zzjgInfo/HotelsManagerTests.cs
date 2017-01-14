using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Dao.ZhddPlatform.zzjgInfo;
namespace Beyon.Dao.ZhddPlatform.zzjgInfo.Tests
{
    [TestClass()]
    public class HotelsManagerTests
    {
        [TestMethod()]
        public void GetAllHotelsTest()
        {
            HotelManager target = new HotelManager();
            var list = target.GetAllHotels();
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void FindHotelsBySearchTest()
        {
            HotelManager target = new HotelManager();
            var list = target.FindHotelsBySearch("6201020049");
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetAllHotelsByExtenTest()
        {
            HotelManager target = new HotelManager();
            var list = target.GetAllHotelsByExtent(103.83694, 103.83694, 36.02119, 36.02119);
            Assert.AreNotEqual(list.Count, 0);
        }
    }
}
