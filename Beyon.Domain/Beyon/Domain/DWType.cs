namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum DWType
    {
        ALL = -1,
        [Remark("车站码头机场")]
        CZMT_FKCOUNT = 0x8000,
        [Remark("道观")]
        DG_GBCOUNT = 0x20,
        [Remark("大型商场")]
        DXSC_FKCOUNT = 0x800,
        [Remark("佛教寺庙")]
        FJ_GBCOUNT = 0x40,
        [Remark("小计")]
        FKCOUNT = 0x400,
        [Remark("合计")]
        GBCOUNT = 4,
        [Remark("广电通信枢纽")]
        GDTX_FKCOUNT = 0x20000,
        [Remark("国家机关")]
        GJJG_FKCOUNT = 0x4000,
        [Remark("合计")]
        HJ = 0x80000,
        [Remark("基督教堂")]
        JD_GBCOUNT = 0x10,
        [Remark("旅店")]
        LDCOUNT = 2,
        [Remark("其他")]
        QT_FKCOUNT = 0x40000,
        [Remark("其他")]
        QT_GBCOUNT = 0x200,
        [Remark("清真寺")]
        QZS_GBCOUNT = 0x100,
        [Remark("水电站")]
        SDZ_FKCOUNT = 0x10000,
        [Remark("天主教堂")]
        TZ_GBCOUNT = 8,
        [Remark("网吧")]
        WBCOUNT = 1,
        [Remark("学校")]
        XX_FKCOUNT = 0x2000,
        [Remark("医院")]
        YY_FKCOUNT = 0x1000,
        [Remark("藏传佛教寺庙")]
        ZCFJ_GBCOUNT = 0x80
    }
}

