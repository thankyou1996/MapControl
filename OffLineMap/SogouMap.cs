using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using ZYB.GIS;

namespace OffLineMap
{
    public class SogouMap
    {
        #region 全局变量
        private string strFilePathBin = "";
        private string strFilePathInfo = "";

        SogouMapInfo mapInfo;

        #endregion



        public SogouMap(string strFilePathBin,string strFilePathInfo)
        {
            this.strFilePathBin = strFilePathBin;
            this.strFilePathInfo = strFilePathInfo;
            mapInfo = new SogouMapInfo();
        }

        /// <summary>
        /// 获取指定点为中心的图片
        /// </summary>
        /// <param name="pointCenter">中心点经纬度</param>
        /// <param name="sizePicMain"></param>
        /// <param name="intMapLevel"></param>
        public Bitmap GetMapImage(PointD pointCenter_LonLat, Size sizePicMain, int intMapLevel)
        {
            if (sizePicMain.Width == 0 || sizePicMain.Height == 0)
            {
                return null;
            }
            //左下角经纬度
            PointD Temp_pointLeftBottom_Screen = new PointD(-sizePicMain.Width / 2, -sizePicMain.Height / 2);
            PointD Temp_pointLeftBottom_LonLat = mapInfo.ImageToWorld(Temp_pointLeftBottom_Screen, pointCenter_LonLat, intMapLevel);

            //右上角经纬度
            PointD Temp_pointRightTop_Screen = new PointD(sizePicMain.Width / 2, sizePicMain.Height / 2);
            PointD Temp_pointRightTop_LonLat = mapInfo.ImageToWorld(Temp_pointRightTop_Screen, pointCenter_LonLat, intMapLevel);
            BoundingBox box = new BoundingBox
                (   
                    //Temp_pointLeftBottom_LonLat.X, 
                    //Temp_pointLeftBottom_LonLat.Y,
                    //Temp_pointRightTop_LonLat.X,
                    //Temp_pointRightTop_LonLat.Y
                    Temp_pointLeftBottom_LonLat.X,
                    Temp_pointRightTop_LonLat.Y,
                    Temp_pointRightTop_LonLat.X,
                    Temp_pointLeftBottom_LonLat.Y
                );
            return GetMap(box, sizePicMain, intMapLevel);
        }


        public Bitmap GetMap(BoundingBox box, Size sizePicMain, int intMapLevel)
        {
            Bitmap bmpResult = new Bitmap(sizePicMain.Width, sizePicMain.Height);
            Graphics g = Graphics.FromImage(bmpResult);
            g.Clear(Color.White);
            #region 绘制图片
            ArrayList list = GetAllmapPieceInfo(box, intMapLevel);
            for (int i = 0; i < list.Count; i++)
            {
                MapPieceInfo mpi = list[i] as MapPieceInfo;

                byte[] file = Getpic(mpi.filename);
                if (file != null && file.Length > 0)
                {
                    Bitmap itemMap = new Bitmap(new MemoryStream(file));

                    g.DrawImage(itemMap, mpi.destRect, mpi.srcRect, GraphicsUnit.Pixel);
                }
            }
            #endregion

            g.Dispose();
            return bmpResult;    
        }

        /// <summary>
        /// 获取地图块拼接信息
        /// </summary>
        /// <param name="box"></param>
        /// <param name="size"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public ArrayList GetAllmapPieceInfo(BoundingBox box, int level)
        {
            ArrayList list = new ArrayList();

            PauseMapViewInfo PI = new PauseMapViewInfo(box, level);
            SogouMapInfo maptypeinfo = new SogouMapInfo();

            //计算第一个图片块的左上角所处图像位置
            PointD p = maptypeinfo.PixelToImage(PI.topPoint, new PointD(box.Min.X, box.Max.Y), level);

            #region 计算图片
            int Width = PI.maxColIndex - PI.minColIndex + 1;
            int Height = PI.maxRowIndex - PI.minRowIndex + 1;
            int centerX = (Width - 1) / 2;
            int centerY = (Height - 1) / 2;
            int intTest = 0;
            for (int rowIndex = PI.minRowIndex; rowIndex <= PI.maxRowIndex; rowIndex++)
            {
                for (int colIndex = PI.minColIndex; colIndex <= PI.maxColIndex; colIndex++)
                {
                    intTest++;
                    Rectangle destRect = new Rectangle((colIndex - PI.minColIndex) * maptypeinfo.tileSize + (int)Math.Round(p.X), (rowIndex - PI.minRowIndex) * maptypeinfo.tileSize + (int)Math.Round(p.Y), maptypeinfo.tileSize, maptypeinfo.tileSize);
                    string filename = ZYB.GIS.GoogleMapType.GetFileName(colIndex, rowIndex, level);
                    Rectangle srcRect = new Rectangle(0, 0, maptypeinfo.tileSize, maptypeinfo.tileSize);

                    MapPieceInfo mp = new MapPieceInfo();

                    int x = colIndex - PI.minColIndex;
                    int y = rowIndex - PI.minRowIndex;

                    mp.Priority = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY);
                    mp.filename = filename;
                    mp.destRect = destRect;
                    mp.srcRect = srcRect;

                    list.Add(mp);
                }
            }
            string ww = intTest.ToString();
            #endregion

