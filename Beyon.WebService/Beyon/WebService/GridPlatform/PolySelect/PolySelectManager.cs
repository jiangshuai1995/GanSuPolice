namespace Beyon.WebService.GridPlatform.PolySelect
{
    using Beyon.Common;
    using Beyon.Domain.PolySelect;
    using Beyon.Domain.GridSelect;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.IO;
    using Beyon.Domain.GridSearch;
using System.Data.OleDb;

    /// <summary>
    /// 圈选管理类
    /// </summary>
    public class PolySelectManager
    {
        /// <summary>
        /// 配置文件
        /// </summary>
        private const string configFileName = "webservice.config";
        /// <summary>
        /// 圈选获取案件统计
        /// </summary>
        /// <param name="mapLevel">地图级别</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public Dictionary<string, long> GetAjCountByPoly(string mapLevel, string polygon)
        {
            long num;
            long num2;
            long num3;
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选案件统计") + "?geom=" + polygon + "&pageNum=1&pageSize=1"; ;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null));
            long.TryParse(obj2["xsla"].ToString(), out num3);
            long.TryParse(obj2["zala"].ToString(), out num2);
            long.TryParse(obj2["jj"].ToString(), out num);
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            dictionary.Add("接处警", num);
            dictionary.Add("治安案件", num2);
            dictionary.Add("刑事案件", num3);
            return dictionary;
        }

        /// <summary>
        /// 圈选获取案件列表
        /// </summary>
        /// <param name="ajType">案件类型</param>
        /// <param name="mapLevel">地图级别</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<AnJian> GetAnJianListByPoly(string ajType, string mapLevel, string polygon)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选案件统计") + "?geom=" + polygon;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null));
            switch (ajType)
            {
                case "接处警":
                    return JsonConvert.DeserializeObject<List<AnJian>>(obj2["jjList"].ToString());

                case "治安案件":
                    return JsonConvert.DeserializeObject<List<AnJian>>(obj2["zalaList"].ToString());

                case "刑事案件":
                    return JsonConvert.DeserializeObject<List<AnJian>>(obj2["xslaList"].ToString());
            }
            throw new ArgumentException("案件-二级菜单名称不匹配！");
        }

        /// <summary>
        /// 圈选获取案件分页列表
        /// </summary>
        /// <param name="ajType">案件类型</param>
        /// <param name="mapLevel">级别，派出所or责任区</param>
        /// <param name="polygon">圈选范围</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">页码大小</param>
        /// <returns></returns>
        public List<AnJian> GetAnJianPageListByPoly(string ajType, string mapLevel, string polygon, int pageNum, int pageSize)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选案件分页列表") + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            //string url = "http://10.178.21.52:8080/SmartCity/dzsp/getAjCountByPoly.ws" + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null));
            switch (ajType)
            {
                case "接处警":
                    return JsonConvert.DeserializeObject<List<AnJian>>(obj2["jjList"].ToString());

                case "治安案件":
                    return JsonConvert.DeserializeObject<List<AnJian>>(obj2["zalaList"].ToString());

                case "刑事案件":
                    return JsonConvert.DeserializeObject<List<AnJian>>(obj2["xslaList"].ToString());
            }
            throw new ArgumentException("案件-二级菜单名称不匹配！");
        }

        /// <summary>
        /// 圈选获取场所统计
        /// </summary>
        /// <param name="csType">场所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public long GetCSCountByPoly(string csType, string polygon)
        {
            ServiceUtil.GetRemoteXmlStream(string.Concat(new string[]
	        {
		        ConfigHelper.GetValueByKey("webservice.config", "圈选场所统计"),
		        "?geom=",
		        polygon,
		        "&pageNum=1&pageSize=1&type=",
		        ConfigHelper.GetValueByKey("webservice.config", csType)
	        }), null);

             long result;
             long.TryParse(JObject.Parse(ServiceUtil.GetRemoteXmlStream(string.Concat(new string[]
	        {
		        ConfigHelper.GetValueByKey("webservice.config", "圈选场所统计"),
		        "?geom=",
		        polygon,
		        "&type=",
		        ConfigHelper.GetValueByKey("webservice.config", csType)
	        }), null))["count"].ToString(), out result);
            return result;
        }

        /// <summary>
        /// 圈选获取场所列表
        /// </summary>
        /// <param name="csType">场所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyCS> GetCSListByPoly(string csType, string polygon)
        {
            return JsonConvert.DeserializeObject<List<PolyCS>>(JObject.Parse(ServiceUtil.GetRemoteXmlStream((ConfigHelper.GetValueByKey("webservice.config", "圈选场所统计") + "?geom=" + polygon) + "&type=" + ConfigHelper.GetValueByKey("webservice.config", csType), null))["list"].ToString());
        }

        /// <summary>
        /// 获取场所分页列表
        /// </summary>
        /// <param name="csType">场所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyCS> GetCSPageListByPoly(string csType, string polygon, int pageNum, int pageSize)
        {
             String url = ConfigHelper.GetValueByKey("webservice.config", "圈选场所分页列表") + "?geom=" + polygon + "&type=" + ConfigHelper.GetValueByKey("webservice.config", csType) + "&pageNum=" +                 pageNum + "&pageSize=" + pageSize;
             //String url = "http://10.178.21.52:8080/SmartCity/dzsp/getCsCountByPoly.ws" + "?geom=" + polygon + "&type=DWXX_YLWS_PT" + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
             return JsonConvert.DeserializeObject<List<PolyCS>>(JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null))["list"].ToString());
        }

        private bool PtInPolygon(double jd, double wd, List<Point> polygon)
        {
            int cross_count = 0; //交点数量
            double x1, y1, x2, y2;
            int pt_count = polygon.Count;
            for (int i = 0; i < pt_count; ++i)
            {
                x1 = polygon[i].X;
                y1 = polygon[i].Y;
                x2 = polygon[(i + 1) % pt_count].X;
                y2 = polygon[(i + 1) % pt_count].Y;
                //判断过点pt的射线 L1: y=pt.latitude(x<=pt.longitude)与过点P1(x1,y1)和P2(x2,y2)的直线L2是否有交点
                if (y1 == y2) //L1与L2平行
                {
                    if ((wd == y1) && (jd >= Math.Min(x1, x2)) && (jd <= Math.Max(x1, x2)))//P在直线L2上
                        return true;
                    continue;
                }
                //交点在P1P2的延长线上，此时若交点是P1或P2中的一个，则如果P的纵坐标等于P1P2纵坐标中较小者，则略过此情况
                if ((wd <= Math.Min(y1, y2)) || (wd > Math.Max(y1, y2)))
                    continue;
                //计算交点的横坐标（经度）
                double x = (wd - y1) * (x1 - x2) / (y1 - y2) + x1;
                if (Math.Abs(x - jd) < 0.000001) //点P是交点
                    return true;
                else if (x < jd)
                    cross_count++;
            }

            if (cross_count % 2 == 1)
                return true;
            else return false;
        }

        //public  bool PtInPolygon(Point p, List<Point> ptPolygon)
        //    {
        //        int nCross = 0;
        //        int nCount = ptPolygon.Count;
        //        for (int i = 0; i < nCount; i++)
        //        {
        //            Point p1 = ptPolygon[i];
        //            Point p2 = ptPolygon[(i + 1) % nCount];

        //            // 求解 y=p.y 与 p1p2 的交点

        //            if (p1.X == p2.Y) // p1p2 与 y=p0.y平行
        //                continue;

        //            if (p.Y < Math.Min(p1.Y, p2.Y)) // 交点在p1p2延长线上
        //                continue;
        //            if (p.Y >= Math.Max(p1.Y, p2.Y)) // 交点在p1p2延长线上
        //                continue;

        //            // 求交点的 X 坐标 --------------------------------------------------------------
        //            double x = (double)(p.Y - p1.Y) * (double)(p2.X - p1.X) / (double)(p2.Y - p1.Y) + p1.X;

        //            if (x > p.Y)
        //                nCross++; // 只统计单边交点
        //        }

        //        // 单边交点为偶数，点在多边形之外 --- 
        //        return (nCross % 2 == 1);
        //    }

        /// <summary>
        /// 圈选获取监所列表
        /// </summary>
        /// <param name="jsType">监所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyJS> GetJSListByPoly(string jsType, List<Point> polygon)
        {
            //string url = ConfigHelper.GetValueByKey("webservice.config", "监所") + ConfigHelper.GetValueByKey("webservice.config", jsType);
            //List<PolyJS> jslist = JsonConvert.DeserializeObject<List<PolyJS>>((ServiceUtil.GetRemoteXmlStream(url, null)));
            //List<PolyJS> jsli = new List<PolyJS>();
            //Point p = new Point();
            //double jd;
            //double wd;
            ////foreach (PolyJS js in jslist)
            ////{
            ////    if (js.GAJGJD != null && js.GAJGWD != null)
            ////    {
            ////        double.TryParse(js.GAJGJD, out jd);
            ////        double.TryParse(js.GAJGWD, out wd);
            ////        p.X = jd;
            ////        p.Y = wd;
            ////        bool re = PtInPolygon(jd,wd, polygon);
            ////        if (re == true)
            ////        {
            ////            jsli.Add(js);
            ////        }
            ////    }
            ////}
            ////return jsli;

            //return jslist;

            string url = ConfigHelper.GetValueByKey("webservice.config", "监所") + ConfigHelper.GetValueByKey("webservice.config", jsType);
            List<PolyJS> list = JsonConvert.DeserializeObject<List<PolyJS>>(ServiceUtil.GetRemoteXmlStream(url, null));
            List<PolyJS> list2 = new List<PolyJS>();
            Point point = default(Point);
            foreach (PolyJS current in list)
            {
                if (current.GAJGJD != null && current.GAJGWD != null)
                {
                    double num;
                    if (!double.TryParse(current.GAJGJD, out num))
                        continue;
                    double num2;
                    if (!double.TryParse(current.GAJGWD, out num2))
                        continue;
                    point.X = num;
                    point.Y = num2;
                    bool flag = this.PtInPolygon(num, num2, polygon);
                    if (flag)
                    {
                        list2.Add(current);
                    }
                }
            }
            return list2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsType"></param>
        /// <returns></returns>
        public List<PolyJS> GetJSListByProvince(string jsType)
        {
            OleDbConnectionStringBuilder zzjgDBConnectBuilder = new OleDbConnectionStringBuilder();

             zzjgDBConnectBuilder.Add("Provider", "MSDAORA");
             zzjgDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "zzjgDB"));
             zzjgDBConnectBuilder.Add("Persist Security Info", true);
             zzjgDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBUser"));
             zzjgDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBPasswd"));

            string type ="0";
            if(jsType=="看守所")
            {
                type="1";
            }
            else if(jsType=="拘留所")
            {
                type="2";
            }
            else if(jsType=="戒毒所")
            {
                type="3";
            }

             List<PolyJS> result = new List<PolyJS>();

             try
             {
                 using (OleDbConnection conn = new OleDbConnection(zzjgDBConnectBuilder.ConnectionString))
                 { 
                        String sql =String.Format( "select JSBH,JSMC,DZ,GAJGJD,GAJGWD from B_ZTK_SP_JSJBXX where substr(JSBH,7,1)='{0}'",type);
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read()) 
                        {
                            PolyJS info = new PolyJS();
                            if (!reader.IsDBNull(0))
                            {
                                info.JS_CODE = reader[0].ToString();
                            }

                            if (!reader.IsDBNull(1))
                            {
                                info.JS_MC = reader[1].ToString();
                            }
                            if (!reader.IsDBNull(2)) 
                            { 
                                
                            }
                            if (!reader.IsDBNull(3) && !reader.IsDBNull(4)) 
                            {
                                info.GAJGJD = reader[3].ToString();
                                info.GAJGWD = reader[4].ToString();
                                result.Add(info);
                            }
                        }
                 }
             }
             catch (Exception ex) 
             {
                 throw ex;
             }

             return result;


            //string url = ConfigHelper.GetValueByKey("webservice.config", "监所") + ConfigHelper.GetValueByKey("webservice.config", jsType);
            //return JsonConvert.DeserializeObject<List<PolyJS>>((ServiceUtil.GetRemoteXmlStream(url, null)));
        }

        public List<RenKou> GetCZRenKouListByPoly(string mapLevel, string polygon)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选人口统计") + "?geom=" + polygon;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            return JsonConvert.DeserializeObject<List<RenKou>>(JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null))["czrkList"].ToString());
        }

        public PolySummary GetFQInfoByPoly(string mapLevel, string polygon)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选概要信息") + "?geom=" + polygon;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            return JsonConvert.DeserializeObject<PolySummary>(ServiceUtil.GetRemoteXmlStream(url, null));
        }

        public long GetFWCountByPoly(string mapLevel, string polygon)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选房屋统计") + "?geom=" + polygon + "&pageNum=1&pageSize=1";
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            PolyBuilding polyBuilding = JsonConvert.DeserializeObject<PolyBuilding>(ServiceUtil.GetRemoteXmlStream(url, null));
            return polyBuilding.fw;
        }

        public PolyBuilding GetFWListByPoly(string mapLevel, string polygon)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选房屋统计") + "?geom=" + polygon;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            return JsonConvert.DeserializeObject<PolyBuilding>(ServiceUtil.GetRemoteXmlStream(url, null));
        }

        /// <summary>
        /// 圈选获取分页房屋列表
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public PolyBuilding GetFWPageListByPoly(string mapLevel, string polygon, int pageNum, int pageSize)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选房屋分页列表") + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            //string url = "http://10.178.3.69/SmartCity/dzsp/getFwCountByPoly.ws" + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            return JsonConvert.DeserializeObject<PolyBuilding>(ServiceUtil.GetRemoteXmlStream(url, null));
        }

        /// <summary>
        /// 圈选获取派出所详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PcsDetail GetPcsDetailByPoly(string id)
        {
            return JsonConvert.DeserializeObject<PcsDetail>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选派出所责任区详细信息") + "?type=pcs&id=" + id, null));
        }

        /// <summary>
        /// 圈选获取派出所责任区统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetPcsZrqCountByPoly(string mapLevel, string polygon)
        {
            long num;
            long num2;
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选派出所责任区统计") + "?geom=" + polygon + "&pageNum=1&pageSize=1";
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null));
            long.TryParse(obj2["pcs"].ToString(), out num);
            long.TryParse(obj2["zrq"].ToString(), out num2);
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            dictionary.Add("派出所", num);
            dictionary.Add("责任区", num2);
            return dictionary;
        }

        /// <summary>
        /// 圈选获取派出所责任区列表
        /// </summary>
        /// <param name="gridType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<GridInfo> GetPcsZrqListByPoly(string gridType, string polygon)
        {
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选派出所责任区统计") + "?geom=" + polygon, null));
            switch (gridType)
            {
                case "派出所":
                    return JsonConvert.DeserializeObject<List<GridInfo>>(obj2["pcsList"].ToString());

                case "责任区":
                    return JsonConvert.DeserializeObject<List<GridInfo>>(obj2["zrqList"].ToString());
            }
            throw new ArgumentException("责任区域-区域类型名称不匹配！");
        }

        /// <summary>
        /// 圈选 派出所责任区 分页列表
        /// </summary>
        /// <param name="gridType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<GridInfo> GetPcsZrqPageListByPoly(string gridType, string polygon, int pageNum, int pageSize)
        {
            String url = ConfigHelper.GetValueByKey("webservice.config", "圈选派出所责任区统计") + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            //String url = "http://10.178.21.52:8080/SmartCity/dzsp/getJyCountByPoly.ws" + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null));
            switch (gridType)
            {
                case "派出所":
                    return JsonConvert.DeserializeObject<List<GridInfo>>(obj2["pcsList"].ToString());

                case "责任区":
                    return JsonConvert.DeserializeObject<List<GridInfo>>(obj2["zrqList"].ToString());
            }
            throw new ArgumentException("责任区域-区域类型名称不匹配！");
        }

        /// <summary>
        /// 圈选获取警察统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public long GetPoliceManCountByPoly(string mapLevel, string polygon)
        {
            long num;
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选警员统计") + "?geom=" + polygon + "&pageNum=1&pageSize=1";
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            long.TryParse(JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null))["jy"].ToString(), out num);
            return num;
        }

        public List<PoliceMan> GetPoliceManListByPoly(string polygon)
        {
            return JsonConvert.DeserializeObject<List<PoliceMan>>(JObject.Parse(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选警员统计") + "?geom=" + polygon, null))["jyList"].ToString());
        }

        /// <summary>
        /// 圈选获取警员分页列表
        /// </summary>
        /// <param name="polygon">圈选范围</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public List<PoliceMan> GetPoliceManPageListByPoly(string polygon, int pageNum, int pageSize)
        {
            String url = ConfigHelper.GetValueByKey("webservice.config", "圈选警员分页列表") + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            //String url = "http://10.178.21.52:8080/SmartCity/dzsp/getJyCountByPoly.ws" + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            return JsonConvert.DeserializeObject<List<PoliceMan>>(JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null))["jyList"].ToString());
        }

        /// <summary>
        /// 临时版 获取警车列表
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<PoliceCar> GetPoliceCarListByPoly(List<Point> polygon)
        {
            List<GridInfo> xzqhList = new List<GridInfo>();

            //从文本文件读取市局、县区列表
            String policeCarPath = ConfigHelper.GetAssemblyPath() + "PoliceCar.txt";
            StreamReader reader = new  StreamReader(policeCarPath);
            try
            {
                do
                {
                    string line = reader.ReadLine();
                    string[] lineList = line.Split(null);
                    GridInfo gridInfo = new GridInfo { ZZJGDM = lineList[0], JD = lineList[1], WD = lineList[2]}; //todo
                    xzqhList.Add(gridInfo);
                }
                while (reader.Peek() != -1);
            }
            catch(System.IO.FileNotFoundException)
            {
                throw new FileNotFoundException("未发现警车点文件");
            }
            finally
            {
                reader.Close();
            }

            List<GridInfo> filterXzqhList = new List<GridInfo>();
            foreach (GridInfo js in xzqhList)
            {
                if (js.JD != null && js.WD != null)
                {
                    double jd, wd;
                    double.TryParse(js.JD, out jd);
                    double.TryParse(js.WD, out wd);
                    bool re = PtInPolygon(jd, wd, polygon);
                    if (re == true)
                    {
                        filterXzqhList.Add(js);
                    }
                }
            }

            List<PoliceCar> plcList = JsonConvert.DeserializeObject<List<PoliceCar>>((ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选警车统计"), null)));
            List<PoliceCar> plcListRe = new List<PoliceCar>();
            string quxian = null;
            foreach (GridInfo pcs in filterXzqhList)
            {
                string pcsid = pcs.ZZJGDM.Substring(0, 6);
                if (pcsid.Equals(quxian))
                {
                    continue;
                }
                else
                {
                    quxian = pcsid;
                }
                foreach (PoliceCar plc in plcList)
                {
                    string plcid = plc.ORGID.Substring(0, 6);
                    if (pcsid.Equals(plcid))
                    {
                        plcListRe.Add(plc);
                    }
                }
            }
            return plcListRe;
        }

        /// <summary>
        /// 圈选获取人口统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetRenKouCountByPoly(string mapLevel, string polygon)
        {
            long num1;
            long num2;
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选人口统计") + "?geom=" + polygon + "&pageNum=1&pageSize=1"; 
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }
            string json = string.Empty;
            try
            {
                json = ServiceUtil.GetRemoteXmlStream(url, null);
            }
            catch (Exception)
            {
                json = ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选人口统计") + "?geom=" + polygon + "&queryType=outline", null);
            }
            JObject obj2 = JObject.Parse(json);
            //long.TryParse(obj2["zdr"].ToString(), out num2);
            long.TryParse(obj2["czrk"].ToString(), out num1);
            long.TryParse(obj2["zdrDqb"].ToString(), out num2);
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            dictionary.Add("常住人口", num1);
            //dictionary.Add("治安重点人口", num2);
            dictionary.Add("重点人口", num2);
            return dictionary;
        }

        /// <summary>
        /// 圈选获取人口列表
        /// </summary>
        /// <param name="rkType">人口类型</param>
        /// <param name="mapLevel">地图级别</param>
        /// <param name="polygon">圈选区域</param>
        /// <returns></returns>
        public List<RenKou> GetRenKouListByPoly(string rkType, string mapLevel, string polygon)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选人口统计") + "?geom=" + polygon;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }

            string json = string.Empty;
            try
            {
                json = ServiceUtil.GetRemoteXmlStream(url, null);
            }
            catch (Exception)
            {
                json = ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选人口统计") + "?geom=" + polygon + "&queryType=outline", null);
            }

            JObject obj2 = JObject.Parse(json);
            switch (rkType)
            {
                case "常住人口":
                    return JsonConvert.DeserializeObject<List<RenKou>>(obj2["czrkList"].ToString());

                //case "治安重点人口":
                //    return JsonConvert.DeserializeObject<List<RenKou>>(obj2["zdrList"].ToString());

                case "重点人口":
                    return JsonConvert.DeserializeObject<List<RenKou>>(obj2["zdrDqbList"].ToString());
            }
            throw new ArgumentException("无效的人口类型！");
        }

        /// <summary>
        /// 圈选获取分页人口列表
        /// </summary>
        /// <param name="rkType">人口类型</param>
        /// <param name="mapLevel">地图级别</param>
        /// <param name="polygon">圈选区域</param>
        /// <returns>分页列表</returns>
        public List<RenKou> GetRenKouPageListByPoly(string rkType, string mapLevel, string polygon, int pageNum, int pageSize)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "圈选人口分页列表") + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            //string url = "http://10.178.21.52:8080/SmartCity/dzsp/getRkCountByPoly.ws" + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            {
                url = url + "&queryType=accurate";
            }
            else
            {
                url = url + "&queryType=outline";
            }

            string json = string.Empty;
            try
            {
                json = ServiceUtil.GetRemoteXmlStream(url, null);
            }
            catch (Exception)
            {
                json = ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选人口分页列表") + "?geom=" + polygon 
                    + "&pageNum=" + pageNum + "&pageSize=" + pageSize + "&queryType=outline", null);
            }

            JObject obj2 = JObject.Parse(json);
            switch (rkType)
            {
                case "常住人口":
                    return JsonConvert.DeserializeObject<List<RenKou>>(obj2["czrkList"].ToString());

                //case "治安重点人口":
                //    return JsonConvert.DeserializeObject<List<RenKou>>(obj2["zdrList"].ToString());

                case "重点人口":
                    return JsonConvert.DeserializeObject<List<RenKou>>(obj2["zdrDqbList"].ToString());
            }
            throw new ArgumentException("无效的人口类型！");
        }

        /// <summary>
        /// 圈选获取视频监控统计值
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetSpjkCountByPoly(string polygon)
        {
            long num;
            long num2;
            long num3;
            long num4;
            long num5;
            long num6;
            long num7;
            long num8;
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选视频监控统计") + "?geom=" + polygon + "&pageNum=1&pageSize=1", null));
            long.TryParse(obj2["bazx"].ToString(), out num);
            long.TryParse(obj2["ckdw"].ToString(), out num2);
            long.TryParse(obj2["zdcs"].ToString(), out num3);
            long.TryParse(obj2["ggcs"].ToString(), out num4);
            long.TryParse(obj2["jgcs"].ToString(), out num5);
            long.TryParse(obj2["dljt"].ToString(), out num6);
            long.TryParse(obj2["ydsp"].ToString(), out num7);
            long.TryParse(obj2["nbsp"].ToString(), out num8);
            Dictionary<string, long> dictionary = new Dictionary<string, long>();
            dictionary.Add("办案中心", num);
            dictionary.Add("重点场所", num3);
            dictionary.Add("道路交通", num6);
            dictionary.Add("公共场所", num4);
            dictionary.Add("监管场所", num5);
            dictionary.Add("窗口单位", num2);
            dictionary.Add("移动视频", num7);
            dictionary.Add("内部视频", num8);
            return dictionary;
        }

        /// <summary>
        /// 圈选获取视频监控列表
        /// </summary>
        /// <param name="videoType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<Beyon.Domain.PolySelect.Video> GetSpjkListByPoly(string videoType, string polygon)
        {
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选视频监控统计") + "?geom=" + polygon, null));
            switch (videoType)
            {
                case "重点场所":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["zdcsList"].ToString());

                case "道路交通":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["dljtList"].ToString());

                case "公共场所":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["ggcsList"].ToString());

                case "监管场所":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["jgcsList"].ToString());

                case "办案中心":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["bazxList"].ToString());

                case "窗口单位":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["ckdwList"].ToString());

                case "移动视频":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["ydspList"].ToString());

                case "内部视频":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["nbspList"].ToString());
            }
            throw new ArgumentException("视频管理-错误的视频分类名称！");
        }

        /// <summary>
        /// 获取视频监控分页列表
        /// </summary>
        /// <param name="videoType">视频类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public List<Beyon.Domain.PolySelect.Video> GetSpjkPageListByPoly(string videoType, string polygon, int pageNum, int pageSize)
        {
            String url = ConfigHelper.GetValueByKey("webservice.config", "圈选视频监控分页列表") + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            //String url = "http://10.178.21.52:8080/SmartCity/dzsp/getSpjkCountByPoly.ws" + "?geom=" + polygon + "&pageNum=" + pageNum + "&pageSize=" + pageSize;
            JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null));
            switch (videoType)
            {
                case "重点场所":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["zdcsList"].ToString());

                case "道路交通":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["dljtList"].ToString());

                case "公共场所":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["ggcsList"].ToString());

                case "监管场所":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["jgcsList"].ToString());

                case "办案中心":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["bazxList"].ToString());

                case "窗口单位":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["ckdwList"].ToString());

                case "移动视频":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["ydspList"].ToString());

                case "内部视频":
                    return JsonConvert.DeserializeObject<List<Beyon.Domain.PolySelect.Video>>(obj2["nbspList"].ToString());
            }
            throw new ArgumentException("视频管理-错误的视频分类名称！");
        }

        /// <summary>
        /// 圈选获取责任区详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ZrqDetail GetZrqDetailByPoly(string id)
        {
            return JsonConvert.DeserializeObject<ZrqDetail>(ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选派出所责任区详细信息") + "?type=zrq&id=" + id, null));
        }

        /// <summary>
        /// 圈选获取监所人员列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<JSPerson> GetJSPersonListByPoly(string type,string id)
        {
            string url=ConfigHelper.GetValueByKey("webservice.config", "监所人员列表")+ type;
            List<JSPerson> alljsp = new List<JSPerson>();
            alljsp=JsonConvert.DeserializeObject<List<JSPerson>>(ServiceUtil.GetRemoteXmlStream(url,null));
            List<JSPerson> idjsp = new List<JSPerson>();
            foreach (JSPerson jsp in alljsp)
            {
                if (jsp.JBXXBH != null)
                {
                    if (jsp.JBXXBH.Substring(0, 9).Equals(id))
                    {
                        idjsp.Add(jsp);
                    }
                }
            }
            return idjsp;
        }

        /// <summary>
        /// 圈选获取监所人员详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public JSPersonDetail GetJSPersonDetailByPoly(string id,string type)
        {
            JSPersonDetail jspd = new JSPersonDetail();
            string url = ConfigHelper.GetValueByKey("webservice.config", "监所人员详细信息") + id + "&lb=" + type;
            //List<JSPerson> alljsp = new List<JSPerson>();
            jspd = JsonConvert.DeserializeObject<List<JSPersonDetail>>(ServiceUtil.GetRemoteXmlStream(url,null))[0];
            jspd.NJSL = jspd.AJ.Count.ToString();
            return jspd;
        }

        /// <summary>
        /// 圈选获取监所详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JSDetail GetJSDetailByPoly(string id)
        {

            OleDbConnectionStringBuilder zzjgDBConnectBuilder = new OleDbConnectionStringBuilder();

            zzjgDBConnectBuilder.Add("Provider", "MSDAORA");
            zzjgDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "zzjgDB"));
            zzjgDBConnectBuilder.Add("Persist Security Info", true);
            zzjgDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBUser"));
            zzjgDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBPasswd"));

            JSDetail info = new JSDetail();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(zzjgDBConnectBuilder.ConnectionString))
                {
                    //缺少照片数据
                    String sql = String.Format("select JSMC,LD,DH,DZ,BZRS from B_ZTK_SP_JSJBXX where JSBH='{0}'", id);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            info.JS_MC = reader[0].ToString();
                        }
                        if (!reader.IsDBNull(1))
                        {
                            info.DWLD_XM = reader[1].ToString();
                        }
                        if (!reader.IsDBNull(2))
                        {
                            info.DWLD_LXDH = reader[2].ToString();
                        }
                        if (!reader.IsDBNull(3))
                        {
                            info.GAJGXZ = reader[3].ToString();
                        }
                        if (!reader.IsDBNull(4))
                        {
                            info.RS = reader[4].ToString();
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return info;

            //string json = ServiceUtil.GetRemoteXmlStream(ConfigHelper.GetValueByKey("webservice.config", "圈选监所详细信息") + id, null);
            //return JsonConvert.DeserializeObject<List<JSDetail>>(json)[0];
        }

        /// <summary>
        /// 一键搜索接口
        /// </summary>
        /// <param name="sjzjdw"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public SearchResult OneKeySearch(string sjzjdw, string text)
        {
            string url = ConfigHelper.GetValueByKey("webservice.config", "一键搜索") + "?sjzgdw=" + sjzjdw + "&text=" + text;
            //string url = "http://10.178.21.53:8080/SmartCity/dzsp/searchDb.ws" + "?sjzgdw=" + sjzjdw + "&text=" + text;
            SearchResult sr = JsonConvert.DeserializeObject<SearchResult>(ServiceUtil.GetRemoteXmlStream(url, null));
            return sr;
        }
    }
}

