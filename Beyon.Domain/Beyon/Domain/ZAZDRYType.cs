namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum ZAZDRYType
    {
        ALL = -1,
        [Remark("十八至四十岁")]
        BETWEENFORTYANDEIGHTEEN = 0x20,
        [Remark("帮教")]
        BJ = 0x80,
        [Remark("查证")]
        CZ = 0x400,
        [Remark("监管")]
        JG = 0x100,
        [Remark("考察")]
        KC = 0x200,
        [Remark("小于十八岁")]
        LESSTHANEIGHTEEN = 0x40,
        [Remark("男")]
        MAN = 2,
        [Remark("大于四十岁")]
        MORETHANFORTY = 0x10,
        [Remark("其他")]
        OTHER = 0x800,
        [Remark("总数")]
        TOTAL = 0x1000,
        [Remark("总数")]
        TOTALCOUNT = 1,
        [Remark("未知性别")]
        UNKNOW = 8,
        [Remark("女")]
        WOMAN = 4
    }
}

