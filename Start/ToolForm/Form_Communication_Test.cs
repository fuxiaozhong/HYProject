using System.Windows.Forms;

namespace HYProject.ToolForm
{
    public partial class Form_Communication_Test : Form
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

        public Form_Communication_Test()
        {
            InitializeComponent();
        }
    }
}