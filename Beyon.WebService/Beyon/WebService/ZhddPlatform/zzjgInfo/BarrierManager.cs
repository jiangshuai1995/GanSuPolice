using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Beyon.Common;
using Beyon.Domain.Zhdd.zjjg;
using Npgsql;

namespace Beyon.WebService.ZhddPlatform.zzjgInfo
{
    /// <summary>
    /// 卡口
    /// </summary>
    public class BarrierManager
    {
        //private String  KKDBConnectString;
        private OleDbConnectionStringBuilder zzjgDBConnectBuilder;


        public BarrierManager()
        {
            //KKDBConnectString = ConfigHelper.GetValueByKey("webservice.config", "pgConnect");

            this.zzjgDBConnectBuilder = new OleDbConnectionStringBuilder();

            zzjgDBConnectBuilder.Add("Provider", "MSDAORA");
            zzjgDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "zzjgDB"));
            zzjgDBConnectBuilder.Add("Persist Security Info", true);
            zzjgDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBUser"));
            zzjgDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBPasswd"));
        }

        public List<Barrier> GetAllBarrierByExtent(double minX, double minY, double maxX, double maxY) 
        {
            List<Barrier> result = new List<Barrier>();
            String URL = ConfigHelper.GetValueByKey("webservice.config", "TransportCenter");
            try
            {
                using (OleDbConnection conn = new OleDbConnection(zzjgDBConnectBuilder.ConnectionString))
                {
                    string sql =String.Format( "select DEVICE_CODE,CHANNEL_SN,CHANNEL_NAME,GPS_X,GPS_Y FROM B_ZTK_SP_KKTDB where GPS_X is not null AND GPS_Y is not null  AND GPS_Y >='{0}' AND GPS_Y <='{1}' ",minY,maxY);
                    if (minX >= 100||maxX<100)
                    {
                        sql = String.Format("select DEVICE_CODE,CHANNEL_SN,CHANNEL_NAME,GPS_X,GPS_Y FROM b_ztk_sp_kktdb where GPS_X is not null AND GPS_Y is not null AND GPS_X >='{0}' AND GPS_X<='{1}' AND GPS_Y >='{2}' AND GPS_Y <='{3}'",minX,maxX,minY,maxY);
                    }

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Barrier info = new Barrier();
                        if (!reader.IsDBNull(0))
                        {
                            info.Kkid = reader[0].ToString();
                        }

                        //卡口名称
                        if (!reader.IsDBNull(2))
                        {
                            info.Kkmc = reader[2].ToString();
                        }

                        //卡口所在地经度
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if (x > 0)
                            {
                                info.KkJd = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if (y > 0)
                            {
                                info.KkWd = y;
                            }
                        }

                        //卡口通道标识码
                        if (!reader.IsDBNull(1))
                        {
                            info.Kkssd = reader[1].ToString();
                        }

                        info.KkUrl = URL;

                        //范围
                        if (info.KkJd > 0 && info.KkWd > 0 && info.KkJd >= minX && info.KkWd >= minY && info.KkJd <= maxX && info.KkWd <= maxY)
                        {
                            result.Add(info);
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Barrier GetBarrierByID(string id)
        {
            Barrier barrier = new Barrier();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(zzjgDBConnectBuilder.ConnectionString))
                {
                    string sql = String.Format("select DEVICE_CODE,CHANNEL_SN,CHANNEL_NAME,GPS_X,GPS_Y FROM B_ZTK_SP_KKTDB where GPS_X is not null AND GPS_Y is not null  AND DEVICE_CODE='{0}'", id); 

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Barrier info = new Barrier();
                        //卡口id
                        if (!reader.IsDBNull(0))
                        {
                            info.Kkid = reader[0].ToString();
                        }

                        //卡口名称
                        if (!reader.IsDBNull(2))
                        {
                            info.Kkmc = reader[2].ToString();
                        }

                        //卡口所在地经度
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if (x > 0)
                            {
                                info.KkJd = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if (y > 0)
                            {
                                info.KkWd = y;
                            }
                        }

                        //卡口通道标识码
                        if (!reader.IsDBNull(1))
                        {
                            info.Kkssd = reader[1].ToString();
                        }

                        return info;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
