namespace Beyon.Service.GridPlatform.PolygonSelect
{
    using Beyon.Domain.GridSelect;
    using Beyon.Domain.PolySelect;
    using Beyon.Dao.GridPlatform.PolySelect;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using Beyon.Common;
using Beyon.Domain.GridSearch;

    public class PolygonSelectService
    {
        private PolySelectManager polySelectManager = new PolySelectManager();

        private string CoordinateTransfer(List<Point> points)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("POLYGON((");
            foreach (Point point in points)
            {
                builder.Append(point.X.ToString() + " " + point.Y.ToString());
                builder.Append(",");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("))");
            return builder.ToString();
        }

        public List<PolyCountInfo> GetCountInfoByPoly(string firstClass, string xzqhLevel, List<Point> polygon)
        {
            //LogMgr.Instance.Log("开始计算[" + firstClass + "]统计值");
            DateTime startTime = DateTime.Now;
            string str = this.CoordinateTransfer(polygon);
            List<PolyCountInfo> list = new List<PolyCountInfo>();
            switch (firstClass)
            {
                case "人口管理":
                {
                    Dictionary<string, long> renKouCountByPoly = this.polySelectManager.GetRenKouCountByPoly(xzqhLevel, str);
                    foreach (KeyValuePair<string, long> pair in renKouCountByPoly)
                    {
                        PolyCountInfo item = new PolyCountInfo {
                            Name = pair.Key,
                            Count = pair.Value
                        };
                        list.Add(item);
                    }
                    break;
                }
                case "房屋管理":
                {
                    long fwCount = this.polySelectManager.GetFWCountByPoly(xzqhLevel, str);
                    PolyCountInfo fwCountInfo = new PolyCountInfo {
                        Name = "楼宇数目",
                        Count = fwCount
                    };
                    list.Add(fwCountInfo);
                    break;
                }
                case "公共场所":
                {
                    PolyCountInfo info6 = new PolyCountInfo {
                        Name = "公共活动场所",
                        Count = this.polySelectManager.GetCSCountByPoly("公共活动场所", str)
                    };
                    list.Add(info6);
                    PolyCountInfo info7 = new PolyCountInfo {
                        Name = "商贸市场",
                        Count = this.polySelectManager.GetCSCountByPoly("商贸市场", str)
                    };
                    list.Add(info7);
                    PolyCountInfo info8 = new PolyCountInfo {
                        Name = "交通场所",
                        Count = this.polySelectManager.GetCSCountByPoly("交通场所", str)
                    };
                    list.Add(info8);
                    PolyCountInfo info9 = new PolyCountInfo {
                        Name = "体育场所",
                        Count = this.polySelectManager.GetCSCountByPoly("体育场所", str)
                    };
                    list.Add(info9);
                    PolyCountInfo info10 = new PolyCountInfo {
                        Name = "旅游场所",
                        Count = this.polySelectManager.GetCSCountByPoly("旅游场所", str)
                    };
                    list.Add(info10);
                    PolyCountInfo info11 = new PolyCountInfo {
                        Name = "居民服务场所",
                        Count = this.polySelectManager.GetCSCountByPoly("居民服务场所", str)
                    };
                    list.Add(info11);
                    PolyCountInfo info12 = new PolyCountInfo {          
                        Name = "文化场所",
                        Count = this.polySelectManager.GetCSCountByPoly("文化场所", str)
                    };
                    list.Add(info12);
                    break;
                }
                case "特种场所":
                {
                    PolyCountInfo info13 = new PolyCountInfo {
                        Name = "旅店",
                        Count = this.polySelectManager.GetCSCountByPoly("旅店", str)
                    };
                    list.Add(info13);
                    PolyCountInfo info14 = new PolyCountInfo {
                        Name = "网吧",
                        Count = this.polySelectManager.GetCSCountByPoly("网吧", str)
                    };
                    list.Add(info14);
                    PolyCountInfo info15 = new PolyCountInfo {
                        Name = "娱乐场所",
                        Count = this.polySelectManager.GetCSCountByPoly("娱乐场所", str)
                    };
                    list.Add(info15);
                    break;
                }
                case "重点单位":
                {
                    PolyCountInfo info16 = new PolyCountInfo {
                        Name = "党政机关",
                        Count = this.polySelectManager.GetCSCountByPoly("党政机关", str)
                    };
                    list.Add(info16);
                    PolyCountInfo info17 = new PolyCountInfo {
                        Name = "寺观教堂",
                        Count = this.polySelectManager.GetCSCountByPoly("寺观教堂", str)
                    };
                    list.Add(info17);
                    PolyCountInfo info18 = new PolyCountInfo {
                        Name = "医院",
                        Count = this.polySelectManager.GetCSCountByPoly("医院", str)
                    };
                    list.Add(info18);
                    PolyCountInfo info19 = new PolyCountInfo {
                        Name = "学校",
                        Count = this.polySelectManager.GetCSCountByPoly("学校", str)
                    };
                    list.Add(info19);
                    PolyCountInfo info20 = new PolyCountInfo {
                        Name = "金融证券",
                        Count = this.polySelectManager.GetCSCountByPoly("金融证券", str)
                    };
                    list.Add(info20);
                    PolyCountInfo info21 = new PolyCountInfo {
                        Name = "危险品存放处",
                        Count = this.polySelectManager.GetCSCountByPoly("危险品存放处", str)
                    };
                    list.Add(info21);
                    break;
                }
                case "案件管理":
                {
                    Dictionary<string, long> ajCountByPoly = this.polySelectManager.GetAjCountByPoly(xzqhLevel, str);
                    foreach (KeyValuePair<string, long> pair2 in ajCountByPoly)
                    {
                        PolyCountInfo info2 = new PolyCountInfo {
                            Name = pair2.Key,
                            Count = pair2.Value
                        };
                        list.Add(info2);
                    }
                    break;
                }
                case "视频管理":
                {
                    Dictionary<string, long> spjkCountByPoly = this.polySelectManager.GetSpjkCountByPoly(str);
                    foreach (KeyValuePair<string, long> pair3 in spjkCountByPoly)
                    {
                        PolyCountInfo info3 = new PolyCountInfo {
                            Name = pair3.Key,
                            Count = pair3.Value
                        };
                        list.Add(info3);
                    }
                    break;
                }
                case "勤务信息":
                {
                    List<PoliceCar> pcListByPoly = this.polySelectManager.GetPoliceCarListByPoly(polygon);
                    PolyCountInfo infojc = new PolyCountInfo
                    {
                        Name = "警车",
                        Count = pcListByPoly.Count
                    };
                    list.Add(infojc);
                    
                    PolyCountInfo info22 = new PolyCountInfo {
                        Name = "警员",
                        Count = this.polySelectManager.GetPoliceManCountByPoly(xzqhLevel, str)
                    };
                    list.Add(info22);
                    break;
                }
                case "责任区域":
                {
                    Dictionary<string, long> pcsZrqCountByPoly = this.polySelectManager.GetPcsZrqCountByPoly(xzqhLevel, str);
                    foreach (KeyValuePair<string, long> pair4 in pcsZrqCountByPoly)
                    {
                        PolyCountInfo info4 = new PolyCountInfo {
                            Name = pair4.Key,
                            Count = pair4.Value
                        };
                        list.Add(info4);
                    }
                    break;
                }
                case "监所管理":
                    
                    List<PolyJS> jlCountByPoly = this.polySelectManager.GetJSListByPoly("拘留所",polygon);
                        PolyCountInfo infojl = new PolyCountInfo {
                            Name = "拘留所",
                            Count = jlCountByPoly.Count
                        };
                        list.Add(infojl);

                    List<PolyJS> ksCountByPoly = this.polySelectManager.GetJSListByPoly("看守所",polygon);
                        PolyCountInfo infoks = new PolyCountInfo {
                            Name = "看守所",
                            Count = ksCountByPoly.Count
                        };
                        list.Add(infoks);
                        List<PolyJS> jdCountByPoly = this.polySelectManager.GetJSListByPoly("戒毒所",polygon);
                        PolyCountInfo infojd = new PolyCountInfo {
                            Name = "戒毒所",
                            Count = jdCountByPoly.Count
                        };
                        list.Add(infojd);

                        break;
            }
            DateTime endTime = DateTime.Now;
            TimeSpan consume = endTime - startTime;
            //LogMgr.Instance.Log("结束["+ firstClass + "]统计值计算", consume);
            return list;
        }

