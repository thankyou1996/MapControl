using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZYB.GIS;

namespace MapControl
{
    //[
    //    DefaultEvent("PageIndexChanged"),  //默认事件
    //    DefaultProperty("RecordCount"),    //默认属性
    //    Description("离线地图"),  //控件说明
    //    ToolboxBitmap(typeof(PagingControl), "Resources.Bitmap.pager") //设置控件图标
    //]
    public partial class SogouOfflineMap : UserControl, IMapControl
    {
        #region 全局变量
        SogouMap mapMain;

        /// <summary>
        /// 地图Bin文件
        /// </summary>
        public string strMapFileBin = "";
        /// <summary>
        /// 地图Info文件
        /// </summary>
        public string strMapFileInfo = "";
        /// <summary>
        /// 地图Ini文件
        /// </summary>
        public string strMapFileIni = "";

        public string strMapIconPath = "";

        int intPicValueKey = 1;
        Dictionary<object, PictureBox> dicPicValue = new Dictionary<object, PictureBox>();
        Dictionary<object, Label> dicLabel = new Dictionary<object, Label>();

        #region 地图文件基本信息
        /// <summary>
        /// 地图初始经度
        /// </summary>
        double dblMapInitLon;

        /// <summary>
        /// 地图初始纬度
        /// </summary>
        double dblMapInitLat;

        /// <summary>
        /// 地图初始等级
        /// </summary>
        int intMapInitLevel;

        /// <summary>
        /// 地图最小经度
        /// </summary>
        double dblMapMinLon;

        /// <summary>
        /// 地图最大经度
        /// </summary>
        double dblMapMaxLon;

        /// <summary>
        /// 地图最小纬度
        /// </summary>
        double dblMapMinLat;

        /// <summary>
        /// 地图最小纬度
        /// </summary>
        double dblMapMaxLat;

        /// <summary>
        /// 地图最大显示等级
        /// </summary>
        int intMapMaxLevel;

        /// <summary>
        /// 地图最小显示等级
        /// </summary>
        int intMapMinLevel;

        #endregion

        #region 地图实时信息

        /// <summary>
        /// 初始化状态
        /// </summary>
        bool bolInit = false;

        /// <summary>
        /// 地图当前中心点
        /// </summary>
        PointD pointCurrentMapCenter;

        /// <summary>
        /// 地图当前显示等级
        /// </summary>
        int intCurrentMapLevel;

        public int CurrentMapLevel
        {
            get { return intCurrentMapLevel; }
            set
            {
                if (value > intMapMaxLevel)
                {
                    //最大显示等级
                    intCurrentMapLevel = intMapMaxLevel;
                }
                else if (value < intMapMinLevel)
                {
                    //最小显示等级
                    intCurrentMapLevel = intMapMinLevel;
                }
                else
                {
                    //合理值
                    intCurrentMapLevel = value;
                }
            }
        }

        private MapPointInfo pointCurrentMouseMapPointt;

        public MapPointInfo CurrentMouseMapPoint
        {
            get { return pointCurrentMouseMapPointt; }
            set
            {
                pointCurrentMouseMapPointt = value;
            }
        }

        #endregion

        #region 地图拖动效果参数
        int intLastX;
        int intLastY;

        /// <summary>
        ///  鼠标按下状态（Down 事件下置为true Up事件下置为false）
        /// </summary>
        private bool bolIsMouseDown = false;

        /// <summary>
        /// 鼠标移动起始位置
        /// </summary>
        private Point pointMouseBeginMovePoint;

        /// <summary>
        /// 鼠标移动时显示的图片
        /// </summary>
        private Bitmap bmpMapImageBuff = null;
        #endregion

        #endregion

        #region
        Size sizePointImage = new System.Drawing.Size(16, 16);
        #endregion

        #region 事件委托

        #region 异常事件
        /// <summary>
        /// 离线地图异常事件委托
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="strExceptionTag"></param>
        public delegate void OfflineMap_ErrorEventHandler(Exception ex, string strExceptionTag = "");

        /// <summary>
        /// 离线地图异常事件
        /// </summary>
        public event OfflineMap_ErrorEventHandler OfflineMapError;

        /// <summary>
        /// 异常事件
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="strExceptionTag"></param>
        public void Error(Exception ex, string strExceptionTag = "")
        {
            if (OfflineMapError != null)
            {
                OfflineMapError(ex, strExceptionTag);
            }
        }

        #endregion

