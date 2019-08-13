using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MapControlUse
{
    [System.Runtime.InteropServices.ComVisible(true)]   //窗体与脚本交互设置
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(new Uri(Environment.CurrentDirectory + "\\GoogleMapTest.html"));
            webBrowser1.Navigate(new Uri("https://ie.itzmx.com/"));
            //webBrowser1.Navigate(new Uri("http://www.google.cn/maps"));
        }
    }
}
