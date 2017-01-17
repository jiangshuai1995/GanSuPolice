namespace Beyon.Domain
{
    using System;
    using System.Runtime.CompilerServices;

    public class TJSJ
    {
        public static string ToString()
        {
            DateTime now = DateTime.Now;
            return string.Format("{0}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}.0", new object[] { now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second });
        }

        public int date { get; set; }

        public int day { get; set; }

        public int hours { get; set; }

        public int minutes { get; set; }

        public int month { get; set; }

        public int nanos { get; set; }

        public int seconds { get; set; }

        public long time { get; set; }

        public int timezoneOffset { get; set; }

        public int year { get; set; }
    }
}

