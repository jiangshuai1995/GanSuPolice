using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Service.GridPlatform.PolygonSelect;
using Beyon.Domain.PolySelect;
using Beyon.Domain.GridSelect;
using System.Windows;
using Beyon.Dao;
using BeyonDB.Client;

namespace Beyon.DataMigrate
{
    /// <summary>
    /// 案件迁移类
    /// </summary>
    class AnJianMigrate
    {
        private PolygonSelectService polyService;
        private DBOperate dbOper;

        /// <summary>
        /// 案件统计信息
        /// </summary>
        public List<PolyCountInfo> CountInfo
        {
            get;
            set;
        }

        public AnJianMigrate(PolygonSelectService polyService, DBOperate dbOper)
        {
            this.polyService = polyService;
            this.dbOper = dbOper;
        }

        public void Execute(List<System.Windows.Point> polygon)
        {
            //获取案件总数
            List<PolyCountInfo> ajCount = polyService.GetCountInfoByPoly("案件管理", "派出所", polygon);

            foreach (PolyCountInfo ci in ajCount)
            {
                List<PolyListInfo> ajList = polyService.GetPageListInfoByPoly("案件管理", ci.Name, "派出所", polygon, 1, Convert.ToInt32(ci.Count));
                //List<PolyListInfo> ajList = polyService.GetListInfoByPoly("案件管理", ci.Name, "派出所", polygon);

                foreach(PolyListInfo listInfo in ajList)
                {
                    BeyonDBParameter param1 = new BeyonDBParameter("ajid", BeyonDBType.VarChar);
                    param1.Value = listInfo.ID == null ? string.Empty : listInfo.ID;
                    BeyonDBParameter param2 = new BeyonDBParameter("ajmc", BeyonDBType.VarChar);
                    param2.Value = listInfo.Name == null ? string.Empty : listInfo.Name;
                    BeyonDBParameter param3 = new BeyonDBParameter("ajtype", BeyonDBType.VarChar);
                    param3.Value = ci.Name == null ? string.Empty : ci.Name;

                    //此处应先清空案件表，再插入。因这里原始.net api事务不好处理，请先手工清空表.
                    dbOper.ExecuteScalar("insert into anjian (ajid, ajmc, ajtype) values(?, ?, ?)", new BeyonDBParameter[]{param1, param2, param3});
                }    
            }
        }
    }
}
