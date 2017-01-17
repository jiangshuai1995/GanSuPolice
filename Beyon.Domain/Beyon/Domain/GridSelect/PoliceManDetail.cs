namespace Beyon.Domain.GridSelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 警员详细信息
    /// </summary>
    public class PoliceManDetail
    {

        public string CSRQ { get; set; }

        /// <summary>
        /// 单位编号
        /// </summary>
        public string DW_CODE { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string DW_NAME { get; set; }

        /// <summary>
        /// 公民身份证号
        /// </summary>
        public string GMSFZHM { get; set; }

        public string GRSF { get; set; }

        public string GRSF_NAME { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public string IMAGE { get; set; }

        /// <summary>
        /// 警号
        /// </summary>
        public string JH { get; set; }

        /// <summary>
        /// 上级领导编号
        /// </summary>
        public string LEADER_CODE { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string MZ { get; set; }

        /// <summary>
        /// 民族全称
        /// </summary>
        public string MZ_NAME { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string XB { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string XM { get; set; }
    }
}

