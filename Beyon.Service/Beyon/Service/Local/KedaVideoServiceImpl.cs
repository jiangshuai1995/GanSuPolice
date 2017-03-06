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
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<KedaVideo> GetAllVideosByExtent(double minX, double minY, double maxX, double maxY)
        {
            return videoManager.GetAllVideosByExtent(minX, minY, maxX, maxY);
        }
    }
}
