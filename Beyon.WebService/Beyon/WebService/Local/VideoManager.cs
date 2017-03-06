using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using Beyon.Common;
using Beyon.Domain.Local;
using Npgsql;

namespace Beyon.WebService.Local
{
    /// <summary>
    /// 摄像机数据外部接口管理类
    /// </summary>
    public class VideoManager
    {

        #region Fields

        /// <summary>
        /// 摄像机视频数据库连接字符串构造器
        /// </summary>
        private String connectString;

        #endregion

        #region Constructors

        /// <summary>
        /// 无参构造
        /// </summary>
        public VideoManager()
        {
            connectString = ConfigHelper.GetValueByKey("webservice.config", "pgConnect");
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取所有摄像头信息
        /// </summary>
        /// <returns></returns>
        public List<VideoInfoModel> GetAllVideos()
        {
            List<VideoInfoModel> list = new List<VideoInfoModel>();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                try
                {
                    conn.Open();

                    String sql_first = "select kdid55,name,jd,wd,gbid from gbid";
                    NpgsqlCommand cmd_first = new NpgsqlCommand(sql_first, conn);
                    NpgsqlDataReader reader_first = cmd_first.ExecuteReader();
                    while (reader_first.Read())
                    {
                        //这些字段值都有可能是空的
                        if (reader_first.IsDBNull(0) || reader_first.IsDBNull(1) || reader_first.IsDBNull(2) ||
                            reader_first.IsDBNull(3) || reader_first.IsDBNull(4))
                        {
                            continue;
                        }

                        VideoInfoModel video = new VideoInfoModel();
                        video.VideoChannel = reader_first.GetString(0);
                        video.VideoName = reader_first.GetString(1);
                        video.X = reader_first.GetDouble(2);
                        video.Y = reader_first.GetDouble(3);
                        video.FactoryName = "gb";
                        video.VideoPort = "0";
                        video.VideoSource = 2;
                        video.Gbid = reader_first.GetString(4);
                        list.Add(video);
                    } //end while

                    String sql_second = "select puid,name,longitude,latitude,channel,vendor,source from gbid1";
                    NpgsqlCommand cmd_second = new NpgsqlCommand(sql_second, conn);
                    NpgsqlDataReader reader_second = cmd_second.ExecuteReader();
                    while (reader_second.Read())
                    {
                        if (reader_second.IsDBNull(0) || reader_second.IsDBNull(1) || reader_second.IsDBNull(2) ||
                            reader_second.IsDBNull(3) ||
                            reader_second.IsDBNull(4) || reader_second.IsDBNull(5) || reader_second.IsDBNull(6))
                        {
                            continue;
                        }
                        VideoInfoModel video = new VideoInfoModel();
                        video.VideoChannel = reader_second.GetString(0);
                        video.VideoName = reader_second.GetString(1);
                        video.X = reader_second.GetDouble(2);
                        video.Y = reader_second.GetDouble(3);
                        video.VideoPort = reader_second[4].ToString();
                        video.FactoryName = reader_second.GetString(5);
                        video.VideoSource = Convert.ToInt32(reader_second[6]);
                        list.Add(video);
                    } //end while
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error("日志记录", ex);
                }
            }

            return list;
        }


