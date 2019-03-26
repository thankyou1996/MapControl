using System;
using System.Collections.Generic;
using System.Text;

namespace MapCurrencyModule
{
    /// <summary>
    /// Icon
    /// </summary>
    public class MapIcon
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        private MapSize size = new MapSize { Width = 0, Height = 0 };

        /// <summary>
        /// 尺寸
        /// </summary>
        public MapSize Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
