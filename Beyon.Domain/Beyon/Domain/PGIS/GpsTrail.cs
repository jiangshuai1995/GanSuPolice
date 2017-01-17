using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beyon.Domain.PGIS
{
    /// <summary>
    /// GPS轨迹信息
    /// </summary>
	public class GpsTrail
	{
        private string gpsId;

        public string GpsId
        {
            get { return gpsId; }
            set { gpsId = value; }
        }

        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private int gpsType;

        /// <summary>
        /// GPS类型：{1 : 警车}, {2 : A210手持终端}, {3 : 安卓手机}, {4 : 350M}, {5 : 3G图传车}, {6 : 340M图传车}, {7 : 340M + 3G图传车}
        /// </summary>
        public int GpsType
        {
            get { return gpsType; }
            set { gpsType = value; }
        }

	}
}
