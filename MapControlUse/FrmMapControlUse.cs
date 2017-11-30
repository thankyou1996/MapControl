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
            Init();
            Test();
            mapControl1.Init();
        }

        public void Init()
        {
            //cmbMapType.Items.Add("BaiduOnLineMap");
            //cmbMapType.Items.Add("SogouOffLineMap");
            mapControl1.MapDisplayEvent += MapDisplay;


        }
        public void Test()
        {
            mapControl1.g_strBaiduOnlieMapFilePath = Environment.CurrentDirectory + "\\OnlineMapFile\\Map_Basic.html";
            mapControl1.g_strSougouOffLineMapFileBin = mapControl1.g_strSougouOffLineMapFileFolderPath+ "//Map.bin";
            mapControl1.g_strSougouOffLineMapFileInfo = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.info";
            mapControl1.g_strSougouOffLineMapFileIni = mapControl1.g_strSougouOffLineMapFileFolderPath + "//Map.ini";
        }




        public void MapDisplay(MapControl.MapType mtType, double dblLon, double dblLat, int intMapLevel, string strTag = "")
        {
            txtMapType.Text = mtType.ToString();
            txtMapCenterLon.Text = dblLon.ToString();
            txtMapCenterLat.Text = dblLat.ToString();
            txtMapCurrentMapLevl.Text = intMapLevel.ToString();
        }



        private void btnSogouOfflineMap_Click(object sender, EventArgs e)
        {
            mapControl1.CurrentMapType = MapControl.MapType.SogouOffLineMap;
            mapControl1.Init();
        }

        private void btnBaiduOnlineMap_Click(object sender, EventArgs e)
        {
            mapControl1.CurrentMapType = MapControl.MapType.BaiduOnlineMap;
            mapControl1.Init();
        }
    }
}
