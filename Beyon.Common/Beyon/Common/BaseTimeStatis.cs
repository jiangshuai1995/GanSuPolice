namespace Beyon.Common
{
    using System;
    using System.Diagnostics;

    public abstract class BaseTimeStatis
    {
        private Stopwatch statisWatch = new Stopwatch();

        protected BaseTimeStatis()
        {
        }

        protected void BeginMethodStatis()
        {
            this.statisWatch.Restart();
        }

        protected void EndMethodStatis()
        {
            this.statisWatch.Stop();
            StackFrame frame = new StackTrace().GetFrame(1);
        }
    }
}

