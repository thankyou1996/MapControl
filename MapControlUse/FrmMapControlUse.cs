using PublicClassCurrency;
using PublicClassCurrency.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Init();
            Test();
            mapControl1.Init();
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

        }
        public void Test()
        {
            mapControl1.g_strBaiduOnlieMapFilePath = Environment.CurrentDirectory + "\\MapFile\\OnlineMapFile\\BaiduOnlineMap\\Map_Basic.html";
            mapControl1.g_strSougouOffLineMapFileBin = mapControl1.g_strSougouOffLineMapFileFolderPath+ "//Map.bin";
            mapControl1.g_strSougouOffLineMapFileInfo = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.info";
            mapControl1.g_strSougouOffLineMapFileIni = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.ini";
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
        public void SelectedMapPoint(object sender,MapPointInfo MapPointInfo)
        {
            txtSelectedMapPointType.Text = MapPointInfo.cordinateSyatem.ToString();
            txtSelectedMapPointLevel.Text = MapPointInfo.intMapLevel.ToString();
            txtSelectedMapPointLon.Text= MapPointInfo.dblLon.ToString();
            txtSelectedMapPointLat.Text = MapPointInfo.dblLat.ToString();
        }

        #endregion

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
            mapControl1.g_strSougouOffLineMapFileBin = @"G:\上班汇总\Working\维护项目\SK3000_Client\SK3000CU\Trunk\接警客户端\bin\Release\VectorMap\湖南岳阳.bin";
            mapControl1.g_strSougouOffLineMapFileInfo = @"G:\上班汇总\Working\维护项目\SK3000_Client\SK3000CU\Trunk\接警客户端\bin\Release\VectorMap\湖南岳阳.info";
            mapControl1.g_strSougouOffLineMapFileIni = @"G:\上班汇总\Working\维护项目\SK3000_Client\SK3000CU\Trunk\接警客户端\bin\Release\VectorMap\湖南岳阳.ini";
            mapControl1.CurrentMapType = MapType.SogouOffLineMap;
            mapControl1.Init();
        }
    }
}
