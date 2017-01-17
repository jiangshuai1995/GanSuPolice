using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows;
using Beyon.Common;
using Beyon.Domain.Zhdd.zjjg;

namespace Beyon.WebService.ZhddPlatform.zzjgInfo
{
    /// <summary>
    /// 公安机构信息管理类
    /// </summary>
	public class PoliceOrgManager
	{
        private OleDbConnectionStringBuilder zzjgDBConnectBuilder;

        public PoliceOrgManager()
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
        /// 获取所有公安机构
        /// </summary>
        /// <returns></returns>
        public List<PoliceOrg> GetAllPoliceOrgs()
        {
            List<PoliceOrg> result = new List<PoliceOrg>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where zt = '01'";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
       
                    while (reader.Read())
                    {
                        PoliceOrg info = new PoliceOrg();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Gajgdm = reader[0].ToString();
                        }
                        //orgid
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajgmc = reader[1].ToString();
                        }
                        //carno
                        if (!reader.IsDBNull(2))
                        {
                            info.Gajgjc = reader[2].ToString();
                        }
                        //sssjmc
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if (x > 0)
                            {
                                info.GajgJD = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if (y > 0)
                            {
                                info.GajgWD = y;
                            }
                        }
                        //ssdwmc
                        if (!reader.IsDBNull(5))
                        {
                            info.Jglx = reader[5].ToString();
                        }

                        result.Add(info);
                        
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
        /// 获取派出所公安机构
        /// </summary>
        /// <returns></returns>
        public List<PoliceOrg> GetPcsPoliceOrgs()
        {
            List<PoliceOrg> result = new List<PoliceOrg>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where zt = '01' and jglx = 'PCS'";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PoliceOrg info = new PoliceOrg();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Gajgdm = reader[0].ToString();
                        }
                        //orgid
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajgmc = reader[1].ToString();
                        }
                        //carno
                        if (!reader.IsDBNull(2))
                        {
                            info.Gajgjc = reader[2].ToString();
                        }
                        //sssjmc
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if (x > 0)
                            {
                                info.GajgJD = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if (y > 0)
                            {
                                info.GajgWD = y;
                            }
                        }
                        //ssdwmc
                        if (!reader.IsDBNull(5))
                        {
                            info.Jglx = reader[5].ToString();
                        }

