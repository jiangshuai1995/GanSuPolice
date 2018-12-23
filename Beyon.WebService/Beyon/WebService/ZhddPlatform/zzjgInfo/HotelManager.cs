using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Beyon.Common;
using Beyon.Domain.Zhdd.zjjg;

namespace Beyon.WebService.ZhddPlatform.zzjgInfo
{
    /// <summary>
    /// 旅店信息管理类
    /// </summary>
	public class HotelManager
	{
        private OleDbConnectionStringBuilder zzjgDBConnectBuilder;

        public HotelManager()
        {
            this.zzjgDBConnectBuilder = new OleDbConnectionStringBuilder();

            zzjgDBConnectBuilder.Add("Provider", "MSDAORA");
            zzjgDBConnectBuilder.Add("Data Source", ConfigHelper.GetValueByKey("webservice.config", "zzjgDB"));
            zzjgDBConnectBuilder.Add("Persist Security Info", true);
            zzjgDBConnectBuilder.Add("User ID", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBUser"));
            zzjgDBConnectBuilder.Add("Password", ConfigHelper.GetValueByKey("webservice.config", "zzjgDBPasswd"));

            //zzjgDBConnectBuilder.Add("Provider", "MSDAORA");
            //zzjgDBConnectBuilder.Add("Data Source", "10.178.3.37/orcl");
            //zzjgDBConnectBuilder.Add("Persist Security Info", true);
            //zzjgDBConnectBuilder.Add("User ID", "zzjgcx");
            //zzjgDBConnectBuilder.Add("Password", "zzjgcx");
        }

        /// <summary>
        /// 获取所有旅店
        /// </summary>
        /// <returns></returns>
        public List<Hotel> GetAllHotels()
        {
            List<Hotel> result = new List<Hotel>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select LGBM, GXPCS_GAJGJGDM, DWMC, DZ, DLJD, DLWD, FZR_XM, LXDH from B_ZTK_SP_LGYYCS";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Hotel info = new Hotel();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Ld_code = reader[0].ToString();
                        }
                       
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajg_key = reader[1].ToString();
                        }
                       
                        if (!reader.IsDBNull(2))
                        {
                            info.Ldmc = reader[2].ToString();
                        }
                       
                        if (!reader.IsDBNull(3))
                        {
                            info.Ldxz = reader[3].ToString();
                        }
                        
                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x,y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if(x > 0)
                            {
                                info.LdJD = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.LdWD = y;
                            }
                        }

                        if(!reader.IsDBNull(6))
                        {
                            info.Fzr_xm = reader[6].ToString();
                        }

                        //if(!reader.IsDBNull(7))
                        //{
                        //    info.Fzr_sfzh = reader[7].ToString();
                        //}

                        if (!reader.IsDBNull(7))
                        {
                            info.Lxdh = reader[7].ToString();
                        }

                        //if (!reader.IsDBNull(9))
                        //{
                        //    info.Ld_code_old = reader[9].ToString();
                        //}

                        if(info.LdJD > 0 && info.LdWD > 0)
                        {
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
        }

        /// <summary>
        /// 根据输入条件搜索旅店
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<Hotel> FindHotelsBySearch(string exp)
        {
            List<Hotel> result = new List<Hotel>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select LGBM, GXPCS_GAJGJGDM, DWMC, DZ, DLJD, DLWD, FZR_XM, LXDH from B_ZTK_SP_LGYYCS where DWMC like '%'||?||'%'";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.Add(new OleDbParameter("@exp1", OleDbType.VarChar));
                    cmd.Parameters[0].Value = exp;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Hotel info = new Hotel();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Ld_code = reader[0].ToString();
                        }

                        if (!reader.IsDBNull(1))
                        {
                            info.Gajg_key = reader[1].ToString();
                        }

                        if (!reader.IsDBNull(2))
                        {
                            info.Ldmc = reader[2].ToString();
                        }

