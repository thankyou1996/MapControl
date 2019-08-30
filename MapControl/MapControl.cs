using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MapControl
{
    public partial class MapControl : UserControl, IMapControl
    {
        public MapControl()
        {
            InitializeComponent();
        }
        #region 全局变量
        /// <summary>
        /// 地图文件 文件夹地址
        /// </summary>
        public string g_strSougouOffLineMapFileFolderPath = Application.StartupPath + "//MapFile";
        /// <summary>
        /// 地图Bin文件
        /// </summary>
        public string g_strSougouOffLineMapFileBin = "";
        /// <summary>
        /// 地图Info文件
        /// </summary>
        public string g_strSougouOffLineMapFileInfo = "";
        /// <summary>
        /// 地图Ini文件
        /// </summary>
        public string g_strSougouOffLineMapFileIni = "";


        public string g_strBaiduOnlieMapFilePath = "";


        public string g_strGoogleMapFilePath = "";


        IMapControl mapControl;

        public bool LoadEnd
        {
            get
            {
                if (mapControl != null)
                {
                    return mapControl.LoadEnd;
                }
                return false;
            }
        }
        #endregion

        #region 回调与事件
        #region 地图显示事件
        public delegate void MapControl_DisplayMapEventHandler(MapType mtType, double dblLon, double dblLat, int intMapLevel, string strTag = "");
        public event MapControl_DisplayMapEventHandler MapDisplayEvent;

        private void MapDisplay(MapType mtType, double dblLon, double dblLat, int intMapLevel, string strTag = "")
        {
            if (MapDisplayEvent != null)
            {
                MapDisplayEvent(mtType, dblLon, dblLat, intMapLevel, strTag = "");
            }
        }
        #endregion

        #region 选中地图点
        public delegate void SelectedMapPointDelegate(object sender, MapPointInfo MapPointInfo);

        public event SelectedMapPointDelegate SelectedMapPointEvent;

        public void SelectedMapPoint(MapPointInfo MapPointInfo)
        {
            if (SelectedMapPointEvent != null)
            {
                SelectedMapPointEvent(this, MapPointInfo);
            }
        }
        #endregion
        public event MapControlLoadEndDelegate MapControlLoadEndEvent;
        public event MapControlRightClick MapControlRightClickEvent;
        /// <summary>
        /// 标注点点击事件
        /// </summary>
        public event MapMarkerClickDelegate MapMarkerClickEvent;

        /// <summary>
        /// 标注点右键点击事件
        /// </summary>
        public event MapMarkerClickDelegate MapMarkerRightClickEvent;


        /// <summary>
        /// 标注点双击事件
        /// </summary>
        public event MapMarkerClickDelegate MapMarkerDoubleClickEvent;

        #endregion

        #region 自定义属性

        private MapType currentMapType = MapType.BaiduOnlineMap;
        [Description("地图类型"), Category("自定义属性")]
        public MapType CurrentMapType
        {
            get { return currentMapType; }
            set
            {
                if (currentMapType != value)
                {
                    switch (value)
                    {
                        case MapType.BaiduOnlineMap:
                            baiduOnlineMap1.Visible = true;
                            sogouOfflineMap1.Visible = false;
                            googleOnlineMap1.Visible = false;
                            baiduOnlineMap1.Dock = DockStyle.Fill;
                            mapControl = baiduOnlineMap1;
                            break;

                        case MapType.SogouOffLineMap:
                            baiduOnlineMap1.Visible = false;
                            sogouOfflineMap1.Visible = true;
                            googleOnlineMap1.Visible = false;
                            sogouOfflineMap1.Dock = DockStyle.Fill;
                            mapControl = sogouOfflineMap1;
                            break;

                        case MapType.GoogleOnlineMap:
                            baiduOnlineMap1.Visible = false;
                            sogouOfflineMap1.Visible = false;
                            googleOnlineMap1.Visible = true;
                            googleOnlineMap1.Dock = DockStyle.Fill;
                            mapControl = googleOnlineMap1;
                            break;
                    }
                    Init_EventRegister();
                    currentMapType = value;
                }

            }
        }

       
        #endregion




        private void MapControl_Load(object sender, EventArgs e)
        {
            sogouOfflineMap1.OfflineMapDisplay += SogouMapDisplay;
            sogouOfflineMap1.SelectedMapPointEvent += SelectedMapPoint;
            baiduOnlineMap1.SelectedMapPointEvent += SelectedMapPoint;
            googleOnlineMap1.SelectedMapPointEvent += SelectedMapPoint;
        }
        public void SogouMapDisplay(double dblLon, double dblLat, int intMapLevel, string strTag = "")
        {
            MapDisplay(MapType.SogouOffLineMap, dblLon, dblLat, intMapLevel, strTag);
        }

        public void Init()
        {
            switch (currentMapType)
            {
                case MapType.BaiduOnlineMap:
                    mapControl = baiduOnlineMap1;
                    
                    break;
                case MapType.SogouOffLineMap:
                    mapControl = sogouOfflineMap1;
                    break;
                case MapType.GoogleOnlineMap:
                    mapControl = googleOnlineMap1;
                    break;

            }
            Init_EventRegister();
            switch (currentMapType)
            {
                case MapType.BaiduOnlineMap:
                    Init_BaiduOnlineMap();

                    break;
                case MapType.SogouOffLineMap:
                    Init_SogouMapOfflineMap();
                    break;
                case MapType.GoogleOnlineMap:
                    Init_Google();
                    break;
            }
        }
        public void Init_SogouMapOfflineMap()
        {
            sogouOfflineMap1.Init(g_strSougouOffLineMapFileBin, g_strSougouOffLineMapFileInfo, g_strSougouOffLineMapFileIni);
        }
        
        public void Init_BaiduOnlineMap()
        {
            baiduOnlineMap1.Init(g_strBaiduOnlieMapFilePath);
        }

        public void Init_Google()
        {
            googleOnlineMap1.Init(g_strGoogleMapFilePath);
        }

        public void Init_EventRegister()
        {

            if (MapControlLoadEndEvent != null)
            {
                mapControl.MapControlLoadEndEvent -= MapControlLoadEndEvent;
                mapControl.MapControlLoadEndEvent += MapControlLoadEndEvent;
            }
            if (MapControlRightClickEvent != null)
            {
                mapControl.MapControlRightClickEvent -= MapControlRightClickEvent;
                mapControl.MapControlRightClickEvent += MapControlRightClickEvent;
            }
            if (MapMarkerRightClickEvent != null)
            {
                mapControl.MapMarkerRightClickEvent -= MapMarkerRightClickEvent;
                mapControl.MapMarkerRightClickEvent += MapMarkerRightClickEvent;
            }
            if (MapMarkerClickEvent != null)
            {
                mapControl.MapMarkerClickEvent -= MapMarkerClickEvent;
                mapControl.MapMarkerClickEvent += MapMarkerClickEvent;
            }

            if (MapMarkerDoubleClickEvent != null)
            {
                mapControl.MapMarkerDoubleClickEvent -= MapMarkerDoubleClickEvent;
                mapControl.MapMarkerDoubleClickEvent += MapMarkerDoubleClickEvent;
            }
        }
        #region 百度地图事件
        public void BaiduOnlineMap_SelectedMapPointEvent(object sender, MapPointInfo mappointInfo)
        {
            SelectedMapPoint(mappointInfo);
        }
        #endregion
        public MapType mapType
        {
            get => CurrentMapType;
            set => CurrentMapType = value;
        }

        /// <summary>
        /// 双击地图方法 是否启用设置
        /// 默认启用
        /// </summary>
        /// <param name="bolSetValue"></param>
        public void SetEnableDoubleClickZoom(bool bolSetValue)
        {
            mapControl.SetEnableDoubleClickZoom(bolSetValue);
        }

        public void SelectedMapPoint(object sender, MapPointInfo mappointInfo)
        {
            SelectedMapPoint(mappointInfo);
        }

        /// <summary>
        /// 设置标注点跳动效果
        /// </summary>
        /// <param name="strMarkerID"></param>
        public void SetMarkerANIMATION_BOUNCE(string strMarkerID)
        {
            mapControl.SetMarkerANIMATION_BOUNCE(strMarkerID);
        }
        public bool SetCenterPoint(MapPointInfo point)
        {
            return mapControl.SetCenterPoint(point);
        }

        public bool SetMapLevel(MapPointInfo point)
        {
            return mapControl.SetMapLevel(point);
        }

        public bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath)
        {
            return mapControl.SetMapMarker(point, strMarkerPicFilePath);
        }

        public bool SetMapPointInfo(MapPointInfo point)
        {
            return mapControl.SetMapPointInfo(point);
        }

        public bool SetMapMarker(MapMarkerPointInfo marker)
        {
            return mapControl.SetMapMarker(marker);
        }

        public bool SetMapMarkerList(List<MapMarkerPointInfo> markers)
        {
            return mapControl.SetMapMarkerList(markers);
        }

        public bool ClearMapMarkerList()
        {
            return mapControl.ClearMapMarkerList();
        }

        public bool SetCircel(MapPointInfo point, int intSize)
        {
            return mapControl.SetCircel(point, intSize);
        }
    }
}
