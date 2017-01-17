using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.Zhdd.zjjg
{
    /// <summary>
    /// 网吧信息类
    /// </summary>
	public class CyberBar
	{
        private string wb_code;

        /// <summary>
        /// 网吧编号
        /// </summary>
        public string Wb_code
        {
            get { return wb_code; }
            set { wb_code = value; }
        }

        /// <summary>
        /// 网吧编号
        /// </summary>
        public string Wb_code_old
        {
            get;
            set;
        }

        private string gajg_key;

        /// <summary>
        /// 所属公安机构编号
        /// </summary>
        public string Gajg_key
        {
            get { return gajg_key; }
            set { gajg_key = value; }
        }

        private string wbmc;

        /// <summary>
        /// 网吧名称
        /// </summary>
        public string Wbmc
        {
            get { return wbmc; }
            set { wbmc = value; }
        }

        private string wbxz;

        /// <summary>
        /// 网吧详细地址
        /// </summary>
        public string Wbxz
        {
            get { return wbxz; }
            set { wbxz = value; }
        }

        private double wbjd;

        /// <summary>
        /// 网吧经度
        /// </summary>
        public double Wbjd
        {
            get { return wbjd; }
            set { wbjd = value; }
        }

        private double wbwd;

        /// <summary>
        /// 网吧纬度
        /// </summary>
        public double Wbwd
        {
            get { return wbwd; }
            set { wbwd = value; }
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
        /// 网吧联系电话
        /// </summary>
        public string Lxdh
        {
            get { return lxdh; }
            set { lxdh = value; }
        }


	}
}