            return RePrioritymapPiece(list);
        }

        /// <summary>
        /// 调整下载图片顺序,以中心向四周下载
        /// </summary>
        public ArrayList RePrioritymapPiece(ArrayList list)
        {
            if (list.Count < 2) return list;

            MapPieceInfo temp = null;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    MapPieceInfo m1 = list[i] as MapPieceInfo;
                    MapPieceInfo m2 = list[j] as MapPieceInfo;
                    if (m1.Priority > m2.Priority)
                    {
                        temp = m1;
                        m1 = m2;
                        m2 = temp;
                        list[i] = m1;
                        list[j] = m2;
                    }

                }
            }
            return list;

        }

        /// <summary>
        /// 从本地读取图片,如果本地没有则上网下载并保存到本地
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public byte[] Getpic(string file)
        {
            return GetPicFromBag(file);
        }

        /// <summary>
        /// 读取地图包
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private byte[] GetPicFromBag(string fileName)
        {
            byte[] bret = null;

            UndoBagClass Ub = new UndoBagClass(strFilePathBin, strFilePathInfo);
            Stream mapstream = Ub.UndoBagToStream(fileName + ".jpg");

            if (mapstream != null)
            {
                mapstream.Seek(0, SeekOrigin.Begin);
                bret = new byte[mapstream.Length];
                mapstream.Read(bret, 0, bret.Length);
            }
            Ub.Dispose();
            return bret;
        }

        public class SogouMapInfo
        {
            public const int Min_level = 1;
            public const int Max_level = 19;
            public const int TileSize = 256;

            public int tileSize { get { return TileSize; } }

            public readonly BoundingBox PixelMaxBox = new BoundingBox(-32768000, -32768000, 32768000, 32768000);
            public readonly IProjections projection = new SGProjections();

            /// <summary>
            /// 取得每单位平面坐标所对应图片像素
            /// </summary>
            private double zoomX(int levelGrade)
            {
                double cha = PixelMaxBox.Max.X - PixelMaxBox.Min.X;
                double zoomx = Math.Pow(2, levelGrade) * tileSize / cha;
                return zoomx;
            }

            /// <summary>
            /// 取得每单位平面坐标所对应图片像素
            /// </summary>
            private double zoomY(int levelGrade)
            {
                double cha = (PixelMaxBox.Max.Y - PixelMaxBox.Min.Y);
                double zoomy = Math.Pow(2, levelGrade) * tileSize / cha;
                return zoomy;
            }

            /// <summary>
            /// 平面坐标转屏幕坐标
            /// </summary>
            /// <param name="point">平面坐标</param>
            /// <param name="box">左上角经纬度</param>
            /// <returns>屏幕坐标</returns>
            public PointD PixelToImage(PointD point, PointD pointLeftTop, int levelGrade)
            {
                PointD ViewExtentMinPixel = projection.LatLngToPixel(pointLeftTop);

                double xx = (point.X - ViewExtentMinPixel.X) * zoomX(levelGrade);
                double yy = (ViewExtentMinPixel.Y - point.Y) * zoomY(levelGrade);

                return new PointD(xx, yy);
            }

            /// <summary>
            /// 屏幕坐标转平面坐标
            /// </summary>
            /// <param name="p">屏幕坐标</param>
            /// <param name="pointLeftTop">左上角经纬度</param>
            /// <param name="levelGrade"></param>
            /// <returns>平面坐标</returns>
            public PointD ImageToPixel(PointD p, PointD pointLeftTop, int levelGrade)
            {
                PointD ViewExtentMinPixel = projection.LatLngToPixel(pointLeftTop);
                double x = ViewExtentMinPixel.X + p.X / zoomX(levelGrade);
                double y = ViewExtentMinPixel.Y - p.Y / zoomY(levelGrade);
                return new PointD(x, y);
            }

            /// <summary>
            /// 从经纬度转换到屏幕坐标
            /// 经纬度-平面-屏幕
            /// </summary>
            /// <param name="point">经纬度</param>
            /// <param name="box">左上角经纬度</param>
            /// <returns>屏幕坐标</returns>
            public PointD WorldToImage(PointD point, PointD pointLeftTop, int levelGrade)
            {
                PointD p = projection.LatLngToPixel(point);
                return PixelToImage(p, pointLeftTop, levelGrade);
            }

            /// <summary>
            /// 从屏幕坐标转换到经纬度
            /// </summary>
            /// <param name="p">屏幕坐标</param>
            /// <param name="PointD">左上角经纬度</param>
            /// <returns>经纬度</returns>
            public PointD ImageToWorld(PointD p, PointD pointLeftTop, int levelGrade)
            {
                PointD point = ImageToPixel(p, pointLeftTop, levelGrade);
                return projection.PixelToLatLng(point);
            }


        }

        public class MapPieceInfo
        {
            /// <summary>
            /// 下载优先级,值小的优先下载
            /// 它等于与中心图片块的距离(方格距离)
            /// </summary>
            public int Priority;

            /// <summary>
            /// 由qrst构成的地图块文件
            /// </summary>
            public string filename;

            /// <summary>
            /// 目标矩形
            /// </summary>
            public Rectangle destRect;
            /// <summary>
            /// 本图片矩形
            /// </summary>
            public Rectangle srcRect;

        }

        /// <summary>
        /// 当前级别，显示经纬度得出图块范围，第一个图块的左上角平面坐标等。
        /// </summary>
        public class PauseMapViewInfo
        {
            /// <summary>
            /// //地图每行(列)的图片块数
            /// </summary>
            public int levelSize;
            public int nowColIndex;
            public int nowRowIndex;
            public int minColIndex;
            public int maxColIndex;
            public int minRowIndex;
            public int maxRowIndex;
            /// <summary>
            /// //第一个图块的左上角平面坐标
            /// </summary>
            public PointD topPoint;

            /// <summary>
            /// zyb081217 获取可见区域的地图块及相关信息
            /// </summary>
            /// <param name="pTop"></param>
            /// <param name="level"></param>
            /// <param name="width"></param>
            /// <param name="height"></param>
            public PauseMapViewInfo(BoundingBox box, int level)
            {
                SogouMapInfo maptypeinfo = new SogouMapInfo();

                levelSize = (int)Math.Pow(2, level);
                PointD maxPoint = maptypeinfo.projection.LatLngToPixel(box.Max);
                PointD minPoint = maptypeinfo.projection.LatLngToPixel(box.Min);

                minColIndex = (int)Math.Floor((minPoint.X - maptypeinfo.PixelMaxBox.Min.X) / (maptypeinfo.PixelMaxBox.Max.X - maptypeinfo.PixelMaxBox.Min.X) * (double)levelSize);
                maxColIndex = (int)Math.Floor((maxPoint.X - maptypeinfo.PixelMaxBox.Min.X) / (maptypeinfo.PixelMaxBox.Max.X - maptypeinfo.PixelMaxBox.Min.X) * (double)levelSize);

                minRowIndex = (int)Math.Floor((maptypeinfo.PixelMaxBox.Max.Y - maxPoint.Y) / (maptypeinfo.PixelMaxBox.Max.Y - maptypeinfo.PixelMaxBox.Min.Y) * (double)levelSize);
                maxRowIndex = (int)Math.Floor((maptypeinfo.PixelMaxBox.Max.Y - minPoint.Y) / (maptypeinfo.PixelMaxBox.Max.Y - maptypeinfo.PixelMaxBox.Min.Y) * (double)levelSize);

                if (minColIndex < 0) minColIndex = 0;
                if (minRowIndex < 0) minRowIndex = 0;
                if (maxColIndex >= levelSize) maxColIndex = levelSize - 1;
                if (maxRowIndex >= levelSize) maxRowIndex = levelSize - 1;

                float topX = ((float)minColIndex / (float)levelSize) * (float)(maptypeinfo.PixelMaxBox.Max.X - maptypeinfo.PixelMaxBox.Min.X) + (float)maptypeinfo.PixelMaxBox.Min.X;
                float topY = (float)maptypeinfo.PixelMaxBox.Max.Y - ((float)minRowIndex / (float)levelSize) * (float)(maptypeinfo.PixelMaxBox.Max.Y - maptypeinfo.PixelMaxBox.Min.Y);

                topPoint = new PointD(topX, topY);

                this.nowColIndex = minColIndex;
                this.nowRowIndex = minRowIndex;
            }

        }


        public PointD MoveMap(PointD PointCenter, Point pMove, int level)
        {
            return mapInfo.ImageToWorld(new PointD(pMove.X, pMove.Y), PointCenter, level);
        }


        /// <summary>
        /// 从经纬度转换到屏幕坐标
        /// </summary>
        /// <param name="pointCenter"></param>
        /// <param name="pointDisplayPoint"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public PointD WorldToImage(PointD pointCenter, PointD pointDisplayPoint, int level)
        {
            return mapInfo.WorldToImage(pointDisplayPoint, pointCenter, level);
        }
    }
}
