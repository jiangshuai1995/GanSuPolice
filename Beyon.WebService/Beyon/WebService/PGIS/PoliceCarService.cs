using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using Beyon.Common;
using Beyon.Domain.PGIS;

namespace Beyon.WebService.PGIS.Services
{
    /// <summary>
    /// 警车数据外部服务
    /// </summary>
    public class PoliceCarService
    {
        #region Fields

        /// <summary>
        /// 警车数据库连接字符串构造器
        /// </summary>
        private OleDbConnectionStringBuilder policeCarDBConnectBuilder;

        /// <summary>
        /// 视频数据库连接字符串构造器
        /// </summary>
        private OleDbConnectionStringBuilder videoDBConnectBuilder;

        #endregion

        #region Constructors

        /// <summary>
        ///无参构造
        /// </summary>
        public PoliceCarService()
        {
            //policeCarDBConnectBuilder = new OleDbConnectionStringBuilder();
            //policeCarDBConnectBuilder.Add("Provider", "MSDAORA");
            //policeCarDBConnectBuilder.Add("Data Source", ConfigurationManager.AppSettings["PoliceCarDB"]);
            //policeCarDBConnectBuilder.Add("Persist Security Info", true);
            //policeCarDBConnectBuilder.Add("User ID", ConfigurationManager.AppSettings["PoliceCarDBUser"]);
            //policeCarDBConnectBuilder.Add("Password", ConfigurationManager.AppSettings["PoliceCarDBPasswd"]);

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
        /// 获取所有警车信息
        /// </summary>
        /// <returns></returns>
        public List<PoliceInfo> GetAllPoliceCarInfo()
        {
            List<PoliceInfo> list = new List<PoliceInfo>();
            String sql =
                        "select GPSID,LOCTYPE,POLICETYPEID,UIM,CARNO,CZTID,FZR,LXFS,SSSJMC,SSFJMC,SSDWMC,POLICEID,POLICENAME,CALLNO,REMARK,SFBDHM from PGIS_DWXX.T_GPS_INFO_DZSP";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(policeCarDBConnectBuilder.ConnectionString))
                {
                    //15个字段
                    
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PoliceInfo info = new PoliceInfo();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.GpsId = reader[0].ToString();
                        }
                        //LOCTYPE
                        if (!reader.IsDBNull(1))
                        {
                            info.LocType = Convert.ToInt32(reader[1].ToString());
                        }
                        //POLICETYPEID
                        if (!reader.IsDBNull(2))
                        {
                            info.PatrolType = reader[2].ToString();
                        }
                        //UIM
                        if (!reader.IsDBNull(3))
                        {
                            info.UIM = reader[3].ToString();
                        }
                        //CARNO
                        if (!reader.IsDBNull(4))
                        {
                            info.CarPlateNum = reader[4].ToString();
                        }
                        //350MCZTID
                        if (!reader.IsDBNull(5))
                        {
                            info.CarCallNum = reader[5].ToString();
                        }
                        //FZR
                        if (!reader.IsDBNull(6))
                        {
                            info.Responser = reader[6].ToString();
                        }
                        //LXFS
                        if (!reader.IsDBNull(7))
                        {
                            info.ResponserPhoneNo = reader[7].ToString();
                        }
                        //SSSJMC
                        if (!reader.IsDBNull(8))
                        {
                            info.CarSJUnit = reader[8].ToString();
                        }
                        //SSFJMC
                        if (!reader.IsDBNull(9))
                        {
                            info.CarFJUnit = reader[9].ToString();
                        }
                        //SSDWMC
                        if (!reader.IsDBNull(10))
                        {
                            info.CarUnit = reader[10].ToString();
                        }
                        //POLICEID
                        if (!reader.IsDBNull(11))
                        {
                            info.PoliceId = reader[11].ToString();
                        }
                        //POLICENAME
                        if (!reader.IsDBNull(12))
                        {
                            info.PoliceName = reader[12].ToString();
                        }
                        //CALLNO
                        if (!reader.IsDBNull(13))
                        {
                            info.PhoneNo = reader[13].ToString();
                        }
                        //REMARK
                        if (!reader.IsDBNull(14))
                        {
                            info.Remark = reader[14].ToString();
                        }
                        //SFBDHM
                        if (!reader.IsDBNull(15))
                        {
                            info.CarChannel = reader[15].ToString();
                        }
                        list.Add(info);
                        //LogManage.InfoLog(typeof(int), "警车总数:" + list.Count);
                    } //end while
                } //end using
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error(String.Format("执行警车查询失败，SQL:{0}", sql), ex);
                //LogManage.ErrorLog("日志记录", ex);
            }
           
            return list;
        }
        #endregion

    }
}
