using System;
using System.ComponentModel;
using System.IO.Ports;

namespace ToolKit.CommunicAtion
{
    [Serializable]
    public class LightSource
    {
        private int _CH1;
        private int _CH2;
        private int _CH3;
        private int _CH4;

        private bool _StateCH1 = true;
        private bool _StateCH2 = true;
        private bool _StateCH3 = true;
        private bool _StateCH4 = true;

        /// <summary>
        /// 1通道值
        /// </summary>
        [CategoryAttribute("1通道值"), DescriptionAttribute("1通道值")]
        public int CH1
        {
            get
            {
                return this._CH1;
            }

            set
            {
                this._CH1 = value;
                Send();
            }
        }

        /// <summary>
        /// 2通道值
        /// </summary>
        [CategoryAttribute("2通道值"), DescriptionAttribute("2通道值")]
        public int CH2
        {
            get
            {
                return this._CH2;
            }

            set
            {
                this._CH2 = value;
                Send();
            }
        }

        /// <summary>
        /// 3通道值
        /// </summary>
        [CategoryAttribute("3通道值"), DescriptionAttribute("3通道值")]
        public int CH3
        {
            get
            {
                return this._CH3;
            }

            set
            {
                this._CH3 = value;
                Send();
            }
        }

        /// <summary>
        /// 4通道值
        /// </summary>
        [CategoryAttribute("4通道值"), DescriptionAttribute("4通道值")]
        public int CH4
        {
            get
            {
                return this._CH4;
            }

            set
            {
                this._CH4 = value;
                Send();
            }
        }

        /// <summary>
        /// 1通道状态 true打开 false关闭
        /// </summary>
        [CategoryAttribute("1通道状态 true打开 false关闭"), DescriptionAttribute("1通道状态 true打开 false关闭")]
        public bool StateCH1
        {
            get
            {
                return this._StateCH1;
            }

            set
            {
                this._StateCH1 = value;
                Send();
            }
        }

        /// <summary>
        /// 2通道状态 true打开 false关闭
        /// </summary>
        [CategoryAttribute("2通道状态 true打开 false关闭"), DescriptionAttribute("3通道状态 true打开 false关闭")]
        public bool StateCH2
        {
            get
            {
                return this._StateCH2;
            }

            set
            {
                this._StateCH2 = value;
                Send();
            }
        }

        /// <summary>
        /// 3通道状态 true打开 false关闭
        /// </summary>
        [CategoryAttribute("3通道状态 true打开 false关闭"), DescriptionAttribute("3通道状态 true打开 false关闭")]
        public bool StateCH3
        {
            get
            {
                return this._StateCH3;
            }

            set
            {
                this._StateCH3 = value;
                Send();
            }
        }

        /// <summary>
        /// 4通道状态 true打开 false关闭
        /// </summary>
        [CategoryAttribute("4通道状态 true打开 false关闭"), DescriptionAttribute("4通道状态 true打开 false关闭")]
        public bool StateCH4
        {
            get
            {
                return this._StateCH4;
            }

            set
            {
                this._StateCH4 = value;
                Send();
            }
        }

        /// <summary>
        /// 光源通讯连接状态
        /// </summary>
        [CategoryAttribute("光源通讯连接状态"), DescriptionAttribute("光源通讯连接状态")]
        public bool IsOpen
        {
            get
            {

                if (COMSerailPortDevice == null)
                {
                    return false;
                }

                return COMSerailPortDevice.IsOpen;
            }
        }

        [NonSerialized]
        private COMSerailPortDevice COMSerailPortDevice;


        /// <summary>
        /// 打开光源通讯
        /// </summary>
        /// <param name="portName">串口名</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="parity">奇偶校验</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        /// <returns></returns>
        public bool OpenLightSource(string portName, int baudRate = 19200, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            try
            {
                COMSerailPortDevice = new COMSerailPortDevice();
                bool sta = COMSerailPortDevice.OpenSerialPort(portName, baudRate, parity, dataBits, stopBits);

                return sta;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 打开光源通讯
        /// </summary>
        /// <param name="port">串口对象</param>
        /// <returns></returns>
        public bool OpenLightSource(SerialPort port)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                }
                COMSerailPortDevice = new COMSerailPortDevice();
                return COMSerailPortDevice.OpenSerialPort(port.PortName, port.BaudRate, port.Parity, port.DataBits, port.StopBits);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 发送指令
        /// </summary>
        private void Send()
        {
            string order = "S";
            string ch1 = CH1.ToString("D4");
            string ch2 = CH2.ToString("D4");
            string ch3 = CH3.ToString("D4");
            string ch4 = CH4.ToString("D4");
            if (StateCH1)
            {
                order += "A" + ch1 + "T";
            }
            else
            {
                order += "A" + ch1 + "F";
            }
            if (StateCH2)
            {
                order += "B" + ch2 + "T";
            }
            else
            {
                order += "B" + ch2 + "F";
            }
            if (StateCH3)
            {
                order += "C" + ch3 + "T";
            }
            else
            {
                order += "C" + ch3 + "F";
            }
            if (StateCH4)
            {
                order += "D" + ch4 + "T";
            }
            else
            {
                order += "D" + ch4 + "F";
            }

            order += "C#";

            if (COMSerailPortDevice != null && COMSerailPortDevice.IsOpen)
            {
                COMSerailPortDevice.SendSerailData(order);
            }
        }

        /// <summary>
        /// 关闭光源连接
        /// </summary>
        public void CloseLightSource()
        {
            StateCH1 = false;
            StateCH2 = false;
            StateCH3 = false;
            StateCH4 = false;
            if (COMSerailPortDevice != null && COMSerailPortDevice.IsOpen)
            {
                COMSerailPortDevice.CloseSerialPort();
            }
        }

        /// <summary>
        /// 关闭所有通道
        /// </summary>
        public void CloseAllCH()
        {
            StateCH1 = false;
            StateCH2 = false;
            StateCH3 = false;
            StateCH4 = false;
        }

        /// <summary>
        /// 打开所有通道
        /// </summary>
        public void OpenAllCH()
        {
            StateCH1 = true;
            StateCH2 = true;
            StateCH3 = true;
            StateCH4 = true;
        }
    }
}