using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;

using ToolKit.HYControls.HYForm;

namespace HYProject
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool flag = true;
            Task.Factory.StartNew(() =>
            {
                while (flag)
                {
                    if (stopwatch.ElapsedMilliseconds >= 30 * 1000)
                    {
                        HYMessageBox.ShowError("程序初始化超时:10S");
                        DialogResult = DialogResult.OK;
                        break;
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                if (!Directory.Exists(AppParam.Instance.Save_Data_Path))
                    Directory.CreateDirectory(AppParam.Instance.Save_Data_Path);

                if (!Directory.Exists(AppParam.Instance.Save_Image_Path))
                    Directory.CreateDirectory(AppParam.Instance.Save_Image_Path);

                if (!Directory.Exists(AppParam.Instance.ProductLibrary))
                    Directory.CreateDirectory(AppParam.Instance.ProductLibrary);

                Log.WriteRunLog("开始加载配置文件");
                //初始化相机
                Cameras.Instance.InitializeCamera();

                AppParam.Instance.TCPSocketServer_Cam1 = new ToolKit.CommunicAtion.TCPSocketServer(AppParam.Instance.TCPServerIPAddress_Cam1, AppParam.Instance.TCPServerPort_Cam1);
                AppParam.Instance.TCPSocketServer_Cam1.SocketReceiveMessage += Work.TCPSocketServer_SocketReceiveMessage1;
                AppParam.Instance.TCPSocketServer_Cam1.ClientsConnect += Work.TCPSocketServer_ClientsConnect1;
                AppParam.Instance.TCPSocketServer_Cam1.ClientsLoss += Work.TCPSocketServer_ClientsLoss1;
                Log.WriteRunLog(AppParam.Instance.TCPSocketServer_Cam1.StartListen() ? "Cam1_TCP服务器打开成功" : "Cam1_TCP服务器打开失败");

                AppParam.Instance.TCPSocketServer_Cam2 = new ToolKit.CommunicAtion.TCPSocketServer(AppParam.Instance.TCPServerIPAddress_Cam2, AppParam.Instance.TCPServerPort_Cam2);
                AppParam.Instance.TCPSocketServer_Cam2.SocketReceiveMessage += Work.TCPSocketServer_SocketReceiveMessage2;
                AppParam.Instance.TCPSocketServer_Cam2.ClientsConnect += Work.TCPSocketServer_ClientsConnect2;
                AppParam.Instance.TCPSocketServer_Cam2.ClientsLoss += Work.TCPSocketServer_ClientsLoss2;
                Log.WriteRunLog(AppParam.Instance.TCPSocketServer_Cam2.StartListen() ? "Cam2_TCP服务器打开成功" : "Cam2_TCP服务器打开失败");

                AppParam.Instance.TCPSocketServer_Cam3 = new ToolKit.CommunicAtion.TCPSocketServer(AppParam.Instance.TCPServerIPAddress_Cam3, AppParam.Instance.TCPServerPort_Cam3);
                AppParam.Instance.TCPSocketServer_Cam3.SocketReceiveMessage += Work.TCPSocketServer_SocketReceiveMessage3;
                AppParam.Instance.TCPSocketServer_Cam3.ClientsConnect += Work.TCPSocketServer_ClientsConnect3;
                AppParam.Instance.TCPSocketServer_Cam3.ClientsLoss += Work.TCPSocketServer_ClientsLoss3;
                Log.WriteRunLog(AppParam.Instance.TCPSocketServer_Cam3.StartListen() ? "Cam3_TCP服务器打开成功" : "Cam3_TCP服务器打开失败");

                CalibrationData.Instance = (CalibrationData)Serialization.Read("CalibrationData");

                if (AppParam.Instance.lightSource.OpenLightSource(AppParam.Instance.LightSourcePortName,
                                                             AppParam.Instance.LightSourceBaudRate,
                                                             AppParam.Instance.LightSourceParity,
                                                             AppParam.Instance.LightSourceDataBits,
                                                             AppParam.Instance.LightSourceStopBits))
                {

                    AppParam.Instance.lightSource.StateCH1 = true;
                    AppParam.Instance.lightSource.StateCH2 = true;
                    AppParam.Instance.lightSource.StateCH3 = true;
                    AppParam.Instance.lightSource.StateCH4 = true;
                    Thread.Sleep(200);
                    AppParam.Instance.lightSource.StateCH1 = false;
                    AppParam.Instance.lightSource.StateCH2 = false;
                    AppParam.Instance.lightSource.StateCH3 = false;
                    AppParam.Instance.lightSource.StateCH4 = false;
                    Log.WriteRunLog("光源连接成功");

                }
                else
                {
                    Log.WriteErrorLog("光源连接失败");
                }

                //参数PLC
                //if (AppParam.Instance.Fx3uPLC == null)
                //{
                //    AppParam.Instance.Fx3uPLC = new HslCommunication.Profinet.Melsec.MelsecA1ENet();
                //}

                //AppParam.Instance.Fx3uPLC.IpAddress = AppParam.Instance.Fx3uPLC_IP;
                //AppParam.Instance.Fx3uPLC.Port = AppParam.Instance.Fx3uPLC_Port;
                //AppParam.Instance.Fx3uPLC.ConnectTimeOut = 1000;
                //AppParam.Instance.Fx3uPLCResult = AppParam.Instance.Fx3uPLC.ConnectServer();
                //if (AppParam.Instance.Fx3uPLCResult.IsSuccess)
                //{
                //    Log.WriteRunLog("PLC连接成功");
                //}
                //else
                //{
                //    Log.WriteErrorLog("PLC连接失败");
                //}

                //DataLimit.Instance.Read();

                Log.WriteRunLog("数据配置加载完成");
                //等待进度条加载完成
                while (flag) { }
                DialogResult = DialogResult.OK;
            });
            //进度条
            Task.Factory.StartNew(() =>
            {
                while (label3.Width <= this.Width)
                {
                    label3.Width += 2;
                    label3.Text = ((double)label3.Width / (double)this.Width * 100).ToString("0.00") + "%";
                    if ((double)label3.Width / (double)this.Width * 100 >= 100)
                    {
                        label3.Text = "100 %";
                        flag = false;
                        break;
                    }
                    Thread.Sleep(20);
                }
            });
        }



        private void Label4_Click(object sender, EventArgs e)
        {
            Cameras.Instance.CloseCamera();
            DialogResult = DialogResult.Cancel;
        }
    }
}