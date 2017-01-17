namespace Beyon.Service.DDDS
{
    using Beyon.Domain;
    using System;
    using System.Runtime.CompilerServices;

    public class UrlParameter
    {
        public const string FJ = "FJ";
        public const string PCS = "PCS";
        public const string SJ = "SJ";
        public const string ST = "ST";

        public UrlParameter(string xzqh)
        {
            this.xzqh = new Beyon.Service.DDDS.xzqh();
            this.xzqh.XZQH = xzqh;
            this.rectang = new Beyon.Service.DDDS.rectang(0.0, 0.0, 0.0, 0.0);
        }

        public UrlParameter(Jglx jglx, double minJd, double maxJd, double minWd, double maxWd)
        {
            switch (jglx)
            {
                case Jglx.ST:
                    this.jgalx = "ST";
                    break;

                case Jglx.SJ:
                    this.jgalx = "SJ";
                    break;

                case Jglx.FJ:
                    this.jgalx = "FJ";
                    break;

                case Jglx.PCS:
                    this.jgalx = "PCS";
                    break;
            }
            this.jgalx = this.jgalx;
            this.rectang = new Beyon.Service.DDDS.rectang(minWd, maxWd, minJd, maxJd);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is UrlParameter))
            {
                return false;
            }
            UrlParameter parameter = (UrlParameter) obj;
            return (((((this.jgalx == parameter.jgalx) && (this.xzqh.XZQH == parameter.xzqh.XZQH)) && ((this.rectang.MaxLatitude == parameter.rectang.MaxLatitude) && (this.rectang.MaxLongitude == parameter.rectang.MaxLongitude))) && (this.rectang.MinLatitude == parameter.rectang.MinLatitude)) && (this.rectang.MinLongitude == parameter.rectang.MinLongitude));
        }

        public override string ToString()
        {
            if ((((this.jgalx != "ST") && (this.jgalx != "SJ")) && (this.jgalx != "FJ")) && (this.jgalx != "PCS"))
            {
                throw new ArgumentOutOfRangeException(this.jgalx + " ： 不属于(\"ST\" \"SJ\" \"FJ\" \"PCS\")中的一个)");
            }
            return string.Format("?jglx={0}&{1}", this.jgalx, this.rectang.ToString());
        }

        public string xzqhToString()
        {
            return this.xzqh.ToString();
        }

        public string jgalx { get; set; }

        public Beyon.Service.DDDS.rectang rectang { private get; set; }

        public Beyon.Service.DDDS.xzqh xzqh { private get; set; }
    }
}

