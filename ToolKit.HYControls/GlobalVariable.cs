using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ToolKit.HYControls
{
    public partial class GlobalVariable : UserControl
    {
        public GlobalVariable()
        {
            InitializeComponent();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string type = "Int", name = "", value = "", mark = "";

            GlobalVariableUpdate global = new GlobalVariableUpdate(ref type, ref name, ref value, ref mark);
        REPEAT:
            if (global.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (item.Cells[2].Value.ToString() == global.name)
                    {
                        MessageBox.Show("此变量名已存在");
                        goto REPEAT;
                    }
                }
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = index + 1;
                dataGridView1.Rows[index].Cells[1].Value = global.type;
                dataGridView1.Rows[index].Cells[2].Value = global.name;
                dataGridView1.Rows[index].Cells[3].Value = global.value;
                dataGridView1.Rows[index].Cells[4].Value = global.mark;
            }
            //设置DataGridView文本居中
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string type = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                    name = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                    value = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                    mark = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                GlobalVariableUpdate global = new GlobalVariableUpdate(ref type, ref name, ref value, ref mark);
                if (global.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.SelectedRows[0].Cells[3].Value = global.value;
                    dataGridView1.SelectedRows[0].Cells[4].Value = global.mark;
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确认删除?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }
            }
        }

        /// <summary>
        /// 根据名称获取值
        /// </summary>
        /// <param name="name">变量名</param>
        /// <returns></returns>
        public object GetValue(string name)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[2].Value.ToString() == name)
                {
                    switch (item.Cells[1].Value.ToString())
                    {
                        case "Int":
                            return int.Parse(item.Cells[3].Value.ToString());

                        case "Double":
                            return double.Parse(item.Cells[3].Value.ToString());

                        case "String":
                            return item.Cells[3].Value.ToString();

                        case "Bool":
                            return bool.Parse(item.Cells[3].Value.ToString());
                    }
                    break;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据序号获取值
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns></returns>
        public object GetValue(int index)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[1].Value.ToString() == index.ToString())
                {
                    switch (item.Cells[1].Value.ToString())
                    {
                        case "Int":
                            return int.Parse(item.Cells[3].Value.ToString());

                        case "Double":
                            return double.Parse(item.Cells[3].Value.ToString());

                        case "String":
                            return item.Cells[3].Value.ToString();

                        case "Bool":
                            return bool.Parse(item.Cells[3].Value.ToString());
                    }
                    break;
                }
            }
            return null;
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        public List<GlobalVariableData> GetData()
        {
            List<GlobalVariableData> list = new List<GlobalVariableData>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                list.Add(new GlobalVariableData()
                {
                    index = item.Cells[0].Value.ToString(),
                    type = item.Cells[1].Value.ToString(),
                    mark = item.Cells[4].Value.ToString(),
                    value = item.Cells[3].Value.ToString(),
                    name = item.Cells[2].Value.ToString(),
                });
            }
            return list;
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="list"></param>
        public void SetData(List<GlobalVariableData> list)
        {
            dataGridView1.Rows.Clear();
            foreach (GlobalVariableData item in list)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.index;
                dataGridView1.Rows[index].Cells[1].Value = item.type;
                dataGridView1.Rows[index].Cells[2].Value = item.name;
                dataGridView1.Rows[index].Cells[3].Value = item.value;
                dataGridView1.Rows[index].Cells[4].Value = item.mark;
            }
        }

        /// <summary>
        /// 序列化保存数据
        /// </summary>
        public void Save()
        {
            FileStream stream = new FileStream(this.Name + ".bin", FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(stream, GetData());
            stream.Close();
        }

        /// <summary>
        /// 读取序列化保存好的数据
        /// </summary>
        public void Read()
        {
            if (File.Exists(this.Name + ".bin"))
            {
                FileStream stream = new FileStream(this.Name + ".bin", FileMode.Open);
                BinaryFormatter bFormat = new BinaryFormatter();
                SetData((List<GlobalVariableData>)bFormat.Deserialize(stream));
                stream.Close();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void 读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Read();
        }
    }

    [Serializable]
    public class GlobalVariableData
    {
        public string index, type, name, value, mark;
    }
}