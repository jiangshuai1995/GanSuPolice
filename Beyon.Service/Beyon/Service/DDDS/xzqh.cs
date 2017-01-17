namespace Beyon.Service.DDDS
{
    using System;
    using System.Runtime.CompilerServices;

    public class xzqh
    {
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.XZQH))
            {
                return "";
            }
            return ("?xzqh=" + this.XZQH);
        }

        public string XZQH { get; set; }
    }
}