        #region 地图显示事件
        public delegate void OfflineMap_DisplayMapEventHandler(double dblLon, double dblLat, int intMapLevel, string strTag = "");
        public event OfflineMap_DisplayMapEventHandler OfflineMapDisplay;

        public void Display(double dblLon, double dblLat, int intMapLevel, string strTag = "")
        {
            if (OfflineMapDisplay != null)
            {
                OfflineMapDisplay(dblLon, dblLat, intMapLevel, strTag = "");
            }
        }

        #endregion

        #region 当前点移动
        public delegate void PointMove_EventHandler(MapPointInfo mapPoint);

        public event PointMove_EventHandler PointMove_Evnet;

        private void PointMove(MapPointInfo mapPoint)
        {
            if (PointMove_Evnet != null)
            {
                PointMove_Evnet(mapPoint);
            }
        }


        #endregion

        #region 地图选中事件
        public delegate void SelectedMapPointDelegate(object sender, MapPointInfo SelectedMapPointValue);

        public event SelectedMapPointDelegate SelectedMapPointEvent;
        public event MapControlLoadEndDelegate MapControlLoadEndDelegate;

        private void SelectedMapPoint(MapPointInfo SelectedMapPointValue)
        {
            if (SelectedMapPointEvent != null)
            {
                SelectedMapPointEvent(this, SelectedMapPointValue);
            }
        }
        #endregion

        public event MapControlLoadEndDelegate MapControlLoadEndEvent;
        public event MarkerRightClickDelegate MarkerRightClickEvent;
        public event MapControlRightClick MapControlRightClickEvent;

        private void MapControlLoadEnd(object MapControlLoadEndValue)
        {
            bolLoadEnd = true;
            if (MapControlLoadEndEvent != null)
            {
                MapControlLoadEndEvent(this, MapControlLoadEndValue);
            }
        }

        #region 

        #endregion


        #region 标注点点击事件

        public event MapMarkerClickDelegate MapMarkerClickEvent;

        private void MapMarkerClick(object MapMarkerClickValue)
        {
            if (MapMarkerClickEvent != null)
            {
                MapMarkerClickEvent(this, MapMarkerClickEvent);
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

        #region 标注点右击事件

        public event MapMarkerClickDelegate MapMarkerRightClickEvent;
        private void MapMarkerRightClick(object MapMarkerClickValue)
        {
            if (MapMarkerRightClickEvent != null)
            {
                MapMarkerRightClickEvent(this, MapMarkerClickEvent);
            }
        }
        #endregion
        #endregion


        private bool bolLoadEnd = false;
        int type;

        public bool LoadEnd
        {
            get { return bolLoadEnd; }
        }
        public SogouOfflineMap()
        {
            InitializeComponent();
        }

        public SogouOfflineMap(string strMapFilePath_Bin, string strMapFilePath_Info, string strMapFilePath_Ini)
        {
            InitializeComponent();
            strMapFileBin = strMapFilePath_Bin;
            strMapFileInfo = strMapFilePath_Info;
            strMapFileIni = strMapFilePath_Ini;
            mapMain = new SogouMap(strMapFilePath_Bin, strMapFilePath_Info);
            bolInit = true;
        }

        private void OfflineMap_Load(object sender, EventArgs e)
        {
            //Init_ReadMapInfo();
            //picMap.Image=mapMain.

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(string strMapFilePath_Bin, string strMapFilePath_Info, string strMapFilePath_Ini)
        {
            strMapFileBin = strMapFilePath_Bin;
            strMapFileInfo = strMapFilePath_Info;
            strMapFileIni = strMapFilePath_Ini;
            mapMain = new SogouMap(strMapFileBin, strMapFileInfo);
            Init_ReadMapInfo();
            DisplayMap();
            MapControlLoadEnd(null);
            bolInit = true;
        }

        /// <summary>
        /// 读取地图信息
        /// </summary>
        public void Init_ReadMapInfo()
        {
            try
            {
                #region 读取地图文件信息
                Ini.IniFile ini = new Ini.IniFile(strMapFileIni);
                dblMapInitLon = double.Parse(ini.IniReadValue("地图信息", "地图初始经度"));
                dblMapInitLat = double.Parse(ini.IniReadValue("地图信息", "地图初始纬度"));
                intMapInitLevel = int.Parse(ini.IniReadValue("地图信息", "地图初始显示级数"));
                dblMapMinLon = double.Parse(ini.IniReadValue("地图信息", "最小经度"));
                dblMapMaxLon = double.Parse(ini.IniReadValue("地图信息", "最大经度"));
                dblMapMinLat = double.Parse(ini.IniReadValue("地图信息", "最小纬度"));
                dblMapMaxLat = double.Parse(ini.IniReadValue("地图信息", "最大纬度"));
                intMapMinLevel = Int32.Parse(ini.IniReadValue("地图信息", "显示最小级数"));
                intMapMaxLevel = Int32.Parse(ini.IniReadValue("地图信息", "显示最大级数"));
                #endregion
                //地图中心点位置
                pointCurrentMapCenter = new PointD(dblMapInitLon, dblMapInitLat);
                //地图显示等级
                CurrentMapLevel = intMapInitLevel;
            }
            catch (Exception ex)
            {
                Error(ex, "Init_ReadMapInfo");
            }
        }


        #region 控件方法事件

        /// <summary>
        /// 尺寸改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMap_SizeChanged(object sender, EventArgs e)
        {
            if (bolInit)
            {
                DisplayMap();
            }
        }

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pointMouseBeginMovePoint = new Point(e.X, e.Y);
                bolIsMouseDown = true;
                bmpMapImageBuff = picMap.Image as Bitmap;
            }
        }

        /// <summary>
        /// 鼠标弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)     //左键移动地图
            {
                if (bolIsMouseDown)
                {
                    bolIsMouseDown = false;
                    int MoveX = e.X - pointMouseBeginMovePoint.X;
                    int MoveY = e.Y - pointMouseBeginMovePoint.Y;
                    if (MoveX != 0 && MoveY != 0)
                    {
                        //移动
                        MoveMap(-MoveX, -MoveY);
                        //picMap.Image = mapMain.GetMapImage(pointMapCenter, picMap.Size, intMapLevel);
                        DisplayMap();
                        if (x != 0 || y != 0)
                        {
                            x = x + MoveX;
                            y = y + MoveY;                           
                        }
                    }
                   
                }
            }
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMap_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (mapMain != null)
                {
                    if (e.Button == MouseButtons.Left && (e.X + e.Y) % 2 == 0)
                    {

                        //m.
                        //PointMove();

                        int MoveX = e.X - pointMouseBeginMovePoint.X;
                        int MoveY = e.Y - pointMouseBeginMovePoint.Y;
                        picMap.Image = MoveImage(bmpMapImageBuff, -MoveX, -MoveY);
                    }
                }
            }
            catch (Exception ex)
            {
                Error(ex, "picMap_MouseMove");
            }
        }

