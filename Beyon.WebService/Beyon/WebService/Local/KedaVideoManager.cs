using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using Npgsql;
using MySql.Data.MySqlClient;
using Beyon.Common;
using Beyon.Domain.Local;

namespace Beyon.WebService.Local
{
    public class KedaVideoManager
    {
        private String remoteConnectString;
        private String localConnectString;
        private bool m_useLocal = false;
        private int m_tryNum = 1;       //MySQL强制连接次数

        public KedaVideoManager()
        {
            try
            {
                remoteConnectString = ConfigHelper.GetValueByKey("webservice.config", "kedaMysqlConnect");
            }
            catch { }

            try
            {
                localConnectString = ConfigHelper.GetValueByKey("webservice.config", "pgConnect");
            }
            catch { }

            try
            {
                m_tryNum = Int32.Parse(ConfigHelper.GetValueByKey("webservice.config", "视频远程库重复连接次数"));
            }
            catch { }
        }

        /// <summary>
        /// 获取所有视频接口
        /// </summary>
        /// <returns></returns>
        public List<KedaVideo> GetAllVideos()
        {
            String pgsql = "select gbid, kdid, kddomainid, name, longitude, latitude, channel from public.tblgbdevice";
            String mysql = "select gbid, kdid, kddomainid, name, longitude, latitude, channel from tblGbDevice";
            return ExecuteQuerySQL(mysql, pgsql);
        }

        /// <summary>
        /// 获取所有固定摄像头信息
        /// </summary>
        /// <returns></returns>
        public List<KedaVideo> GetAllFixedVides()
        {
            return GetVideosOfRect(80, 20, 180, 90);
        }

        /// <summary>
        /// 获取某一区域内所有固定摄像头
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<KedaVideo> GetVideosOfRect(double longitude_left, double latitude_left, double longitude_right, double latitude_right)
        {
            String pgsql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from public.tblgbdevice WHERE longitude >= {0} AND longitude <= {1} AND latitude >= {2} AND latitude <= {3}", longitude_left, longitude_right, latitude_left, latitude_right);
            String mysql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from tblGbDevice WHERE longitude >= {0} AND longitude <= {1} AND latitude >= {2} AND latitude <= {3}", longitude_left, longitude_right, latitude_left, latitude_right);
            return ExecuteQuerySQL(mysql, pgsql);
        }

        /// <summary>
        /// 获取监所摄像头集合（依据名称区别看守所、戒毒所与拘留所，依据监所ID前六位匹配civilcode前六位）
        /// （1）监所ID后九位编码规则，共9位，前面6位表示行政区域；第七位为1，预留；第八位为监所种类，1表示看守所，2表示拘留所，3表示戒毒所，4表示收容教育所；第九位表示同一行政区域的同类型监所的第几个,只有兰州市（前六位是620101）有。如620101111为兰州市第一看守所；620101112位兰州第二看守所。
        /// </summary>
        /// <param name="prisonID">监所Id</param>
        /// <returns></returns>
        public List<KedaVideo> GetVideoOfPrison(String prisonID)
        {
            String civil_code = prisonID.Substring(0, 6);
            String areaType = prisonID.Substring(7, 1);
            String sql_suffix = null;
            string sql_suffix_other = null;
            switch (areaType)
            {
                case "1":
                    sql_suffix = "看守所";
                    break;
                case "2":
                    sql_suffix = "拘留所";
                    break;
                case "3":
                    sql_suffix = "戒毒所";
                    break;
                case "4":
                    sql_suffix = "收容教育所";
                    break;
                default:
                    break;
            }

            ///针对兰州市有多个看守所特别处理
            if (civil_code == "620101")
            {
                String number = prisonID.Substring(8, 1);
                switch (number)
                {
                    case "1":
                        sql_suffix_other = "第一";
                        break;
                    case "2":
                        sql_suffix_other = "第二";
                        break;
                    case "3":
                        sql_suffix_other = "第三";
                        break;
                    case "4":
                        sql_suffix_other = "第四";
                        break;
                    case "5":
                        sql_suffix_other = "第五";
                        break;
                    case "6":
                        sql_suffix_other = "第六";
                        break;
                    case "7":
                        sql_suffix_other = "第七";
                        break;
                    case "8":
                        sql_suffix_other = "第八";
                        break;
                    case "9":
                        sql_suffix_other = "第九";
                        break;
                }
            }

            if (!String.IsNullOrEmpty(sql_suffix_other) && !string.IsNullOrEmpty(sql_suffix))
            {
                sql_suffix = sql_suffix_other + sql_suffix;
            }

            String pgsql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from public.tblgbdevice WHERE substr(civilcode,1,6) = '{0}' AND name LIKE '%{1}%'", civil_code, sql_suffix);
            String mysql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from tblGbDevice WHERE substr(civilcode,1,6) = '{0}' AND name LIKE '%{1}%'", civil_code, sql_suffix);

            return ExecuteQuerySQL(mysql, pgsql);
        }


