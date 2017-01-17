using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.PGIS;
using Beyon.WebService.PGIS;

namespace Beyon.Service.PGisPlatform
{
	public class GpsHistoryOneDayImpl : GpsHistoryServiceI
	{
        private GpsHistory gpsHistory; //单件

        public GpsHistoryOneDayImpl()
        {
            this.gpsHistory = new GpsHistory();
        }

        public List<GpsTrail> GetGpsTrail(DateTime start, DateTime end) 
        {
            return this.gpsHistory.GetAllGpsHistoryInfo(start, end); 
        }

        public List<GpsTrail> GetGpsCarTrail(DateTime start, DateTime end)
        {
            return this.gpsHistory.GetGpsCarHistoryInfo(start, end);
        }

        public List<GpsTrail> GetGpsDeviceTrail(DateTime start, DateTime end)
        {
            return this.gpsHistory.GetGpsDeviceHistoryInfo(start, end);
        }
	}
}
