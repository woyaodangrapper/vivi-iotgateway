﻿using System.Threading;
using System.Threading.Tasks;

using TouchSocket.Resources;

namespace ThingsGateway.Foundation.Adapter.Modbus
{
    public class ModbusTcp : ReadWriteDevicesTcpClientBase
    {
        public ModbusTcpDataHandleAdapter DataHandleAdapter = new();

        public ModbusTcp(TcpClient tcpClient) : base(tcpClient)
        {
            ThingsGatewayBitConverter = new ThingsGatewayBitConverter(EndianType.Big);
            RegisterByteLength = 2;
        }
        public bool IsCheckMessageId { get; set; }

        public byte Station { get; set; } = 1;

        public override async Task<OperResult<byte[]>> ReadAsync(string address, int length, CancellationToken token = default)
        {
            try
            {
                await ConnectAsync();
                var commandResult = ModbusHelper.GetReadModbusCommand(address, length, Station);
                if (commandResult.IsSuccess)
                {
                    var item = commandResult.Content;
                    var result = TcpClient.GetTGWaitingClient(new()).SendThenResponse(item, TimeOut, token);
                    if (result.RequestInfo is MessageBase collectMessage)
                    {
                        return collectMessage;
                    }
                }
                else
                {
                    return OperResult.CreateFailedResult<byte[]>(commandResult);
                }
            }
            catch (Exception ex)
            {
                return new OperResult<byte[]>(ex);
            }
            return new OperResult<byte[]>(TouchSocketStatus.UnknownError.GetDescription());

        }

        public override void SetDataAdapter()
        {
            DataHandleAdapter = new();
            DataHandleAdapter.IsCheckMessageId = IsCheckMessageId;
            TcpClient.SetDataHandlingAdapter(DataHandleAdapter);
        }
        public override async Task<OperResult> WriteAsync(string address, byte[] value, CancellationToken token = default)
        {
            try
            {
                await ConnectAsync();
                var commandResult = ModbusHelper.GetWriteModbusCommand(address, value, Station);
                if (commandResult.IsSuccess)
                {
                    var result = TcpClient.GetTGWaitingClient(new()).SendThenResponse(commandResult.Content, TimeOut, token);
                    if (result.RequestInfo is MessageBase collectMessage)
                    {
                        return collectMessage;
                    }
                }
                else
                {
                    return OperResult.CreateFailedResult<bool[]>(commandResult);
                }
            }
            catch (Exception ex)
            {
                return new OperResult<bool[]>(ex);
            }
            return new OperResult<byte[]>(TouchSocketStatus.UnknownError.GetDescription());

        }

        public override async Task<OperResult> WriteAsync(string address, bool[] value, CancellationToken token = default)
        {
            try
            {
                await ConnectAsync();
                var commandResult = ModbusHelper.GetWriteBoolModbusCommand(address, value, Station);
                if (commandResult.IsSuccess)
                {
                    var result = TcpClient.GetTGWaitingClient(new()).SendThenResponse(commandResult.Content, TimeOut, token);
                    if (result.RequestInfo is MessageBase collectMessage)
                    {
                        return collectMessage;
                    }
                }
                else
                {
                    return OperResult.CreateFailedResult<bool[]>(commandResult);
                }
            }
            catch (Exception ex)
            {
                return new OperResult<bool[]>(ex);
            }
            return new OperResult<byte[]>(TouchSocketStatus.UnknownError.GetDescription());

        }
    }
}
