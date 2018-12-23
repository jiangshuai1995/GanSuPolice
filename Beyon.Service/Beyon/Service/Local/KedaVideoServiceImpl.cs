using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.Local;
using Beyon.WebService.Local;

namespace Beyon.Service.Local
{
    public class KedaVideoServiceImpl : KedaVideoServiceI
    {
        private KedaVideoManager videoManager;

        public KedaVideoServiceImpl()
        {
            videoManager = new KedaVideoManager();
        }

        /// <summary>
        /// 获取科达2.0视频表中所有视频
        /// </summary>
        /// <returns></returns>
        public List<KedaVideo> GetAllVideos()
        {
            return videoManager.GetAllVideos();
        }

        /// <summary>
        /// 获取科达2.0视频表中所有视频
        /// </summary>
        /// <returns></returns>
        public List<KedaVideo> GetAllFixedVides()
        {
            return videoManager.GetAllFixedVides();
        }

        /// <summary>
        /// 根据名称模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<KedaVideo> GetAllVideosByName(string name)
        {
            return videoManager.GetAllVideosByName(name);
        }

        /// <summary>
        /// 根据四个角点坐标查询此范围内所有视频信息
        /// </summary>
        /// <param name="minX">最小经度</param>
        /// <param name="minY">最小纬度</param>
        /// <param name="maxX">最大经度</param>
        /// <param name="maxY">最大纬度</param>
        /// <returns></returns>
        public List<KedaVideo> GetVideosOfRect(double longitude_left, double latitude_left, double longitude_right, double latitude_right)
        {
            return videoManager.GetVideosOfRect(longitude_left, latitude_left, longitude_right, latitude_right);
        }

        /// <summary>
        /// 获取监所的视频参数
        /// </summary>
        /// <param name="prisonID">监所ID后九位编码规则，共9位，前面6位表示行政区域；第七位为1，预留；第八位为监所种类，1表示看守所，2表示拘留所，3表示戒毒所，4表示收容教育所；第九位表示同一行政区域的同类型监所的第几个,只有兰州市（前六位是620101）有。如620101111为兰州市第一看守所；620101112位兰州第二看守所</param>
        /// <returns></returns>
        public List<KedaVideo> GetVideoOfPrison(String prisonID)
        {
            return videoManager.GetVideoOfPrison(prisonID);
        }
    }
}
