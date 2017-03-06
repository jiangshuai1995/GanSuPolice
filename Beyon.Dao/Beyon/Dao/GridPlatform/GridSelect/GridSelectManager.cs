using Beyon.Common;
using Beyon.Domain.GridSelect;
using Beyon.Domain.PolySelect;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Dao.GridPlatform.GridSelect
{
    public class GridSelectManager
    {
        /// <summary>
        /// 配置文件
        /// </summary>
        private const string configFileName = "webservice.config";

        public string GetAnJianDetail(string ajType, string ajid)
        {
            switch (ajType)
            {
                case "jj":
                    return (ConfigHelper.GetValueByKey("webservice.config", "案件-接触警详细信息") + ajid);

                case "xsla":
                    return (ConfigHelper.GetValueByKey("webservice.config", "案件-刑事案件详细信息") + ajid);

                case "zala":
                    return (ConfigHelper.GetValueByKey("webservice.config", "案件-治安案件详细信息") + ajid);
            }
            throw new ArgumentException("传入案件类型参数不正确");
        }

        public CSDetail GetCSDetail(string csId, string type)
        {
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            CSDetail csd = new CSDetail();
            switch (type)
            {
                case "娱乐场所":
                    type = "CS_YLCS_PT";
                    
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type,csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[1].ToString();
                                    csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[0].ToString();
                                    
                        
                                }
                             }
                        }
                    }
                    return csd;
                case "旅店":
                    type = "CS_ZSFW_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type,csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    csd.GXDWMC = reader[0].ToString();
                                    csd.MC = reader[1].ToString();
                                }
                             }
                        }
                    }
                    return csd;
                case "网吧":
                    type = "CS_HLWSWFW_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    csd.GXDWMC = reader[4].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "医院":
                    type = "DWXX_YLWS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    csd.GXDWMC = reader[4].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "学校":
                    type = "DWXX_JYJG_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[1].ToString();
                                    csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[0].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "金融证券":
                    type = "DWXX_JRZQ_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    csd.GXDWMC = reader[4].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "危险品存放处":
                    type = "DWXX_WXPCFDDW_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    //csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "党政机关":
                    type = "DWXX_DXJG_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    //csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "寺观教堂":
                    type = "CS_ZJCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[1].ToString();
                                    csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[0].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "公共活动场所":
                    type = "CS_GGHDCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    csd.GXDWMC = reader[0].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "商贸市场":
                    type = "CS_SMCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    csd.GXDWMC = reader[0].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "交通场所":
                    type = "CS_JTCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[1].ToString();
                                    //csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[0].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "体育场所":
                    type = "CS_TYCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[2].ToString();
                                    csd.GXDWMC = reader[0].ToString();
                                    csd.MC = reader[1].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "旅游场所":
                    type = "CS_LYCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[1].ToString();
                                    //csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[0].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "居民服务场所":
                    type = "CS_JMFWCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[1].ToString();
                                    csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[0].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                case "文化场所":
                    type = "CS_WHCS_PT";
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type, csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csd.DZ = reader[1].ToString();
                                    csd.GXDWMC = reader[3].ToString();
                                    csd.MC = reader[0].ToString();

                                }
                            }
                        }
                    }
                    return csd;
                default:
                    throw new ArgumentNullException("二级菜单不正确");
            }

            //String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //CSDetail csd = new CSDetail();

            ////2.创建数据库连接
            //using (var connection = new NpgsqlConnection(connect))
            //{
            //    //3.打开数据库连接
            //    if (connection.State == System.Data.ConnectionState.Closed)
            //        connection.Open();

            //    //4.创建数据库查询命令
            //    using (var command = connection.CreateCommand())
            //    {
            //        //5.赋予查询语句
            //        command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type,csId);

            //        //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {

            //                csd.DZ = reader[1].ToString();
            //                csd.GXDWMC = reader[3].ToString();
            //                csd.MC = reader[0].ToString();
                        
            //            }
            //        }
            //    }
            //}
            //return csd;
        }

        public CSDetailWithPic GetCSDetailWithPic(string csId, string type) 
        {
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            CSDetailWithPic csdw = new CSDetailWithPic();

            switch (type) 
            { 
                case "寺观教堂":
                    type = "CS_ZJCS_PT";
                    
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
                            command.CommandText = String.Format("SELECT * FROM dbo.\"csgl_{0}\" WHERE objectid='{1}'", type,csId);

                            //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    csdw.DZ = reader[2].ToString();
                                    csdw.GXDWMC = reader[0].ToString();
                                    csdw.MC = reader[1].ToString();
                                    csdw.zp = reader[6].ToString();
                                    csdw.PGIS_GXDW = reader[4].ToString();

                                    
                        
                                }
                             }
                        }
                    }
                    return csdw;
                default:
                    return csdw;

            }
        
        }

        public BuildingDetail GetBuildingDetail(string fwId) 
        {
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");
            BuildingDetail bd = new BuildingDetail();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.fwgldetail WHERE \"OBJECTID\"='{0}'", fwId);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            bd.JZWMC = reader[3].ToString();
                            bd.ROOMCOUNT = reader[1].ToString();
                            bd.JZWBZCS = reader[2].ToString();
                        }
                    }
                }
            }
            return bd;

        }

        public ZDRenKou GetZDRenKouDetail(string sfzh)
        {
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");
            ZDRenKou zdrk = new ZDRenKou();
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.zdrkdetail WHERE sfzh ='{0}'", sfzh);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            zdrk.XM = reader[0].ToString();
                            zdrk.SFZH = reader[1].ToString();
                            //zdrk.CH= reader[2].ToString();
                            zdrk.XB = reader[3].ToString();
                            zdrk.ZDRYXL = reader[4].ToString();
                            zdrk.HJDXZ = reader[5].ToString();
                            //zdrk.ZDYJ = reader[6].ToString();
                            zdrk.zp = reader[7].ToString();
                        }
                    }
                }
            }
            return zdrk;
        }

        public RenKou GetRenKouDetail(string sfzh) 
        {
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");
            RenKou rk = new RenKou();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.rkgldetail WHERE gmsfhm='{0}'", sfzh);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rk.XM = reader[2].ToString();
                            rk.XB = reader[0].ToString();
                            rk.SFZH = reader[1].ToString();
                            rk.zp = reader[3].ToString();
                        }
                    }
                }
            }
            return rk;
        }

        public PoliceManDetail GetPoliceManDetail(string jyId) 
        {
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");
            PoliceManDetail pmd = new PoliceManDetail();
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
                    command.CommandText = String.Format("SELECT * FROM dbo.jygl2 WHERE gmsfzhm='{0}'", jyId);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pmd.XM = reader[0].ToString();
                            pmd.GMSFZHM = reader[1].ToString();
                            pmd.XB = reader[2].ToString();
                            pmd.CSRQ = reader[3].ToString();
                            pmd.DW_CODE = reader[5].ToString();
                            pmd.MZ = reader[4].ToString();
                            pmd.GRSF = reader[6].ToString();
                            pmd.MZ_NAME = reader[7].ToString();
                            pmd.GRSF_NAME = reader[8].ToString();
                            pmd.DW_NAME = reader[10].ToString();
                            pmd.IMAGE = reader[11].ToString();
                            pmd.JH = reader[12].ToString();
                        }
                    }
                }
            }
            return pmd;
        }
        
    }
}
