namespace OffLineMapUse
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMapCurrentMapLevl = new System.Windows.Forms.TextBox();
            this.txtMapCenterLat = new System.Windows.Forms.TextBox();
            this.txtMapCenterLon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMapLevel = new System.Windows.Forms.ComboBox();
            this.cmbPicMulchIndex = new System.Windows.Forms.ComboBox();
            this.picCurrentImage = new System.Windows.Forms.PictureBox();
            this.cmbPicPointIndex = new System.Windows.Forms.ComboBox();
            this.btnSetCenter = new System.Windows.Forms.Button();
            this.btnDisplayMulch = new System.Windows.Forms.Button();
            this.btnDisplayPos = new System.Windows.Forms.Button();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSelectLon = new System.Windows.Forms.TextBox();
            this.txtSelectLat = new System.Windows.Forms.TextBox();
            this.offlineMap1 = new OffLineMap.SogouOfflineMap();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbPicMulchIndex);
            this.groupBox1.Controls.Add(this.picCurrentImage);
            this.groupBox1.Controls.Add(this.cmbPicPointIndex);
            this.groupBox1.Controls.Add(this.btnSetCenter);
            this.groupBox1.Controls.Add(this.btnDisplayMulch);
            this.groupBox1.Controls.Add(this.btnDisplayPos);
            this.groupBox1.Controls.Add(this.txtLat);
            this.groupBox1.Controls.Add(this.txtLon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 504);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMapCurrentMapLevl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMapCenterLat);
            this.groupBox2.Controls.Add(this.txtMapCenterLon);
            this.groupBox2.Controls.Add(this.cmbMapLevel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 123);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地图信息";
            // 
            // txtMapCurrentMapLevl
            // 
            this.txtMapCurrentMapLevl.Location = new System.Drawing.Point(79, 66);
            this.txtMapCurrentMapLevl.Name = "txtMapCurrentMapLevl";
            this.txtMapCurrentMapLevl.Size = new System.Drawing.Size(78, 21);
            this.txtMapCurrentMapLevl.TabIndex = 1;
            // 
            // txtMapCenterLat
            // 
            this.txtMapCenterLat.Location = new System.Drawing.Point(79, 44);
            this.txtMapCenterLat.Name = "txtMapCenterLat";
            this.txtMapCenterLat.Size = new System.Drawing.Size(100, 21);
            this.txtMapCenterLat.TabIndex = 1;
            // 
            // txtMapCenterLon
            // 
            this.txtMapCenterLon.Location = new System.Drawing.Point(79, 21);
            this.txtMapCenterLon.Name = "txtMapCenterLon";
            this.txtMapCenterLon.Size = new System.Drawing.Size(100, 21);
            this.txtMapCenterLon.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "显示等级";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "中心点纬度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "中心点经度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "地图等级";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "覆盖物图片";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "标注点图片";
            // 
            // cmbMapLevel
            // 
            this.cmbMapLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapLevel.FormattingEnabled = true;
            this.cmbMapLevel.Location = new System.Drawing.Point(79, 93);
            this.cmbMapLevel.Name = "cmbMapLevel";
            this.cmbMapLevel.Size = new System.Drawing.Size(39, 20);
            this.cmbMapLevel.TabIndex = 3;
            this.cmbMapLevel.SelectedIndexChanged += new System.EventHandler(this.cmbMapLevel_SelectedIndexChanged);
            // 
            // cmbPicMulchIndex
            // 
            this.cmbPicMulchIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPicMulchIndex.FormattingEnabled = true;
            this.cmbPicMulchIndex.Location = new System.Drawing.Point(227, 44);
            this.cmbPicMulchIndex.Name = "cmbPicMulchIndex";
            this.cmbPicMulchIndex.Size = new System.Drawing.Size(39, 20);
            this.cmbPicMulchIndex.TabIndex = 3;
            this.cmbPicMulchIndex.SelectedIndexChanged += new System.EventHandler(this.cmbPicMulchIndex_SelectedIndexChanged);
            // 
            // picCurrentImage
            // 
            this.picCurrentImage.Location = new System.Drawing.Point(6, 20);
            this.picCurrentImage.Name = "picCurrentImage";
            this.picCurrentImage.Size = new System.Drawing.Size(150, 150);
            this.picCurrentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCurrentImage.TabIndex = 4;
            this.picCurrentImage.TabStop = false;
            // 
            // cmbPicPointIndex
            // 
            this.cmbPicPointIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPicPointIndex.FormattingEnabled = true;
            this.cmbPicPointIndex.Location = new System.Drawing.Point(227, 17);
            this.cmbPicPointIndex.Name = "cmbPicPointIndex";
            this.cmbPicPointIndex.Size = new System.Drawing.Size(39, 20);
            this.cmbPicPointIndex.TabIndex = 3;
            this.cmbPicPointIndex.SelectedIndexChanged += new System.EventHandler(this.cmbPicIndexImage_SelectedIndexChanged);
            // 
            // btnSetCenter
            // 
            this.btnSetCenter.Location = new System.Drawing.Point(162, 121);
            this.btnSetCenter.Name = "btnSetCenter";
            this.btnSetCenter.Size = new System.Drawing.Size(51, 23);
            this.btnSetCenter.TabIndex = 2;
            this.btnSetCenter.Text = "居中";
            this.btnSetCenter.UseVisualStyleBackColor = true;
            this.btnSetCenter.Click += new System.EventHandler(this.btnSetCenter_Click);
            // 
            // btnDisplayMulch
            // 
            this.btnDisplayMulch.Location = new System.Drawing.Point(164, 147);
            this.btnDisplayMulch.Name = "btnDisplayMulch";
            this.btnDisplayMulch.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayMulch.TabIndex = 2;
            this.btnDisplayMulch.Text = "添加覆盖物";
            this.btnDisplayMulch.UseVisualStyleBackColor = true;
            this.btnDisplayMulch.Click += new System.EventHandler(this.btnDisplayMulch_Click);
            // 
            // btnDisplayPos
            // 
            this.btnDisplayPos.Location = new System.Drawing.Point(220, 121);
            this.btnDisplayPos.Name = "btnDisplayPos";
            this.btnDisplayPos.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayPos.TabIndex = 2;
            this.btnDisplayPos.Text = "添加标注点";
            this.btnDisplayPos.UseVisualStyleBackColor = true;
            this.btnDisplayPos.Click += new System.EventHandler(this.btnDisplayPos_Click);
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(197, 94);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(98, 21);
            this.txtLat.TabIndex = 1;
            this.txtLat.Text = "24.911641436";
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(197, 68);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(98, 21);
            this.txtLon.TabIndex = 1;
            this.txtLon.Text = "118.5587065";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "经度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "经度";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(826, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(155, 178);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox3.Location = new System.Drawing.Point(788, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(215, 238);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtSelectLat);
            this.groupBox3.Controls.Add(this.txtSelectLon);
            this.groupBox3.Location = new System.Drawing.Point(6, 305);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 71);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选中点";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "选中点";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "选中点";
            // 
            // txtSelectLon
            // 
            this.txtSelectLon.Location = new System.Drawing.Point(63, 17);
            this.txtSelectLon.Name = "txtSelectLon";
            this.txtSelectLon.Size = new System.Drawing.Size(100, 21);
            this.txtSelectLon.TabIndex = 1;
            // 
            // txtSelectLat
            // 
            this.txtSelectLat.Location = new System.Drawing.Point(63, 40);
            this.txtSelectLat.Name = "txtSelectLat";
            this.txtSelectLat.Size = new System.Drawing.Size(100, 21);
            this.txtSelectLat.TabIndex = 1;
            // 
            // offlineMap1
            // 
            this.offlineMap1.BackColor = System.Drawing.SystemColors.Control;
            this.offlineMap1.CurrentMapLevel = 0;
            this.offlineMap1.CurrentMouseMapPoint = null;
            this.offlineMap1.DisplayMulchList = null;
            this.offlineMap1.DisplayPointList = null;
            this.offlineMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offlineMap1.Location = new System.Drawing.Point(0, 0);
            this.offlineMap1.Name = "offlineMap1";
            this.offlineMap1.Size = new System.Drawing.Size(1012, 504);
            this.offlineMap1.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 504);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.offlineMap1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDisplayPos;
        private System.Windows.Forms.ComboBox cmbPicPointIndex;
        private System.Windows.Forms.PictureBox picCurrentImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMapLevel;
        private System.Windows.Forms.Button btnSetCenter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPicMulchIndex;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMapCurrentMapLevl;
        private System.Windows.Forms.TextBox txtMapCenterLat;
        private System.Windows.Forms.TextBox txtMapCenterLon;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnDisplayMulch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSelectLat;
        private System.Windows.Forms.TextBox txtSelectLon;
        private OffLineMap.SogouOfflineMap offlineMap1;
    }
}

