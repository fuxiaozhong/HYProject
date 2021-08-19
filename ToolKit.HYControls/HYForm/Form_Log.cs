using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToolKit.HYControls.HYForm
{
    public partial class Form_Log : BaseForm
    {
        private static Form_Log _Form_Logs = null;
        private static object _Lock = new object();

        public static Form_Log Instance
        {
            get
            {
                if (_Form_Logs == null) //双if +lock
                {
                    lock (_Lock)
                    {
                        if (_Form_Logs == null)
                        {
                            _Form_Logs = new Form_Log();
                            _Form_Logs.TopLevel = false;
                            _Form_Logs.TopMost = false;
                            _Form_Logs.Dock = DockStyle.Fill;
                        }
                    }
                }
                return _Form_Logs;
            }
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

        private Form_Log()
        {
            InitializeComponent();
        }

        private List<OutputItem> L_outputItem = new List<OutputItem>();
        private int numGreen = 0;
        private int numOrange = 0;
        private int numRed = 0;
        private object obj = new object();

        internal void ClearLog()
        {
            numGreen = 0;
            numRed = 0;
            numOrange = 0;
            this.listView1.Items.Clear();
            L_outputItem.Clear();
            tsb_tip.Text = string.Format("运行日志({0})", numGreen);
            tsb_warn.Text = string.Format("警告({0})", numOrange);
            tsb_error.Text = string.Format("错误({0})", numRed);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="color">颜色显示</param>
        public void OutputMsg(string msg, Color color)
        {
            try
            {
                lock (obj)
                {
                    if (msg == string.Empty)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = string.Empty;
                        item.SubItems.Add(msg);
                        item.ForeColor = color;
                        listView1.Items.Add(item);
                    }
                    else
                    {
                        if (color == Color.Orange)
                            numOrange++;
                        else if (color == Color.Red)
                        {
                            numRed++;
                        }
                        else
                            numGreen++;

                        string time = DateTime.Now.ToString("HH:mm:ss:ffff");

                        ListViewItem item = new ListViewItem();
                        item.Text = (listView1.Items.Count + 1).ToString();
                        item.SubItems.Add(time);
                        item.SubItems.Add(msg);
                        item.ForeColor = color;

                        OutputItem outputItem = new OutputItem();
                        outputItem.index = (listView1.Items.Count + 1);
                        outputItem.msg = msg;
                        outputItem.color = color;
                        outputItem.time = time;

                        listView1.Items.Add(item);

                        L_outputItem.Add(outputItem);

                        if (L_outputItem.Count > 1000)
                        {
                            if (L_outputItem[0].color == Color.Orange)
                                numOrange--;
                            else if (L_outputItem[0].color == Color.Red)
                                numRed--;
                            else
                                numGreen--;

                            L_outputItem.RemoveAt(0);
                        }

                        UpdateCount();
                        this.listView1.Items[this.listView1.Items.Count - 1].EnsureVisible();
                    }
                    Application.DoEvents();
                }
            }
            catch (Exception)
            {
            }
        }

        private void UpdateCount()
        {
            tsb_tip.Text = string.Format("运行日志({0})", numGreen);
            tsb_warn.Text = string.Format("警告({0})", numOrange);
            tsb_error.Text = string.Format("错误({0})", numRed);
        }

        private void Tsb_tip_Click(object sender, EventArgs e)
        {
            if (tsb_tip.Checked)
            {
                tsb_warn.Checked = false;
                tsb_error.Checked = false;

                listView1.Items.Clear();
                for (int i = 0; i < L_outputItem.Count; i++)
                {
                    if (L_outputItem[i].color == Color.Green)
                    {
                        ListViewItem item = new ListViewItem();

                        item.Text = L_outputItem[i].index.ToString();
                        item.SubItems.Add(L_outputItem[i].time);
                        item.SubItems.Add(L_outputItem[i].msg);
                        item.ForeColor = L_outputItem[i].color;
                        listView1.Items.Add(item);
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                for (int i = 0; i < L_outputItem.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = L_outputItem[i].index.ToString();
                    item.SubItems.Add(L_outputItem[i].time);
                    item.SubItems.Add(L_outputItem[i].msg);
                    item.ForeColor = L_outputItem[i].color;
                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                }
            }
        }

        private void Tsb_warn_Click(object sender, EventArgs e)
        {
            if (tsb_warn.Checked)
            {
                tsb_tip.Checked = false;
                tsb_error.Checked = false;

                listView1.Items.Clear();
                for (int i = 0; i < L_outputItem.Count; i++)
                {
                    if (L_outputItem[i].color == Color.Orange)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = L_outputItem[i].index.ToString();
                        item.SubItems.Add(L_outputItem[i].time);
                        item.SubItems.Add(L_outputItem[i].msg);
                        item.ForeColor = L_outputItem[i].color;
                        listView1.Items.Add(item);
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                for (int i = 0; i < L_outputItem.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = L_outputItem[i].index.ToString();
                    item.SubItems.Add(L_outputItem[i].time);
                    item.SubItems.Add(L_outputItem[i].msg);
                    item.ForeColor = L_outputItem[i].color;
                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                }
            }
        }

        private void Tsb_error_Click(object sender, EventArgs e)
        {
            if (tsb_error.Checked)
            {
                tsb_tip.Checked = false;
                tsb_warn.Checked = false;

                listView1.Items.Clear();
                for (int i = 0; i < L_outputItem.Count; i++)
                {
                    if (L_outputItem[i].color == Color.Red)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = L_outputItem[i].index.ToString();
                        item.SubItems.Add(L_outputItem[i].time);
                        item.SubItems.Add(L_outputItem[i].msg);
                        item.ForeColor = L_outputItem[i].color;
                        listView1.Items.Add(item);
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                for (int i = 0; i < L_outputItem.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = L_outputItem[i].index.ToString();
                    item.SubItems.Add(L_outputItem[i].time);
                    item.SubItems.Add(L_outputItem[i].msg);
                    item.ForeColor = L_outputItem[i].color;
                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                }
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                if (listView1.SelectedItems[0].ForeColor== Color.Orange)
                {
                    ShowWarn("时间：" + listView1.SelectedItems[0].SubItems[1].Text + "\n" +
                                          "详情：" + listView1.SelectedItems[0].SubItems[2].Text, "日志详情 - 警告");
                }
                else if (listView1.SelectedItems[0].ForeColor == Color.Green)
                {
                    ShowNormal("时间：" + listView1.SelectedItems[0].SubItems[1].Text + "\n" +
                                         "详情：" + listView1.SelectedItems[0].SubItems[2].Text, "日志详情 - 正常");
                }
                else if (listView1.SelectedItems[0].ForeColor == Color.Red)
                {
                    ShowError("时间：" + listView1.SelectedItems[0].SubItems[1].Text + "\n" +
                                         "详情：" + listView1.SelectedItems[0].SubItems[2].Text, "日志详情 - 错误");
                }
            }
        }

        private void Tsb_clear_Click(object sender, EventArgs e)
        {
            ClearLog();
        }
    }

    public struct OutputItem
    {
        public int index;
        public string msg;
        public string time;
        public Color color;
    }
}