namespace Beyon.Service.GridPlatform.GridSelect
{
    using Beyon.Domain.GridSelect;
    using Beyon.WebService.GridPlatform.GridSelect;
    using System;
    using System.Collections.Generic;
    using Beyon.Dao.GridPlatform.GridSelect;

    public class GridSelectService
    {
        private Beyon.WebService.GridPlatform.GridSelect.GridSelectManager gridSelectManager = new Beyon.WebService.GridPlatform.GridSelect.GridSelectManager();
        private Beyon.Dao.GridPlatform.GridSelect.GridSelectManager gs = new Dao.GridPlatform.GridSelect.GridSelectManager();

        public List<GridInfo> GetAllGrids()
        {
            return this.gridSelectManager.GetAllGrids();
        }

        private Dictionary<string, long> GetAnJianCount(string gridId)
        {
            return this.gridSelectManager.GetAnJianCount(gridId);
        }

        public string GetAnJianDetail(string ajType, string ajid)
        {
            return this.gridSelectManager.GetAnJianDetail(ajType, ajid);
        }

        public List<Building> GetBuildingByRenKou(string sfzh)
        {
            return this.gridSelectManager.GetBuildingByRenKou(sfzh);
        }

        private GridBuilding GetBuildingCount(string gridId)
        {
            return this.gridSelectManager.GetBuildingCount(gridId);
        }

        public BuildingDetail GetBuildingDetail(string fwId)
        {
            return gs.GetBuildingDetail(fwId);
            //return this.gridSelectManager.GetBuildingDetail(fwId);
        }

        public List<ChangSuo> GetChangSuoList(string gridId, string type)
        {
            return this.gridSelectManager.GetChangSuoList(gridId, type);
        }

        public List<GridInfo> GetChildGrids(string gridId, string type)
        {
            return this.gridSelectManager.GetChildGrids(gridId, type);
        }

