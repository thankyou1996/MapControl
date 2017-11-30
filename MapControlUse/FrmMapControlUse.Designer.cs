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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnSogouOfflineMap = new System.Windows.Forms.Button();
            this.btnBaiduOnlineMap = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMapCurrentMapLevl = new System.Windows.Forms.TextBox();
            this.txtMapCenterLat = new System.Windows.Forms.TextBox();
            this.txtMapCenterLon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMapType = new System.Windows.Forms.TextBox();
            this.mapControl1 = new MapControl.MapControl();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.groupBox2);
            this.pnlLeft.Controls.Add(this.btnBaiduOnlineMap);
            this.pnlLeft.Controls.Add(this.btnSogouOfflineMap);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(147, 400);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.mapControl1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(147, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(366, 400);
            this.pnlMain.TabIndex = 2;
            // 
            // btnSogouOfflineMap
            // 
            this.btnSogouOfflineMap.Location = new System.Drawing.Point(3, 3);
            this.btnSogouOfflineMap.Name = "btnSogouOfflineMap";
            this.btnSogouOfflineMap.Size = new System.Drawing.Size(138, 25);
            this.btnSogouOfflineMap.TabIndex = 0;
            this.btnSogouOfflineMap.Text = "搜狗离线";
            this.btnSogouOfflineMap.UseVisualStyleBackColor = true;
            this.btnSogouOfflineMap.Click += new System.EventHandler(this.btnSogouOfflineMap_Click);
            // 
            // btnBaiduOnlineMap
            // 
            this.btnBaiduOnlineMap.Location = new System.Drawing.Point(3, 34);
            this.btnBaiduOnlineMap.Name = "btnBaiduOnlineMap";
            this.btnBaiduOnlineMap.Size = new System.Drawing.Size(138, 25);
            this.btnBaiduOnlineMap.TabIndex = 0;
            this.btnBaiduOnlineMap.Text = "百度在线";
            this.btnBaiduOnlineMap.UseVisualStyleBackColor = true;
            this.btnBaiduOnlineMap.Click += new System.EventHandler(this.btnBaiduOnlineMap_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtMapCurrentMapLevl);
            this.groupBox2.Controls.Add(this.txtMapCenterLat);
            this.groupBox2.Controls.Add(this.txtMapType);
            this.groupBox2.Controls.Add(this.txtMapCenterLon);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 138);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地图信息";
            // 
            // txtMapCurrentMapLevl
            // 
            this.txtMapCurrentMapLevl.Location = new System.Drawing.Point(66, 83);
            this.txtMapCurrentMapLevl.Name = "txtMapCurrentMapLevl";
            this.txtMapCurrentMapLevl.Size = new System.Drawing.Size(73, 21);
            this.txtMapCurrentMapLevl.TabIndex = 1;
            // 
            // txtMapCenterLat
            // 
            this.txtMapCenterLat.Location = new System.Drawing.Point(44, 61);
            this.txtMapCenterLat.Name = "txtMapCenterLat";
            this.txtMapCenterLat.Size = new System.Drawing.Size(95, 21);
            this.txtMapCenterLat.TabIndex = 1;
            // 
            // txtMapCenterLon
            // 
            this.txtMapCenterLon.Location = new System.Drawing.Point(44, 38);
            this.txtMapCenterLon.Name = "txtMapCenterLon";
            this.txtMapCenterLon.Size = new System.Drawing.Size(95, 21);
            this.txtMapCenterLon.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "显示等级";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "经度";
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
            // txtMapType
            // 
            this.txtMapType.Location = new System.Drawing.Point(44, 14);
            this.txtMapType.Name = "txtMapType";
            this.txtMapType.Size = new System.Drawing.Size(95, 21);
            this.txtMapType.TabIndex = 1;
            // 
            // mapControl1
            // 
            this.mapControl1.CurrentMapType = MapControl.MapType.SogouOffLineMap;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(366, 400);
            this.mapControl1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "*离线地图显示中心点\r\n 在线地图显示选中点";
            // 
            // FrmMapControlUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 400);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmMapControlUse";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMapControlUse_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MapControl.MapControl mapControl1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnBaiduOnlineMap;
        private System.Windows.Forms.Button btnSogouOfflineMap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMapCurrentMapLevl;
        private System.Windows.Forms.TextBox txtMapCenterLat;
        private System.Windows.Forms.TextBox txtMapCenterLon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMapType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

