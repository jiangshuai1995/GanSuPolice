using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.PolySelect;
using Beyon.Domain.GridSelect;
using Beyon.Dao;
using BeyonDB.Client;
using Beyon.Service.GridPlatform.GridSelect;
using Beyon.Service.GridPlatform.PolygonSelect;

namespace Beyon.DataMigrate
{
    /// <summary>
    /// 场所迁移类
    /// </summary>
    class CsMigrate
    {
        private GridSelectService gridService;
        private PolygonSelectService polyService;
        private DBOperate dbOper;

        public CsMigrate(PolygonSelectService polyService, DBOperate dbOper)
        {
            this.polyService = polyService;
            this.dbOper = dbOper;
            this.gridService = new GridSelectService(); //todo 应该把场所详细信息接口复制一份到polyselect下
        }

        public void ExecutePublicCs(List<System.Windows.Point> polygon)
        {
            //获取公共场所总数
            List<PolyCountInfo> csCount = polyService.GetCountInfoByPoly("公共场所", "派出所", polygon);

            Console.Out.WriteLine("开始写入公共场所数据: ");
            foreach (PolyCountInfo ci in csCount)
            {
                List<PolyListInfo> csList = polyService.GetPageListInfoByPoly("公共场所", ci.Name, "派出所", polygon, 1, Convert.ToInt32(ci.Count));

                foreach (PolyListInfo listInfo in csList)
                {
                    CSDetail csDetail = gridService.GetCSDetail(listInfo.ID, ci.Name);

                    BeyonDBParameter param1 = new BeyonDBParameter("csid", BeyonDBType.VarChar);
                    param1.Value = listInfo.ID == null ? string.Empty : listInfo.ID;
                    BeyonDBParameter param2 = new BeyonDBParameter("csmc", BeyonDBType.VarChar);
                    param2.Value = listInfo.Name == null ? string.Empty : listInfo.Name;
                    BeyonDBParameter param3 = new BeyonDBParameter("cstype", BeyonDBType.VarChar);
                    param3.Value = ci.Name == null ? string.Empty : ci.Name;
                    BeyonDBParameter param4 = new BeyonDBParameter("jd", BeyonDBType.VarChar);
                    param4.Value = listInfo.JD == null ? 0 : listInfo.JD;
                    BeyonDBParameter param5 = new BeyonDBParameter("wd", BeyonDBType.VarChar);
                    param5.Value = listInfo.WD == null ? 0 : listInfo.WD;
                    BeyonDBParameter param6 = new BeyonDBParameter("dw", BeyonDBType.VarChar);
                    param6.Value = csDetail.GXDWMC == null ? string.Empty : csDetail.GXDWMC;
                    BeyonDBParameter param7 = new BeyonDBParameter("dz", BeyonDBType.VarChar);
                    param7.Value = csDetail.DZ == null ? string.Empty : csDetail.DZ;
                    dbOper.ExecuteScalar("insert into cs_ggcs (csid, csmc, cstype, jd, wd, gxdwmc, dz) values(?, ?, ?, ?, ?, ?, ?)", new BeyonDBParameter[]{param1, param2, param3, param4, param5, param6, param7});
                }
            }
            Console.Out.WriteLine("完成公共场所数据写入.");
        }

