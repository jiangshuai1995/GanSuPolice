namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum QZCSType
    {
        ALL = -1,
        [Remark("今年拘传")]
        JN_JCCOUNT = 1,
        [Remark("今年监视居住")]
        JN_JSZJCOUNT = 0x1000,
        [Remark("今年取保候审")]
        JN_QBHSCOUNT = 0x8000,
        [Remark("今年提请逮捕")]
        JN_TQDBCOUNT = 0x200,
        [Remark("今年刑事拘留")]
        JN_XSJLCOUNT = 8,
        [Remark("今年治安拘留")]
        JN_XZJLCOUNT = 0x40,
        [Remark("去年拘传")]
        QN_JCCOUNT = 2,
        [Remark("去年监视居住")]
        QN_JSZJCOUNT = 0x2000,
        [Remark("去年取保候审")]
        QN_QBHSCOUNT = 0x10000,
        [Remark("去年提请逮捕")]
        QN_TQDBCOUNT = 0x400,
        [Remark("去年刑事拘留")]
        QN_XSJLCOUNT = 0x10,
        [Remark("去年治安拘留")]
        QN_XZJLCOUNT = 0x80,
        [Remark("统计时间")]
        TJSJ = 0x40000,
        [Remark("拘传同比")]
        XB_JCCOUNT = 4,
        [Remark("监视居住同比")]
        XB_JSZJCOUNT = 0x4000,
        [Remark("取保候审同比")]
        XB_QBHSCOUNT = 0x20000,
        [Remark("提请逮捕同比")]
        XB_TQDBCOUNT = 0x800,
        [Remark("刑事拘留同比")]
        XB_XSJLCOUNT = 0x20,
        [Remark("治安拘留同比")]
        XB_XZJLCOUNT = 0x100,
        [Remark("总体情况")]
        ZTQK = 0x80000
    }
}