        #endregion

        #region 公用事件

        #region 地图显示
        /// <summary>
        /// 显示地图
        /// </summary>
        private void DisplayMap()
        {
            if (mapMain != null)
            {
                picMap.Image = mapMain.GetMapImage(pointCurrentMapCenter, picMap.Size, CurrentMapLevel);

                if (dicPicValue != null && dicPicValue.Count > 0)
                {
                    foreach (PictureBox pic in dicPicValue.Values)
                    {
                        if (pic != null && pic.Visible == true && pic.Parent == picMap)
                        {
                            MapPointInfo point = (MapPointInfo)pic.Tag;
                            PointD pointDisplatPos = new PointD(point.dblLon, point.dblLat);
                            PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                            pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - pic.Width / 2), Convert.ToInt32(picMap.Height / 2 + p.Y - pic.Height));
                        }
                    }
                }

                if (dicLabel != null && dicLabel.Count > 0)
                {
                    foreach (Label pic in dicLabel.Values)
                    {
                        if (pic != null && pic.Visible == true && pic.Parent == picMap)
                        {
                            MapPointInfo point = (MapPointInfo)pic.Tag;
                            PointD pointDisplatPos = new PointD(point.dblLon, point.dblLat);
                            PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                            pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - pic.Width / 2), Convert.ToInt32(picMap.Height / 2 + p.Y - pic.Height) + 32);
                        }
                    }
                }

                if (picsDisplayPointList != null && picsDisplayPointList.Length > 0)
                {
                    //存在显示点
                    foreach (PictureBox pic in picsDisplayPointList)
                    {
                        if (pic != null && pic.Visible == true && pic.Tag != null && pic.Parent == picMap)
                        {
                            PointD pointDisplatPos = (PointD)pic.Tag;
                            PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                            pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - 8), Convert.ToInt32(picMap.Height / 2 + p.Y - 8));
                        }
                    }
                }

                if (picsDisplayMulchList != null && picsDisplayMulchList.Length > 0)
                {
                    //存在显示区域
                    foreach (PictureBox pic in picsDisplayMulchList)
                    {
                        if (pic != null && pic.Visible == true && pic.Tag != null && pic.Parent == picMap)
                        {
                            //PointD pointDisplatPos = (PointD)pic.Tag;
                            //PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                            //pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - 8), Convert.ToInt32(picMap.Height / 2 + p.Y - 8));

                            PointAndLevel pl = (PointAndLevel)pic.Tag;
                            PointD pointDisplatPos = new PointD(pl.lon, pl.lat);
                            PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                            pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - 8), Convert.ToInt32(picMap.Height / 2 + p.Y - 8));
                            //整体思路 
                            //1.添加时设置显示等级，及默认大小
                            //2.在显示地图是判断当前等级及显示等级大小（比较）
                            //3.根据比较结果放大或者缩小图片
                            int intDisplayMapLevel = pl.intMapLevel;
                            //正数表示需要放大 0表示当前等级正常 负数表示需要缩小 以300px 为基准
                            Size sizeBasic = new Size(300, 300);

                            int intDisparity = intCurrentMapLevel - intDisplayMapLevel;
                            if (intDisparity > 0)
                            {
                                //放大
                                double Temp_dbl = Math.Pow(2, intDisparity);
                                sizeBasic = new Size(Convert.ToInt32(300 * Temp_dbl), Convert.ToInt32(300 * Temp_dbl));
                            }
                            else if (intDisparity < 0)
                            {
                                //缩小
                                intDisparity = Math.Abs(intDisparity);
                                double Temp_dbl = Math.Pow(2, intDisparity);
                                sizeBasic = new Size(Convert.ToInt32(300 / Temp_dbl), Convert.ToInt32(300 / Temp_dbl));
                            }
                            else if (intDisparity == 0)
                            {
                                //默认值 
                                pic.Size = sizeBasic;
                            }
                            pic.Size = sizeBasic;

                        }
                    }
                }

                Display(pointCurrentMapCenter.X, pointCurrentMapCenter.Y, intCurrentMapLevel, "");

            }
        }



        /// <summary>
        /// 显示地图
        /// </summary>
        /// <param name="pointDisplayMapCenter"></param>
        private void DisplayMap_SetCenter(PointD pointDisplayMapCenter)
        {
            if (mapMain != null)
            {
                pointCurrentMapCenter = pointDisplayMapCenter;
                DisplayMap();
            }
        }



        /// <summary>
        /// 显示地图
        /// </summary>
        /// <param name="pointDisplayMapCenter"></param>
        /// <param name="intDisplayMapLevel"></param>
        private void DisplayMap_SetCenterAndLevel(PointD pointDisplayMapCenter, int intDisplayMapLevel)
        {
            if (mapMain != null)
            {
                pointCurrentMapCenter = pointDisplayMapCenter;
                CurrentMapLevel = intDisplayMapLevel;
                DisplayMap();
            }
        }

        public void DisplayMap_SetCenterAndLevel(double dblLon, double dblLat, int intMapLevel)
        {
            if (mapMain != null)
            {
                LegalLonAndLat(ref dblLon, ref dblLat);
                pointCurrentMapCenter = new PointD(dblLon, dblLat);
                CurrentMapLevel = intMapLevel;
                DisplayMap();
            }
        }

        #endregion

        /// <summary>
        /// 移动地图 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        private void MoveMap(int X, int Y)
        {
            if (mapMain != null)
            {
                PointD p = mapMain.MoveMap(pointCurrentMapCenter, new Point(X, Y), CurrentMapLevel);
                SetCenter(p.X, p.Y);
            }
        }

        /// <summary>
        /// 设置中心点
        /// </summary>
        /// <param name="dblCenterLon"></param>
        /// <param name="dblCenterLat"></param>
        public void SetCenter(double dblCenterLon, double dblCenterLat)
        {
            LegalLonAndLat(ref dblCenterLon, ref dblCenterLat);
            if (dblCenterLon > -180 && dblCenterLon < 180 && dblCenterLat > -90 && dblCenterLat < 80)
            {
                pointCurrentMapCenter = new ZYB.GIS.PointD(dblCenterLon, dblCenterLat);
            }
        }

        public void LegalLonAndLat(ref double dblLon, ref double dblLat)
        {
            if (dblLon < dblMapMinLon) dblLon = dblMapMinLon;
            if (dblLon > dblMapMaxLon) dblLon = dblMapMaxLon;
            if (dblLat < dblMapMinLat) dblLat = dblMapMinLat;
            if (dblLat > dblMapMaxLat) dblLat = dblMapMaxLat;
        }

        /// <summary>
        /// 移动图片
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Bitmap MoveImage(Bitmap bmp, int x, int y)
        {
            try
            {
                if (bmp == null) return null;
                Bitmap bm = new Bitmap(bmp.Width, bmp.Height);
                Graphics g = Graphics.FromImage(bm);
                g.Clear(Color.White);

                Rectangle dest = new Rectangle(0, 0, bmp.Width, bmp.Width);
                Rectangle src = new Rectangle(x, y, bmp.Width, bmp.Width);
                g.DrawImage(bmp, dest, src, GraphicsUnit.Pixel);
                g.Dispose();
                return bm;
            }
            catch
            {
                //异常返回空
                return null;
            }
        }


        /// <summary>
        /// 放大
        /// </summary>
        public void ZoomIn()
        {
            if (SetLevel(CurrentMapLevel + 1))
            {
                //DisplayXY(int X, int Y)
                DisplayMap();
            }
        }

        /// <summary>
        /// 缩小
        /// </summary>
        public void ZoomOut()
        {
            if (SetLevel(CurrentMapLevel - 1))
            {
                DisplayMap();
            }
        }

        /// <summary>
        /// 设置地图显示等级
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool SetLevel(int level)
        {
            if (level < intMapMinLevel) level = intMapMinLevel;
            if (level > intMapMaxLevel) level = intMapMaxLevel;

            if (level >= 1 && level <= 19)
            {
                CurrentMapLevel = level;
                return true;
            }
            else return false;
        }

        #endregion

        #region  外部调用事件

        /// <summary>
        /// 显示地图_设置地图中心点
        /// </summary>
        /// <param name="pointDisplayMapCenter"></param>
        public void DisplayMap_SetCenter(MapPointInfo point)
        {
            if (mapMain != null)
            {
                LegalLonAndLat(ref point.dblLon, ref point.dblLat);
                pointCurrentMapCenter = new PointD(point.dblLon, point.dblLat);
                DisplayMap();
            }
        }

        /// <summary>
        /// 显示地图_设置地图等级
        /// </summary>
        /// <param name="pointDisplayMapCenter"></param>
        public void DisplayMap_SetMapLevel(int intDisplayMapLevel)
        {
            if (mapMain != null)
            {
                CurrentMapLevel = intDisplayMapLevel;
                DisplayMap();
            }
        }

        /// <summary>
        /// 设置标注点
        /// </summary>
        public void DisplayMap_SetMarker(MapPointInfo point, string strImageFileName)
        {
            //设置图片位置，将状态置为显示
            PointD pointDisplatPos = new PointD(point.dblLon, point.dblLat);
            PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
            PictureBox pic = new PictureBox();
            pic.Image = Image.FromFile(strMapIconPath + "\\" + strImageFileName);
            pic.Size = new Size(32, 32);
            pic.BackColor = Color.Transparent;
            pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - pic.Width / 2), Convert.ToInt32(picMap.Height / 2 + p.Y - pic.Height));
            pic.Tag = point;
            if (dicPicValue.ContainsKey(intPicValueKey))
            {
                dicPicValue[intPicValueKey].Dispose();
            }
            dicPicValue[intPicValueKey] = pic;
            intPicValueKey++;
            picMap.Controls.Add(pic);
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="intIndex">图片索引</param>
        /// <param name="dblLon">经度</param>
        /// <param name="dblLat">纬度</param>
        public void DisplayImage(int intIndex, double dblLon, double dblLat)
        {
            if (picsDisplayPointList != null)
            {
                //设置图片位置，将状态置为显示
                PointD pointDisplatPos = new PointD(dblLon, dblLat);
                PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                picsDisplayPointList[intIndex].Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - 8), Convert.ToInt32(picMap.Height / 2 + p.Y - 8));
                picsDisplayPointList[intIndex].Visible = true;
                picsDisplayPointList[intIndex].Tag = pointDisplatPos;
                //picMap.Controls.Add(picsDisplayPictureBoxList[intIndex]);
            }
        }

        /// <summary>
        /// 显示覆盖物
        /// </summary>
        /// <param name="intIndex">图片索引</param>
        /// <param name="dblLon">经度</param>
        /// <param name="dblLat">纬度</param>
        public void DisplayMulchImage(int intIndex, double dblLon, double dblLat)
        {
            if (picsDisplayMulchList != null)
            {
                PointD pointDisplatPos = new PointD(dblLon, dblLat);
                PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                picsDisplayMulchList[intIndex].Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - 8), Convert.ToInt32(picMap.Height / 2 + p.Y - 8));
                picsDisplayMulchList[intIndex].Visible = true;
                picsDisplayMulchList[intIndex].Tag = pointDisplatPos;
            }
        }

        /// <summary>
        /// 显示覆盖物信息
        /// </summary>
        /// <param name="intIndex">图片索引</param>
        /// <param name="dblLon">经度</param>
        /// <param name="dblLat">纬度</param>
        /// <param name="intMapLevel">地图显示等级</param>
        public void DisplayMulchImage(int intIndex, double dblLon, double dblLat, int intMapLevel)
        {
            if (picsDisplayMulchList != null)
            {
                PointD pointDisplatPos = new PointD(dblLon, dblLat);
                PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                picsDisplayMulchList[intIndex].Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - 8), Convert.ToInt32(picMap.Height / 2 + p.Y - 8));
                picsDisplayMulchList[intIndex].Visible = true;
                PointAndLevel pl = new PointAndLevel();
                pl.lon = dblLon;
                pl.lat = dblLat;
                pl.intMapLevel = intMapLevel;
                picsDisplayMulchList[intIndex].Tag = pl;
            }
        }

        public void TestSet(double dblLon, double dblLat)
        {
            if (picsDisplayPointList != null)
            {
                PointD pointDisplatPos = new PointD(dblLon, dblLat);
                PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                picsDisplayPointList[0].Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - 8), Convert.ToInt32(picMap.Height / 2 + p.Y - 8));
                picsDisplayPointList[0].Visible = true;
                picsDisplayPointList[0].Tag = pointDisplatPos;
                //picMap.Controls.Add(picsDisplayPictureBoxList[0]);
            }
        }
        #endregion
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                ZoomIn();
            }
            else
                if (e.Delta < 0)
            {
                ZoomOut();
            }

            base.OnMouseWheel(e);
        }


        #region 自定义属性

        public PictureBox[] picsDisplayMulchList;
        [Description("覆盖物列表"), Category("自定义属性")]
        public PictureBox[] DisplayMulchList
        {
            get { return picsDisplayMulchList; }
            set
            {
                picsDisplayMulchList = value;
                if (picsDisplayMulchList != null)
                {
                    foreach (PictureBox pic in picsDisplayMulchList)
                    {
                        pic.Visible = false;
                        picMap.Controls.Add(pic);
                    }
                }
            }
        }

        public PictureBox[] picsDisplayPointList;
        [Description("标注点列表"), Category("自定义属性")]
        public PictureBox[] DisplayPointList
        {
            get { return picsDisplayPointList; }
            set
            {
                picsDisplayPointList = value;
                if (picsDisplayPointList != null)
                {
                    foreach (PictureBox pic in picsDisplayPointList)
                    {
                        pic.Visible = false;
                        picMap.Controls.Add(pic);
                    }
                }
            }
        }




        #endregion
        public class PointAndLevel
        {
            public double lon;
            public double lat;
            public int intMapLevel;
        }

        public MapType mapType
        {
            get => MapType.SogouOffLineMap;
            set
            {
                ;
            }
        }

        private void picMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //左键点击
                intLastX = e.X; intLastY = e.Y;
                int intCurX = intLastX - this.picMap.Width / 2;
                int intCurY = intLastY - this.picMap.Height / 2;
                pictureBox1.Location = new Point { X = e.X - (pictureBox1.Size.Width / 2), Y = e.Y - pictureBox1.Size.Height };
                pictureBox1.Visible = true;
                PointD p = mapMain.MoveMap(pointCurrentMapCenter, new Point(intCurX, intCurY), intCurrentMapLevel);
                MapPointInfo m = new MapPointInfo();
                m.dblLon = p.X;
                m.dblLat = p.Y;
                m.intMapLevel = intCurrentMapLevel;
                m.cordinateSyatem = Enum_CordinateSystem.WGS_84;
                SelectedMapPoint(m);
                picMap.Refresh();
            }
        }

        #region 接口事件

        /// <summary>
        /// 双击地图方法 是否启用设置
        /// 默认启用
        /// </summary>
        /// <param name="bolSetValue"></param>
        public void SetEnableDoubleClickZoom(bool bolSetValue)
        {
            return;
        }

        public bool SetCenterPoint(MapPointInfo point)
        {
            point = point.ToWGS_84();
            bool bolResult = false;
            if (mapMain != null)
            {
                LegalLonAndLat(ref point.dblLon, ref point.dblLat);
                pointCurrentMapCenter = new PointD(point.dblLon, point.dblLat);
                DisplayMap();
                bolResult = true;
            }
            return bolResult;
        }

        /// <summary>
        /// 设置标注点跳动效果
        /// </summary>
        /// <param name="strMarkerID"></param>
        public void SetMarkerANIMATION_BOUNCE(string strMarkerID)
        {

        }
        public bool SetMapLevel(MapPointInfo point)
        {
            bool bolResult = false;
            point = point.ToWGS_84();
            if (mapMain != null)
            {
                CurrentMapLevel = point.intMapLevel;
                DisplayMap();
                bolResult = true;
            }
            return bolResult;
        }
        public bool SetMapPointInfo(MapPointInfo point)
        {
            bool bolResult = false;
            point = point.ToWGS_84();
            if (mapMain != null)
            {
                CurrentMapLevel = point.intMapLevel;
                LegalLonAndLat(ref point.dblLon, ref point.dblLat);
                pointCurrentMapCenter = new PointD(point.dblLon, point.dblLat);
                DisplayMap();
                bolResult = true;
            }
            return bolResult;
        }

        public bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath)
        {
            bool bolResult = false;
            point = point.ToWGS_84();
            if (mapMain != null)
            {
                if (File.Exists(strMarkerPicFilePath))
                {
                    //设置图片位置，将状态置为显示
                    PointD pointDisplatPos = new PointD(point.dblLon, point.dblLat);
                    PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile(strMarkerPicFilePath);
                    pic.Size = new Size(32, 32);
                    pic.BackColor = Color.Transparent;
                    pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - pic.Width / 2), Convert.ToInt32(picMap.Height / 2 + p.Y - pic.Height));
                    pic.Tag = point;
                    if (dicPicValue.ContainsKey(intPicValueKey))
                    {
                        dicPicValue[intPicValueKey].Dispose();
                    }
                    dicPicValue[intPicValueKey] = pic;
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(152, 65);
                    label.Name = "lbl" + intPicValueKey;
                    label.Size = new System.Drawing.Size(41, 12);
                    label.TabIndex = 1;
                    label.Tag = point;
                    label.Text = "label1";
                    intPicValueKey++;
                    picMap.Controls.Add(pic);
                    bolResult = true;
                }
            }
            return bolResult;
        }

        public bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath, string strDisplay)
        {
            bool bolResult = false;
            point = point.ToWGS_84();
            if (mapMain != null)
            {
                if (File.Exists(strMarkerPicFilePath))
                {
                    //设置图片位置，将状态置为显示
                    PointD pointDisplatPos = new PointD(point.dblLon, point.dblLat);
                    PointD p = mapMain.WorldToImage(pointCurrentMapCenter, pointDisplatPos, CurrentMapLevel);  //计算点在地图上的位置
                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile(strMarkerPicFilePath);
                    pic.Size = new Size(32, 32);
                    pic.BackColor = Color.Transparent;
                    pic.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - pic.Width / 2), Convert.ToInt32(picMap.Height / 2 + p.Y - pic.Height));
                    pic.Tag = point;
                    if (dicPicValue.ContainsKey(intPicValueKey))
                    {
                        dicPicValue[intPicValueKey].Dispose();
                    }
                    dicPicValue[intPicValueKey] = pic;
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Location = new Point(Convert.ToInt32(picMap.Width / 2 + p.X - pic.Width / 2), Convert.ToInt32(picMap.Height / 2 + p.Y - pic.Height) + 32);
                    label.Name = "lbl" + intPicValueKey;
                    label.Size = new System.Drawing.Size(41, 12);
                    label.TabIndex = 1;
                    label.Text = strDisplay;
                    label.Tag = point;
                    label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    if (dicLabel.ContainsKey(intPicValueKey))
                    {
                        dicLabel[intPicValueKey].Dispose();
                    }
                    dicLabel[intPicValueKey] = label;

                    intPicValueKey++;
                    picMap.Controls.Add(pic);
                    picMap.Controls.Add(label);
                    bolResult = true;
                }
            }
            return bolResult;
        }

        public bool SetMapMarker(MapMarkerPointInfo marker)
        {
            //SetMapMarker(marker.MarkerPoint, marker.MarkerIconFilePath, marker.MarkerDisplayValue);
            SetMapMarker(marker.MarkerPoint, marker.MarkerIconFilePath, marker.MarkerDisplayValue);
            //bool 
            //throw new NotImplementedException();
            return false;
        }

        public bool SetMapMarkerList(List<MapMarkerPointInfo> markers)
        {
            foreach (MapMarkerPointInfo item in markers)
            {
                item.MarkerPoint = item.MarkerPoint.ToWGS_84();
                SetMapMarker(item.MarkerPoint, item.MarkerIconFilePath, item.MarkerDisplayTag.ToString());
            }
            bool bolResult = false;
            return bolResult;
        }

        /// <summary>
        /// 清除地图所有点信息
        /// </summary>
        /// <returns></returns>
        public bool ClearMapMarkerList()
        {
            foreach (PictureBox pic in dicPicValue.Values)
            {
                picMap.Controls.Remove(pic);
                pic.Dispose();
            }
            dicPicValue.Clear();
            foreach (Label lbl in dicLabel.Values)
            {
                picMap.Controls.Remove(lbl);
                lbl.Dispose();
            }
            dicLabel.Clear();
            return false;
        }
        #endregion
        /// <summary>
        ///标记点的平面坐标 x、y
        /// </summary>
        private float x;
        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        private float y;
        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        double dblSize = 100.0;
        Color returnColor;

        public bool SetCircel(MapPointInfo point, int intSize,string color)
        {
            double _dGPSX = point.dblLon;
            double _dGPSY = point.dblLat;
            var size = Circelsizi();
            PointD pointGPS1 = new PointD(_dGPSX, _dGPSY);
            PointD p1 = mapMain.WorldToImage(pointCurrentMapCenter, pointGPS1, CurrentMapLevel);
            Graphics g = picMap.CreateGraphics();
            x = Convert.ToInt32(this.picMap.Width / 2 + p1.X) - size;
            y = Convert.ToInt32(this.picMap.Height / 2 + p1.Y) - size;
            intSize = 2 * size;
            returnColor = ColorTranslator.FromHtml(color);
            g.FillEllipse(new SolidBrush(Color.FromArgb(125,returnColor)), x, y, intSize, intSize);
            return false;
            //throw new NotImplementedException();
        }

        private void PicMap_Paint(object sender, PaintEventArgs e)
        {
            if (x==0||y==0)
            {
                return;
            }
           else 
            { 
                if (x != 0 || y != 0)
                {
                    Graphics g = picMap.CreateGraphics();
                    var size = Circelsizi();
                    int siziCircel = 2 * size;
                    g.FillEllipse(new SolidBrush(Color.FromArgb(125, returnColor)), x, y, siziCircel, siziCircel);
                }
            }          
        }

        public int Circelsizi()
        {
            int intScale100M = 0;
            switch (CurrentMapLevel)
            {
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    intScale100M = 1;
                    break;
                case 11:
                    intScale100M = Convert.ToInt32(dblSize / 5000 * MillimetersToPixelsWidth(13));
                    break;
                case 12:
                    intScale100M = Convert.ToInt32(dblSize / 2000 * MillimetersToPixelsWidth(10));
                    break;
                case 13:
                    intScale100M = Convert.ToInt32(dblSize / 1000 * MillimetersToPixelsWidth(10));
                    break;
                case 14:
                    intScale100M = Convert.ToInt32(dblSize / 800 * MillimetersToPixelsWidth(16));
                    break;
                case 15:
                    intScale100M = Convert.ToInt32(dblSize / 400 * MillimetersToPixelsWidth(16));
                    break;
                case 16:
                    intScale100M = Convert.ToInt32(dblSize / 200 * MillimetersToPixelsWidth(16));
                    break;
                case 17:
                    intScale100M = Convert.ToInt32(dblSize / 90 * MillimetersToPixelsWidth(15));
                    break;
                case 18:
                    intScale100M = Convert.ToInt32(dblSize / 50 * MillimetersToPixelsWidth(16));
                    break;
                case 19:
                    intScale100M = Convert.ToInt32(dblSize / 25 * MillimetersToPixelsWidth(16));
                    break;
            }
            return intScale100M;
        }

        public static double MillimetersToPixelsWidth(double length) //length是毫米，1厘米=10毫米
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 4);     // HORZRES 
            int pixels = GetDeviceCaps(hdc, 8);     // BITSPIXEL
            g.ReleaseHdc(hdc);
            return (((double)pixels / (double)width) * (double)length);
        }
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);

        public bool Cleancircle()
        {
            x = 0;
            y = 0;
            picMap.Refresh();
            return false;
            //throw new NotImplementedException();
        }            
    }
}
