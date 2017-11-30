using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MapControl
{
    public partial class MapControl : UserControl
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
        /// 地图Infow文件
        /// </summary>
        public string g_strSougouOffLineMapFileInfo = "";
        /// <summary>
        /// 地图Ini文件
        /// </summary>
        public string g_strSougouOffLineMapFileIni = "";


        public string g_strBaiduOnlieMapFilePath = "";
        #endregion

        #region 回调与事件
        //public void MapControlDispInfo()
        //    }
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
                            baiduOnlineMap1.Dock = DockStyle.Fill;
                            break;

                        case MapType.SogouOffLineMap:
                            baiduOnlineMap1.Visible = false;
                            sogouOfflineMap1.Visible = true;
                            sogouOfflineMap1.Dock = DockStyle.Fill;
                            break;
                    }
                    currentMapType = value;
                }

            }
        }

        #endregion
        
       
        

        private void MapControl_Load(object sender, EventArgs e)
        {
            sogouOfflineMap1.OfflineMapDisplay += SogouMapDisplay;
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
                    Init_BaiduOnlineMap();
                    break;
                case MapType.SogouOffLineMap:
                    Init_SogouMapOfflineMap();
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
    }
    public enum MapType
    {
        BaiduOnlineMap = 0,
        SogouOffLineMap = 1
    }
}
