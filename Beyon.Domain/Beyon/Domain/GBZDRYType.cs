namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum GBZDRYType
    {
        ALL = -1,
        [Remark("道教")]
        SSLY_DJ = 0x800,
        [Remark("佛教")]
        SSLY_FJ = 0x400,
        [Remark("反政府组织")]
        SSLY_FZFZZ = 0x200,
        [Remark("高校")]
        SSLY_GX = 0x4000,
        [Remark("会道门")]
        SSLY_HDM = 0x2000,
        [Remark("基督教")]
        SSLY_JDJ = 0x20,
        [Remark("其他")]
        SSLY_QT = 0x10000,
        [Remark("上访群体")]
        SSLY_SFQT = 0x40,
        [Remark("涉疆")]
        SSLY_SJ = 4,
        [Remark("涉蒙")]
        SSLY_SM = 0x1000,
        [Remark("涉外企业")]
        SSLY_SWQY = 0x8000,
        [Remark("涉藏")]
        SSLY_SZ = 2,
        [Remark("天主教")]
        SSLY_TZJ = 0x10,
        [Remark("网上涉稳")]
        SSLY_WSJCDC = 0x100,
        [Remark("伊斯兰教")]
        SSLY_YSLJ = 8,
        [Remark("反颠覆破坏")]
        SSLY_YSXT = 0x80,
        [Remark("合计")]
        TOTAL = 1
    }
}

