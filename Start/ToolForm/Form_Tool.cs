using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NPOI.SS.Formula.Functions;

using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_Tool : BaseForm
    {
        public Form_Tool()
        {
            InitializeComponent();
        }


        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TabPage Page = new TabPage();
            switch (e.Node.Text)
            {
                case "串口通讯":
                    Page.Name = e.Node.Text;
                    Page.Text = e.Node.Text;
                    tabControlEx1.Controls.Add(Page);
                    break;
                case "TCP通讯":
                    Page.Name = e.Node.Text;
                    Page.Text = e.Node.Text;
                    tabControlEx1.Controls.Add(Page);
                    break;
                case "光源通讯":
                    Page.Name = e.Node.Text;
                    Page.Text = e.Node.Text;
                    tabControlEx1.Controls.Add(Page);
                    break;
            }

        }
    }
}
