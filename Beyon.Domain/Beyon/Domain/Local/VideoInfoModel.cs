using System;

namespace Beyon.Domain.Local
{
    /// <summary>
    /// 摄像机实体
    /// </summary>
    public class VideoInfoModel
    {

        private int m_Index;
        /// <summary>
        /// 序号
        /// </summary>
        public int Index
        {
            get { return m_Index; }
            set { m_Index = value;}
        }

        private string m_VideoName;
        /// <summary>
        /// 摄像机名称
        /// </summary>
        public string VideoName
        {
            get { return m_VideoName; }
            set { m_VideoName = value;  }
        }

  
        private string m_VideoPort;
        /// <summary>
        /// 摄像机端口
        /// </summary>
        public string VideoPort
        {
            get { return m_VideoPort; }
            set { m_VideoPort = value;  }
        }

   
        private string m_FactoryName;
        /// <summary>
        /// 厂商名称
        /// </summary>
        public string FactoryName
        {
            get { return m_FactoryName; }
            set { m_FactoryName = value; }
        }


        private double m_X;
        /// <summary>
        /// 经度
        /// </summary>
        public double X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        private double m_Y;
        /// <summary>
        /// 维度
        /// </summary>
        public double Y
        {
            get { return m_Y; }
            set { m_Y = value;}
        }

        private string m_Gbid;
        /// <summary>
        /// 对应的gbid
        /// </summary>
        public string Gbid
        {
            get { return m_Gbid; }
            set { m_Gbid = value; }
        }

        #region 2.0视频参数

        private string m_DeviceId;
        /// <summary>
        /// 设备Id（2.0）
        /// </summary>
        public string DeviceId
        {
            get { return m_DeviceId; }
            set { m_DeviceId = value;  }
        }

        private string m_DomainId;
        /// <summary>
        /// 域Id（2.0）
        /// </summary>
        public string DomainId
        {
            get { return m_DomainId; }
            set { m_DomainId = value; }
        }

        private string m_VideoChannel;
        /// <summary>
        /// 通道号（2.0）
        /// </summary>
        public string VideoChannel
        {
            get { return m_VideoChannel; }
            set { m_VideoChannel = value; }
        }

        private int m_VideoSource;
        /// <summary>
        /// 来源标识（2.0）
        /// </summary>
        public int VideoSource
        {
            get { return m_VideoSource; }
            set { m_VideoSource = value; }
        }

        
        #endregion


    }
}
