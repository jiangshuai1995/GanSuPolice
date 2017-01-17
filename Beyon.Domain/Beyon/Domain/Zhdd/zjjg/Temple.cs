using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.Zhdd.zjjg
{
    /// <summary>
    /// 宗教场所
    /// </summary>
    public class Temple
    {
        /// <summary>
        /// 场所名称
        /// </summary>
        public string Csmc
        {
            get;
            set;
        }

        /// <summary>
        /// 编号
        /// </summary>
        public string Bh
        {
            get;
            set;
        }

        /// <summary>
        /// 兼容网格平台ID
        /// </summary>
        public string Key_zd
        {
            get;
            set;
        }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Xxdz
        {
            get;
            set;
        }

        /// <summary>
        /// 辖区派出所编号
        /// </summary>
        public string Xqpcs
        {
            get;
            set;
        }

        /// <summary>
        /// 建院情况
        /// </summary>
        public string Jyqk
        {
            get;
            set;
        }

        /// <summary>
        /// 场所照片id
        /// </summary>
        public string Cszpid
        {
            get;
            set;
        }

        /// <summary>
        /// 宗教场所经度
        /// </summary>
        public double ZjcsJd
        {
            get;
            set;
        }

        /// <summary>
        /// 宗教场所纬度
        /// </summary>
        public double ZjcsWd
        {
            get;
            set;
        }

    }
}
