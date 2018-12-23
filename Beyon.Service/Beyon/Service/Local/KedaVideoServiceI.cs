using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.Domain.Local;

namespace Beyon.Service.Local
{
    public interface KedaVideoServiceI
    {
        /// <summary>
        /// 获取科达2.0视频表中所有视频
        /// </summary>
        /// <returns></returns>
        List<KedaVideo> GetAllVideos();

         /// <summary>
        /// 获取所有固定摄像头信息
        /// </summary>
        /// <returns></returns>
        List<KedaVideo> GetAllFixedVides();

        /// <summary>
        /// 根据名称模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<KedaVideo> GetAllVideosByName(string name);

        /// <summary>
        /// 根据四个角点坐标查询此范围内所有视频信息
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        List<KedaVideo> GetVideosOfRect(double longitude_left, double latitude_left, double longitude_right, double latitude_right);

        /// <summary>
        /// 获取监所摄像头集合
        /// </summary>
        /// <param name="prisonID"></param>
        /// <returns></returns>
        List<KedaVideo> GetVideoOfPrison(String prisonID);
    }
}
