namespace Beyon.Domain.GridSelect
{
    using System;
    using System.Runtime.CompilerServices;

    public class RenKou
    {
        public string FJH { get; set; }

        public string GMSFHM
        {
            set
            {
                this.SFZH = value;
            }
        }

        public string RKBM { get; set; }

        public string SFZH { get; set; }

        public string XB { get; set; }

        public string XM { get; set; }

        public string zp { get; set; }
    }
}

