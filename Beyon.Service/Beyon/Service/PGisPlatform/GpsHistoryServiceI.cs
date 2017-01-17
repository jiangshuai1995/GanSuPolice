using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.PGIS;

namespace Beyon.Service.PGisPlatform
{
	public interface GpsHistoryServiceI
	{
        List<GpsTrail> GetGpsTrail(DateTime start, DateTime end);
        List<GpsTrail> GetGpsCarTrail(DateTime start, DateTime end);
        List<GpsTrail> GetGpsDeviceTrail(DateTime start, DateTime end);
	}
}
