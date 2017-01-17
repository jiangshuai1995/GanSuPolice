namespace Beyon.Domain.PolySelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 责任区详细信息
    /// </summary>
    public class ZrqDetail
    {
        /// <summary>
        /// 常住人口
        /// </summary>
        public long CZRK { get; set; }

        /// <summary>
        /// 代号
        /// </summary>
        public string DH { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string FZR { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string MC { get; set; }

        /// <summary>
        /// 重点人
        /// </summary>
        public long ZDR { get; set; }

        /// <summary>
        /// 大情报重点人
        /// </summary>
        public long ZDRDQB { get; set; }
    }
}

