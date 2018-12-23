using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beyon.WebService.Local;
using Beyon.Domain.Local;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beyon.Test
{
    [TestClass()]
    public class VideoManagerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        ///GetAllVideosTest 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllVideosTest()
        {
            VideoManager target = new VideoManager();
            List<VideoInfoModel> actual = target.GetAllVideos();
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///GetAllVideosByName 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllVideosByName()
        {
            KedaVideoManager target = new KedaVideoManager();
            List<KedaVideo> actual = target.GetAllVideosByName("酒");
            Assert.AreEqual(actual.Count >= 1, true);
        }


        /// <summary>
        ///GetAllVideosByName 的测试
        ///</summary>
        [TestMethod()]
        public void GetVideosOfRect()
        {
            KedaVideoManager target = new KedaVideoManager();
            List<KedaVideo> actual = target.GetVideosOfRect(100, 33, 104, 37);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///GetAllVideosByName 的测试
        ///</summary>
        [TestMethod()]
        public void GetKedaVideoOfPrison()
        {
            KedaVideoManager target = new KedaVideoManager();
            List<KedaVideo> actual = target.GetVideoOfPrison("620101111");
            Assert.AreEqual(actual.Count >= 1, true);
        }
        
        /// <summary>
        ///GetSpecificVideos 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpecificVideos()
        {
            VideoManager target = new VideoManager();
            List<VideoInfoModel> actual = target.GetSpecificVideos(VideoTypeModel.VideoType.CaseCenter);
            actual = target.GetSpecificVideos(VideoTypeModel.VideoType.InternalVideo);
            actual = target.GetSpecificVideos(VideoTypeModel.VideoType.KeyArea);
            actual = target.GetSpecificVideos(VideoTypeModel.VideoType.MoveableVideo);
            actual = target.GetSpecificVideos(VideoTypeModel.VideoType.PublicArea);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///GetSpecificVideos 的测试
        ///</summary>
        [TestMethod()]
        public void GetSpecificVideosOfRect()
        {
            VideoManager target = new VideoManager();
            List<VideoInfoModel> actual = target.GetSpecificVideosOfRect(99, 33, 104, 37, VideoTypeModel.VideoType.PublicArea);
            Assert.AreEqual(actual.Count >= 1, true);
        }

        /// <summary>
        ///GetSpecificVideos 的测试
        ///</summary>
        [TestMethod()]
        public void GetVideoOfPrison()
        {
            VideoManager target = new VideoManager();
            List<VideoInfoModel> actual = target.GetVideoOfPrison("62102466666", VideoTypeModel.AreaType.Custody);
        }

        [TestMethod()]
        public void GetVideoNearPoint()
        {
            VideoManager target = new VideoManager();
            List<VideoInfoModel> actual = target.GetVideoNearPoint(36, 103);
        }
        
    }
}
