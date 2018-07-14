using PublicClassCurrency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OffLineMapUse
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 地图文件 文件夹地址
        /// </summary>
        public string g_MapFileFolderPath = Application.StartupPath + "//MapFile";
        /// <summary>
        /// 地图Bin文件
        /// </summary>
        public string g_strMapFileBin = "";
        /// <summary>
        /// 地图Infow文件
        /// </summary>
        public string g_strMapFileInfo = "";
        /// <summary>
        /// 地图Ini文件
        /// </summary>
        public string g_strMapFileIni = "";
        public FrmMain()
        {
            InitializeComponent();
            g_strMapFileBin = g_MapFileFolderPath + "//Map.bin";
            g_strMapFileInfo = g_MapFileFolderPath + "//Map.info";
            g_strMapFileIni = g_MapFileFolderPath + "//Map.ini";
            //offlineMap1.strMapFileBin = g_strMapFileBin;
            //offlineMap1.strMapFileInfo = g_strMapFileInfo;
            //offlineMap1.strMapFileIni = g_strMapFileIni;

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            offlineMap1.SelectedMapPointEvent += SelectedMapPoint;
            offlineMap1.OfflineMapDisplay += OfflineMapDisplay;
            pictureBox2.Parent = pictureBox3;
            Init();
            cmbPicMulchIndex.SelectedIndex = 0;
        }


        public void Init()
        {
            for (int i = 1; i < 30; i++)
            {
                cmbPicPointIndex.Items.Add((i));
                cmbPicMulchIndex.Items.Add(i);
            }
            for (int i = 1; i <= 19; i++)
            {
                cmbMapLevel.Items.Add(i);
            }
            offlineMap1.Init(g_strMapFileBin, g_strMapFileInfo, g_strMapFileIni);
            offlineMap1.strMapIconPath= Environment.CurrentDirectory + "\\OnlineMapFile\\ImageFile";
        }

        public void OfflineMapDisplay(double dblLon, double dblLat, int intMapLevel, string strTag = "")
        {
            txtMapCenterLon.Text = dblLon.ToString();
            txtMapCenterLat.Text = dblLat.ToString();
            txtMapCurrentMapLevl.Text = intMapLevel.ToString();
        }



        private void cmbPicIndexImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int intIndex = Convert.ToInt32(cmbPicPointIndex.Text.Trim()) - 1;
                if (offlineMap1.DisplayPointList != null)
                {
                    if (offlineMap1.DisplayPointList.Length > intIndex)
                    {
                        picCurrentImage.Image = offlineMap1.DisplayPointList[intIndex].Image;
                    }
                    else
                    {
                        MessageBox.Show("索引超出范围");
                    }
                }
                else
                {
                    MessageBox.Show("图片列表未赋值");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        private void cmbMapLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intMapLevel = Convert.ToInt32(cmbMapLevel.Text.ToString());
            offlineMap1.DisplayMap_SetMapLevel(intMapLevel);
        }

        private void cmbPicMulchIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int intIndex = Convert.ToInt32(cmbPicMulchIndex.Text.Trim()) - 1;
                if (offlineMap1.DisplayMulchList != null)
                {
                    if (offlineMap1.DisplayMulchList.Length > intIndex)
                    {
                        picCurrentImage.Image = offlineMap1.DisplayMulchList[intIndex].Image;
                    }
                    else
                    {
                        MessageBox.Show("索引超出范围");
                    }
                }
                else
                {
                    MessageBox.Show("图片列表未赋值");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// 显示覆盖物点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayMulch_Click(object sender, EventArgs e)
        {
            try
            {
                int intIndex = Convert.ToInt32(cmbPicMulchIndex.Text.Trim()) - 1;
                double dblLon = Convert.ToDouble(txtLon.Text.Trim());
                double dblLat = Convert.ToDouble(txtLat.Text.Trim());
                offlineMap1.DisplayMulchImage(intIndex, dblLon, dblLat, 18);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// 显示标注点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplayPos_Click(object sender, EventArgs e)
        {
            try
            {
                int intIndex = Convert.ToInt32(cmbPicPointIndex.Text.Trim()) - 1;
                double dblLon = Convert.ToDouble(txtLon.Text.Trim());
                double dblLat = Convert.ToDouble(txtLat.Text.Trim());
                offlineMap1.DisplayImage(intIndex, dblLon, dblLat);
                //offlineMap1.set
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //offlineMap1.DisplayMap_SetCenterAndLevel(dblLon, dblLat, 16);
        }

        private void offlineMap1_OfflineMapError(Exception ex, string strExceptionTag)
        {

        }

        #region　地图控件事件
        public void SelectedMapPoint(object sender, MapPointInfo1 MapPointInfo)
        {
            txtSelectedMapPointType.Text = MapPointInfo.cordinateSyatem.ToString();
            txtSelectedMapPointLevel.Text = MapPointInfo.intMapLevel.ToString();
            txtSelectedMapPointLon.Text = MapPointInfo.dblLon.ToString();
            txtSelectedMapPointLat.Text = MapPointInfo.dblLat.ToString();
            txtSetMapInfo_MapLon.Text = MapPointInfo.dblLon.ToString();
            txtSetMapInfo_MapLat.Text = MapPointInfo.dblLat.ToString();
        }

        #endregion
        

        private void btnSetCenter_Click(object sender, EventArgs e)
        {
            MapPointInfo1 point = new MapPointInfo1();
            point.dblLon = Convert.ToDouble(txtSetMapInfo_MapLon.Text.Trim());
            point.dblLat = Convert.ToDouble(txtSetMapInfo_MapLat.Text.Trim());
            offlineMap1.SetCenterPoint(point);
        }

        private void btnSetMapLevel_Click(object sender, EventArgs e)
        {
            int intMapLevel = Convert.ToInt32(txtSetMapInfo_MapLevel.Text.ToString());
            //offlineMap1.DisplayMap_SetMapLevel(intMapLevel);
            offlineMap1.SetMapLevel(new MapPointInfo1 { intMapLevel = intMapLevel });
        }

        private void btnSetMarker_Click(object sender, EventArgs e)
        {
            MapPointInfo1 m = new MapPointInfo1();
            m.dblLon = Convert.ToDouble(txtSetMapInfo_MapLon.Text);
            m.dblLat = Convert.ToDouble(txtSetMapInfo_MapLat.Text);
            string strMapIconFilePath = txtMarkerIconFilePath.Text.Trim();
            //public bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath)
            offlineMap1.SetMapMarker(m, Environment.CurrentDirectory + "\\OnlineMapFile\\ImageFile\\" + strMapIconFilePath);
            //offlineMap1.DisplayMap_SetMarker(m, strMapIconFilePath);
        }
    }
}
