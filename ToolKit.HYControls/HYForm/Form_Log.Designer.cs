
namespace ToolKit.HYControls.HYForm
{
    partial class Form_Log
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Log));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsb_tip = new System.Windows.Forms.ToolStripButton();
            this.tsb_warn = new System.Windows.Forms.ToolStripButton();
            this.tsb_error = new System.Windows.Forms.ToolStripButton();
            this.tsb_clear = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(0, 22);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(648, 226);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.ListView1_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "序号";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "信息";
            this.columnHeader2.Width = 400;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_tip,
            this.tsb_warn,
            this.tsb_clear,
            this.tsb_error});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(648, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsb_tip
            // 
            this.tsb_tip.CheckOnClick = true;
            this.tsb_tip.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tip.Image")));
            this.tsb_tip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tip.Name = "tsb_tip";
            this.tsb_tip.Size = new System.Drawing.Size(91, 22);
            this.tsb_tip.Text = "运行日志(0)";
            this.tsb_tip.Click += new System.EventHandler(this.Tsb_tip_Click);
            // 
            // tsb_warn
            // 
            this.tsb_warn.CheckOnClick = true;
            this.tsb_warn.Image = ((System.Drawing.Image)(resources.GetObject("tsb_warn.Image")));
            this.tsb_warn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_warn.Name = "tsb_warn";
            this.tsb_warn.Size = new System.Drawing.Size(67, 22);
            this.tsb_warn.Text = "警告(0)";
            this.tsb_warn.Click += new System.EventHandler(this.Tsb_warn_Click);
            // 
            // tsb_error
            // 
            this.tsb_error.CheckOnClick = true;
            this.tsb_error.Image = ((System.Drawing.Image)(resources.GetObject("tsb_error.Image")));
            this.tsb_error.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_error.Name = "tsb_error";
            this.tsb_error.Size = new System.Drawing.Size(67, 22);
            this.tsb_error.Text = "错误(0)";
            this.tsb_error.Click += new System.EventHandler(this.Tsb_error_Click);
            // 
            // tsb_clear
            // 
            this.tsb_clear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_clear.CheckOnClick = true;
            this.tsb_clear.Image = ((System.Drawing.Image)(resources.GetObject("tsb_clear.Image")));
            this.tsb_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_clear.Name = "tsb_clear";
            this.tsb_clear.Size = new System.Drawing.Size(52, 22);
            this.tsb_clear.Text = "清除";
            this.tsb_clear.Click += new System.EventHandler(this.Tsb_clear_Click);
            // 
            // Form_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 247);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Log";
            this.Text = "Form_Log";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsb_tip;
        private System.Windows.Forms.ToolStripButton tsb_warn;
        private System.Windows.Forms.ToolStripButton tsb_error;
        private System.Windows.Forms.ToolStripButton tsb_clear;
    }
}