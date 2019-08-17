namespace MapControl
{
    partial class MapControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sogouOfflineMap1 = new global::MapControl.SogouOfflineMap();
            this.baiduOnlineMap1 = new global::MapControl.BaiduOnlineMap();
            this.googleOnlineMap1 = new global::MapControl.GoogleOnlineMap();
            this.SuspendLayout();
            // 
            // sogouOfflineMap1
            // 
            this.sogouOfflineMap1.BackColor = System.Drawing.SystemColors.Control;
            this.sogouOfflineMap1.CurrentMapLevel = 0;
            this.sogouOfflineMap1.CurrentMouseMapPoint = null;
            this.sogouOfflineMap1.DisplayMulchList = null;
            this.sogouOfflineMap1.DisplayPointList = null;
            this.sogouOfflineMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sogouOfflineMap1.Location = new System.Drawing.Point(0, 0);
            this.sogouOfflineMap1.mapType = global::MapControl.MapType.SogouOffLineMap;
            this.sogouOfflineMap1.Name = "sogouOfflineMap1";
            this.sogouOfflineMap1.Size = new System.Drawing.Size(433, 305);
            this.sogouOfflineMap1.TabIndex = 0;
            // 
            // baiduOnlineMap1
            // 
            this.baiduOnlineMap1.CurrentMapLevel = 0;
            this.baiduOnlineMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baiduOnlineMap1.Location = new System.Drawing.Point(0, 0);
            this.baiduOnlineMap1.mapType = global::MapControl.MapType.BaiduOnlineMap;
            this.baiduOnlineMap1.Name = "baiduOnlineMap1";
            this.baiduOnlineMap1.Size = new System.Drawing.Size(433, 305);
            this.baiduOnlineMap1.TabIndex = 1;
            // 
            // googleOnlineMap1
            // 
            this.googleOnlineMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.googleOnlineMap1.Location = new System.Drawing.Point(0, 0);
            this.googleOnlineMap1.mapType = global::MapControl.MapType.GoogleOnlineMap;
            this.googleOnlineMap1.Name = "googleOnlineMap1";
            this.googleOnlineMap1.Size = new System.Drawing.Size(433, 305);
            this.googleOnlineMap1.TabIndex = 2;
            this.googleOnlineMap1.Visible = false;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.googleOnlineMap1);
            this.Controls.Add(this.baiduOnlineMap1);
            this.Controls.Add(this.sogouOfflineMap1);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(433, 305);
            this.Load += new System.EventHandler(this.MapControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SogouOfflineMap sogouOfflineMap1;
        private BaiduOnlineMap baiduOnlineMap1;
        private GoogleOnlineMap googleOnlineMap1;
    }
}
