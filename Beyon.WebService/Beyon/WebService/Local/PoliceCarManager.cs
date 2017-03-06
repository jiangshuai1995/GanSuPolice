using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using Beyon.Common;
using Beyon.Domain.Local;
using Npgsql;

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
