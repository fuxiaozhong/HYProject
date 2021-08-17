using System;
using System.Windows.Forms;

namespace ToolKit.HYControls.HYForm
{
    public partial class Form_Edit : BaseForm
    {
        public Form_Edit(string text, bool checkEmpty = true, string type = "string")
        {
            InitializeComponent();
            this.RheckEmpty = checkEmpty;
            label1.Text = text;
            Type = type;
        }

        private string value;
        private string Type = "string";
        private bool RheckEmpty = true;

        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
                textBox1.Text = value.ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (RheckEmpty && textBox1.Text.Length == 0)
            {
                MessageBox.Show("输入不能为空", "输入提示", MessageBoxButtons.OK);
                return;
            }
            if (Type == "string")
            {
                Value = textBox1.Text;
            }
            else if (Type == "int")
            {
                try
                {
                    int.Parse(textBox1.Text);
                    Value = textBox1.Text;
                }
                catch
                {
                    MessageBox.Show("输入类型有误", "输入提示", MessageBoxButtons.OK);
                    return;
                }
            }
            else if (Type == "double")
            {
                try
                {
                    double.Parse(textBox1.Text);
                    Value = textBox1.Text;
                }
                catch
                {
                    MessageBox.Show("输入类型有误", "输入提示", MessageBoxButtons.OK);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}