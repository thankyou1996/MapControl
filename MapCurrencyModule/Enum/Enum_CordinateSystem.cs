using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapCurrencyModule.Enum
{
    /// <summary>
    /// 坐标系统枚举
    /// </summary>
    public enum Enum_CordinateSystem
    {
        /// <summary>
        /// 大地坐标系统
        /// GPS坐标
        /// </summary>
        WGS_84 = 0,

        /// <summary>
        /// 火星坐标
        /// 高德地图，腾讯地图
        /// </summary>
        GCJ_02 = 1,

        /// <summary>
        /// 百度坐标
        /// 百度地图
        /// </summary>
        BD_09 = 2,
    }
}
