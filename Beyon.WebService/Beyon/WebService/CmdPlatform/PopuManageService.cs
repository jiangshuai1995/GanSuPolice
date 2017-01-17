namespace Beyon.WebService.CmdPlatform
{
    using Beyon.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class PopuManageService
    {
        private string ckUrl = "http://10.178.3.34/zhddInterface/ry/ryglInterface!getCkPageCount.do";

        public Dictionary<string, int> GetPermanPopuByGender(string areaName)
        {
            return new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetPermanPopuByHukou(string areaName)
        {
            return new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetPermanPopuByStatus(string areaName)
        {
            string url = "http://10.178.3.34/zhddInterface/ry/ryglInterface!getCkPageCount.do";
            List<object> list = JsonConvert.DeserializeObject<List<object>>(ServiceUtil.GetRemoteXmlStream(url, null));
            return new Dictionary<string, int>();
        }
    }
}

