
using ToolKit.MaterialSkin.Controls;

namespace HYProject
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Data = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataStatisticsControl1 = new ToolKit.HYControls.DataStatisticsControl();
            this.processEllipse3 = new ToolKit.HYControls.ProcessEllipse();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_Log = new System.Windows.Forms.Panel();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.ctms_camera = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重新加载相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsl_nowtime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.materialContextMenuStrip1 = new ToolKit.MaterialSkin.Controls.MaterialContextMenuStrip();
            this.光源控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLC通讯设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.数据表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControl11 = new ToolKit.HalconTool.UserControl1();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.processEllipse1 = new ToolKit.HYControls.ProcessEllipse();
            this.processEllipse2 = new ToolKit.HYControls.ProcessEllipse();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.主页面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.插件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayout.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_Data.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.ctms_camera.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout.Controls.Add(this.panel_Buttom, 0, 2);
            this.tableLayout.Controls.Add(this.panel_Title, 0, 0);
            this.tableLayout.Controls.Add(this.toolStrip1, 0, 3);
            this.tableLayout.Controls.Add(this.panel4, 0, 1);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 67);
            this.tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 4;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(1448, 771);
            this.tableLayout.TabIndex = 1;
            // 
            // panel_Buttom
            // 
            this.tableLayout.SetColumnSpan(this.panel_Buttom, 2);
            this.panel_Buttom.Controls.Add(this.tableLayoutPanel2);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Buttom.Location = new System.Drawing.Point(1, 629);
            this.panel_Buttom.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(1446, 120);
            this.panel_Buttom.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel_Data, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel_Log, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1446, 120);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel_Data
            // 
            this.panel_Data.Controls.Add(this.tableLayoutPanel3);
            this.panel_Data.Controls.Add(this.splitter1);
            this.panel_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Data.Location = new System.Drawing.Point(723, 0);
            this.panel_Data.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Data.Name = "panel_Data";
            this.panel_Data.Size = new System.Drawing.Size(723, 120);
            this.panel_Data.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.processEllipse2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.processEllipse1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataStatisticsControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.processEllipse3, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(722, 120);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dataStatisticsControl1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.dataStatisticsControl1, 3);
            this.dataStatisticsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataStatisticsControl1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.dataStatisticsControl1.Location = new System.Drawing.Point(0, 0);
            this.dataStatisticsControl1.Margin = new System.Windows.Forms.Padding(0);
            this.dataStatisticsControl1.Name = "dataStatisticsControl1";
            this.dataStatisticsControl1.Ng = 0;
            this.dataStatisticsControl1.Ok = 0;
            this.dataStatisticsControl1.Size = new System.Drawing.Size(360, 120);
            this.dataStatisticsControl1.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dataStatisticsControl1, "统计面板(右击菜单清零)");
            // 
            // processEllipse3
            // 
            this.processEllipse3.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.processEllipse3.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.processEllipse3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processEllipse3.IsShowCoreEllipseBorder = true;
            this.processEllipse3.Location = new System.Drawing.Point(610, 10);
            this.processEllipse3.Margin = new System.Windows.Forms.Padding(10);
            this.processEllipse3.MaxValue = 100;
            this.processEllipse3.Name = "processEllipse3";
            this.processEllipse3.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.processEllipse3.Size = new System.Drawing.Size(102, 100);
            this.processEllipse3.TabIndex = 2;
            this.toolTip1.SetToolTip(this.processEllipse3, "内存使用率\r\n");
            this.processEllipse3.Value = 50;
            this.processEllipse3.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.processEllipse3.ValueMargin = 5;
            this.processEllipse3.ValueType = ToolKit.HYControls.ValueType.Percent;
            this.processEllipse3.ValueWidth = 30;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 120);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panel_Log
            // 
            this.panel_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Log.Location = new System.Drawing.Point(0, 0);
            this.panel_Log.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Log.Name = "panel_Log";
            this.panel_Log.Size = new System.Drawing.Size(723, 120);
            this.panel_Log.TabIndex = 0;
            // 
            // panel_Title
            // 
            this.panel_Title.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayout.SetColumnSpan(this.panel_Title, 2);
            this.panel_Title.Controls.Add(this.menuStrip1);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Title.Location = new System.Drawing.Point(1, 1);
            this.panel_Title.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(1446, 48);
            this.panel_Title.TabIndex = 0;
            // 
            // ctms_camera
            // 
            this.ctms_camera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新加载相机ToolStripMenuItem});
            this.ctms_camera.Name = "contextMenuStrip1";
            this.ctms_camera.Size = new System.Drawing.Size(149, 26);
            // 
            // 重新加载相机ToolStripMenuItem
            // 
            this.重新加载相机ToolStripMenuItem.Name = "重新加载相机ToolStripMenuItem";
            this.重新加载相机ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.重新加载相机ToolStripMenuItem.Text = "重新加载相机";
            this.重新加载相机ToolStripMenuItem.Click += new System.EventHandler(this.重新加载相机ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.tableLayout.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_nowtime,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(1, 750);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1446, 20);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsl_nowtime
            // 
            this.tsl_nowtime.Name = "tsl_nowtime";
            this.tsl_nowtime.Size = new System.Drawing.Size(130, 17);
            this.tsl_nowtime.Text = "2021-07-28  08:50:00";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripLabel1.Text = "光源:未连接";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 20);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripLabel2.Text = "PLC:未连接";
            // 
            // panel4
            // 
            this.tableLayout.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.split_Main);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 50);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1446, 578);
            this.panel4.TabIndex = 4;
            // 
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.IsSplitterFixed = true;
            this.split_Main.Location = new System.Drawing.Point(0, 0);
            this.split_Main.Margin = new System.Windows.Forms.Padding(0);
            this.split_Main.Name = "split_Main";
            this.split_Main.Size = new System.Drawing.Size(1446, 578);
            this.split_Main.SplitterDistance = 1080;
            this.split_Main.SplitterWidth = 1;
            this.split_Main.TabIndex = 0;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.光源控制ToolStripMenuItem,
            this.参数设置ToolStripMenuItem,
            this.pLC通讯设置ToolStripMenuItem,
            this.参数设置ToolStripMenuItem1,
            this.数据表ToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(146, 114);
            // 
            // 光源控制ToolStripMenuItem
            // 
            this.光源控制ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("光源控制ToolStripMenuItem.Image")));
            this.光源控制ToolStripMenuItem.Name = "光源控制ToolStripMenuItem";
            this.光源控制ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.光源控制ToolStripMenuItem.Text = "光源控制";
            this.光源控制ToolStripMenuItem.Click += new System.EventHandler(this.光源控制ToolStripMenuItem_Click);
            // 
            // 参数设置ToolStripMenuItem
            // 
            this.参数设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("参数设置ToolStripMenuItem.Image")));
            this.参数设置ToolStripMenuItem.Name = "参数设置ToolStripMenuItem";
            this.参数设置ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.参数设置ToolStripMenuItem.Text = "上下限设置";
            this.参数设置ToolStripMenuItem.Click += new System.EventHandler(this.参数设置ToolStripMenuItem_Click);
            // 
            // pLC通讯设置ToolStripMenuItem
            // 
            this.pLC通讯设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pLC通讯设置ToolStripMenuItem.Image")));
            this.pLC通讯设置ToolStripMenuItem.Name = "pLC通讯设置ToolStripMenuItem";
            this.pLC通讯设置ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.pLC通讯设置ToolStripMenuItem.Text = "PLC通讯设置";
            this.pLC通讯设置ToolStripMenuItem.Click += new System.EventHandler(this.PLC通讯设置ToolStripMenuItem_Click);
            // 
            // 参数设置ToolStripMenuItem1
            // 
            this.参数设置ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("参数设置ToolStripMenuItem1.Image")));
            this.参数设置ToolStripMenuItem1.Name = "参数设置ToolStripMenuItem1";
            this.参数设置ToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.参数设置ToolStripMenuItem1.Text = "全局变量";
            this.参数设置ToolStripMenuItem1.Click += new System.EventHandler(this.参数设置ToolStripMenuItem1_Click);
            // 
            // 数据表ToolStripMenuItem
            // 
            this.数据表ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("数据表ToolStripMenuItem.Image")));
            this.数据表ToolStripMenuItem.Name = "数据表ToolStripMenuItem";
            this.数据表ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.数据表ToolStripMenuItem.Text = "数据表";
            this.数据表ToolStripMenuItem.Click += new System.EventHandler(this.数据表ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1325, 518);
            this.panel1.TabIndex = 4;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(4, 2);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(10, 10);
            this.userControl11.TabIndex = 0;
            this.userControl11.Visible = false;
            // 
            // processEllipse1
            // 
            this.processEllipse1.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.processEllipse1.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.processEllipse1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processEllipse1.IsShowCoreEllipseBorder = true;
            this.processEllipse1.Location = new System.Drawing.Point(370, 10);
            this.processEllipse1.Margin = new System.Windows.Forms.Padding(10);
            this.processEllipse1.MaxValue = 100;
            this.processEllipse1.Name = "processEllipse1";
            this.processEllipse1.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.processEllipse1.Size = new System.Drawing.Size(100, 100);
            this.processEllipse1.TabIndex = 4;
            this.toolTip1.SetToolTip(this.processEllipse1, "内存使用率\r\n");
            this.processEllipse1.Value = 50;
            this.processEllipse1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.processEllipse1.ValueMargin = 5;
            this.processEllipse1.ValueType = ToolKit.HYControls.ValueType.Percent;
            this.processEllipse1.ValueWidth = 30;
            // 
            // processEllipse2
            // 
            this.processEllipse2.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.processEllipse2.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.processEllipse2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processEllipse2.IsShowCoreEllipseBorder = true;
            this.processEllipse2.Location = new System.Drawing.Point(490, 10);
            this.processEllipse2.Margin = new System.Windows.Forms.Padding(10);
            this.processEllipse2.MaxValue = 100;
            this.processEllipse2.Name = "processEllipse2";
            this.processEllipse2.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.processEllipse2.Size = new System.Drawing.Size(100, 100);
            this.processEllipse2.TabIndex = 5;
            this.toolTip1.SetToolTip(this.processEllipse2, "内存使用率\r\n");
            this.processEllipse2.Value = 50;
            this.processEllipse2.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.processEllipse2.ValueMargin = 5;
            this.processEllipse2.ValueType = ToolKit.HYControls.ValueType.Percent;
            this.processEllipse2.ValueWidth = 30;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主页面ToolStripMenuItem,
            this.相机ToolStripMenuItem,
            this.产品库ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.退出系统ToolStripMenuItem,
            this.运行ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.插件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1446, 48);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 相机ToolStripMenuItem
            // 
            this.相机ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("相机ToolStripMenuItem.Image")));
            this.相机ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.相机ToolStripMenuItem.Name = "相机ToolStripMenuItem";
            this.相机ToolStripMenuItem.Size = new System.Drawing.Size(96, 44);
            this.相机ToolStripMenuItem.Text = "相机";
            this.相机ToolStripMenuItem.Click += new System.EventHandler(this.Button_Camera_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("设置ToolStripMenuItem.Image")));
            this.设置ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(96, 44);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.Button_Setting_Click);
            // 
            // 产品库ToolStripMenuItem
            // 
            this.产品库ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("产品库ToolStripMenuItem.Image")));
            this.产品库ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.产品库ToolStripMenuItem.Name = "产品库ToolStripMenuItem";
            this.产品库ToolStripMenuItem.Size = new System.Drawing.Size(116, 44);
            this.产品库ToolStripMenuItem.Text = "产品库";
            this.产品库ToolStripMenuItem.Click += new System.EventHandler(this.Button3_Click);
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.运行ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.运行ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("运行ToolStripMenuItem.Image")));
            this.运行ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.运行ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(120, 44);
            this.运行ToolStripMenuItem.Text = "运    行";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.Button_Run_Click);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.退出系统ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出系统ToolStripMenuItem.Image")));
            this.退出系统ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(136, 44);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // 主页面ToolStripMenuItem
            // 
            this.主页面ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("主页面ToolStripMenuItem.Image")));
            this.主页面ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.主页面ToolStripMenuItem.Name = "主页面ToolStripMenuItem";
            this.主页面ToolStripMenuItem.Size = new System.Drawing.Size(116, 44);
            this.主页面ToolStripMenuItem.Text = "主页面";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 44);
            this.toolStripMenuItem1.Visible = false;
            // 
            // 插件ToolStripMenuItem
            // 
            this.插件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("插件ToolStripMenuItem.Image")));
            this.插件ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.插件ToolStripMenuItem.Name = "插件ToolStripMenuItem";
            this.插件ToolStripMenuItem.Size = new System.Drawing.Size(96, 44);
            this.插件ToolStripMenuItem.Text = "插件";
            this.插件ToolStripMenuItem.Click += new System.EventHandler(this.插件ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 838);
            this.Controls.Add(this.tableLayout);
            this.HelpButton = true;
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "视觉软件 -- 未登录";
            this.toolTip1.SetToolTip(this, "视觉检测软件");
            this.UserClick += new System.EventHandler(this.MainForm_UserClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Controls.SetChildIndex(this.tableLayout, 0);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.panel_Buttom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel_Data.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.ctms_camera.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel_Data;
        private System.Windows.Forms.Panel panel_Log;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ToolKit.HYControls.ProcessEllipse processEllipse3;
        public ToolKit.HYControls.DataStatisticsControl dataStatisticsControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip ctms_camera;
        private System.Windows.Forms.ToolStripMenuItem 重新加载相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsl_nowtime;
        private ToolKit.HalconTool.UserControl1 userControl11;
        private MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 光源控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLC通讯设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 数据表ToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer split_Main;
        private ToolKit.HYControls.ProcessEllipse processEllipse2;
        private ToolKit.HYControls.ProcessEllipse processEllipse1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 主页面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 插件ToolStripMenuItem;
        // private ToolKit.HYControls.CreateModelControl createModelControl1;
    }
}