        public List<GridCountInfo> GetCountInfoByGrid(string gridId, string firstClass)
        {
            List<GridCountInfo> list = new List<GridCountInfo>();
            switch (firstClass)
            {
                case "人口管理":
                {
                    Dictionary<string, long> renKouCount = this.gridSelectManager.GetRenKouCount(gridId);
                    foreach (KeyValuePair<string, long> pair in renKouCount)
                    {
                        GridCountInfo item = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(item);
                    }
                    return list;
                }
                case "房屋管理":
                {
                    GridSummary summaryInfo = this.GetSummaryInfo(gridId);
                    GridCountInfo info2 = new GridCountInfo {
                        Name = "楼宇数目",
                        Count = summaryInfo.FWCount
                    };
                    list.Add(info2);
                    return list;
                }
                case "公共场所":
                {
                    Dictionary<string, long> cSCount = this.GetCSCount(gridId, "公共活动场所");
                    foreach (KeyValuePair<string, long> pair in cSCount)
                    {
                        GridCountInfo info3 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info3);
                    }
                    Dictionary<string, long> dictionary3 = this.GetCSCount(gridId, "商贸市场");
                    foreach (KeyValuePair<string, long> pair in dictionary3)
                    {
                        GridCountInfo info4 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info4);
                    }
                    Dictionary<string, long> dictionary4 = this.GetCSCount(gridId, "交通场所");
                    foreach (KeyValuePair<string, long> pair in dictionary4)
                    {
                        GridCountInfo info5 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info5);
                    }
                    Dictionary<string, long> dictionary5 = this.GetCSCount(gridId, "体育场所");
                    foreach (KeyValuePair<string, long> pair in dictionary5)
                    {
                        GridCountInfo info6 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info6);
                    }
                    return list;
                }
                case "特种场所":
                {
                    Dictionary<string, long> dictionary6 = this.GetCSCount(gridId, "旅店");
                    foreach (KeyValuePair<string, long> pair in dictionary6)
                    {
                        GridCountInfo info7 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info7);
                    }
                    Dictionary<string, long> dictionary7 = this.GetCSCount(gridId, "网吧");
                    foreach (KeyValuePair<string, long> pair in dictionary7)
                    {
                        GridCountInfo info8 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info8);
                    }
                    return list;
                }
                case "重点单位":
                {
                    Dictionary<string, long> dictionary8 = this.GetCSCount(gridId, "党政机关");
                    foreach (KeyValuePair<string, long> pair in dictionary8)
                    {
                        GridCountInfo info9 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info9);
                    }
                    Dictionary<string, long> dictionary9 = this.GetCSCount(gridId, "寺观教堂");
                    foreach (KeyValuePair<string, long> pair in dictionary9)
                    {
                        GridCountInfo info10 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info10);
                    }
                    Dictionary<string, long> dictionary10 = this.GetCSCount(gridId, "医院");
                    foreach (KeyValuePair<string, long> pair in dictionary10)
                    {
                        GridCountInfo info11 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info11);
                    }
                    Dictionary<string, long> dictionary11 = this.GetCSCount(gridId, "学校");
                    foreach (KeyValuePair<string, long> pair in dictionary11)
                    {
                        GridCountInfo info12 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info12);
                    }
                    return list;
                }
                case "案件管理":
                {
                    Dictionary<string, long> anJianCount = this.GetAnJianCount(gridId);
                    foreach (KeyValuePair<string, long> pair in anJianCount)
                    {
                        GridCountInfo info13 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info13);
                    }
                    return list;
                }
                case "监控管理":
                {
                    Dictionary<string, long> videoCount = this.gridSelectManager.GetVideoCount(gridId);
                    foreach (KeyValuePair<string, long> pair in videoCount)
                    {
                        GridCountInfo info14 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info14);
                    }
                    return list;
                }
                case "警车警力":
                {
                    Dictionary<string, long> jcJyCount = this.GetJcJyCount(gridId);
                    foreach (KeyValuePair<string, long> pair in jcJyCount)
                    {
                        GridCountInfo info15 = new GridCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(info15);
                    }
                    return list;
                }
            }
            throw new ArgumentException("一级菜单名无效");
        }

        private Dictionary<string, long> GetCSCount(string gridId, string type)
        {
            return this.gridSelectManager.GetCSCount(gridId, type);
        }

        public CSDetail GetCSDetail(string csId, string type)
        {
            return gs.GetCSDetail(csId, type);
            //return this.gridSelectManager.GetCSDetail(csId, type);
        }

        public CSDetailWithPic GetCSDetailWithPic(string csId, string type)
        {
            return gs.GetCSDetailWithPic(csId, type);
            //return this.gridSelectManager.GetCSDetailWithPic(csId, type);
        }

        public List<RenKou> GetCZRenKouList(string gridId)
        {
            return this.gridSelectManager.GetCZRenKouList(gridId);
        }

        public DqbZDRenKou GetDqbDZRenKou(string sfzh)
        {
            return this.gridSelectManager.GetDqbZDRenKouDetail(sfzh);
        }

        public List<RenKou> GetFangWuRenKou(string fwId)
        {
            return this.gridSelectManager.GetFangWuRenKou(fwId);
        }

        private Dictionary<string, long> GetJcJyCount(string gridId)
        {
            return this.gridSelectManager.GetJcJyCount(gridId);
        }

        public List<JieChuJing> GetJieChuJingList(string gridId)
        {
            return this.gridSelectManager.GetJieChuJingList(gridId);
        }

        public List<GridListInfo> GetListInfoByGrid(string gridId, string firstClass, string secondClass)
        {
            double num;
            double num2;
            List<GridListInfo> list = new List<GridListInfo>();
            switch (firstClass)
            {
                case "人口管理":
                    switch (secondClass)
                    {
                        case "常住人口":
                        {
                            List<RenKou> cZRenKouList = this.gridSelectManager.GetCZRenKouList(gridId);
                            foreach (RenKou kou in cZRenKouList)
                            {
                                GridListInfo item = new GridListInfo {
                                    ID = kou.SFZH,
                                    Name = kou.XM
                                };
                                list.Add(item);
                            }
                            return list;
                        }
                        case "重点人口":
                        {
                            List<RenKou> zDRenKouList = this.gridSelectManager.GetZDRenKouList(gridId);
                            foreach (RenKou kou in zDRenKouList)
                            {
                                GridListInfo info2 = new GridListInfo {
                                    ID = kou.SFZH,
                                    Name = kou.XM
                                };
                                list.Add(info2);
                            }
                            return list;
                        }
                    }
                    throw new ArgumentException("人口管理：二级菜单名称无效");

                case "房屋管理":
                {
                    GridBuilding buildingCount = this.gridSelectManager.GetBuildingCount(gridId);
                    foreach (Building building2 in buildingCount.BuildingList)
                    {
                        double.TryParse(building2.JD, out num);
                        double.TryParse(building2.WD, out num2);
                        GridListInfo info3 = new GridListInfo {
                            ID = building2.JZWDM,
                            Name = building2.JZWMC,
                            JD = num,
                            WD = num2
                        };
                        list.Add(info3);
                    }
                    return list;
                }
                case "公共场所":
                case "特种场所":
                case "重点单位":
                {
                    List<ChangSuo> changSuoList = this.gridSelectManager.GetChangSuoList(gridId, secondClass);
                    foreach (ChangSuo suo in changSuoList)
                    {
                        double.TryParse(suo.JD, out num);
                        double.TryParse(suo.WD, out num2);
                        GridListInfo info4 = new GridListInfo {
                            ID = suo.ID,
                            Name = suo.MC,
                            JD = num,
                            WD = num2
                        };
                        list.Add(info4);
                    }
                    return list;
                }
                case "案件管理":
                    switch (secondClass)
                    {
                        case "接处警":
                        {
                            List<JieChuJing> jieChuJingList = this.GetJieChuJingList(gridId);
                            foreach (JieChuJing jing in jieChuJingList)
                            {
                                GridListInfo info5 = new GridListInfo {
                                    ID = jing.ID,
                                    Name = jing.ID + "(" + jing.CJBS + ")"
                                };
                                list.Add(info5);
                            }
                            return list;
                        }
                        case "刑事案件":
                        {
                            List<AnJian> xingShiAJList = this.GetXingShiAJList(gridId);
                            foreach (AnJian jian in xingShiAJList)
                            {
                                GridListInfo info6 = new GridListInfo {
                                    ID = jian.ID,
                                    Name = jian.ID + "(" + jian.AJZT + ")"
                                };
                                list.Add(info6);
                            }
                            return list;
                        }
                        case "治安案件":
                        {
                            List<AnJian> zhiAnAjList = this.GetZhiAnAjList(gridId);
                            foreach (AnJian jian in zhiAnAjList)
                            {
                                GridListInfo info7 = new GridListInfo {
                                    ID = jian.ID,
                                    Name = jian.ID + "(" + jian.AJZT + ")"
                                };
                                list.Add(info7);
                            }
                            return list;
                        }
                    }
                    throw new ArgumentException("案件管理：二级菜单名称无效");

                case "监控管理":
                {
                    List<Video> videoListByGrid = this.gridSelectManager.GetVideoListByGrid(gridId, secondClass);
                    foreach (Video video in videoListByGrid)
                    {
                        double.TryParse(video.JD, out num);
                        double.TryParse(video.WD, out num2);
                        GridListInfo info8 = new GridListInfo {
                            ID = video.KDID,
                            Name = video.NAME,
                            JD = num,
                            WD = num2
                        };
                        list.Add(info8);
                    }
                    return list;
                }
                case "警车警力":
                    switch (secondClass)
                    {
                        case "警车":
                        {
                            List<PoliceCar> policeCarList = this.GetPoliceCarList(gridId);
                            foreach (PoliceCar car in policeCarList)
                            {
                                GridListInfo info9 = new GridListInfo {
                                    ID = car.CARNO,
                                    Name = car.CARNO
                                };
                                list.Add(info9);
                            }
                            return list;
                        }
                        case "警员":
                        {
                            List<PoliceMan> policeManList = this.GetPoliceManList(gridId);
                            foreach (PoliceMan man in policeManList)
                            {
                                GridListInfo info10 = new GridListInfo {
                                    ID = man.ID,
                                    Name = man.XM
                                };
                                list.Add(info10);
                            }
                            return list;
                        }
                    }
                    throw new ArgumentException("警车警力：二级菜单名称无效");
            }
            throw new ArgumentException("一级菜单名称无效");
        }

        public LvKe GetLvKeDetail(string lksfzh)
        {
            return this.gridSelectManager.GetLvKeDetail(lksfzh);
        }

        public List<LvKe> GetLvKeList(string ldId)
        {
            return this.gridSelectManager.GetLvKeList(ldId);
        }

        public List<PoliceCar> GetPoliceCarList(string gridId)
        {
            return this.gridSelectManager.GetPoliceCarList(gridId);
        }

        public PoliceManDetail GetPoliceManDetail(string jyid)
        {
            return gs.GetPoliceManDetail(jyid);
            //return this.gridSelectManager.GetPoliceManDetail(jyid);
        }

        public List<PoliceMan> GetPoliceManList(string gridId)
        {
            return this.gridSelectManager.GetPoliceManList(gridId);
        }

        public RenKou GetRenKouDetail(string sfzh)
        {
            return gs.GetRenKouDetail(sfzh);
            //return this.gridSelectManager.GetRenKouDetail(sfzh);
        }

        public GridSummary GetSummaryInfo(string gridId)
        {
            return this.gridSelectManager.GetGridSummary(gridId);
        }

        public SWRY GetSWRYDetail(string zjhm)
        {
            return this.gridSelectManager.GetSWRYDetail(zjhm);
        }

        public List<SWRY> GetSWRYList(string wbId)
        {
            return this.gridSelectManager.GetSWRYList(wbId);
        }

        public List<AnJian> GetXingShiAJList(string gridId)
        {
            return this.gridSelectManager.GetXingShiAJList(gridId);
        }

        public ZDRenKou GetZDRenKouDetail(string sfzh)
        {
            return gs.GetZDRenKouDetail(sfzh);
            //return this.gridSelectManager.GetZDRenKouDetail(sfzh);
        }

        public List<RenKou> GetZDRenKouList(string gridId)
        {
            return this.gridSelectManager.GetZDRenKouList(gridId);
        }

        public List<AnJian> GetZhiAnAjList(string gridId)
        {
            return this.gridSelectManager.GetZhiAnAjList(gridId);
        }
    }
}

