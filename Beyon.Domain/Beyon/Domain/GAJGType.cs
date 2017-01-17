namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum GAJGType
    {
        [Remark("市")]
        FJ_NUM = 0x10,
        [Remark("县")]
        FJJG_NUM = 0x20,
        [Remark("行业公安")]
        HYGA_NUM = 0x80,
        [Remark("派出所")]
        PCS_NUM = 0x40,
        [Remark("市")]
        SJ_NUM = 4,
        [Remark("州")]
        SJJG_NUM = 8,
        [Remark("省厅")]
        ST_NUM = 1,
        [Remark("厅机关")]
        STJG_NUM = 2
    }
}

