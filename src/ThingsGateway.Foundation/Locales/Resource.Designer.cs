﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThingsGateway.Foundation.Locales {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ThingsGateway.Foundation.Locales.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性，对
        ///   使用此强类型资源类的所有资源查找执行重写。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 必须继承 {0} 才能使用这个适配器 的本地化字符串。
        /// </summary>
        public static string AdapterTypeError {
            get {
                return ResourceManager.GetString("AdapterTypeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 当前适配器不支持对象发送 的本地化字符串。
        /// </summary>
        public static string CannotSendIRequestInfo {
            get {
                return ResourceManager.GetString("CannotSendIRequestInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不允许自由调用 {0} 进行赋值 的本地化字符串。
        /// </summary>
        public static string CannotSet {
            get {
                return ResourceManager.GetString("CannotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 该适配器不支持拼接发送 的本地化字符串。
        /// </summary>
        public static string CannotSplicingSend {
            get {
                return ResourceManager.GetString("CannotSplicingSend", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 此适配器已被其他终端使用，请重新创建对象 的本地化字符串。
        /// </summary>
        public static string CannotUseAdapterAgain {
            get {
                return ResourceManager.GetString("CannotUseAdapterAgain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 配置文件不能为空 的本地化字符串。
        /// </summary>
        public static string ConfigNotNull {
            get {
                return ResourceManager.GetString("ConfigNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 连接成功 的本地化字符串。
        /// </summary>
        public static string Connected {
            get {
                return ResourceManager.GetString("Connected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 正在连接 的本地化字符串。
        /// </summary>
        public static string Connecting {
            get {
                return ResourceManager.GetString("Connecting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 连接超时 的本地化字符串。
        /// </summary>
        public static string ConnectTimeout {
            get {
                return ResourceManager.GetString("ConnectTimeout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 数据长度错误 {0}  的本地化字符串。
        /// </summary>
        public static string DataLengthError {
            get {
                return ResourceManager.GetString("DataLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似  {0} 数据类型未实现 的本地化字符串。
        /// </summary>
        public static string DataTypeNotSupported {
            get {
                return ResourceManager.GetString("DataTypeNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ————————————————————
        ///        4字节数据转换格式：data=ABCD;可选ABCD=&gt;Big-Endian;BADC=&gt;;Big-Endian Byte Swap;CDAB=&gt;Little-Endian Byte Swap;DCBA=&gt;Little-Endian。
        ///        字符串长度：len=1。
        ///        数组长度：arraylen=1。
        ///        Bcd格式：bcd=C8421，可选C8421;C5421;C2421;C3;Gray。
        ///        字符格式：encoding=UTF-8，可选UTF-8;ASCII;Default;Unicode等。
        ///———————————————————— 的本地化字符串。
        /// </summary>
        public static string DefaultAddressDes {
            get {
                return ResourceManager.GetString("DefaultAddressDes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 断开连接 的本地化字符串。
        /// </summary>
        public static string Disconnected {
            get {
                return ResourceManager.GetString("Disconnected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 正在断开连接 的本地化字符串。
        /// </summary>
        public static string Disconnecting {
            get {
                return ResourceManager.GetString("Disconnecting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Dtu标识 {0} 连接成功 的本地化字符串。
        /// </summary>
        public static string DtuConnected {
            get {
                return ResourceManager.GetString("DtuConnected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 客户端未连接或寄存器设置不正确。寄存器必须设置id＝｛Dtu注册包｝ 的本地化字符串。
        /// </summary>
        public static string DtuNoConnectedWaining {
            get {
                return ResourceManager.GetString("DtuNoConnectedWaining", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 错误信息 的本地化字符串。
        /// </summary>
        public static string ErrorMessage {
            get {
                return ResourceManager.GetString("ErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 在事件 {0} 中发生错误 的本地化字符串。
        /// </summary>
        public static string EventError {
            get {
                return ResourceManager.GetString("EventError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 异常堆栈 的本地化字符串。
        /// </summary>
        public static string Exception {
            get {
                return ResourceManager.GetString("Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 数据长度不足，原始数据：{0} 的本地化字符串。
        /// </summary>
        public static string LengthShortError {
            get {
                return ResourceManager.GetString("LengthShortError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 接收数据正确，但主机并没有主动请求数据 的本地化字符串。
        /// </summary>
        public static string NotActiveQueryError {
            get {
                return ResourceManager.GetString("NotActiveQueryError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 主动断开 的本地化字符串。
        /// </summary>
        public static string ProactivelyDisconnect {
            get {
                return ResourceManager.GetString("ProactivelyDisconnect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 接收出现错误 {0}，错误代码 {1} 的本地化字符串。
        /// </summary>
        public static string ProcessReceiveError {
            get {
                return ResourceManager.GetString("ProcessReceiveError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 接收 的本地化字符串。
        /// </summary>
        public static string Receive {
            get {
                return ResourceManager.GetString("Receive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 在处理数据时发生错误 的本地化字符串。
        /// </summary>
        public static string ReceiveError {
            get {
                return ResourceManager.GetString("ReceiveError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 远程终端已关闭 的本地化字符串。
        /// </summary>
        public static string RemoteClose {
            get {
                return ResourceManager.GetString("RemoteClose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 发送 的本地化字符串。
        /// </summary>
        public static string Send {
            get {
                return ResourceManager.GetString("Send", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 新的SerialPort必须在连接状态 的本地化字符串。
        /// </summary>
        public static string SerialPortNotClient {
            get {
                return ResourceManager.GetString("SerialPortNotClient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 启动 的本地化字符串。
        /// </summary>
        public static string ServiceStarted {
            get {
                return ResourceManager.GetString("ServiceStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 停止 的本地化字符串。
        /// </summary>
        public static string ServiceStoped {
            get {
                return ResourceManager.GetString("ServiceStoped", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 字符串读写必须在寄存器地址中指定长度，例如 len=10; 的本地化字符串。
        /// </summary>
        public static string StringAddressError {
            get {
                return ResourceManager.GetString("StringAddressError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 转换失败-原始字节数组  {0}，长度 {1} 的本地化字符串。
        /// </summary>
        public static string TransBytesError {
            get {
                return ResourceManager.GetString("TransBytesError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 未知错误 的本地化字符串。
        /// </summary>
        public static string UnknowError {
            get {
                return ResourceManager.GetString("UnknowError", resourceCulture);
            }
        }
    }
}
