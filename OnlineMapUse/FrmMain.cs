using PublicClassCurrency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OnlineMapUse
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string strMapFilePath = Environment.CurrentDirectory + "\\OnlineMapFile\\BaiduOnlineMap\\Map_Basic.html";
            onlineMap1.Init(strMapFilePath);
            onlineMap1.SelectedMapPointEvent += SelectedMapPoint;
            onlineMap1.strMapIconPath= Environment.CurrentDirectory+ "\\OnlineMapFile\\ImageFile";
        }

        #region　地图控件事件
        public void SelectedMapPoint(object sender, MapPointInfo MapPointInfo)
        {
            MapPointInfo test = MapPointInfo.ToGCJ_02();
            txtSelectedMapPointType.Text = MapPointInfo.cordinateSyatem.ToString();
            txtSelectedMapPointLevel.Text = MapPointInfo.intMapLevel.ToString();
            txtSelectedMapPointLon.Text = MapPointInfo.dblLon.ToString();
            txtSelectedMapPointLat.Text = MapPointInfo.dblLat.ToString();
            txtSetMapInfo_MapLon.Text= MapPointInfo.dblLon.ToString();
            txtSetMapInfo_MapLat.Text = MapPointInfo.dblLat.ToString();
        }

        #endregion

        private void btnSetCenter_Click(object sender, EventArgs e)
        {
            MapPointInfo m = new MapPointInfo();
            m.dblLon = Convert.ToDouble(txtSetMapInfo_MapLon.Text);
            m.dblLat = Convert.ToDouble(txtSetMapInfo_MapLat.Text);
            onlineMap1.SetCenterPoint(m);
        }

        private void btnSetMapLevel_Click(object sender, EventArgs e)
        {
            int intLevel = Convert.ToInt32(txtSetMapInfo_MapLevel.Text);
            onlineMap1.DisplayMap_SetMapLevel(intLevel);
        }

        private void btnSetMarker_Click(object sender, EventArgs e)
        {
            MapPointInfo m = new MapPointInfo();
            m.dblLon = Convert.ToDouble(txtSetMapInfo_MapLon.Text);
            m.dblLat = Convert.ToDouble(txtSetMapInfo_MapLat.Text);
            string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
            onlineMap1.DisplayMap_SetMarker(m, strMapIconFilePath);
        }
    }
}
