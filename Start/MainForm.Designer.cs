﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Data = new System.Windows.Forms.Panel();
            this.pro_memory = new ToolKit.HYControls.ProcessEllipse();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_Log = new System.Windows.Forms.Panel();
            this.panel_Title = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.主页面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.插件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsl_nowtime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.materialContextMenuStrip1 = new ToolKit.MaterialSkin.Controls.MaterialContextMenuStrip();
            this.光源控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLC通讯设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.数据表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControl11 = new ToolKit.HalconTool.UserControl1();
            this.锁定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayout.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_Data.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.SuspendLayout();
            this.materialContextMenuStrip1.SuspendLayout();
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
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(1239, 667);
            this.tableLayout.TabIndex = 1;
            // 
            // panel_Buttom
            // 
            this.tableLayout.SetColumnSpan(this.panel_Buttom, 2);
            this.panel_Buttom.Controls.Add(this.tableLayoutPanel2);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Buttom.Location = new System.Drawing.Point(1, 536);
            this.panel_Buttom.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(1237, 109);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1237, 109);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel_Data
            // 
            this.panel_Data.Controls.Add(this.pro_memory);
            this.panel_Data.Controls.Add(this.splitter1);
            this.panel_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Data.Location = new System.Drawing.Point(618, 0);
            this.panel_Data.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Data.Name = "panel_Data";
            this.panel_Data.Size = new System.Drawing.Size(619, 109);
            this.panel_Data.TabIndex = 1;
            // 
            // pro_memory
            // 
            this.pro_memory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pro_memory.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.pro_memory.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.pro_memory.IsShowCoreEllipseBorder = false;
            this.pro_memory.Location = new System.Drawing.Point(513, 4);
            this.pro_memory.Margin = new System.Windows.Forms.Padding(0);
            this.pro_memory.MaxValue = 100;
            this.pro_memory.Name = "pro_memory";
            this.pro_memory.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.pro_memory.Size = new System.Drawing.Size(100, 100);
            this.pro_memory.TabIndex = 2;
            this.pro_memory.Value = 15;
            this.pro_memory.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.pro_memory.ValueMargin = 5;
            this.pro_memory.ValueType = ToolKit.HYControls.ValueType.Percent;
            this.pro_memory.ValueWidth = 25;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 109);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panel_Log
            // 
            this.panel_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Log.Location = new System.Drawing.Point(0, 0);
            this.panel_Log.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Log.Name = "panel_Log";
            this.panel_Log.Size = new System.Drawing.Size(618, 109);
            this.panel_Log.TabIndex = 2;
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
            this.panel_Title.Size = new System.Drawing.Size(1237, 48);
            this.panel_Title.TabIndex = 0;
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
            this.插件ToolStripMenuItem,
            this.锁定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1237, 48);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 主页面ToolStripMenuItem
            // 
            this.主页面ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("主页面ToolStripMenuItem.Image")));
            this.主页面ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.主页面ToolStripMenuItem.Name = "主页面ToolStripMenuItem";
            this.主页面ToolStripMenuItem.Size = new System.Drawing.Size(116, 44);
            this.主页面ToolStripMenuItem.Text = "主页面";
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
            // 产品库ToolStripMenuItem
            // 
            this.产品库ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("产品库ToolStripMenuItem.Image")));
            this.产品库ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.产品库ToolStripMenuItem.Name = "产品库ToolStripMenuItem";
            this.产品库ToolStripMenuItem.Size = new System.Drawing.Size(116, 44);
            this.产品库ToolStripMenuItem.Text = "产品库";
            this.产品库ToolStripMenuItem.Click += new System.EventHandler(this.Button3_Click);
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
            // toolStrip1
            // 
            this.tableLayout.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_nowtime,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(1, 646);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1237, 20);
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
            this.panel4.Controls.Add(this.splitContainer_Main);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 50);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1237, 485);
            this.panel4.TabIndex = 4;
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer_Main.Size = new System.Drawing.Size(1237, 485);
            this.splitContainer_Main.SplitterDistance = 936;
            this.splitContainer_Main.SplitterWidth = 1;
            this.splitContainer_Main.TabIndex = 0;
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
            // 锁定ToolStripMenuItem
            // 
            this.锁定ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("锁定ToolStripMenuItem.Image")));
            this.锁定ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.锁定ToolStripMenuItem.Name = "锁定ToolStripMenuItem";
            this.锁定ToolStripMenuItem.Size = new System.Drawing.Size(96, 44);
            this.锁定ToolStripMenuItem.Text = "锁定";
            this.锁定ToolStripMenuItem.Click += new System.EventHandler(this.锁定ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 734);
            this.Controls.Add(this.tableLayout);
            this.HelpButton = true;
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "视觉软件";
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
            this.panel_Title.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Panel panel_Title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel_Data;
        private System.Windows.Forms.Splitter splitter1;
        private ToolKit.HYControls.ProcessEllipse pro_memory;
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 主页面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 插件ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Log;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.ToolStripMenuItem 锁定ToolStripMenuItem;
        // private ToolKit.HYControls.CreateModelControl createModelControl1;
    }
}

