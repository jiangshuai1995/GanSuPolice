namespace Beyon.Domain
{
    using Beyon.Common;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Runtime.InteropServices;

    public class ZHDDPT
    {
        private Jglx _jglx = Jglx.ST;
        private AffairsType affType;
        private JosnAnalysisDataTable ajTable = new JosnAnalysisDataTable();
        private IScreenRow CurrentStat;
        private IScreenRow ConstrastStat;   //同比值
        private JosnAnalysisDataTable czrkTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable dqbTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable dwTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable fxjTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable gajgTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable gajgtjTable = new JosnAnalysisDataTable();
        private GAJGCoordinate gajgzbTable = new GAJGCoordinate();
        private JosnAnalysisDataTable gbTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable grkylbTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable jcjTable = new JosnAnalysisDataTable();
        private string jdsResultURL;
        private JosnAnalysisDataTable jlfbTable = new JosnAnalysisDataTable();
        private string jlsResultURL;
        private JosnAnalysisDataTable jsTable = new JosnAnalysisDataTable();
        private string kssResultURL;
        private JosnAnalysisDataTable qzcsTable = new JosnAnalysisDataTable();
        private List<StatisticInfo> resultInfo;
        private string srsResultURL;
        private JosnAnalysisDataTable xsajTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable ydzdTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable zaajTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable zazdrTable = new JosnAnalysisDataTable();
        private JosnAnalysisDataTable zbglTable = new JosnAnalysisDataTable();
        private string zyqkResultURL;
        private JosnAnalysisDataTable zzrkTable = new JosnAnalysisDataTable();

        public ZHDDPT()
        {
            this.SetFieldsKyes();
            this.SetFieldsUrl();
        }

        private void GetAJGLColumnChartInfo(string tow, string three)
        {
            string str = tow;
            if (str != null)
            {
                if (!(str == "接处警"))
                {
                    if (str == "刑事案件")
                    {
                        this.GetXSAJColumnChartInfo(three);
                    }
                    else if (str == "治安案件")
                    {
                        this.GetZAAJColumnChartInfo(three);
                    }
                    else if (str == "强制措施")
                    {
                        this.GetQZCSColumnChartInfo(three);
                    }
                }
                else
                {
                    this.GetJCJColumnChartInfo(three);
                }
            }
        }

        public List<StatisticInfo> GetColumnChartInfo(string level, string name, double minLongitude, double minLatitude, double maxLongitude, double maxLatitude)
        {
            LogMgr.Instance.Log(String.Format("【统计图同比值】获取等级 {0} 的 {1} 开始!", level, name));
            this.resultInfo = null;
            string str = level;
            if (str != null)
            {
                if (!(str == "省"))
                {
                    if (str == "市")
                    {
                        this._jglx = Jglx.SJ;
                        goto Label_0075;
                    }
                    if (str == "县")
                    {
                        this._jglx = Jglx.FJ;
                        goto Label_0075;
                    }
                    if (str == "派出所")
                    {
                        this._jglx = Jglx.PCS;
                        goto Label_0075;
                    }
                }
                else
                {
                    this._jglx = Jglx.ST;
                    goto Label_0075;
                }
            }
            return null;
        Label_0075:
            this.gajgzbTable.GetAreaData(this._jglx, minLongitude, maxLongitude, minLatitude, maxLatitude);
            string[] strArray = new string[] { "", "", "" };
            int index = -1;
            int startIndex = 0;
            for (int i = 0; i < 3; i++)
            {
                index = name.IndexOf("_", startIndex);
                if (index == -1)
                {
                    strArray[i] = name.Substring(startIndex);
                    break;
                }
                strArray[i] = name.Substring(startIndex, index - startIndex);
                startIndex = index + 1;
            }
            if (strArray[2] != "")
            {
                str = strArray[0];
                if (str != null)
                {
                    if (!(str == "案件管理"))
                    {
                        if (str == "人员管理")
                        {
                            this.GetRYGLColumnChartInfo(strArray[1], strArray[2]);
                            goto Label_01C6;
                        }
                        if (str == "监所管理")
                        {
                            this.GetJSGLColumnChartInfo(strArray[1], strArray[2]);
                            goto Label_01C6;
                        }
                        if (str == "单位管理")
                        {
                            this.GetDWGLColumnChartInfo(strArray[1], strArray[2]);
                            goto Label_01C6;
                        }
                        if (str == "勤务管理")
                        {
                            this.GetQWGLColumnChartInfo(strArray[1], strArray[2]);
                            goto Label_01C6;
                        }
                    }
                    else
                    {
                        this.GetAJGLColumnChartInfo(strArray[1], strArray[2]);
                        goto Label_01C6;
                    }
                }
            }

            LogMgr.Instance.Log(String.Format("【统计图同比值】获取等级 {0} 的 {1} 结束！", level, name));

            return null;
        Label_01C6:

            LogMgr.Instance.Log(String.Format("【统计图同比值】获取等级 {0} 的 {1} 结束！", level, name));

            return this.resultInfo;
        }

        private void GetCZRKColumnChartInfo(string three)
        {
            this.CurrentStat = this.czrkTable;
            string str = three;
            if (str != null)
            {
                if (!(str == "人员状态"))
                {
                    if (str == "性别")
                    {
                        this.SingleOrganizeResult((CZRKType.WOMAN | CZRKType.MAN).ToString(), CZRKType.MAN.GetRemark() + "," + CZRKType.WOMAN.GetRemark(), "ck,ck", "XZQH", "JC", null);
                    }
                    else if (str == "户口")
                    {
                        this.SingleOrganizeResult((CZRKType.OTHERHK | CZRKType.NCHK | CZRKType.CZHK).ToString(), CZRKType.CZHK.GetRemark() + "," + CZRKType.NCHK.GetRemark() + "," + CZRKType.OTHERHK.GetRemark(), "ck,ck,ck", "XZQH", "JC", null);
                    }
                }
                else
                {
                    this.SingleOrganizeResult((CZRKType.OTHERBZ | CZRKType.ZX | CZRKType.ZC).ToString(), CZRKType.ZC.GetRemark() + "," + CZRKType.ZX.GetRemark() + "," + CZRKType.OTHERBZ.GetRemark(), "ck,ck,ck", "XZQH", "JC", null);
                }
            }
        }

        private void GetDQBZDRColumnChartInfo(string three)
        {
            DQBZDRYType em = 0;
            this.CurrentStat = this.dqbTable;
            switch (three)
            {
                case "性别":
                    this.SingleOrganizeResult((DQBZDRYType.WOMAN | DQBZDRYType.MAN).ToString(), DQBZDRYType.MAN.GetRemark() + ',' + DQBZDRYType.WOMAN.GetRemark(), "dqb,dqb", "XZQH", "JC", null);
                    return;

                case "涉恐":
                    em = DQBZDRYType.SK;
                    break;

                case "涉稳":
                    em = DQBZDRYType.SW;
                    break;

                case "涉毒":
                    em = DQBZDRYType.SD;
                    break;

                case "在逃":
                    em = DQBZDRYType.ZT;
                    break;

                case "刑事犯罪前科":
                    em = DQBZDRYType.QK;
                    break;

                case "肇事肇祸精神病":
                    em = DQBZDRYType.ZSZHJSB;
                    break;

                case "上访":
                    em = DQBZDRYType.SF;
                    break;

                case "其他":
                    em = DQBZDRYType.OTHER;
                    break;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), "dqb", "XZQH", "JC", null);
        }

        private void GetDWGLColumnChartInfo(string tow, string three)
        {
            string str = tow;
            if (str != null)
            {
                if (!(str == "旅店"))
                {
                    if (str == "网吧")
                    {
                        this.GetWBColumnChartInfo(three);
                    }
                    else if (str == "寺观教堂")
                    {
                        this.GetSGJTColumnChartInfo(three);
                    }
                    else if (str == "重点单位")
                    {
                        this.GetZDDWColumnChartInfo(three);
                    }
                }
                else
                {
                    this.GetLDColumnChartInfo(three);
                }
            }
        }

        private void GetFXJColumnChartInfo(string three)
        {
            this.CurrentStat = this.fxjTable;
            if (three == "具体情况")
            {
                this.SingleOrganizeResult((FXJType.YHQG | FXJType.MY | FXJType.FLG | FXJType.TOTAL).ToString(), FXJType.TOTAL.GetRemark() + "," + FXJType.FLG.GetRemark() + "," + FXJType.MY.GetRemark() + "," + FXJType.YHQG.GetRemark(), "a,b,c,d", "XZQH", "JC", null);
            }
        }

        private void GetGBZDRColumnChartInfo(string three)
        {
            string lb = "a";
            this.CurrentStat = this.gbTable;
            GBZDRYType em = 0;
            switch (three)
            {
                case "涉藏":
                    em = GBZDRYType.SSLY_SZ;
                    lb = "";
                    break;

                case "涉疆":
                    em = GBZDRYType.SSLY_SJ;
                    lb = "";
                    break;

                case "伊斯兰教":
                    em = GBZDRYType.SSLY_YSLJ;
                    lb = "";
                    break;

                case "天主教":
                    em = GBZDRYType.SSLY_TZJ;
                    lb = "";
                    break;

                case "基督教":
                    em = GBZDRYType.SSLY_JDJ;
                    lb = "";
                    break;

                case "上访":
                    em = GBZDRYType.SSLY_SFQT;
                    lb = "";
                    break;

                case "反颠覆破坏":
                    em = GBZDRYType.SSLY_YSXT;
                    lb = "";
                    break;

                case "网上涉稳":
                    em = GBZDRYType.SSLY_WSJCDC;
                    lb = "";
                    break;

                case "非政府组织":
                    em = GBZDRYType.SSLY_FZFZZ;
                    lb = "";
                    break;

                case "佛教":
                    em = GBZDRYType.SSLY_FJ;
                    lb = "";
                    break;

                case "道教":
                    em = GBZDRYType.SSLY_DJ;
                    lb = "";
                    break;

                case "涉蒙":
                    em = GBZDRYType.SSLY_SM;
                    lb = "";
                    break;

                case "会道门":
                    em = GBZDRYType.SSLY_HDM;
                    lb = "";
                    break;

                case "高校":
                    em = GBZDRYType.SSLY_GX;
                    lb = "";
                    break;

                case "涉外企业":
                    em = GBZDRYType.SSLY_SWQY;
                    lb = "";
                    break;

                case "其他":
                    em = GBZDRYType.SSLY_QT;
                    lb = "";
                    break;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), lb, "XZQH", "JC", null);
        }

        private void GetJCJColumnChartInfo(string three)
        {
            JCJType em = 0;
            this.CurrentStat = this.jcjTable;
            string lb = string.Empty;
            switch (three)
            {
                case "总体情况":
                    this.CurrentStat = this.ajTable;
                    this.ConstrastStat = this.jcjTable;
                    this.SingleOrganizeResult((AJYLBType.JCJ_JJ | AJYLBType.JCJ_CJ).ToString(), AJYLBType.JCJ_JJ.GetRemark() + ',' + AJYLBType.JCJ_CJ.GetRemark(), "b,a", "XZQH", "XZQHMC", null);
                    this.ConstrastStat = null;
                    return;

                case "违法犯罪":
                    lb = "c";
                    em = JCJType.WFFZAJ;
                    break;

                case "治安案件":
                    lb = "d";
                    em = JCJType.ZAAJ;
                    break;

                case "火灾事故":
                    lb = "e";
                    em = JCJType.HZSG;
                    break;

                case "交通事故":
                    lb = "f";
                    em = JCJType.JTSG;
                    break;

                case "治安灾害事故":
                    lb = "g";
                    em = JCJType.ZAZHSG;
                    break;

                case "灾害事故":
                    lb = "h";
                    em = JCJType.ZHSG;
                    break;

                case "自杀":
                    lb = "i";
                    em = JCJType.ZS;
                    break;

                case "纠纷":
                    lb = "j";
                    em = JCJType.JF;
                    break;

                case "家庭暴力":
                    lb = "k";
                    em = JCJType.JTBL;
                    break;

                case "走失寻人":
                    lb = "m";
                    em = JCJType.ZSXR;
                    break;

                case "公民求助":
                    lb = "l";
                    em = JCJType.GMQZ;
                    break;

                case "警务监督":
                    lb = "n";
                    em = JCJType.JWJD;
                    break;

                default:
                    return;
            }
            this.TowOrganizeResult(em.ToString(), em.GetRemark(), lb, false, "XZQH", "XZQHMC");
        }

        private void GetJDSBColumnChartInfo(string three)
        {
            this.CurrentStat = this.jsTable;
            string lb = string.Empty;
            JDSType em = 0;
            switch (three)
            {
                case "戒毒总数":
                    em = JDSType.JDSCOUNT;
                    lb = "a";
                    break;

                case "性别":
                    this.SingleOrganizeResult((JDSType.JDS_NVCOUNT | JDSType.JDS_NANCOUNT).ToString(), JDSType.JDS_NANCOUNT.GetRemark() + ',' + JDSType.JDS_NVCOUNT.GetRemark(), "b,c", "XZQH", "XZQHMC", null);
                    return;

                case "戒毒方法":
                    this.SingleOrganizeResult((JDSType.JDS_QTCOUNT | JDSType.JDS_YJCOUNT | JDSType.JDS_GJCOUNT).ToString(), string.Concat(new object[] { JDSType.JDS_GJCOUNT.GetRemark(), ',', JDSType.JDS_YJCOUNT.GetRemark(), ',', JDSType.JDS_QTCOUNT.GetRemark() }), "d,e,f", "XZQH", "XZQHMC", null);
                    return;

                case "口服":
                    em = JDSType.JDS_KFCOUNT;
                    lb = "g";
                    break;

                case "咀嚼":
                    em = JDSType.JDS_JJCOUNT;
                    lb = "h";
                    break;

                case "烟吸":
                    em = JDSType.JDS_YXCOUNT;
                    lb = "i";
                    break;

                case "鼻吸":
                    em = JDSType.JDS_BXCOUNT;
                    lb = "j";
                    break;

                case "烫吸":
                    em = JDSType.JDS_TXCOUNT;
                    lb = "k";
                    break;

                case "皮肤吸收":
                    em = JDSType.JDS_PXCOUNT;
                    lb = "l";
                    break;

                case "肌注":
                    em = JDSType.JDS_JIZCOUNT;
                    lb = "m";
                    break;

                case "静注":
                    em = JDSType.JDS_JZCOUNT;
                    lb = "n";
                    break;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), lb, "XZQH", "XZQHMC", null);
        }

        private void GetJLFBColumnChartInfo(string three)
        {
            string gw = string.Empty;
            this.CurrentStat = this.jlfbTable;
            switch (three)
            {
                case "警员总数":
                    gw = "01dw";
                    this.SingleOrganizeResult(JLFBType.JY_ZRS.ToString(), JLFBType.JY_ZRS.GetRemark(), "a", "XZQH", "JC", gw);
                    return;

                case "厅（局）领导":
                    gw = "01dw";
                    break;

                case "部门领导":
                    gw = "01bm";
                    break;

                case "政工":
                    gw = "02";
                    break;

                case "综合":
                    gw = "03";
                    break;

                case "纪检":
                    gw = "05";
                    break;

                case "治安":
                    gw = "10";
                    break;

                case "法治":
                    gw = "06";
                    break;

                case "户政":
                    gw = "11";
                    break;

                case "交通":
                    gw = "12";
                    break;

                case "侦查":
                    gw = "13";
                    break;

                case "外事":
                    gw = "09";
                    break;

                case "监管":
                    gw = "14";
                    break;

                case "通信":
                    gw = "16";
                    break;

                case "后勤":
                    gw = "04";
                    break;

                case "计安监":
                    gw = "15";
                    break;

                case "消防":
                    gw = "20";
                    break;

                case "警卫":
                    gw = "19";
                    break;

                case "科研":
                    gw = "18";
                    break;

                case "审计":
                    gw = "07";
                    break;

                case "经文保":
                    gw = "08";
                    break;

                case "公安院校":
                    gw = "17";
                    break;

                case "附属":
                    gw = "90";
                    break;

                case "其他":
                    gw = "99";
                    break;

                default:
                    return;
            }
            this.SingleOrganizeResult(JLFBType.ZRS.ToString(), JLFBType.ZRS.GetRemark(), "a", "XZQH", "JC", gw);
        }

        private void GetJLSColumnChartInfo(string three)
        {
            this.CurrentStat = this.jsTable;
            string str = three;
            if (str != null)
            {
                if (!(str == "总数"))
                {
                    if (str == "婚姻状况")
                    {
                        this.SingleOrganizeResult((JLSType.JLS_SOCOUNT | JLSType.JLS_LYCOUNT | JLSType.JLS_YHCOUNT | JLSType.JLS_WHCOUNT).ToString(), string.Concat(new object[] { JLSType.JLS_WHCOUNT.GetRemark(), ',', JLSType.JLS_YHCOUNT.GetRemark(), ',', JLSType.JLS_LYCOUNT.GetRemark(), ',', JLSType.JLS_SOCOUNT.GetRemark() }), "b,c,d,e", "XZQH", "XZQHMC", null);
                    }
                    else if (str == "年龄")
                    {
                        this.SingleOrganizeResult((JLSType.JLS_YSCOUNT | JLSType.JLS_ZDCOUNT | JLSType.JLS_WCNCOUNT).ToString(), string.Concat(new object[] { JLSType.JLS_WCNCOUNT.GetRemark(), ',', JLSType.JLS_ZDCOUNT.GetRemark(), ',', JLSType.JLS_YSCOUNT.GetRemark() }), "f,g,h", "XZQH", "XZQHMC", null);
                    }
                    else if (str == "文化程度")
                    {
                        this.SingleOrganizeResult((JLSType.JLS_DXCOUNT | JLSType.JLS_ZXCOUNT | JLSType.JLS_XXCOUNT | JLSType.JLS_WMCOUNT).ToString(), string.Concat(new object[] { JLSType.JLS_WMCOUNT.GetRemark(), ',', JLSType.JLS_XXCOUNT.GetRemark(), ',', JLSType.JLS_ZXCOUNT.GetRemark(), ',', JLSType.JLS_DXCOUNT.GetRemark() }), "i,j,k,l", "XZQH", "XZQHMC", null);
                    }
                }
                else
                {
                    this.SingleOrganizeResult(JLSType.JLSCOUNT.ToString(), JLSType.JLSCOUNT.GetRemark(), "a", "XZQH", "XZQHMC", null);
                }
            }
        }

        private void GetJSGLColumnChartInfo(string tow, string three)
        {
            string str = tow;
            if (str != null)
            {
                if (!(str == "在押总数"))
                {
                    if (str == "看守所")
                    {
                        this.jsTable.DetailedUrl = this.kssResultURL;
                        this.GetKSSColumnChartInfo(three);
                    }
                    else if (str == "拘留所")
                    {
                        this.jsTable.DetailedUrl = this.jlsResultURL;
                        this.GetJLSColumnChartInfo(three);
                    }
                    else if (str == "戒毒所")
                    {
                        this.jsTable.DetailedUrl = this.jdsResultURL;
                        this.GetJDSBColumnChartInfo(three);
                    }
                    else if (str == "收容教育所")
                    {
                        this.jsTable.DetailedUrl = this.srsResultURL;
                        this.GetSRSBColumnChartInfo(three);
                    }
                }
                else
                {
                    this.jsTable.DetailedUrl = this.zyqkResultURL;
                    this.GetZYZSColumnChartInfo(three);
                }
            }
        }

        private void GetKSSColumnChartInfo(string three)
        {
            string lb = string.Empty;
            this.CurrentStat = this.jsTable;
            KSSType em = 0;
            switch (three)
            {
                case "在押总数":
                    em = KSSType.KSSCOUNT;
                    lb = "a";
                    break;

                case "性别":
                    this.SingleOrganizeResult((KSSType.KSS_NVCOUNT | KSSType.KSS_NANCOUNT).ToString(), KSSType.KSS_NANCOUNT.GetRemark() + ',' + KSSType.KSS_NVCOUNT.GetRemark(), "b,c", "XZQH", "XZQHMC", null);
                    return;

                case "刑拘":
                    em = KSSType.KSS_XJCOUNT;
                    lb = "d";
                    break;

                case "逮捕":
                    em = KSSType.KSS_DBCOUNT;
                    lb = "e";
                    break;

                case "起诉":
                    em = KSSType.KSS_QSCOUNT;
                    lb = "f";
                    break;

                case "审判":
                    em = KSSType.KSS_SPCOUNT;
                    lb = "g";
                    break;

                case "已决犯":
                    em = KSSType.KSS_YJCOUNT;
                    lb = "h";
                    break;

                case "留所":
                    em = KSSType.KSS_LSFXCOUNT;
                    lb = "i";
                    break;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), lb, "XZQH", "XZQHMC", null);
        }

        private void GetLDColumnChartInfo(string three)
        {
            this.CurrentStat = this.dwTable;
            if (three == "合计")
            {
                this.SingleOrganizeResult(DWType.LDCOUNT.ToString(), DWType.LDCOUNT.GetRemark(), "c", "XZQH", "XZQHMC", null);
            }
        }

        private void GetQWGLColumnChartInfo(string tow, string three)
        {
            string str = tow;
            if (str != null)
            {
                if (!(str == "警力分布"))
                {
                    if (str == "移动警务终端")
                    {
                        this.GetYDSBColumnCharInfo(three);
                    }
                    else if (str == "装备管理")
                    {
                        this.GetZBGLColumnChartInfo(three);
                    }
                }
                else
                {
                    this.GetJLFBColumnChartInfo(three);
                }
            }
        }

        private void GetQZCSColumnChartInfo(string three)
        {
            AJYLBType em = 0;
            this.CurrentStat = this.ajTable;
            string lb = string.Empty;
            switch (three)
            {
                case "拘传":
                    lb = "i";
                    em = AJYLBType.QZCS_JC;
                    break;

                case "刑事拘留":
                    lb = "j";
                    em = AJYLBType.QZCS_XSJL;
                    break;

                case "行政拘留":
                    lb = "k";
                    em = AJYLBType.QZCS_XZJL;
                    break;

                case "提请逮捕":
                    lb = "l";
                    em = AJYLBType.QZCS_TQDB;
                    break;

                case "监视居住":
                    lb = "m";
                    em = AJYLBType.QZCS_JSJZ;
                    break;

                case "取保候审":
                    lb = "n";
                    em = AJYLBType.QZCS_QBHS;
                    break;

                default:
                    return;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), lb, "XZQH", "XZQHMC", null);
        }

        private void GetRYGLColumnChartInfo(string tow, string three)
        {
            string str = tow;
            if (str != null)
            {
                if (!(str == "常住人口"))
                {
                    if (str == "暂住人口")
                    {
                        this.GetZZRKBColumnChartInfo(three);
                    }
                    else if (str == "治安重点人员")
                    {
                        this.GetZAZDRColumnChartInfo(three);
                    }
                    else if (str == "DQB重点人口")
                    {
                        this.GetDQBZDRColumnChartInfo(three);
                    }
                    else if (str == "国保重点人员")
                    {
                        this.GetGBZDRColumnChartInfo(three);
                    }
                    else if (str == "反邪教关注人员")
                    {
                        this.GetFXJColumnChartInfo(three);
                    }
                }
                else
                {
                    this.GetCZRKColumnChartInfo(three);
                }
            }
        }

        private void GetSGJTColumnChartInfo(string three)
        {
            string lb = string.Empty;
            this.CurrentStat = this.dwTable;
            DWType em = 0;
            switch (three)
            {
                case "合计":
                    em = DWType.GBCOUNT;
                    lb = "b";
                    break;

                case "天主教堂":
                    em = DWType.TZ_GBCOUNT;
                    lb = "e";
                    break;

                case "基督教堂":
                    em = DWType.JD_GBCOUNT;
                    lb = "f";
                    break;

                case "道观":
                    em = DWType.DG_GBCOUNT;
                    lb = "g";
                    break;

                case "佛教寺庙":
                    em = DWType.FJ_GBCOUNT;
                    lb = "h";
                    break;

                case "藏传佛教寺庙":
                    em = DWType.ZCFJ_GBCOUNT;
                    lb = "i";
                    break;

                case "清真寺":
                    em = DWType.QZS_GBCOUNT;
                    lb = "j";
                    break;

                case "其他":
                    em = DWType.QT_GBCOUNT;
                    lb = "k";
                    break;

                default:
                    return;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), lb, "XZQH", "XZQHMC", null);
        }

        private void GetSRSBColumnChartInfo(string three)
        {
            this.CurrentStat = this.jsTable;
            if (three == "收容总数")
            {
                this.SingleOrganizeResult(SRSType.SRSCOUNT.ToString(), SRSType.SRSCOUNT.GetRemark(), "d", "XZQH", "XZQHMC", null);
            }
        }

        private string GetUrl(string lb, string xzqh, string xzqhmc)
        {
            if ((this._jglx == Jglx.SJ) || (this._jglx == Jglx.ST))
            {
                return this.CurrentStat.GetHostURL(xzqh);
            }
            if (((((this.CurrentStat == this.dwTable) || (this.CurrentStat == this.czrkTable)) || ((this.CurrentStat == this.zzrkTable) || (this.CurrentStat == this.dqbTable))) || ((this.CurrentStat == this.zazdrTable) || (this.CurrentStat == this.zbglTable))) || (this.CurrentStat == this.ydzdTable))
            {
                return this.CurrentStat.GetResultURLTwoParam(lb, xzqh);
            }
            return this.CurrentStat.GetResultURL(new string[] { lb, xzqh, TJSJ.ToString(), xzqhmc });
        }

        private string GetUrl(string lb, string xzqh, string xzqhmc, string type)
        {
            if ((this._jglx == Jglx.SJ) || (this._jglx == Jglx.ST))
            {
                return this.CurrentStat.GetHostURL(xzqh);
            }
            return this.CurrentStat.GetResultURL(new string[] { lb, xzqh, TJSJ.ToString(), xzqhmc, type });
        }

        private void GetWBColumnChartInfo(string three)
        {
            this.CurrentStat = this.dwTable;
            if (three == "合计")
            {
                this.SingleOrganizeResult(DWType.WBCOUNT.ToString(), DWType.WBCOUNT.GetRemark(), "b", "XZQH", "XZQHMC", null);
            }
        }

        private void GetXSAJColumnChartInfo(string three)
        {
            XSAJType em = 0;
            this.CurrentStat = this.xsajTable;
            string lb = string.Empty;
            switch (three)
            {
                case "总体情况":
                    this.CurrentStat = this.ajTable;
                    this.SingleOrganizeResult((AJYLBType.XSAJ_PA | AJYLBType.XSAJ_LA).ToString(), AJYLBType.XSAJ_LA.GetRemark() + ',' + AJYLBType.XSAJ_PA.GetRemark(), "c,d", "XZQH", "XZQHMC", null);
                    return;

                case "放火":
                    lb = "d";
                    em = XSAJType.FH;
                    break;

                case "爆炸":
                    lb = "e";
                    em = XSAJType.BZ;
                    break;

                case "劫持":
                    lb = "f";
                    em = XSAJType.FMDP;
                    break;

                case "杀人":
                    lb = "g";
                    em = XSAJType.GYSR;
                    break;

                case "伤害":
                    lb = "h";
                    em = XSAJType.GYSH;
                    break;

                case "强奸":
                    lb = "i";
                    em = XSAJType.QJIAN;
                    break;

                case "绑架":
                    lb = "j";
                    em = XSAJType.TD;
                    break;

                case "抢劫":
                    lb = "k";
                    em = XSAJType.QJIE;
                    break;

                case "盗窃":
                    lb = "l";
                    em = XSAJType.DQ;
                    break;

                case "抢夺":
                    lb = "m";
                    em = XSAJType.QD;
                    break;

                case "诈骗":
                    lb = "n";
                    em = XSAJType.ZP;
                    break;

                case "电信诈骗":
                    lb = "o";
                    em = XSAJType.DXZP;
                    break;

                case "毒品犯罪":
                    lb = "p";
                    em = XSAJType.DPFZ;
                    break;

                case "经济犯罪":
                    lb = "q";
                    em = XSAJType.JJFZ;
                    break;

                default:
                    return;
            }
            this.TowOrganizeResult(em.ToString(), em.GetRemark(), lb, true, "XZQH", "XZQHMC");
        }

        private void GetYDSBColumnCharInfo(string three)
        {
            this.CurrentStat = this.ydzdTable;
            string str = three;
            if (str != null)
            {
                if (!(str == "移动上网本"))
                {
                    if (str == "手持终端")
                    {
                        this.SingleOrganizeResult((YDSBType.SCJ_ZXS | YDSBType.SCJ_ZS).ToString(), YDSBType.SCJ_ZS.GetRemark() + ',' + YDSBType.SCJ_ZXS.GetRemark(), "scjzs,scjzxs", "UNITCODE", "UNITNAME", null);
                    }
                }
                else
                {
                    this.SingleOrganizeResult((YDSBType.BJB_ZXS | YDSBType.BJB_ZS).ToString(), YDSBType.BJB_ZS.GetRemark() + ',' + YDSBType.BJB_ZXS.GetRemark(), "bjbzs,bjbzxs", "UNITCODE", "UNITNAME", null);
                }
            }
        }

        private void GetZAAJColumnChartInfo(string three)
        {
            this.CurrentStat = this.ajTable;
            string str = three;
            if ((str != null) && (str == "总体情况"))
            {
                this.SingleOrganizeResult((AJYLBType.ZAAJ_CCH | AJYLBType.ZAAJ_ZACF | AJYLBType.ZAAJ_SL).ToString(), string.Concat(new object[] { AJYLBType.ZAAJ_CCH.GetRemark(), ',', AJYLBType.ZAAJ_SL.GetRemark(), ',', AJYLBType.ZAAJ_ZACF.GetRemark() }), "g,f,h", "XZQH", "XZQHMC", null);
            }
        }

        private void GetZAZDRColumnChartInfo(string three)
        {
            this.CurrentStat = this.zazdrTable;
            string str = three;
            if (str != null)
            {
                if (!(str == "年龄"))
                {
                    if (str == "性别")
                    {
                        this.SingleOrganizeResult((ZAZDRYType.WOMAN | ZAZDRYType.MAN).ToString(), ZAZDRYType.MAN.GetRemark() + ',' + ZAZDRYType.WOMAN.GetRemark(), "zazdr,zazdr", "XZQH", "JC", null);
                    }
                    else if (str == "管理方式")
                    {
                        this.SingleOrganizeResult((ZAZDRYType.OTHER | ZAZDRYType.CZ | ZAZDRYType.KC | ZAZDRYType.JG | ZAZDRYType.BJ).ToString(), string.Concat(new object[] { ZAZDRYType.BJ.GetRemark(), ',', ZAZDRYType.JG.GetRemark(), ',', ZAZDRYType.KC.GetRemark(), ',', ZAZDRYType.CZ.GetRemark(), ',', ZAZDRYType.OTHER.GetRemark() }), "zazdr,zazdr,zazdr,zazdr,zazdr", "XZQH", "JC", null);
                    }
                }
                else
                {
                    this.SingleOrganizeResult((ZAZDRYType.LESSTHANEIGHTEEN | ZAZDRYType.BETWEENFORTYANDEIGHTEEN | ZAZDRYType.MORETHANFORTY).ToString(), string.Concat(new object[] { ZAZDRYType.LESSTHANEIGHTEEN.GetRemark(), ',', ZAZDRYType.BETWEENFORTYANDEIGHTEEN.GetRemark(), ',', ZAZDRYType.MORETHANFORTY.GetRemark() }), "zazdr,zazdr,zazdr", "XZQH", "JC", null);
                }
            }
        }

        private void GetZBGLColumnChartInfo(string three)
        {
            ZBGLType em = 0;
            this.CurrentStat = this.zbglTable;
            string lb = string.Empty;
            switch (three)
            {
                case "交通装备":
                    lb = "jtzb";
                    em = ZBGLType.JTZB;
                    break;

                case "通信装备":
                    lb = "tszb";
                    em = ZBGLType.TSZB;
                    break;

                case "警械及携行装备":
                    lb = "jxjxxzb";
                    em = ZBGLType.JXJXXZB;
                    break;

                case "计算机信息装备":
                    lb = "jsjxxzb";
                    em = ZBGLType.JSJXXZB;
                    break;

                case "警用防护装备":
                    lb = "jyfhzb";
                    em = ZBGLType.JYFHZB;
                    break;

                case "刑侦物证鉴定装备":
                    lb = "xzwzjdzb";
                    em = ZBGLType.XZWZJDZB;
                    break;

                case "侦察审讯装备":
                    lb = "zcsxzb";
                    em = ZBGLType.ZCSXZB;
                    break;

                case "安全防范技术装备":
                    lb = "aqffjszb";
                    em = ZBGLType.AQFFJSZB;
                    break;

                case "办公设备":
                    lb = "bgsb";
                    em = ZBGLType.BGSB;
                    break;

                case "行动技术装备":
                    lb = "qtjszb";
                    em = ZBGLType.QTJSZB;
                    break;

                case "其他":
                    lb = "qt";
                    em = ZBGLType.QT;
                    break;

                default:
                    return;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), lb, "XZQH", "XZQHMC", null);
        }

        private void GetZDDWColumnChartInfo(string three)
        {
            string lb = string.Empty;
            this.CurrentStat = this.dwTable;
            DWType em = 0;
            switch (three)
            {
                case "大型商场":
                    em = DWType.DXSC_FKCOUNT;
                    lb = "m";
                    break;

                case "医院":
                    em = DWType.YY_FKCOUNT;
                    lb = "n";
                    break;

                case "学校":
                    em = DWType.XX_FKCOUNT;
                    lb = "o";
                    break;

                case "国家机关":
                    em = DWType.GJJG_FKCOUNT;
                    lb = "p";
                    break;

                case "车站码头机场":
                    em = DWType.CZMT_FKCOUNT;
                    lb = "q";
                    break;

                case "水电站":
                    em = DWType.SDZ_FKCOUNT;
                    lb = "r";
                    break;

                case "广电通信枢纽":
                    em = DWType.GDTX_FKCOUNT;
                    lb = "s";
                    break;

                case "其他":
                    em = DWType.QT_FKCOUNT;
                    lb = "t";
                    break;
            }
            this.SingleOrganizeResult(em.ToString(), em.GetRemark(), lb, "XZQH", "XZQHMC", null);
        }

        private void GetZYZSColumnChartInfo(string three)
        {
            this.CurrentStat = this.jsTable;
            if (three == "合计")
            {
                string columns = KSSType.KSSCOUNT.ToString() + "," + JLSType.JLSCOUNT.ToString() + "," + JDSType.JDSCOUNT.ToString() + "," + SRSType.SRSCOUNT.ToString();
                string name = "看守所,拘留所,戒毒所,收容所";
                this.SingleOrganizeResult(columns, name, "a,b,c,d", "XZQH", "XZQHMC", null);
            }
        }

        private void GetZZRKBColumnChartInfo(string three)
        {
            this.CurrentStat = this.zzrkTable;
            string str = three;
            if (str != null)
            {
                if (!(str == "暂住时间"))
                {
                    if (str == "性别")
                    {
                        this.SingleOrganizeResult((ZZRKType.WOMAN | ZZRKType.MAN).ToString(), ZZRKType.MAN.GetRemark() + ',' + ZZRKType.WOMAN.GetRemark(), "zk,zk", "XZQH", "JC", null);
                    }
                    else if (str == "暂住事由")
                    {
                        this.SingleOrganizeResult((ZZRKType.OTHER | ZZRKType.JZMG | ZZRKType.QYLSG | ZZRKType.GTHJS | ZZRKType.QTLW).ToString(), string.Concat(new object[] { ZZRKType.GTHJS.GetRemark(), ',', ZZRKType.JZMG.GetRemark(), ',', ZZRKType.OTHER.GetRemark(), ',', ZZRKType.QTLW.GetRemark(), ',', ZZRKType.QYLSG.GetRemark() }), "zk,zk,zk,zk,zk", "XZQH", "JC", null);
                    }
                }
                else
                {
                    this.SingleOrganizeResult((ZZRKType.LESSTHANTHREEMONTH | ZZRKType.MORETHANTHREEMONTH | ZZRKType.MORETHANONEYEAR).ToString(), string.Concat(new object[] { ZZRKType.LESSTHANTHREEMONTH.GetRemark(), ',', ZZRKType.MORETHANTHREEMONTH.GetRemark(), ',', ZZRKType.MORETHANONEYEAR.GetRemark() }), "zk,zk,zk", "XZQH", "JC", null);
                }
            }
        }

        public void sd()
        {
        }

        private void SetFieldsKyes()
        {
            this.ajTable.keys.Add("dayArray");
            this.ajTable.keys.Add("monthArray");
            this.ajTable.keys.Add("yearArray");
            this.czrkTable.keys.Add("czrkArray");
            this.dqbTable.keys.Add("dqbArray");
            this.dwTable.keys.Add("dwArray");
            this.fxjTable.keys.Add("fxjArray");
            this.gajgtjTable.keys.Add("gajgtjArray");
            this.gbTable.keys.Add("gbArray");
            this.grkylbTable.keys.Add("grkylbArray");
            this.gajgzbTable.keys.Add("hqgajgzbArray");
            this.jcjTable.keys.Add("jcjjjArray");
            this.jcjTable.keys.Add("jcjcjArray");
            this.jsTable.keys.Add("jsArray");
            this.qzcsTable.keys.Add("qzcsArray");
            this.xsajTable.keys.Add("xsajlaArray");
            this.xsajTable.keys.Add("xsajpaArray");
            this.zaajTable.keys.Add("zaajArray");
            this.zazdrTable.keys.Add("zazdrArray");
            this.zzrkTable.keys.Add("zzrkArray");
            this.gajgTable.keys.Add("gajgArray");
            this.jlfbTable.keys.Add("jlfbArray");
            this.ydzdTable.keys.Add("ydzbArray");
            this.zbglTable.keys.Add("zbglArray");
        }

        private void SetFieldsUrl()
        {
            string configFileName = "webservice.config";
            KeyValueConfigurationCollection valueBy = ConfigHelper.GetValueBy(configFileName);
            this.ajTable.Url = valueBy["案件预览"].Value.ToString();
            this.czrkTable.Url = valueBy["常住人口"].Value.ToString();
            this.zzrkTable.Url = valueBy["暂住人口"].Value.ToString();
            this.dqbTable.Url = valueBy["大情报"].Value.ToString();
            this.dwTable.Url = valueBy["单位管理"].Value.ToString();
            this.fxjTable.Url = valueBy["反邪教"].Value.ToString();
            this.gajgtjTable.Url = valueBy["公安机关统计"].Value.ToString();
            this.gbTable.Url = valueBy["国保"].Value.ToString();
            this.grkylbTable.Url = valueBy["人员管理"].Value.ToString();
            this.gajgzbTable.Url = valueBy["公安机构坐标"].Value.ToString();
            this.jcjTable.Url = valueBy["接处警"].Value.ToString();
            this.jsTable.Url = valueBy["监所管理"].Value.ToString();
            this.qzcsTable.Url = valueBy["强制措施"].Value.ToString();
            this.xsajTable.Url = valueBy["刑事案件"].Value.ToString();
            this.zaajTable.Url = valueBy["治安案件"].Value.ToString();
            this.zazdrTable.Url = valueBy["治安重点人"].Value.ToString();
            this.gajgTable.Url = valueBy["公安机关统计"].Value.ToString();
            this.jlfbTable.Url = valueBy["警力分布"].Value.ToString();
            this.ydzdTable.Url = valueBy["移动终端"].Value.ToString();
            this.zbglTable.Url = valueBy["装备管理"].Value.ToString();
            this.czrkTable.HostUrl = valueBy["人员管理Host"].Value.ToString() + "?xzqh={0}&type=ck";
            this.zzrkTable.HostUrl = valueBy["人员管理Host"].Value.ToString() + "?xzqh={0}&type=zk";
            this.dqbTable.HostUrl = valueBy["人员管理Host"].Value.ToString() + "?xzqh={0}&type=dqb";
            this.zazdrTable.HostUrl = valueBy["人员管理Host"].Value.ToString() + "?xzqh={0}&type=zazdr";
            this.gbTable.HostUrl = valueBy["人员管理Host"].Value.ToString() + "?xzqh={0}&type=gb";
            this.fxjTable.HostUrl = valueBy["人员管理Host"].Value.ToString() + "?xzqh={0}&type=fxj";
            this.dwTable.HostUrl = valueBy["单位管理Host"].Value.ToString() + "?xzqh={0}";
            this.jsTable.HostUrl = valueBy["监所管理Host"].Value.ToString();
            this.ajTable.HostUrl = valueBy["案件管理Host"].Value.ToString() + "?xzqh={0}&chxLb=year&cursel=3";
            this.zaajTable.HostUrl = this.ajTable.HostUrl;
            this.qzcsTable.HostUrl = this.ajTable.HostUrl;
            this.jcjTable.HostUrl = this.ajTable.HostUrl;
            this.xsajTable.HostUrl = this.ajTable.HostUrl;
            this.gajgTable.HostUrl = valueBy["勤务管理Host"].Value.ToString();
            this.jlfbTable.HostUrl = this.gajgTable.HostUrl;
            this.ydzdTable.HostUrl = this.gajgTable.HostUrl;
            this.zbglTable.HostUrl = this.gajgTable.HostUrl;
            this.dwTable.DetailedUrl = valueBy["单位管理URL"].Value.ToString() + "?lb={0}&xzqh={1}";
            this.czrkTable.DetailedUrl = valueBy["人员管理URL"].Value.ToString() + "?view={0}List&type={0}&xzqh={1}";
            this.zzrkTable.DetailedUrl = valueBy["人员管理URL"].Value.ToString() + "?view={0}List&type={0}&xzqh={1}";
            this.dqbTable.DetailedUrl = valueBy["人员管理URL"].Value.ToString() + "?view={0}List&type={0}&xzqh={1}";
            this.zazdrTable.DetailedUrl = valueBy["人员管理URL"].Value.ToString() + "?view={0}List&type={0}&xzqh={1}";
            this.ajTable.DetailedUrl = valueBy["案件一览表URL"].Value.ToString() + "?ajlb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}&chxLb=year";
            this.zaajTable.DetailedUrl = valueBy["接触警LeftURL"].Value.ToString() + "?ajlb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}&chxLb=zaaj";
            this.qzcsTable.DetailedUrl = valueBy["接触警LeftURL"].Value.ToString() + "?ajlb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}&chxLb=qzcs";
            this.jcjTable.DetailedUrl = valueBy["接触警LeftURL"].Value.ToString() + "?ajlb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}&chxLb={4}";
            this.xsajTable.DetailedUrl = valueBy["接触警LeftURL"].Value.ToString() + "?ajlb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}&chxLb={4}";
            this.zyqkResultURL = valueBy["在押情况URL"].Value.ToString() + "?lb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}";
            this.kssResultURL = valueBy["看守所URL"].Value.ToString() + "?lb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}";
            this.jlsResultURL = valueBy["拘留所URL"].Value.ToString() + "?lb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}";
            this.jdsResultURL = valueBy["戒毒所URL"].Value.ToString() + "?lb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}";
            this.srsResultURL = valueBy["收容所URL"].Value.ToString() + "?lb={0}&xzqh={1}&tjsj={2}&xzqhmc={3}";
            this.zbglTable.DetailedUrl = valueBy["装备管理URL"].Value.ToString() + "?type={0}&xzqh={1}&xzqhType=xj";
            this.ydzdTable.DetailedUrl = valueBy["移动终端URL"].Value.ToString() + "?type={0}&xzqh={1}";
        }

        private double GetContrast(DataRow row, String Name)
        {
            if (row == null)
                return 0;

            if(row.Table.Columns.Contains(Name))
            {
                double contrast;
                if (double.TryParse(row[Name].ToString(), out contrast))
                    return contrast;
            }

            return 0;
        }
        private List<StatisticInfo> SingleOrganizeResult(string columns, string name, string lb, string xzqhCol = "XZQH", string xzqhmcCol = "XZQHMC", string gw = null)
        {
            string[] strArray = columns.Split(new char[] { ',' });
            int index = 0;
            while (index < strArray.Length)
            {
                strArray[index] = strArray[index].Trim();
                index++;
            }
            string[] strArray2 = lb.Split(new char[] { ',' });
            string[] strArray3 = name.Split(new char[] { ',' });
            this.resultInfo = new List<StatisticInfo>();
            foreach (string str in this.gajgzbTable.AreaData.Keys)
            {
                if (gw == null)
                {
                    this.CurrentStat.NewUrlParam = this.XZHGToUrlParam(str);
                }
                else
                {
                    this.CurrentStat.NewUrlParam = this.XZHGToUrlParam(str) + string.Format("&gw={0}&type=QS", gw);
                }

                if (this.ConstrastStat != null)
                {
                    this.ConstrastStat.NewUrlParam = this.CurrentStat.NewUrlParam;
                }

                foreach (DataRow row in this.gajgzbTable.AreaData[str])
                {
                    StatisticInfo item = new StatisticInfo();
                    Dictionary<string, StatisticInfo.Value> dictionary = new Dictionary<string, StatisticInfo.Value>();
                    DataRow row2 = this.XZQHMateRow(row["GAJG_KEY"].ToString(), xzqhCol);
                    //DataRow row3 = this.CurrentStat.Screen(row["GAJG_KEY"].ToString(), AffairsType.JJ, xzqhCol);
                    //DataRow row4 = this.CurrentStat.Screen(row["GAJG_KEY"].ToString(), AffairsType.CJ, xzqhCol);

                    if (row2 != null)
                    {
                        index = 0;
                        foreach (string str2 in strArray)
                        {
                            DataRow row3 = null;
                            if (str2.Contains("JJ") && ConstrastStat != null)
                            {
                                row3 = this.ConstrastStat.Screen(row["GAJG_KEY"].ToString(), AffairsType.JJ, xzqhCol);
                            }
                            else if (str2.Contains("CJ") && ConstrastStat != null)
                            {
                                row3 = this.ConstrastStat.Screen(row["GAJG_KEY"].ToString(), AffairsType.CJ, xzqhCol);
                            }

                            StatisticInfo.Value value2 = new StatisticInfo.Value(this.GetUrl(strArray2[index], row2[xzqhCol].ToString(), row2[xzqhmcCol].ToString()), long.Parse(row2[str2].ToString()), GetContrast(row3, "XB"));
                            dictionary.Add(strArray3[index], value2);
                            index++;
                        }
                        item.StatMap = dictionary;
                        item.JgId = row["GAJGDM"].ToString();
                        item.Name = row["GAJGJC"].ToString();
                        item.Latitude = double.Parse(row["GAJGWD"].ToString());
                        item.Longitude = double.Parse(row["GAJGJD"].ToString());
                        this.resultInfo.Add(item);
                    }
                }
            }
            return this.resultInfo;
        }

        private List<StatisticInfo> TowOrganizeResult(string columns, string name, string lb, bool aj, string xzqhCol = "XZQH", string xzqhmcCol = "XZQHMC")
        {
            string[] strArray = columns.Split(new char[] { ',' });
            string[] strArray2 = lb.Split(new char[] { ',' });
            string[] strArray3 = name.Split(new char[] { ',' });
            this.resultInfo = new List<StatisticInfo>();
            foreach (string str in this.gajgzbTable.AreaData.Keys)
            {
                this.CurrentStat.NewUrlParam = this.XZHGToUrlParam(str);
                foreach (DataRow row in this.gajgzbTable.AreaData[str])
                {
                    StatisticInfo item = new StatisticInfo();
                    Dictionary<string, StatisticInfo.Value> dictionary = new Dictionary<string, StatisticInfo.Value>();
                    DataRow row2 = this.XZQHMateRow(row["GAJG_KEY"].ToString(), xzqhCol);
                    DataRow row3 = this.XZQHMateRow(row["GAJG_KEY"].ToString(), AffairsType.CJ, xzqhCol);
                    if (row2 != null)
                    {
                        int index = 0;
                        foreach (string str2 in strArray)
                        {
                            StatisticInfo.Value value2;
                            StatisticInfo.Value value3;
                            if (aj)
                            {
                                value2 = new StatisticInfo.Value(this.GetUrl(strArray2[index], row2[xzqhCol].ToString(), row2[xzqhmcCol].ToString(), "la"), long.Parse(row2[str2].ToString()), 0);    //GetContrast(row2, "XB")
                                value3 = new StatisticInfo.Value(this.GetUrl(strArray2[index], row3[xzqhCol].ToString(), row3[xzqhmcCol].ToString(), "pa"), long.Parse(row3[str2].ToString()), 0);   //GetContrast(row3, "XB")
                                dictionary.Add("立案", value2);
                                dictionary.Add("破案", value3);
                            }
                            else
                            {
                                value2 = new StatisticInfo.Value(this.GetUrl(strArray2[index], row2[xzqhCol].ToString(), row2[xzqhmcCol].ToString(), "jj"), long.Parse(row2[str2].ToString()), 0);    //GetContrast(row2, "XB")
                                value3 = new StatisticInfo.Value(this.GetUrl(strArray2[index], row3[xzqhCol].ToString(), row3[xzqhmcCol].ToString(), "cj"), long.Parse(row3[str2].ToString()), 0);    //GetContrast(row3, "XB")
                                dictionary.Add("接警", value2);
                                dictionary.Add("处警", value3);
                            }
                            index++;
                        }
                        item.StatMap = dictionary;
                        item.JgId = row["GAJGDM"].ToString();
                        item.Name = row["GAJGJC"].ToString();
                        item.Latitude = double.Parse(row["GAJGWD"].ToString());
                        item.Longitude = double.Parse(row["GAJGJD"].ToString());
                        this.resultInfo.Add(item);
                    }
                }
            }
            return this.resultInfo;
        }

        private string XZHGToUrlParam(string xzqh)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(xzqh))
            {
                str = "?xzqh=" + xzqh;
            }
            return str;
        }

        private DataRow XZQHMateRow(string xzqh, string xzqhCol)
        {
            if (this.CurrentStat == null)
            {
                return null;
            }
            if (this.CurrentStat == this.ajTable)
            {
                return this.CurrentStat.Screen(xzqh, AffairsType.Y, xzqhCol);
            }
            return this.CurrentStat.Screen(xzqh, AffairsType.DEF, xzqhCol);
        }

        private DataRow XZQHMateRow(string xzqh, AffairsType aff, string xzqhCol)
        {
            if (this.CurrentStat == null)
            {
                return null;
            }
            if (this.CurrentStat == this.ajTable)
            {
                return this.CurrentStat.Screen(xzqh, AffairsType.Y, xzqhCol);
            }
            return this.CurrentStat.Screen(xzqh, aff, xzqhCol);
        }
    }
}

