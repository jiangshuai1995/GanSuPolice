namespace Beyon.Domain.PolySelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 派出所详细信息
    /// </summary>
    public class PcsDetail
    {
        /// <summary>
        /// 处警
        /// </summary>
        public long CJ { get; set; }

        public string DH { get; set; }

        public string DZ { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string FZR { get; set; }

        public string ID { get; set; }

        /// <summary>
        /// 接警
        /// </summary>
        public long JJ { get; set; }

        /// <summary>
        /// 警力
        /// </summary>
        public long JL { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string MC { get; set; }

        /// <summary>
        /// 刑事立案
        /// </summary>
        public long XSLA { get; set; }

        /// <summary>
        /// 治安立案
        /// </summary>
        public long ZALA { get; set; }
    }
}

