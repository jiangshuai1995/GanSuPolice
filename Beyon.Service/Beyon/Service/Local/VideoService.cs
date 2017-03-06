using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Beyon.Domain.Local;
using Beyon.WebService.Local;

namespace Beyon.Service.Local
{
    /// <summary>
    /// 摄像机数据外部接口管理类
    /// </summary>
    public class VideoService
    {

        private VideoManager videoManager;

        #region Constructors

        /// <summary>
        /// 无参构造
        /// </summary>
        public VideoService()
        {
            videoManager = new VideoManager();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取所有摄像头信息
        /// </summary>
        /// <returns></returns>
        public List<VideoInfoModel> GetAllVideos()
        {
            return videoManager.GetAllVideos();
        }


        public List<VideoInfoModel> GetAllVideoTest()
        {
            return videoManager.GetAllVideoTest();
        }

        /// <summary>
        /// 获取某一矩形区域内所有的摄像头
        /// </summary>
        /// <param name="longitude_left">区域左上角经度</param>
        /// <param name="latitude_left">区域左上角纬度</param>
        /// <param name="longitude_right">区域右下角经度</param>
        /// <param name="latitude_right">区域右下角纬度</param>
        /// <returns></returns>
        public List<VideoInfoModel> GetVideosOfRect(double longitude_left, double latitude_left, double longitude_right,
            double latitude_right)
        {
            return videoManager.GetVideosOfRect(longitude_left, latitude_left, longitude_right, latitude_right);
        }

        /// <summary>
        /// 获取特定类型的摄像头
        /// </summary>
        /// <param name="type">摄像头类型</param>
        /// <returns></returns>
        public List<VideoInfoModel> GetSpecificVideos(VideoTypeModel.VideoType type)
        {
            return videoManager.GetSpecificVideos(type);
        }

        /// <summary>
        /// 获取矩形区域内特定类型的摄像头
        /// </summary>
        /// <param name="longitude_left">矩形左上角经度</param>
        /// <param name="latitude_left">矩形左上角纬度</param>
        /// <param name="longitude_right">矩形右下角经度</param>
        /// <param name="latitude_right">矩形右下角纬度</param>
        /// <param name="type">摄像头类型</param>
        /// <returns></returns>
        public List<VideoInfoModel> GetSpecificVideosOfRect(double longitude_left, double latitude_left,
            double longitude_right, double latitude_right, VideoTypeModel.VideoType type)
        {
            return videoManager.GetSpecificVideosOfRect(longitude_left, latitude_left, longitude_right, latitude_right, type);
        }

        /// <summary>
        /// 根据警号获取手持终端视频参数
        /// </summary>
        /// <param name="policeID"></param>
        /// <returns></returns>
        public VideoInfoModel GetTerminalVideoInfo(String policeID)
        {
            return videoManager.GetTerminalVideoInfo(policeID);
        }

        /// <summary>
        /// 获取监所的视频参数
        /// </summary>
        /// <param name="prisonID">9位的监所编号，即JS_CODE字段</param>
        /// <returns></returns>
        public List<VideoInfoModel> GetVideoOfPrison(String prisonID, VideoTypeModel.AreaType type)
        {
            return videoManager.GetVideoOfPrison(prisonID, type);
        }

        /// <summary>
        /// 取得某个经纬度点附近的摄像头参数
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public List<VideoInfoModel> GetVideoNearPoint(double latitude, double longitude)
        {
            return videoManager.GetVideoNearPoint(latitude, longitude);
        }

        #endregion

    }
}
