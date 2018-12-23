using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.Zhdd.zjjg
{
    public class Barrier
    {
        /// <summary>
        /// 卡口名称
        /// </summary>
        public string Kkmc
        {
            get;
            set;
        }
        
        /// <summary>
        /// 卡口ID
        /// </summary>
        public string Kkid
        {
            get;
            set;
        }

        /// <summary>
        /// 卡口经度
        /// </summary>
        public double KkJd
        {
            get;
            set;
        }

        /// <summary>
        /// 卡口纬度
        /// </summary>
        public double KkWd
        {
            get;
            set;
        }

        /// <summary>
        /// 卡口所在地
        /// </summary>
        public string Kkssd
        {
            get;
            set;
        }

        /// <summary>
        /// URL 链接到卡口的URL
        /// </summary>
        public string KkUrl
        {
            get;
            set;
        }
    }
}
