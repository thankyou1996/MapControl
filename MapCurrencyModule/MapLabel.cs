using System;
using System.Collections.Generic;
using System.Text;

namespace MapCurrencyModule
{
    /// <summary>
    /// Label
    /// </summary>
    public class MapLabel
    {
        /// <summary>
        /// 内容
        /// </summary>
        private string content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        /// <summary>
        /// 偏移的尺寸
        /// </summary>
        public MapSize OffSet
        {
            get;
            set;
        }
    }
}
