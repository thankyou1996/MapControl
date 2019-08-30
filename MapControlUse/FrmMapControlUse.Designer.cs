
using MapControl;

namespace MapControlUse
{
    partial class FrmMapControlUse
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnGoogleOnlineMap = new System.Windows.Forms.Button();
            this.btnClearMarkerList = new System.Windows.Forms.Button();
            this.btnSetMarkerANIMATION_BOUNCE = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDoubleClickZoon_False = new System.Windows.Forms.Button();
            this.btnDoubleClickZoon_True = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSetMapLevel = new System.Windows.Forms.TextBox();
            this.txtSetMapPointLat = new System.Windows.Forms.TextBox();
            this.txtSetMapPointLon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btntxtSetMapLevel = new System.Windows.Forms.Button();
            this.btntxtSetMapPointInfo = new System.Windows.Forms.Button();
            this.btntxtSetMapPoint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSetMarker2 = new System.Windows.Forms.Button();
            this.btnSetMarker1 = new System.Windows.Forms.Button();
            this.txtMarkerIconFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSelectedMapPointLevel = new System.Windows.Forms.TextBox();
            this.txtSelectedMapPointLat = new System.Windows.Forms.TextBox();
            this.txtSelectedMapPointType = new System.Windows.Forms.TextBox();
            this.txtSelectedMapPointLon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMapCurrentMapLevl = new System.Windows.Forms.TextBox();
            this.txtMapCenterLat = new System.Windows.Forms.TextBox();
            this.txtMapType = new System.Windows.Forms.TextBox();
            this.txtMapCenterLon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBaiduOnlineMap = new System.Windows.Forms.Button();
            this.btnSogouOfflineMap2 = new System.Windows.Forms.Button();
            this.btnSogouOfflineMap1 = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.右键点击1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.右键点击3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapControl1 = new MapControl.MapControl();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnGoogleOnlineMap);
            this.pnlLeft.Controls.Add(this.btnClearMarkerList);
            this.pnlLeft.Controls.Add(this.btnSetMarkerANIMATION_BOUNCE);
            this.pnlLeft.Controls.Add(this.textBox1);
            this.pnlLeft.Controls.Add(this.btnDoubleClickZoon_False);
            this.pnlLeft.Controls.Add(this.btnDoubleClickZoon_True);
            this.pnlLeft.Controls.Add(this.groupBox4);
            this.pnlLeft.Controls.Add(this.groupBox3);
            this.pnlLeft.Controls.Add(this.groupBox1);
            this.pnlLeft.Controls.Add(this.groupBox2);
            this.pnlLeft.Controls.Add(this.btnBaiduOnlineMap);
            this.pnlLeft.Controls.Add(this.btnSogouOfflineMap2);
            this.pnlLeft.Controls.Add(this.btnSogouOfflineMap1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(325, 468);
            this.pnlLeft.TabIndex = 1;
            this.pnlLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlLeft_MouseClick);
            // 
            // btnGoogleOnlineMap
            // 
            this.btnGoogleOnlineMap.Location = new System.Drawing.Point(164, 5);
            this.btnGoogleOnlineMap.Name = "btnGoogleOnlineMap";
            this.btnGoogleOnlineMap.Size = new System.Drawing.Size(59, 23);
            this.btnGoogleOnlineMap.TabIndex = 13;
            this.btnGoogleOnlineMap.Text = "Google";
            this.btnGoogleOnlineMap.UseVisualStyleBackColor = true;
            this.btnGoogleOnlineMap.Click += new System.EventHandler(this.BtnGoogleOnlineMap_Click);
            // 
            // btnClearMarkerList
            // 
            this.btnClearMarkerList.Location = new System.Drawing.Point(227, 119);
            this.btnClearMarkerList.Name = "btnClearMarkerList";
            this.btnClearMarkerList.Size = new System.Drawing.Size(91, 35);
            this.btnClearMarkerList.TabIndex = 12;
            this.btnClearMarkerList.Text = "清除标注点信息";
            this.btnClearMarkerList.UseVisualStyleBackColor = true;
            this.btnClearMarkerList.Click += new System.EventHandler(this.btnClearMarkerList_Click);
            // 
            // btnSetMarkerANIMATION_BOUNCE
            // 
            this.btnSetMarkerANIMATION_BOUNCE.Location = new System.Drawing.Point(227, 92);
            this.btnSetMarkerANIMATION_BOUNCE.Name = "btnSetMarkerANIMATION_BOUNCE";
            this.btnSetMarkerANIMATION_BOUNCE.Size = new System.Drawing.Size(91, 23);
            this.btnSetMarkerANIMATION_BOUNCE.TabIndex = 11;
            this.btnSetMarkerANIMATION_BOUNCE.Text = "设置跳动";
            this.btnSetMarkerANIMATION_BOUNCE.UseVisualStyleBackColor = true;
            this.btnSetMarkerANIMATION_BOUNCE.Click += new System.EventHandler(this.btnSetMarkerANIMATION_BOUNCE_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0001";
            // 
            // btnDoubleClickZoon_False
            // 
            this.btnDoubleClickZoon_False.Location = new System.Drawing.Point(227, 41);
            this.btnDoubleClickZoon_False.Name = "btnDoubleClickZoon_False";
            this.btnDoubleClickZoon_False.Size = new System.Drawing.Size(91, 23);
            this.btnDoubleClickZoon_False.TabIndex = 9;
            this.btnDoubleClickZoon_False.Text = "关闭双击放大";
            this.btnDoubleClickZoon_False.UseVisualStyleBackColor = true;
            this.btnDoubleClickZoon_False.Click += new System.EventHandler(this.btnDoubleClickZoon_False_Click);
            // 
            // btnDoubleClickZoon_True
            // 
            this.btnDoubleClickZoon_True.Location = new System.Drawing.Point(227, 12);
            this.btnDoubleClickZoon_True.Name = "btnDoubleClickZoon_True";
            this.btnDoubleClickZoon_True.Size = new System.Drawing.Size(91, 23);
            this.btnDoubleClickZoon_True.TabIndex = 8;
            this.btnDoubleClickZoon_True.Text = "打开双击放大";
            this.btnDoubleClickZoon_True.UseVisualStyleBackColor = true;
            this.btnDoubleClickZoon_True.Click += new System.EventHandler(this.btnDoubleClickZoon_True_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.txtSetMapLevel);
            this.groupBox4.Controls.Add(this.txtSetMapPointLat);
            this.groupBox4.Controls.Add(this.txtSetMapPointLon);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btntxtSetMapLevel);
            this.groupBox4.Controls.Add(this.btntxtSetMapPointInfo);
            this.groupBox4.Controls.Add(this.btntxtSetMapPoint);
            this.groupBox4.Location = new System.Drawing.Point(6, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 121);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设置地图点";
            // 
            // txtSetMapLevel
            // 
            this.txtSetMapLevel.Location = new System.Drawing.Point(43, 66);
            this.txtSetMapLevel.Name = "txtSetMapLevel";
            this.txtSetMapLevel.Size = new System.Drawing.Size(93, 21);
            this.txtSetMapLevel.TabIndex = 17;
            // 
            // txtSetMapPointLat
            // 
            this.txtSetMapPointLat.Location = new System.Drawing.Point(43, 42);
            this.txtSetMapPointLat.Name = "txtSetMapPointLat";
            this.txtSetMapPointLat.Size = new System.Drawing.Size(174, 21);
            this.txtSetMapPointLat.TabIndex = 15;
            // 
            // txtSetMapPointLon
            // 
            this.txtSetMapPointLon.Location = new System.Drawing.Point(43, 19);
            this.txtSetMapPointLon.Name = "txtSetMapPointLon";
            this.txtSetMapPointLon.Size = new System.Drawing.Size(174, 21);
            this.txtSetMapPointLon.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "等级";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "纬度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "经度";
            // 
            // btntxtSetMapLevel
            // 
            this.btntxtSetMapLevel.Location = new System.Drawing.Point(140, 65);
            this.btntxtSetMapLevel.Name = "btntxtSetMapLevel";
            this.btntxtSetMapLevel.Size = new System.Drawing.Size(75, 23);
            this.btntxtSetMapLevel.TabIndex = 12;
            this.btntxtSetMapLevel.Text = "设置等级";
            this.btntxtSetMapLevel.UseVisualStyleBackColor = true;
            this.btntxtSetMapLevel.Click += new System.EventHandler(this.btntxtSetMapLevel_Click);
            // 
            // btntxtSetMapPointInfo
            // 
            this.btntxtSetMapPointInfo.Location = new System.Drawing.Point(140, 94);
            this.btntxtSetMapPointInfo.Name = "btntxtSetMapPointInfo";
            this.btntxtSetMapPointInfo.Size = new System.Drawing.Size(75, 23);
            this.btntxtSetMapPointInfo.TabIndex = 12;
            this.btntxtSetMapPointInfo.Text = "设置点信息";
            this.btntxtSetMapPointInfo.UseVisualStyleBackColor = true;
            this.btntxtSetMapPointInfo.Click += new System.EventHandler(this.btntxtSetMapPointInfo_Click);
            // 
            // btntxtSetMapPoint
            // 
            this.btntxtSetMapPoint.Location = new System.Drawing.Point(58, 94);
            this.btntxtSetMapPoint.Name = "btntxtSetMapPoint";
            this.btntxtSetMapPoint.Size = new System.Drawing.Size(80, 23);
            this.btntxtSetMapPoint.TabIndex = 12;
            this.btntxtSetMapPoint.Text = "设置中心点";
            this.btntxtSetMapPoint.UseVisualStyleBackColor = true;
            this.btntxtSetMapPoint.Click += new System.EventHandler(this.btntxtSetMapPoint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnSetMarker2);
            this.groupBox3.Controls.Add(this.btnSetMarker1);
            this.groupBox3.Controls.Add(this.txtMarkerIconFilePath);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(5, 393);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 66);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "添加标注点";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "多标注点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSetMarker2
            // 
            this.btnSetMarker2.Location = new System.Drawing.Point(78, 41);
            this.btnSetMarker2.Name = "btnSetMarker2";
            this.btnSetMarker2.Size = new System.Drawing.Size(61, 23);
            this.btnSetMarker2.TabIndex = 12;
            this.btnSetMarker2.Text = "标注点2";
            this.btnSetMarker2.UseVisualStyleBackColor = true;
            this.btnSetMarker2.Click += new System.EventHandler(this.btnSetMarker2_Click);
            // 
            // btnSetMarker1
            // 
            this.btnSetMarker1.Location = new System.Drawing.Point(11, 41);
            this.btnSetMarker1.Name = "btnSetMarker1";
            this.btnSetMarker1.Size = new System.Drawing.Size(61, 23);
            this.btnSetMarker1.TabIndex = 12;
            this.btnSetMarker1.Text = "标注点1";
            this.btnSetMarker1.UseVisualStyleBackColor = true;
            this.btnSetMarker1.Click += new System.EventHandler(this.btnSetMarker_Click);
            // 
            // txtMarkerIconFilePath
            // 
            this.txtMarkerIconFilePath.Location = new System.Drawing.Point(44, 14);
            this.txtMarkerIconFilePath.Name = "txtMarkerIconFilePath";
            this.txtMarkerIconFilePath.Size = new System.Drawing.Size(175, 21);
            this.txtMarkerIconFilePath.TabIndex = 13;
            this.txtMarkerIconFilePath.Text = "MapIcon_PositionLabel1_Red.png";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "图标";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSelectedMapPointLevel);
            this.groupBox1.Controls.Add(this.txtSelectedMapPointLat);
            this.groupBox1.Controls.Add(this.txtSelectedMapPointType);
            this.groupBox1.Controls.Add(this.txtSelectedMapPointLon);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(3, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 89);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选中点信息";
            // 
            // txtSelectedMapPointLevel
            // 
            this.txtSelectedMapPointLevel.Location = new System.Drawing.Point(180, 14);
            this.txtSelectedMapPointLevel.Name = "txtSelectedMapPointLevel";
            this.txtSelectedMapPointLevel.Size = new System.Drawing.Size(38, 21);
            this.txtSelectedMapPointLevel.TabIndex = 1;
            // 
            // txtSelectedMapPointLat
            // 
            this.txtSelectedMapPointLat.Location = new System.Drawing.Point(44, 61);
            this.txtSelectedMapPointLat.Name = "txtSelectedMapPointLat";
            this.txtSelectedMapPointLat.Size = new System.Drawing.Size(174, 21);
            this.txtSelectedMapPointLat.TabIndex = 1;
            // 
            // txtSelectedMapPointType
            // 
            this.txtSelectedMapPointType.Location = new System.Drawing.Point(44, 14);
            this.txtSelectedMapPointType.Name = "txtSelectedMapPointType";
            this.txtSelectedMapPointType.Size = new System.Drawing.Size(95, 21);
            this.txtSelectedMapPointType.TabIndex = 1;
            // 
            // txtSelectedMapPointLon
            // 
            this.txtSelectedMapPointLon.Location = new System.Drawing.Point(44, 38);
            this.txtSelectedMapPointLon.Name = "txtSelectedMapPointLon";
            this.txtSelectedMapPointLon.Size = new System.Drawing.Size(174, 21);
            this.txtSelectedMapPointLon.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "等级";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "纬度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "类型";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "经度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMapCurrentMapLevl);
            this.groupBox2.Controls.Add(this.txtMapCenterLat);
            this.groupBox2.Controls.Add(this.txtMapType);
            this.groupBox2.Controls.Add(this.txtMapCenterLon);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 86);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地图信息";
            // 
            // txtMapCurrentMapLevl
            // 
            this.txtMapCurrentMapLevl.Location = new System.Drawing.Point(180, 14);
            this.txtMapCurrentMapLevl.Name = "txtMapCurrentMapLevl";
            this.txtMapCurrentMapLevl.Size = new System.Drawing.Size(38, 21);
            this.txtMapCurrentMapLevl.TabIndex = 1;
            // 
            // txtMapCenterLat
            // 
            this.txtMapCenterLat.Location = new System.Drawing.Point(44, 61);
            this.txtMapCenterLat.Name = "txtMapCenterLat";
            this.txtMapCenterLat.Size = new System.Drawing.Size(174, 21);
            this.txtMapCenterLat.TabIndex = 1;
            // 
            // txtMapType
            // 
            this.txtMapType.Location = new System.Drawing.Point(44, 14);
            this.txtMapType.Name = "txtMapType";
            this.txtMapType.Size = new System.Drawing.Size(95, 21);
            this.txtMapType.TabIndex = 1;
            // 
            // txtMapCenterLon
            // 
            this.txtMapCenterLon.Location = new System.Drawing.Point(44, 38);
            this.txtMapCenterLon.Name = "txtMapCenterLon";
            this.txtMapCenterLon.Size = new System.Drawing.Size(174, 21);
            this.txtMapCenterLon.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "等级";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "纬度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "经度";
            // 
            // btnBaiduOnlineMap
            // 
            this.btnBaiduOnlineMap.Location = new System.Drawing.Point(83, 3);
            this.btnBaiduOnlineMap.Name = "btnBaiduOnlineMap";
            this.btnBaiduOnlineMap.Size = new System.Drawing.Size(75, 25);
            this.btnBaiduOnlineMap.TabIndex = 0;
            this.btnBaiduOnlineMap.Text = "百度在线";
            this.btnBaiduOnlineMap.UseVisualStyleBackColor = true;
            this.btnBaiduOnlineMap.Click += new System.EventHandler(this.btnBaiduOnlineMap_Click);
            // 
            // btnSogouOfflineMap2
            // 
            this.btnSogouOfflineMap2.Location = new System.Drawing.Point(3, 34);
            this.btnSogouOfflineMap2.Name = "btnSogouOfflineMap2";
            this.btnSogouOfflineMap2.Size = new System.Drawing.Size(74, 25);
            this.btnSogouOfflineMap2.TabIndex = 0;
            this.btnSogouOfflineMap2.Text = "搜狗离线2";
            this.btnSogouOfflineMap2.UseVisualStyleBackColor = true;
            this.btnSogouOfflineMap2.Click += new System.EventHandler(this.btnSogouOfflineMap2_Click);
            // 
            // btnSogouOfflineMap1
            // 
            this.btnSogouOfflineMap1.Location = new System.Drawing.Point(3, 3);
            this.btnSogouOfflineMap1.Name = "btnSogouOfflineMap1";
            this.btnSogouOfflineMap1.Size = new System.Drawing.Size(74, 25);
            this.btnSogouOfflineMap1.TabIndex = 0;
            this.btnSogouOfflineMap1.Text = "搜狗离线1";
            this.btnSogouOfflineMap1.UseVisualStyleBackColor = true;
            this.btnSogouOfflineMap1.Click += new System.EventHandler(this.btnSogouOfflineMap_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.mapControl1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(325, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(580, 468);
            this.pnlMain.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.右键点击1ToolStripMenuItem,
            this.右键点击3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItem1.Text = "右键点击1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 右键点击1ToolStripMenuItem
            // 
            this.右键点击1ToolStripMenuItem.Name = "右键点击1ToolStripMenuItem";
            this.右键点击1ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.右键点击1ToolStripMenuItem.Text = "右键点击2";
            this.右键点击1ToolStripMenuItem.Click += new System.EventHandler(this.右键点击1ToolStripMenuItem_Click);
            // 
            // 右键点击3ToolStripMenuItem
            // 
            this.右键点击3ToolStripMenuItem.Name = "右键点击3ToolStripMenuItem";
            this.右键点击3ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.右键点击3ToolStripMenuItem.Text = "右键点击3";
            this.右键点击3ToolStripMenuItem.Click += new System.EventHandler(this.右键点击3ToolStripMenuItem_Click);
            // 
            // mapControl1
            // 
            this.mapControl1.CurrentMapType = MapControl.MapType.BaiduOnlineMap;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.mapType = MapControl.MapType.BaiduOnlineMap;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(580, 468);
            this.mapControl1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "圆形";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FrmMapControlUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 468);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmMapControlUse";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMapControlUse_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MapControl.MapControl mapControl1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnBaiduOnlineMap;
        private System.Windows.Forms.Button btnSogouOfflineMap1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMapCurrentMapLevl;
        private System.Windows.Forms.TextBox txtMapCenterLat;
        private System.Windows.Forms.TextBox txtMapCenterLon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMapType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSelectedMapPointLevel;
        private System.Windows.Forms.TextBox txtSelectedMapPointLat;
        private System.Windows.Forms.TextBox txtSelectedMapPointType;
        private System.Windows.Forms.TextBox txtSelectedMapPointLon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSetMarker1;
        private System.Windows.Forms.TextBox txtMarkerIconFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btntxtSetMapPoint;
        private System.Windows.Forms.TextBox txtSetMapPointLat;
        private System.Windows.Forms.TextBox txtSetMapPointLon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSetMapLevel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btntxtSetMapLevel;
        private System.Windows.Forms.Button btntxtSetMapPointInfo;
        private System.Windows.Forms.Button btnSogouOfflineMap2;
        private System.Windows.Forms.Button btnSetMarker2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 右键点击1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 右键点击3ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDoubleClickZoon_True;
        private System.Windows.Forms.Button btnDoubleClickZoon_False;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSetMarkerANIMATION_BOUNCE;
        private System.Windows.Forms.Button btnClearMarkerList;
        private System.Windows.Forms.Button btnGoogleOnlineMap;
        private System.Windows.Forms.Button button2;
    }
}

