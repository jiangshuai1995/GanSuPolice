using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Common;
using Beyon.Domain;
using Beyon.Domain.Zhdd.zjjg;
using Npgsql;

namespace Beyon.Dao.ZhddPlatform.zzjgInfo
{
    public class PoliceOrgManager
    {
        public List<PoliceOrg> GetAllPoliceOrgs()
        {
            List<PoliceOrg> plist = new List<PoliceOrg>();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.\"GAJG_BASEINFO\" ");

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceOrg p = new PoliceOrg();
                            p.Gajgmc = reader[1].ToString();
                            p.Gajgdm = reader[0].ToString();
                            p.Dhhm = reader[2].ToString();
                            p.Dwld_xm = reader[6].ToString();
                            p.GajgJD = double.Parse(reader[3].ToString());
                            p.GajgWD = double.Parse(reader[4].ToString());
                            p.Dwld_sfzh = reader[7].ToString();
                            p.Dwld_lxdh = reader[8].ToString();
                            p.Jglx = reader[5].ToString();
                            p.Gajgjc = reader[2].ToString();
                            p.Gajgxz = reader[9].ToString();
                            plist.Add(p);
                        }
                    }
                }
            }
            return plist;
        
        }

        public List<PoliceOrg> GetAllPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<PoliceOrg> plist = new List<PoliceOrg>();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.\"GAJG_BASEINFO\"  WHERE \"GAJGJD\">='{0}' AND \"GAJGJD\"<='{1}' AND \"GAJGWD\">='{2}' AND \"GAJGWD\"<='{3}' ",minX,maxX,minY,maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceOrg p = new PoliceOrg();
                            p.Gajgmc = reader[1].ToString();
                            p.Gajgdm = reader[0].ToString();
                            p.Dhhm = reader[2].ToString();
                            p.Dwld_xm = reader[6].ToString();
                            p.GajgJD = double.Parse(reader[3].ToString());
                            p.GajgWD = double.Parse(reader[4].ToString());
                            p.Dwld_sfzh = reader[7].ToString();
                            p.Dwld_lxdh = reader[8].ToString();
                            p.Jglx = reader[5].ToString();
                            p.Gajgjc = reader[2].ToString();
                            p.Gajgxz = reader[9].ToString();
                            plist.Add(p);
                        }
                    }
                }
            }
            return plist;
        }

        public List<PoliceOrg> GetPcsPoliceOrgs()
        {
            List<PoliceOrg> plist = new List<PoliceOrg>();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.\"GAJG_BASEINFO\" WHERE \"JGLX\"='PCS' ");

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceOrg p = new PoliceOrg();
                            p.Gajgmc = reader[1].ToString();
                            p.Gajgdm = reader[0].ToString();
                            p.Dhhm = reader[2].ToString();
                            p.Dwld_xm = reader[6].ToString();
                            p.GajgJD = double.Parse(reader[3].ToString());
                            p.GajgWD = double.Parse(reader[4].ToString());
                            p.Dwld_sfzh = reader[7].ToString();
                            p.Dwld_lxdh = reader[8].ToString();
                            p.Jglx = reader[5].ToString();
                            p.Gajgjc = reader[2].ToString();
                            p.Gajgxz = reader[9].ToString();
                            plist.Add(p);
                        }
                    }
                }
            }
            return plist;
        }

        public List<PoliceOrg> GetPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<PoliceOrg> plist = new List<PoliceOrg>();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.\"GAJG_BASEINFO\" WHERE \"JGLX\"='PCS' AND  \"GAJGJD\">='{0}' AND \"GAJGJD\"<='{1}' AND \"GAJGWD\">='{2}' AND \"GAJGWD\"<='{3}' ",minX,maxX,minY,maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceOrg p = new PoliceOrg();
                            p.Gajgmc = reader[1].ToString();
                            p.Gajgdm = reader[0].ToString();
                            p.Dhhm = reader[2].ToString();
                            p.Dwld_xm = reader[6].ToString();
                            p.GajgJD = double.Parse(reader[3].ToString());
                            p.GajgWD = double.Parse(reader[4].ToString());
                            p.Dwld_sfzh = reader[7].ToString();
                            p.Dwld_lxdh = reader[8].ToString();
                            p.Jglx = reader[5].ToString();
                            p.Gajgjc = reader[2].ToString();
                            p.Gajgxz = reader[9].ToString();
                            plist.Add(p);
                        }
                    }
                }
            }
            return plist;
        }

        public List<PoliceOrg> GetNPcsPoliceOrgs()
        {
            List<PoliceOrg> plist = new List<PoliceOrg>();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.\"GAJG_BASEINFO\" WHERE \"JGLX\"!='PCS' ");

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceOrg p = new PoliceOrg();
                            p.Gajgmc = reader[1].ToString();
                            p.Gajgdm = reader[0].ToString();
                            p.Dhhm = reader[2].ToString();
                            p.Dwld_xm = reader[6].ToString();
                            p.GajgJD = double.Parse(reader[3].ToString());
                            p.GajgWD = double.Parse(reader[4].ToString());
                            p.Dwld_sfzh = reader[7].ToString();
                            p.Dwld_lxdh = reader[8].ToString();
                            p.Jglx = reader[5].ToString();
                            p.Gajgjc = reader[2].ToString();
                            p.Gajgxz = reader[9].ToString();
                            plist.Add(p);
                        }
                    }
                }
            }
            return plist;
        }

        public List<PoliceOrg> GetNPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<PoliceOrg> plist = new List<PoliceOrg>();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.\"GAJG_BASEINFO\" WHERE \"JGLX\"!='PCS' AND  \"GAJGJD\">='{0}' AND \"GAJGJD\"<='{1}' AND \"GAJGWD\">='{2}' AND \"GAJGWD\"<='{3}' ", minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceOrg p = new PoliceOrg();
                            p.Gajgmc = reader[1].ToString();
                            p.Gajgdm = reader[0].ToString();
                            p.Dhhm = reader[2].ToString();
                            p.Dwld_xm = reader[6].ToString();
                            p.GajgJD = double.Parse(reader[3].ToString());
                            p.GajgWD = double.Parse(reader[4].ToString());
                            p.Dwld_sfzh = reader[7].ToString();
                            p.Dwld_lxdh = reader[8].ToString();
                            p.Jglx = reader[5].ToString();
                            p.Gajgjc = reader[2].ToString();
                            p.Gajgxz = reader[9].ToString();
                            plist.Add(p);
                        }
                    }
                }
            }
            return plist;
        }

        public List<PoliceOrg> FindPoliceOrgsBySearch(string exp)
        {
            List<PoliceOrg> plist = new List<PoliceOrg>();
            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.\"GAJG_BASEINFO\" WHERE \"GAJGMC\"='{0}' OR \"GAJGDM\"='{0}'  ",exp);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PoliceOrg p = new PoliceOrg();
                            p.Gajgmc = reader[1].ToString();
                            p.Gajgdm = reader[0].ToString();
                            p.Dhhm = reader[2].ToString();
                            p.Dwld_xm = reader[6].ToString();
                            p.GajgJD = double.Parse(reader[3].ToString());
                            p.GajgWD = double.Parse(reader[4].ToString());
                            p.Dwld_sfzh = reader[7].ToString();
                            p.Dwld_lxdh = reader[8].ToString();
                            p.Jglx = reader[5].ToString();
                            p.Gajgjc = reader[2].ToString();
                            p.Gajgxz = reader[9].ToString();
                            plist.Add(p);
                        }
                    }
                }
            }
            return plist;
        }
    }
}
