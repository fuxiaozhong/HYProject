
namespace HYProject.ToolForm
{
    partial class Form_ProductOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProductOperation));
            this.button_Close = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Close.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button_Close.Location = new System.Drawing.Point(694, 497);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(150, 35);
            this.button_Close.TabIndex = 40;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_save.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button_save.Location = new System.Drawing.Point(538, 497);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(150, 35);
            this.button_save.TabIndex = 38;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.Button_save_Click);
            // 
            // Form_ProductOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 544);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_save);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideOrClose = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Name = "Form_ProductOperation";
            this.Text = "产品_";
            this.Load += new System.EventHandler(this.Form_ProductOperation_Load);
            this.Controls.SetChildIndex(this.button_save, 0);
            this.Controls.SetChildIndex(this.button_Close, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_save;
    }
}