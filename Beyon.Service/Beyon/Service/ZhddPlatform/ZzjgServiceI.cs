using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.Zhdd.zjjg;

namespace Beyon.Service.ZhddPlatform
{
	public interface ZzjgServiceI
	{
        List<Hotel> GetAllHotels();
        List<Hotel> FindHotelsBySearch(string exp);
        List<Hotel> GetAllHotelsByExtent(double minX, double minY, double maxX, double maxY);
        List<CyberBar> GetAllCyberBars();
        List<CyberBar> FindCyberBarsBySearch(string exp);
        List<CyberBar> GetAllCyberBarsByExtent(double minX, double minY, double maxX, double maxY);
        List<PoliceOrg> GetAllPoliceOrgs();
        List<PoliceOrg> GetPcsPoliceOrgs();
        List<PoliceOrg> GetNPcsPoliceOrgs();
        List<PoliceOrg> FindPoliceOrgsBySearch(string exp);
        List<PoliceOrg> GetAllPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY);
        List<PoliceOrg> GetPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY);
        List<PoliceOrg> GetNPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY);

        List<Temple> GetAllTemplesByExtent(double minX, double minY, double maxX, double maxY);

        List<Barrier> GetAllBarriersByExtent(double minX, double minY, double maxX, double maxY);

        Barrier GetBarrierByID(string id);
	}
}
