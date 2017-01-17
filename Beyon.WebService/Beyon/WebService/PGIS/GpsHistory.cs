using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Beyon.Common;
using Beyon.Domain.PGIS;

namespace Beyon.WebService.PGIS
{
	public class GpsHistory
	{
        #region Fields

        /// <summary>
        /// PGIS GPS数据库连接字符串构造器
        /// </summary>
        private OleDbConnectionStringBuilder gpsHistoryDBConnectBuilder;

        /// <summary>
        /// GPS警车、设备信息库
        /// </summary>
        private OleDbConnectionStringBuilder gpsDeviceDBConnectBuilder;
        #endregion

        private Dictionary<string, GpsInfo> allGpsList;
        private Dictionary<string, GpsInfo> gpsCarList;
        private Dictionary<string, GpsInfo> gpsDeviceList;

        public GpsHistory()
        {
            //todo 后期需统一将数据库操作封装到一层中
            gpsHistoryDBConnectBuilder = new OleDbConnectionStringBuilder();

            gpsHistoryDBConnectBuilder.Add("Provider", "MSDAORA");
            gpsHistoryDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "gpsDB"));
            gpsHistoryDBConnectBuilder.Add("Persist Security Info", true);
            gpsHistoryDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "gpsDBUser"));
            gpsHistoryDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "gpsDBPasswd"));

            //gpsHistoryDBConnectBuilder.Add("Provider", "MSDAORA");
            //gpsHistoryDBConnectBuilder.Add("Data Source", "10.178.1.218/gspgis");
            //gpsHistoryDBConnectBuilder.Add("Persist Security Info", true);
            //gpsHistoryDBConnectBuilder.Add("User ID", "zcdz");
            //gpsHistoryDBConnectBuilder.Add("Password", "zcdz");

            gpsDeviceDBConnectBuilder = new OleDbConnectionStringBuilder();

            gpsDeviceDBConnectBuilder.Add("Provider", "MSDAORA");
            gpsDeviceDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "gpsDeviceDB"));
            gpsDeviceDBConnectBuilder.Add("Persist Security Info", true);
            gpsDeviceDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "gpsDeviceDBUser"));
            gpsDeviceDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "gpsDeviceDBPasswd"));

            //gpsDeviceDBConnectBuilder.Add("Provider", "MSDAORA");
            //gpsDeviceDBConnectBuilder.Add("Data Source", "10.178.1.108/pgis");
            //gpsDeviceDBConnectBuilder.Add("Persist Security Info", true);
            //gpsDeviceDBConnectBuilder.Add("User ID", "zcdz");
            //gpsDeviceDBConnectBuilder.Add("Password", "zcdz");
        }

        private void InitAllGpsList()
        {
            if(this.allGpsList == null)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(this.gpsDeviceDBConnectBuilder.ConnectionString))
                    {
                        String sql = "select gpsid, orgid, carno, sssjmc, ssfjmc, ssdwmc, loctype from GSBUILDER.T_GPS_INFO t";
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        this.gpsCarList = new Dictionary<string, GpsInfo>();
                        while (reader.Read())
                        {
                            GpsInfo info = new GpsInfo();
                            //GPSID
                            if (!reader.IsDBNull(0))
                            {
                                info.GpsId = reader[0].ToString();
                            }
                            //orgid
                            if (!reader.IsDBNull(1))
                            {
                                info.OrgId = reader[1].ToString();
                            }
                            //carno
                            if (!reader.IsDBNull(2))
                            {
                                info.CarNo = reader[2].ToString();
                            }
                            //sssjmc
                            if (!reader.IsDBNull(3))
                            {
                                info.Sssjmc = reader[3].ToString();
                            }
                            //ssfjmc
                            if (!reader.IsDBNull(4))
                            {
                                info.Ssfjmc = reader[4].ToString();
                            }
                            //ssdwmc
                            if (!reader.IsDBNull(5))
                            {
                                info.Ssdwmc = reader[5].ToString();
                            }
                            //gps type
                            if (!reader.IsDBNull(6))
                            {
                                info.GpsType = Convert.ToInt32(reader[6].ToString());
                            }


                            if (!this.gpsCarList.ContainsKey(info.GpsId))
                            {
                                this.gpsCarList.Add(info.GpsId, info);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 初始化gpsCar 字典
        /// </summary>
        private void InitGpsCarList()
        {
            if(this.gpsCarList == null)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(this.gpsDeviceDBConnectBuilder.ConnectionString))
                    {
                        String sql = "select gpsid, orgid, carno, sssjmc, ssfjmc, ssdwmc, loctype from GSBUILDER.T_GPS_INFO t where loctype = 1";
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        this.gpsCarList = new Dictionary<string, GpsInfo>();
                        while (reader.Read())
                        {
                            GpsInfo info = new GpsInfo();
                            //GPSID
                            if (!reader.IsDBNull(0))
                            {
                                info.GpsId = reader[0].ToString();
                            }
                            //orgid
                            if (!reader.IsDBNull(1))
                            {
                                info.OrgId =reader[1].ToString();
                            }
                            //carno
                            if (!reader.IsDBNull(2))
                            {
                                info.CarNo = reader[2].ToString();
                            }
                            //sssjmc
                            if (!reader.IsDBNull(3))
                            {
                                info.Sssjmc = reader[3].ToString();
                            }
                            //ssfjmc
                            if (!reader.IsDBNull(4))
                            {
                                info.Ssfjmc = reader[4].ToString();
                            }
                            //ssdwmc
                            if (!reader.IsDBNull(5))
                            {
                                info.Ssdwmc = reader[5].ToString();
                            }
                            //gps type
                            if( !reader.IsDBNull(6))
                            {
                                info.GpsType = Convert.ToInt32(reader[6].ToString());
                            }


                            if( ! this.gpsCarList.ContainsKey(info.GpsId))
                            {
                                this.gpsCarList.Add(info.GpsId, info);
                            }     
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 初始化gps终端 字典
        /// </summary>
        private void InitGpsDeviceList()
        {
            if(this.gpsDeviceList == null)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(this.gpsDeviceDBConnectBuilder.ConnectionString))
                    {
                        String sql = "select gpsid, orgid, carno, sssjmc, ssfjmc, ssdwmc   from GSBUILDER.T_GPS_INFO t where loctype = 2";
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        this.gpsDeviceList = new Dictionary<string, GpsInfo>();
                        while (reader.Read())
                        {
                            GpsInfo info = new GpsInfo();
                            //GPSID
                            if (!reader.IsDBNull(0))
                            {
                                info.GpsId = reader[0].ToString();
                            }
                            //orgid
                            if (!reader.IsDBNull(1))
                            {
                                info.OrgId = reader[1].ToString();
                            }
                            //carno
                            if (!reader.IsDBNull(2))
                            {
                                info.CarNo = reader[2].ToString();
                            }
                            //sssjmc
                            if (!reader.IsDBNull(3))
                            {
                                info.Sssjmc = reader[3].ToString();
                            }
                            //ssfjmc
                            if (!reader.IsDBNull(3))
                            {
                                info.Ssfjmc = reader[4].ToString();
                            }
                            //ssdwmc
                            if (!reader.IsDBNull(3))
                            {
                                info.Ssdwmc = reader[5].ToString();
                            }
                            //gps type
                            if (!reader.IsDBNull(6))
                            {
                                info.GpsType = Convert.ToInt32(reader[6].ToString());
                            }

                            if( ! this.gpsDeviceList.ContainsKey(info.GpsId))
                            {
                                this.gpsDeviceList.Add(info.GpsId, info);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<GpsTrail> GetAllGpsHistoryInfo(DateTime start, DateTime end)
        {
            if(start.Day != end.Day){
                throw new ArgumentException("不支持跨天查询，请仔细检查起始时间参数！");
            }

            InitAllGpsList();

            String timeMarker = new StringBuilder().Append("_").Append(start.Year).Append("_").Append(start.Month >= 10 ? start.Month.ToString() : ("0" + start.Month)).Append("_").Append(start.Day).ToString();
            List<GpsTrail> list = new List<GpsTrail>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(gpsHistoryDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GPSID,X,Y,TIME from GSDATA.GA_GPS_HISTORY" + timeMarker + "  where TIME >= ? and TIME <= ?"; //todo 根据时间构造
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.Add(new OleDbParameter("@start", OleDbType.DBTimeStamp));
                    cmd.Parameters[0].Value = start;
                    cmd.Parameters.Add(new OleDbParameter("@end", OleDbType.DBTimeStamp));
                    cmd.Parameters[1].Value = end;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        GpsTrail info = new GpsTrail();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.GpsId = reader[0].ToString();
                        }
                        //X
                        if (!reader.IsDBNull(1))
                        {
                            info.X = Convert.ToDouble(reader[1].ToString());
                        }
                        //Y
                        if (!reader.IsDBNull(2))
                        {
                            info.Y = Convert.ToDouble(reader[2].ToString());
                        }
                        //Time
                        if (!reader.IsDBNull(3))
                        {
                            info.Time = Convert.ToDateTime(reader[3].ToString());
                        }

                        if (this.gpsCarList.ContainsKey(info.GpsId))
                        {
                            info.GpsType = this.gpsCarList[info.GpsId].GpsType;
                            list.Add(info);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }

        /// <summary>
        /// 获取gps警车轨迹信息
        /// </summary>
        /// <param name="start">查询开始时间</param>
        /// <param name="end">查询结束时间</param>
        /// <returns></returns>
        public List<GpsTrail> GetGpsCarHistoryInfo(DateTime start, DateTime end)
        {
            if (start.Day != end.Day)
            {
                throw new ArgumentException("不支持跨天查询，请仔细检查起始时间参数！");
            }

            InitGpsCarList();

            String timeMarker = new StringBuilder().Append("_").Append(start.Year).Append("_").Append(start.Month >= 10 ? start.Month.ToString() : ("0" + start.Month)).Append("_").Append(start.Day).ToString();
            List<GpsTrail> list = new List<GpsTrail>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(gpsHistoryDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GPSID,X,Y,TIME from GSDATA.GA_GPS_HISTORY" + timeMarker + "  where TIME >= ? and TIME <= ?"; //todo 根据时间构造
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.Add(new OleDbParameter("@start", OleDbType.DBTimeStamp));
                    cmd.Parameters[0].Value = start;
                    cmd.Parameters.Add(new OleDbParameter("@end", OleDbType.DBTimeStamp));
                    cmd.Parameters[1].Value = end;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        GpsTrail info = new GpsTrail();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.GpsId = reader[0].ToString();
                        }
                        //X
                        if (!reader.IsDBNull(1))
                        {
                            info.X = Convert.ToDouble(reader[1].ToString());
                        }
                        //Y
                        if (!reader.IsDBNull(2))
                        {
                            info.Y = Convert.ToDouble(reader[2].ToString());
                        }
                        //Time
                        if (!reader.IsDBNull(3))
                        {
                            info.Time = Convert.ToDateTime(reader[3].ToString());
                        }

                        info.GpsType = 1;

                        if (this.gpsCarList.ContainsKey(info.GpsId))
                        {
                            list.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        /// <summary>
        /// 获取gps手持终端历史轨迹信息
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<GpsTrail> GetGpsDeviceHistoryInfo(DateTime start, DateTime end)
        {
            if (start.Day != end.Day)
            {
                throw new ArgumentException("不支持跨天查询，请仔细检查起始时间参数！");
            }

            InitGpsDeviceList();

            String timeMarker = new StringBuilder().Append("_").Append(start.Year).Append("_").Append(start.Month >= 10 ? start.Month.ToString() : ("0" + start.Month)).Append("_").Append(start.Day).ToString();
            List<GpsTrail> list = new List<GpsTrail>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(gpsHistoryDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GPSID,X,Y,TIME from GSDATA.GA_GPS_HISTORY" + timeMarker + "  where TIME >= ? and TIME <= ?"; //todo 根据时间构造
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.Add(new OleDbParameter("@start", OleDbType.DBTimeStamp));
                    cmd.Parameters[0].Value = start;
                    cmd.Parameters.Add(new OleDbParameter("@end", OleDbType.DBTimeStamp));
                    cmd.Parameters[1].Value = end;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        GpsTrail info = new GpsTrail();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.GpsId = reader[0].ToString();
                        }
                        //X
                        if (!reader.IsDBNull(1))
                        {
                            info.X = Convert.ToDouble(reader[1].ToString());
                        }
                        //Y
                        if (!reader.IsDBNull(2))
                        {
                            info.Y = Convert.ToDouble(reader[2].ToString());
                        }
                        //Time
                        if (!reader.IsDBNull(3))
                        {
                            info.Time = Convert.ToDateTime(reader[3].ToString());
                        }

                        //A210手持终端
                        info.GpsType = 2;

                        if (this.gpsDeviceList.ContainsKey(info.GpsId))
                        {
                            list.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
	}
}
