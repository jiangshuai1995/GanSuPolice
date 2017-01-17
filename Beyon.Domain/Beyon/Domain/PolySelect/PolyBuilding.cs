namespace Beyon.Domain.PolySelect
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Beyon.Domain.GridSelect;

    /// <summary>
    /// 圈选房屋列表项
    /// </summary>
    public class PolyBuilding
    {
        /// <summary>
        /// 房屋数目
        /// </summary>
        public long fw { get; set; }

        /// <summary>
        /// 房屋列表
        /// </summary>
        public List<Building> fwList { get; set; }
    }
}

