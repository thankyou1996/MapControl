using System;
using System.Collections.Generic;
using System.Text;

namespace MapControl
{
    /// <summary>
    /// 地图加载结束事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="MapControlLoadEndValue"></param>
    public delegate void MapControlLoadEndDelegate(object sender, object MapControlLoadEndValue);
    
    /// <summary>
    /// 选中地图点事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="SelectedMapPointValue"></param>
    public delegate void SelectedMapPointDelegate(object sender, MapPointInfo SelectedMapPointValue);

    /// <summary>
    /// 地图控件右键事件委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="MapControlRightClickValue"></param>
    /// <returns></returns>
    public delegate bool MapControlRightClick(object sender, object MapControlRightClickValue);

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
        /// 地图控件右键事件
        /// </summary>
        event MapControlRightClick MapControlRightClickEvent;

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