        public PolySummary GetFQInfoByPoly(string xzqhLevel, List<Point> polygon)
        {
            return this.polySelectManager.GetFQInfoByPoly(xzqhLevel, this.CoordinateTransfer(polygon));
        }

        public List<PolyListInfo> GetListInfoByPoly(string firstClass, string secondClass, string mapLevel, List<Point> polygon)
        {
            double num;
            double num2;
            string str = this.CoordinateTransfer(polygon);
            List<PolyListInfo> list = new List<PolyListInfo>();
            switch (firstClass)
            {
                case "人口管理":
                    {
                        List<RenKou> list2 = this.polySelectManager.GetRenKouListByPoly(secondClass, mapLevel, str);
                        foreach (RenKou kou in list2)
                        {
                            PolyListInfo item = new PolyListInfo
                            {
                                ID = kou.SFZH,
                                Name = kou.XM
                            };
                            list.Add(item);
                        }
                        return list;
                    }
                case "房屋管理":
                    {
                        PolyBuilding fWListByPoly = this.polySelectManager.GetFWListByPoly(mapLevel, str);
                        if (fWListByPoly.fwList != null)
                        {
                            foreach (Building building2 in fWListByPoly.fwList)
                            {
                                double.TryParse(building2.JD, out num);
                                double.TryParse(building2.WD, out num2);
                                PolyListInfo info2 = new PolyListInfo
                                {
                                    ID = building2.JZWDM,
                                    Name = building2.JZWMC,
                                    JD = num,
                                    WD = num2
                                };
                                list.Add(info2);
                            }
                            return list;
                        }
                        return list;
                    }
                case "公共场所":
                    //return list;
                case "特种场所":
                    //return list;
                case "重点单位":
                    {
                        List<PolyCS> cSListByPoly = this.polySelectManager.GetCSListByPoly(secondClass, str);
                        foreach (PolyCS ycs in cSListByPoly)
                        {
                            double.TryParse(ycs.JD, out num);
                            double.TryParse(ycs.WD, out num2);
                            PolyListInfo info3 = new PolyListInfo
                            {
                                ID = ycs.ID,
                                Name = ycs.MC,
                                JD = num,
                                WD = num2
                            };
                            list.Add(info3);
                        }
                        return list;
                    }
                case "案件管理":
                    {
                        List<AnJian> list4 = this.polySelectManager.GetAnJianListByPoly(secondClass, mapLevel, str);
                        if (!secondClass.Equals("接处警"))
                        {
                            foreach (AnJian jian in list4)
                            {
                                PolyListInfo info5 = new PolyListInfo
                                {
                                    ID = jian.ID,
                                    Name = jian.AJMC + "(" + jian.AJZT + ")"
                                };
                                list.Add(info5);
                            }
                            return list;
                        }
                        foreach (AnJian jian in list4)
                        {
                            PolyListInfo info4 = new PolyListInfo
                            {
                                ID = jian.ID,
                                Name = jian.BJLX + "(" + jian.AJZT + "-" + jian.ID + ")"
                            };
                            list.Add(info4);
                        }
                        return list;
                    }
                case "视频管理":
                    {
                        List<Beyon.Domain.PolySelect.Video> spjkListByPoly = this.polySelectManager.GetSpjkListByPoly(secondClass, str);
                        foreach (Beyon.Domain.PolySelect.Video video in spjkListByPoly)
                        {
                            PolyListInfo info6 = new PolyListInfo
                            {
                                ID = video.ID,
                                Name = video.MC
                            };
                            list.Add(info6);
                        }
                        return list;
                    }
                case "勤务信息":
                    {
                        if (secondClass.Equals("警车"))
                        {
                            List<PoliceCar> pcListByPoly = this.polySelectManager.GetPoliceCarListByPoly(polygon);
                            foreach (PoliceCar pc in pcListByPoly)
                            {
                                PolyListInfo infojc = new PolyListInfo
                                {
                                    Name = pc.CARNO,
                                    ID = pc.GPSID,
                                };
                                list.Add(infojc);
                            }
                            return list;

                        }
                        else if (secondClass.Equals("警员"))
                        {
                            List<PoliceMan> policeManListByPoly = this.polySelectManager.GetPoliceManListByPoly(str);
                            foreach (PoliceMan man in policeManListByPoly)
                            {
                                PolyListInfo info7 = new PolyListInfo
                                {
                                    ID = man.ID,
                                    Name = man.XM
                                };
                                list.Add(info7);
                            }
                            return list;
                        }
                        else
                            return list;
                    }
                    throw new ArgumentException("警车警力：二级菜单名称无效");

                case "责任区域":
                    {
                        List<GridInfo> pcsZrqListByPoly = this.polySelectManager.GetPcsZrqListByPoly(secondClass, str);
                        foreach (GridInfo info8 in pcsZrqListByPoly)
                        {
                            double.TryParse(info8.JD, out num);
                            double.TryParse(info8.WD, out num2);
                            PolyListInfo info9 = new PolyListInfo
                            {
                                ID = info8.ZZJGDM,
                                Name = info8.MC,
                                JD = num,
                                WD = num2
                            };
                            list.Add(info9);
                        }
                        return list;
                    }
                case "监所管理":
                    {
                        if (secondClass.Equals("拘留所"))
                        {
                            List<PolyJS> jlCountByPoly = this.polySelectManager.GetJSListByPoly("拘留所", polygon);
                            foreach (PolyJS jlr in jlCountByPoly)
                            {
                                double.TryParse(jlr.GAJGJD, out num);
                                double.TryParse(jlr.GAJGWD, out num2);
                                PolyListInfo infojl = new PolyListInfo
                                {
                                    //Name = "拘留所",
                                    ID = jlr.GAJGDM+"|"+jlr.JS_CODE,
                                    Name = jlr.JS_MC,
                                    JD = num,
                                    WD = num2

                                };
                                list.Add(infojl);
                            }
                            return list;
                        }
                        else if (secondClass.Equals("看守所"))
                        {

                                List<PolyJS> ksCountByPoly = this.polySelectManager.GetJSListByPoly("看守所",polygon);
                                foreach (PolyJS ksr in ksCountByPoly)
                                {
                                    double.TryParse(ksr.GAJGJD, out num);
                                    double.TryParse(ksr.GAJGWD, out num2);
                                    PolyListInfo infoks = new PolyListInfo
                                    {
                                        //Name = "拘留所",
                                        ID = ksr.GAJGDM + "|" + ksr.JS_CODE,
                                        Name = ksr.JS_MC,
                                        JD = num,
                                        WD = num2

                                    };
                                    list.Add(infoks);
                                }
                                return list;
                            

                        }
                        else if (secondClass.Equals("戒毒所"))
                        {
                              List<PolyJS> jdCountByPoly = this.polySelectManager.GetJSListByPoly("戒毒所", polygon);
                                foreach (PolyJS jdr in jdCountByPoly)
                                {
                                    double.TryParse(jdr.GAJGJD, out num);
                                    double.TryParse(jdr.GAJGWD, out num2);
                                    PolyListInfo infojd = new PolyListInfo
                                    {
                                        //Name = "拘留所",
                                        ID = jdr.GAJGDM + "|" + jdr.JS_CODE,
                                        Name = jdr.JS_MC,
                                        JD = num,
                                        WD = num2
                                    };
                                    list.Add(infojd);
                                }
                                return list;
                        }
                        else
                            return list;
                    }
            }
            throw new ArgumentException("一级菜单名称无效");

        }

