namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum XSAJType
    {
        ALL = -1,
        [Remark("爆炸")]
        BZ = 4,
        [Remark("毒品犯罪")]
        DPFZ = 0x2000,
        [Remark("盗窃")]
        DQ = 0x200,
        [Remark("电信诈骗")]
        DXZP = 0x1000,
        [Remark("放火")]
        FH = 2,
        [Remark("劫持")]
        FMDP = 8,
        [Remark("伤害")]
        GYSH = 0x20,
        [Remark("杀人")]
        GYSR = 0x10,
        [Remark("经济犯罪")]
        JJFZ = 0x4000,
        [Remark("抢夺")]
        QD = 0x400,
        [Remark("强奸")]
        QJIAN = 0x40,
        [Remark("抢劫")]
        QJIE = 0x100,
        [Remark("绑架")]
        TD = 0x80,
        [Remark("诈骗")]
        ZP = 0x800,
        [Remark("总体情况")]
        ZTQK = 1
    }
}

