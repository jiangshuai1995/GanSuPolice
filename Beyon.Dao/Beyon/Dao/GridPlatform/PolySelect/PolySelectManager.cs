namespace Beyon.Dao.GridPlatform.PolySelect
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using Npgsql;
    using GeoAPI;
    using GeoAPI.Geometries;
    using Beyon.Common;
    using Beyon.Domain.PolySelect;
    using Beyon.Domain.GridSelect;
    using Beyon.Domain.GridSearch;

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
            throw new NotImplementedException();
            //long num;
            //long num2;
            //long num3;
            //string url = ConfigHelper.GetValueByKey("webservice.config", "圈选案件统计") + "?geom=" + polygon;
            //if (mapLevel.Equals("派出所") || mapLevel.Equals("责任区"))
            //{
            //    url = url + "&queryType=accurate";
            //}
            //else
            //{
            //    url = url + "&queryType=outline";
            //}
            //JObject obj2 = JObject.Parse(ServiceUtil.GetRemoteXmlStream(url, null));
            //long.TryParse(obj2["xsla"].ToString(), out num3);
            //long.TryParse(obj2["zala"].ToString(), out num2);
            //long.TryParse(obj2["jj"].ToString(), out num);
            //Dictionary<string, long> dictionary = new Dictionary<string, long>();
            //dictionary.Add("接处警", num);
            //dictionary.Add("治安案件", num2);
            //dictionary.Add("刑事案件", num3);
            //return dictionary;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取场所统计
        /// </summary>
        /// <param name="csType">场所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public long GetCSCountByPoly(string csType, string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using(var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using(var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.csgl WHERE type = '{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'", csType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    return (long)command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 圈选获取场所列表
        /// </summary>
        /// <param name="csType">场所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyCS> GetCSListByPoly(string csType, string polygon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取场所分页列表
        /// </summary>
        /// <param name="csType">场所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyCS> GetCSPageListByPoly(string csType, string polygon, int pageNum, int pageSize)
        {
            throw new NotImplementedException();
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

        /// <summary>
        /// 圈选获取监所列表
        /// </summary>
        /// <param name="jsType">监所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyJS> GetJSListByPoly(string jsType, List<Point> polygon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsType"></param>
        /// <returns></returns>
        public List<PolyJS> GetJSListByProvince(string jsType)
        {
            throw new NotImplementedException();
        }

        public List<RenKou> GetCZRenKouListByPoly(string mapLevel, string polygon)
        {
            throw new NotImplementedException();
        }

        public PolySummary GetFQInfoByPoly(string mapLevel, string polygon)
        {
            throw new NotImplementedException();
        }

        public long GetFWCountByPoly(string mapLevel, string polygon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取房屋列表信息
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public PolyBuilding GetFWListByPoly(string mapLevel, string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            PolyBuilding result = new PolyBuilding();
            result.fwList = new List<Building>();

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.fwgl WHERE \"JD\" >= '{0}' AND \"JD\" <= '{1}' AND \"WD\" >= '{2}' AND \"WD\" <= '{3}'", minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using(var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Building building = new Building();
                            building.OBJECTID = reader[0].ToString();
                            building.JD = reader[1].ToString();
                            building.WD = reader[2].ToString();
                            building.JZWMC = reader[3].ToString();
                            building.JZWDM = reader[4].ToString();
                            result.fwList.Add(building);
                            result.fw++;
                        }
                        
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 圈选获取分页房屋列表
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public PolyBuilding GetFWPageListByPoly(string mapLevel, string polygon, int pageNum, int pageSize)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            int offset = (pageNum - 1) * pageSize;
            int limit = pageSize;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            PolyBuilding result = new PolyBuilding();
            result.fwList = new List<Building>();

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.fwgl WHERE \"JD\" >= '{0}' AND \"JD\" <= '{1}' AND \"WD\" >= '{2}' AND \"WD\" <= '{3}' limit {4} offset {5}", minX, maxX, minY, maxY, limit, offset);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Building building = new Building();
                            building.OBJECTID = reader[0].ToString();
                            building.JD = reader[1].ToString();
                            building.WD = reader[2].ToString();
                            building.JZWMC = reader[3].ToString();
                            building.JZWDM = reader[4].ToString();
                            result.fwList.Add(building);
                            result.fw++;
                        }

                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 圈选获取派出所详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PcsDetail GetPcsDetailByPoly(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取派出所责任区统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetPcsZrqCountByPoly(string mapLevel, string polygon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取派出所责任区列表
        /// </summary>
        /// <param name="gridType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<GridInfo> GetPcsZrqListByPoly(string gridType, string polygon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选 派出所责任区 分页列表
        /// </summary>
        /// <param name="gridType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<GridInfo> GetPcsZrqPageListByPoly(string gridType, string polygon, int pageNum, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取警察统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public long GetPoliceManCountByPoly(string mapLevel, string polygon)
        {
            throw new NotImplementedException();
        }

        public List<PoliceMan> GetPoliceManListByPoly(string polygon)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 临时版 获取警车列表
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<PoliceCar> GetPoliceCarListByPoly(List<Point> polygon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取人口统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetRenKouCountByPoly(string mapLevel, string polygon)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取视频监控统计值
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetSpjkCountByPoly(string polygon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取视频监控列表
        /// </summary>
        /// <param name="videoType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<Beyon.Domain.PolySelect.Video> GetSpjkListByPoly(string videoType, string polygon)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取责任区详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ZrqDetail GetZrqDetailByPoly(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取监所人员列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<JSPerson> GetJSPersonListByPoly(string type,string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取监所人员详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public JSPersonDetail GetJSPersonDetailByPoly(string id,string type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 圈选获取监所详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JSDetail GetJSDetailByPoly(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 一键搜索接口
        /// </summary>
        /// <param name="sjzjdw"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public SearchResult OneKeySearch(string sjzjdw, string text)
        {
            throw new NotImplementedException();
        }


        #region 内部实现代码
        private IGeometry GeomFromText(String Wkt)
        {
            NetTopologySuite.IO.WKTReader reader = new NetTopologySuite.IO.WKTReader();
            return reader.Read(Wkt);
        }
        #endregion
    }
}

