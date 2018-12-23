namespace Beyon.Common
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using System.Linq;

    /// <summary>
    /// 网络服务工具类
    /// </summary>
    public class ServiceUtil
    {
        private const string tfgf = "[{";
        private const string wfgf = "------------";

        public static string DeleteTJSJ(string jsonstr)
        {
            bool flag;
            int startIndex = 0;
            string str = "\"TJSJ\":{\"date\":";
            if (jsonstr.IndexOf(str, startIndex) == -1)
            {
                return jsonstr;
            }
            StringBuilder builder = new StringBuilder();
            startIndex = 0;
            int index = 0;
            int num3 = 0;
            try
            {
                goto Label_0088;
            Label_0037:
                startIndex = jsonstr.IndexOf(str, startIndex);
                if (startIndex == -1)
                {
                    builder.Append(jsonstr.Substring(num3));
                    goto Label_0126;
                }
                index = jsonstr.IndexOf("},", startIndex);
                builder.Append(jsonstr.Substring(num3, startIndex - num3));
                num3 = index + 2;
                startIndex = index;
            Label_0088:
                flag = true;
                goto Label_0037;
            }
            catch (Exception)
            {
                builder.Clear();
                index = 0;
                num3 = 0;
                startIndex = 0;
                goto Label_011E;
            Label_00A6:
                startIndex = jsonstr.IndexOf(str, startIndex);
                if (startIndex == -1)
                {
                    builder.Append(jsonstr.Substring(num3));
                    goto Label_0126;
                }
                index = jsonstr.IndexOf("}", startIndex);
                if (num3 == 0)
                {
                    builder.Append(jsonstr.Substring(num3, (startIndex - num3) - 1));
                }
                else
                {
                    builder.Append(jsonstr.Substring(num3, (startIndex - num3) - 1));
                }
                num3 = index + 1;
                startIndex = index;
            Label_011E:
                flag = true;
                goto Label_00A6;
            }
        Label_0126:
            return builder.ToString();
        }

        public static DataSet GetRemoteDataSet(string url, WebProxy proxy, List<string> keys)
        {
            DataSet set = new DataSet();
            List<string> list = new List<string>();
            string remoteXmlStream = GetRemoteXmlStream(url, proxy);
            int startIndex = 0;
            int index = 0;
            int count = keys.Count;
            foreach (string str2 in keys)
            {
                startIndex = remoteXmlStream.IndexOf("[{", startIndex);
                if (startIndex == -1)
                {
                    break;
                }
                index = remoteXmlStream.IndexOf("------------", startIndex);
                if (index == -1)
                {
                    list.Add(remoteXmlStream.Substring(startIndex));
                    break;
                }
                list.Add(remoteXmlStream.Substring(startIndex, index - startIndex));
                startIndex = index;
            }
            int num4 = 0;
            foreach (string str2 in list)
            {
                //Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
                //JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                //{
                //    //日期类型默认格式化处理
                //    setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                //    setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //    //空值处理
                //    setting.NullValueHandling = NullValueHandling.Ignore;

                //    setting.FloatFormatHandling = FloatFormatHandling.Symbol;

                //    return setting;
                //});

                //DataTable table = JsonConvert.DeserializeObject<DataTable>(DeleteTJSJ(str2), setting);
                String json = DeleteTJSJ(str2);
                DataTable table = null;
                try
                {
                    //解决解析double字段精度缺少问题
                    table = Tabulate(json);
                }
                catch(Exception)
                {
                    //若自有方法解析出错，使用NewJson自有方法
                    table = JsonConvert.DeserializeObject<DataTable>(json);
                }
                
                table.TableName = keys[num4];

                ////Todo 写入数据到文件
                //String directory = String.Format(@"{0}\统计数据", System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
                //String fileName = String.Format(@"{0}\统计数据\{1}.xml", System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, keys[num4]);
                //if (Directory.Exists(directory))
                //    Directory.CreateDirectory(directory);
                //table.WriteXml(fileName);

                set.Tables.Add(table);
                num4++;
            }
            return set;
        }

        private static DataTable Tabulate(string json)
        {
            var jsonLinq = Newtonsoft.Json.Linq.JArray.Parse(json);

            DataTable table = new DataTable();
            bool addColumnName = false;
            // Find the first array using Linq
            foreach (JObject row in jsonLinq.Children<JObject>())
            {
                if (!addColumnName)
                {
                    foreach (JProperty column in row.Properties())
                    {
                        if (column.Value is JValue)
                        {
                            table.Columns.Add(column.Name, typeof(string));
                        }
                    }
                }
                addColumnName = true;

                var tableRow = table.NewRow();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types
                    if (column.Value is JValue)
                    {
                        tableRow[column.Name] = column.Value.ToString();
                    }
                }
                table.Rows.Add(tableRow);
            }

            return table;
        }

        public static Dictionary<string, List<T>> GetRemoteObject<T>(string url, WebProxy proxy, List<string> keys)
        {
            Dictionary<string, List<T>> dictionary = null;
            List<string> list = new List<string>();
            string remoteXmlStream = GetRemoteXmlStream(url, proxy);
            int startIndex = 0;
            int index = 0;
            int count = keys.Count;
            foreach (string str2 in keys)
            {
                startIndex = remoteXmlStream.IndexOf("[{", startIndex);
                if (startIndex == -1)
                {
                    break;
                }
                index = remoteXmlStream.IndexOf("------------", startIndex);
                if (index == -1)
                {
                    list.Add(remoteXmlStream.Substring(startIndex));
                    break;
                }
                list.Add(remoteXmlStream.Substring(startIndex, index - startIndex));
                startIndex = index;
            }
            int num4 = 0;
            dictionary = new Dictionary<string, List<T>>();
            foreach (string str2 in list)
            {
                List<T> list2 = JsonConvert.DeserializeObject<List<T>>(str2);
                dictionary.Add(keys[num4], list2);
                num4++;
            }
            return dictionary;
        }

        public static void GetRemoteObject<T1, T2>(string url, WebProxy proxy, out List<T1> t1, out List<T2> t2)
        {
            List<string> list = new List<string>();
            string remoteXmlStream = GetRemoteXmlStream(url, proxy);
            int startIndex = 0;
            int index = 0;
            for (int i = 0; i < 2; i++)
            {
                startIndex = remoteXmlStream.IndexOf("[{", startIndex);
                index = remoteXmlStream.IndexOf("------------", startIndex);
                if (index == -1)
                {
                    list.Add(remoteXmlStream.Substring(startIndex));
                }
                else
                {
                    list.Add(remoteXmlStream.Substring(startIndex, index - startIndex));
                    startIndex = index;
                }
            }
            if (index != -1)
            {
                throw new AggregateException(url + " : 请求的json数组超过了两个");
            }
            List<T1> list2 = new List<T1>();
            List<T2> list3 = new List<T2>();
            if (list.Count > 0)
            {
                list2 = JsonConvert.DeserializeObject<List<T1>>(list[0]);
            }
            if (list.Count > 1)
            {
                list3 = JsonConvert.DeserializeObject<List<T2>>(list[1]);
            }
            t1 = list2;
            t2 = list3;
        }

        //private static bool hasUse = false;
        public static string GetRemoteXmlStream(string url, WebProxy proxy)
        {
            WebRequest request = null;
            try
            {
                //设置允许最大连接数
                if (System.Net.ServicePointManager.DefaultConnectionLimit < 50)
                    System.Net.ServicePointManager.DefaultConnectionLimit = 200;
                DateTime startTime = DateTime.Now;
                String result;
                Uri requestUri = new Uri(url);
                if (requestUri.IsAbsoluteUri && requestUri.IsFile)
                {
                    using (Stream responseStream = System.IO.File.OpenRead(requestUri.LocalPath))
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    request = WebRequest.Create(requestUri);
                    if (proxy != null)
                    {
                        request.Proxy = proxy;
                    }
                    request.Timeout = -1;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                result = reader.ReadToEnd();

                            }
                        }
                    }

                    if (request != null)
                        request.Abort();
                }

                DateTime endTime = DateTime.Now;
                TimeSpan consumeTime = endTime - startTime;
                LogMgr.Instance.Log("Url[" + url + "]");
                LogMgr.Instance.Log("调用远程web服务耗时:", consumeTime);
                return result;
            }
            catch (Exception ex)
            {
                if (request != null)
                    request.Abort();
                LogMgr.Instance.Log(String.Format("URL执行错误：Url[{0}],错误信息如下：{1}", url, ex.Message));
                throw ex;
            }
        }
    }
}

