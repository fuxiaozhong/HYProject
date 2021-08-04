using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;

using MaterialSkin.Controls;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            bool flag = true;
            Task.Factory.StartNew(() =>
            {
                if (!Directory.Exists(AppParam.Instance.Save_Data_Path))
                    Directory.CreateDirectory(AppParam.Instance.Save_Data_Path);

                if (!Directory.Exists(AppParam.Instance.Save_Image_Path))
                    Directory.CreateDirectory(AppParam.Instance.Save_Image_Path);

                if (!Directory.Exists(AppParam.Instance.ProductLibrary))
                    Directory.CreateDirectory(AppParam.Instance.ProductLibrary);


                Log.RunLog("开始加载配置文件");
                ///初始化相机
                Cameras.Instance.InitializeCamera();
                if (AppParam.Instance.lightSource.OpenLightSource(AppParam.Instance.LightSourcePortName,
                                                             AppParam.Instance.LightSourceBaudRate,
                                                             AppParam.Instance.LightSourceParity,
                                                             AppParam.Instance.LightSourceDataBits,
                                                             AppParam.Instance.LightSourceStopBits))
                {
                    Log.RunLog("光源连接成功");
                    AppParam.Instance.lightSource.StateCH1 = true;
                    AppParam.Instance.lightSource.StateCH2 = true;
                    AppParam.Instance.lightSource.StateCH3 = true;
                    AppParam.Instance.lightSource.StateCH4 = true;
                    Thread.Sleep(100);
                    AppParam.Instance.lightSource.StateCH1 = false;
                    AppParam.Instance.lightSource.StateCH2 = false;
                    AppParam.Instance.lightSource.StateCH3 = false;
                    AppParam.Instance.lightSource.StateCH4 = false;
                }
                else
                {
                    Log.WriteErrorLog("光源连接失败");

                }

                ///参数PLC
                if (AppParam.Instance.Fx3uPLC == null)
                {
                    AppParam.Instance.Fx3uPLC = new HslCommunication.Profinet.Melsec.MelsecA1ENet();
                }

                AppParam.Instance.Fx3uPLC.IpAddress = AppParam.Instance.Fx3uPLC_IP;
                AppParam.Instance.Fx3uPLC.Port = AppParam.Instance.Fx3uPLC_Port;
                AppParam.Instance.Fx3uPLC.ConnectTimeOut = 1000;
                AppParam.Instance.Fx3uPLCResult = AppParam.Instance.Fx3uPLC.ConnectServer();
                if (AppParam.Instance.Fx3uPLCResult.IsSuccess)
                {
                    Log.RunLog("PLC连接成功");
                }
                else
                {
                    Log.WriteErrorLog("PLC连接失败");
                }


                DataLimit.Instance.Read();

                Log.RunLog("数据配置加载完成");
                //等待进度条加载完成
                while (flag) { }
                DialogResult = DialogResult.OK;
            });
            ///进度条
            Task.Factory.StartNew(() =>
            {
                while (label3.Width <= this.Width)
                {
                    label3.Width += 5;
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