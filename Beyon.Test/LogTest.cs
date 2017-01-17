using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beyon.Common;

namespace Beyon.Test
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void TestWriteLog()
        {
            for (int i = 0; i < 20; i++)
            {
                thr t = new thr();
                ThreadPool.QueueUserWorkItem(new WaitCallback(t.ThreadProc), i);
            }
        }
    }

    public class thr
    {
        public void ThreadProc(object i)
        {
            try
            {
                var startTime = DateTime.Now;
                LogMgr.Instance.Log("Thread[" + i.ToString() + "]");
                var endTime = DateTime.Now;
                LogMgr.Instance.Log("时间里飞机阿里卡减肥辣椒粉拉近了放假啊了解法拉伐啦激发肌肤啦发，书法家阿娇法拉省家里附近阿里飞机辣椒粉拉近了房间啊发发发发送方是服务蛟龙未济浪费精力微积分网络分类法拉萨街坊邻居阿里飞机阿里发阿里放假啊乱惊飞垃圾分类批发价法拉利飞机阿什拉夫将阿里");
                LogMgr.Instance.Log("写入时间", endTime - startTime);
            }
            catch(Exception ex)
            {
                LogMgr.Instance.Log(ex.Message);
            }
            
            //Thread.Sleep(1000);
        }
    }
}
