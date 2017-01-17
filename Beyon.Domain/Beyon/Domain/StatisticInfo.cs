namespace Beyon.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class StatisticInfo
    {
        public string JgId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public Dictionary<string, Value> StatMap { get; set; }

        public class Value
        {
            public Value(string url, long value, double contrast)
            {
                this.Url = url;
                this.pValue = value;
                this.Contrast = contrast;
            }

            public long pValue { get; set; }

            public string Url { get; set; }

            /// <summary>
            /// 同比值
            /// </summary>
            public double Contrast { get; set; }
        }
    }
}

