
namespace HYProject.ToolForm
{
    partial class Form_TCPSocketServer
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
            this.materialLabel1 = new ToolKit.MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField1 = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField2 = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new ToolKit.MaterialSkin.Controls.MaterialLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 44);
            this.materialLabel1.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(26, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "IP:";
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(50, 40);
            this.materialSingleLineTextField1.MaxLength = 32767;
            this.materialSingleLineTextField1.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(102, 23);
            this.materialSingleLineTextField1.TabIndex = 6;
            this.materialSingleLineTextField1.TabStop = false;
            this.materialSingleLineTextField1.Text = "127.0.0.1";
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Hint = "";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(218, 40);
            this.materialSingleLineTextField2.MaxLength = 32767;
            this.materialSingleLineTextField2.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(102, 23);
            this.materialSingleLineTextField2.TabIndex = 8;
            this.materialSingleLineTextField2.TabStop = false;
            this.materialSingleLineTextField2.Text = "8080";
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(165, 44);
            this.materialLabel2.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(41, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Port:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(16, 69);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(304, 82);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(16, 173);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(304, 97);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            // 
            // Form_TCPSocketServer
            // 
            this.ClientSize = new System.Drawing.Size(460, 335);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.materialSingleLineTextField2);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialSingleLineTextField1);
            this.Controls.Add(this.materialLabel1);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideMaxButtom = false;
            this.HideMinButtom = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Name = "Form_TCPSocketServer";
            this.Text = "TCP服务端";
            this.Load += new System.EventHandler(this.Form_TCPSocketServer_Load);
            this.Controls.SetChildIndex(this.materialLabel1, 0);
            this.Controls.SetChildIndex(this.materialSingleLineTextField1, 0);
            this.Controls.SetChildIndex(this.materialLabel2, 0);
            this.Controls.SetChildIndex(this.materialSingleLineTextField2, 0);
            this.Controls.SetChildIndex(this.richTextBox1, 0);
            this.Controls.SetChildIndex(this.richTextBox2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolKit.MaterialSkin.Controls.MaterialLabel materialLabel1;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private ToolKit.MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}
