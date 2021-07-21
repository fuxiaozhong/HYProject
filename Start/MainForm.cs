using System;
using System.Windows.Forms;

using HalconDotNet;

using ToolKit.CamreaSDK;
using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

namespace HYProject
{
    public partial class MainForm : Form

    {
        public MainForm()
        {
            InitializeComponent();
            HOperatorSet.SetSystem("clip_region", "false");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            autoAddDisplayWindowControl1.Count = 8;
            panel_Log.Controls.Add(Form_Log.Instance);
            Form_Log.Instance.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            autoAddDisplayWindowControl1[0].Disp_Image(autoAddDisplayWindowControl1[0].Open_Image());
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            autoAddDisplayWindowControl1.Count = (int)numericUpDown1.Value;
        }
    }
}