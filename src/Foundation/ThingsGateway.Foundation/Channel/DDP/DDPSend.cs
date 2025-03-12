//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://thingsgateway.cn/
//  QQ群：605534569
//------------------------------------------------------------------------------

using System.Text;

namespace ThingsGateway.Foundation;

/// <summary>
/// <inheritdoc/>
/// </summary>
public class DDPSend : ISendMessage
{

    public int MaxLength => 300;
    public int Sign { get; set; }
    ReadOnlyMemory<byte> ReadOnlyMemory;
    string Id;
    byte Command;
    public DDPSend(ReadOnlyMemory<byte> readOnlyMemory, string id, byte command = 0x89)
    {

        ReadOnlyMemory = readOnlyMemory;
        Id = id;
        Command = command;
    }
    public void Build<TByteBlock>(ref TByteBlock byteBlock) where TByteBlock : IByteBlock
    {
        byteBlock.WriteByte(0x7b);
        byteBlock.WriteByte(Command);
        byteBlock.WriteUInt16(0x00);//len
        byteBlock.WriteNormalString(Id.Remove(0, 3), Encoding.UTF8);
        byteBlock.Write(ReadOnlyMemory.Span);
        byteBlock.WriteByte(0x7b);
        byteBlock.Position = 2;
        byteBlock.WriteUInt16((ushort)byteBlock.Length);//len
    }
}
