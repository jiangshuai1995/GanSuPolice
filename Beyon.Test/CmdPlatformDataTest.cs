using Beyon.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Beyon.Domain;
using System.Collections.Generic;

namespace Beyon.Test
{
    
    /// <summary>
    ///这是 CmdPlatformDataTest 的测试类，旨在
    ///包含所有 CmdPlatformDataTest 单元测试
    ///</summary>
    [TestClass()]
    public class CmdPlatformDataTest
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

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///TestMethod 的测试
        ///</summary>
        [TestMethod()]
        public void TestMethodTest()
        {
            CmdPlatformData target = new CmdPlatformData(); // TODO: 初始化为适当的值
            //target.TestMethod();
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///GetColumnChartInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetColumnChartInfoTest()
        {
            ////返回同比值
            //var json = "[{\"XZQH\":\"0062\",\"JN\":8266,\"QN\":9571,\"XB\":-0.14,\"WFFZJ\":829,\"ZAAJ\":1876,\"HZSG\":7,\"JTSG\":1028,\"ZAZHSG\":0," +
            //    "\"ZHSG\":0,\"ZS\":2,\"JF\":836,\"JTBL\":114,\"GMQZ\":827,\"ZSXR\":10,\"JWJD\":0,\"TJSJ\":\"2017-01-05 12:33:34\", \"XZQHMC\":\"合&nbsp;计\"}]";
            //var jcjjjArray = Newtonsoft.Json.Linq.JArray.Parse(json);
            //String test =  Newtonsoft.Json.JsonConvert.SerializeObject(jcjjjArray);

            //var json1 = "[{\"GAJG_KEY\":\"6211\",\"JN\":8266,\"QN\":9571,\"XB\":-0.14,\"WFFZJ\":829,\"ZAAJ\":1876,\"HZSG\":7,\"JTSG\":1028,\"ZAZHSG\":0," +
            //    "\"ZHSG\":0,\"ZS\":2,\"JF\":836,\"JTBL\":114,\"GMQZ\":827,\"ZSXR\":10,\"JWJD\":0,\"TJSJ\":\"2017-01-05 12:33:34\", \"XZQHMC\":\"合&nbsp;计\"}]";
            //var jcjjjArray1 = Newtonsoft.Json.Linq.JArray.Parse(json);
            //String test1 = Newtonsoft.Json.JsonConvert.SerializeObject(jcjjjArray1);

            CmdPlatformData target = new CmdPlatformData(); // TODO: 初始化为适当的值
            //string level = "市"; // TODO: 初始化为适当的值
            //string name = "案件管理_接处警_违法犯罪";  //"案件管理_接处警_总体情况";      //"案件管理_接处警_违法犯罪" // TODO: 初始化为适当的值     //总体情况

            string level = "县";
            string name = "案件管理_接处警_总体情况"; 

            double minLongitude = 0F; // TODO: 初始化为适当的值
            double minLatitude = 0F; // TODO: 初始化为适当的值
            double maxLongitude = 100F; // TODO: 初始化为适当的值
            double maxLatitude = 100F; // TODO: 初始化为适当的值
            List<StatisticInfo> expected = null; // TODO: 初始化为适当的值
            List<StatisticInfo> actual;
            actual = target.GetColumnChartInfo(level, name, minLongitude, minLatitude, maxLongitude, maxLatitude);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
