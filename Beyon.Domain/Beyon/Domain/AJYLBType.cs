namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum AJYLBType
    {
        [Remark("接警")]
        JCJ_JJ = 1,
        [Remark("处警")]
        JCJ_CJ = 2,
        [Remark("拘传")]
        QZCS_JC = 0x20,
        [Remark("监视居住")]
        QZCS_JSJZ = 0x200,
        [Remark("取保候审")]
        QZCS_QBHS = 0x400,
        [Remark("提请逮捕")]
        QZCS_TQDB = 0x100,
        [Remark("刑事拘留")]
        QZCS_XSJL = 0x40,
        [Remark("行政拘留")]
        QZCS_XZJL = 0x80,
        [Remark("提交时间")]
        TJSJ = 0x2000,
        [Remark("立案")]
        XSAJ_LA = 4,
        [Remark("破案")]
        XSAJ_PA = 8,
        [Remark("抓获嫌疑人")]
        XSAJ_ZHXYR = 0x10,
        [Remark("查处")]
        ZAAJ_CCH = 0x4000,
        [Remark("受理")]
        ZAAJ_SL = 0x800,
        [Remark("治安处罚")]
        ZAAJ_ZACF = 0x1000
    }
}

