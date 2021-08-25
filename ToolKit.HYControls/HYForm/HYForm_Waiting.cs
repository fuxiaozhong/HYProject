using System;
using System.Windows.Forms;

namespace ToolKit.HYControls.HYForm
{
    public partial class HYForm_Waiting : Form
    {
        /// <summary>
        /// 等待窗体
        /// </summary>
        /// <param name="Method">等待室执行的事件方法</param>
        /// <param name="msg">等待时显示的信息</param>
        public HYForm_Waiting(EventHandler<EventArgs> Method, string msg = "数据加载中...")
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