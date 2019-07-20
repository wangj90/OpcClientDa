using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EQuality.OTIZ.SSP.WebReadTag.Common
{
    public class TimeDelayer
    {
        private int _timeOut;
        private DateTime _startTime;
        public TimeDelayer(int timeOut)
        {
            this._timeOut = timeOut;
        }
        public void Start()
        {
            _startTime = DateTime.Now;
        }
        public bool IsTimeout()
        {
            if (DateTime.Now.Subtract(_startTime).TotalMilliseconds >= _timeOut)
            {
                return true;
            }
            return false;
        }
    }
}