        /// <summary>
        /// 圈选获取分页列表
        /// </summary>
        /// <param name="firstClass">一级菜单</param>
        /// <param name="secondClass">二级菜单</param>
        /// <param name="mapLevel">地图级别</param>
        /// <param name="polygon">圈选区域</param>
        /// <param name="pageNum">第N页</param>
        /// <param name="pageList">分页大小</param>
        /// <returns></returns>
        public List<PolyListInfo> GetPageListInfoByPoly(string firstClass, string secondClass, string mapLevel, List<Point> polygon, int pageNum, int pageSize)
        {
            double num;
            double num2;
            string str = this.CoordinateTransfer(polygon);
            List<PolyListInfo> list = new List<PolyListInfo>();
            switch (firstClass)
            {
                case "人口管理":
                    {
                        List<RenKou> list2 = this.polySelectManager.GetRenKouPageListByPoly(secondClass, mapLevel, str, pageNum, pageSize);
                        foreach (RenKou kou in list2)
                        {
                            PolyListInfo item = new PolyListInfo
                            {
                                ID = kou.SFZH,
                                Name = kou.XM
                            };
                            list.Add(item);
                        }
                        return list;
                    }
                case "房屋管理":
                    {
                        PolyBuilding fWListByPoly = this.polySelectManager.GetFWPageListByPoly(mapLevel, str, pageNum, pageSize);
                        if (fWListByPoly.fwList != null)
                        {
                            foreach (Building building2 in fWListByPoly.fwList)
                            {
                                double.TryParse(building2.JD, out num);
                                double.TryParse(building2.WD, out num2);
                                PolyListInfo info2 = new PolyListInfo
                                {
                                    ID = building2.JZWDM,
                                    Name = building2.JZWMC,
                                    JD = num,
                                    WD = num2
                                };
                                list.Add(info2);
                            }
                            return list;
                        }
                        return list;
                    }
                case "公共场所":
                //return list;
                case "特种场所":
                //return list;
                case "重点单位":
                    {
                        List<PolyCS> cSListByPoly = this.polySelectManager.GetCSPageListByPoly(secondClass, str, pageNum, pageSize);
                        foreach (PolyCS ycs in cSListByPoly)
                        {
                            double.TryParse(ycs.JD, out num);
                            double.TryParse(ycs.WD, out num2);
                            PolyListInfo info3 = new PolyListInfo
                            {
                                ID = ycs.ID,
                                Name = ycs.MC,
                                JD = num,
                                WD = num2
                            };
                            list.Add(info3);
                        }
                        return list;
                    }
                case "案件管理":
                    {
                        List<AnJian> list4 = this.polySelectManager.GetAnJianPageListByPoly(secondClass, mapLevel, str, pageNum, pageSize);
                        if (!secondClass.Equals("接处警"))
                        {
                            foreach (AnJian jian in list4)
                            {
                                PolyListInfo info5 = new PolyListInfo
                                {
                                    ID = jian.ID,
                                    Name = jian.AJMC + "(" + jian.AJZT + ")"
                                };
                                list.Add(info5);
                            }
                            return list;
                        }
                        foreach (AnJian jian in list4)
                        {
                            PolyListInfo info4 = new PolyListInfo
                            {
                                ID = jian.ID,
                                Name = jian.BJLX + "(" + jian.AJZT + "-" + jian.ID + ")"
                            };
                            list.Add(info4);
                        }
                        return list;
                    }
                case "视频管理":
                    {
                        List<Beyon.Domain.PolySelect.Video> spjkListByPoly = this.polySelectManager.GetSpjkPageListByPoly(secondClass, str, pageNum, pageSize);
                        foreach (Beyon.Domain.PolySelect.Video video in spjkListByPoly)
                        {
                            PolyListInfo info6 = new PolyListInfo
                            {
                                ID = video.ID,
                                Name = video.MC
                            };
                            list.Add(info6);
                        }
                        return list;
                    }
                case "勤务信息":
                    {
                        if (secondClass.Equals("警车"))
                        {
                            List<PoliceCar> pcListByPoly = this.polySelectManager.GetPoliceCarListByPoly(polygon);
                            foreach (PoliceCar pc in pcListByPoly)
                            {
                                PolyListInfo infojc = new PolyListInfo
                                {
                                    Name = pc.CARNO,
                                    ID = pc.GPSID,
                                };
                                list.Add(infojc);
                            }
                            return list;

                        }
                        else if (secondClass.Equals("警员"))
                        {
                            List<PoliceMan> policeManListByPoly = this.polySelectManager.GetPoliceManPageListByPoly(str, pageNum, pageSize);
                            foreach (PoliceMan man in policeManListByPoly)
                            {
                                PolyListInfo info7 = new PolyListInfo
                                {
                                    ID = man.ID,
                                    Name = man.XM
                                };
                                list.Add(info7);
                            }
                            return list;
                        }
                        else
                            return list;
                    }
                    throw new ArgumentException("警车警力：二级菜单名称无效");

                case "责任区域":
                    {
                        List<GridInfo> pcsZrqListByPoly = this.polySelectManager.GetPcsZrqListByPoly(secondClass, str);
                        foreach (GridInfo info8 in pcsZrqListByPoly)
                        {
                            double.TryParse(info8.JD, out num);
                            double.TryParse(info8.WD, out num2);
                            PolyListInfo info9 = new PolyListInfo
                            {
                                ID = info8.ZZJGDM,
                                Name = info8.MC,
                                JD = num,
                                WD = num2
                            };
                            list.Add(info9);
                        }
                        return list;
                    }
                case "监所管理":
                    {
                        if (secondClass.Equals("拘留所"))
                        {
                            List<PolyJS> jlCountByPoly = this.polySelectManager.GetJSListByPoly("拘留所", polygon);
                            foreach (PolyJS jlr in jlCountByPoly)
                            {
                                double.TryParse(jlr.GAJGJD, out num);
                                double.TryParse(jlr.GAJGWD, out num2);
                                PolyListInfo infojl = new PolyListInfo
                                {
                                    //Name = "拘留所",
                                    ID = jlr.GAJGDM + "|" + jlr.JS_CODE,
                                    Name = jlr.JS_MC,
                                    JD = num,
                                    WD = num2

                                };
                                list.Add(infojl);
                            }
                            return list;
                        }
                        else if (secondClass.Equals("看守所"))
                        {

                            List<PolyJS> ksCountByPoly = this.polySelectManager.GetJSListByPoly("看守所", polygon);
                            foreach (PolyJS ksr in ksCountByPoly)
                            {
                                double.TryParse(ksr.GAJGJD, out num);
                                double.TryParse(ksr.GAJGWD, out num2);
                                PolyListInfo infoks = new PolyListInfo
                                {
                                    //Name = "拘留所",
                                    ID = ksr.GAJGDM + "|" + ksr.JS_CODE,
                                    Name = ksr.JS_MC,
                                    JD = num,
                                    WD = num2

                                };
                                list.Add(infoks);
                            }
                            return list;


                        }
                        else if (secondClass.Equals("戒毒所"))
                        {
                            List<PolyJS> jdCountByPoly = this.polySelectManager.GetJSListByPoly("戒毒所", polygon);
                            foreach (PolyJS jdr in jdCountByPoly)
                            {
                                double.TryParse(jdr.GAJGJD, out num);
                                double.TryParse(jdr.GAJGWD, out num2);
                                PolyListInfo infojd = new PolyListInfo
                                {
                                    //Name = "拘留所",
                                    ID = jdr.GAJGDM + "|" + jdr.JS_CODE,
                                    Name = jdr.JS_MC,
                                    JD = num,
                                    WD = num2
                                };
                                list.Add(infojd);
                            }
                            return list;
                        }
                        else
                            return list;
                    }
            }
            throw new ArgumentException("一级菜单名称无效");

        }

        public PcsDetail GetPcsDetailByPoly(string id)
        {
            return this.polySelectManager.GetPcsDetailByPoly(id);
        }

        public ZrqDetail GetZrqDetailByPoly(string id)
        {
            return this.polySelectManager.GetZrqDetailByPoly(id);
        }

        public JSDetail GetJSDetailByPoly(string id)
        {
            return this.polySelectManager.GetJSDetailByPoly(id);
        }
        public List<JSPerson> GetJSPersonListByPoly(string type,string id)
        {
            return this.polySelectManager.GetJSPersonListByPoly(type,id);
        }
        public JSPersonDetail GetJSPersonDetailByPoly(string id,string type)
        {
            return this.polySelectManager.GetJSPersonDetailByPoly(id,type);
        }
        public List<PolyJS> GetJSListByProvince(string jsType)
        {
            return this.polySelectManager.GetJSListByProvince(jsType);
        }

        public SearchResult OneKeySearch(string sjzgdw, string text)
        {
            return this.polySelectManager.OneKeySearch(sjzgdw, text);
        }
    }
}

