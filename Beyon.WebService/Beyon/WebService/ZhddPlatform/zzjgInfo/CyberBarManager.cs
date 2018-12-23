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
    /// 网吧信息管理类
    /// </summary>
	public class CyberBarManager
	{
        private OleDbConnectionStringBuilder zzjgDBConnectBuilder;

        public CyberBarManager()
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

        public List<CyberBar> GetAllWBs()
        {
            List<CyberBar> result = new List<CyberBar>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    //String sql = "select WB_CODE, GAJG_KEY, WBMC, WBXZ, WBJD, WBWD, FZR_XM, FZR_SFZH, LXDH, WB_CODE_OLD from ZZJGXT.WB_INFO t ";
                    String sql ="SELECT YYCSDM,YYCS_DWMC,SSDS_XZQHDM,YYCS_DZMC,DLJD,DLWD,FZR_LXDH,DJDW_GAJGMC from B_ZTK_SP_WBYYCS WHERE DLJD is not null AND DLWD is not null";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CyberBar info = new CyberBar();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Wb_code = reader[0].ToString();
                        }

                        //公安机构代码变成名称
                        if (!reader.IsDBNull(7))
                        {
                            info.Gajg_key = reader[7].ToString();
                        }

                        if (!reader.IsDBNull(1))
                        {
                            info.Wbmc = reader[1].ToString();
                        }

                        if (!reader.IsDBNull(3))
                        {
                            info.Wbxz = reader[3].ToString();
                        }

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x, y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if (x > 0)
                            {
                                info.Wbjd = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.Wbwd = y;
                            }
                        }

                        //if (!reader.IsDBNull(6))
                        //{
                        //    info.Fzr_xm = reader[6].ToString();
                        //}

                        //if (!reader.IsDBNull(7))
                        //{
                        //    info.Fzr_sfzh = reader[7].ToString();
                        //}

                        if (!reader.IsDBNull(6))
                        {
                            info.Lxdh = reader[6].ToString();
                        }

                        //if (!reader.IsDBNull(9))
                        //{
                        //    info.Wb_code_old = reader[9].ToString();
                        //}

                        //if (info.Wbjd > 0 && info.Wbwd > 0)
                        //{
                            result.Add(info);
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<CyberBar> FindCyberBarsBySearch(string exp)
        {
            List<CyberBar> result = new List<CyberBar>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select YYCSDM,YYCS_DWMC,SSDS_XZQHDM,YYCS_DZMC,DLJD,DLWD,FZR_LXDH,DJDW_GAJGMC from B_ZTK_SP_WBYYCS t where YYCS_DWMC like '%'||?||'%'";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.Add(new OleDbParameter("@exp1", OleDbType.VarChar));
                    cmd.Parameters[0].Value = exp;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CyberBar info = new CyberBar();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Wb_code = reader[0].ToString();
                        }

                        //公安机构代码变成名称
                        if (!reader.IsDBNull(7))
                        {
                            info.Gajg_key = reader[7].ToString();
                        }

                        if (!reader.IsDBNull(1))
                        {
                            info.Wbmc = reader[1].ToString();
                        }

                        if (!reader.IsDBNull(3))
                        {
                            info.Wbxz = reader[3].ToString();
                        }

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x, y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if (x > 0)
                            {
                                info.Wbjd = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.Wbwd = y;
                            }
                        }

                        //if (!reader.IsDBNull(6))
                        //{
                        //    info.Fzr_xm = reader[6].ToString();
                        //}

                        //if (!reader.IsDBNull(7))
                        //{
                        //    info.Fzr_sfzh = reader[7].ToString();
                        //}

                        if (!reader.IsDBNull(6))
                        {
                            info.Lxdh = reader[6].ToString();
                        }

                        //if (!reader.IsDBNull(9))
                        //{
                        //    info.Wb_code_old = reader[9].ToString();
                        //}

                        //if (info.Wbjd > 0 && info.Wbwd > 0)
                        //{
                        result.Add(info);
                        //}

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
        /// 根据屏幕坐标范围获取所有网吧
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<CyberBar> GetAllWBsByExtent_backup(double minX, double minY, double maxX, double maxY)
        {
            List<CyberBar> result = new List<CyberBar>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select WB_CODE, GAJG_KEY, WBMC, WBXZ, WBJD, WBWD, FZR_XM, FZR_SFZH, LXDH from ZZJGXT.WB_INFO t where WBJD IS NOT NULL and WBWD IS NOT NULL and WBJD >= ? and WBWD >= ? and WBJD <= ? and WBWD <= ?";
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
                        CyberBar info = new CyberBar();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Wb_code = reader[0].ToString();
                        }

                        if (!reader.IsDBNull(1))
                        {
                            info.Gajg_key = reader[1].ToString();
                        }

                        if (!reader.IsDBNull(2))
                        {
                            info.Wbmc = reader[2].ToString();
                        }

                        if (!reader.IsDBNull(3))
                        {
                            info.Wbxz = reader[3].ToString();
                        }

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x, y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if (x > 0)
                            {
                                info.Wbjd = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.Wbwd = y;
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

                        if (info.Wbjd > 0 && info.Wbwd > 0)
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
        /// 根据屏幕坐标范围获取所有网吧
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<CyberBar> GetAllWBsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<CyberBar> result = new List<CyberBar>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = String.Format( "select YYCSDM,YYCS_DWMC,SSDS_XZQHDM,YYCS_DZMC,DLJD,DLWD,FZR_LXDH,DJDW_GAJGMC from B_ZTK_SP_WBYYCS t where DLJD IS NOT NULL and DLWD IS NOT NULL AND DLWD>='{0}' AND DLWD<='{1}'",minY,maxY);
                    if (minX >= 100 || maxX < 100)
                    {
                        sql = String.Format("select YYCSDM,YYCS_DWMC,SSDS_XZQHDM,YYCS_DZMC,DLJD,DLWD,FZR_LXDH,DJDW_GAJGMC from B_ZTK_SP_WBYYCS t where DLJD IS NOT NULL and DLWD IS NOT NULL AND DLJD>='{0}' AND DLJD<='{1}' AND DLWD>='{2}' AND DLWD<='{3}'", minX, maxX, minY, maxY);
                    }
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CyberBar info = new CyberBar();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Wb_code = reader[0].ToString();
                        }

                        //公安机构代码变成名称
                        if (!reader.IsDBNull(7))
                        {
                            info.Gajg_key = reader[7].ToString();
                        }

                        if (!reader.IsDBNull(1))
                        {
                            info.Wbmc = reader[1].ToString();
                        }

                        if (!reader.IsDBNull(3))
                        {
                            info.Wbxz = reader[3].ToString();
                        }

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            double x, y;
                            Double.TryParse(reader[4].ToString(), out x);
                            if (x > 0)
                            {
                                info.Wbjd = x;
                            }

                            Double.TryParse(reader[5].ToString(), out y);
                            if (y > 0)
                            {
                                info.Wbwd = y;
                            }
                        }

                        //if (!reader.IsDBNull(6))
                        //{
                        //    info.Fzr_xm = reader[6].ToString();
                        //}

                        //if (!reader.IsDBNull(7))
                        //{
                        //    info.Fzr_sfzh = reader[7].ToString();
                        //}

                        if (!reader.IsDBNull(6))
                        {
                            info.Lxdh = reader[6].ToString();
                        }

                        //if (!reader.IsDBNull(9))
                        //{
                        //    info.Wb_code_old = reader[9].ToString();
                        //}


                        if (info.Wbjd > 0 && info.Wbwd > 0 && info.Wbjd >= minX && info.Wbwd >= minY && info.Wbjd <= maxX && info.Wbwd <= maxY)
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

        public int GetAllWBsCount()
        {
            int result = 0;
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select count(*) from B_ZTK_SP_WBYYCS t where DLJD IS NOT NULL and DLWD IS NOT NULL";
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
