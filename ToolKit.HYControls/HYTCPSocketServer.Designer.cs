
namespace ToolKit.HYControls
{
    partial class HYTCPSocketServer
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_severport = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_severIP = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.richTextBox_severjs = new System.Windows.Forms.RichTextBox();
            this.richTextBox_severSend = new System.Windows.Forms.RichTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_clientList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.03448F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.96552F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_severport, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_severIP, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.button6, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.richTextBox_severjs, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.richTextBox_severSend, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.button5, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmb_clientList, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.27273F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.72727F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(387, 178);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // textBox_severport
            // 
            this.textBox_severport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_severport.Location = new System.Drawing.Point(201, 3);
            this.textBox_severport.Name = "textBox_severport";
            this.textBox_severport.Size = new System.Drawing.Size(85, 21);
            this.textBox_severport.TabIndex = 3;
            this.textBox_severport.Text = "8080";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(152, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 26);
            this.label7.TabIndex = 2;
            this.label7.Text = "Port:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "IP:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_severIP
            // 
            this.textBox_severIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_severIP.Location = new System.Drawing.Point(49, 3);
            this.textBox_severIP.Name = "textBox_severIP";
            this.textBox_severIP.Size = new System.Drawing.Size(97, 21);
            this.textBox_severIP.TabIndex = 1;
            this.textBox_severIP.Text = "127.0.0.1";
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(289, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 26);
            this.button4.TabIndex = 4;
            this.button4.Text = "打开";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(289, 153);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 25);
            this.button6.TabIndex = 10;
            this.button6.Text = "关闭";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // richTextBox_severjs
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.richTextBox_severjs, 3);
            this.richTextBox_severjs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_severjs.Location = new System.Drawing.Point(46, 116);
            this.richTextBox_severjs.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.richTextBox_severjs.Name = "richTextBox_severjs";
            this.tableLayoutPanel2.SetRowSpan(this.richTextBox_severjs, 2);
            this.richTextBox_severjs.Size = new System.Drawing.Size(243, 62);
            this.richTextBox_severjs.TabIndex = 9;
            this.richTextBox_severjs.Text = "";
            // 
            // richTextBox_severSend
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.richTextBox_severSend, 3);
            this.richTextBox_severSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_severSend.Location = new System.Drawing.Point(46, 56);
            this.richTextBox_severSend.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox_severSend.Name = "richTextBox_severSend";
            this.richTextBox_severSend.Size = new System.Drawing.Size(243, 55);
            this.richTextBox_severSend.TabIndex = 6;
            this.richTextBox_severSend.Text = "";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(289, 56);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 26);
            this.button5.TabIndex = 7;
            this.button5.Text = "发送";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label5.Size = new System.Drawing.Size(40, 42);
            this.label5.TabIndex = 8;
            this.label5.Text = "接收:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 56);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label6.Size = new System.Drawing.Size(40, 55);
            this.label6.TabIndex = 5;
            this.label6.Text = "发送:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 26);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label9.Size = new System.Drawing.Size(40, 30);
            this.label9.TabIndex = 11;
            this.label9.Text = "客户端:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_clientList
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmb_clientList, 3);
            this.cmb_clientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_clientList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_clientList.FormattingEnabled = true;
            this.cmb_clientList.Location = new System.Drawing.Point(46, 26);
            this.cmb_clientList.Margin = new System.Windows.Forms.Padding(0);
            this.cmb_clientList.Name = "cmb_clientList";
            this.cmb_clientList.Size = new System.Drawing.Size(243, 20);
            this.cmb_clientList.TabIndex = 12;
            // 
            // HYTCPSocketServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "HYTCPSocketServer";
            this.Size = new System.Drawing.Size(387, 178);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox_severport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_severIP;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RichTextBox richTextBox_severjs;
        private System.Windows.Forms.RichTextBox richTextBox_severSend;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_clientList;
    }
}
