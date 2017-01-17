namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum KSSType
    {
        ALL = -1,
        [Remark("逮捕")]
        KSS_DBCOUNT = 0x10,
        [Remark("留所")]
        KSS_LSFXCOUNT = 0x100,
        [Remark("男性")]
        KSS_NANCOUNT = 2,
        [Remark("女性")]
        KSS_NVCOUNT = 4,
        [Remark("起诉")]
        KSS_QSCOUNT = 0x20,
        [Remark("审判")]
        KSS_SPCOUNT = 0x40,
        [Remark("刑拘")]
        KSS_XJCOUNT = 8,
        [Remark("已决犯")]
        KSS_YJCOUNT = 0x80,
        [Remark("合计")]
        KSSCOUNT = 1
    }
}

