
namespace HYProject.MenuForm
{
    partial class Form_Camera
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
            this.displayWindow1 = new ToolKit.DisplayWindow.DisplayWindow();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_CamList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.num__exposuretime = new System.Windows.Forms.NumericUpDown();
            this.num_gain = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_TriggerMode = new System.Windows.Forms.ComboBox();
            this.comboBox_TriggerSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_TriggerSource = new System.Windows.Forms.Label();
            this.label_TriggerMode = new System.Windows.Forms.Label();
            this.label_Gain = new System.Windows.Forms.Label();
            this.label_exposuretime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num__exposuretime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_gain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayWindow1
            // 
            this.displayWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayWindow1.BackColor = System.Drawing.Color.Transparent;
            this.displayWindow1.Location = new System.Drawing.Point(3, 3);
            this.displayWindow1.Margin = new System.Windows.Forms.Padding(0);
            this.displayWindow1.Name = "displayWindow1";
            this.displayWindow1.Size = new System.Drawing.Size(735, 608);
            this.displayWindow1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "相机列表:";
            // 
            // comboBox_CamList
            // 
            this.comboBox_CamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CamList.FormattingEnabled = true;
            this.comboBox_CamList.Location = new System.Drawing.Point(840, 6);
            this.comboBox_CamList.Name = "comboBox_CamList";
            this.comboBox_CamList.Size = new System.Drawing.Size(141, 24);
            this.comboBox_CamList.TabIndex = 2;
            this.comboBox_CamList.SelectedIndexChanged += new System.EventHandler(this.ComboBox_CamList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "曝光时间:";
            // 
            // num__exposuretime
            // 
            this.num__exposuretime.Location = new System.Drawing.Point(840, 227);
            this.num__exposuretime.Name = "num__exposuretime";
            this.num__exposuretime.Size = new System.Drawing.Size(141, 26);
            this.num__exposuretime.TabIndex = 4;
            // 
            // num_gain
            // 
            this.num_gain.Location = new System.Drawing.Point(840, 259);
            this.num_gain.Name = "num_gain";
            this.num_gain.Size = new System.Drawing.Size(141, 26);
            this.num_gain.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(753, 267);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "增    益:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(753, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "触发模式:";
            // 
            // comboBox_TriggerMode
            // 
            this.comboBox_TriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TriggerMode.FormattingEnabled = true;
            this.comboBox_TriggerMode.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.comboBox_TriggerMode.Location = new System.Drawing.Point(840, 291);
            this.comboBox_TriggerMode.Name = "comboBox_TriggerMode";
            this.comboBox_TriggerMode.Size = new System.Drawing.Size(141, 24);
            this.comboBox_TriggerMode.TabIndex = 8;
            // 
            // comboBox_TriggerSource
            // 
            this.comboBox_TriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TriggerSource.FormattingEnabled = true;
            this.comboBox_TriggerSource.Items.AddRange(new object[] {
            "Software",
            "Line1",
            "Line2",
            "Line3",
            "Line4",
            "Line5",
            "Line6",
            "Line7"});
            this.comboBox_TriggerSource.Location = new System.Drawing.Point(840, 321);
            this.comboBox_TriggerSource.Name = "comboBox_TriggerSource";
            this.comboBox_TriggerSource.Size = new System.Drawing.Size(141, 24);
            this.comboBox_TriggerSource.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(753, 329);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "触 发 源:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_TriggerSource);
            this.groupBox1.Controls.Add(this.label_TriggerMode);
            this.groupBox1.Controls.Add(this.label_Gain);
            this.groupBox1.Controls.Add(this.label_exposuretime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(743, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 173);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机参数";
            // 
            // button_Save
            // 
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.Location = new System.Drawing.Point(795, 370);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(159, 32);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "保    存";
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(795, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 32);
            this.button2.TabIndex = 13;
            this.button2.Text = "拍    照";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(795, 478);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 32);
            this.button3.TabIndex = 14;
            this.button3.Text = "实时模式";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "触 发 源:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "触发模式:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 72);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "增    益:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 40);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "曝光时间:";
            // 
            // label_TriggerSource
            // 
            this.label_TriggerSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_TriggerSource.AutoSize = true;
            this.label_TriggerSource.Location = new System.Drawing.Point(98, 134);
            this.label_TriggerSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TriggerSource.Name = "label_TriggerSource";
            this.label_TriggerSource.Size = new System.Drawing.Size(72, 16);
            this.label_TriggerSource.TabIndex = 17;
            this.label_TriggerSource.Text = "Software";
            // 
            // label_TriggerMode
            // 
            this.label_TriggerMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_TriggerMode.AutoSize = true;
            this.label_TriggerMode.Location = new System.Drawing.Point(98, 104);
            this.label_TriggerMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TriggerMode.Name = "label_TriggerMode";
            this.label_TriggerMode.Size = new System.Drawing.Size(24, 16);
            this.label_TriggerMode.TabIndex = 16;
            this.label_TriggerMode.Text = "On";
            // 
            // label_Gain
            // 
            this.label_Gain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Gain.AutoSize = true;
            this.label_Gain.Location = new System.Drawing.Point(98, 72);
            this.label_Gain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Gain.Name = "label_Gain";
            this.label_Gain.Size = new System.Drawing.Size(16, 16);
            this.label_Gain.TabIndex = 15;
            this.label_Gain.Text = "0";
            // 
            // label_exposuretime
            // 
            this.label_exposuretime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_exposuretime.AutoSize = true;
            this.label_exposuretime.Location = new System.Drawing.Point(98, 40);
            this.label_exposuretime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_exposuretime.Name = "label_exposuretime";
            this.label_exposuretime.Size = new System.Drawing.Size(16, 16);
            this.label_exposuretime.TabIndex = 14;
            this.label_exposuretime.Text = "0";
            // 
            // Form_Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 614);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox_TriggerSource);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_TriggerMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.num_gain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num__exposuretime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_CamList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayWindow1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Camera";
            this.Text = "相机";
            this.Load += new System.EventHandler(this.Form_Camera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num__exposuretime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_gain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolKit.DisplayWindow.DisplayWindow displayWindow1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_CamList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num__exposuretime;
        private System.Windows.Forms.NumericUpDown num_gain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_TriggerMode;
        private System.Windows.Forms.ComboBox comboBox_TriggerSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_TriggerSource;
        private System.Windows.Forms.Label label_TriggerMode;
        private System.Windows.Forms.Label label_Gain;
        private System.Windows.Forms.Label label_exposuretime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}