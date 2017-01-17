namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum CZRKType
    {
        ALL = -1,
        [Remark("城镇户口")]
        CZHK = 4,
        [Remark("男")]
        MAN = 1,
        [Remark("农村户口")]
        NCHK = 8,
        [Remark("其他标志")]
        OTHERBZ = 0x80,
        [Remark("其他户口")]
        OTHERHK = 0x10,
        [Remark("女")]
        WOMAN = 2,
        [Remark("正常")]
        ZC = 0x20,
        [Remark("注销")]
        ZX = 0x40
    }
}

