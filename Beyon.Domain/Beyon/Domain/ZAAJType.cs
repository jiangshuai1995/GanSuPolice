namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum ZAAJType
    {
        ALL = -1,
        [Remark("今年查处")]
        CC_JNCOUNT = 8,
        [Remark("去年查处")]
        CC_QNCOUNT = 0x10,
        [Remark("查处同比")]
        CC_XBCOUNT = 0x20,
        [Remark("今年治安处罚")]
        CF_JNCOUNT = 0x40,
        [Remark("去年治安处罚")]
        CF_QNCOUNT = 0x80,
        [Remark("治安处罚同比")]
        CF_XBCOUNT = 0x100,
        [Remark("今年受理")]
        SL_JNCOUNT = 1,
        [Remark("去年受理")]
        SL_QNCOUNT = 2,
        [Remark("受理同比")]
        SL_XBCOUNT = 4,
        [Remark("统计时间")]
        TJSJ = 0x200,
        [Remark("总体情况")]
        ZTQK = 0x400
    }
}

