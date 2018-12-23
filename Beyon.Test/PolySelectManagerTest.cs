﻿using Beyon.WebService.GridPlatform.PolySelect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Beyon.Domain.PolySelect;
using System.Collections.Generic;
using Beyon.Domain.GridSelect;
using Beyon.Domain.GridSearch;

namespace Beyon.Test
{
    
    
    /// <summary>
    ///这是 PolySelectManagerTest 的测试类，旨在
    ///包含所有 PolySelectManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class PolySelectManagerTest
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
        ///GetJSListByPoly 的测试
        ///</summary>
        [TestMethod()]
        public void GetJSListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            string jsType = string.Empty; // TODO: 初始化为适当的值
            string polygon = string.Empty; // TODO: 初始化为适当的值
            List<PolyJS> expected = null; // TODO: 初始化为适当的值
            //List<PolyJS> actual;
            //actual = target.GetJSListByPoly("戒毒所", polygon);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetJSDetailByPoly 的测试
        ///</summary>
        [TestMethod()]
        public void GetJSDetailByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); // TODO: 初始化为适当的值
            string id = string.Empty; // TODO: 初始化为适当的值
            JSDetail expected = null; // TODO: 初始化为适当的值
            JSDetail actual;
            actual = target.GetJSDetailByPoly(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///圈选人口分页 的测试
        ///</summary>
        [TestMethod()]
        public void GetRenKouPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); 
            string rkType = "常住人口";
            string mapLevel = "责任区";
            string polygon = "103.745243272164,36.1462015483218,103.688029071412,36.1310363384838,103.668038567535,36.0007533994213,103.678378483333,35.9973067608218,103.689407726852,35.9945494499421,103.70595159213,35.9924814667824,103.720427474248,35.9911028113426,103.736282011806,35.9897241559028,103.750068566204,35.9897241559028,103.765233776042,35.9897241559028,103.77902033044,35.9890348281829,103.793496212558,35.9904134836227,103.809350750116,35.9945494499421,103.824515959954,35.9993747439815,103.832787892593,36.0021320548611,103.840370497512,36.0042000380208,103.84864243015,36.0083360043403,103.856914362789,36.0110933152199,103.864496967708,36.0152292815393,103.873458228067,36.0193652478588,103.880351505266,36.0228118864583,103.886555454745,36.0269478527778,103.892070076505,36.0310838190972,103.895516715104,36.0345304576968,103.901031336863,36.0393557517361,103.904477975463,36.0428023903356,103.907235286343,36.0455597012153,103.910681924942,36.0483170120949,103.914817891262,36.0517636506944,103.918264529861,36.055210289294,103.922400496181,36.0586569278935,103.92584713478,36.0621035664931,103.92791511794,36.0655502050926,103.92929377338,36.0689968436921,103.9299831011,36.0724434822917,103.9299831011,36.0745114654514,103.930672428819,36.0779581040509,103.930672428819,36.0807154149306,103.930672428819,36.0834727258102,103.930672428819,36.0876086921296,103.9299831011,36.092433986169,103.92860444566,36.0972592802083,103.92515780706,36.1034632296875,103.9230898239,36.1075991960069,103.919643185301,36.1124244900463,103.916885874421,36.1165604563657,103.911371252662,36.1227644058449,103.907924614063,36.1262110444444,103.903099320023,36.1303470107639,103.896895370544,36.1337936493634,103.890691421065,36.1379296156829,103.884487471586,36.1406869265625,103.878972849826,36.1434442374421,103.872768900347,36.1462015483218,103.866564950868,36.1489588592014,103.859671673669,36.1510268423611,103.85484637963,36.1524054978009,103.84933175787,36.1551628086806,103.845885119271,36.1558521364005,103.841059825231,36.1586094472801,103.838302514352,36.159298775,103.834166548032,36.1606774304398,103.832098564873,36.1620560858796,103.830030581713,36.1627454135995,103.826583943113,36.1641240690393,103.824515959954,36.1641240690393,103.820379993634,36.1655027244792,103.818312010475,36.1661920521991,103.814865371875,36.166881379919,103.812108060995,36.1675707076389,103.807972094676,36.1675707076389,103.804525456076,36.1682600353588,103.799700162037,36.1689493630787,103.796253523438,36.1689493630787,103.792806884838,36.1689493630787,103.790738901678,36.1689493630787,103.789360246238,36.1689493630787,103.787981590799,36.1689493630787,103.786602935359,36.1689493630787,103.784534952199,36.1682600353588,103.7810883136,36.1675707076389,103.777641675,36.1661920521991,103.771437725521,36.1648133967593,103.767301759201,36.1634347413194,103.762476465162,36.1620560858796,103.758340498843,36.1606774304398,103.756272515683,36.1606774304398,103.754204532523,36.1599881027199,103.752136549363,36.159298775,103.748000583044,36.1579201195602,103.745243272164,36.1565414641204,103.742485961285,36.1551628086806,103.739039322685,36.1537841532407,103.734903356366,36.151716170081,103.731456717766,36.1496481869213,103.728010079167,36.1462015483218,103.725252768287,36.1434442374421,103.723184785127,36.1406869265625,103.721116801968,36.1393082711227,103.719738146528,36.1358616325231,103.719048818808,36.1344829770833,103.718359491088,36.1331043216435";
            int pageNum = 1;
            int pageSize = 50;
            List<RenKou> actual;
            actual = target.GetRenKouPageListByPoly(rkType, mapLevel, polygon, pageNum, pageSize);
            Assert.AreEqual(actual.Count >= 1, true);
        }



        /// <summary>
        ///圈选房屋分页的测试
        ///</summary>
        [TestMethod()]
        public void GetFWPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            string polygon = "103.843041642426,36.0575367703487,103.825636117499,36.0560719489439,103.825205287674,36.0556411191189,103.824602125919,36.054779459469,103.824257462059,36.0540039657841,103.823740466269,36.0530561401693,103.823568134339,36.0521944805194,103.823395802409,36.0515051527995,103.823395802409,36.0509019910446,103.823395802409,36.0503849952546,103.823740466269,36.0496095015697,103.824343628024,36.0487478419199,103.825119121709,36.04771385034,103.826239279254,36.0467660247251,103.828134930483,36.0455597012153,103.830633743468,36.0443533777054,103.833391054348,36.0429747222656,103.836148365227,36.0417683987558,103.838991842072,36.0409929050709,103.842007650846,36.040562075246,103.844592629796,36.040131245421,103.847091442781,36.039872747526,103.849762587695,36.039872747526,103.85260606454,36.0397004155961,103.85501871156,36.0397004155961,103.857431358579,36.0397004155961,103.859413175774,36.0397004155961,103.860877997179,36.0397004155961,103.862515150514,36.039958913491,103.863721474023,36.040389743316,103.864841631568,36.0406482412109,103.865617125253,36.0409929050709,103.866392618938,36.0411652370009,103.866995780693,36.0413375689308,103.867771274378,36.0415099008608,103.868460602098,36.0415960668258,103.869149929818,36.0416822327908,103.869925423503,36.0417683987558,103.870614751223,36.0420268966508,103.871390244907,36.0421992285807,103.872251904557,36.0425438924407,103.872941232277,36.0427162243707,103.873802891927,36.0430608882306,103.874578385612,36.0433193861256,103.875612377192,36.0437502159505,103.876387870877,36.0440948798105,103.877163364562,36.0444395436704,103.877852692282,36.0447842075304,103.878283522107,36.0450427054254,103.878455854037,36.0451288713903,103.878714351931,36.0453873692853,103.878714351931,36.0454735352503,103.878886683861,36.0457320331453,103.879059015791,36.0461628629702,103.879145181756,36.0464213608652,103.879145181756,36.0466798587601,103.879145181756,36.0469383566551,103.879145181756,36.0471968545501,103.879145181756,36.04754151841,103.878886683861,36.0482308461299,103.878369688072,36.0488340078848,103.877938858247,36.0495233356047,103.877163364562,36.0502126633247,103.876301704912,36.0506434931496,103.875095381402,36.0514189868345,103.873802891927,36.0519359826244,103.872338070522,36.0525391443793,103.870356253328,36.0532284720992,103.868460602098,36.0536593019242,103.866306452973,36.0540901317491,103.864066137883,36.0545209615741,103.861739656829,36.054779459469,103.858982345949,36.055037957364,103.857000528754,36.055210289294,103.85519104349,36.0555549531539,103.85398471998,36.0556411191189,103.8529507284,36.0558134510489,103.85208906875,36.0558996170139,103.8512274091,36.0559857829789,103.85053808138,36.0561581149089,103.84967642173,36.0561581149089,103.84898709401,36.0561581149089,103.848297766291,36.0562442808738,103.847608438571,36.0563304468388,103.846832944886,36.0564166128038,103.846229783131,36.0565027787688,103.845368123481,36.0566751106988,103.844937293656,36.0566751106988,103.844161799971,36.0567612766638,103.843386306286,36.0569336085938,103.842610812601,36.0570197745587,103.841921484881,36.0571059405237,103.841145991197,36.0572782724537,103.840715161372,36.0574506043837,103.840284331547,36.0576229363137,103.840025833652,36.0577952682436,103.839681169792,36.0578814342086,103.839422671897,36.0579676001736,103.839250339967,36.0581399321036,103.838819510142,36.0583122640336,103.838561012247,36.0583122640336,103.838388680317,36.0583122640336,103.838216348387,36.0584845959635,103.838044016457,36.0584845959635,103.837957850492,36.0584845959635,103.837871684527,36.0585707619285,103.837785518562,36.0585707619285,103.837699352597,36.0586569278935,103.837527020667,36.0586569278935,103.837354688737,36.0586569278935,103.837182356807,36.0587430938585,103.837096190842,36.0587430938585";
            string mapLevel = "派出所";
            int pageNum = 1;
            int pageSize = 100;
            PolyBuilding actual;
            actual = target.GetFWPageListByPoly(mapLevel, polygon, pageNum, pageSize);
            Assert.AreEqual(actual.fwList.Count >= 1, true);
        }

        /// <summary>
        ///圈选场所分页的测试
        ///</summary>
        [TestMethod()]
        public void GetCSPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            string csType = "公共场所";
            string polygon = "103.843041642426,36.0575367703487,103.825636117499,36.0560719489439,103.825205287674,36.0556411191189,103.824602125919,36.054779459469,103.824257462059,36.0540039657841,103.823740466269,36.0530561401693,103.823568134339,36.0521944805194,103.823395802409,36.0515051527995,103.823395802409,36.0509019910446,103.823395802409,36.0503849952546,103.823740466269,36.0496095015697,103.824343628024,36.0487478419199,103.825119121709,36.04771385034,103.826239279254,36.0467660247251,103.828134930483,36.0455597012153,103.830633743468,36.0443533777054,103.833391054348,36.0429747222656,103.836148365227,36.0417683987558,103.838991842072,36.0409929050709,103.842007650846,36.040562075246,103.844592629796,36.040131245421,103.847091442781,36.039872747526,103.849762587695,36.039872747526,103.85260606454,36.0397004155961,103.85501871156,36.0397004155961,103.857431358579,36.0397004155961,103.859413175774,36.0397004155961,103.860877997179,36.0397004155961,103.862515150514,36.039958913491,103.863721474023,36.040389743316,103.864841631568,36.0406482412109,103.865617125253,36.0409929050709,103.866392618938,36.0411652370009,103.866995780693,36.0413375689308,103.867771274378,36.0415099008608,103.868460602098,36.0415960668258,103.869149929818,36.0416822327908,103.869925423503,36.0417683987558,103.870614751223,36.0420268966508,103.871390244907,36.0421992285807,103.872251904557,36.0425438924407,103.872941232277,36.0427162243707,103.873802891927,36.0430608882306,103.874578385612,36.0433193861256,103.875612377192,36.0437502159505,103.876387870877,36.0440948798105,103.877163364562,36.0444395436704,103.877852692282,36.0447842075304,103.878283522107,36.0450427054254,103.878455854037,36.0451288713903,103.878714351931,36.0453873692853,103.878714351931,36.0454735352503,103.878886683861,36.0457320331453,103.879059015791,36.0461628629702,103.879145181756,36.0464213608652,103.879145181756,36.0466798587601,103.879145181756,36.0469383566551,103.879145181756,36.0471968545501,103.879145181756,36.04754151841,103.878886683861,36.0482308461299,103.878369688072,36.0488340078848,103.877938858247,36.0495233356047,103.877163364562,36.0502126633247,103.876301704912,36.0506434931496,103.875095381402,36.0514189868345,103.873802891927,36.0519359826244,103.872338070522,36.0525391443793,103.870356253328,36.0532284720992,103.868460602098,36.0536593019242,103.866306452973,36.0540901317491,103.864066137883,36.0545209615741,103.861739656829,36.054779459469,103.858982345949,36.055037957364,103.857000528754,36.055210289294,103.85519104349,36.0555549531539,103.85398471998,36.0556411191189,103.8529507284,36.0558134510489,103.85208906875,36.0558996170139,103.8512274091,36.0559857829789,103.85053808138,36.0561581149089,103.84967642173,36.0561581149089,103.84898709401,36.0561581149089,103.848297766291,36.0562442808738,103.847608438571,36.0563304468388,103.846832944886,36.0564166128038,103.846229783131,36.0565027787688,103.845368123481,36.0566751106988,103.844937293656,36.0566751106988,103.844161799971,36.0567612766638,103.843386306286,36.0569336085938,103.842610812601,36.0570197745587,103.841921484881,36.0571059405237,103.841145991197,36.0572782724537,103.840715161372,36.0574506043837,103.840284331547,36.0576229363137,103.840025833652,36.0577952682436,103.839681169792,36.0578814342086,103.839422671897,36.0579676001736,103.839250339967,36.0581399321036,103.838819510142,36.0583122640336,103.838561012247,36.0583122640336,103.838388680317,36.0583122640336,103.838216348387,36.0584845959635,103.838044016457,36.0584845959635,103.837957850492,36.0584845959635,103.837871684527,36.0585707619285,103.837785518562,36.0585707619285,103.837699352597,36.0586569278935,103.837527020667,36.0586569278935,103.837354688737,36.0586569278935,103.837182356807,36.0587430938585,103.837096190842,36.0587430938585"; 
            int pageNum = 10; 
            int pageSize = 10; 
            List<PolyCS> actual;
            actual = target.GetCSPageListByPoly(csType, polygon, pageNum, pageSize);
            Assert.AreEqual(actual.Count >= 1, true);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAnJianPageListByPoly 的测试
        ///</summary>
        [TestMethod()]
        public void GetAnJianPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); 
            string ajType = "接处警"; 
            //string mapLevel = "派出所";
            string mapLevel = "责任区";
            string polygon = "103.843041642426,36.0575367703487,103.825636117499,36.0560719489439,103.825205287674,36.0556411191189,103.824602125919,36.054779459469,103.824257462059,36.0540039657841,103.823740466269,36.0530561401693,103.823568134339,36.0521944805194,103.823395802409,36.0515051527995,103.823395802409,36.0509019910446,103.823395802409,36.0503849952546,103.823740466269,36.0496095015697,103.824343628024,36.0487478419199,103.825119121709,36.04771385034,103.826239279254,36.0467660247251,103.828134930483,36.0455597012153,103.830633743468,36.0443533777054,103.833391054348,36.0429747222656,103.836148365227,36.0417683987558,103.838991842072,36.0409929050709,103.842007650846,36.040562075246,103.844592629796,36.040131245421,103.847091442781,36.039872747526,103.849762587695,36.039872747526,103.85260606454,36.0397004155961,103.85501871156,36.0397004155961,103.857431358579,36.0397004155961,103.859413175774,36.0397004155961,103.860877997179,36.0397004155961,103.862515150514,36.039958913491,103.863721474023,36.040389743316,103.864841631568,36.0406482412109,103.865617125253,36.0409929050709,103.866392618938,36.0411652370009,103.866995780693,36.0413375689308,103.867771274378,36.0415099008608,103.868460602098,36.0415960668258,103.869149929818,36.0416822327908,103.869925423503,36.0417683987558,103.870614751223,36.0420268966508,103.871390244907,36.0421992285807,103.872251904557,36.0425438924407,103.872941232277,36.0427162243707,103.873802891927,36.0430608882306,103.874578385612,36.0433193861256,103.875612377192,36.0437502159505,103.876387870877,36.0440948798105,103.877163364562,36.0444395436704,103.877852692282,36.0447842075304,103.878283522107,36.0450427054254,103.878455854037,36.0451288713903,103.878714351931,36.0453873692853,103.878714351931,36.0454735352503,103.878886683861,36.0457320331453,103.879059015791,36.0461628629702,103.879145181756,36.0464213608652,103.879145181756,36.0466798587601,103.879145181756,36.0469383566551,103.879145181756,36.0471968545501,103.879145181756,36.04754151841,103.878886683861,36.0482308461299,103.878369688072,36.0488340078848,103.877938858247,36.0495233356047,103.877163364562,36.0502126633247,103.876301704912,36.0506434931496,103.875095381402,36.0514189868345,103.873802891927,36.0519359826244,103.872338070522,36.0525391443793,103.870356253328,36.0532284720992,103.868460602098,36.0536593019242,103.866306452973,36.0540901317491,103.864066137883,36.0545209615741,103.861739656829,36.054779459469,103.858982345949,36.055037957364,103.857000528754,36.055210289294,103.85519104349,36.0555549531539,103.85398471998,36.0556411191189,103.8529507284,36.0558134510489,103.85208906875,36.0558996170139,103.8512274091,36.0559857829789,103.85053808138,36.0561581149089,103.84967642173,36.0561581149089,103.84898709401,36.0561581149089,103.848297766291,36.0562442808738,103.847608438571,36.0563304468388,103.846832944886,36.0564166128038,103.846229783131,36.0565027787688,103.845368123481,36.0566751106988,103.844937293656,36.0566751106988,103.844161799971,36.0567612766638,103.843386306286,36.0569336085938,103.842610812601,36.0570197745587,103.841921484881,36.0571059405237,103.841145991197,36.0572782724537,103.840715161372,36.0574506043837,103.840284331547,36.0576229363137,103.840025833652,36.0577952682436,103.839681169792,36.0578814342086,103.839422671897,36.0579676001736,103.839250339967,36.0581399321036,103.838819510142,36.0583122640336,103.838561012247,36.0583122640336,103.838388680317,36.0583122640336,103.838216348387,36.0584845959635,103.838044016457,36.0584845959635,103.837957850492,36.0584845959635,103.837871684527,36.0585707619285,103.837785518562,36.0585707619285,103.837699352597,36.0586569278935,103.837527020667,36.0586569278935,103.837354688737,36.0586569278935,103.837182356807,36.0587430938585,103.837096190842,36.0587430938585"; 
            int pageNum = 10; 
            int pageSize = 100; 
            List<AnJian> actual;
            actual = target.GetAnJianPageListByPoly(ajType, mapLevel, polygon, pageNum, pageSize);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///圈选视频监控分页列表的测试
        ///</summary>
        [TestMethod()]
        public void GetSpjkPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            string videoType = "公共场所";
            string polygon = "103.843041642426,36.0575367703487,103.825636117499,36.0560719489439,103.825205287674,36.0556411191189,103.824602125919,36.054779459469,103.824257462059,36.0540039657841,103.823740466269,36.0530561401693,103.823568134339,36.0521944805194,103.823395802409,36.0515051527995,103.823395802409,36.0509019910446,103.823395802409,36.0503849952546,103.823740466269,36.0496095015697,103.824343628024,36.0487478419199,103.825119121709,36.04771385034,103.826239279254,36.0467660247251,103.828134930483,36.0455597012153,103.830633743468,36.0443533777054,103.833391054348,36.0429747222656,103.836148365227,36.0417683987558,103.838991842072,36.0409929050709,103.842007650846,36.040562075246,103.844592629796,36.040131245421,103.847091442781,36.039872747526,103.849762587695,36.039872747526,103.85260606454,36.0397004155961,103.85501871156,36.0397004155961,103.857431358579,36.0397004155961,103.859413175774,36.0397004155961,103.860877997179,36.0397004155961,103.862515150514,36.039958913491,103.863721474023,36.040389743316,103.864841631568,36.0406482412109,103.865617125253,36.0409929050709,103.866392618938,36.0411652370009,103.866995780693,36.0413375689308,103.867771274378,36.0415099008608,103.868460602098,36.0415960668258,103.869149929818,36.0416822327908,103.869925423503,36.0417683987558,103.870614751223,36.0420268966508,103.871390244907,36.0421992285807,103.872251904557,36.0425438924407,103.872941232277,36.0427162243707,103.873802891927,36.0430608882306,103.874578385612,36.0433193861256,103.875612377192,36.0437502159505,103.876387870877,36.0440948798105,103.877163364562,36.0444395436704,103.877852692282,36.0447842075304,103.878283522107,36.0450427054254,103.878455854037,36.0451288713903,103.878714351931,36.0453873692853,103.878714351931,36.0454735352503,103.878886683861,36.0457320331453,103.879059015791,36.0461628629702,103.879145181756,36.0464213608652,103.879145181756,36.0466798587601,103.879145181756,36.0469383566551,103.879145181756,36.0471968545501,103.879145181756,36.04754151841,103.878886683861,36.0482308461299,103.878369688072,36.0488340078848,103.877938858247,36.0495233356047,103.877163364562,36.0502126633247,103.876301704912,36.0506434931496,103.875095381402,36.0514189868345,103.873802891927,36.0519359826244,103.872338070522,36.0525391443793,103.870356253328,36.0532284720992,103.868460602098,36.0536593019242,103.866306452973,36.0540901317491,103.864066137883,36.0545209615741,103.861739656829,36.054779459469,103.858982345949,36.055037957364,103.857000528754,36.055210289294,103.85519104349,36.0555549531539,103.85398471998,36.0556411191189,103.8529507284,36.0558134510489,103.85208906875,36.0558996170139,103.8512274091,36.0559857829789,103.85053808138,36.0561581149089,103.84967642173,36.0561581149089,103.84898709401,36.0561581149089,103.848297766291,36.0562442808738,103.847608438571,36.0563304468388,103.846832944886,36.0564166128038,103.846229783131,36.0565027787688,103.845368123481,36.0566751106988,103.844937293656,36.0566751106988,103.844161799971,36.0567612766638,103.843386306286,36.0569336085938,103.842610812601,36.0570197745587,103.841921484881,36.0571059405237,103.841145991197,36.0572782724537,103.840715161372,36.0574506043837,103.840284331547,36.0576229363137,103.840025833652,36.0577952682436,103.839681169792,36.0578814342086,103.839422671897,36.0579676001736,103.839250339967,36.0581399321036,103.838819510142,36.0583122640336,103.838561012247,36.0583122640336,103.838388680317,36.0583122640336,103.838216348387,36.0584845959635,103.838044016457,36.0584845959635,103.837957850492,36.0584845959635,103.837871684527,36.0585707619285,103.837785518562,36.0585707619285,103.837699352597,36.0586569278935,103.837527020667,36.0586569278935,103.837354688737,36.0586569278935,103.837182356807,36.0587430938585,103.837096190842,36.0587430938585"; 
            int pageNum = 10; 
            int pageSize = 100; 
            List<Beyon.Domain.PolySelect.Video> actual;
            actual = target.GetSpjkPageListByPoly(videoType, polygon, pageNum, pageSize);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///圈选警员分页列表 的测试
        ///</summary>
        [TestMethod()]
        public void GetPoliceManPageListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager();
            string polygon = "103.843041642426,36.0575367703487,103.825636117499,36.0560719489439,103.825205287674,36.0556411191189,103.824602125919,36.054779459469,103.824257462059,36.0540039657841,103.823740466269,36.0530561401693,103.823568134339,36.0521944805194,103.823395802409,36.0515051527995,103.823395802409,36.0509019910446,103.823395802409,36.0503849952546,103.823740466269,36.0496095015697,103.824343628024,36.0487478419199,103.825119121709,36.04771385034,103.826239279254,36.0467660247251,103.828134930483,36.0455597012153,103.830633743468,36.0443533777054,103.833391054348,36.0429747222656,103.836148365227,36.0417683987558,103.838991842072,36.0409929050709,103.842007650846,36.040562075246,103.844592629796,36.040131245421,103.847091442781,36.039872747526,103.849762587695,36.039872747526,103.85260606454,36.0397004155961,103.85501871156,36.0397004155961,103.857431358579,36.0397004155961,103.859413175774,36.0397004155961,103.860877997179,36.0397004155961,103.862515150514,36.039958913491,103.863721474023,36.040389743316,103.864841631568,36.0406482412109,103.865617125253,36.0409929050709,103.866392618938,36.0411652370009,103.866995780693,36.0413375689308,103.867771274378,36.0415099008608,103.868460602098,36.0415960668258,103.869149929818,36.0416822327908,103.869925423503,36.0417683987558,103.870614751223,36.0420268966508,103.871390244907,36.0421992285807,103.872251904557,36.0425438924407,103.872941232277,36.0427162243707,103.873802891927,36.0430608882306,103.874578385612,36.0433193861256,103.875612377192,36.0437502159505,103.876387870877,36.0440948798105,103.877163364562,36.0444395436704,103.877852692282,36.0447842075304,103.878283522107,36.0450427054254,103.878455854037,36.0451288713903,103.878714351931,36.0453873692853,103.878714351931,36.0454735352503,103.878886683861,36.0457320331453,103.879059015791,36.0461628629702,103.879145181756,36.0464213608652,103.879145181756,36.0466798587601,103.879145181756,36.0469383566551,103.879145181756,36.0471968545501,103.879145181756,36.04754151841,103.878886683861,36.0482308461299,103.878369688072,36.0488340078848,103.877938858247,36.0495233356047,103.877163364562,36.0502126633247,103.876301704912,36.0506434931496,103.875095381402,36.0514189868345,103.873802891927,36.0519359826244,103.872338070522,36.0525391443793,103.870356253328,36.0532284720992,103.868460602098,36.0536593019242,103.866306452973,36.0540901317491,103.864066137883,36.0545209615741,103.861739656829,36.054779459469,103.858982345949,36.055037957364,103.857000528754,36.055210289294,103.85519104349,36.0555549531539,103.85398471998,36.0556411191189,103.8529507284,36.0558134510489,103.85208906875,36.0558996170139,103.8512274091,36.0559857829789,103.85053808138,36.0561581149089,103.84967642173,36.0561581149089,103.84898709401,36.0561581149089,103.848297766291,36.0562442808738,103.847608438571,36.0563304468388,103.846832944886,36.0564166128038,103.846229783131,36.0565027787688,103.845368123481,36.0566751106988,103.844937293656,36.0566751106988,103.844161799971,36.0567612766638,103.843386306286,36.0569336085938,103.842610812601,36.0570197745587,103.841921484881,36.0571059405237,103.841145991197,36.0572782724537,103.840715161372,36.0574506043837,103.840284331547,36.0576229363137,103.840025833652,36.0577952682436,103.839681169792,36.0578814342086,103.839422671897,36.0579676001736,103.839250339967,36.0581399321036,103.838819510142,36.0583122640336,103.838561012247,36.0583122640336,103.838388680317,36.0583122640336,103.838216348387,36.0584845959635,103.838044016457,36.0584845959635,103.837957850492,36.0584845959635,103.837871684527,36.0585707619285,103.837785518562,36.0585707619285,103.837699352597,36.0586569278935,103.837527020667,36.0586569278935,103.837354688737,36.0586569278935,103.837182356807,36.0587430938585,103.837096190842,36.0587430938585"; 
            int pageNum = 10; 
            int pageSize = 10; 
            List<PoliceMan> actual;
            actual = target.GetPoliceManPageListByPoly(polygon, pageNum, pageSize);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///圈选 派出所责任区分页列表 的测试
        ///</summary>
        [TestMethod()]
        public void GetPcsZrqListByPolyTest()
        {
            PolySelectManager target = new PolySelectManager(); 
            string gridType = "派出所";
            string polygon = "103.843041642426,36.0575367703487,103.825636117499,36.0560719489439,103.825205287674,36.0556411191189,103.824602125919,36.054779459469,103.824257462059,36.0540039657841,103.823740466269,36.0530561401693,103.823568134339,36.0521944805194,103.823395802409,36.0515051527995,103.823395802409,36.0509019910446,103.823395802409,36.0503849952546,103.823740466269,36.0496095015697,103.824343628024,36.0487478419199,103.825119121709,36.04771385034,103.826239279254,36.0467660247251,103.828134930483,36.0455597012153,103.830633743468,36.0443533777054,103.833391054348,36.0429747222656,103.836148365227,36.0417683987558,103.838991842072,36.0409929050709,103.842007650846,36.040562075246,103.844592629796,36.040131245421,103.847091442781,36.039872747526,103.849762587695,36.039872747526,103.85260606454,36.0397004155961,103.85501871156,36.0397004155961,103.857431358579,36.0397004155961,103.859413175774,36.0397004155961,103.860877997179,36.0397004155961,103.862515150514,36.039958913491,103.863721474023,36.040389743316,103.864841631568,36.0406482412109,103.865617125253,36.0409929050709,103.866392618938,36.0411652370009,103.866995780693,36.0413375689308,103.867771274378,36.0415099008608,103.868460602098,36.0415960668258,103.869149929818,36.0416822327908,103.869925423503,36.0417683987558,103.870614751223,36.0420268966508,103.871390244907,36.0421992285807,103.872251904557,36.0425438924407,103.872941232277,36.0427162243707,103.873802891927,36.0430608882306,103.874578385612,36.0433193861256,103.875612377192,36.0437502159505,103.876387870877,36.0440948798105,103.877163364562,36.0444395436704,103.877852692282,36.0447842075304,103.878283522107,36.0450427054254,103.878455854037,36.0451288713903,103.878714351931,36.0453873692853,103.878714351931,36.0454735352503,103.878886683861,36.0457320331453,103.879059015791,36.0461628629702,103.879145181756,36.0464213608652,103.879145181756,36.0466798587601,103.879145181756,36.0469383566551,103.879145181756,36.0471968545501,103.879145181756,36.04754151841,103.878886683861,36.0482308461299,103.878369688072,36.0488340078848,103.877938858247,36.0495233356047,103.877163364562,36.0502126633247,103.876301704912,36.0506434931496,103.875095381402,36.0514189868345,103.873802891927,36.0519359826244,103.872338070522,36.0525391443793,103.870356253328,36.0532284720992,103.868460602098,36.0536593019242,103.866306452973,36.0540901317491,103.864066137883,36.0545209615741,103.861739656829,36.054779459469,103.858982345949,36.055037957364,103.857000528754,36.055210289294,103.85519104349,36.0555549531539,103.85398471998,36.0556411191189,103.8529507284,36.0558134510489,103.85208906875,36.0558996170139,103.8512274091,36.0559857829789,103.85053808138,36.0561581149089,103.84967642173,36.0561581149089,103.84898709401,36.0561581149089,103.848297766291,36.0562442808738,103.847608438571,36.0563304468388,103.846832944886,36.0564166128038,103.846229783131,36.0565027787688,103.845368123481,36.0566751106988,103.844937293656,36.0566751106988,103.844161799971,36.0567612766638,103.843386306286,36.0569336085938,103.842610812601,36.0570197745587,103.841921484881,36.0571059405237,103.841145991197,36.0572782724537,103.840715161372,36.0574506043837,103.840284331547,36.0576229363137,103.840025833652,36.0577952682436,103.839681169792,36.0578814342086,103.839422671897,36.0579676001736,103.839250339967,36.0581399321036,103.838819510142,36.0583122640336,103.838561012247,36.0583122640336,103.838388680317,36.0583122640336,103.838216348387,36.0584845959635,103.838044016457,36.0584845959635,103.837957850492,36.0584845959635,103.837871684527,36.0585707619285,103.837785518562,36.0585707619285,103.837699352597,36.0586569278935,103.837527020667,36.0586569278935,103.837354688737,36.0586569278935,103.837182356807,36.0587430938585,103.837096190842,36.0587430938585"; 
            int pageNum = 10; 
            int pageSize = 10; 
            List<GridInfo> actual;
            actual = target.GetPcsZrqPageListByPoly(gridType, polygon, pageNum, pageSize);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///圈选场所分页列表 的测试
        ///</summary>
        [TestMethod()]
        public void GetCSPageListByPolyTest1()
        {
            PolySelectManager target = new PolySelectManager(); 
            string csType = "重点单位";
            string polygon = "103.843041642426,36.0575367703487,103.825636117499,36.0560719489439,103.825205287674,36.0556411191189,103.824602125919,36.054779459469,103.824257462059,36.0540039657841,103.823740466269,36.0530561401693,103.823568134339,36.0521944805194,103.823395802409,36.0515051527995,103.823395802409,36.0509019910446,103.823395802409,36.0503849952546,103.823740466269,36.0496095015697,103.824343628024,36.0487478419199,103.825119121709,36.04771385034,103.826239279254,36.0467660247251,103.828134930483,36.0455597012153,103.830633743468,36.0443533777054,103.833391054348,36.0429747222656,103.836148365227,36.0417683987558,103.838991842072,36.0409929050709,103.842007650846,36.040562075246,103.844592629796,36.040131245421,103.847091442781,36.039872747526,103.849762587695,36.039872747526,103.85260606454,36.0397004155961,103.85501871156,36.0397004155961,103.857431358579,36.0397004155961,103.859413175774,36.0397004155961,103.860877997179,36.0397004155961,103.862515150514,36.039958913491,103.863721474023,36.040389743316,103.864841631568,36.0406482412109,103.865617125253,36.0409929050709,103.866392618938,36.0411652370009,103.866995780693,36.0413375689308,103.867771274378,36.0415099008608,103.868460602098,36.0415960668258,103.869149929818,36.0416822327908,103.869925423503,36.0417683987558,103.870614751223,36.0420268966508,103.871390244907,36.0421992285807,103.872251904557,36.0425438924407,103.872941232277,36.0427162243707,103.873802891927,36.0430608882306,103.874578385612,36.0433193861256,103.875612377192,36.0437502159505,103.876387870877,36.0440948798105,103.877163364562,36.0444395436704,103.877852692282,36.0447842075304,103.878283522107,36.0450427054254,103.878455854037,36.0451288713903,103.878714351931,36.0453873692853,103.878714351931,36.0454735352503,103.878886683861,36.0457320331453,103.879059015791,36.0461628629702,103.879145181756,36.0464213608652,103.879145181756,36.0466798587601,103.879145181756,36.0469383566551,103.879145181756,36.0471968545501,103.879145181756,36.04754151841,103.878886683861,36.0482308461299,103.878369688072,36.0488340078848,103.877938858247,36.0495233356047,103.877163364562,36.0502126633247,103.876301704912,36.0506434931496,103.875095381402,36.0514189868345,103.873802891927,36.0519359826244,103.872338070522,36.0525391443793,103.870356253328,36.0532284720992,103.868460602098,36.0536593019242,103.866306452973,36.0540901317491,103.864066137883,36.0545209615741,103.861739656829,36.054779459469,103.858982345949,36.055037957364,103.857000528754,36.055210289294,103.85519104349,36.0555549531539,103.85398471998,36.0556411191189,103.8529507284,36.0558134510489,103.85208906875,36.0558996170139,103.8512274091,36.0559857829789,103.85053808138,36.0561581149089,103.84967642173,36.0561581149089,103.84898709401,36.0561581149089,103.848297766291,36.0562442808738,103.847608438571,36.0563304468388,103.846832944886,36.0564166128038,103.846229783131,36.0565027787688,103.845368123481,36.0566751106988,103.844937293656,36.0566751106988,103.844161799971,36.0567612766638,103.843386306286,36.0569336085938,103.842610812601,36.0570197745587,103.841921484881,36.0571059405237,103.841145991197,36.0572782724537,103.840715161372,36.0574506043837,103.840284331547,36.0576229363137,103.840025833652,36.0577952682436,103.839681169792,36.0578814342086,103.839422671897,36.0579676001736,103.839250339967,36.0581399321036,103.838819510142,36.0583122640336,103.838561012247,36.0583122640336,103.838388680317,36.0583122640336,103.838216348387,36.0584845959635,103.838044016457,36.0584845959635,103.837957850492,36.0584845959635,103.837871684527,36.0585707619285,103.837785518562,36.0585707619285,103.837699352597,36.0586569278935,103.837527020667,36.0586569278935,103.837354688737,36.0586569278935,103.837182356807,36.0587430938585,103.837096190842,36.0587430938585";
            int pageNum = 10; 
            int pageSize = 10;
            List<PolyCS> actual;
            actual = target.GetCSPageListByPoly(csType, polygon, pageNum, pageSize);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///OneKeySearch 的测试
        ///</summary>
        [TestMethod()]
        public void OneKeySearchTest()
        {
            PolySelectManager target = new PolySelectManager(); 
            string sjzjdw = "62"; 
            string text = "如家"; 
            SearchResult expected = null;
            SearchResult actual;
            actual = target.OneKeySearch(sjzjdw, text);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        ///<summary>
        ///获取全省监所列表
        ///</summary>
        [TestMethod()]
        public void GetJSListByProvinceTest() 
        {
            PolySelectManager target = new PolySelectManager();
            string type = "看守所";
            List<PolyJS> actual;
            actual = target.GetJSListByProvince(type);
            Assert.AreEqual(actual.Count >= 1, true);
        }
    }
}