                        result.Add(info);

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
        /// 获取非派出所公安机构
        /// </summary>
        /// <returns></returns>
        public List<PoliceOrg> GetNPcsPoliceOrgs()
        {
            List<PoliceOrg> result = new List<PoliceOrg>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where zt = '01' and jglx != 'PCS'";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PoliceOrg info = new PoliceOrg();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Gajgdm = reader[0].ToString();
                        }
                        //orgid
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajgmc = reader[1].ToString();
                        }
                        //carno
                        if (!reader.IsDBNull(2))
                        {
                            info.Gajgjc = reader[2].ToString();
                        }
                        //sssjmc
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if (x > 0)
                            {
                                info.GajgJD = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if (y > 0)
                            {
                                info.GajgWD = y;
                            }
                        }
                        //ssdwmc
                        if (!reader.IsDBNull(5))
                        {
                            info.Jglx = reader[5].ToString();
                        }

                        result.Add(info);

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
        /// 圈选获取所有公安机构
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<PoliceOrg> GetAllPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<PoliceOrg> result = new List<PoliceOrg>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where zt = '01' and GAJGJD is not null and GAJGWD is not null and GAJGJD >= ? and GAJGWD >= ? and GAJGJD <= ? and GAJGWD <= ?";
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
                        PoliceOrg info = new PoliceOrg();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Gajgdm = reader[0].ToString();
                        }
                        //orgid
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajgmc = reader[1].ToString();
                        }
                        //carno
                        if (!reader.IsDBNull(2))
                        {
                            info.Gajgjc = reader[2].ToString();
                        }
                        //sssjmc
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if(x > 0)
                            {
                                info.GajgJD = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if(y > 0)
                            {
                                info.GajgWD = y;
                            }
                        }

                        //ssdwmc
                        if (!reader.IsDBNull(5))
                        {
                            info.Jglx = reader[5].ToString();
                        }

                        if (info.GajgJD > 0 && info.GajgWD > 0 && info.GajgJD >= minX && info.GajgWD >= minY && info.GajgJD <= maxX && info.GajgWD <= maxY)
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
        /// 根据屏幕坐标范围获取派出所机构
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<PoliceOrg> GetPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<PoliceOrg> result = new List<PoliceOrg>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where zt = '01' and jglx = 'PCS' and GAJGJD is not null and GAJGWD is not null and GAJGJD >= ? and GAJGWD >= ? and GAJGJD <= ? and GAJGWD <= ?";
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
                        PoliceOrg info = new PoliceOrg();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Gajgdm = reader[0].ToString();
                        }
                        //orgid
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajgmc = reader[1].ToString();
                        }
                        //carno
                        if (!reader.IsDBNull(2))
                        {
                            info.Gajgjc = reader[2].ToString();
                        }
                        //sssjmc
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if (x > 0)
                            {
                                info.GajgJD = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if (y > 0)
                            {
                                info.GajgWD = y;
                            }
                        }
                        //ssdwmc
                        if (!reader.IsDBNull(5))
                        {
                            info.Jglx = reader[5].ToString();
                        }

                        if (info.GajgJD > 0 && info.GajgWD > 0 && info.GajgJD >= minX && info.GajgWD >= minY && info.GajgJD <= maxX && info.GajgWD <= maxY)
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
        /// 根据屏幕坐标范围获取派出所机构
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<PoliceOrg> GetNPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<PoliceOrg> result = new List<PoliceOrg>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where zt = '01' and jglx != 'PCS' and GAJGJD is not null and GAJGWD is not null and GAJGJD >= ? and GAJGWD >= ? and GAJGJD <= ? and GAJGWD <= ?";
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
                        PoliceOrg info = new PoliceOrg();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Gajgdm = reader[0].ToString();
                        }
                        //orgid
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajgmc = reader[1].ToString();
                        }
                        //carno
                        if (!reader.IsDBNull(2))
                        {
                            info.Gajgjc = reader[2].ToString();
                        }
                        //sssjmc
                        if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                        {
                            double x, y;
                            Double.TryParse(reader[3].ToString(), out x);
                            if (x > 0)
                            {
                                info.GajgJD = x;
                            }

                            Double.TryParse(reader[4].ToString(), out y);
                            if (y > 0)
                            {
                                info.GajgWD = y;
                            }
                        }
                        //ssdwmc
                        if (!reader.IsDBNull(5))
                        {
                            info.Jglx = reader[5].ToString();
                        }

                        if (info.GajgJD > 0 && info.GajgWD > 0 && info.GajgJD >= minX && info.GajgWD >= minY && info.GajgJD <= maxX && info.GajgWD <= maxY)
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

        public List<PoliceOrg> FindPoliceOrgsBySearch(String exp)
        {
            List<PoliceOrg> result = new List<PoliceOrg>();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(this.zzjgDBConnectBuilder.ConnectionString))
                {
                    //String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where GAJGMC like '%" + exp + "%' or GAJGDM like '%" + exp + "%'";
                    String sql = "select GAJGDM, GAJGMC, GAJGJC, GAJGJD, GAJGWD, JGLX from ZZJGXT.GAJG_BASEINFO t where GAJGMC like '%'||?||'%' or GAJGDM like '%'||?||'%'";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.Parameters.Add(new OleDbParameter("@exp1", OleDbType.VarChar));
                    cmd.Parameters[0].Value = exp;
                    cmd.Parameters.Add(new OleDbParameter("@exp2", OleDbType.VarChar));
                    cmd.Parameters[1].Value = exp;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PoliceOrg info = new PoliceOrg();
                        //GPSID
                        if (!reader.IsDBNull(0))
                        {
                            info.Gajgdm = reader[0].ToString();
                        }
                        //orgid
                        if (!reader.IsDBNull(1))
                        {
                            info.Gajgmc = reader[1].ToString();
                        }
                        //carno
                        if (!reader.IsDBNull(2))
                        {
                            info.Gajgjc = reader[2].ToString();
                        }
                        //sssjmc
                        if (!reader.IsDBNull(3))
                        {
                            info.GajgJD = Convert.ToDouble(reader[3].ToString());
                        }
                        //ssfjmc
                        if (!reader.IsDBNull(4))
                        {
                            info.GajgWD = Convert.ToDouble(reader[4].ToString());
                        }
                        //ssdwmc
                        if (!reader.IsDBNull(5))
                        {
                            info.Jglx = reader[5].ToString();
                        }

                        result.Add(info);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        //public List<PoliceOrg> GetPcsPoliceOrgsByPoly(Point min, Point max)
        //{

        //}

        //public List<PoliceOrg> GetNPcsPoliceOrgsByPoly(Point min, Point max)
        //{

        //}

	}
}
