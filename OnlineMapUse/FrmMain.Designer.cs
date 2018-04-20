namespace OnlineMapUse
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpSetMapInfo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMarkerIconFilePath = new System.Windows.Forms.TextBox();
            this.btnSetMarker = new System.Windows.Forms.Button();
            this.btnSetMapLevel = new System.Windows.Forms.Button();
            this.btnSetCenter = new System.Windows.Forms.Button();
            this.txtSetMapInfo_MapLevel = new System.Windows.Forms.TextBox();
            this.txtSetMapInfo_MapLat = new System.Windows.Forms.TextBox();
            this.txtSetMapInfo_MapType = new System.Windows.Forms.TextBox();
            this.txtSetMapInfo_MapLon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSelectedMapPointLevel = new System.Windows.Forms.TextBox();
            this.txtSelectedMapPointLat = new System.Windows.Forms.TextBox();
            this.txtSelectedMapPointType = new System.Windows.Forms.TextBox();
            this.txtSelectedMapPointLon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.onlineMap1 = new OnlineMap.BaiduOnlineMap();
            this.pnlLeft.SuspendLayout();
            this.grpSetMapInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpSetMapInfo);
            this.pnlLeft.Controls.Add(this.groupBox2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(186, 412);
            this.pnlLeft.TabIndex = 2;
            // 
            // grpSetMapInfo
            // 
            this.grpSetMapInfo.Controls.Add(this.label10);
            this.grpSetMapInfo.Controls.Add(this.textBox1);
            this.grpSetMapInfo.Controls.Add(this.label9);
            this.grpSetMapInfo.Controls.Add(this.txtMarkerIconFilePath);
            this.grpSetMapInfo.Controls.Add(this.btnSetMarker);
            this.grpSetMapInfo.Controls.Add(this.btnSetMapLevel);
            this.grpSetMapInfo.Controls.Add(this.btnSetCenter);
            this.grpSetMapInfo.Controls.Add(this.txtSetMapInfo_MapLevel);
            this.grpSetMapInfo.Controls.Add(this.txtSetMapInfo_MapLat);
            this.grpSetMapInfo.Controls.Add(this.txtSetMapInfo_MapType);
            this.grpSetMapInfo.Controls.Add(this.txtSetMapInfo_MapLon);
            this.grpSetMapInfo.Controls.Add(this.label2);
            this.grpSetMapInfo.Controls.Add(this.label3);
            this.grpSetMapInfo.Controls.Add(this.label4);
            this.grpSetMapInfo.Controls.Add(this.label5);
            this.grpSetMapInfo.Location = new System.Drawing.Point(3, 118);
            this.grpSetMapInfo.Name = "grpSetMapInfo";
            this.grpSetMapInfo.Size = new System.Drawing.Size(180, 222);
            this.grpSetMapInfo.TabIndex = 7;
            this.grpSetMapInfo.TabStop = false;
            this.grpSetMapInfo.Text = "地图信息_设置点信息";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "图标";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 169);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "显示测试";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "图标";
            // 
            // txtMarkerIconFilePath
            // 
            this.txtMarkerIconFilePath.Location = new System.Drawing.Point(44, 139);
            this.txtMarkerIconFilePath.Name = "txtMarkerIconFilePath";
            this.txtMarkerIconFilePath.Size = new System.Drawing.Size(130, 21);
            this.txtMarkerIconFilePath.TabIndex = 10;
            this.txtMarkerIconFilePath.Text = "MapIcon_PositionLabel1_Red.png";
            // 
            // btnSetMarker
            // 
            this.btnSetMarker.Location = new System.Drawing.Point(9, 193);
            this.btnSetMarker.Name = "btnSetMarker";
            this.btnSetMarker.Size = new System.Drawing.Size(75, 23);
            this.btnSetMarker.TabIndex = 9;
            this.btnSetMarker.Text = "设置标注点";
            this.btnSetMarker.UseVisualStyleBackColor = true;
            this.btnSetMarker.Click += new System.EventHandler(this.btnSetMarker_Click);
            // 
            // btnSetMapLevel
            // 
            this.btnSetMapLevel.Location = new System.Drawing.Point(90, 110);
            this.btnSetMapLevel.Name = "btnSetMapLevel";
            this.btnSetMapLevel.Size = new System.Drawing.Size(75, 23);
            this.btnSetMapLevel.TabIndex = 8;
            this.btnSetMapLevel.Text = "设置等级";
            this.btnSetMapLevel.UseVisualStyleBackColor = true;
            this.btnSetMapLevel.Click += new System.EventHandler(this.btnSetMapLevel_Click);
            // 
            // btnSetCenter
            // 
            this.btnSetCenter.Location = new System.Drawing.Point(9, 110);
            this.btnSetCenter.Name = "btnSetCenter";
            this.btnSetCenter.Size = new System.Drawing.Size(75, 23);
            this.btnSetCenter.TabIndex = 8;
            this.btnSetCenter.Text = "设置中心";
            this.btnSetCenter.UseVisualStyleBackColor = true;
            this.btnSetCenter.Click += new System.EventHandler(this.btnSetCenter_Click);
            // 
            // txtSetMapInfo_MapLevel
            // 
            this.txtSetMapInfo_MapLevel.Location = new System.Drawing.Point(66, 83);
            this.txtSetMapInfo_MapLevel.Name = "txtSetMapInfo_MapLevel";
            this.txtSetMapInfo_MapLevel.Size = new System.Drawing.Size(108, 21);
            this.txtSetMapInfo_MapLevel.TabIndex = 1;
            // 
            // txtSetMapInfo_MapLat
            // 
            this.txtSetMapInfo_MapLat.Location = new System.Drawing.Point(44, 61);
            this.txtSetMapInfo_MapLat.Name = "txtSetMapInfo_MapLat";
            this.txtSetMapInfo_MapLat.Size = new System.Drawing.Size(130, 21);
            this.txtSetMapInfo_MapLat.TabIndex = 1;
            // 
            // txtSetMapInfo_MapType
            // 
            this.txtSetMapInfo_MapType.Location = new System.Drawing.Point(44, 14);
            this.txtSetMapInfo_MapType.Name = "txtSetMapInfo_MapType";
            this.txtSetMapInfo_MapType.Size = new System.Drawing.Size(130, 21);
            this.txtSetMapInfo_MapType.TabIndex = 1;
            // 
            // txtSetMapInfo_MapLon
            // 
            this.txtSetMapInfo_MapLon.Location = new System.Drawing.Point(44, 38);
            this.txtSetMapInfo_MapLon.Name = "txtSetMapInfo_MapLon";
            this.txtSetMapInfo_MapLon.Size = new System.Drawing.Size(130, 21);
            this.txtSetMapInfo_MapLon.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "显示等级";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "纬度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "经度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSelectedMapPointLevel);
            this.groupBox2.Controls.Add(this.txtSelectedMapPointLat);
            this.groupBox2.Controls.Add(this.txtSelectedMapPointType);
            this.groupBox2.Controls.Add(this.txtSelectedMapPointLon);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 109);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地图信息_选中点信息";
            // 
            // txtSelectedMapPointLevel
            // 
            this.txtSelectedMapPointLevel.Location = new System.Drawing.Point(66, 83);
            this.txtSelectedMapPointLevel.Name = "txtSelectedMapPointLevel";
            this.txtSelectedMapPointLevel.Size = new System.Drawing.Size(108, 21);
            this.txtSelectedMapPointLevel.TabIndex = 1;
            // 
            // txtSelectedMapPointLat
            // 
            this.txtSelectedMapPointLat.Location = new System.Drawing.Point(44, 61);
            this.txtSelectedMapPointLat.Name = "txtSelectedMapPointLat";
            this.txtSelectedMapPointLat.Size = new System.Drawing.Size(130, 21);
            this.txtSelectedMapPointLat.TabIndex = 1;
            // 
            // txtSelectedMapPointType
            // 
            this.txtSelectedMapPointType.Location = new System.Drawing.Point(44, 14);
            this.txtSelectedMapPointType.Name = "txtSelectedMapPointType";
            this.txtSelectedMapPointType.Size = new System.Drawing.Size(130, 21);
            this.txtSelectedMapPointType.TabIndex = 1;
            // 
            // txtSelectedMapPointLon
            // 
            this.txtSelectedMapPointLon.Location = new System.Drawing.Point(44, 38);
            this.txtSelectedMapPointLon.Name = "txtSelectedMapPointLon";
            this.txtSelectedMapPointLon.Size = new System.Drawing.Size(130, 21);
            this.txtSelectedMapPointLon.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.onlineMap1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(186, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 412);
            this.panel1.TabIndex = 3;
            // 
            // onlineMap1
            // 
            this.onlineMap1.CurrentMapLevel = 0;
            this.onlineMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onlineMap1.Location = new System.Drawing.Point(0, 0);
            this.onlineMap1.Name = "onlineMap1";
            this.onlineMap1.Size = new System.Drawing.Size(446, 412);
            this.onlineMap1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlLeft.ResumeLayout(false);
            this.grpSetMapInfo.ResumeLayout(false);
            this.grpSetMapInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OnlineMap.BaiduOnlineMap onlineMap1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSelectedMapPointLevel;
        private System.Windows.Forms.TextBox txtSelectedMapPointLat;
        private System.Windows.Forms.TextBox txtSelectedMapPointType;
        private System.Windows.Forms.TextBox txtSelectedMapPointLon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetCenter;
        private System.Windows.Forms.GroupBox grpSetMapInfo;
        private System.Windows.Forms.TextBox txtSetMapInfo_MapLevel;
        private System.Windows.Forms.TextBox txtSetMapInfo_MapLat;
        private System.Windows.Forms.TextBox txtSetMapInfo_MapType;
        private System.Windows.Forms.TextBox txtSetMapInfo_MapLon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetMapLevel;
        private System.Windows.Forms.Button btnSetMarker;
        private System.Windows.Forms.TextBox txtMarkerIconFilePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
    }
}

