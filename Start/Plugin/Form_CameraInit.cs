using System;
using System.Collections.Generic;

using HYProject.Model;

using ToolKit.HYControls.HYForm;

namespace HYProject.Plugin
{
    public partial class Form_CameraInit : HYBaseForm
    {
        public Form_CameraInit()
        {
            InitializeComponent();
        }

        private void Form_CameraInit_Load(object sender, EventArgs e)
        {
            foreach (string s in Enum.GetNames(typeof(CameraType)))
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.SelectedIndex = 0;

            if (AppParam.Instance.CameraInitStr != null && AppParam.Instance.CameraInitStr.Count > 0)
            {
                foreach (CameraInfo item in AppParam.Instance.CameraInitStr)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = index;
                    dataGridView1.Rows[index].Cells[1].Value = item.CameraType;
                    dataGridView1.Rows[index].Cells[2].Value = item.CameraName;
                    dataGridView1.Rows[index].Cells[3].Value = item.Mark;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                ShowWarn("请输入相机名!!!");
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == comboBox1.Text && dataGridView1.Rows[i].Cells[2].Value.ToString() == textBox1.Text.Trim())
                {
                    ShowWarn("已存在,请勿重复添加.");
                    return;
                }
            }

            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = dataGridView1.Rows.Count;
            dataGridView1.Rows[index].Cells[1].Value = Enum.Parse(typeof(CameraType), comboBox1.Text);
            dataGridView1.Rows[index].Cells[2].Value = textBox1.Text;
            dataGridView1.Rows[index].Cells[3].Value = textBox2.Text;
            ShowNormal("添加成功");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.CameraInitStr == null)
            {
                AppParam.Instance.CameraInitStr = new List<CameraInfo>();
            }
            AppParam.Instance.CameraInitStr?.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                CameraInfo cameraInfo = new CameraInfo()
                {
                    CameraType = (CameraType)Enum.Parse(typeof(CameraType), dataGridView1.Rows[i].Cells[1].Value.ToString()),
                    CameraName = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Mark = dataGridView1.Rows[i].Cells[3].Value.ToString()
                };
                AppParam.Instance.CameraInitStr.Add(cameraInfo);
            }
            ShowNormal("保存成功。");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}