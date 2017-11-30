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
            string strMapFilePath = Environment.CurrentDirectory + "\\OnlineMapFile\\Map_Basic.html";
            onlineMap1.Init(strMapFilePath);
        }
    }
}
