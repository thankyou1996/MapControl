using MapControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MapControlUse
{
    public partial class FrmMapControlUse : Form
    {
        public FrmMapControlUse()
        {
            InitializeComponent();
        }

        private void FrmMapControlUse_Load(object sender, EventArgs e)
        {

            mapControl1.MapControlLoadEndEvent += MapControl1_MapControlLoadEndEvent;
            mapControl1.MapControlRightClickEvent += MapControl1_MapControlRightClickEvent;
            mapControl1.MapMarkerClickEvent += MapControl1_MapMarkerClickEvent;
            mapControl1.MapMarkerRightClickEvent += MapControl1_MapMarkerRightClickEvent;
            mapControl1.MapMarkerDoubleClickEvent += MapControl1_MapMarkerDoubleClickEvent;
            Init();
            Test();

            mapControl1.Init();
        }

        private bool MapControl1_MapMarkerDoubleClickEvent(object sender, object MapMarkerClickValue)
        {
            Console.WriteLine("Double Click:" + MapMarkerClickValue);
            return true;
        }

        private bool MapControl1_MapMarkerRightClickEvent(object sender, object MapMarkerClickValue)
        {
            Console.WriteLine("Right Click:" + MapMarkerClickValue);
            return true;
            //throw new NotImplementedException();
        }

        private bool MapControl1_MapMarkerClickEvent(object sender, object MapMarkerClickValue)
        {
            Console.WriteLine("Click:" + MapMarkerClickValue);
            return true;
        }

        private bool MapControl1_MapControlRightClickEvent(object sender, object MapControlRightClickValue)
        {
            Console.WriteLine("MapControlRightClick:");
            bool bolResult = false;
            //Point p = this.PointToClient(Control.MousePosition);
            //contextMenuStrip1.Show(this, p);
            return bolResult;
        }

        private void MapControl1_MapControlLoadEndEvent(object sender, object MapControlLoadEndValue)
        {
            IMapControl mapControl = (IMapControl)sender;
            Console.WriteLine(mapControl.mapType.ToString() + "_LoadEnd");
        }

        public void Init()
        {
            //cmbMapType.Items.Add("BaiduOnLineMap");
            //cmbMapType.Items.Add("SogouOffLineMap");
            mapControl1.MapDisplayEvent += MapDisplay;
            mapControl1.SelectedMapPointEvent += SelectedMapPoint;

            DataTable dt = new DataTable();
            dt.Columns.Add("Value");
            dt.Columns.Add("Dsiplay");
            DataRow dr = dt.NewRow();
            dr["Value"] = "Red";
            dt.Rows.Add(dr);
            cmbcolor.ValueMember = "Value";
            cmbcolor.DataSource = dt;
        }

        public void Test()
        {
            mapControl1.g_strBaiduOnlieMapFilePath = Environment.CurrentDirectory + "\\OnlineMapFile\\BaiduOnlineMap\\Map_Basic.html";
            //mapControl1.g_strBaiduOnlieMapFilePath = @"G:\Working\Maintenance\SK3000\CU\Branch\SK3000CU_SK9301\CUCode\接警客户端\bin\Release\MapFile\OnlineMapFile\BaiduOnlineMap\Map_Basic.html";
            //mapControl1.g_strBaiduOnlieMapFilePath = @"G:\Working\Maintenance\SK3000\CU\CU_Html\html\map\baidu\map_basic.html";
            mapControl1.g_strSougouOffLineMapFileBin = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.bin";
            mapControl1.g_strSougouOffLineMapFileInfo = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.info";
            mapControl1.g_strSougouOffLineMapFileIni = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.ini";

            mapControl1.g_strGoogleMapFilePath = Environment.CurrentDirectory + "\\OnlineMapFile\\GoogleOnlineMap\\Map_Basic.html";
        }




        public void MapDisplay(MapType mtType, double dblLon, double dblLat, int intMapLevel, string strTag = "")
        {
            txtMapType.Text = mtType.ToString();
            txtMapCenterLon.Text = dblLon.ToString();
            txtMapCenterLat.Text = dblLat.ToString();
            txtMapCurrentMapLevl.Text = intMapLevel.ToString();
        }





        private void btnBaiduOnlineMap_Click(object sender, EventArgs e)
        {
            mapControl1.CurrentMapType = MapType.BaiduOnlineMap;
            mapControl1.Init();
        }

        #region　地图控件事件
        public void SelectedMapPoint(object sender, MapPointInfo MapPointInfo)
        {
            txtSelectedMapPointType.Text = MapPointInfo.cordinateSyatem.ToString();
            txtSelectedMapPointLevel.Text = MapPointInfo.intMapLevel.ToString();
            txtSelectedMapPointLon.Text = MapPointInfo.dblLon.ToString();
            txtSelectedMapPointLat.Text = MapPointInfo.dblLat.ToString();
        }

        #endregion


        private void btntxtSetMapPoint_Click(object sender, EventArgs e)
        {
            MapPointInfo m = new MapPointInfo();
            try
            {
                m.dblLon = Convert.ToDouble(txtSetMapPointLon.Text);
                m.dblLat = Convert.ToDouble(txtSetMapPointLat.Text);
                string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
                mapControl1.SetCenterPoint(m);
            }
            catch
            {
                //取值异常不做处理
            }
        }

        private void btntxtSetMapLevel_Click(object sender, EventArgs e)
        {
            MapPointInfo m = new MapPointInfo();
            try
            {
                m.dblLon = Convert.ToDouble(txtSetMapPointLon.Text);
                m.dblLat = Convert.ToDouble(txtSetMapPointLat.Text);
                m.intMapLevel = Convert.ToInt32(txtSetMapLevel.Text);
                string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
                mapControl1.SetMapLevel(m);
            }
            catch
            {
                //取值异常不做处理
            }
        }

        private void btntxtSetMapPointInfo_Click(object sender, EventArgs e)
        {
            MapPointInfo m = new MapPointInfo();
            try
            {
                m.dblLon = Convert.ToDouble(txtSetMapPointLon.Text);
                m.dblLat = Convert.ToDouble(txtSetMapPointLat.Text);
                m.intMapLevel = Convert.ToInt32(txtSetMapLevel.Text);
                string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
                mapControl1.SetMapPointInfo(m);
            }
            catch
            {
                //取值异常不做处理
            }
        }

        private void btnSogouOfflineMap2_Click(object sender, EventArgs e)
        {
            mapControl1.g_strSougouOffLineMapFileBin = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.bin";
            mapControl1.g_strSougouOffLineMapFileInfo = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.info";
            mapControl1.g_strSougouOffLineMapFileIni = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.ini";
            mapControl1.CurrentMapType = MapType.SogouOffLineMap;
            mapControl1.Init();
        }
        private void btnSogouOfflineMap_Click(object sender, EventArgs e)
        {
            mapControl1.g_strSougouOffLineMapFileBin = Environment.CurrentDirectory + "\\MapFile\\Map.bin";
            mapControl1.g_strSougouOffLineMapFileInfo = Environment.CurrentDirectory + "\\MapFile\\Map.info";
            mapControl1.g_strSougouOffLineMapFileIni = Environment.CurrentDirectory + "\\MapFile\\Map.ini";
            mapControl1.CurrentMapType = MapType.SogouOffLineMap;
            mapControl1.Init();
        }
        private void btnSetMarker_Click(object sender, EventArgs e)
        {
            MapPointInfo m = new MapPointInfo();
            try
            {
                m.dblLon = Convert.ToDouble(txtSelectedMapPointLon.Text);
                m.dblLat = Convert.ToDouble(txtSelectedMapPointLat.Text);
                string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
                mapControl1.SetMapMarker(m, Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath);
            }
            catch
            {
                //取值异常不做处理
            }
        }

        private void btnSetMarker2_Click(object sender, EventArgs e)
        {
            try
            {
                string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
                MapMarkerPointInfo m = new MapMarkerPointInfo
                {
                    MarkerName = DateTime.Now.Second.ToString(),
                    MarkerPoint = new MapPointInfo
                    {
                        dblLon = Convert.ToDouble(txtSelectedMapPointLon.Text),
                        dblLat = Convert.ToDouble(txtSelectedMapPointLat.Text)
                    },
                    MarkerDisplayValue = DateTime.Now.ToString(),
                    MarkerDisplayTag = "123",
                    MarkerIconFilePath = Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath,
                };
                m.MarkerRightClickEvent += MarkerRightClick;
                mapControl1.SetMapMarker(m);
            }
            catch (Exception ex)
            {
                string x = ex.ToString();
                //取值异常不做处理
            }

        }

        public bool MarkerRightClick(object sender, object MarkerRightClickValue)
        {
            bool bolResult = false;
            MapMarkerPointInfo m = (MapMarkerPointInfo)sender;
            StringBuilder sbDisplayInfo = new StringBuilder();
            sbDisplayInfo.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sbDisplayInfo.Append("_" + m.MarkerName);
            sbDisplayInfo.Append("_RightClick");
            Console.WriteLine(sbDisplayInfo.ToString());

            //1.获取鼠标位置
            //2.显示鼠标右键列表
            //int x = Control.MousePosition.X;
            //int y = Control.MousePosition.Y;
            Point p = this.PointToClient(Control.MousePosition);
            //int xx = this.mouser;
            //int yy = Control.MousePosition.Y;

            contextMenuStrip1.Show(this, p);
            return bolResult;
        }

        private void pnlLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("右键点击1");
        }

        private void 右键点击1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("右键点击2");
        }

        private void 右键点击3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("右键点击3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<MapMarkerPointInfo> lst = new List<MapMarkerPointInfo>();
            string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
            lst.Add(new MapMarkerPointInfo
            {
                MarkerName = "设备11111111111111",
                MarkerPoint = new MapPointInfo
                {
                    dblLon = 118.663395460268,
                    dblLat = 24.8702832694795
                },
                MarkerDisplayValue = DateTime.Now.ToString(),
                MarkerDisplayTag = "设备11111111111111",
                MarkerIconFilePath = Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath,
                CallbackValue = "0001",
            });

            lst.Add(new MapMarkerPointInfo
            {
                MarkerName = "设备222222222222222222222",
                MarkerPoint = new MapPointInfo
                {
                    dblLon = 118.95936869691,
                    dblLat = 24.8848535906569
                },
                MarkerDisplayValue = DateTime.Now.ToString(),
                MarkerDisplayTag = "设备222222222222222222222",
                MarkerIconFilePath = Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath,
                CallbackValue = "0002",
            });
            lst.Add(new MapMarkerPointInfo
            {
                MarkerName = "设备33333333333333333",
                MarkerPoint = new MapPointInfo
                {
                    dblLon = 118.58986311357,
                    dblLat = 24.7949416109346
                },
                MarkerDisplayValue = DateTime.Now.ToString(),
                MarkerDisplayTag = "设备33333333333333333",
                MarkerIconFilePath = Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath,
                CallbackValue = "0003",
            });
            lst.Add(new MapMarkerPointInfo
            {
                MarkerName = "设备4444444444444444",
                MarkerPoint = new MapPointInfo
                {
                    dblLon = 118.500474917019,
                    dblLat = 24.8983688406796
                },
                MarkerDisplayValue = DateTime.Now.ToString(),
                MarkerDisplayTag = "设备4444444444444444",
                MarkerIconFilePath = Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath,
                CallbackValue = "0004",
            });
            lst.Add(new MapMarkerPointInfo
            {
                MarkerName = "设备5555555555555555555",
                MarkerPoint = new MapPointInfo
                {
                    dblLon = 118.596130844151,
                    dblLat = 24.8653438696144
                },
                MarkerDisplayTag = "设备5555555555555555555",
                MarkerIconFilePath = Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath,
                CallbackValue = "0005",
            });

            lst.Add(new MapMarkerPointInfo
            {
                MarkerName = "设备6",
                MarkerPoint = new MapPointInfo
                {
                    dblLon = 106.432934,
                    dblLat = 26.755622
                },
                MarkerDisplayTag = "设备5",
                MarkerIconFilePath = Environment.CurrentDirectory + "\\MapFile\\MarkerFile\\" + strMapIconFilePath,
                CallbackValue = "0006",
            });
            mapControl1.SetMapMarkerList(lst);
        }

        private void btnDoubleClickZoon_True_Click(object sender, EventArgs e)
        {
            mapControl1.SetEnableDoubleClickZoom(true);
        }

        private void btnDoubleClickZoon_False_Click(object sender, EventArgs e)
        {
            mapControl1.SetEnableDoubleClickZoom(false);
        }

        private void btnSetMarkerANIMATION_BOUNCE_Click(object sender, EventArgs e)
        {
            string strId = textBox1.Text;
            mapControl1.SetMarkerANIMATION_BOUNCE(strId);
        }

        private void btnClearMarkerList_Click(object sender, EventArgs e)
        {
            mapControl1.ClearMapMarkerList();
        }

        private void BtnGoogleOnlineMap_Click(object sender, EventArgs e)
        {
            mapControl1.CurrentMapType = MapType.GoogleOnlineMap;
            mapControl1.Init();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MapPointInfo m = new MapPointInfo();
            m.dblLon = Convert.ToDouble(txtSetMapPointLon.Text);
            m.dblLat = Convert.ToDouble(txtSetMapPointLat.Text);
            string color =cmbcolor.Text;
            mapControl1.SetCircel(m, 5000, color);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            mapControl1.Cleancircle();
        }       
    }
}
