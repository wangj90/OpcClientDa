using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;
using EQuality.OTIZ.SSP.WebReadTag.Common;
using OpcClientDa.Data;
using OpcClientDa.Models;

namespace OpcClientDa.Controllers
{
    public class DataReaderController : ApiController
    {
        public IList<OpcItem> Get()
        {
            var result = new List<OpcItem>();
            var device = DeviceData.GetDeviveData();
            try
            {
                device.Start();
                var timeDelayer = new TimeDelayer(5000);
                timeDelayer.Start();
                while (true)
                {
                    //当设备状态为连接状态时
                    if (device.Status == 1)
                    {
                        //循环读取每个tag的值
                        foreach (var tag in device.Groups[0].Tags)
                        {
                            //结果集中已经存在当前tag时,循环下一个
                            if (result.Any(r => r.ItemId.Equals(tag.Address)))
                            {
                                continue;
                            }
                            //根据tag的地址读取数据
                            var value = device.Read(tag.Address);
                            //获取到数据后，将数据加入到结果集中
                            if (value != null)
                            {
                                var opcItem = new OpcItem
                                {
                                    ItemId = tag.Address,
                                    Value = value
                                };
                                result.Add(opcItem);
                            }
                        }
                        //结果集的总数大于等于tag集总数时，退出while循环
                        if (result.Count >= device.Groups[0].Tags.Count)
                        {
                            break;
                        }
                    }
                    if (timeDelayer.IsTimeout())
                    {
                        throw new Exception("读取数据超时");
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                device.Abort();
            }
            return result;
        }
    }
}
