namespace Beyon.Domain.PolySelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 圈选场所
    /// </summary>
    public class PolyCS
    {
        /// <summary>
        /// 场所ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string JD { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string MC { get; set; }

        public string OBJECTID
        {
            set
            {
                this.ID = value;
            }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        public string WD { get; set; }
    }
}

