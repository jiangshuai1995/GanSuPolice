namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum ZZRKType
    {
        ALL = -1,
        [Remark("个体户经商")]
        GTHJS = 0x100,
        [Remark("建筑民工")]
        JZMG = 0x400,
        [Remark("少于三个月")]
        LESSTHANTHREEMONTH = 0x40,
        [Remark("男")]
        MAN = 1,
        [Remark("超过一年")]
        MORETHANONEYEAR = 0x10,
        [Remark("超过三个月")]
        MORETHANTHREEMONTH = 0x20,
        [Remark("其他暂住事由")]
        OTHER = 0x800,
        [Remark("其他劳务")]
        QTLW = 0x80,
        [Remark("企业临时工")]
        QYLSG = 0x200,
        [Remark("省外")]
        SN = 4,
        [Remark("省内")]
        SW = 8,
        [Remark("总数")]
        TOTAL = 0x1000,
        [Remark("女")]
        WOMAN = 2
    }
}

