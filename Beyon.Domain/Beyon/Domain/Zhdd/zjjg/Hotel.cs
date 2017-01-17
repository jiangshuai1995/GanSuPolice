using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.Zhdd.zjjg
{
    /// <summary>
    /// 旅馆信息
    /// </summary>
	public class Hotel
	{
        private string ld_code;

        /// <summary>
        /// 旅店代码
        /// </summary>
        public string Ld_code
        {
            get { return ld_code; }
            set { ld_code = value; }
        }

        /// <summary>
        /// 旅店代码，主要为了与网格平台旅店兼容
        /// </summary>
        public string Ld_code_old
        {
            get;
            set;
        }

        private string gajg_key;

        /// <summary>
        /// 所属公安机构代号
        /// </summary>
        public string Gajg_key
        {
            get { return gajg_key; }
            set { gajg_key = value; }
        }

        private string ldmc;

        /// <summary>
        /// 旅店名称
        /// </summary>
        public string Ldmc
        {
            get { return ldmc; }
            set { ldmc = value; }
        }

        private string ldxz;

        /// <summary>
        /// 旅店详细地址
        /// </summary>
        public string Ldxz
        {
            get { return ldxz; }
            set { ldxz = value; }
        }

        private double ldJD;

        /// <summary>
        /// 旅店经度
        /// </summary>
        public double LdJD
        {
            get { return ldJD; }
            set { ldJD = value; }
        }

        private double ldWD;

        /// <summary>
        /// 旅店纬度
        /// </summary>
        public double LdWD
        {
            get { return ldWD; }
            set { ldWD = value; }
        }

        private string fzr_xm;

        /// <summary>
        /// 负责人姓名
        /// </summary>
        public string Fzr_xm
        {
            get { return fzr_xm; }
            set { fzr_xm = value; }
        }

        private string fzr_sfzh;

        /// <summary>
        /// 负责人身份证号
        /// </summary>
        public string Fzr_sfzh
        {
            get { return fzr_sfzh; }
            set { fzr_sfzh = value; }
        }

        private string lxdh;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Lxdh
        {
            get { return lxdh; }
            set { lxdh = value; }
        }


	}
}
