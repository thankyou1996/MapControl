using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MapControl
{
    [System.Runtime.InteropServices.ComVisible(true)]   //窗体与脚本交互设置
    public partial class GoogleOnlineMap : UserControl, IMapControl
    {
        /// <summary>
        /// 地图Html文件位置
        /// </summary>
        public string strMapFilePath = "";
        public GoogleOnlineMap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>       
        public void Init()
        {
            wbMain.Navigate(this.strMapFilePath);
            wbMain.ObjectForScripting = this;
        }

        /// <summary>
        /// 地图加载完成
        /// </summary>
        bool Maploaded = false;
        public MapType mapType
        {
            get => MapType.GoogleOnlineMap;
            set
            {
                ;
            }
        }

        private bool bolLoadEnd = false;
        public bool LoadEnd
        {
            get { return bolLoadEnd; }
        }

        /// <summary>
        /// JS脚本调用用于显示标注的经纬度 160728
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="level"></param>
        public void Setlnglat(string lng, string lat, string level)
        {
            MapPointInfo mappointInfo = new MapPointInfo();
            mappointInfo.dblLon = Convert.ToDouble(lng);
            mappointInfo.dblLat = Convert.ToDouble(lat);
            mappointInfo.intMapLevel = Convert.ToInt32(level);
            mappointInfo.cordinateSyatem = Enum_CordinateSystem.GCJ_02;
            SelectedMapPoint(mappointInfo);
        }

        /// <summary>
        /// 控件加载结束
        /// </summary>
        public event MapControlLoadEndDelegate MapControlLoadEndEvent;
        private void MapControlLoadEnd(object MapControlLoadEndValue)
        {
            bolLoadEnd = true;
            MapControlLoadEndEvent?.Invoke(this, MapControlLoadEndValue);
        }
        public event MapControlRightClick MapControlRightClickEvent;
        public bool MapControlRightClick(object MapControlRightClickValue)
        {
            bool bolResule = false;
            if (MapControlRightClickEvent != null)
            {
                bolResule = MapControlRightClickEvent(this, MapControlRightClickValue);
            }
            return bolResule;
        }
        public event MapMarkerClickDelegate MapMarkerClickEvent;
        private void MapMarkerClick(object MapMarkerClickValue)
        {
            RemoveMapSelectInfoMarker();
            if (MapMarkerClickEvent != null)
            {
                MapMarkerClickEvent(this, MapMarkerClickValue);
            }
        }
        public event MapMarkerClickDelegate MapMarkerRightClickEvent;
        private void MapMarkerRightClick(object MapMarkerClickValue)
        {
            RemoveMapSelectInfoMarker();
            if (MapMarkerRightClickEvent != null)
            {
                MapMarkerRightClickEvent(this, MapMarkerClickValue);
            }
        }
        public event MapMarkerClickDelegate MapMarkerDoubleClickEvent;
        private void MapMarkerDoubleClick(object MapMarkerClickValue)
        {
            if (MapMarkerDoubleClickEvent != null)
            {
                MapMarkerDoubleClickEvent(this, MapMarkerClickValue);
            }
        }
        public event SelectedMapPointDelegate SelectedMapPointEvent;

        private void SelectedMapPoint(MapPointInfo SelectedMapPointValue)
        {
            if (SelectedMapPointEvent != null)
            {
                SelectedMapPointEvent(this, SelectedMapPointValue);
            }
        }

        /// <summary>
        /// 移除地图选中信息标注点
        /// </summary>
        public void RemoveMapSelectInfoMarker()
        {
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("removeMapSelectInfoMarker");
                        }));
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
        }

        /// <summary>
        /// 清空地图标注列表
        /// </summary>
        /// <returns></returns>
        public bool ClearMapMarkerList()
        {
            bool bolResult = false;
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("clearMapMarkerList");
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }

        /// <summary>
        /// 设置地图中心点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetCenterPoint(MapPointInfo point)
        {
            point = point.ToGCJ_02();
            bool bolResult = false;
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("SetMapCenter", new object[] { point.dblLon, point.dblLat });
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }

        /// <summary>
        /// 延迟
        /// </summary>
        /// <param name="Millisecond"></param>
        private void Delay(int Millisecond)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        public void SetEnableDoubleClickZoom(bool bolSetValue)
        {
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("SetEnableDoubleClickZoom", new object[] { bolSetValue });
                        }));
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
        }

        /// <summary>
        /// 设置地图等级
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetMapLevel(MapPointInfo point)
        {
            point = point.ToGCJ_02();
            bool bolResult = false;
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("SetMapLevel", new object[] { point.intMapLevel });
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }

        /// <summary>
        ///  设置标注点信息
        /// </summary>
        /// <param name="point"></param>
        /// <param name="strMarkerPicFilePath"></param>
        /// <returns></returns>
        public bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath)
        {
            bool bolResult = false;
            point = point.ToGCJ_02();
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("DisplayMarker", new object[] { point.dblLon, point.dblLat, strMarkerPicFilePath });
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }

        /// <summary>
        /// 显示标注点信息
        /// </summary>
        /// <param name="marker"></param>
        /// <returns></returns>
        public bool SetMapMarker(MapMarkerPointInfo marker)
        {
            bool bolResult = false;
            marker.MarkerPoint = marker.MarkerPoint.ToGCJ_02();
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("DisplayMarker1", new object[] { marker.MarkerPoint.dblLon, marker.MarkerPoint.dblLat, marker.MarkerDisplayValue, marker.MarkerIconFilePath, marker.CallbackValue });
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }

        /// <summary>
        /// 显示标注列表
        /// </summary>
        /// <param name="markers"></param>
        /// <returns></returns>
        public bool SetMapMarkerList(List<MapMarkerPointInfo> markers)
        {
            foreach (MapMarkerPointInfo item in markers)
            {
                item.MarkerPoint = item.MarkerPoint.ToGCJ_02();
            }
            bool bolResult = false;
            string msg = Newtonsoft.Json.JsonConvert.SerializeObject(markers);
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("setMapMarkerList", new object[] { msg });
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }

        /// <summary>
        /// 设置地图中心点和等级
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetMapPointInfo(MapPointInfo point)
        {
            point = point.ToGCJ_02();
            ToHtml_SetCenter(point);
            ToHtml_SetMapLevel(point.intMapLevel);
            return true;
        }

        /// <summary>
        /// 设置标注动画
        /// </summary>
        /// <param name="strMarkerID"></param>
        public void SetMarkerANIMATION_BOUNCE(string strMarkerID)
        {
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("SetMarkerANIMATION_BOUNCE", new object[] { strMarkerID });
                        }));
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
        }

        /// <summary>
        /// 标注点点击事件
        /// </summary>
        /// <param name="objMarkerRightClickValue"></param>
        public void MarkerClick(object objMarkerRightClickValue)
        {
            MapMarkerClick(objMarkerRightClickValue);
        }

        /// <summary>
        /// 标注点右键事件
        /// </summary>
        /// <param name="sender"></param>
        public void MarkerRightClick(object objMarkerRightClickValue)
        {
            MapMarkerRightClick(objMarkerRightClickValue);

        }

        public void MarkerDoubleClick(object objMarkerRightClickValue)
        {
            MapMarkerDoubleClick(objMarkerRightClickValue);
        }

        /// <summary>
        /// 地图加载完成返回
        /// </summary>
        public void MapLoadEnd()
        {
            Maploaded = true;
            MapControlLoadEnd(null);
        }

        /// <summary>
        /// Html调用事件_地图等级显示改变
        /// </summary>
        /// <param name="srMapLevel"></param>
        public void FromHtml_MapZoomChanged(string srMapLevel)
        {
            //strlevel = srMapLevel;
        }
        public void MapControlRightClick()
        {
            MapControlRightClick(null);
        }


        /// <summary>
        /// Html页面事件_设置中心点 当前等级
        /// </summary>
        private void ToHtml_SetCenter(MapPointInfo point)
        {
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("SetMapCenter", new object[] { point.dblLon, point.dblLat });
                        }));
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
        }

        /// <summary>
        /// Html页面事件_设置地图等级
        /// </summary>
        /// <param name="MapLevel"></param>
        private void ToHtml_SetMapLevel(int MapLevel)
        {
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("SetMapLevel", new object[] { MapLevel });
                        }));
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
        }

        /// <summary>
        /// 设置圆形区域
        /// </summary>
        /// <param name="point"></param>
        /// <param name="color"></param>
        /// <param name="Transparent"></param>
        /// <param name="circlesize"></param>
        /// <returns></returns>
        public bool SetCircle(MapPointInfo point, string color, int Transparent, int circlesize)
        {
            bool bolResult = false;
            object[] para = new object[] { point.dblLon, point.dblLat, color, Transparent, circlesize, 1 };
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("Cleancircle");
                            wbMain.Document.InvokeScript("DispalayLocationArea", para);
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return false;
        }

        /// <summary>
        /// 清除圆形区域
        /// </summary>
        /// <returns></returns>
        public bool Cleancircle()
        {
            bool bolResult = false;
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("Cleancircle");
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }       
    }
}
