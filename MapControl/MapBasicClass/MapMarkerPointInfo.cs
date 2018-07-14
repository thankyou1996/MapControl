using System;
using System.Collections.Generic;
using System.Text;

namespace MapControl
{
    public delegate bool MarkerRightClickDelegate(object sneder, object MarkerRightClickValue);
    /// <summary>
    /// 地图标注点信息
    /// </summary>
    public class MapMarkerPointInfo
    {
        /// <summary>
        /// 标注点ID
        /// </summary>
        private int intMarkerID;

        /// <summary>
        /// 标注点ID
        /// </summary>
        public int MarkerID
        {
            get { return intMarkerID; }
            set { intMarkerID = value; }
        }

        /// <summary>
        /// 标注点名称
        /// </summary>
        public string MarkerName = "";

        /// <summary>
        /// 标注点显示信息
        /// </summary>
        public string MarkerDisplayValue = "";

        /// <summary>
        /// 标注点标签
        /// </summary>
        public object MarkerDisplayTag;
        
        /// <summary>
        /// 标注点Icon路径
        /// </summary>
        public string MarkerIconFilePath = "";

        /// <summary>
        /// 标注点Icon 宽度
        /// </summary>
        public int MarkerIconWidth = 16;
        /// <summary>
        /// 标注点Icon 高度
        /// </summary>
        public int MarkerIconHeight = 16;

        /// <summary>
        /// 标注点首次显示地图等级
        /// 0表示未设置
        /// </summary>
        public int MarkerFirstDisplayMapLevel = 0;

        /// <summary>
        /// 地图点信息
        /// </summary>
        public MapPointInfo MarkerPoint = new MapPointInfo();

        #region 事件

        public bool ExistMarkerRightClickEvent()
        {
            return MarkerRightClickEvent != null;
        }

        public bool MarkerRightClick(object MarkerRightValue)
        {
            bool bolResult = false;
            if (MarkerRightClickEvent != null)
            {
                bolResult = MarkerRightClickEvent(this, MarkerRightValue);
            }
            return bolResult;
        }
        /// <summary>
        /// 标注点右键点击事件
        /// </summary>
        public event MarkerRightClickDelegate MarkerRightClickEvent;
        #endregion
    }
}
