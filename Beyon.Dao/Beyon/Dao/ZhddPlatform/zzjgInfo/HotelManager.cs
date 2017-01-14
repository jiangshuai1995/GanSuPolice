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
    public class HotelManager
    {
        public List<Hotel> GetAllHotels()
        {
            List<Hotel> hlist = new List<Hotel>();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_CS_ZSFW_PT\" ");

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hotel h = new Hotel();
                            h.Ld_code = reader[3].ToString();
                            h.Ldmc= reader[1].ToString();
                            h.Gajg_key = reader[0].ToString();
                            h.Fzr_xm = reader[7].ToString();
                            h.LdJD = double.Parse(reader[5].ToString());
                            h.LdWD = double.Parse(reader[6].ToString());
                            h.Lxdh = reader[4].ToString();
                            h.Fzr_sfzh = reader[8].ToString();
                            h.Ldxz = reader[2].ToString();
                            h.Ld_code_old = reader[9].ToString();
                            hlist.Add(h);
                        }
                    }
                }
            }
            return hlist;  
        }

        /// <summary>
        /// 根据旅店名称或代码查询
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<Hotel> FindHotelsBySearch(string exp)
        {
            List<Hotel> hlist = new List<Hotel>();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_CS_ZSFW_PT\"  WHERE mc='{0}'  or objectid='{0}' ",exp);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hotel h = new Hotel();
                            h.Ld_code = reader[3].ToString();
                            h.Ldmc = reader[1].ToString();
                            h.Gajg_key = reader[0].ToString();
                            h.Fzr_xm = reader[7].ToString();
                            h.LdJD = double.Parse(reader[5].ToString());
                            h.LdWD = double.Parse(reader[6].ToString());
                            h.Lxdh = reader[4].ToString();
                            h.Fzr_sfzh = reader[8].ToString();
                            h.Ldxz = reader[2].ToString();
                            h.Ld_code_old = reader[9].ToString();
                            hlist.Add(h);
                        }
                    }
                }
            }
            return hlist;  
        }

        public List<Hotel> GetAllHotelsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<Hotel> hlist = new List<Hotel>();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_CS_ZSFW_PT\"  WHERE jd>='{0}' AND jd<='{1}' AND wd>='{2}' AND wd <='{3}' ", minX,maxX,minY,maxX);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hotel h = new Hotel();
                            h.Ld_code = reader[3].ToString();
                            h.Ldmc = reader[1].ToString();
                            h.Gajg_key = reader[0].ToString();
                            h.Fzr_xm = reader[7].ToString();
                            h.LdJD = double.Parse(reader[5].ToString());
                            h.LdWD = double.Parse(reader[6].ToString());
                            h.Lxdh = reader[4].ToString();
                            h.Fzr_sfzh = reader[8].ToString();
                            h.Ldxz = reader[2].ToString();
                            h.Ld_code_old = reader[9].ToString();
                            hlist.Add(h);
                        }
                    }
                }
            }
            return hlist;  
        }
    }
}
