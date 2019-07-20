using System.Collections.Generic;
using xcDEVICE;
using static xcCOMMON.clsEnum;

namespace OpcClientDa.Data
{
    public static class DeviceData
    {
        //OPC Server Prog Id
        private const string OpcServerName = "Kepware.KEPServerEX.V5";
        //OPC Server IP
        private const string OpcServerNode = "127.0.0.1";
        //OPC Server激活标识
        private const bool OpcServerActive = true;
        //模式:OPC服务器
        private const Model ServerModel = Model.OPCServer;
        //OPC设备名称
        private const string DeviceName = "Data Type Examples.16 Bit Device";
        //OPC组名称
        private const string GroupName = "R Registers";

        public static Device GetDeviveData()
        {
            return new Device
            {
                OPCServerName = OpcServerName,
                OPCServerNode = OpcServerNode,
                Name = DeviceName,
                OPCServerActive = OpcServerActive,
                Model = ServerModel,
                //组集合
                Groups = new List<Group>
                {
                    new Group
                    {
                        Name = GroupName,
                        //标签集合
                        Tags = new List<Tag>
                        {
                            new Tag
                            {
                                Name = "Boolean2",
                                Address = DeviceName + "." + GroupName + ".Boolean2",
                                DataType = DataType._Default,
                                Length = 1
                            },
                            new Tag
                            {
                                Name = "Double2",
                                Address = DeviceName + "." + GroupName + ".Double2",
                                DataType = DataType._Default,
                                Length = 1
                            },
                            new Tag
                            {
                                Name = "DWord2",
                                Address = DeviceName + "." + GroupName + ".DWord2",
                                DataType = DataType._Default,
                                Length = 1
                            }
                        }
                    }
                }
            };
        }
    }
}