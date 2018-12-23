using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.WebService.ZhddPlatform.zzjgInfo;
using Beyon.Domain.Zhdd.zjjg;

namespace Beyon.Service.ZhddPlatform
{
	public class ZzjgServiceImpl : ZzjgServiceI
	{
        private HotelManager hotelManager;
        private CyberBarManager cyberBarManager;
        private PoliceOrgManager policeOrgManager;
        private TempleManager templeManager;
        private BarrierManager barrierManager;

        public ZzjgServiceImpl()
        {
            this.hotelManager = new HotelManager();
            this.cyberBarManager = new CyberBarManager();
            this.policeOrgManager = new PoliceOrgManager();
            this.templeManager = new TempleManager();
            this.barrierManager = new BarrierManager();
        }

        public List<Hotel> GetAllHotels()
        {
            return this.hotelManager.GetAllHotels();
        }

        public List<Hotel> FindHotelsBySearch(string exp)
        {
            return this.hotelManager.FindHotelsBySearch(exp);
        }

        public List<Hotel> GetAllHotelsByExtent(double minX, double minY, double maxX, double maxY)
        {
            return this.hotelManager.GetAllHotelsByExtent(minX, minY, maxX, maxY);
        }

        public List<CyberBar> GetAllCyberBars()
        {
            return this.cyberBarManager.GetAllWBs();
        }

        public List<CyberBar> FindCyberBarsBySearch(string exp)
        {
            return this.cyberBarManager.FindCyberBarsBySearch(exp);
        }

        public List<CyberBar> GetAllCyberBarsByExtent(double minX, double minY, double maxX, double maxY)
        {
            return this.cyberBarManager.GetAllWBsByExtent(minX, minY, maxX, maxY);
        }

        public List<PoliceOrg> GetAllPoliceOrgs()
        {
            return this.policeOrgManager.GetAllPoliceOrgs();
        }

        public List<PoliceOrg> GetAllPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            return this.policeOrgManager.GetAllPoliceOrgsByExtent(minX, minY, maxX, maxY);
        }

        public List<PoliceOrg> GetPcsPoliceOrgs()
        {
            return this.policeOrgManager.GetPcsPoliceOrgs();
        }

        public List<PoliceOrg> GetPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            return this.policeOrgManager.GetPcsPoliceOrgsByExtent(minX, minY, maxX, maxY);
        }

        public List<PoliceOrg> GetNPcsPoliceOrgs()
        {
            return this.policeOrgManager.GetNPcsPoliceOrgs();
        }

        public List<PoliceOrg> GetNPcsPoliceOrgsByExtent(double minX, double minY, double maxX, double maxY)
        {
            return this.policeOrgManager.GetNPcsPoliceOrgsByExtent(minX, minY, maxX, maxY);
        }

        public List<PoliceOrg> FindPoliceOrgsBySearch(string exp)
        {
            return this.policeOrgManager.FindPoliceOrgsBySearch(exp);
        }

        public List<Temple> GetAllTemplesByExtent(double minX, double minY, double maxX, double maxY)
        {
            return this.templeManager.GetAllTempleByExtent(minX, minY, maxX, maxY);
        }

        public List<Barrier> GetAllBarriersByExtent(double minX, double minY, double maxX, double maxY) 
        {
            return this.barrierManager.GetAllBarrierByExtent(minX, minY, maxX, maxY);
        }

        public Barrier GetBarrierByID(string id) 
        {
            return this.barrierManager.GetBarrierByID(id);
        }
	}
}