        public List<VideoInfoModel> GetAllVideoTest()
        {
            List<VideoInfoModel> list = new List<VideoInfoModel>();
            return list;
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
            List<VideoInfoModel> list = new List<VideoInfoModel>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                try
                {
                    conn.Open();

                    String sql_first =
                        String.Format(
                            "select kdid55,name,jd,wd from gbid where jd between {0} and {1} and wd between {2} and {3}",
                            longitude_left, longitude_right, latitude_left, latitude_right);
                    NpgsqlCommand cmd_first = new NpgsqlCommand(sql_first, conn);
                    NpgsqlDataReader reader_first = cmd_first.ExecuteReader();
                    while (reader_first.Read())
                    {
                        if (reader_first.IsDBNull(0) || reader_first.IsDBNull(1) || reader_first.IsDBNull(2) ||
                            reader_first.IsDBNull(3))
                        {
                            continue;
                        }
                        VideoInfoModel video = new VideoInfoModel();
                        video.VideoChannel = reader_first.GetString(0);
                        video.VideoName = reader_first.GetString(1);
                        video.X = reader_first.GetDouble(2);
                        video.Y = reader_first.GetDouble(3);
                        video.FactoryName = "gb";
                        video.VideoPort = "0";
                        video.VideoSource = 2;
                        list.Add(video);
                    }

                    String sql_second =
                        String.Format(
                            "select puid,name,longitude,latitude,channel,vendor,source from gbid1 where longitude between {0} and {1} and latitude between {2} and {3}",
                            longitude_left, longitude_right, latitude_left, latitude_right);
                    NpgsqlCommand cmd_second = new NpgsqlCommand(sql_second, conn);
                    NpgsqlDataReader reader_second = cmd_second.ExecuteReader();
                    while (reader_second.Read())
                    {
                        if (reader_second.IsDBNull(0) || reader_second.IsDBNull(1) || reader_second.IsDBNull(2) ||
                            reader_second.IsDBNull(3) ||
                            reader_second.IsDBNull(4) || reader_second.IsDBNull(5) || reader_second.IsDBNull(6))
                        {
                            continue;
                        }
                        VideoInfoModel video = new VideoInfoModel();
                        video.VideoChannel = reader_second.GetString(0);
                        video.VideoName = reader_second.GetString(1);
                        video.X = reader_second.GetDouble(2);
                        video.Y = reader_second.GetDouble(3);
                        video.VideoPort = reader_second[4].ToString();
                        video.FactoryName = reader_second.GetString(5);
                        video.VideoSource = Convert.ToInt32(reader_second[6]);
                        list.Add(video);
                    }
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error("日志记录", ex);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取特定类型的摄像头
        /// </summary>
        /// <param name="type">摄像头类型</param>
        /// <returns></returns>
        public List<VideoInfoModel> GetSpecificVideos(VideoTypeModel.VideoType type)
        {
            List<VideoInfoModel> list = new List<VideoInfoModel>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    String sql = null;
                    switch (type)
                    {
                        case VideoTypeModel.VideoType.KeyArea:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') between 60 and 65";
                            break;
                        case VideoTypeModel.VideoType.RoadTraffic:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') between 66 and 69";
                            break;
                        case VideoTypeModel.VideoType.PublicArea:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') between 70 and 75";
                            break;
                        case VideoTypeModel.VideoType.SuperviseArea:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') = 92";
                            break;
                        case VideoTypeModel.VideoType.CaseCenter:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') = 93";
                            break;
                        case VideoTypeModel.VideoType.WindowUnit:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') = 94";
                            break;
                        case VideoTypeModel.VideoType.MoveableVideo:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') = 77";
                            break;
                        case VideoTypeModel.VideoType.InternalVideo:
                            sql =
                                "select kdid55,name,jd,wd from gbid where to_number(substr(civilcode,length(civilcode)-1,2),'999999999D99999999') = 78";
                            break;
                        default:
                            break;
                    } //end switch

                    if (sql != null)
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(3))
                            {
                                continue;
                            }
                            VideoInfoModel video = new VideoInfoModel();
                            video.VideoChannel = reader.GetString(0);
                            video.VideoName = reader.GetString(1);
                            video.X = reader.GetDouble(2);
                            video.Y = reader.GetDouble(3);
                            video.VideoPort = "0";
                            video.FactoryName = "gb";
                            video.VideoSource = 2;
                            list.Add(video);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error("日志记录", ex);
                }
            }
            return list;
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
            List<VideoInfoModel> list = new List<VideoInfoModel>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                String sql =
                    String.Format(
                        "select kdid55,name,jd,wd from gbid where jd between {0} and {1} and wd between {2} and {3}",
                        longitude_left, longitude_right, latitude_left, latitude_right);
                String sql_type = null;
                try
                {
                    conn.Open();
                    switch (type)
                    {
                        case VideoTypeModel.VideoType.KeyArea:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') between 60 and 65";
                            break;
                        case VideoTypeModel.VideoType.RoadTraffic:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') between 66 and 69";
                            break;
                        case VideoTypeModel.VideoType.PublicArea:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') between 70 and 75";
                            break;
                        case VideoTypeModel.VideoType.SuperviseArea:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') = 92";
                            break;
                        case VideoTypeModel.VideoType.CaseCenter:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') = 93";
                            break;
                        case VideoTypeModel.VideoType.WindowUnit:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') = 94";
                            break;
                        case VideoTypeModel.VideoType.MoveableVideo:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') = 77";
                            break;
                        case VideoTypeModel.VideoType.InternalVideo:
                            sql_type = " and to_number(substr(civilcode,length(civilcode)-1,2), '999999999D99999999') = 78";
                            break;
                        default:
                            break;
                    } //end switch

                    if (sql_type != null)
                    {
                        sql = sql + sql_type;
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0) || reader.IsDBNull(1) || reader.IsDBNull(2) || reader.IsDBNull(3))
                            {
                                continue;
                            }
                            VideoInfoModel video = new VideoInfoModel();
                            video.VideoChannel = reader.GetString(0);
                            video.VideoName = reader.GetString(1);
                            video.X = reader.GetDouble(2);
                            video.Y = reader.GetDouble(3);
                            video.VideoPort = "0";
                            video.VideoSource = 2;
                            video.FactoryName = "gb";
                            list.Add(video);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error("日志记录", ex);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据警号获取手持终端视频参数
        /// </summary>
        /// <param name="policeID"></param>
        /// <returns></returns>
        public VideoInfoModel GetTerminalVideoInfo(String policeID)
        {
            VideoInfoModel model = new VideoInfoModel();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                try
                {
                    conn.Open();

                    String sql = "select puid,name,vendor,channel,source from gbid1 where carno = '" + policeID +
                                 "'";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            model.VideoChannel = reader[0].ToString();
                        }
                        if (!reader.IsDBNull(1))
                        {
                            model.VideoName = reader[1].ToString();
                        }
                        if (!reader.IsDBNull(2))
                        {
                            model.FactoryName = reader[2].ToString();
                        }
                        if (!reader.IsDBNull(3))
                        {
                            model.VideoPort = reader[3].ToString();
                        }
                        if (!reader.IsDBNull(4))
                        {
                            model.VideoSource = Convert.ToInt32(reader[4].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error("日志记录", ex);
                }
            }

            return model;
        }

