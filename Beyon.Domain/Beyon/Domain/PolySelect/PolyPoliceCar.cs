using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.PolySelect
{
    /// <summary>
    /// 圈选警车
    /// </summary>
   public class PolyPoliceCar 
    {
       /// <summary>
       /// GPS编号
       /// </summary>
        public string GPSID { get; set; }

        /// <summary>
        /// 所属组织机构编号
        /// </summary>
        public string ORGID { get; set; }  

        /// <summary>
        /// 电话
        /// </summary>
        public string CALLNO { get; set; } 
        
        /// <summary>
        /// 所属组织机构名称
        /// </summary>
        public string ORGNAME { get; set; }

        public string UTM { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CARNO { get; set; } 
    }
}
