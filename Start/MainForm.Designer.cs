﻿
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Data = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.processEllipse2 = new ToolKit.HYControls.ProcessEllipse();
            this.processEllipse1 = new ToolKit.HYControls.ProcessEllipse();
            this.dataStatisticsControl1 = new ToolKit.HYControls.DataStatisticsControl();
            this.processEllipse3 = new ToolKit.HYControls.ProcessEllipse();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_Log = new System.Windows.Forms.Panel();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.userControl11 = new ToolKit.HalconTool.UserControl1();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.光源控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLC通讯设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Camera = new System.Windows.Forms.Button();
            this.ctms_camera = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重新加载相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_UserLogin = new System.Windows.Forms.Button();
            this.button_Setting = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsl_nowtime = new System.Windows.Forms.ToolStripLabel();
            this.tsl_nowuser = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.参数设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_Data.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
            this.ctms_camera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel_Buttom, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel_Main, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_Title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1424, 861);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel_Buttom
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_Buttom, 2);
            this.panel_Buttom.Controls.Add(this.tableLayoutPanel2);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Buttom.Location = new System.Drawing.Point(0, 721);
            this.panel_Buttom.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(1424, 120);
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
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1424, 120);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel_Data
            // 
            this.panel_Data.Controls.Add(this.tableLayoutPanel3);
            this.panel_Data.Controls.Add(this.splitter1);
            this.panel_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Data.Location = new System.Drawing.Point(712, 0);
            this.panel_Data.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Data.Name = "panel_Data";
            this.panel_Data.Size = new System.Drawing.Size(712, 120);
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
            this.tableLayoutPanel3.Controls.Add(this.processEllipse2, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.processEllipse1, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataStatisticsControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.processEllipse3, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(711, 120);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // processEllipse2
            // 
            this.processEllipse2.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.processEllipse2.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.processEllipse2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processEllipse2.IsShowCoreEllipseBorder = true;
            this.processEllipse2.Location = new System.Drawing.Point(357, 3);
            this.processEllipse2.MaxValue = 100;
            this.processEllipse2.Name = "processEllipse2";
            this.processEllipse2.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.processEllipse2.Size = new System.Drawing.Size(112, 114);
            this.processEllipse2.TabIndex = 1;
            this.processEllipse2.Value = 80;
            this.processEllipse2.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.processEllipse2.ValueMargin = 5;
            this.processEllipse2.ValueType = ToolKit.HYControls.ValueType.Percent;
            this.processEllipse2.ValueWidth = 30;
            // 
            // processEllipse1
            // 
            this.processEllipse1.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.processEllipse1.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.processEllipse1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processEllipse1.IsShowCoreEllipseBorder = true;
            this.processEllipse1.Location = new System.Drawing.Point(475, 3);
            this.processEllipse1.MaxValue = 100;
            this.processEllipse1.Name = "processEllipse1";
            this.processEllipse1.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.processEllipse1.Size = new System.Drawing.Size(112, 114);
            this.processEllipse1.TabIndex = 0;
            this.processEllipse1.Value = 20;
            this.processEllipse1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.processEllipse1.ValueMargin = 5;
            this.processEllipse1.ValueType = ToolKit.HYControls.ValueType.Percent;
            this.processEllipse1.ValueWidth = 30;
            // 
            // dataStatisticsControl1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.dataStatisticsControl1, 3);
            this.dataStatisticsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataStatisticsControl1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.dataStatisticsControl1.Location = new System.Drawing.Point(4, 4);
            this.dataStatisticsControl1.Margin = new System.Windows.Forms.Padding(4);
            this.dataStatisticsControl1.Name = "dataStatisticsControl1";
            this.dataStatisticsControl1.Ng = 0;
            this.dataStatisticsControl1.Ok = 0;
            this.dataStatisticsControl1.Size = new System.Drawing.Size(346, 112);
            this.dataStatisticsControl1.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dataStatisticsControl1, "统计面板(右击菜单清零)");
            // 
            // processEllipse3
            // 
            this.processEllipse3.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.processEllipse3.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.processEllipse3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processEllipse3.IsShowCoreEllipseBorder = true;
            this.processEllipse3.Location = new System.Drawing.Point(593, 3);
            this.processEllipse3.MaxValue = 100;
            this.processEllipse3.Name = "processEllipse3";
            this.processEllipse3.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.processEllipse3.Size = new System.Drawing.Size(115, 114);
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
            this.panel_Log.Size = new System.Drawing.Size(712, 120);
            this.panel_Log.TabIndex = 0;
            // 
            // panel_Main
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_Main, 2);
            this.panel_Main.Controls.Add(this.userControl11);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 75);
            this.panel_Main.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(1424, 646);
            this.panel_Main.TabIndex = 1;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(4, 2);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(10, 10);
            this.userControl11.TabIndex = 0;
            this.userControl11.Visible = false;
            // 
            // panel_Title
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel_Title, 2);
            this.panel_Title.ContextMenuStrip = this.materialContextMenuStrip1;
            this.panel_Title.Controls.Add(this.button_Camera);
            this.panel_Title.Controls.Add(this.button_UserLogin);
            this.panel_Title.Controls.Add(this.button_Setting);
            this.panel_Title.Controls.Add(this.button3);
            this.panel_Title.Controls.Add(this.button_Run);
            this.panel_Title.Controls.Add(this.button_Exit);
            this.panel_Title.Controls.Add(this.label1);
            this.panel_Title.Controls.Add(this.pictureBox1);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(1424, 75);
            this.panel_Title.TabIndex = 0;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.光源控制ToolStripMenuItem,
            this.参数设置ToolStripMenuItem,
            this.pLC通讯设置ToolStripMenuItem,
            this.参数设置ToolStripMenuItem1});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // 光源控制ToolStripMenuItem
            // 
            this.光源控制ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("光源控制ToolStripMenuItem.Image")));
            this.光源控制ToolStripMenuItem.Name = "光源控制ToolStripMenuItem";
            this.光源控制ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // button_Camera
            // 
            this.button_Camera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Camera.ContextMenuStrip = this.ctms_camera;
            this.button_Camera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Camera.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button_Camera.Image = ((System.Drawing.Image)(resources.GetObject("button_Camera.Image")));
            this.button_Camera.Location = new System.Drawing.Point(688, 7);
            this.button_Camera.Name = "button_Camera";
            this.button_Camera.Size = new System.Drawing.Size(140, 63);
            this.button_Camera.TabIndex = 7;
            this.button_Camera.Text = "相    机";
            this.button_Camera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button_Camera, "相机操作");
            this.button_Camera.UseVisualStyleBackColor = true;
            this.button_Camera.Click += new System.EventHandler(this.Button_Camera_Click);
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
            // button_UserLogin
            // 
            this.button_UserLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_UserLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_UserLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button_UserLogin.Image = ((System.Drawing.Image)(resources.GetObject("button_UserLogin.Image")));
            this.button_UserLogin.Location = new System.Drawing.Point(542, 7);
            this.button_UserLogin.Name = "button_UserLogin";
            this.button_UserLogin.Size = new System.Drawing.Size(140, 63);
            this.button_UserLogin.TabIndex = 6;
            this.button_UserLogin.Text = "用    户";
            this.button_UserLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button_UserLogin, "切换用户");
            this.button_UserLogin.UseVisualStyleBackColor = true;
            this.button_UserLogin.Click += new System.EventHandler(this.Button_UserLogin_Click);
            // 
            // button_Setting
            // 
            this.button_Setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Setting.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button_Setting.Image = ((System.Drawing.Image)(resources.GetObject("button_Setting.Image")));
            this.button_Setting.Location = new System.Drawing.Point(834, 7);
            this.button_Setting.Name = "button_Setting";
            this.button_Setting.Size = new System.Drawing.Size(140, 63);
            this.button_Setting.TabIndex = 5;
            this.button_Setting.Text = "设    置";
            this.button_Setting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button_Setting, "系统设置");
            this.button_Setting.UseVisualStyleBackColor = true;
            this.button_Setting.Click += new System.EventHandler(this.Button_Setting_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(980, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 63);
            this.button3.TabIndex = 4;
            this.button3.Text = "产 品 库";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button3, "产品切换");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button_Run
            // 
            this.button_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Run.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button_Run.ForeColor = System.Drawing.Color.Red;
            this.button_Run.Image = ((System.Drawing.Image)(resources.GetObject("button_Run.Image")));
            this.button_Run.Location = new System.Drawing.Point(1126, 7);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(140, 63);
            this.button_Run.TabIndex = 3;
            this.button_Run.Text = "运    行";
            this.button_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button_Run, "开始运行/停止运行(F5)");
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.Button_Run_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.button_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit.Image")));
            this.button_Exit.Location = new System.Drawing.Point(1272, 7);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(140, 63);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "退出系统";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button_Exit, "退出系统");
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("华文新魏", 35F);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(81, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 66);
            this.label1.TabIndex = 1;
            this.label1.Text = "视觉软件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label1, "视觉检测软件");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "深圳市恒越自动化科技有限公司");
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_nowtime,
            this.tsl_nowuser,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 841);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1424, 20);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsl_nowtime
            // 
            this.tsl_nowtime.Name = "tsl_nowtime";
            this.tsl_nowtime.Size = new System.Drawing.Size(130, 17);
            this.tsl_nowtime.Text = "2021-07-28  08:50:00";
            // 
            // tsl_nowuser
            // 
            this.tsl_nowuser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsl_nowuser.Name = "tsl_nowuser";
            this.tsl_nowuser.Size = new System.Drawing.Size(99, 17);
            this.tsl_nowuser.Text = "当前用户: 未登录";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripLabel1.Text = "光源:已连接";
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
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripLabel2.Text = "PLC:未连接";
            // 
            // 参数设置ToolStripMenuItem1
            // 
            this.参数设置ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("参数设置ToolStripMenuItem1.Image")));
            this.参数设置ToolStripMenuItem1.Name = "参数设置ToolStripMenuItem1";
            this.参数设置ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.参数设置ToolStripMenuItem1.Text = "全局变量";
            this.参数设置ToolStripMenuItem1.Click += new System.EventHandler(this.参数设置ToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视觉软件 -- 未登录";
            this.toolTip1.SetToolTip(this, "视觉检测软件");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_Buttom.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel_Data.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel_Main.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ctms_camera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel_Data;
        private System.Windows.Forms.Panel panel_Log;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_UserLogin;
        private System.Windows.Forms.Button button_Setting;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ToolKit.HYControls.ProcessEllipse processEllipse1;
        private ToolKit.HYControls.ProcessEllipse processEllipse2;
        private ToolKit.HYControls.ProcessEllipse processEllipse3;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Camera;
        public ToolKit.HYControls.DataStatisticsControl dataStatisticsControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip ctms_camera;
        private System.Windows.Forms.ToolStripMenuItem 重新加载相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsl_nowtime;
        private System.Windows.Forms.ToolStripLabel tsl_nowuser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private ToolKit.HalconTool.UserControl1 userControl11;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 光源控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLC通讯设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem1;
        // private ToolKit.HYControls.CreateModelControl createModelControl1;
    }
}

