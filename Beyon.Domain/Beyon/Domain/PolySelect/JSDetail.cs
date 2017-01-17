using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.PolySelect
{
    /// <summary>
    /// 监所详细信息
    /// </summary>
	public class JSDetail
	{
        /// <summary>
        /// 监所名称
        /// </summary>
        public string JS_MC {get;set;}
            
        /// <summary>
        /// 公安机构详细地址
        /// </summary>
        public string GAJGXZ {get;set;}
        
        public string DWLD_XM {get;set;}
        public string DWLD_LXDH {get;set;}

        /// <summary>
        /// 人数
        /// </summary>
        public string RS {get;set;}

        /// <summary>
        /// 照片
        /// </summary>
        public string zp { get; set; }
	}
}
