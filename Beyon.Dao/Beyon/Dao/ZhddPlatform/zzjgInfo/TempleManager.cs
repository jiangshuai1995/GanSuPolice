using Beyon.Common;
using Beyon.Domain.Zhdd.zjjg;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Dao.ZhddPlatform.zzjgInfo
{
    public class TempleManager
    {
        public List<Temple> GetAllTempleByExtent(double minX, double minY, double maxX, double maxY)
        {
            List<Temple> tlist = new List<Temple>();
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
                    command.CommandText = String.Format("SELECT * FROM  dbo.csgl_zjcsinfo WHERE zjcsjd>='{0}' AND zjcsjd<='{1}' AND zjcswd>='{2}'  AND zjcswd<='{3}' ",minX,maxX,minY,maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Temple t = new Temple();
                            t.Bh = reader[0].ToString();
                            t.Csmc = reader[1].ToString();
                            t.Xxdz = reader[2].ToString();
                            t.Xqpcs = reader[3].ToString();
                            t.Jyqk = reader[4].ToString();
                            t.Cszpid = reader[5].ToString();
                            t.ZjcsJd = double.Parse(reader[6].ToString());
                            t.ZjcsWd = double.Parse(reader[7].ToString());
                            t.Key_zd = reader[8].ToString();
                            tlist.Add(t);
                        }
                    }
                }
            }
            return tlist;
        }
    }
}
