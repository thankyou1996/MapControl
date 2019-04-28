using System;
using System.Collections.Generic;
using System.Text;

namespace MapCurrencyModule
{
    /// <summary>
    /// 地图轨迹点
    /// </summary>
    public class MapTrajectoryPoint
    {
        string name = "";

        /// <summary>
        /// 名称（实际业务应用中可作为id 或者关联信息存储）
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double dblSpeed = 0.0;

        /// <summary>
        /// 速度 m
        /// </summary>
        public double Speed
        {
            get { return dblSpeed; }
            set { dblSpeed = value; }
        }
        /// <summary>
        /// GPS定位方向
        /// 方向 0-359 正北为0,顺时针
        /// </summary>
        private double intDirection = 0.0;
        /// <summary>
        /// GPS定位方向
        /// 方向 0-359 正北为0,顺时针
        /// </summary>
        public double Direction
        {
            get { return intDirection; }
            set { intDirection = value; }
        }

        /// <summary>
        /// 定位时间
        /// </summary>
        public DateTime LocationTime
        {
            get;
            set;
        }


        private MapPoint point = new MapPoint { Lon = 0.0, Lat = 0.0, Coordinate = Enum.Enum_Coordinate.WGS_84 };

        /// <summary>
        /// 坐标点
        /// </summary>
        public MapPoint Point
        {
            get { return point; }
            set { point = value; }
        }
    }
}
