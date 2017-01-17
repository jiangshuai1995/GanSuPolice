namespace Beyon.Domain.GridSelect
{
    using System;
    using System.Runtime.CompilerServices;

    public class GridInfo
    {
        public string FLDM { get; set; }

        public string GTYPE { get; set; }

        public string JD { get; set; }

        public string MC { get; set; }

        public string SSJWXQ { get; set; }

        public string WD { get; set; }

        public string ZZJGDM { get; set; }

        public string ZZJJDM
        {
            set
            {
                this.ZZJGDM = value;
            }
        }
    }
}