        /// <summary>
        /// 获取监所的视频参数
        /// </summary>
        /// <param name="prisonID">9位的监所编号，即JS_CODE字段</param>
        /// <returns></returns>
        public List<VideoInfoModel> GetVideoOfPrison(String prisonID, VideoTypeModel.AreaType type)
        {
            List<VideoInfoModel> list = new List<VideoInfoModel>();
            String civil_code = prisonID.Substring(0, 6);
            String sql_suffix = null;
            switch (type)
            {
                case VideoTypeModel.AreaType.Detention:
                    sql_suffix = "'%看守所%'";
                    break;
                case VideoTypeModel.AreaType.DrugAbuse:
                    sql_suffix = "'%戒毒所%'";
                    break;
                case VideoTypeModel.AreaType.Custody:
                    sql_suffix = "'%拘留所%'";
                    break;
                default:
                    break;
            }
            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    if (civil_code == "621023")
                    {
                        String sql_first = "select kdid55,name,jd,wd from gbid where fzmc like '%华池县监管场所%'";
                        NpgsqlCommand cmd_first = new NpgsqlCommand(sql_first, conn);
                        NpgsqlDataReader reader_first = cmd_first.ExecuteReader();
                        while (reader_first.Read())
                        {
                            if (reader_first.IsDBNull(0) || reader_first.IsDBNull(1))
                                continue;
                            VideoInfoModel model = new VideoInfoModel();
                            model.VideoChannel = reader_first.GetString(0);
                            if (model.VideoChannel == "55000000000000000011113632400000" || model.VideoChannel == "55000000000000000011113632500000")
                            {
                                continue;
                            }
                            model.VideoName = reader_first.GetString(1);
                            if (reader_first.IsDBNull(2))
                            {
                                model.X = 0.0;
                            }
                            else
                            {
                                model.X = reader_first.GetDouble(2);
                            }

                            if (reader_first.IsDBNull(3))
                            {
                                model.Y = 0.0;
                            }
                            else
                            {
                                model.Y = reader_first.GetDouble(3);
                            }
                            model.VideoPort = "0";
                            model.VideoSource = 2;
                            model.FactoryName = "gb";
                            list.Add(model);
                        }
                    }
                    else
                    {

                        String sql_first =
                            "select kdid55,name,jd,wd from gbid where fzmc like '%监管场所%' and gbid like '" +
                            civil_code + "%' and name like " + sql_suffix;

                        NpgsqlCommand cmd_first = new NpgsqlCommand(sql_first, conn);
                        NpgsqlDataReader reader_first = cmd_first.ExecuteReader();
                        while (reader_first.Read())
                        {
                            if (reader_first.IsDBNull(0) || reader_first.IsDBNull(1))
                                continue;
                            VideoInfoModel model = new VideoInfoModel();
                            model.VideoChannel = reader_first.GetString(0);
                            model.VideoName = reader_first.GetString(1);
                            if (reader_first.IsDBNull(2))
                            {
                                model.X = 0.0;
                            }
                            else
                            {
                                model.X = reader_first.GetDouble(2);
                            }

                            if (reader_first.IsDBNull(3))
                            {
                                model.Y = 0.0;
                            }
                            else
                            {
                                model.Y = reader_first.GetDouble(3);
                            }
                            model.VideoPort = "0";
                            model.VideoSource = 2;
                            model.FactoryName = "gb";
                            list.Add(model);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error("日志记录", ex);
                }
            }
            return list;
        }

