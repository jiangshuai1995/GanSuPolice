namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum JLFBType
    {
        [Remark("警种分类")]
        GW = 4,
        [Remark("警员总数")]
        JY_ZRS = 2,
        [Remark("所占比例")]
        SZBL = 8,
        [Remark("总人数")]
        ZRS = 1
    }
}

