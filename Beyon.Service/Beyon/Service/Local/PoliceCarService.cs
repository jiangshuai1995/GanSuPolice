using System;
using System.Collections.Generic;
using System.Configuration;
using Beyon.WebService.Local;
using Beyon.Domain.Local;

namespace Beyon.Service.Local
{
    /// <summary>
    /// 警车数据外部服务
    /// </summary>
    public class PoliceCarService
    {
        private PoliceCarManager policeCarManager;

        #region Constructors

        /// <summary>
        ///无参构造
        /// </summary>
        public PoliceCarService()
        {
            policeCarManager = new PoliceCarManager();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取警车上的3G摄像头数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public VideoInfoModel Get3GVideoOfPoliceCar(String CarPlateNum)
        {
            return policeCarManager.Get3GVideoOfPoliceCar(CarPlateNum);
        }

        /// <summary>
        /// 获取4G图传车视频数据
        /// </summary>
        /// <param name="CarPlateNum"></param>
        /// <returns></returns>
        public List<KedaVideo> Get4GVideoOfPoliceCar(String CarPlateNum) 
        {
            return policeCarManager.Get4GVideoOfPoliceCar(CarPlateNum);
        }

        /// <summary>
        /// 获取警车上的340M图传车摄像头设备ID
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public String Get340MDeviceIDOfPoliceCar(String CarPlateNum)
        {
            return policeCarManager.Get340MDeviceIDOfPoliceCar(CarPlateNum);
        }

        #endregion

    }
}
