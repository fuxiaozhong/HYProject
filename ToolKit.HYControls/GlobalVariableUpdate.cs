using System;
using System.Windows.Forms;

namespace ToolKit.HYControls
{
    public partial class GlobalVariableUpdate : Form
    {
        public GlobalVariableUpdate(ref string type, ref string name, ref string value, ref string mark)
        {
            InitializeComponent();
            comboBox1.Text = type;
            textBox_Name.Text = name;
            textBox_mark.Text = mark;

            if (name == "")
            {
                Text = "添加";
            }
            else
            {
                Text = "修改";
                textBox_Name.Enabled = false;
                comboBox1.Enabled = false;
                if (comboBox1.Text == "Bool")
                {
                    comboBox2.Text = value;
                }
                else if (comboBox1.Text == "String")
                {
                    textBox_value.Text = value;
                }
                else if (comboBox1.Text == "Int")
                {
                    numericUpDown1.Value = int.Parse(value);
                }
                else if (comboBox1.Text == "Double")
                {
                    numericUpDown1.Value = (decimal)double.Parse(value);
                }
            }
        }

        private void GlobalVariableUpdate_Load(object sender, EventArgs e)
        {
        }

        public string type = "", name = "", value = "", mark = "";

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Bool")
            {
                comboBox2.Visible = true;
                textBox_value.Visible = false;
                numericUpDown1.Visible = false;
            }
            else if (comboBox1.Text == "String")
            {
                comboBox2.Visible = false;
                textBox_value.Visible = true;
                numericUpDown1.Visible = false;
            }
            else if (comboBox1.Text == "Int")
            {
                comboBox2.Visible = false;
                textBox_value.Visible = false;
                numericUpDown1.Visible = true;
                numericUpDown1.DecimalPlaces = 0;
            }
            else if (comboBox1.Text == "Double")
            {
                comboBox2.Visible = false;
                textBox_value.Visible = false;
                numericUpDown1.Visible = true;
                numericUpDown1.DecimalPlaces = 3;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Bool")
            {
                if (textBox_Name.Text.Trim() == "" || comboBox2.Text.Trim() == "")
                {
                    MessageBox.Show("请输入必填项");
                    return;
                }
            }
            else if (comboBox1.Text == "String")
            {
                if (textBox_value.Text.Trim() == "" || textBox_Name.Text.Trim() == "")
                {
                    MessageBox.Show("请输入必填项");
                    return;
                }
            }
            else if (comboBox1.Text == "Int")
            {
                if (textBox_Name.Text.Trim() == "" || numericUpDown1.Value.ToString().Trim() == "")
                {
                    MessageBox.Show("请输入必填项");
                    return;
                }
            }
            else if (comboBox1.Text == "Double")
            {
                if (textBox_Name.Text.Trim() == "" || numericUpDown1.Value.ToString().Trim() == "")
                {
                    MessageBox.Show("请输入必填项");
                    return;
                }
            }

            name = textBox_Name.Text.Trim(); mark = textBox_mark.Text.Trim();
            try
            {
                switch (comboBox1.Text)
                {
                    case "Int":
                        type = "Int"; value = numericUpDown1.Value.ToString();
                        break;

                    case "Double":
                        type = "Double"; value = numericUpDown1.Value.ToString();
                        break;

                    case "String":
                        type = "String"; value = textBox_value.Text.Trim();
                        break;

                    case "Bool":
                        type = "Bool"; value = bool.Parse(comboBox2.Text).ToString();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("当前输入的值与所选类型不符");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}