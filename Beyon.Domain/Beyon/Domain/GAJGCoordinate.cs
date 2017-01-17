namespace Beyon.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class GAJGCoordinate : JosnAnalysisDataTable
    {
        private Dictionary<string, List<DataRow>> qydawhf = new Dictionary<string, List<DataRow>>();

        public Dictionary<string, List<DataRow>> GetAreaData(Jglx jglx, double minJd, double maxJd, double minWd, double maxWd)
        {
            this.qydawhf.Clear();
            string str = string.Empty;
            switch (jglx)
            {
                case Jglx.ST:
                    str = "ST";
                    break;

                case Jglx.SJ:
                    str = "SJ";
                    break;

                case Jglx.FJ:
                    str = "FJ";
                    break;

                case Jglx.PCS:
                    str = "PCS";
                    break;

                default:
                    return this.qydawhf;
            }
            if ((minJd >= maxJd) || (minWd >= maxWd))
            {
                throw new ArgumentOutOfRangeException("你输入的区域范围不合法");
            }
            base.NewUrlParam = string.Format("?jglx={0}&polygonStr={1},{2},{3},{4}", new object[] { str, minJd, maxJd, minWd, maxWd });
            DataTable table = this.GetTable1();
            if (table == null)
            {
                return null;
            }
            foreach (DataRow row in table.Rows)
            {
                string str3 = row["SJGAJG_KEY"].ToString();
                if (string.IsNullOrEmpty(str3))
                {
                    str3 = row["GAJG_KEY"].ToString();
                }
                switch (jglx)
                {
                    case Jglx.ST:
                    case Jglx.SJ:
                        row["SJGAJG_KEY"] = str3.Substring(0, 2);
                        break;

                    case Jglx.FJ:
                        row["SJGAJG_KEY"] = str3.Substring(0, 4);
                        break;

                    case Jglx.PCS:
                        row["SJGAJG_KEY"] = str3.Substring(0, 6);
                        break;

                    default:
                        return this.qydawhf;
                }
                string key = row["SJGAJG_KEY"].ToString();
                if (!this.qydawhf.ContainsKey(key))
                {
                    this.qydawhf.Add(key, new List<DataRow>());
                }
                this.qydawhf[key].Add(row);
            }
            return this.qydawhf;
        }

        public Dictionary<string, List<DataRow>> AreaData
        {
            get
            {
                return this.qydawhf;
            }
        }
    }
}

