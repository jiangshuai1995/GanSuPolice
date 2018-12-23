namespace Beyon.WebService.GridPlatform.GridSelect
{
    using Beyon.Common;
    using Beyon.Domain.GridSelect;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Globalization;
    using System.Linq;

    public class GridSelectManager
    {
        private const string configFileName = "webservice.config";

        public List<GridInfo> GetAllGrids()
        {
            return JsonConvert.DeserializeObject<List<GridInfo>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格层次"), null));
        }

        public Dictionary<string, long> GetAnJianCount(string gridId)
        {
            Dictionary<string, long> dictionary = JsonConvert.DeserializeObject<Dictionary<string, long>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格案件统计") + "?id=" + gridId, null));
            Dictionary<string, long> dictionary2 = new Dictionary<string, long>();
            try
            {
                dictionary2.Add("接处警", dictionary["jj"]);
                dictionary2.Add("刑事案件", dictionary["xsla"]);
                dictionary2.Add("治安案件", dictionary["zala"]);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("获取的场所统计值不是有效的数字!");
            }
            return dictionary2;
        }

        public string GetAnJianDetail(string ajType, string ajid)
        {
            switch (ajType)
            {
                case "接处警":
                    return (ConfigHelper.GetValueByKey("webservice.config", "案件-接触警详细信息") + ajid);

                case "刑事案件":
                    return (ConfigHelper.GetValueByKey("webservice.config", "案件-刑事案件详细信息") + ajid);

                case "治安案件":
                    return (ConfigHelper.GetValueByKey("webservice.config", "案件-治安案件详细信息") + ajid);
            }
            throw new ArgumentException("传入案件类型参数不正确");
        }

        public List<Building> GetBuildingByRenKou(string sfzh)
        {
            return JsonConvert.DeserializeObject<List<Building>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "获取人员所属房屋列表") + "?id=" + sfzh, null));
        }

        public GridBuilding GetBuildingCount(string gridId)
        {
            List<Building> list = JsonConvert.DeserializeObject<List<Building>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格房屋统计") + "?id=" + gridId, null));
            return new GridBuilding { Count = list.Count, BuildingList = list };
        }

        public BuildingDetail GetBuildingDetail(string fwId)
        {
            List<BuildingDetail> list = JsonConvert.DeserializeObject<List<BuildingDetail>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "房屋详细信息") + "?id=" + fwId, null));
            return ((list.Count >= 1) ? list[0] : new BuildingDetail());
        }

        public List<ChangSuo> GetChangSuoList(string gridId, string type)
        {
            string str = ConfigHelper.GetValueByKey("webservice.config", "网格场所列表") + "?id=" + gridId;
            string valueByKey = ConfigHelper.GetValueByKey("webservice.config", type);
            return JsonConvert.DeserializeObject<List<ChangSuo>>(ServiceUtil.GetRemoteXmlStream(str + "&type=" + valueByKey, null));
        }

        public List<GridInfo> GetChildGrids(string gridId, string type)
        {
            List<GridInfo> source = JsonConvert.DeserializeObject<List<GridInfo>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格层次") + "?id=" + gridId + "&type=" + type, null));
            if (type.Equals("050106"))
            {
                Dictionary<string, GridInfo> dictionary = source.ToDictionary<GridInfo, string, GridInfo>(x => x.MC, x => x);
                return new List<GridInfo> { dictionary["兰州市公安局"], dictionary["嘉峪关市公安局"], dictionary["金昌市公安局"], dictionary["白银市公安局"], dictionary["天水市公安局"], dictionary["武威市公安局"], dictionary["张掖市公安局"], dictionary["平凉市公安局"], dictionary["酒泉市公安局"], dictionary["庆阳市公安局"], dictionary["定西市公安局"], dictionary["陇南市公安局"], dictionary["临夏回族自治州公安局"], dictionary["甘南藏族自治州公安局"] };
            }
            return source;
        }

        public Dictionary<string, long> GetCSCount(string gridId, string type)
        {
            string valueByKey = ConfigHelper.GetValueByKey("webservice.config", "网格场所统计");
            string str2 = ConfigHelper.GetValueByKey("webservice.config", type);
            string remoteXmlStream = ServiceUtil.GetRemoteXmlStream(valueByKey + "?id=" + gridId + "&type=" + str2, null);
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            try
            {
                long num = Convert.ToInt64(remoteXmlStream);
                dictionary.Add(type, num);
            }
            catch (FormatException)
            {
                throw new FormatException("获取的场所统计值不是有效的数字!");
            }
            return dictionary;
        }

        public CSDetail GetCSDetail(string csId, string type)
        {
            string str = ConfigHelper.GetValueByKey("webservice.config", "场所详细信息无照片") + "?id=" + csId;
            string valueByKey = ConfigHelper.GetValueByKey("webservice.config", type);
            List<CSDetail> list = JsonConvert.DeserializeObject<List<CSDetail>>(ServiceUtil.GetRemoteXmlStream(str + "&type=" + valueByKey, null));
            return ((list.Count >= 1) ? list[0] : new CSDetail());
        }

        public CSDetailWithPic GetCSDetailWithPic(string csId, string type)
        {
            string str = ConfigHelper.GetValueByKey("webservice.config", "场所详细信息有照片") + "?id=" + csId;
            string valueByKey = ConfigHelper.GetValueByKey("webservice.config", type);
            return JsonConvert.DeserializeObject<CSDetailWithPic>(ServiceUtil.GetRemoteXmlStream(str + "&type=" + valueByKey, null));
        }

        public List<RenKou> GetCZRenKouList(string gridId)
        {
            return JsonConvert.DeserializeObject<List<RenKou>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格常住人口列表") + "?id=" + gridId, null));
        }

        public DqbZDRenKou GetDqbZDRenKouDetail(string sfzh)
        {
            string remoteXmlStream = ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "大情报重点人口详细信息") + "?key=" + sfzh, null);
            List<DqbZDRenKou> list = null;
            try
            {
                list = JsonConvert.DeserializeObject<List<DqbZDRenKou>>(remoteXmlStream);
            }
            catch (Exception)
            {
                throw new Exception("反序列号失败！后端服务返回数据错误！");
            }
            return ((list.Count >= 1) ? list[0] : new DqbZDRenKou());
        }

        public List<RenKou> GetFangWuRenKou(string fwId)
        {
            return JsonConvert.DeserializeObject<List<RenKou>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "获取房屋内人员列表") + "?id=" + fwId, null));
        }

        public GridSummary GetGridSummary(string gridId)
        {
            Dictionary<string, List<Dictionary<string, string>>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格概要信息") + "?id=" + gridId, null));
            List<Dictionary<string, string>> list = dictionary["sl"];
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            foreach (Dictionary<string, string> dictionary3 in list)
            {
                dictionary2.Add(dictionary3["LX"], dictionary3["SL"]);
            }
            List<Dictionary<string, string>> list2 = dictionary["info"];
            return new GridSummary { 
                GridName = list2[0]["MC"], GridId = list2[0]["ZZJGDM"], FatherGridId = list2[0]["SSJGDM"], FLDM = list2[0]["FLDM"], Contacts = list2[0].ContainsKey("LXR") ? list2[0]["LXR"] : string.Empty, PhoneNumber = list2[0].ContainsKey("LXDH") ? list2[0]["LXDH"] : string.Empty, FWCount = dictionary2.ContainsKey("fw") ? Convert.ToInt64(dictionary2["fw"]) : 0L, CKCount = dictionary2.ContainsKey("czrk") ? Convert.ToInt64(dictionary2["czrk"]) : 0L, ZDRKCount = dictionary2.ContainsKey("zdr") ? Convert.ToInt64(dictionary2["zdr"]) : 0L, JieJingCount = dictionary2.ContainsKey("jj") ? Convert.ToInt64(dictionary2["jj"]) : 0L, ChuJingCount = dictionary2.ContainsKey("cj") ? Convert.ToInt64(dictionary2["cj"]) : 0L, XingShiLiAnCount = dictionary2.ContainsKey("xsla") ? Convert.ToInt64(dictionary2["xsla"]) : 0L, XingShiPoAnCount = dictionary2.ContainsKey("xspa") ? Convert.ToInt64(dictionary2["xspa"]) : 0L, ZhiAnLiAnCount = dictionary2.ContainsKey("zala") ? Convert.ToInt64(dictionary2["zala"]) : 0L, ZhiAnPoAnCount = dictionary2.ContainsKey("zaja") ? Convert.ToInt64(dictionary2["zaja"]) : 0L, PoliceCarCount = dictionary2.ContainsKey("jc") ? Convert.ToInt64(dictionary2["jc"]) : 0L, 
                PoliceManCount = dictionary2.ContainsKey("jy") ? Convert.ToInt64(dictionary2["jy"]) : 0L
             };
        }

        public Dictionary<string, long> GetJcJyCount(string gridId)
        {
            Dictionary<string, long> dictionary = JsonConvert.DeserializeObject<Dictionary<string, long>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格警车警力统计") + "?id=" + gridId, null));
            Dictionary<string, long> dictionary2 = new Dictionary<string, long>();
            dictionary2.Add("警车", dictionary["jc"]);
            dictionary2.Add("警员", dictionary["jy"]);
            return dictionary2;
        }

        public List<JieChuJing> GetJieChuJingList(string gridId)
        {
            return JsonConvert.DeserializeObject<List<JieChuJing>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格接处警案件列表") + "?id=" + gridId, null));
        }

        public LvKe GetLvKeDetail(string lksfzh,string dateTime=null)
        {

            //OleDbConnectionStringBuilder zzjgDBConnectBuilder = new OleDbConnectionStringBuilder();

            //zzjgDBConnectBuilder.Add("Provider", "MSDAORA");
            //zzjgDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "zzjgDB"));
            //zzjgDBConnectBuilder.Add("Persist Security Info", true);
            //zzjgDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBUser"));
            //zzjgDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBPasswd"));

            //DateTimeFormatInfo format = new System.Globalization.DateTimeFormatInfo();
            //format.ShortDatePattern = "yyyyMMddhhmm";

            //LvKe info = new LvKe();

            //try
            //{
            //    using (OleDbConnection conn = new OleDbConnection(zzjgDBConnectBuilder.ConnectionString))
            //    {
            //        String sql = String.Format("select XM,ZJHM,RZFH,RZSJ from B_ZTK_SP_LKZSXX where ZJHM='{0}' AND ROWNUM=1", lksfzh);
            //        conn.Open();
            //        OleDbCommand cmd = new OleDbCommand(sql, conn);
            //        OleDbDataReader reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
                        
            //            if (!reader.IsDBNull(0))
            //            {
            //                info.LKXM = reader[0].ToString();
            //            }
            //            if (!reader.IsDBNull(1))
            //            {
            //                info.LKSFZH = reader[1].ToString();
            //            }
            //            if (!reader.IsDBNull(2))
            //            {
            //                info.FJH = reader[2].ToString();
            //            }
            //            if (!reader.IsDBNull(3))
            //            {
            //                info.RZSJ = DateTime.Parse(reader[3].ToString(), format);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            //return info;

            List<LvKe> list = JsonConvert.DeserializeObject<List<LvKe>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "旅馆旅客详细信息") + "?id=" + lksfzh, null));
            if (!String.IsNullOrEmpty(dateTime))
            {
                foreach (var lvke in list)
                {
                    if (String.Equals(lvke.RZSJ.ToString(), dateTime))
                    {
                        return lvke;
                    }
                }
            }

            return ((list.Count >= 1) ? list[0] : new LvKe());
        }

        public List<LvKe> GetLvKeList(string ldId)
        {
            
            //List<LvKe> list = new List<LvKe>();
            //OleDbConnectionStringBuilder zzjgDBConnectBuilder = new OleDbConnectionStringBuilder();

            //zzjgDBConnectBuilder.Add("Provider", "MSDAORA");
            //zzjgDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "zzjgDB"));
            //zzjgDBConnectBuilder.Add("Persist Security Info", true);
            //zzjgDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBUser"));
            //zzjgDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBPasswd"));

            //DateTimeFormatInfo format = new System.Globalization.DateTimeFormatInfo();
            //format.ShortDatePattern = "yyyyMMddhhmm";

            //try
            //{
            //    using (OleDbConnection conn = new OleDbConnection(zzjgDBConnectBuilder.ConnectionString))
            //    {
            //        String sql = String.Format("select XM,ZJHM,RZFH,RZSJ from B_ZTK_SP_LKZSXX where LGBM='{0}'", ldId);
            //        conn.Open();
            //        OleDbCommand cmd = new OleDbCommand(sql, conn);
            //        OleDbDataReader reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            LvKe info = new LvKe();
            //            if (!reader.IsDBNull(0))
            //            {
            //                info.LKXM = reader[0].ToString();
            //            }
            //            if (!reader.IsDBNull(1))
            //            {
            //                info.LKSFZH = reader[1].ToString();
            //            }
            //            if (!reader.IsDBNull(2))
            //            {
            //                info.FJH = reader[2].ToString();
            //            }
            //            if (!reader.IsDBNull(3))
            //            {
            //                info.RZSJ = DateTime.Parse(reader[3].ToString(),format);
            //            }
            //            list.Add(info);
            //        }
            //    }
            //}
            //catch (Exception ex) 
            //{
            //    throw ex;
            //}




            var list = JsonConvert.DeserializeObject<List<LvKe>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "旅馆旅客列表") + "?id=" + ldId, null));
            if (list != null && list.Count > 0)
            {
                list = list.OrderByDescending(t => t.RZSJ).ToList<LvKe>();
            }

            //list = list.OrderByDescending(t => t.RZSJ).ToList<LvKe>();
            return list;
        }

        public List<PoliceCar> GetPoliceCarList(string gridId)
        {
            return JsonConvert.DeserializeObject<List<PoliceCar>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格警车列表") + "?id=" + gridId, null));
        }

        public PoliceManDetail GetPoliceManDetail(string jyid)
        {
            List<PoliceManDetail> list = JsonConvert.DeserializeObject<List<PoliceManDetail>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "警员详细信息") + "?leaderCode=" + jyid, null));
            return ((list.Count >= 1) ? list[0] : new PoliceManDetail());
        }

        public List<PoliceMan> GetPoliceManList(string gridId)
        {
            return JsonConvert.DeserializeObject<List<PoliceMan>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格警员列表") + "?id=" + gridId, null));
        }

        public Dictionary<string, long> GetRenKouCount(string gridId)
        {
            Dictionary<string, long> dictionary = JsonConvert.DeserializeObject<Dictionary<string, long>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格人口统计") + "?id=" + gridId, null));
            Dictionary<string, long> dictionary2 = new Dictionary<string, long>();
            dictionary2.Add("常住人口", dictionary["rk"]);
            dictionary2.Add("重点人口", dictionary["zdrk"]);
            return dictionary2;
        }

        public RenKou GetRenKouDetail(string sfzh)
        {
            return JsonConvert.DeserializeObject<RenKou>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "人员详细信息") + "?id=" + sfzh, null));
        }

        public SWRY GetSWRYDetail(string zjhm, string time = null)
        {
            List<SWRY> list = JsonConvert.DeserializeObject<List<SWRY>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网吧上网人员详细信息") + "?id=" + zjhm, null));
            if (!string.IsNullOrEmpty(time))
            {
                foreach (var swry in list)
                {
                    if (string.Equals(swry.SJSJ.ToString(), time))
                    {
                        return swry;
                    }
                }
            }
            return ((list.Count >= 1) ? list[0] : new SWRY());
        }

        public List<SWRY> GetSWRYList(string wbId)
        {
            var list = JsonConvert.DeserializeObject<List<SWRY>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网吧上网人员列表") + "?id=" + wbId, null));
            if (list != null && list.Count > 0)
            {
                list = list.OrderByDescending(t => t.SJSJ).ToList<SWRY>();
            }
            return list;
        }

        public Dictionary<string, long> GetVideoCount(string gridId)
        {
            List<Dictionary<string, string>> list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格视频统计") + "?id=" + gridId, null));
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            foreach (Dictionary<string, string> dictionary2 in list)
            {
                dictionary.Add(dictionary2["LX"], Convert.ToInt64(dictionary2["SL"]));
            }
            Dictionary<string, long> dictionary3 = new Dictionary<string, long>();
            dictionary3.Add("重点场所", dictionary["zdcs"]);
            dictionary3.Add("道路交通", dictionary["dljt"]);
            dictionary3.Add("公共场所", dictionary["ggcs"]);
            dictionary3.Add("监管场所", dictionary["jgcs"]);
            dictionary3.Add("办案中心", dictionary["bazx"]);
            dictionary3.Add("窗口单位", dictionary["ckdw"]);
            dictionary3.Add("移动视频", dictionary["ydsp"]);
            dictionary3.Add("内部视频", dictionary["nbsp"]);
            return dictionary3;
        }

        public List<Video> GetVideoListByGrid(string gridId, string videoType)
        {
            string str = ConfigHelper.GetValueByKey("webservice.config", "网格视频列表") + "?id=" + gridId;
            string valueByKey = ConfigHelper.GetValueByKey("webservice.config", videoType);
            return JsonConvert.DeserializeObject<List<Video>>(ServiceUtil.GetRemoteXmlStream(str + "&type=" + valueByKey, null));
        }

        public List<AnJian> GetXingShiAJList(string gridId)
        {
            return JsonConvert.DeserializeObject<List<AnJian>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格刑事案件列表") + "?id=" + gridId, null));
        }

        public ZDRenKou GetZDRenKouDetail(string sfzh)
        {
            return JsonConvert.DeserializeObject<ZDRenKou>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "重点人口详细信息") + "?id=" + sfzh, null));
        }

        public List<RenKou> GetZDRenKouList(string gridId)
        {
            return JsonConvert.DeserializeObject<List<RenKou>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格重点人口列表") + "?id=" + gridId, null));
        }

        public List<AnJian> GetZhiAnAjList(string gridId)
        {
            return JsonConvert.DeserializeObject<List<AnJian>>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "网格治安案件列表") + "?id=" + gridId, null));
        }
    }
}

