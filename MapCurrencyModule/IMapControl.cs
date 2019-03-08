﻿using MapCurrencyModule.Delegate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapCurrencyModule
{
    public interface IMapControl
    {
        /// <summary>
        /// 地图类型
        /// </summary>
        MapType mapType
        {
            get;
            set;
        }

        /// <summary>
        /// 地图加载完成事件
        /// </summary>
        event MapControlLoadEndDelegate MapControlLoadEndEvent;
        /// <summary>
        /// 设置中心点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        bool SetCenterPoint(MapPointInfo point);

        /// <summary>
        /// 设置地图等级
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        bool SetMapLevel(MapPointInfo point);

        bool SetMapPointInfo(MapPointInfo point);

        /// <summary>
        /// 设置标注点信息
        /// </summary>
        /// <param name="point"></param>
        /// <param name="strMarkerPicFilePath"></param>
        /// <returns></returns>
        bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath);

        /// <summary>
        /// 显示标注点信息
        /// </summary>
        /// <param name="marker"></param>
        /// <returns></returns>
        bool SetMapMarker(MapMarkerPointInfo marker);
    }
}
