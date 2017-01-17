namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum JDSType
    {
        ALL = -1,
        [Remark("鼻吸")]
        JDS_BXCOUNT = 0x200,
        [Remark("干戒")]
        JDS_GJCOUNT = 8,
        [Remark("肌注")]
        JDS_JIZCOUNT = 0x1000,
        [Remark("咀嚼")]
        JDS_JJCOUNT = 0x80,
        [Remark("静注")]
        JDS_JZCOUNT = 0x2000,
        [Remark("口服")]
        JDS_KFCOUNT = 0x40,
        [Remark("男性")]
        JDS_NANCOUNT = 2,
        [Remark("女性")]
        JDS_NVCOUNT = 4,
        [Remark("皮肤吸收")]
        JDS_PXCOUNT = 0x800,
        [Remark("其他")]
        JDS_QTCOUNT = 0x20,
        [Remark("烫吸")]
        JDS_TXCOUNT = 0x400,
        [Remark("药戒")]
        JDS_YJCOUNT = 0x10,
        [Remark("烟吸")]
        JDS_YXCOUNT = 0x100,
        [Remark("总数")]
        JDSCOUNT = 1
    }
}