        /// <summary>
        /// 重点单位迁移
        /// </summary>
        /// <param name="polygon"></param>
        public void ExecuteKeyCs(List<System.Windows.Point> polygon)
        {
            //获取公共场所总数
            List<PolyCountInfo> csCount = polyService.GetCountInfoByPoly("重点单位", "派出所", polygon);

            Console.Out.WriteLine("开始写入重点单位数据: ");
            foreach (PolyCountInfo ci in csCount)
            {
                List<PolyListInfo> csList = polyService.GetPageListInfoByPoly("重点单位", ci.Name, "派出所", polygon, 1, Convert.ToInt32(ci.Count));

                foreach (PolyListInfo listInfo in csList)
                {
                    CSDetail csDetail = gridService.GetCSDetail(listInfo.ID, ci.Name);

                    BeyonDBParameter param1 = new BeyonDBParameter("csid", BeyonDBType.VarChar);
                    param1.Value = listInfo.ID == null ? string.Empty : listInfo.ID;
                    BeyonDBParameter param2 = new BeyonDBParameter("csmc", BeyonDBType.VarChar);
                    param2.Value = listInfo.Name == null ? string.Empty : listInfo.Name;
                    BeyonDBParameter param3 = new BeyonDBParameter("cstype", BeyonDBType.VarChar);
                    param3.Value = ci.Name == null ? string.Empty : ci.Name;
                    BeyonDBParameter param4 = new BeyonDBParameter("jd", BeyonDBType.VarChar);
                    param4.Value = listInfo.JD == null ? 0 : listInfo.JD;
                    BeyonDBParameter param5 = new BeyonDBParameter("wd", BeyonDBType.VarChar);
                    param5.Value = listInfo.WD == null ? 0 : listInfo.WD;
                    BeyonDBParameter param6 = new BeyonDBParameter("dw", BeyonDBType.VarChar);
                    param6.Value = csDetail.GXDWMC == null ? string.Empty : csDetail.GXDWMC;
                    BeyonDBParameter param7 = new BeyonDBParameter("dz", BeyonDBType.VarChar);
                    param7.Value = csDetail.DZ == null ? string.Empty : csDetail.DZ;
                    dbOper.ExecuteScalar("insert into cs_zddw (csid, csmc, cstype, jd, wd, gxdwmc, dz) values(?, ?, ?, ?, ?, ?, ?)", new BeyonDBParameter[] { param1, param2, param3, param4, param5, param6, param7 });
                }
            }
            Console.Out.WriteLine("完成重点单位数据写入.");
        }

        /// <summary>
        /// 特种场所迁移
        /// </summary>
        /// <param name="polygon"></param>
        public void ExecuteSpecialCs(List<System.Windows.Point> polygon)
        {
            //获取公共场所总数
            List<PolyCountInfo> csCount = polyService.GetCountInfoByPoly("特种场所", "派出所", polygon);

            Console.Out.WriteLine("开始写入特种场所数据: ");
            foreach (PolyCountInfo ci in csCount)
            {
                List<PolyListInfo> csList = polyService.GetPageListInfoByPoly("特种场所", ci.Name, "派出所", polygon, 1, Convert.ToInt32(ci.Count));

                foreach (PolyListInfo listInfo in csList)
                {
                    CSDetail csDetail = gridService.GetCSDetail(listInfo.ID, ci.Name);

                    BeyonDBParameter param1 = new BeyonDBParameter("csid", BeyonDBType.VarChar);
                    param1.Value = listInfo.ID == null ? string.Empty : listInfo.ID;
                    BeyonDBParameter param2 = new BeyonDBParameter("csmc", BeyonDBType.VarChar);
                    param2.Value = listInfo.Name == null ? string.Empty : listInfo.Name;
                    BeyonDBParameter param3 = new BeyonDBParameter("cstype", BeyonDBType.VarChar);
                    param3.Value = ci.Name == null ? string.Empty : ci.Name;
                    BeyonDBParameter param4 = new BeyonDBParameter("jd", BeyonDBType.VarChar);
                    param4.Value = listInfo.JD == null ? 0 : listInfo.JD;
                    BeyonDBParameter param5 = new BeyonDBParameter("wd", BeyonDBType.VarChar);
                    param5.Value = listInfo.WD == null ? 0 : listInfo.WD;
                    BeyonDBParameter param6 = new BeyonDBParameter("dw", BeyonDBType.VarChar);
                    param6.Value = csDetail.GXDWMC == null ? string.Empty : csDetail.GXDWMC;
                    BeyonDBParameter param7 = new BeyonDBParameter("dz", BeyonDBType.VarChar);
                    param7.Value = csDetail.DZ == null ? string.Empty : csDetail.DZ;
                    dbOper.ExecuteScalar("insert into cs_tzcs (csid, csmc, cstype, jd, wd, gxdwmc, dz) values(?, ?, ?, ?, ?, ?, ?)", new BeyonDBParameter[] { param1, param2, param3, param4, param5, param6, param7 });
                }
            }
            Console.Out.WriteLine("完成特种数据写入.");
        }
    }
}
