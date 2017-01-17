using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Service.GridPlatform.PolygonSelect;
using Beyon.Service.GridPlatform.GridSelect;
using Beyon.Dao;
using Beyon.Domain.PolySelect;
using Beyon.Domain.GridSelect;
using BeyonDB.Client;

namespace Beyon.DataMigrate
{
    /// <summary>
    /// 警员迁移类
    /// </summary>
    class PoliceManMigrate
    {
        private PolygonSelectService polyService;
        private DBOperate dbOper;
        private GridSelectService gridService;

        public PoliceManMigrate(PolygonSelectService polyService, GridSelectService gridService, DBOperate dbOper)
        {
            this.polyService = polyService;
            this.dbOper = dbOper;
            this.gridService = gridService;
        }

        public void Execute(List<System.Windows.Point> polygon)
        {
            //获取警员总数
            List<PolyCountInfo> jlCount = polyService.GetCountInfoByPoly("勤务信息", "派出所", polygon);

            foreach (PolyCountInfo ci in jlCount)
            {
                if(ci.Name.Equals("警员"))
                {
                     List<PolyListInfo> jlList = polyService.GetPageListInfoByPoly("勤务信息", ci.Name, "派出所", polygon, 1, Convert.ToInt32(ci.Count));
                     
                     foreach (PolyListInfo listInfo in jlList)
                     {
                         //获取警员详细信息
                         PoliceManDetail pmDetail = gridService.GetPoliceManDetail(listInfo.ID); //todo 目前无法访问 指挥调度平台

                         //todo
                         BeyonDBParameter param1 = new BeyonDBParameter("ajid", BeyonDBType.VarChar);
                         param1.Value = listInfo.ID == null ? string.Empty : listInfo.ID;
                         BeyonDBParameter param2 = new BeyonDBParameter("ajmc", BeyonDBType.VarChar);
                         param2.Value = listInfo.Name == null ? string.Empty : listInfo.Name;
                         BeyonDBParameter param3 = new BeyonDBParameter("ajtype", BeyonDBType.VarChar);
                         param3.Value = ci.Name == null ? string.Empty : ci.Name;
                     
                         //插入警员信息到警员表 policeman
                         dbOper.ExecuteScalar("insert into policeman (ajid, ajmc, ajtype) values(?, ?, ?)", new BeyonDBParameter[] { param1, param2, param3 });
                     }
                }
            }
        }
    }
}
