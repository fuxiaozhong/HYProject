using System;
using System.IO.Ports;
using System.Text;

namespace ToolKit.CommunicAtion
{
    internal class COM_Serail_Port_Device
    {
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

        public void CloseSerialPort()
        {
            if (IsOpen)
            {
                m_serialPort.Close();
                m_serialPort = null;
            }
        }

        public bool IsOpen
        {
            get
            {
                return (m_serialPort != null && m_serialPort.IsOpen);
            }
        }

        public static string[] AllSerialPort()
        {
            return SerialPort.GetPortNames();
        }

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