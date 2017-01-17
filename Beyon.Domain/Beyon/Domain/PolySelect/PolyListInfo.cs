namespace Beyon.Domain.PolySelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 圈选列表信息，主要用于统一返回
    /// </summary>
    public class PolyListInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double JD { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double WD { get; set; }
    }
}

