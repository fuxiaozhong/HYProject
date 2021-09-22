
namespace HYProject.Plugin
{
    partial class Form_Angle_Calibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Angle_Calibration));
            this.halconWindow1 = new ToolKit.DisplayWindow.HalconWindow();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Cam1_1_Angle = new System.Windows.Forms.TextBox();
            this.textBox_Cam1_2_Angle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Cam2_1_Angle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Cam2_2_Angle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Cam3_1_Angle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Cam3_2_Angle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // halconWindow1
            // 
            this.halconWindow1.BackColor = System.Drawing.Color.Transparent;
            this.halconWindow1.Location = new System.Drawing.Point(4, 28);
            this.halconWindow1.Name = "halconWindow1";
            this.halconWindow1.Size = new System.Drawing.Size(442, 436);
            this.halconWindow1.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Teal;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(469, 69);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 29);
            this.button5.TabIndex = 46;
            this.button5.Text = "拍照";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "相机1",
            "相机2",
            "相机3"});
            this.comboBox1.Location = new System.Drawing.Point(500, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 47;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1号吸嘴",
            "2号吸嘴"});
            this.comboBox2.Location = new System.Drawing.Point(678, 29);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "相机：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "吸嘴：";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(613, 69);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(202, 347);
            this.propertyGrid1.TabIndex = 51;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(469, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 29);
            this.button1.TabIndex = 52;
            this.button1.Text = "画线";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(469, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 29);
            this.button2.TabIndex = 53;
            this.button2.Text = "测量角度";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Teal;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(693, 428);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 29);
            this.button3.TabIndex = 54;
            this.button3.Text = "关闭";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(550, 428);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 29);
            this.button4.TabIndex = 55;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 56;
            this.label3.Text = "Cam1_1_Angle:";
            // 
            // textBox_Cam1_1_Angle
            // 
            this.textBox_Cam1_1_Angle.Location = new System.Drawing.Point(541, 179);
            this.textBox_Cam1_1_Angle.Name = "textBox_Cam1_1_Angle";
            this.textBox_Cam1_1_Angle.Size = new System.Drawing.Size(66, 21);
            this.textBox_Cam1_1_Angle.TabIndex = 57;
            this.textBox_Cam1_1_Angle.Text = "0.00000";
            // 
            // textBox_Cam1_2_Angle
            // 
            this.textBox_Cam1_2_Angle.Location = new System.Drawing.Point(541, 206);
            this.textBox_Cam1_2_Angle.Name = "textBox_Cam1_2_Angle";
            this.textBox_Cam1_2_Angle.Size = new System.Drawing.Size(66, 21);
            this.textBox_Cam1_2_Angle.TabIndex = 59;
            this.textBox_Cam1_2_Angle.Text = "0.00000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 58;
            this.label4.Text = "Cam1_2_Angle:";
            // 
            // textBox_Cam2_1_Angle
            // 
            this.textBox_Cam2_1_Angle.Location = new System.Drawing.Point(541, 233);
            this.textBox_Cam2_1_Angle.Name = "textBox_Cam2_1_Angle";
            this.textBox_Cam2_1_Angle.Size = new System.Drawing.Size(66, 21);
            this.textBox_Cam2_1_Angle.TabIndex = 61;
            this.textBox_Cam2_1_Angle.Text = "0.00000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 60;
            this.label5.Text = "Cam2_1_Angle:";
            // 
            // textBox_Cam2_2_Angle
            // 
            this.textBox_Cam2_2_Angle.Location = new System.Drawing.Point(541, 260);
            this.textBox_Cam2_2_Angle.Name = "textBox_Cam2_2_Angle";
            this.textBox_Cam2_2_Angle.Size = new System.Drawing.Size(66, 21);
            this.textBox_Cam2_2_Angle.TabIndex = 63;
            this.textBox_Cam2_2_Angle.Text = "0.00000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "Cam2_2_Angle:";
            // 
            // textBox_Cam3_1_Angle
            // 
            this.textBox_Cam3_1_Angle.Location = new System.Drawing.Point(541, 287);
            this.textBox_Cam3_1_Angle.Name = "textBox_Cam3_1_Angle";
            this.textBox_Cam3_1_Angle.Size = new System.Drawing.Size(66, 21);
            this.textBox_Cam3_1_Angle.TabIndex = 65;
            this.textBox_Cam3_1_Angle.Text = "0.00000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 64;
            this.label7.Text = "Cam3_1_Angle:";
            // 
            // textBox_Cam3_2_Angle
            // 
            this.textBox_Cam3_2_Angle.Location = new System.Drawing.Point(541, 314);
            this.textBox_Cam3_2_Angle.Name = "textBox_Cam3_2_Angle";
            this.textBox_Cam3_2_Angle.Size = new System.Drawing.Size(66, 21);
            this.textBox_Cam3_2_Angle.TabIndex = 67;
            this.textBox_Cam3_2_Angle.Text = "0.00000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 66;
            this.label8.Text = "Cam3_2_Angle:";
            // 
            // Form_Angle_Calibration
            // 
            this.ClientSize = new System.Drawing.Size(827, 469);
            this.Controls.Add(this.textBox_Cam3_2_Angle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_Cam3_1_Angle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Cam2_2_Angle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Cam2_1_Angle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Cam1_2_Angle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Cam1_1_Angle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.halconWindow1);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Name = "Form_Angle_Calibration";
            this.Text = "角度标定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Angle_Calibration_FormClosing);
            this.Load += new System.EventHandler(this.Form_Angle_Calibration_Load);
            this.Controls.SetChildIndex(this.halconWindow1, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.comboBox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBox_Cam1_1_Angle, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBox_Cam1_2_Angle, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textBox_Cam2_1_Angle, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.textBox_Cam2_2_Angle, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.textBox_Cam3_1_Angle, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.textBox_Cam3_2_Angle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolKit.DisplayWindow.HalconWindow halconWindow1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Cam1_1_Angle;
        private System.Windows.Forms.TextBox textBox_Cam1_2_Angle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Cam2_1_Angle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Cam2_2_Angle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Cam3_1_Angle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Cam3_2_Angle;
        private System.Windows.Forms.Label label8;
    }
}
