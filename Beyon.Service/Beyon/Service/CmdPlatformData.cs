namespace Beyon.Service
{
    using Beyon.Common;
    using Beyon.Domain;
    using System;
    using System.Collections.Generic;

    public class CmdPlatformData : BaseTimeStatis
    {
        private ZHDDPT df = new ZHDDPT();

        public List<StatisticInfo> GetColumnChartInfo(string level, string name, double minLongitude, double minLatitude, double maxLongitude, double maxLatitude)
        {
            return this.df.GetColumnChartInfo(level, name, minLongitude, minLatitude, maxLongitude, maxLatitude);
        }

    }
}

