
namespace HYProject.Plugin
{
    partial class Form_TCPSocketSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TCPSocketSetting));
            this.label1 = new System.Windows.Forms.Label();
            this.text_Cam1_TCPIP = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.text_Cam1_TCPport = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label2 = new System.Windows.Forms.Label();
            this.text_Cam2_TCPport = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.text_Cam2_TCPIP = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label4 = new System.Windows.Forms.Label();
            this.text_Cam3_TCPport = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label5 = new System.Windows.Forms.Label();
            this.text_Cam3_TCPIP = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cam1 TCP IP:";
            // 
            // text_Cam1_TCPIP
            // 
            this.text_Cam1_TCPIP.Depth = 0;
            this.text_Cam1_TCPIP.Hint = "";
            this.text_Cam1_TCPIP.Location = new System.Drawing.Point(163, 43);
            this.text_Cam1_TCPIP.MaxLength = 32767;
            this.text_Cam1_TCPIP.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_Cam1_TCPIP.Name = "text_Cam1_TCPIP";
            this.text_Cam1_TCPIP.PasswordChar = '\0';
            this.text_Cam1_TCPIP.SelectedText = "";
            this.text_Cam1_TCPIP.SelectionLength = 0;
            this.text_Cam1_TCPIP.SelectionStart = 0;
            this.text_Cam1_TCPIP.Size = new System.Drawing.Size(145, 23);
            this.text_Cam1_TCPIP.TabIndex = 6;
            this.text_Cam1_TCPIP.TabStop = false;
            this.text_Cam1_TCPIP.Text = "127.0.0.1";
            this.text_Cam1_TCPIP.UseSystemPasswordChar = false;
            // 
            // text_Cam1_TCPport
            // 
            this.text_Cam1_TCPport.Depth = 0;
            this.text_Cam1_TCPport.Hint = "";
            this.text_Cam1_TCPport.Location = new System.Drawing.Point(163, 72);
            this.text_Cam1_TCPport.MaxLength = 32767;
            this.text_Cam1_TCPport.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_Cam1_TCPport.Name = "text_Cam1_TCPport";
            this.text_Cam1_TCPport.PasswordChar = '\0';
            this.text_Cam1_TCPport.SelectedText = "";
            this.text_Cam1_TCPport.SelectionLength = 0;
            this.text_Cam1_TCPport.SelectionStart = 0;
            this.text_Cam1_TCPport.Size = new System.Drawing.Size(145, 23);
            this.text_Cam1_TCPport.TabIndex = 8;
            this.text_Cam1_TCPport.TabStop = false;
            this.text_Cam1_TCPport.Text = "8500";
            this.text_Cam1_TCPport.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cam1 TCP Port:";
            // 
            // text_Cam2_TCPport
            // 
            this.text_Cam2_TCPport.Depth = 0;
            this.text_Cam2_TCPport.Hint = "";
            this.text_Cam2_TCPport.Location = new System.Drawing.Point(163, 130);
            this.text_Cam2_TCPport.MaxLength = 32767;
            this.text_Cam2_TCPport.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_Cam2_TCPport.Name = "text_Cam2_TCPport";
            this.text_Cam2_TCPport.PasswordChar = '\0';
            this.text_Cam2_TCPport.SelectedText = "";
            this.text_Cam2_TCPport.SelectionLength = 0;
            this.text_Cam2_TCPport.SelectionStart = 0;
            this.text_Cam2_TCPport.Size = new System.Drawing.Size(145, 23);
            this.text_Cam2_TCPport.TabIndex = 15;
            this.text_Cam2_TCPport.TabStop = false;
            this.text_Cam2_TCPport.Text = "8501";
            this.text_Cam2_TCPport.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cam2 TCP Port:";
            // 
            // text_Cam2_TCPIP
            // 
            this.text_Cam2_TCPIP.Depth = 0;
            this.text_Cam2_TCPIP.Hint = "";
            this.text_Cam2_TCPIP.Location = new System.Drawing.Point(163, 101);
            this.text_Cam2_TCPIP.MaxLength = 32767;
            this.text_Cam2_TCPIP.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_Cam2_TCPIP.Name = "text_Cam2_TCPIP";
            this.text_Cam2_TCPIP.PasswordChar = '\0';
            this.text_Cam2_TCPIP.SelectedText = "";
            this.text_Cam2_TCPIP.SelectionLength = 0;
            this.text_Cam2_TCPIP.SelectionStart = 0;
            this.text_Cam2_TCPIP.Size = new System.Drawing.Size(145, 23);
            this.text_Cam2_TCPIP.TabIndex = 13;
            this.text_Cam2_TCPIP.TabStop = false;
            this.text_Cam2_TCPIP.Text = "127.0.0.1";
            this.text_Cam2_TCPIP.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cam2 TCP IP:";
            // 
            // text_Cam3_TCPport
            // 
            this.text_Cam3_TCPport.Depth = 0;
            this.text_Cam3_TCPport.Hint = "";
            this.text_Cam3_TCPport.Location = new System.Drawing.Point(163, 188);
            this.text_Cam3_TCPport.MaxLength = 32767;
            this.text_Cam3_TCPport.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_Cam3_TCPport.Name = "text_Cam3_TCPport";
            this.text_Cam3_TCPport.PasswordChar = '\0';
            this.text_Cam3_TCPport.SelectedText = "";
            this.text_Cam3_TCPport.SelectionLength = 0;
            this.text_Cam3_TCPport.SelectionStart = 0;
            this.text_Cam3_TCPport.Size = new System.Drawing.Size(145, 23);
            this.text_Cam3_TCPport.TabIndex = 19;
            this.text_Cam3_TCPport.TabStop = false;
            this.text_Cam3_TCPport.Text = "8502";
            this.text_Cam3_TCPport.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cam3 TCP Port:";
            // 
            // text_Cam3_TCPIP
            // 
            this.text_Cam3_TCPIP.Depth = 0;
            this.text_Cam3_TCPIP.Hint = "";
            this.text_Cam3_TCPIP.Location = new System.Drawing.Point(163, 159);
            this.text_Cam3_TCPIP.MaxLength = 32767;
            this.text_Cam3_TCPIP.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_Cam3_TCPIP.Name = "text_Cam3_TCPIP";
            this.text_Cam3_TCPIP.PasswordChar = '\0';
            this.text_Cam3_TCPIP.SelectedText = "";
            this.text_Cam3_TCPIP.SelectionLength = 0;
            this.text_Cam3_TCPIP.SelectionStart = 0;
            this.text_Cam3_TCPIP.Size = new System.Drawing.Size(145, 23);
            this.text_Cam3_TCPIP.TabIndex = 17;
            this.text_Cam3_TCPIP.TabStop = false;
            this.text_Cam3_TCPIP.Text = "127.0.0.1";
            this.text_Cam3_TCPIP.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cam3 TCP IP:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(216, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 40);
            this.button1.TabIndex = 20;
            this.button1.Text = "取    消";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.HslButton2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(31, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 40);
            this.button2.TabIndex = 21;
            this.button2.Text = "保    存";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.HslButton1_Click);
            // 
            // Form_TCPSocketSetting
            // 
            this.ClientSize = new System.Drawing.Size(402, 294);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text_Cam3_TCPport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_Cam3_TCPIP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text_Cam2_TCPport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_Cam2_TCPIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_Cam1_TCPport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_Cam1_TCPIP);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideMaxButtom = false;
            this.HideMinButtom = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Name = "Form_TCPSocketSetting";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.text_Cam1_TCPIP, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.text_Cam1_TCPport, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.text_Cam2_TCPIP, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.text_Cam2_TCPport, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.text_Cam3_TCPIP, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.text_Cam3_TCPport, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_Cam1_TCPIP;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_Cam1_TCPport;
        private System.Windows.Forms.Label label2;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_Cam2_TCPport;
        private System.Windows.Forms.Label label3;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_Cam2_TCPIP;
        private System.Windows.Forms.Label label4;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_Cam3_TCPport;
        private System.Windows.Forms.Label label5;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_Cam3_TCPIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
