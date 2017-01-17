namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum YDSBType
    {
        [Remark("笔记本离线数")]
        BJB_BZXS = 8,
        [Remark("笔记本总数")]
        BJB_ZS = 1,
        [Remark("笔记本在线率")]
        BJB_ZXL = 4,
        [Remark("笔记本在线数")]
        BJB_ZXS = 2,
        [Remark("手持离线数")]
        SCJ_BZXS = 0x80,
        [Remark("手持总数")]
        SCJ_ZS = 0x10,
        [Remark("手持在线率")]
        SCJ_ZXL = 0x40,
        [Remark("手持在线数")]
        SCJ_ZXS = 0x20
    }
}

