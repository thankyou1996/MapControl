using System;
using System.Collections.Generic;
using System.Text;

namespace MapCurrencyModule
{
    /// <summary>
    /// 地图Marker
    /// </summary>
    public class MapMarker
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        public string DisplayValue
        {
            get;
            set;
        }

        /// <summary>
        /// 旋转角度
        /// </summary>
        public int Rotation
        {
            get;
            set;
        }

        /// <summary>
        /// 阴影(null 表示没有阴影效果)
        /// </summary>
        public MapIcon Shadow
        {
            get;
            set;
        }

        /// <summary>
        /// 图标
        /// </summary>
        public MapIcon Icon
        {
            get;
            set;
        }

        /// <summary>
        /// 坐标信息
        /// </summary>
        public MapPoint Point
        {
            get;
            set;
        }
            
    }
}
