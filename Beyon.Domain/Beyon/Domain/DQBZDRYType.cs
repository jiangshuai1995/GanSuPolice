namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum DQBZDRYType
    {
        ALL = -1,
        [Remark("男")]
        MAN = 2,
        [Remark("其他")]
        OTHER = 0x400,
        [Remark("前科")]
        QK = 0x80,
        [Remark("涉毒")]
        SD = 0x10,
        [Remark("上访")]
        SF = 0x200,
        [Remark("涉恐")]
        SK = 0x20,
        [Remark("涉稳")]
        SW = 0x40,
        [Remark("总数")]
        TOTAL = 1,
        [Remark("女")]
        WOMAN = 4,
        [Remark("肇事肇祸精神病")]
        ZSZHJSB = 0x100,
        [Remark("在逃")]
        ZT = 8
    }
}

