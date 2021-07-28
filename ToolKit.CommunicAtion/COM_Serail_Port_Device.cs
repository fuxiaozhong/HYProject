using System;
using System.IO.Ports;
using System.Text;

namespace ToolKit.CommunicAtion
{
    internal class COM_Serail_Port_Device
    {
        /// <summary>
        /// 接受消息回调事件
        /// </summary>
        public event EventHandler<SerialEventArgs> SigDataReceived;

        private enum SerialDataType
        {
            HEX,
            ASCII,
            UTF8,
            UNICODE,
        }

        private SerialPort m_serialPort = null;
        private int m_type = (int)SerialDataType.ASCII;

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity"> 奇偶校验</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        /// <returns></returns>
        public bool OpenSerialPort(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            try
            {
                if (m_serialPort != null)
                {
                    m_serialPort.Close();
                }
                m_serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                m_serialPort.Open();
                m_serialPort.DataReceived += new SerialDataReceivedEventHandler(OnReceiveSerailData);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("open error:", e);
                return false;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void CloseSerialPort()
        {
            if (IsOpen)
            {
                m_serialPort.Close();
                m_serialPort = null;
            }
        }

        /// <summary>
        /// 是否打开
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return (m_serialPort != null && m_serialPort.IsOpen);
            }
        }

        /// <summary>
        /// 枚举全部串口
        /// </summary>
        /// <returns></returns>
        public static string[] AllSerialPort()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendSerailData(string msg)
        {
            if (IsOpen)
            {
                try
                {
                    m_serialPort.Write(msg);
                    return true;
                }
                catch (Exception err)
                {
                    Console.WriteLine("send err:", err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置编码类型
        /// </summary>
        public int SetSerailType
        {
            get { return m_type; }
            set
            {
                if (value > 3)
                {
                    m_type = (int)SerialDataType.ASCII;
                }
                else
                {
                    m_type = value;
                }
            }
        }

        private void ParseSerailData(byte[] data)
        {
            string strResult;
            // 数据转换
            if (m_type == (int)SerialDataType.HEX)
            {
                StringBuilder strBuild = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    strBuild.AppendFormat("{0:x2}" + " ", data[i]);
                }
                strResult = strBuild.ToString().ToUpper();
            }
            else if (m_type == (int)SerialDataType.ASCII)
            {
                strResult = new ASCIIEncoding().GetString(data);
            }
            else if (m_type == (int)SerialDataType.UTF8)
            {
                strResult = new UTF8Encoding().GetString(data);
            }
            else
            {
                strResult = new UnicodeEncoding().GetString(data);
            }

            SigDataReceived?.Invoke(this, new SerialEventArgs() { Code = strResult.Trim() });
        }

        private void OnReceiveSerailData(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[m_serialPort.BytesToRead];
            int result = m_serialPort.Read(ReDatas, 0, ReDatas.Length);
            if (result <= 0)
            {
                return;
            }
            ParseSerailData(ReDatas);
            m_serialPort.DiscardInBuffer();
        }
    }

    public class SerialEventArgs
    {
        public SerialEventArgs()
        {
        }

        public string Code { get; internal set; }
    }
}