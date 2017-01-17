namespace Beyon.Domain
{
    using System;

    [Flags]
    public enum JLSType
    {
        ALL = -1,
        [Remark("大专以上")]
        JLS_DXCOUNT = 0x800,
        [Remark("离异")]
        JLS_LYCOUNT = 8,
        [Remark("丧偶")]
        JLS_SOCOUNT = 0x10,
        [Remark("不满18岁")]
        JLS_WCNCOUNT = 0x20,
        [Remark("未婚")]
        JLS_WHCOUNT = 2,
        [Remark("文盲")]
        JLS_WMCOUNT = 0x100,
        [Remark("小学")]
        JLS_XXCOUNT = 0x200,
        [Remark("已婚")]
        JLS_YHCOUNT = 4,
        [Remark("26岁以上")]
        JLS_YSCOUNT = 0x80,
        [Remark("18-25岁")]
        JLS_ZDCOUNT = 0x40,
        [Remark("中学")]
        JLS_ZXCOUNT = 0x400,
        [Remark("总数")]
        JLSCOUNT = 1
    }
}

