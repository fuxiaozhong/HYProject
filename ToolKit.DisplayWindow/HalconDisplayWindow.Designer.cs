
namespace ToolKit.DisplayWindow
{
    partial class HalconDisplayWindow
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.contextMenu_Hal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.自适应ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示中心线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拖动缩放屏蔽文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存原图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全屏显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenu_Hal.SuspendLayout();
            this.SuspendLayout();
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ContextMenuStrip = this.contextMenu_Hal;
            this.hWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(280, 260);
            this.hWindowControl1.TabIndex = 0;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(280, 260);
            this.hWindowControl1.HMouseMove += new HalconDotNet.HMouseEventHandler(this.HWindowControl1_HMouseMove);
            this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.HWindowControl1_HMouseDown);
            this.hWindowControl1.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.HWindowControl1_HMouseWheel);
            this.hWindowControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HWindowControl1_KeyUp);
            this.hWindowControl1.MouseLeave += new System.EventHandler(this.HWindowControl1_MouseLeave);
            // 
            // contextMenu_Hal
            // 
            this.contextMenu_Hal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自适应ToolStripMenuItem,
            this.显示中心线ToolStripMenuItem,
            this.线宽ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.打开图像ToolStripMenuItem,
            this.保存图像ToolStripMenuItem,
            this.全屏显示ToolStripMenuItem,
            this.缩放ToolStripMenuItem});
            this.contextMenu_Hal.Name = "contextMenuStrip1";
            this.contextMenu_Hal.Size = new System.Drawing.Size(176, 180);
            // 
            // 自适应ToolStripMenuItem
            // 
            this.自适应ToolStripMenuItem.Name = "自适应ToolStripMenuItem";
            this.自适应ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.自适应ToolStripMenuItem.Text = "自适应";
            this.自适应ToolStripMenuItem.Click += new System.EventHandler(this.自适应ToolStripMenuItem_Click);
            // 
            // 显示中心线ToolStripMenuItem
            // 
            this.显示中心线ToolStripMenuItem.CheckOnClick = true;
            this.显示中心线ToolStripMenuItem.Name = "显示中心线ToolStripMenuItem";
            this.显示中心线ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.显示中心线ToolStripMenuItem.Text = "显示中心线";
            this.显示中心线ToolStripMenuItem.Click += new System.EventHandler(this.显示中心线ToolStripMenuItem_Click);
            // 
            // 线宽ToolStripMenuItem
            // 
            this.线宽ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.线宽ToolStripMenuItem.Name = "线宽ToolStripMenuItem";
            this.线宽ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.线宽ToolStripMenuItem.Text = "线宽";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.CheckOnClick = true;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.CheckOnClick = true;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.CheckOnClick = true;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.CheckOnClick = true;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.CheckOnClick = true;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem7.Text = "6";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.CheckOnClick = true;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem8.Text = "7";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.CheckOnClick = true;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem9.Text = "8";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.CheckOnClick = true;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem10.Text = "9";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拖动缩放屏蔽文字ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 拖动缩放屏蔽文字ToolStripMenuItem
            // 
            this.拖动缩放屏蔽文字ToolStripMenuItem.CheckOnClick = true;
            this.拖动缩放屏蔽文字ToolStripMenuItem.Name = "拖动缩放屏蔽文字ToolStripMenuItem";
            this.拖动缩放屏蔽文字ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.拖动缩放屏蔽文字ToolStripMenuItem.Text = "拖动缩放屏蔽文字";
            // 
            // 打开图像ToolStripMenuItem
            // 
            this.打开图像ToolStripMenuItem.Name = "打开图像ToolStripMenuItem";
            this.打开图像ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.打开图像ToolStripMenuItem.Text = "打开图像";
            this.打开图像ToolStripMenuItem.Click += new System.EventHandler(this.打开图像ToolStripMenuItem_Click);
            // 
            // 保存图像ToolStripMenuItem
            // 
            this.保存图像ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存原图ToolStripMenuItem,
            this.保存截图ToolStripMenuItem});
            this.保存图像ToolStripMenuItem.Name = "保存图像ToolStripMenuItem";
            this.保存图像ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.保存图像ToolStripMenuItem.Text = "保存图像";
            // 
            // 保存原图ToolStripMenuItem
            // 
            this.保存原图ToolStripMenuItem.Name = "保存原图ToolStripMenuItem";
            this.保存原图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存原图ToolStripMenuItem.Text = "保存原图";
            this.保存原图ToolStripMenuItem.Click += new System.EventHandler(this.保存图像ToolStripMenuItem_Click);
            // 
            // 保存截图ToolStripMenuItem
            // 
            this.保存截图ToolStripMenuItem.Name = "保存截图ToolStripMenuItem";
            this.保存截图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存截图ToolStripMenuItem.Text = "保存截图";
            this.保存截图ToolStripMenuItem.Click += new System.EventHandler(this.保存截图ToolStripMenuItem_Click);
            // 
            // 全屏显示ToolStripMenuItem
            // 
            this.全屏显示ToolStripMenuItem.CheckOnClick = true;
            this.全屏显示ToolStripMenuItem.Name = "全屏显示ToolStripMenuItem";
            this.全屏显示ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.全屏显示ToolStripMenuItem.Text = "全屏显示(Esc退出)";
            this.全屏显示ToolStripMenuItem.Click += new System.EventHandler(this.全屏显示ToolStripMenuItem_Click);
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.Enabled = false;
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.缩放ToolStripMenuItem.Text = "缩放";
            this.缩放ToolStripMenuItem.Visible = false;
            this.缩放ToolStripMenuItem.Click += new System.EventHandler(this.缩放ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("宋体", 8F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 11);
            this.label1.TabIndex = 1;
            // 
            // HalconDisplayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hWindowControl1);
            this.Name = "HalconDisplayWindow";
            this.Size = new System.Drawing.Size(280, 260);
            this.Resize += new System.EventHandler(this.DisplayWindow_Resize);
            this.contextMenu_Hal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Hal;
        private System.Windows.Forms.ToolStripMenuItem 自适应ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示中心线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线宽ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem 保存图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存原图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全屏显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拖动缩放屏蔽文字ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 缩放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开图像ToolStripMenuItem;
    }
}
