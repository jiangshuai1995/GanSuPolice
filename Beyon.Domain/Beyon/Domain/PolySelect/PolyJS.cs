using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.PolySelect
{

    /// <summary>
    /// 圈选监所
    /// </summary>
	public class PolyJS
	{
        /// <summary>
        /// 公安机构代码
        /// </summary>
        public string GAJGDM { get; set; }

        /// <summary>
        /// 监所编号
        /// </summary>
        public string JS_CODE { get; set; }

        /// <summary>
        /// 监所名称
        /// </summary>
        public string JS_MC { get; set; }

        /// <summary>
        /// 公安机构简称
        /// </summary>
        public string GAJGJC { get; set; }

        /// <summary>
        /// 公安机构经度
        /// </summary>
        public string GAJGJD { get; set; }

        /// <summary>
        /// 公安机构纬度
        /// </summary>
        public string GAJGWD { get; set; }
        public string GAJGDM_NEW { get; set; }
	}
}
