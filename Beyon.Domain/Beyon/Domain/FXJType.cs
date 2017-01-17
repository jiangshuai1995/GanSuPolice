namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum FXJType
    {
        ALL = -1,
        [Remark("法轮功")]
        FLG = 2,
        [Remark("有害气功")]
        MY = 4,
        [Remark("合计")]
        TOTAL = 1,
        [Remark("冒用")]
        YHQG = 8
    }
}

