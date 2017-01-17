using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.PolySelect
{
    public class AJ
    {
        public string AJBH{get;set;}
       public  string AJMC{get;set;}
    }

    /// <summary>
    /// 监所人员详细信息
    /// </summary>
	public class JSPersonDetail
	{
        /// <summary>
        /// 姓名
        /// </summary>
       public string XM { get; set; }

       /// <summary>
       /// 照片
       /// </summary>
       public string ZP { get; set; }

       public string NJSL { get; set; }

       /// <summary>
       /// 所涉案件列表
       /// </summary>
       public List<AJ> AJ { get; set; }
	}
}
