using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpcClientDa.Models
{
    public class OpcItem
    {
        /// <summary>
        /// Item Id
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// Item值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Item质量
        /// </summary>
        public object Quality { get; internal set; }
        /// <summary>
        /// Item获取时间
        /// </summary>
        public object TimeStamp { get; internal set; }
    }
}