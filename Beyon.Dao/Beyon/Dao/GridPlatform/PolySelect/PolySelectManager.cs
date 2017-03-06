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
    using System.Text;

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
        public Dictionary<string, long> GetAjCountByPoly(string mapLevel,string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.ajgl WHERE type = 'jj' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num1 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.ajgl WHERE type = 'zala' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num2 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.ajgl WHERE type = 'xsla' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num3 = (long)command.ExecuteScalar();
                    Dictionary<string, long> dictionary = new Dictionary<string, long>();
                    dictionary.Add("接处警", num1);
                    dictionary.Add("治安案件", num2);
                    dictionary.Add("刑事案件", num3);
                    return dictionary;
                }
            }
        }

        /// <summary>
        /// 圈选获取案件列表
        /// </summary>
        /// <param name="ajType">案件类型</param>
        /// <param name="mapLevel">地图级别</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<AnJian> GetAnJianListByPoly(string ajType,string mapLevel,string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            List<AnJian> ajlist = new List<AnJian>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.ajgl WHERE type = '{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'",ajType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnJian aj = new AnJian();
                            aj.AJMC = reader[0].ToString();
                            aj.AJZT = reader[1].ToString();
                            aj.ID = reader[2].ToString();
                            aj.BJLX = reader[6].ToString();
                            aj.JYAQ = reader[7].ToString();
                            ajlist.Add(aj);
                        }
                    }
                }
            }
            return ajlist;
        }

        /// <summary>
        /// 圈选获取案件分页列表
        /// </summary>
        /// <param name="ajType">案件类型</param>
        /// <param name="mapLevel">地图级别</param>
        /// <param name="polygon">圈选范围</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">页码大小</param>
        /// <returns></returns>
        public List<AnJian> GetAnJianPageListByPoly(string ajType, string mapLevel,string polygon, int pageNum, int pageSize)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;
            if (ajType == "接处警")
                ajType = "jj";
            if (ajType == "治安案件")
                ajType = "zala";
            if (ajType == "刑事案件")
                ajType = "xsla";

            int offset = (pageNum - 1) * pageSize;
            int limit = pageSize;

            List<AnJian> ajlist = new List<AnJian>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.ajgl WHERE type = '{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'", ajType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnJian aj = new AnJian();
                            aj.AJMC = reader[0].ToString();
                            aj.AJZT = reader[1].ToString();
                            aj.ID = reader[2].ToString();
                            aj.BJLX = reader[6].ToString();
                            aj.JYAQ = reader[7].ToString();
                            aj.JD = reader[5].ToString();
                            aj.WD = reader[3].ToString();

                            ajlist.Add(aj);
                        }
                    }
                }
            }
            return ajlist;
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
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;
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
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            List<PolyCS> cslist = new List<PolyCS>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.csgl WHERE type='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'",csType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PolyCS cs = new PolyCS();
                            cs.OBJECTID = reader[0].ToString();
                            cs.MC = reader[1].ToString();
                            cs.JD = reader[2].ToString();
                            cs.WD = reader[3].ToString();
                            cs.ID = reader[5].ToString();
                            cslist.Add(cs);
                        }
                    }
                }
            }
            return cslist;
        }

        /// <summary>
        /// 获取场所分页列表
        /// </summary>
        /// <param name="csType">场所类型</param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyCS> GetCSPageListByPoly(string csType, string polygon, int pageNum, int pageSize)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;
            switch (csType) 
            { 
                case "娱乐场所":
                    csType = "CS_YLCS_PT";
                    break;
                case "旅店":
                    csType = "CS_ZSFW_PT";
                    break;
                case "网吧":
                    csType = "CS_HLWSWFW_PT";
                    break;
                case"医院":
                    csType = "DWXX_YLWS_PT";
                    break;
                case"学校":
                    csType = "DWXX_JYJG_PT";
                    break;
                case"金融证券":
                    csType = "DWXX_JRZQ_PT";
                    break;
                case "危险品存放处":
                    csType = "DWXX_WXPCFDDW_PT";
                    break;

                case "党政机关":
                    csType = "DWXX_DXJG_PT";
                    break;
                case "寺观教堂":
                    csType = "CS_ZJCS_PT";
                    break;
                case "公共活动场所":
                    csType = "CS_GGHDCS_PT";
                    break;
                case "商贸市场":
                    csType = "CS_SMCS_PT";
                    break;
                case "交通场所":
                    csType = "CS_JTCS_PT";
                    break;
                case "体育场所":
                    csType = "CS_TYCS_PT";
                    break;
                case "旅游场所":
                    csType = "CS_LYCS_PT";
                    break;
                case "居民服务场所":
                    csType = "CS_JMFWCS_PT";
                    break;
                case "文化场所":
                    csType = "CS_WHCS_PT";
                    break;


            }
            
            int offset = (pageNum - 1) * pageSize;
            int limit = pageSize;

            List<PolyCS> cslist = new List<PolyCS>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.csgl WHERE type='{0}'AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}' offset {5} limit {6}", csType, minX, maxX, minY, maxY, offset, limit);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PolyCS cs = new PolyCS();
                            cs.OBJECTID = reader[0].ToString();
                            cs.MC = reader[1].ToString();
                            cs.JD = reader[2].ToString();
                            cs.WD = reader[3].ToString();
                            cs.ID = reader[0].ToString();
                            cslist.Add(cs);
                        }
                    }
                }
            }
            return cslist;

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
        /// <param name="jstype"></param>
        /// <param name="polygon">圈选范围</param>
        /// <returns></returns>
        public List<PolyJS> GetJSListByPoly(string jstype, List<Point> polygon)
        {
            string str = CoordinateTransfer(polygon);
            IGeometry geometry = GeomFromText(str);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;
            
            
            List<PolyJS> jslist = new List<PolyJS>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.js WHERE  jstype='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'",jstype, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PolyJS js=new PolyJS();
                            js.JS_CODE = reader[4].ToString();
                            js.JS_MC = reader[3].ToString();
                            js.GAJGJD = reader[1].ToString();
                            js.GAJGWD = reader[3].ToString();
                            js.GAJGDM = reader[9].ToString();
                            js.GAJGJC = reader[10].ToString();
                            jslist.Add(js);
                        }
                    }
                }
            }
            return jslist;
        }

        /// <summary>
        /// 圈选获取监所人员列表   点选监所列表，根据监所ID查询
        /// </summary>
        /// <param name="type">监所人员类型</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<JSPerson> GetJSPersonListByPoly(string type, string id)
        {
            List<JSPerson> jsplist = new List<JSPerson>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.jsry  WHERE type='{0}' AND jsid='{1}' ",type,id);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JSPerson jsp = new JSPerson();
                            jsp.JBXXBH = reader[0].ToString();
                            jsp.XM = reader[1].ToString();
                            jsp.ZJHM = reader[2].ToString();
                            jsplist.Add(jsp);
                        }
                    }
                }
            }
            return jsplist;
        }

        /// <summary>
        /// 圈选获取监所人员详细信息 点选人员列表，根据人员ID查询
        /// </summary>
        /// <param name="type">监所人员类型</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public JSPersonDetail GetJSPersonDetailByPoly(string type,string id)
        {
            JSPersonDetail jspd = new JSPersonDetail();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.jsry WHERE type='{0}' AND bh ='{1}' ",type,id);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jspd.XM = reader[0].ToString();
                            jspd.ZP = reader[3].ToString();
                        }
                    }
                }
            }
            return jspd;
        }

        /// <summary>
        /// 圈选获取监所详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JSDetail GetJSDetailByPoly(string id)
        {
            JSDetail jsdetail = new  JSDetail ();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.js WHERE jsid ='{0}' ", id);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jsdetail.JS_MC = reader[3].ToString();
                            jsdetail.RS = reader[6].ToString();
                            jsdetail.GAJGXZ = reader[5].ToString();
                            jsdetail.zp = reader[7].ToString();
                        }
                    }
                }
            }
            return jsdetail;
        }

        ///<summary>
        ///按类型获取监所信息
        ///<param name="jstype">监所类型</param>
        /// </summary>
        /// <returns></returns>
        public List<PolyJS> GetJSListByProvince(string jstype)
        {
            List<PolyJS> jslist = new List<PolyJS>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.js WHERE  jstype='{0}'", jstype);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PolyJS js = new PolyJS();
                            js.JS_CODE = reader[4].ToString();
                            js.JS_MC = reader[3].ToString();
                            js.GAJGJD = reader[1].ToString();
                            js.GAJGWD = reader[3].ToString();
                            js.GAJGDM = reader[9].ToString();
                            js.GAJGJC = reader[10].ToString();
                            jslist.Add(js);
                        }
                    }
                }
            }
            return jslist;
        }

        /// <summary>
        /// 圈选获取常驻人口列表
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<RenKou> GetCZRenKouListByPoly( string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            List<RenKou> rklist = new List<RenKou>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.rkgl WHERE type='czrk' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'",  minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RenKou rk = new RenKou();
                            rk.XM = reader[1].ToString();
                            rk.XB = reader[2].ToString();
                            rk.SFZH = reader[0].ToString();
                            rklist.Add(rk);
                        }
                    }
                }
            }
            return rklist;
            
        }

        /// <summary>
        /// 圈选进行概要信息查询
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public PolySummary GetFQInfoByPoly( string mapLevel,string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            PolySummary ps = new PolySummary();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.ajgl  WHERE type='jj' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    ps.jj = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.rkgl  WHERE type='czrk' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    ps.czrk = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.fwgl WHERE  \"JD\" >= '{0}' AND \"JD\" <= '{1}' AND \"WD\" >= '{2}' AND \"WD\" <= '{3}'", minX, maxX, minY, maxY);
                    ps.fw = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.rkgl  WHERE   jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    ps.rk = (long)command.ExecuteScalar();
                }
                return ps;
            } 
        }

        ///<summary>
        ///圈选获取房屋统计
        /// </summary>
        ///<param name="maplevel">地图级别</param>
        ///<param name="polygon">圈选范围</param>
        public long GetFWCountByPoly(string maplevel,string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.fwgl WHERE  \"JD\" >= '{0}' AND \"JD\" <= '{1}' AND \"WD\" >= '{2}' AND \"WD\" <= '{3}'", minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    return (long)command.ExecuteScalar();
                }
            }
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
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

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
                            building.JZWDM = reader[0].ToString();
                            result.fwList.Add(building);
                            result.fw++;
                        }
                    }
                }
            }
            return result;
        }
       
        /// <summary>
        /// 圈选获取派出所责任区统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetPcsZrqCountByPoly(string mapLevel,string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.zrgl WHERE type = 'pcs' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num1 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.zrgl WHERE type = 'zrq' AND  jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num2 = (long)command.ExecuteScalar();
                    Dictionary<string, long> dictionary = new Dictionary<string, long>();
                    dictionary.Add("派出所", num1);
                    dictionary.Add("责任区", num2);
                    return dictionary;
                }
            }
        }

        /// <summary>
        /// 圈选获取派出所责任区列表
        /// </summary>
        /// <param name="gridType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<GridInfo> GetPcsZrqListByPoly(string gridType, string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            List<GridInfo> gridlist = new List<GridInfo>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.zrgl WHERE type='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'", gridType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GridInfo gr = new GridInfo();
                            gr.MC= reader[1].ToString();
                            gr.JD= reader[2].ToString();
                            gr.WD = reader[3].ToString();
                            gr.GTYPE = reader[4].ToString();
                            gr.ZZJGDM = reader[5].ToString();
                            gridlist.Add(gr);

                        }
                    }
                }
            }
            return gridlist;
        }

        /// <summary>
        /// 圈选 派出所责任区 分页列表
        /// </summary>
        /// <param name="gridType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<GridInfo> GetPcsZrqPageListByPoly(string gridType, string polygon, int pageNum, int pageSize)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            int offset = (pageNum - 1) * pageSize;
            int limit = pageSize;

            List<GridInfo> gridlist = new List<GridInfo>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.zrgl WHERE type='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'", gridType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GridInfo gr = new GridInfo();
                            gr.MC = reader[1].ToString();
                            gr.JD = reader[2].ToString();
                            gr.WD = reader[3].ToString();
                            gr.GTYPE = reader[4].ToString();
                            gr.ZZJGDM = reader[5].ToString();
                            gridlist.Add(gr);
                        }
                    }
                }
            }
            return gridlist;
        }

        /// <summary>
        /// 点选获取派出所详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PcsDetail GetPcsDetailByPoly(string id)
        {
            PcsDetail pcsd = new PcsDetail();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.pcsdetail WHERE ID='{0}'",id);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pcsd.ID = reader[0].ToString();
                            pcsd.MC = reader[1].ToString();
                            pcsd.FZR = reader[2].ToString();
                            pcsd.JL = long.Parse(reader[3].ToString());
                            pcsd.JJ = long.Parse(reader[4].ToString());
                            pcsd.CJ = long.Parse(reader[5].ToString());
                        }
                    }
                }
            }
            return pcsd;
        }

        /// <summary>
        /// 点选获取责任区详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ZrqDetail GetZrqDetailByPoly(string id)
        {
            ZrqDetail zrqd = new ZrqDetail();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.zrqdetail WHERE ID='{0}'", id);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            zrqd.ID = reader[0].ToString();
                            zrqd.MC = reader[1].ToString();
                            zrqd.FZR = reader[2].ToString();
                            zrqd.ZDR = long.Parse(reader[3].ToString());
                            zrqd.DH = reader[4].ToString();
                            zrqd.CZRK = long.Parse(reader[5].ToString());
                            zrqd.ZDRDQB = long.Parse(reader[6].ToString());
                        }
                    }
                }
            }
            return zrqd;
        }

        /// <summary>
        /// 圈选获取警员统计值
        /// </summary>
        /// <param name="mapLevel"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public long GetPoliceManCountByPoly(string mapLevel,string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.jygl2 WHERE  jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    return (long)command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 圈选获取警员列表
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<PoliceMan> GetPoliceManListByPoly(string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            List<PoliceMan> policelist = new List<PoliceMan>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.jygl2 WHERE jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'",  minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceMan pm = new PoliceMan();
                            pm.XM = reader[0].ToString();  //姓名
                            pm.ID = reader[1].ToString();  //身份证号码
                            pm.JH = reader[12].ToString(); //警号
                            pm.DW = reader[10].ToString(); //单位
                            policelist.Add(pm);
                        }
                    }
                }
            }
            return policelist;
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
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            int offset = (pageNum - 1) * pageSize;
            int limit = pageSize;

            List<PoliceMan> policelist = new List<PoliceMan>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.jygl2 WHERE jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceMan pm = new PoliceMan();
                            pm.XM = reader[0].ToString();  //姓名
                            pm.ID = reader[1].ToString();  //身份证号码
                            pm.JH = reader[12].ToString(); //警号
                            pm.DW = reader[10].ToString(); //单位
                            policelist.Add(pm);
                        }
                    }
                }
            }
            return policelist;
        }

        /// <summary>
        /// 临时版 获取警车列表
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<PoliceCar> GetPoliceCarListByPoly(List<Point> polygon)
        {
            string str = CoordinateTransfer(polygon);
            IGeometry geometry = GeomFromText(str);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;
            List<PoliceCar> carlist = new List<PoliceCar>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.jcgl WHERE jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceCar car = new PoliceCar();
                            car.GPSID = reader[0].ToString();  
                            car.ORGID = reader[1].ToString();  
                            car.CALLNO = reader[2].ToString(); 
                            car.CARNO = reader[4].ToString(); 
                            carlist.Add(car);
                        }
                    }
                }
            }
            return carlist;
        }

        /// <summary>
        /// 圈选获取人口统计值
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetRenKouCountByPoly(string maplevel, string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed||connection.State==System.Data.ConnectionState.Broken)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.rkgl WHERE type = 'czrk' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num1 =(long) command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.rkgl WHERE type = 'zdrk' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num2 = (long)command.ExecuteScalar();
                    Dictionary<string, long> dictionary = new Dictionary<string, long>();
                    dictionary.Add("常住人口", num1);
                    dictionary.Add("重点人口", num2);
                    return dictionary;
                }
            }
        }

        /// <summary>
        /// 圈选获取人口列表
        /// </summary>
        /// <param name="rkType">人口类型</param>
        /// <param name="mapLevel"></param>
        /// <param name="polygon">圈选区域</param>
        /// <returns></returns>
        public List<RenKou> GetRenKouListByPoly(string rkType,string mapLevel,string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            List<RenKou> rklist = new List<RenKou>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.rkgl WHERE  type='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'",rkType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RenKou rk = new RenKou();
                            rk.XM = reader[1].ToString();  //姓名
                            rk.XB = reader[2].ToString();  //性别
                            rk.SFZH = reader[0].ToString(); //身份证号
                            rklist.Add(rk);
                        }
                    }
                }
            }
            return rklist;
        }

        /// <summary>
        /// 圈选获取分页人口列表
        /// </summary>
        /// <param name="rkType">人口类型</param>
        /// <param name="mapLevel"></param>
        /// <param name="polygon">圈选区域</param>
        /// <returns>分页列表</returns>
        public List<RenKou> GetRenKouPageListByPoly(string rkType,string mapLevel,string polygon, int pageNum, int pageSize)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;
            switch (rkType) 
            { 
                case "常住人口":
                    rkType="czrk";
                    break;
                case "重点人口":
                    rkType="zdrk";
                    break;
            }

            int offset = (pageNum - 1) * pageSize;
            int limit = pageSize;

            List<RenKou> rklist = new List<RenKou>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.rkgl WHERE  type='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'  offset {5} limit {6}  ", rkType, minX, maxX, minY, maxY,offset,limit);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RenKou rk = new RenKou();
                            rk.XM = reader[1].ToString();  //姓名
                            rk.XB = reader[2].ToString();  //性别
                            rk.SFZH = reader[0].ToString(); //身份证号
                            rklist.Add(rk);
                        }
                    }
                }
            }
            return rklist;
        }

        /// <summary>
        /// 圈选获取视频监控统计值
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public Dictionary<string, long> GetSpjkCountByPoly(string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed || connection.State == System.Data.ConnectionState.Broken)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'ggcs'AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num1 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'bazx' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num2 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'dljt' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num3 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'nbsp' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num4 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'ckdw' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num5 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'jgcs' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num6 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'zdcs' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num7 = (long)command.ExecuteScalar();
                    command.CommandText = String.Format("SELECT count(*) FROM dbo.spgl WHERE type = 'ydsp' AND jd >= '{0}' AND jd <= '{1}' AND wd >= '{2}' AND wd <= '{3}'", minX, maxX, minY, maxY);
                    long num8 = (long)command.ExecuteScalar();
                    Dictionary<string, long> dictionary = new Dictionary<string, long>();
                    dictionary.Add("公共场所", num1);
                    dictionary.Add("办案中心", num2);
                    dictionary.Add("道路交通", num3);
                    dictionary.Add("内部视频", num4);
                    dictionary.Add("窗口单位", num5);
                    dictionary.Add("监管场所", num6);
                    dictionary.Add("重点场所", num7);
                    dictionary.Add("移动视频", num8);
                    return dictionary;
                }
            }
        }

        /// <summary>
        /// 圈选获取视频监控列表
        /// </summary>
        /// <param name="videoType"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public List<Beyon.Domain.PolySelect.Video> GetSpjkListByPoly(string videoType, string polygon)
        {
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;

            List<Beyon.Domain.PolySelect.Video> splist = new List<Beyon.Domain.PolySelect.Video>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.spgl WHERE  type='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'", videoType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Beyon.Domain.PolySelect.Video sp = new Beyon.Domain.PolySelect.Video();
                            sp.FZMC = reader[0].ToString();  
                            sp.WD = reader[1].ToString();  
                            sp.JD = reader[2].ToString();
                            sp.ID = reader[3].ToString();
                            sp.MC = reader[4].ToString();//案件管理
                            splist.Add(sp);
                        }
                    }
                }
            }
            return splist;
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
            IGeometry geometry = GeomFromText(polygon);
            double minX = geometry.EnvelopeInternal.MinX;
            double maxX = geometry.EnvelopeInternal.MaxX;
            double minY = geometry.EnvelopeInternal.MinY;
            double maxY = geometry.EnvelopeInternal.MaxY;
            //因为世界地图边界问题
            if (minX < 100)
                minX = 100;
            if (minY < 10)
                minY = 10;
            if (maxY >= 100)
                maxY = 90;
            if (maxX < 100)
                maxX = 100;

            switch (videoType) 
            {
                case "公共场所":
                    videoType = "ggcs";
                    break;
                case "办案中心":
                    videoType = "bazx";
                    break;
                case "道路交通":
                    videoType = "dljt";
                    break;
                case "内部视频":
                    videoType = "nbsp";
                    break;
                case "窗口单位":
                    videoType = "ckdw";
                    break;
                case "监管场所":
                    videoType = "jgcs";
                    break;
                case "重点场所":
                    videoType = "zdcs";
                    break;
                case "移动视频":
                    videoType = "ydsp";
                    break;
            }

            int offset = (pageNum - 1) * pageSize;
            int limit = pageSize;

            List<Beyon.Domain.PolySelect.Video> splist = new List<Beyon.Domain.PolySelect.Video>();

            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

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
                    command.CommandText = String.Format("SELECT * FROM dbo.spgl WHERE  type='{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}' offset {5} limit {6} ", videoType, minX, maxX, minY, maxY,offset,limit);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Beyon.Domain.PolySelect.Video sp = new Beyon.Domain.PolySelect.Video();
                            sp.FZMC = reader[0].ToString();
                            sp.WD = reader[1].ToString();
                            sp.JD = reader[2].ToString();
                            sp.ID = reader[3].ToString();
                            sp.MC = reader[4].ToString();//案件管理
                            splist.Add(sp);
                        }
                    }
                }
            }
            return splist;
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

        private string CoordinateTransfer(List<Point> points)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("POLYGON((");
            foreach (Point point in points)
            {
                builder.Append(point.X.ToString()+" "+point.Y.ToString());
                builder.Append(",");
            }
            builder.Append(points[0].X.ToString()+" "+points[0].Y.ToString());
            //builder.Remove(builder.Length - 1, 1);
            builder.Append("))");
            return builder.ToString();
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

