using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain
{
    //案件接处警
    public class ajjcj 
    {
        private String xzqh;
        /// <summary>
        /// 行政区划
        /// </summary>
        public String XZQH { get { return xzqh; } set { xzqh = value; } }
        private String xzqhmc;
        /// <summary>
        /// 行政区划名称
        /// </summary>
        public string XZQHMC { get { return xzqhmc; } set { xzqhmc = value; } }
        public String jn;     //今年
        public String qn;     //去年
        public String xb;     //相比
        public String wffzaj; //违法犯罪案件
        public String zaaj;   //治安案件
        public String hzsg;   //火灾事故
        public String jtsg;   //交通事故
        public String zazhsg; //治安灾害事故
        public String zhsg;   //灾害事故
        public String zs;     //自杀
        public String jf;     //纠纷
        public String jtbl;   //家庭暴力
        public String gmqz;   //公民求助
        public String zsxr;   //走失寻人
        public String jwjd;   //警务监督
        public String tjsj;   //提交时间

        public DateTime tjsjDateTime
        {
            get
            {
                DateTime outtime;
                if (!string.IsNullOrEmpty(tjsj) && DateTime.TryParse(tjsj, out outtime))
                {
                    return outtime;
                }

                return DateTime.Parse("0001/01/01 00:00:00");
            }
        }
        //private Date tjsj;
    }
}
