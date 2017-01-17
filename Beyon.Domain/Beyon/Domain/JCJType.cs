namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum JCJType
    {
        ALL = -1,
        [Remark("公民求助")]
        GMQZ = 0x800,
        [Remark("火灾事故")]
        HZSG = 8,
        [Remark("纠纷")]
        JF = 0x100,
        [Remark("家庭暴力")]
        JTBL = 0x200,
        [Remark("交通事故")]
        JTSG = 0x10,
        [Remark("警务监督")]
        JWJD = 0x1000,
        [Remark("违法犯罪")]
        WFFZAJ = 2,
        [Remark("治安案件")]
        ZAAJ = 4,
        [Remark("治安灾害事故")]
        ZAZHSG = 0x20,
        [Remark("灾害事故")]
        ZHSG = 0x40,
        [Remark("自杀")]
        ZS = 0x80,
        [Remark("走失寻人")]
        ZSXR = 0x400,
        [Remark("总体情况")]
        ZTQK = 1
    }
}

