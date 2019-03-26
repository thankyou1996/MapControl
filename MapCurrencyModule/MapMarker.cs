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
        /// （实际业务应用中可作为id 或者关联信息存储）
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
        public double Rotation
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


        private MapLabel label = new MapLabel();

        /// <summary>
        /// Label
        /// </summary>
        public MapLabel Label
        {
            get;
            set;
        }

        private int intMaxZoom = 19;
        /// <summary>
        /// 最大地图显示等级
        /// 当地图缩放到大于此zoom的时候，marker不会加载到地图上
        /// </summary>
        public int MaxZoom
        {
            get { return intMaxZoom; }
            set { intMaxZoom = value; }
        }


        private int intMinZoom = 1;

        /// <summary>
        /// 最小显示等级
        /// 当地图缩放到小于此zoom的时候，marker不会加载到地图上
        /// </summary>
        public int MinZoom
        {
            get { return intMinZoom; }
            set { intMinZoom = value; }
        }
    }
}
