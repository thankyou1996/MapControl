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
        public string g_strSougouOffLineMapFileBin
        {
            get { return ""; }
            set
            {
                string x = "";
                sogouOfflineMap1.strMapFileBin = value;
                ;
            }
        }

        /// <summary>
        /// 地图Info文件
        /// </summary>
        public string g_strSougouOffLineMapFileInfo 
         {
            get { return ""; }
        set
            {
                string x = "";
                sogouOfflineMap1.strMapFileInfo= value;
                ;
            }
           
        }

        /// <summary>
        /// 地图Ini文件
        /// </summary>
        public string g_strSougouOffLineMapFileIni 
        {
            get { return ""; }
            set
            {
                string x = "";
                sogouOfflineMap1.strMapFileIni= value;
                ;
            }           
        }
        
        public string g_strBaiduOnlieMapFilePath
        {
            get { return ""; }
            set
            {
                string x = "";
                baiduOnlineMap1.strMapFilePath = value;
                ;
            }           
        }

        public string g_strGoogleMapFilePath 
        {
            get { return ""; }
        set
            {
                string x = "";
                googleOnlineMap1.strMapFilePath = value;
                ;
            }           
        }
        
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
                    mapControl.Init();
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
                    baiduOnlineMap1.Init();
                    break;
                case MapType.SogouOffLineMap:
                    sogouOfflineMap1.Init();
                    break;
                case MapType.GoogleOnlineMap:
                    googleOnlineMap1.Init();
                    break;
            }
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

        /// <summary>
        /// 设置地图中心点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetCenterPoint(MapPointInfo point)
        {
            return mapControl.SetCenterPoint(point);
        }

        /// <summary>
        /// 设置地图等级
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetMapLevel(MapPointInfo point)
        {
            return mapControl.SetMapLevel(point);
        }


        /// <summary>
        /// 设置标注点信息
        /// </summary>
        /// <param name="point"></param>
        /// <param name="strMarkerPicFilePath"></param>
        /// <returns></returns>
        public bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath)
        {
            return mapControl.SetMapMarker(point, strMarkerPicFilePath);
        }

        public bool SetMapPointInfo(MapPointInfo point)
        {
            return mapControl.SetMapPointInfo(point);
        }

        /// <summary>
        /// 显示标注点信息
        /// </summary>
        /// <param name="marker"></param>
        /// <returns></returns>
        public bool SetMapMarker(MapMarkerPointInfo marker)
        {
            return mapControl.SetMapMarker(marker);
        }

        /// <summary>
        /// 显示标注d
        /// </summary>
        /// <param name="markers"></param>
        /// <returns></returns>
        public bool SetMapMarkerList(List<MapMarkerPointInfo> markers)
        {
            return mapControl.SetMapMarkerList(markers);
        }

        /// <summary>
        /// 清除地图点信息
        /// </summary>
        /// <returns></returns>
        public bool ClearMapMarkerList()
        {
            return mapControl.ClearMapMarkerList();
        }

        /// <summary>
        /// 设置圆形区域
        /// </summary>
        /// <param name="point"></param>
        /// <param name="color"></param>
        /// <param name="Transparent"></param>
        /// <param name="circlesize"></param>
        /// <returns></returns>
        public bool SetCircle(MapPointInfo point,string color, int Transparent,int circlesize)
        {
            return mapControl.SetCircle(point, color, Transparent, circlesize);
        }

        /// <summary>
        /// 清除圆形区域
        /// </summary>
        /// <returns></returns>
        public bool Cleancircle()
        {
            return mapControl.Cleancircle();
        }        
    }
}
