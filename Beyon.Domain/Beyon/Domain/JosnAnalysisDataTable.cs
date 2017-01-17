namespace Beyon.Domain
{
    using Beyon.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class JosnAnalysisDataTable : IScreenRow
    {
        public DataSet josnSet;
        private string newUrlParam;
        private string oldUrlParam;
        public XZQHChange XZTHChanging;

        public JosnAnalysisDataTable()
        {
            this.keys = new List<string>();
        }

        public string GetHostURL(string xzqh)
        {
            if (this.HostUrl != null)
            {
                return string.Format(this.HostUrl, xzqh);
            }
            return string.Empty;
        }

        private void GetRemote()
        {
            if (this.newUrlParam != this.oldUrlParam)
            {
                string url;
                this.oldUrlParam = this.newUrlParam;
                if (string.IsNullOrEmpty(this.Url))
                {
                    this.ThrowUrlNull();
                }
                if (string.IsNullOrEmpty(this.oldUrlParam) || (this.oldUrlParam.Length == 8))
                {
                    url = this.Url;
                }
                else
                {
                    url = this.Url + this.oldUrlParam;
                }
                this.josnSet = ServiceUtil.GetRemoteDataSet(url, null, this.keys);
            }
        }

        public string GetResultURL(string[] param)
        {
            if (this.DetailedUrl != null)
            {
                return string.Format(this.DetailedUrl, (object[]) param);
            }
            return string.Empty;
        }

        public string GetResultURLTwoParam(string type, string xzqh)
        {
            if (this.DetailedUrl != null)
            {
                return string.Format(this.DetailedUrl, type, xzqh);
            }
            return string.Empty;
        }

        public DataTable GetTable(string tableName)
        {
            this.GetRemote();
            if (this.josnSet.Tables.Count == 0)
            {
                return null;
            }
            return this.josnSet.Tables[tableName];
        }

        public virtual DataTable GetTable1()
        {
            return this.GetTable(this.keys[0]);
        }

        public virtual DataTable GetTable2()
        {
            return this.GetTable(this.keys[1]);
        }

        public virtual DataTable GetTable3()
        {
            return this.GetTable(this.keys[2]);
        }

        public DataRow Screen(string xzqhID, AffairsType at, string xzqh = "XZQH")
        {
            DataTable table;
            switch (at)
            {
                case AffairsType.DEF:
                case AffairsType.D:
                case AffairsType.JJ:
                case AffairsType.LA:
                    table = this.GetTable1();
                    break;

                case AffairsType.M:
                case AffairsType.CJ:
                case AffairsType.PA:
                    table = this.GetTable2();
                    break;

                case AffairsType.Y:
                    table = this.GetTable3();
                    break;

                default:
                    return null;
            }
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row[xzqh].ToString().PadRight(12, '0') == xzqhID)
                    {
                        return row;
                    }
                }
            }
            return null;
        }

        protected void ThrowGetDataErorr(string url)
        {
            throw new AggregateException(url + " ：没有获得正确的数据");
        }

        protected void ThrowUrlNull()
        {
            throw new NullReferenceException("Url 为空");
        }

        public string DetailedUrl { get; set; }

        public string HostUrl { get; set; }

        public List<string> keys { get; set; }

        public string NewUrlParam
        {
            get
            {
                return this.newUrlParam;
            }
            set
            {
                this.newUrlParam = value;
            }
        }

        public string Url { get; set; }

        public delegate string XZQHChange();
    }
}

