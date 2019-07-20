using ClientDaNative.Data;
using OPCAutomation;
using OpcClientDa.Models;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace ClientDaNative.Controllers
{
    public class DataReaderController : ApiController
    {
        public IList<OpcItem> Get()
        {
            return OpcData.GetOpcData()
                .Select(item =>
                {
                    item.Read((short)OPCDataSource.OPCDevice, out object value, out object quality, out object timeStamp);
                    return new OpcItem
                    {
                        ItemId = item.ItemID,
                        Value = value
                    };
                })
                .ToList();
        }
    }
}
