using System;
using System.Windows.Forms;

using HYProject.Model;

using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_Limit : HYBaseForm
    {
        public Form_Limit()
        {
            InitializeComponent();
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

        private void Form_Limit_Load(object sender, EventArgs e)
        {
            //屏蔽
            check_W_block.Checked = DataLimit.Instance.Check_W;
            check_M1_block.Checked = DataLimit.Instance.Check_M1;
            check_M2_block.Checked = DataLimit.Instance.Check_M2;
            check_PT_block.Checked = DataLimit.Instance.Check_PT;
            check_P_block.Checked = DataLimit.Instance.Check_P;
            check_KJ_block.Checked = DataLimit.Instance.Check_KJ;
            check_S1_block.Checked = DataLimit.Instance.Check_S1;
            check_S2_block.Checked = DataLimit.Instance.Check_S2;

            //下限
            num_W_LowerLimit.Value = DataLimit.Instance.LowerLimit_W;
            num_M1_LowerLimit.Value = DataLimit.Instance.LowerLimit_M1;
            num_M2_LowerLimit.Value = DataLimit.Instance.LowerLimit_M2;
            num_PT_LowerLimit.Value = DataLimit.Instance.LowerLimit_PT;
            num_P_LowerLimit.Value = DataLimit.Instance.LowerLimit_P;
            num_KJ_LowerLimit.Value = DataLimit.Instance.LowerLimit_KJ;
            num_S1_LowerLimit.Value = DataLimit.Instance.LowerLimit_S1;
            num_S2_LowerLimit.Value = DataLimit.Instance.LowerLimit_S2;

            //基准
            num_W_Standard.Value = DataLimit.Instance.Standard_W;
            num_M1_Standard.Value = DataLimit.Instance.Standard_M1;
            num_M2_Standard.Value = DataLimit.Instance.Standard_M2;
            num_PT_Standard.Value = DataLimit.Instance.Standard_PT;
            num_P_Standard.Value = DataLimit.Instance.Standard_P;
            num_KJ_Standard.Value = DataLimit.Instance.Standard_KJ;
            num_S1_Standard.Value = DataLimit.Instance.Standard_S1;
            num_S2_Standard.Value = DataLimit.Instance.Standard_S2;

            //上限
            num_W_UpperLimit.Value = DataLimit.Instance.UpperLimit_W;
            num_M1_UpperLimit.Value = DataLimit.Instance.UpperLimit_M1;
            num_M2_UpperLimit.Value = DataLimit.Instance.UpperLimit_M2;
            num_PT_UpperLimit.Value = DataLimit.Instance.UpperLimit_PT;
            num_P_UpperLimit.Value = DataLimit.Instance.UpperLimit_P;
            num_KJ_UpperLimit.Value = DataLimit.Instance.UpperLimit_KJ;
            num_S1_UpperLimit.Value = DataLimit.Instance.UpperLimit_S1;
            num_S2_UpperLimit.Value = DataLimit.Instance.UpperLimit_S2;

            //补偿
            num_W_offset.Value = DataLimit.Instance.Offset_W;
            num_M1_offset.Value = DataLimit.Instance.Offset_M1;
            num_M2_offset.Value = DataLimit.Instance.Offset_M2;
            num_PT_offset.Value = DataLimit.Instance.Offset_PT;
            num_P_offset.Value = DataLimit.Instance.Offset_P;
            num_KJ_offset.Value = DataLimit.Instance.Offset_KJ;
            num_S1_offset.Value = DataLimit.Instance.Offset_S1;
            num_S2_offset.Value = DataLimit.Instance.Offset_S2;
        }

        private void Button_save_Click(object sender, EventArgs e)
        {
            //屏蔽
            DataLimit.Instance.Check_W = check_W_block.Checked;
            DataLimit.Instance.Check_M1 = check_M1_block.Checked;
            DataLimit.Instance.Check_M2 = check_M2_block.Checked;
            DataLimit.Instance.Check_PT = check_PT_block.Checked;
            DataLimit.Instance.Check_P = check_P_block.Checked;
            DataLimit.Instance.Check_KJ = check_KJ_block.Checked;
            DataLimit.Instance.Check_S1 = check_S1_block.Checked;
            DataLimit.Instance.Check_S2 = check_S2_block.Checked;

            //下限
            DataLimit.Instance.LowerLimit_W = num_W_LowerLimit.Value;
            DataLimit.Instance.LowerLimit_M1 = num_M1_LowerLimit.Value;
            DataLimit.Instance.LowerLimit_M2 = num_M2_LowerLimit.Value;
            DataLimit.Instance.LowerLimit_PT = num_PT_LowerLimit.Value;
            DataLimit.Instance.LowerLimit_P = num_P_LowerLimit.Value;
            DataLimit.Instance.LowerLimit_KJ = num_KJ_LowerLimit.Value;
            DataLimit.Instance.LowerLimit_S1 = num_S1_LowerLimit.Value;
            DataLimit.Instance.LowerLimit_S2 = num_S2_LowerLimit.Value;

            //基准
            DataLimit.Instance.Standard_W = num_W_Standard.Value;
            DataLimit.Instance.Standard_M1 = num_M1_Standard.Value;
            DataLimit.Instance.Standard_M2 = num_M2_Standard.Value;
            DataLimit.Instance.Standard_PT = num_PT_Standard.Value;
            DataLimit.Instance.Standard_P = num_P_Standard.Value;
            DataLimit.Instance.Standard_KJ = num_KJ_Standard.Value;
            DataLimit.Instance.Standard_S1 = num_S1_Standard.Value;
            DataLimit.Instance.Standard_S2 = num_S2_Standard.Value;

            //上限
            DataLimit.Instance.UpperLimit_W = num_W_UpperLimit.Value;
            DataLimit.Instance.UpperLimit_M1 = num_M1_UpperLimit.Value;
            DataLimit.Instance.UpperLimit_M2 = num_M2_UpperLimit.Value;
            DataLimit.Instance.UpperLimit_PT = num_PT_UpperLimit.Value;
            DataLimit.Instance.UpperLimit_P = num_P_UpperLimit.Value;
            DataLimit.Instance.UpperLimit_KJ = num_KJ_UpperLimit.Value;
            DataLimit.Instance.UpperLimit_S1 = num_S1_UpperLimit.Value;
            DataLimit.Instance.UpperLimit_S2 = num_S2_UpperLimit.Value;

            //补偿
            DataLimit.Instance.Offset_W = num_W_offset.Value;
            DataLimit.Instance.Offset_M1 = num_M1_offset.Value;
            DataLimit.Instance.Offset_M2 = num_M2_offset.Value;
            DataLimit.Instance.Offset_PT = num_PT_offset.Value;
            DataLimit.Instance.Offset_P = num_P_offset.Value;
            DataLimit.Instance.Offset_KJ = num_KJ_offset.Value;
            DataLimit.Instance.Offset_S1 = num_S1_offset.Value;
            DataLimit.Instance.Offset_S2 = num_S2_offset.Value;

            DataLimit.Instance.Save();
            HYMessageBox.Show("保存成功", "提示");
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            Form_Limit_Load(sender, e);
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}