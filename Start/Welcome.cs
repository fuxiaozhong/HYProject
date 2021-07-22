using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Log.RunLog("开始加载配置文件");
                //Cameras.Instance.InitCamera("Cam1", CameraType.海康威视);
                //Cameras.Instance["Cam1"].Start_Real_Mode();
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