using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.Zhdd.zjjg
{
    /// <summary>
    /// 公安机构类
    /// </summary>
	public class PoliceOrg
	{
        private string gajgdm;

        /// <summary>
        /// 公安机构代码
        /// </summary>
        public string Gajgdm
        {
            get { return gajgdm; }
            set { gajgdm = value; }
        }

        private string gajgmc;

        /// <summary>
        /// 公安机构名称
        /// </summary>
        public string Gajgmc
        {
            get { return gajgmc; }
            set { gajgmc = value; }
        }

        private string gajgjc;

        /// <summary>
        /// 公安机构简称
        /// </summary>
        public string Gajgjc
        {
            get { return gajgjc; }
            set { gajgjc = value; }
        }

        private double gajgJD;

        /// <summary>
        /// 公安机构经度
        /// </summary>
        public double GajgJD
        {
            get { return gajgJD; }
            set { gajgJD = value; }
        }

        private double gajgWD;

        /// <summary>
        /// 公安机构维度
        /// </summary>
        public double GajgWD
        {
            get { return gajgWD; }
            set { gajgWD = value; }
        }

        private string jglx;

        /// <summary>
        /// 公安机构类型
        /// </summary>
        public string Jglx
        {
            get { return jglx; }
            set { jglx = value; }
        }

        /// <summary>
        /// 公安机构详细地址
        /// </summary>
        public string Gajgxz
        {
            get;
            set;
        }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Dhhm
        {
            get;
            set;
        }

        /// <summary>
        /// 单位领导姓名
        /// </summary>
        public string Dwld_xm
        {
            get;
            set;
        }

        /// <summary>
        /// 单位领导联系电话
        /// </summary>
        public string Dwld_lxdh
        {
            get;
            set;
        }

        /// <summary>
        /// 单位领导身份证号
        /// </summary>
        public string Dwld_sfzh
        {
            get;
            set;
        }
	}
}
