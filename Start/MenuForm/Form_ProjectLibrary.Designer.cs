
namespace HYProject.MenuForm
{
    partial class Form_ProjectLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProjectLibrary));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Modify = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_NowProductName = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前工程:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(-7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1180, 2);
            this.label3.TabIndex = 2;
            // 
            // button_Add
            // 
            this.button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Add.Font = new System.Drawing.Font("新宋体", 12F);
            this.button_Add.Image = ((System.Drawing.Image)(resources.GetObject("button_Add.Image")));
            this.button_Add.Location = new System.Drawing.Point(234, 3);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(85, 29);
            this.button_Add.TabIndex = 3;
            this.button_Add.Text = "添加";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // button_Modify
            // 
            this.button_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Modify.Font = new System.Drawing.Font("新宋体", 12F);
            this.button_Modify.Image = ((System.Drawing.Image)(resources.GetObject("button_Modify.Image")));
            this.button_Modify.Location = new System.Drawing.Point(325, 3);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(85, 29);
            this.button_Modify.TabIndex = 4;
            this.button_Modify.Text = "修改";
            this.button_Modify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.Button_Modify_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Delete.Font = new System.Drawing.Font("新宋体", 12F);
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.Location = new System.Drawing.Point(416, 3);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(85, 29);
            this.button_Delete.TabIndex = 5;
            this.button_Delete.Text = "删除";
            this.button_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("新宋体", 12F);
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(507, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 29);
            this.button4.TabIndex = 6;
            this.button4.Text = "切换";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button_Refresh
            // 
            this.button_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Refresh.Font = new System.Drawing.Font("新宋体", 12F);
            this.button_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("button_Refresh.Image")));
            this.button_Refresh.Location = new System.Drawing.Point(1047, 3);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(85, 29);
            this.button_Refresh.TabIndex = 7;
            this.button_Refresh.Text = "刷新";
            this.button_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 43);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1120, 504);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label_NowProductName
            // 
            this.label_NowProductName.AutoSize = true;
            this.label_NowProductName.Depth = 0;
            this.label_NowProductName.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_NowProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_NowProductName.Location = new System.Drawing.Point(100, 8);
            this.label_NowProductName.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_NowProductName.Name = "label_NowProductName";
            this.label_NowProductName.Size = new System.Drawing.Size(0, 19);
            this.label_NowProductName.TabIndex = 8;
            // 
            // Form_ProjectLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 559);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label_NowProductName);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Modify);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1160, 598);
            this.MinimumSize = new System.Drawing.Size(1160, 598);
            this.Name = "Form_ProjectLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工程库";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_Refresh;
        private MaterialSkin.Controls.MaterialLabel label_NowProductName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}