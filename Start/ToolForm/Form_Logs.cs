using System.Drawing;
using System.Windows.Forms;

namespace HYProject.ToolForm
{
    public partial class Form_Logs : ToolKit.HYControls.HYForm.HYBaseForm
    {
        private static Form_Logs _Form_Logs = null;
        private static object _Lock = new object();

        public static Form_Logs Instance
        {
            get
            {
                if (_Form_Logs == null) //双if +lock
                {
                    lock (_Lock)
                    {
                        if (_Form_Logs == null)
                        {
                            _Form_Logs = new Form_Logs();
                            _Form_Logs.TopLevel = false;
                            _Form_Logs.TopMost = false;
                            _Form_Logs.Dock = DockStyle.Fill;
                            _Form_Logs.HideAll = true;
                        }
                    }
                }
                return _Form_Logs;
            }
        }

        private Form_Logs()
        {
            InitializeComponent();
        }

        public void OutputMsg(string msg, Color color)
        {
            hyLogs1.OutputMsg(msg, color);
        }
    }
}