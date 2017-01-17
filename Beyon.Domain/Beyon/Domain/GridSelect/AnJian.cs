namespace Beyon.Domain.GridSelect
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 案件
    /// </summary>
    public class AnJian
    {
        /// <summary>
        /// 案件名称
        /// </summary>
        public string AJMC { get; set; }

        public string AJZT { get; set; }

        /// <summary>
        /// 报警类型
        /// </summary>
        public string BJLX { get; set; }

        public string CJBS
        {
            set
            {
                this.AJZT = value;
            }
        }

        /// <summary>
        /// 案件ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 监狱备注 todo
        /// </summary>
        public string JYAQ { get; set; }
    }
}

