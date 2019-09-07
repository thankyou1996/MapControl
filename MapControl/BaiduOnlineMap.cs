using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MapControl
{
    [System.Runtime.InteropServices.ComVisible(true)]   //窗体与脚本交互设置
    public partial class BaiduOnlineMap : UserControl, IMapControl
    {

        /// <summary>
        /// 地图Html文件位置
        /// </summary>
        string strMapFilePath = "";

        /// <summary>
        /// 地图文件Icon位置
        /// </summary>
        public string strMapIconPath = "\\OnlineMapFile\\ImageFile";

        //List<MapMarkerPointInfo> lMarker = new List<MapMarkerPointInfo>();

        #region 地图实时信息

        /// <summary>
        /// 初始化状态
        /// </summary>
        bool bolInit = false;

        /// <summary>
        /// 地图加载完成
        /// </summary>
        bool Maploaded = false;

        /// <summary>
        /// 地图当前中心点
        /// </summary>
        Point pointCurrentMapCenter;

        /// <summary>
        /// 地图当前显示等级
        /// </summary>
        int intCurrentMapLevel;

        public int CurrentMapLevel
        {
            get { return intCurrentMapLevel; }
            set { intCurrentMapLevel = value; }
        }


        #endregion
        public BaiduOnlineMap()
        {
            InitializeComponent();
        }

        private bool bolLoadEnd = false;

        public bool LoadEnd
        {
            get { return bolLoadEnd; }
        }

        #region 百度图接口
        /// <summary>
        /// 地址信息
        /// </summary>
        public class AddressInfo
        {
            /// <summary>
            /// 经度
            /// </summary>
            public double lng { get; set; }
            /// <summary>
            /// 纬度
            /// </summary>Setlnglat
            public double lat { get; set; }
            /// <summary>
            /// 用户名称或地点信息
            /// </summary>
            public string userName { get; set; }
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

        #region  页面调用后台事件

        /// <summary>
        /// 地图输出日志
        /// </summary>
        /// <param name="strLog"></param>
        public void MapConsoleLog(string strLog)
        {
            StringBuilder sbConsoleInfo = new StringBuilder();
            sbConsoleInfo.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "_");
            sbConsoleInfo.Append(strLog);
            Console.WriteLine(sbConsoleInfo.ToString());
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
        /// 地图加载异常
        /// </summary>
        public void MapLoadException()
        {

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
            mappointInfo.cordinateSyatem = Enum_CordinateSystem.BD_09;
            SelectedMapPoint(mappointInfo);
        }



        public void MapLaodError()
        {
            //bolOnlineMapLoad = false;
        }



        public void FormHtml_DisplayPrompt(string strPrompt)
        {
            //ConsoleWriteInfo(strPrompt);
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
        #endregion

        #region 后台调用页面事件

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
        /// Html页面事件_显示标注点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="strIconFilePath"></param>
        private void ToHtml_DisplayMarker(MapPointInfo point, string strIconFilePath)
        {
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("DisplayMarker", new object[] { point.dblLon, point.dblLat, strIconFilePath });
                        }));
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
        }

        /// <summary>
        /// Html页面事件_显示主机位置信息
        /// </summary>
        /// <param name="dblDBLon"></param>
        /// <param name="dblDBLat"></param>
        /// <param name="strUserName"></param>
        /// <param name="bolIsAlarm"></param>
        /// <param name="intMapLevel"></param>
        /// <param name="dispaly"></param>
        public void ToHtml_DiplayMarker(double dblDBLon, double dblDBLat, string strUserName, bool bolIsAlarm, int intMapLevel = 18, int intAreaSize = 0, int intRegionType = 1)
        {
            MapAddMarker(dblDBLon, dblDBLat, strUserName, bolIsAlarm, intMapLevel);
            DisplayLinkNameInfos();
            if (intAreaSize > 0)
            {
                ToHtml_DispalayLocationArea(dblDBLon, dblDBLat, intAreaSize, intRegionType);
            }
        }

        /// <summary>
        /// 地图上显示SOS标注
        /// </summary>
        /// <param name="dblBDLon"></param>
        /// <param name="dblBDLat"></param>
        public void ToHtml_DiplaySOSMarker(double dblBDLon, double dblBDLat, string strDisplayInfo)
        {
            //MapAddMarker(dblBDLon, dblBDLat, "123", true, 12);
            object[] obj = new object[5];
            obj[0] = dblBDLon;
            obj[1] = dblBDLat;
            obj[2] = strDisplayInfo;
            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && bolOnlineMapLoad)    //170228 添加地图是加载完成判断
            //    {
            //        webBrowser1.Document.InvokeScript("MapAddMarker_SOS", obj);
            //        return;
            //    }
            //    Delay(50);
            //}
        }

        /// <summary>
        /// 在地图上添加标注
        /// </summary>
        /// <param name="lng">经度</param>
        /// <param name="lat">纬度</param>
        /// <param name="username">用户名称或地点信息</param>
        /// <param name="isalarm">是否报警</param>
        /// <param name="maplevel">地图等级</param>
        public void MapAddMarker(double lng, double lat, string username, bool isalarm, int maplevel = 18)
        {
            //object[] obj = new object[5];
            //strlat = lat.ToString();
            //strlng = lng.ToString();
            //obj[0] = lng;
            //obj[1] = lat;
            //obj[2] = username;
            //obj[3] = isalarm.ToString();
            //obj[4] = maplevel;
            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && bolOnlineMapLoad)    //170228 添加地图是加载完成判断
            //    {
            //        //BeginInvoke(new EventHandler(delegate
            //        //{
            //        webBrowser1.Document.InvokeScript("MapAddMarker", obj);
            //        //}));
            //        return;
            //    }
            //    Delay(50);
            //}
        }



        /// <summary>
        /// Html页面事件_显示定位区域
        /// </summary>
        /// <param name="dblDBLon"></param>
        /// <param name="dblDBLat"></param>
        /// <param name="intAreaSize"></param>
        /// <param name="intRegionType"></param>
        public void ToHtml_DispalayLocationArea(double dblDBLon, double dblDBLat, int intAreaSize, int intRegionType = 1)
        {

            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && bolOnlineMapLoad)    //170228 添加地图是加载完成判断
            //    {
            //        webBrowser1.Document.InvokeScript("DispalayLocationArea", new object[] { dblDBLon, dblDBLat, intAreaSize, intRegionType });
            //        return;
            //    }
            //    Delay(50);
            //}
        }

        /// <summary>
        /// 在地图上多点展示
        /// </summary>
        /// <param name="addrList"></param>
        public void MapMostMarker(List<AddressInfo> addrList)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append("[");
            //foreach (var item in addrList)
            //{
            //    sb.Append("{\"lng\":\"" + item.lng + "\",");
            //    sb.Append("\"lat\":\"" + item.lat + "\",");
            //    sb.Append("\"info\":\"" + item.userName + "\"},");
            //}
            //sb.Length = sb.Length - 1;
            //sb.Append("]");
            //while (true)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //    {
            //        BeginInvoke(new EventHandler(delegate
            //        {
            //            webBrowser1.Document.InvokeScript("MapMostMarker", new object[] { sb.ToString() });
            //        }));
            //        return;
            //    }
            //    Delay(50);
            //}
        }

        /// <summary>
        /// 定位所在城市
        /// </summary>
        public void ToHtml_MapLocalCity()
        {

            //while (bolOnlineMapLoad && isOnlineMap)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //    {
            //        BeginInvoke(new EventHandler(delegate
            //        {

            //            webBrowser1.Document.InvokeScript("SelectCity");
            //        }));
            //        return;
            //    }
            //    Delay(50);
            //}

        }


        /// <summary>
        /// Html页面事件_设置双击放大是否启用
        /// </summary>
        /// <param name="bolSetValue"></param>
        public void ToHtml_SetDoubleClickZoom(bool bolSetValue = false)
        {
            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && bolOnlineMapLoad)
            //    {
            //        //BeginInvoke(new EventHandler(delegate
            //        //{
            //        webBrowser1.Document.InvokeScript("SetDoubleClickZoom", new object[] { bolSetValue });
            //        //}));
            //        return;
            //    }
            //    Delay(50);
            //}
        }

        /// <summary>
        /// Html页面事件_清除警务处信息
        /// </summary>
        public void ToHtml_ClearPoliceRoom()
        {
            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //    {
            //        BeginInvoke(new EventHandler(delegate
            //        {
            //            webBrowser1.Document.InvokeScript("ClearPoliceRoom");
            //        }));
            //        return;
            //    }
            //    Common.Delay_Millisecond(50);
            //}
        }

        /// <summary>
        /// 显示相关联点信息
        /// </summary>
        public void DisplayLinkNameInfos()
        {
            ////if (PubParameter.SystemSetting.LinkNameEnable == 1)
            //{
            //    //启用关联点显示
            //    ToHtml_ClearPoliceRoom();
            //    DataTable dtResult = 数据库操作.DB_Table.DB_Rela_HostInfo_LinkNameInfo_Method.GetHostRelaLinkInfo(_strMacNO);
            //    if (dtResult != null && dtResult.Rows.Count > 0)
            //    {
            //        StringBuilder sbLinkNameInfo = new StringBuilder();
            //        sbLinkNameInfo.Append("[");
            //        foreach (DataRow dr in dtResult.Rows)
            //        {
            //            double dblGPSLon = Convert.ToDouble(dr[数据库操作.DB_Table.DB_LinkNameInfo_Method.c_strFieldName_LinkName_Lon]);
            //            double dblGPSLat = Convert.ToDouble(dr[数据库操作.DB_Table.DB_LinkNameInfo_Method.c_strFieldName_LinkName_Lat]);
            //            if (dblGPSLon == 0 && dblGPSLat == 0)
            //            {
            //                //坐标为00 跳过
            //                continue;
            //            }
            //            double dblBDLon;
            //            double dblBDLat;
            //            GPSCoordinateConvert.WGSToBD_encrypt(dblGPSLon, dblGPSLat, out dblBDLon, out dblBDLat);
            //            sbLinkNameInfo.Append("{");

            //            sbLinkNameInfo.Append("'lng':'" + dblBDLon + "',");
            //            sbLinkNameInfo.Append("'lat':'" + dblBDLat + "',");

            //            StringBuilder sbDisplayInfo = new StringBuilder();
            //            sbDisplayInfo.Append("名    称:" + Convert.ToString(dr[数据库操作.DB_Table.DB_LinkNameInfo_Method.c_strFieldName_LinkName_Name]) + "</br>");
            //            sbDisplayInfo.Append("固定电话:" + Convert.ToString(dr[数据库操作.DB_Table.DB_LinkNameInfo_Method.c_strFieldName_LinkName_Phone]) + "</br>");
            //            sbDisplayInfo.Append("联 系 人:" + Convert.ToString(dr[数据库操作.DB_Table.DB_LinkNameInfo_Method.c_strFieldName_LinkName_Contacts]) + "</br>");
            //            sbDisplayInfo.Append("联系方式:" + Convert.ToString(dr[数据库操作.DB_Table.DB_LinkNameInfo_Method.c_strFieldName_LinkName_ContactsNum]) + "</br>");
            //            sbLinkNameInfo.Append("'info':'" + sbDisplayInfo.ToString() + "',");
            //            sbLinkNameInfo.Append("'icon':'2'");
            //            sbLinkNameInfo.Append("}");
            //            sbLinkNameInfo.Append(",");
            //        }
            //        sbLinkNameInfo.Length = sbLinkNameInfo.Length - 1;
            //        if (sbLinkNameInfo.Length > 0)
            //        {
            //            //存在数据
            //            sbLinkNameInfo.Append("]");
            //            ToHtml_DisplayLinkNameInfos(sbLinkNameInfo.ToString());
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Html页面事件_显示关联点位置(移除旧关关联点)
        /// </summary>
        /// <param name="strJsonInfo"></param>
        public void ToHtml_DisplayLinkNameInfos(string strJsonInfo)
        {
            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //    {
            //        BeginInvoke(new EventHandler(delegate
            //        {
            //            webBrowser1.Document.InvokeScript("AddPoliceRooms", new object[] { strJsonInfo });
            //        }));
            //        return;
            //    }
            //    Common.Delay_Millisecond(50);
            //}
        }


        /// <summary>
        /// Html页面事件_添加显示关联点位置
        /// </summary>
        /// <param name="dblBDLon"></param>
        /// <param name="dblBDLat"></param>
        /// <param name="strDisplayInfo"></param>
        /// <param name="intDisplayIndex"></param>
        public void ToHtml_AddLinkNameInfo(double dblBDLon, double dblBDLat, string strDisplayInfo, int intDisplayIndex)
        {
            //string strLinkNameInfo = GetLinkNameJson(dblBDLon, dblBDLat, strDisplayInfo, intDisplayIndex);
            //string strJsonInfo = "[" + strLinkNameInfo + "]";
            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //    {
            //        BeginInvoke(new EventHandler(delegate
            //        {
            //            webBrowser1.Document.InvokeScript("AddPoliceRoom", new object[] { strJsonInfo });
            //        }));
            //        return;
            //    }
            //    Common.Delay_Millisecond(50);
            //}
        }

        public string GetLinkNameJson(double dblBDLon, double dblBDLat, string strDisplayInfo, int intDisplayIndex)
        {
            StringBuilder sbLinkNameInfo = new StringBuilder();
            sbLinkNameInfo.Append("{");
            sbLinkNameInfo.Append("'lng':'" + dblBDLon + "',");
            sbLinkNameInfo.Append("'lat':'" + dblBDLat + "',");
            sbLinkNameInfo.Append("'info':'" + strDisplayInfo + "',");
            sbLinkNameInfo.Append("'icon':'" + intDisplayIndex + "'");
            sbLinkNameInfo.Append("}");
            return sbLinkNameInfo.ToString();
        }

        /// <summary>
        /// Html页面事件_移除标注点（根据经度纬度）
        /// </summary>
        /// <param name="dblLon"></param>
        /// <param name="dbllat"></param>
        public void ToHtml_RemoveAddr(double dblLon, double dbllat)
        {
            //while (bolOnlineMapLoad)
            //{
            //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            //    {
            //        //BeginInvoke(new EventHandler(delegate
            //        //{
            //        webBrowser1.Document.InvokeScript("RemoveAddr", new object[] { dblLon, dbllat });
            //        //}));
            //        return;
            //    }
            //    Common.Delay_Millisecond(50);
            //}
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
        #endregion


        #endregion

        #region 委托及事件

        #region 地图加载完成事件
        public event MapControlLoadEndDelegate MapControlLoadEndEvent;

        private void MapControlLoadEnd(object MapControlLoadEndValue)
        {
            bolLoadEnd = true;
            if (MapControlLoadEndEvent != null)
            {
                MapControlLoadEndEvent(this, MapControlLoadEndValue);
            }
        }
        #endregion

        #region 地图选中事件



        public event SelectedMapPointDelegate SelectedMapPointEvent;

        private void SelectedMapPoint(MapPointInfo SelectedMapPointValue)
        {
            if (SelectedMapPointEvent != null)
            {
                SelectedMapPointEvent(this, SelectedMapPointValue);
            }
        }



        #endregion

        #region 地图控件右键事件
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

        #endregion


        #region 标注点点击事件

        public event MapMarkerClickDelegate MapMarkerClickEvent;

        private void MapMarkerClick(object MapMarkerClickValue)
        {
            RemoveMapSelectInfoMarker();
            if (MapMarkerClickEvent != null)
            {
                MapMarkerClickEvent(this, MapMarkerClickValue);
            }
        }

        #endregion


        #region 标注点右击事件

        public event MapMarkerClickDelegate MapMarkerRightClickEvent;
        private void MapMarkerRightClick(object MapMarkerClickValue)
        {
            RemoveMapSelectInfoMarker();
            if (MapMarkerRightClickEvent != null)
            {
                MapMarkerRightClickEvent(this, MapMarkerClickValue);
            }
        }
        #endregion

        #region 标注点双击事件
        public event MapMarkerClickDelegate MapMarkerDoubleClickEvent;

        private void MapMarkerDoubleClick(object MapMarkerClickValue)
        {
            if (MapMarkerDoubleClickEvent != null)
            {
                MapMarkerDoubleClickEvent(this, MapMarkerClickValue);
            }
        }

        #endregion

        #endregion

        private void OnlineMap_Load(object sender, EventArgs e)
        {

        }

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(string strMapFilePath)
        {
            this.strMapFilePath = strMapFilePath;
            wbMain.Navigate(this.strMapFilePath);
            wbMain.ObjectForScripting = this;
        }

        #endregion

        #region 外部调用事件
        /// 设置地图中心点
        /// </summary>
        /// <param name="dblLon"></param>
        /// <param name="dblLat"></param>
        public void DisplayMap_SetCenter(MapPointInfo point)
        {
            ToHtml_SetCenter(point);
        }

        /// <summary>
        /// 设置地图等级
        /// </summary>
        /// <param name="intMapLevel"></param>
        public void DisplayMap_SetMapLevel(int intMapLevel)
        {
            ToHtml_SetMapLevel(intMapLevel);
        }

        /// <summary>
        /// 设置标注点
        /// </summary>
        public void DisplayMap_SetMarker(MapPointInfo point, string strImageFileName)
        {
            ToHtml_DisplayMarker(point, strMapIconPath + "\\" + strImageFileName);

        }
        #endregion


        public MapType mapType
        {
            get => MapType.BaiduOnlineMap;
            set
            {
                ;
            }
        }

        /// <summary>
        /// 双击地图方法 是否启用设置
        /// 默认启用
        /// </summary>
        /// <param name="bolSetValue"></param>
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

        public bool SetCenterPoint(MapPointInfo point)
        {
            point = point.ToBD_09();
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
        /// 设置标注点跳动效果
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
        public bool SetMapLevel(MapPointInfo point)
        {
            point = point.ToBD_09();
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

        public bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath)
        {
            bool bolResult = false;
            point = point.ToBD_09();
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

        public bool SetMapPointInfo(MapPointInfo point)
        {
            point = point.ToBD_09();
            ToHtml_SetCenter(point);
            ToHtml_SetMapLevel(point.intMapLevel);
            return true;
        }

        public bool SetMapMarker(MapMarkerPointInfo marker)
        {
            bool bolResult = false;
            marker.MarkerPoint = marker.MarkerPoint.ToBD_09();
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


        public bool SetMapMarkerList(List<MapMarkerPointInfo> markers)
        {
            foreach (MapMarkerPointInfo item in markers)
            {
                item.MarkerPoint = item.MarkerPoint.ToBD_09();
            }

            bool bolResult = false;
            string msg= Newtonsoft.Json.JsonConvert.SerializeObject(markers);
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
        /// 地图点信息
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
        int type;
        public bool SetCircel(MapPointInfo point, int intSize,string color, int Transparent, int circlesize)
        {
            bool bolResult = false;
            object[] para = new object[] { point.dblLon, point.dblLat, circlesize, 1};   
            if (Maploaded)
            {
                while (!this.IsDisposed)
                {
                    if (wbMain.ReadyState == WebBrowserReadyState.Complete)
                    {
                        BeginInvoke(new EventHandler(delegate
                        {
                            wbMain.Document.InvokeScript("DispalayLocationArea", para);
                        }));
                        bolResult = true;
                        break;
                    }
                    Delay(50);  //系统延迟50毫秒
                }
            }
            return bolResult;
        }

        public bool Cleancircle()
        {
            Init(strMapFilePath); 
            return false;
            //throw new NotImplementedException();
        }       
    }
}