        public List<KedaVideo> GetAllVideosByName(string name)
        {
            String pgsql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from public.tblgbdevice WHERE name like '%{0}%'", name);
            String mysql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from tblGbDevice WHERE name like '%{0}%'", name);
            return ExecuteQuerySQL(mysql, pgsql);
        }

        private bool ExecuteRemoteQuerySQL(String msqlSql, ref List<KedaVideo> result)
        {
            try
            {
                using (DbConnection conn = new MySqlConnection(this.remoteConnectString))
                {
                    conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = msqlSql;
                        using (DbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KedaVideo video = new KedaVideo();

                                if (!reader.IsDBNull(0))
                                {
                                    video.gbid = reader[0].ToString();
                                }

                                if (!reader.IsDBNull(1))
                                {
                                    video.kdid = reader[1].ToString();
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    video.kddomainid = reader[2].ToString();
                                }

                                if (!reader.IsDBNull(3))
                                {
                                    video.name = reader[3].ToString();
                                }

                                if (!reader.IsDBNull(4))
                                {
                                    double longitude;
                                    if (Double.TryParse(reader[4].ToString(), out longitude))
                                        video.longitude = longitude;
                                }

                                if (!reader.IsDBNull(5))
                                {
                                    double latitude;
                                    if (Double.TryParse(reader[5].ToString(), out latitude))
                                        video.latitude = latitude;
                                }

                                if (!reader.IsDBNull(6))
                                {
                                    video.channel = reader[6].ToString();
                                }

                                result.Add(video);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error(String.Format("执行远程SQL查询出错: {0}", msqlSql), ex);
                return false;
            }
        }

        private List<KedaVideo> ExecuteQuerySQL(String msqlSql, String pgSql)
        {
            List<KedaVideo> result = new List<KedaVideo>();

            if (!String.IsNullOrEmpty(this.remoteConnectString) && !m_useLocal)
            {
                int mRescle = m_tryNum;
                while(mRescle > 0)
                {
                    if(ExecuteRemoteQuerySQL(msqlSql, ref result))
                    {
                        return result;
                    }
                    else
                    {
                        --mRescle;
                    }
                }

                m_useLocal = false;
            }

            try
            {
                //使用本地数据库
                using (DbConnection conn = new NpgsqlConnection(this.localConnectString))
                {
                    conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = pgSql;
                        using (DbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KedaVideo video = new KedaVideo();

                                if (!reader.IsDBNull(0))
                                {
                                    video.gbid = reader[0].ToString();
                                }

                                if (!reader.IsDBNull(1))
                                {
                                    video.kdid = reader[1].ToString();
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    video.kddomainid = reader[2].ToString();
                                }

                                if (!reader.IsDBNull(3))
                                {
                                    video.name = reader[3].ToString();
                                }

                                if (!reader.IsDBNull(4))
                                {
                                    double longitude;
                                    if (Double.TryParse(reader[4].ToString(), out longitude))
                                        video.longitude = longitude;
                                }

                                if (!reader.IsDBNull(5))
                                {
                                    double latitude;
                                    if (Double.TryParse(reader[5].ToString(), out latitude))
                                        video.latitude = latitude;
                                }

                                if (!reader.IsDBNull(6))
                                {
                                    video.channel = reader[6].ToString();
                                }

                                result.Add(video);
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error(String.Format("执行本地SQL查询出错: {0}", pgSql), ex);
                throw ex;
            }
        }
    }
}