                        if (!reader.IsDBNull(3))
                        {
                            info.Ldxz = reader[3].ToString();
                        }

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x, y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if (x > 0)
                            {
                                info.LdJD = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.LdWD = y;
                            }
                        }

                        if (!reader.IsDBNull(6))
                        {
                            info.Fzr_xm = reader[6].ToString();
                        }

                        //if (!reader.IsDBNull(7))
                        //{
                        //    info.Fzr_sfzh = reader[7].ToString();
                        //}

                        if (!reader.IsDBNull(7))
                        {
                            info.Lxdh = reader[7].ToString();
                        }

                        if (info.LdJD > 0 && info.LdWD > 0)
                        {
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
        }

        /// <summary>
        /// 根据屏幕坐标范围获取所有旅馆
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<Hotel> GetAllHotelsByExtent_bak(double minX, double minY, double maxX, double maxY)
        {
            List<Hotel> result = new List<Hotel>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select LD_CODE, GAJG_KEY, LDMC, LDXZ, LDJD, LDWD, FZR_XM, FZR_SFZH, LXDH from ZZJGXT.LD_INFO where LDJD IS NOT NULL and LDWD IS NOT NULL and LDJD >= ? and LDWD >= ? and LDJD <= ? and LDWD <= ?";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.Add(new OleDbParameter("@minX", OleDbType.Double));
                    cmd.Parameters[0].Value = minX;
                    cmd.Parameters.Add(new OleDbParameter("@minY", OleDbType.Double));
                    cmd.Parameters[1].Value = minY;
                    cmd.Parameters.Add(new OleDbParameter("@maxX", OleDbType.Double));
                    cmd.Parameters[2].Value = maxX;
                    cmd.Parameters.Add(new OleDbParameter("@maxY", OleDbType.Double));
                    cmd.Parameters[3].Value = maxY;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Hotel info = new Hotel();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Ld_code = reader[0].ToString();
                        }

                        if (!reader.IsDBNull(1))
                        {
                            info.Gajg_key = reader[1].ToString();
                        }

                        if (!reader.IsDBNull(2))
                        {
                            info.Ldmc = reader[2].ToString();
                        }

                        if (!reader.IsDBNull(3))
                        {
                            info.Ldxz = reader[3].ToString();
                        }

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x, y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if (x > 0)
                            {
                                info.LdJD = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.LdWD = y;
                            }
                        }

                        if (!reader.IsDBNull(6))
                        {
                            info.Fzr_xm = reader[6].ToString();
                        }

                        if (!reader.IsDBNull(7))
                        {
                            info.Fzr_sfzh = reader[7].ToString();
                        }

                        if (!reader.IsDBNull(8))
                        {
                            info.Lxdh = reader[8].ToString();
                        }

                        if (info.LdJD > 0 && info.LdWD > 0)
                        {
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
        }

        public List<Hotel> GetAllHotelsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<Hotel> result = new List<Hotel>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql =String.Format( "select LGBM, GXPCS_GAJGJGDM, DWMC, DZ, DLJD, DLWD, FZR_XM, LXDH from B_ZTK_SP_LGYYCS where DLJD IS NOT NULL and DLWD IS NOT NULL  AND DLWD>='{0}' AND DLWD<='{1}' ",minY,maxY);
                    if (minX >= 100 || maxX < 100)
                    {
                         sql =String.Format( "select LGBM, GXPCS_GAJGJGDM, DWMC, DZ, DLJD, DLWD, FZR_XM, LXDH from B_ZTK_SP_LGYYCS where DLJD IS NOT NULL and DLWD IS NOT NULL AND DLJD>='{0}' AND DLJD<='{1}' AND DLWD>='{2}' AND DLWD<='{3}' ",minX,maxX,minY,maxY);
                    }
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Hotel info = new Hotel();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Ld_code = reader[0].ToString();
                        }

                        if (!reader.IsDBNull(1))
                        {
                            info.Gajg_key = reader[1].ToString();
                        }

                        if (!reader.IsDBNull(2))
                        {
                            info.Ldmc = reader[2].ToString();
                        }

                        if (!reader.IsDBNull(3))
                        {
                            info.Ldxz = reader[3].ToString();
                        }

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x, y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if (x > 0)
                            {
                                info.LdJD = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.LdWD = y;
                            }
                        }

                        if (!reader.IsDBNull(6))
                        {
                            info.Fzr_xm = reader[6].ToString();
                        }

                        //if (!reader.IsDBNull(7))
                        //{
                        //    info.Fzr_sfzh = reader[7].ToString();
                        //}

                        if (!reader.IsDBNull(7))
                        {
                            info.Lxdh = reader[7].ToString();
                        }

                        //if (!reader.IsDBNull(9))
                        //{
                        //    info.Ld_code_old = reader[9].ToString();
                        //}

                        if (info.LdJD > 0 && info.LdWD > 0 && info.LdJD >= minX && info.LdWD >= minY && info.LdJD <= maxX && info.LdWD <= maxY)
                        {
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
        }

        public int GetAllHotelCount()
        {
            int result = 0;
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select count(*) from  B_ZTK_SP_LGYYCS where DLJD IS NOT NULL and DLWD IS NOT NULL";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    var reader = cmd.ExecuteScalar();

                    result = Int32.Parse(reader.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
	}
}
