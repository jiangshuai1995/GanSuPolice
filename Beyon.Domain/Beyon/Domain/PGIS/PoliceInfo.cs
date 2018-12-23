using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyon.Domain.PGIS
{
    /// <summary>
    /// 警务要素
    /// </summary>
    public class PoliceInfo
    {
        /// <summary>
        /// GPSID 唯一标识（警车 手持唯一标识）
        /// </summary>
        public string GpsId { get; set; }
        /// <summary>
        /// 警车类型 （区分普通警车、3G、340M、3G+340M、手持）
        /// </summary>
        public int LocType { get; set; }
        /// <summary>
        /// 巡逻类型（手持、警车都有）
        /// </summary>
        public string PatrolType { get; set; }
        /// <summary>
        /// （打电话区分本地还是外地）（手持、警车 都有）
        /// </summary>
        public string CarChannel { get; set; }
        /// <summary>
        /// UIM卡号（警车 手持都有）
        /// </summary>
        public string UIM { get; set; }

        #region 警车信息
        /// <summary>
        /// 车牌号（警车有）
        /// </summary>
        public string CarPlateNum { get; set; }
        /// <summary>
        /// 警车呼号
        /// </summary>
        public string CarCallNum { get; set; }
        /// <summary>
        /// 警车负责人名称（警车有）
        /// </summary>
        public string Responser { get; set; }
        /// <summary>
        /// 警车负责人联系号码（警车有）手持 联系方式
        /// </summary>
        public string ResponserPhoneNo { get; set; }
        /// <summary>
        /// 警车所属市局单位名车（警车有）
        /// </summary>
        public string CarSJUnit { get; set; }
        /// <summary>
        /// 警车所属分局单位名称（警车有）
        /// </summary>
        public string CarFJUnit { get; set; }
        /// <summary>
        /// 警车所属单位名称（警车的分局下属的单位名称）
        /// </summary>
        public string CarUnit { get; set; }
        #endregion

        #region 手持信息

        /// <summary>
        /// 警号（手持有）
        /// </summary>
        public string PoliceId { get; set; }

        /// <summary>
        /// 警员名称（手持有）
        /// </summary>
        public string PoliceName { get; set; }

        /// <summary>
        /// 警员电话号码(手持有注意：暂不用)
        /// </summary>
        public string PhoneNo { get; set; }
        /// <summary>
        /// 手持所属单位（手持有）
        /// </summary>
        public string Remark { get; set; }

        #endregion
    }
}
