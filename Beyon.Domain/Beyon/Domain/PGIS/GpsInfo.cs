using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.PGIS
{
    /// <summary>
    /// GPS警车或手持终端信息
    /// </summary>
	public class GpsInfo
	{
        
        private string gpsId;

        /// <summary>
        /// gps id
        /// </summary>
        public string GpsId
        {
            get { return gpsId; }
            set { gpsId = value; }
        }

        
        private string orgId;

        /// <summary>
        /// 组织机构id
        /// </summary>
        public string OrgId
        {
            get { return orgId; }
            set { orgId = value; }
        }

       
        private string carNo;

        /// <summary>
        ///  gps车辆号码或gps设备所属人员
        /// </summary>
        public string CarNo
        {
            get { return carNo; }
            set { carNo = value; }
        }
        
       
        private string sssjmc;

        /// <summary>
        ///  所属市局名称
        /// </summary>
        public string Sssjmc
        {
            get { return sssjmc; }
            set { sssjmc = value; }
        }
        
        private string ssfjmc;

        /// <summary>
        /// 所属分局名称
        /// </summary>
        public string Ssfjmc
        {
            get { return ssfjmc; }
            set { ssfjmc = value; }
        }
        
        private string ssdwmc;

        /// <summary>
        /// 所属单位名称
        /// </summary>
        public string Ssdwmc
        {
            get { return ssdwmc; }
            set { ssdwmc = value; }
        }

        private int gpsType;

        /// <summary>
        /// GPS类型
        /// </summary>
        public int GpsType
        {
            get { return gpsType; }
            set { gpsType = value; }
        }

	}
}
