using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using Npgsql;
using Beyon.Common;
using Beyon.Domain.Local;

namespace Beyon.WebService.Local
{
    public class KedaVideoManager
    {
        private String connectString;

        public KedaVideoManager()
        {
            connectString = ConfigHelper.GetValueByKey("webservice.config", "pgConnect");
        }

        public List<KedaVideo> GetAllVideos()
        {
            String sql = "select gbid, kdid, kddomainid, name, longitude, latitude, channel from public.tblgbdevicesmall";
            return ExecuteQuerySQL(sql);
        }

        public List<KedaVideo> GetAllVideosByName(string name)
        {
            String sql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from public.tblgbdevicesmall WHERE name like '%{0}%'", name);
            return ExecuteQuerySQL(sql);
        }

        public List<KedaVideo> GetAllVideosByExtent(double minX, double minY, double maxX, double maxY)
        {
            String sql = String.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from public.tblgbdevicesmall WHERE longitude >= {0} AND longitude <= {1} AND latitude >= {2} AND latitude <= {3}", minX, maxX, minY, maxY);
            return ExecuteQuerySQL(sql);
        }

        private List<KedaVideo> ExecuteQuerySQL(String sql)
        {
            List<KedaVideo> result = new List<KedaVideo>();
            try
            {
                using (DbConnection conn = new NpgsqlConnection(this.connectString))
                {
                    
                    conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
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
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error(String.Format("执行本地SQL查询出错: {0}",sql), ex);
                throw ex;
            }

            return result;
        }
    }
}
