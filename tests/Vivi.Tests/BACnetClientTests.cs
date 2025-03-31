using System.Net.BACnet;

namespace Vivi.Tests
{
    public class BACnetClientTests
    {
        // 测试设备发现及读取属性功能
        [Fact]
        public void Test_DeviceDiscovery_And_ReadProperty()
        {
            // 初始化 BACnet 客户端，使用 BACnet-IP 协议传输，端口 0xBAC0
            BACnetClient bacnet = new BACnetClient(new BACnetIpUdpProtocolTransport(0xBAC0));

            // 注册设备发现回调事件
            bacnet.OnIam += (sender, adr, deviceId, maxApdu, segmentation, vendorId) =>
            {
                // 打印发现的设备信息
                Console.WriteLine($"发现设备 ID: {deviceId}, 地址: {adr}");
                // 调用读取属性方法，获取设备 Analog Input 1 的值
                ReadProperty(bacnet, adr, deviceId);
            };

            // 启动 BACnet 客户端
            bacnet.Start();
            // 打印启动信息
            Console.WriteLine("正在广播设备请求...");
            // 发送 Who-Is 请求，广播设备发现
            bacnet.WhoIs();

            Thread.Sleep(3000);
            Assert.True(false);
        }

        // 读取设备属性的方法
        // 该方法用于读取设备 Analog Input 1 的 Present Value
        void ReadProperty(BACnetClient bacnet, BACnetAddress adr, uint deviceId)
        {
            try
            {
                // 创建 BACnet 对象标识符，表示 Analog Input 类型，实例号为 1
                BACnetObjectId objectId = new BACnetObjectId(BACnetObjectTypes.OBJECT_ANALOG_INPUT, 1);

                // 调用 ReadPropertyRequest 方法读取属性
                // 正确方式：直接传入 BACnetPropertyIds.PROP_READ_ONLY
                if (bacnet.ReadPropertyRequest(adr, objectId, BACnetPropertyIds.PROP_READ_ONLY, out var values))
                {
                    // 打印读取到的值
                    Console.WriteLine($"设备 {deviceId} AI-1 值: {values[0].Value}");
                    Assert.True(true);
                }
                else
                {
                    // 如果读取失败，则打印错误信息
                    Console.WriteLine($"读取失败: 设备 {deviceId}");
                    Assert.True(false);
                }
            }
            catch (Exception ex)
            {
                // 捕获异常并打印错误信息
                Console.WriteLine($"错误: {ex.Message}");
            }
        }
    }
}
