using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HYProject.Model;

using ToolKit.DisplayWindow;

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


                Log.RunLog("开始加载配置文件");
                Cameras.Instance.InitCamera("Cam1", CameraType.海康威视);

                Log.RunLog("数据配置加载完成");
                //等待进度条加载完成
                while (flag) { }
                DialogResult = DialogResult.OK;
            });

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
            DialogResult = DialogResult.Cancel;
        }
    }
}