using System.Windows.Forms;

using HYProject.Model;

namespace HYProject.ToolForm
{
    public partial class Form_DateVsualization : Form
    {
        private static Form_DateVsualization instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static Form_DateVsualization Instance
        {
            get
            {
                //先判断是否存在，不存在再加锁处理
                if (instance == null)
                {
                    //在同一个时刻加了锁的那部分程序只有一个线程可以进入
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Form_DateVsualization();
                            instance.TopLevel = false;
                            instance.Dock = DockStyle.Fill;
                            instance.Show();
                        }
                    }
                }
                return instance;
            }
        }

        public void RefreshData()
        {
            label_L_W.Text = DataLimit.Instance.LowerLimit_W.ToString();
            label_L_PT.Text = DataLimit.Instance.LowerLimit_PT.ToString();
            label_L_M1.Text = DataLimit.Instance.LowerLimit_M1.ToString();
            label_L_M2.Text = DataLimit.Instance.LowerLimit_M2.ToString();
            label_L_P.Text = DataLimit.Instance.LowerLimit_P.ToString();
            label_L_KJ.Text = DataLimit.Instance.LowerLimit_KJ.ToString();
            label_L_S1.Text = DataLimit.Instance.LowerLimit_S1.ToString();
            label_L_S2.Text = DataLimit.Instance.LowerLimit_S2.ToString();

            label_S_W.Text = DataLimit.Instance.Standard_W.ToString();
            label_S_PT.Text = DataLimit.Instance.Standard_PT.ToString();
            label_S_M1.Text = DataLimit.Instance.Standard_M1.ToString();
            label_S_M2.Text = DataLimit.Instance.Standard_M2.ToString();
            label_S_P.Text = DataLimit.Instance.Standard_P.ToString();
            label_S_KJ.Text = DataLimit.Instance.Standard_KJ.ToString();
            label_S_S1.Text = DataLimit.Instance.Standard_S1.ToString();
            label_S_S2.Text = DataLimit.Instance.Standard_S2.ToString();

            label_U_W.Text = DataLimit.Instance.UpperLimit_W.ToString();
            label_U_PT.Text = DataLimit.Instance.UpperLimit_PT.ToString();
            label_U_M1.Text = DataLimit.Instance.UpperLimit_M1.ToString();
            label_U_M2.Text = DataLimit.Instance.UpperLimit_M2.ToString();
            label_U_P.Text = DataLimit.Instance.UpperLimit_P.ToString();
            label_U_KJ.Text = DataLimit.Instance.UpperLimit_KJ.ToString();
            label_U_S1.Text = DataLimit.Instance.UpperLimit_S1.ToString();
            label_U_S2.Text = DataLimit.Instance.UpperLimit_S2.ToString();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        private Form_DateVsualization()
        {
            InitializeComponent();
        }
    }
}