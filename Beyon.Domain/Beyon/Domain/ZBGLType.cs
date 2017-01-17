namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum ZBGLType
    {
        [Remark("安全防范技术装备")]
        AQFFJSZB = 0x400,
        [Remark("办公设备")]
        BGSB = 0x800,
        [Remark("计算机信息装备")]
        JSJXXZB = 0x401,
        [Remark("交通装备")]
        JTZB = 8,
        [Remark("警械及携行装备")]
        JXJXXZB = 0x20,
        [Remark("警用防护装备")]
        JYFHZB = 0x80,
        [Remark("其他")]
        QT = 0x2000,
        [Remark("行动技术装备")]
        QTJSZB = 0x1000,
        [Remark("合计")]
        TATOL = 4,
        [Remark("通信装备")]
        TSZB = 0x10,
        [Remark("市级")]
        TYPE = 2,
        [Remark("行政区划")]
        XZQH = 1,
        [Remark("刑侦物证鉴定装备")]
        XZWZJDZB = 0x100,
        [Remark("侦察审讯装备")]
        ZCSXZB = 0x200
    }
}