        /// <summary>
        /// 取得某个经纬度点附近的摄像头参数
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public List<VideoInfoModel> GetVideoNearPoint(double latitude, double longitude)
        {
            List<VideoInfoModel> list = new List<VideoInfoModel>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    String sql_first =
                        String.Format(
                            "select kdid55,name,jd,wd from gbid where jd between {0} and {1} and wd between {2} and {3}",
                            longitude - 0.0001, longitude + 0.0001, latitude - 0.0001, latitude + 0.0001);

                    Debug.WriteLine(sql_first);

                    NpgsqlCommand cmd_first = new NpgsqlCommand(sql_first, conn);
                    NpgsqlDataReader reader_first = cmd_first.ExecuteReader();
                    while (reader_first.Read())
                    {
                        if (reader_first.IsDBNull(0) || reader_first.IsDBNull(1))
                        {
                            continue;
                        }
                        VideoInfoModel video = new VideoInfoModel();
                        video.VideoChannel = reader_first.GetString(0);
                        video.VideoName = reader_first.GetString(1);
                        if (reader_first.IsDBNull(2))
                        {
                            video.X = 0.0;
                        }
                        else
                        {
                            video.X = reader_first.GetDouble(2);
                        }
                        if (reader_first.IsDBNull(3))
                        {
                            video.Y = 0.0;
                        }
                        else
                        {
                            video.Y = reader_first.GetDouble(3);
                        }
                        video.VideoPort = "0";
                        video.VideoSource = 2;
                        video.FactoryName = "gb";
                        list.Add(video);
                    }

                    String sql_second =
                        String.Format(
                            "select puid,name,longitude,latitude,channel,vendor,source from gbid1 where longitude between {0} and {1} and latitude between {2} and {3}",
                            longitude - 0.0001, longitude + 0.0001, latitude - 0.0001, latitude + 0.0001);
                    Debug.WriteLine(sql_second);
                    NpgsqlCommand cmd_second = new NpgsqlCommand(sql_second, conn);
                    NpgsqlDataReader reader_second = cmd_second.ExecuteReader();
                    while (reader_second.Read())
                    {
                        if (reader_second.IsDBNull(0) || reader_second.IsDBNull(1) || reader_second.IsDBNull(4) ||
                            reader_second.IsDBNull(5) || reader_second.IsDBNull(6))
                        {
                            continue;
                        }
                        VideoInfoModel model = new VideoInfoModel();
                        model.VideoChannel = reader_second.GetString(0);
                        model.VideoName = reader_second.GetString(1);
                        if (reader_second.IsDBNull(2))
                        {
                            model.X = 0.0;
                        }
                        else
                        {
                            model.X = reader_second.GetDouble(2);
                        }
                        if (reader_second.IsDBNull(3))
                        {
                            model.Y = 0.0;
                        }
                        else
                        {
                            model.Y = 0.0;
                        }
                        model.VideoPort = reader_second[4].ToString();
                        model.FactoryName = reader_second.GetString(5);
                        model.VideoSource = Convert.ToInt32(reader_second[6]);
                        list.Add(model);
                    }
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error("日志记录", ex);
                }
            }
            return list;
        }

        #endregion

    }
}
