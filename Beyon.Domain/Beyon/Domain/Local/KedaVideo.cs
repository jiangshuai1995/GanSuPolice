using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.Local
{
    /// <summary>
    /// 科达2.0视频模型
    /// </summary>
    public class KedaVideo
    {
        /// <summary>
        /// 国标ID
        /// </summary>
        public string gbid { get; set; }

        /// <summary>
        /// 科达ID
        /// </summary>
        public string kdid { get; set; }

        /// <summary>
        /// 领域
        /// </summary>
        public string kddomainid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double latitude { get; set; }

        /// <summary>
        /// 通道
        /// </summary>
        public string channel { get; set; }
    }
}
