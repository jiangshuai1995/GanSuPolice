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
    /// <summary>
    /// 网吧信息管理
    /// </summary>
    public class CyberBarManager
    {
        public List<CyberBar> GetAllWBs()
        { 
            List<CyberBar> blist=new List<CyberBar>();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.wb_info ");

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CyberBar wb = new CyberBar();
                            wb.Wb_code = reader[0].ToString();
                            wb.Gajg_key = reader[1].ToString();
                            wb.Wbmc = reader[2].ToString();
                            wb.Wbxz = reader[3].ToString();
                            wb.Wbjd = double.Parse( reader[4].ToString());
                            wb.Wbwd=double.Parse(reader[5].ToString());
                            wb.Fzr_xm=reader[6].ToString();
                            wb.Fzr_sfzh=reader[7].ToString();
                            wb.Lxdh = reader[8].ToString();
                            wb.Wb_code_old = reader[9].ToString();
                            blist.Add(wb);
                        }
                    }
                }
            }
            return blist;  
        }

        /// <summary>
        /// 根据网吧名称或网吧编号查询
        /// </summary>
        /// <param name="exp">网吧名称</param>
        /// <returns></returns>
        public List<CyberBar> FindCyberBarsBySearch(string exp)
        {
            List<CyberBar> blist = new List<CyberBar>();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.wb_info WHERE \"WBMC\" ='{0}' or \"WB_CODE\"='{0}' ",exp);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CyberBar wb = new CyberBar();
                            wb.Wb_code = reader[0].ToString();
                            wb.Gajg_key = reader[1].ToString();
                            wb.Wbmc = reader[2].ToString();
                            wb.Wbxz = reader[3].ToString();
                            wb.Wbjd = double.Parse(reader[4].ToString());
                            wb.Wbwd = double.Parse(reader[5].ToString());
                            wb.Fzr_xm = reader[6].ToString();
                            wb.Fzr_sfzh = reader[7].ToString();
                            wb.Lxdh = reader[8].ToString();
                            wb.Wb_code_old = reader[9].ToString();
                            blist.Add(wb);
                        }
                    }
                }
            }
            return blist;
        }

        /// <summary>
        /// 框选网吧范围
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<CyberBar> GetAllWBsByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<CyberBar> blist = new List<CyberBar>();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.wb_info WHERE \"WBJD\" >='{0}'  AND \"WBJD\"<='{1}' AND \"WBWD\">='{2}'  AND \"WBWD\"<='{3}'", minX,maxX,minY,maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CyberBar wb = new CyberBar();
                            wb.Wb_code = reader[0].ToString();
                            wb.Gajg_key = reader[1].ToString();
                            wb.Wbmc = reader[2].ToString();
                            wb.Wbxz = reader[3].ToString();
                            wb.Wbjd = double.Parse(reader[4].ToString());
                            wb.Wbwd = double.Parse(reader[5].ToString());
                            wb.Fzr_xm = reader[6].ToString();
                            wb.Fzr_sfzh = reader[7].ToString();
                            wb.Lxdh = reader[8].ToString();
                            wb.Wb_code_old = reader[9].ToString();
                            blist.Add(wb);
                        }
                    }
                }
            }
            return blist;
        }
        
    }
}
