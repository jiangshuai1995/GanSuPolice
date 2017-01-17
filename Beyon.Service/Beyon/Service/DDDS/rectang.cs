namespace Beyon.Service.DDDS
{
    using System;
    using System.Runtime.CompilerServices;

    public class rectang
    {
        public rectang(double minWd, double maxWd, double minJd, double maxJd)
        {
            this.MinLongitude = minJd;
            this.MaxLongitude = maxJd;
            this.MinLatitude = minWd;
            this.MaxLatitude = maxWd;
        }

        public override string ToString()
        {
            if ((this.MinLongitude >= this.MaxLongitude) || (this.MinLatitude >= this.MaxLatitude))
            {
                throw new ArgumentOutOfRangeException("你如入的区域范围不合法");
            }
            return string.Format("polygonStr={0},{1},{2},{3}", new object[] { this.MinLongitude, this.MaxLongitude, this.MinLatitude, this.MaxLatitude });
        }

        public double MaxLatitude { get; set; }

        public double MaxLongitude { get; set; }

        public double MinLatitude { get; set; }

        public double MinLongitude { get; set; }
    }
}

