using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using Beyon.Common;
using Beyon.Domain.Local;
using Npgsql;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Beyon.WebService.Local
{
    /// <summary>
    /// 警车数据外部服务
    /// </summary>
    public class PoliceCarManager
    {
        #region Fields

        ///// <summary>
        ///// 警车数据库连接字符串构造器
        ///// </summary>
        //private OleDbConnectionStringBuilder policeCarDBConnectBuilder;

        /// <summary>
        /// 视频数据库连接字符串构造器
        /// </summary>
        private String videoDBConnectString;

        private String remoteConnectString;

        private OleDbConnectionStringBuilder policeCarDBConnectBuilder;

        #endregion

        #region Constructors

        /// <summary>
        ///无参构造
        /// </summary>
        public PoliceCarManager()
        {
            //policeCarDBConnectBuilder = new OleDbConnectionStringBuilder();
            //policeCarDBConnectBuilder.Add("Provider", "MSDAORA");
            //policeCarDBConnectBuilder.Add("Data Source", ConfigurationManager.AppSettings["PoliceCarDB"]);
            //policeCarDBConnectBuilder.Add("Persist Security Info", true);
            //policeCarDBConnectBuilder.Add("User ID", ConfigurationManager.AppSettings["PoliceCarDBUser"]);
            //policeCarDBConnectBuilder.Add("Password", ConfigurationManager.AppSettings["PoliceCarDBPasswd"]);

            videoDBConnectString = ConfigHelper.GetValueByKey("webservice.config", "pgConnect");
            remoteConnectString = ConfigHelper.GetValueByKey("webservice.config", "kedaMysqlConnect");

            policeCarDBConnectBuilder = new OleDbConnectionStringBuilder();

            policeCarDBConnectBuilder.Add("Provider", "MSDAORA");
            policeCarDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "gpsDeviceDB"));
            policeCarDBConnectBuilder.Add("Persist Security Info", true);
            policeCarDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "gpsDeviceDBUser"));
            policeCarDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "gpsDeviceDBPasswd"));

        }

        #endregion

        #region Methods


        /// <summary>
        /// 获取警车上的3G摄像头数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public VideoInfoModel Get3GVideoOfPoliceCar(String CarPlateNum)
        {
            VideoInfoModel model = null;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(videoDBConnectString))
                {
                    conn.Open();
                    String sql = "select puid,name,vendor,channel,source from gbid1 where carno = '" +
                                 CarPlateNum + "'";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (
                            !(reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(3) ||
                              reader.IsDBNull(4)))
                        {
                            model = new VideoInfoModel();
                            model.VideoChannel = reader[0].ToString();
                            model.VideoName = reader[1].ToString();
                            model.FactoryName = reader[2].ToString();
                            model.VideoPort = reader[3].ToString();
                            model.VideoSource = Convert.ToInt32(reader[4].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error("日志记录", ex);
            }
            return model;
        }

        /// <summary>
        /// 获取4G图传车视频播放参数
        /// </summary>
        /// <param name="CarPlateNum">车牌号</param>
        /// <returns></returns>
        public List<KedaVideo> Get4GVideoOfPoliceCar(String CarPlateNum) 
        {
            List<KedaVideo> model = new List<KedaVideo>();
            List<String> gpsid = new List<string>();
            try 
            {
                String sql = "select GPSID1,GPSID2,GPSID3,GPSID4,GPSID5 from PGIS_DWXX.T_GPS_INFO_DZSP where LOCTYPE=8 and CARNO='" + CarPlateNum + "'";
                using (OleDbConnection conn = new OleDbConnection(policeCarDBConnectBuilder.ConnectionString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                    {
                        gpsid.Add(reader[0].ToString());
                        gpsid.Add(reader[1].ToString());
                        gpsid.Add(reader[2].ToString());
                        gpsid.Add(reader[3].ToString());
                        gpsid.Add(reader[4].ToString());
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error("日志记录", ex);
            }
            try
            {
                String mysql = string.Format("select gbid, kdid, kddomainid, name, longitude, latitude, channel from tblGbDevice where gbid='{0}' OR gbid='{1}' OR gbid='{2}' OR gbid='{3}' OR gbid='{4}'", gpsid[0], gpsid[1], gpsid[2], gpsid[3], gpsid[4]);
                
                using (DbConnection conn = new MySqlConnection(this.remoteConnectString)) 
                { 
                    conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = mysql;
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

                                model.Add(video);
                            }
                        }

                    }
                }

            }
            catch (Exception ex) 
            {
                LogMgr.Instance.Error("日志记录", ex);
            }
            return model;
        }

        /// <summary>
        /// 获取警车上的340M图传车摄像头设备ID
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public String Get340MDeviceIDOfPoliceCar(String CarPlateNum)
        {
            if (CarPlateNum == null)
                return null;
            String deviceID = null;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(videoDBConnectString))
                {
                    conn.Open();
                    String sql = "select remark from gbid1 where carno='" + CarPlateNum + "'";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            deviceID = reader[0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error("日志记录", ex);
            }
            return deviceID;
        }

        #endregion

    }
}
