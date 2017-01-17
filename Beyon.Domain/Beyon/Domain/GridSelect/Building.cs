namespace Beyon.Domain.GridSelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 房屋
    /// </summary>
    public class Building
    {
        /// <summary>
        /// 经度
        /// </summary>
        public string JD { get; set; }

        /// <summary>
        /// 建筑物代码
        /// </summary>
        public string JZWDM { get; set; }

        /// <summary>
        /// 建筑物名称
        /// </summary>
        public string JZWMC { get; set; }

        /// <summary>
        /// 建筑物ID
        /// </summary>
        public string OBJECTID
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.JZWDM = value;
                }
            }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        public string WD { get; set; }
    }
}

