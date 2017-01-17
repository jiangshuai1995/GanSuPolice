using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeyonDB.Client;
using Beyon.Dao;
using Beyon.Domain.PolySelect;
using Beyon.Service.GridPlatform.PolygonSelect;
using Beyon.WebService.GridPlatform.PolySelect;

namespace Beyon.DataMigrate
{
    /// <summary>
    /// 监所迁移类
    /// </summary>
    class PrisonMigrate
    {
        private PolygonSelectService polyService;
        private PolySelectManager polyManager = new PolySelectManager();
        private DBOperate dbOper;

        public PrisonMigrate(PolygonSelectService polyService, DBOperate dbOper)
        {
            this.polyService = polyService;
            this.dbOper = dbOper;
        }

        public void Execute(List<System.Windows.Point> polygon)
        {
            //获取案件总数
            List<PolyCountInfo> jsCount = polyService.GetCountInfoByPoly("监所管理", "派出所", polygon);

            foreach (PolyCountInfo js in jsCount)
            {
                List<PolyListInfo> jsList = polyService.GetListInfoByPoly("监所管理", js.Name, "派出所", polygon);

                foreach (PolyListInfo listInfo in jsList)
                {
                    //获取监所详细信息
                    string jscode = listInfo.ID.Split(new char[]{'|'})[0];
                    if(jscode.Equals(string.Empty))
                    {
                        continue;
                    }

                    JSDetail jsDetail = polyService.GetJSDetailByPoly(jscode);

                    BeyonDBParameter param1 = new BeyonDBParameter("jscode", BeyonDBType.VarChar);
                    param1.Value = jscode;
                    BeyonDBParameter param2 = new BeyonDBParameter("jsmc", BeyonDBType.VarChar);
                    param2.Value = listInfo.Name == null ? string.Empty : listInfo.Name;
                    BeyonDBParameter param3 = new BeyonDBParameter("gajgxz", BeyonDBType.VarChar);
                    param3.Value = jsDetail.GAJGXZ == null ? string.Empty : jsDetail.GAJGXZ;
                    BeyonDBParameter param4 = new BeyonDBParameter("dwld_xm", BeyonDBType.VarChar);
                    param4.Value = jsDetail.DWLD_XM == null ? string.Empty : jsDetail.DWLD_XM;
                    BeyonDBParameter param5 = new BeyonDBParameter("dwld_lxdh", BeyonDBType.VarChar);
                    param5.Value = jsDetail.DWLD_LXDH == null ? string.Empty : jsDetail.DWLD_LXDH;
                    BeyonDBParameter param6 = new BeyonDBParameter("rs", BeyonDBType.VarChar);
                    param6.Value = jsDetail.RS == null ? string.Empty : jsDetail.RS;
                    BeyonDBParameter param7 = new BeyonDBParameter("jd", BeyonDBType.VarChar);
                    param7.Value = listInfo.JD == null ? 0 : listInfo.JD;
                    BeyonDBParameter param8 = new BeyonDBParameter("wd", BeyonDBType.VarChar);
                    param8.Value = listInfo.WD == null ? 0 : listInfo.WD;
                    BeyonDBParameter param9 = new BeyonDBParameter("zp", BeyonDBType.VarChar);
                    param9.Value = jsDetail.zp == null ? string.Empty : jsDetail.zp;
                    BeyonDBParameter param10 = new BeyonDBParameter("jstype", BeyonDBType.VarChar);
                    param10.Value = js.Name == null ? string.Empty : js.Name;

                    //此处应先清空案件表，再插入。因这里原始.net api事务不好处理，请先手工清空表.
                    dbOper.ExecuteScalar("insert into prison (jscode, jsmc, gajgxz, dwld_xm, dwld_lxdh, rs, jd, wd, zp, jstype) values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", new BeyonDBParameter[] { param1, param2, param3, param4, param5, param6, param7, param8, param9, param10});

                    ////获取监所内服刑人员，并写入监所人员表
                    //List<JSPerson> jpList =  polyService.GetJSPersonListByPoly(js.Name, listInfo.ID);

                    //foreach(JSPerson jp in jpList)
                    //{
                    //    JSPersonDetail jpDetail = polyService.GetJSPersonDetailByPoly(jp.JBXXBH, js.Name);

                    //    //写入监所服刑人员信息
                    //    dbOper.ExecuteScalar("insert into anjian (ajid, ajmc, ajtype) values(?, ?, ?)", new BeyonDBParameter[] { param1, param2, param3 });

                    //}
                }
            }
        }
    }
}
