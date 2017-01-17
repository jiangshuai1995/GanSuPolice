namespace Beyon.Domain.PolySelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 圈选概要信息
    /// </summary>
    public class PolySummary
    {
        /// <summary>
        /// 处警
        /// </summary>
        public long cj { get; set; }

        /// <summary>
        /// 常住人口数目
        /// </summary>
        public long czrk { get; set; }

        /// <summary>
        /// 房屋数目
        /// </summary>
        public long fw { get; set; }

        /// <summary>
        /// 接警
        /// </summary>
        public long jj { get; set; }

        /// <summary>
        /// 人口数目
        /// </summary>
        public long rk
        {
            set
            {
                this.czrk = value;
            }
        }

        /// <summary>
        /// 刑事立案数
        /// </summary>
        public long xsla { get; set; }

        /// <summary>
        /// 刑事破案数
        /// </summary>
        public long xspa { get; set; }

        /// <summary>
        /// 治安接案
        /// </summary>
        public long zaja { get; set; }

        /// <summary>
        /// 治安立案
        /// </summary>
        public long zala { get; set; }

        /// <summary>
        /// 重点人口数目
        /// </summary>
        public long zdr { get; set; }
    }
}

