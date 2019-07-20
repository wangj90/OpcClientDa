
using OPCAutomation;
using System.Collections.Generic;

namespace ClientDaNative.Data
{
    public static class OpcData
    {
        //Server Prog Id
        private const string OpcServerName = "Kepware.KEPServerEX.V5";
        //Server IP
        private const string OpcServerNode = "127.0.0.1";
        //通道名称
        private const string ChannelName = "Data Type Examples";
        //设备名称
        private const string DeviceName = "16 Bit Device";
        //组名称
        private const string GroupName = "R Registers";

        public static List<OPCItem> GetOpcData()
        {
            var server = new OPCServer();
            server.Connect(OpcServerName, OpcServerNode);
            var group = server.OPCGroups.Add(ChannelName + "." + DeviceName + "." + GroupName);

            return new List<OPCItem>
            {
                group.OPCItems.AddItem(group.Name + "." + "Boolean2",0),
                group.OPCItems.AddItem(group.Name + "." + "Double2",1),
                group.OPCItems.AddItem(group.Name + "." + "DWord2",2),
            };
        }
    }
}