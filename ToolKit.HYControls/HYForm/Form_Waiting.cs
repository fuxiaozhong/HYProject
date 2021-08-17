using System;
using System.Windows.Forms;

namespace ToolKit.HYControls.HYForm
{
    public partial class Form_Waiting : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        /// <summary>
        /// 等待窗体
        /// </summary>
        /// <param name="Method">等待室执行的事件方法</param>
        /// <param name="msg">等待时显示的信息</param>
        public Form_Waiting(EventHandler<EventArgs> Method, string msg = "数据加载中...")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(msg))
                label2.Text = msg;
            _Method = Method;
        }

        private EventHandler<EventArgs> _Method;
        private IAsyncResult asyncResult;

        private void timer1_Tick(object sender, EventArgs e)
        {
            processEllipse1.Value++;
            if (processEllipse1.Value >= 100)
            {
                processEllipse1.Value = 5;
            }
            if (asyncResult.IsCompleted)
            {
                timer1.Enabled = false;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FrmWaitingBox_Shown(object sender, EventArgs e)
        {
            asyncResult = _Method.BeginInvoke(sender, e, null, null);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}