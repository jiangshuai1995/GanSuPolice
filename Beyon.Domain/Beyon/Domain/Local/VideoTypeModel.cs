using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyon.Domain.Local
{
    public class VideoTypeModel
    {
        /// <summary>
        /// 视频类型定义
        /// </summary>
        public enum VideoType
        {
            KeyArea, //重点场所
            RoadTraffic, //道路交通
            PublicArea, //公共场所
            SuperviseArea, //监管场所
            CaseCenter, //办案中心
            WindowUnit, //窗口单位
            MoveableVideo, //移动视频
            InternalVideo //内部视频
        }

        /// <summary>
        /// 监所定义
        /// </summary>
        public enum AreaType
        {
            Detention, //看守所
            DrugAbuse, //戒毒所
            Custody, //挽留所
        }

    }
}
