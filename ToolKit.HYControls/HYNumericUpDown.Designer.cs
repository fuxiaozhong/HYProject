
namespace ToolKit.HYControls
{
    partial class HYNumericUpDown
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
            this.nud_value = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_value)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_value
            // 
            this.nud_value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nud_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_value.Font = new System.Drawing.Font("宋体", 12F);
            this.nud_value.Location = new System.Drawing.Point(0, 0);
            this.nud_value.Margin = new System.Windows.Forms.Padding(0);
            this.nud_value.Name = "nud_value";
            this.nud_value.Size = new System.Drawing.Size(126, 22);
            this.nud_value.TabIndex = 0;
            this.nud_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_value.ValueChanged += new System.EventHandler(this.Nud_value_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(105, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "+";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.Btn_sub_Click);
            // 
            // Numeric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_value);
            this.Name = "Numeric";
            this.Size = new System.Drawing.Size(126, 22);
            this.SizeChanged += new System.EventHandler(this.Numeric_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nud_value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
