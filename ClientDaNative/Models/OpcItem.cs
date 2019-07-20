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
        /// 值
        /// </summary>
        public Object Value { get; set; }
    }
}