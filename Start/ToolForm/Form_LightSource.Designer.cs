
namespace HYProject.ToolForm
{
    partial class Form_LightSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LightSource));
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.switch4 = new ToolKit.HYControls.SwitchControl();
            this.switch3 = new ToolKit.HYControls.SwitchControl();
            this.switch2 = new ToolKit.HYControls.SwitchControl();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.switch1 = new ToolKit.HYControls.SwitchControl();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Port = new System.Windows.Forms.Button();
            this.serialPortConfigurationControl1 = new ToolKit.HYControls.SerialPortConfigurationControl();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(218, 118);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(79, 21);
            this.numericUpDown5.TabIndex = 40;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.NumericUpDown5_ValueChanged);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(218, 87);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(79, 21);
            this.numericUpDown4.TabIndex = 39;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.NumericUpDown4_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(217, 57);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(79, 21);
            this.numericUpDown3.TabIndex = 38;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.NumericUpDown3_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(218, 27);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(79, 21);
            this.numericUpDown2.TabIndex = 37;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.NumericUpDown2_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "CH2:";
            // 
            // switch4
            // 
            this.switch4.BackColor = System.Drawing.Color.Transparent;
            this.switch4.Checked = false;
            this.switch4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switch4.Location = new System.Drawing.Point(304, 119);
            this.switch4.Margin = new System.Windows.Forms.Padding(5);
            this.switch4.Name = "switch4";
            this.switch4.Size = new System.Drawing.Size(51, 20);
            this.switch4.TabIndex = 36;
            this.switch4.Click += new System.EventHandler(this.Switch4_Click);
            // 
            // switch3
            // 
            this.switch3.BackColor = System.Drawing.Color.Transparent;
            this.switch3.Checked = false;
            this.switch3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switch3.Location = new System.Drawing.Point(304, 89);
            this.switch3.Margin = new System.Windows.Forms.Padding(5);
            this.switch3.Name = "switch3";
            this.switch3.Size = new System.Drawing.Size(51, 20);
            this.switch3.TabIndex = 35;
            this.switch3.Click += new System.EventHandler(this.Switch3_Click);
            // 
            // switch2
            // 
            this.switch2.BackColor = System.Drawing.Color.Transparent;
            this.switch2.Checked = false;
            this.switch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switch2.Location = new System.Drawing.Point(304, 57);
            this.switch2.Margin = new System.Windows.Forms.Padding(5);
            this.switch2.Name = "switch2";
            this.switch2.Size = new System.Drawing.Size(51, 20);
            this.switch2.TabIndex = 34;
            this.switch2.Click += new System.EventHandler(this.Switch2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 92);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "CH3:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(181, 124);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "CH4:";
            // 
            // switch1
            // 
            this.switch1.BackColor = System.Drawing.Color.Transparent;
            this.switch1.Checked = false;
            this.switch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switch1.Location = new System.Drawing.Point(304, 29);
            this.switch1.Margin = new System.Windows.Forms.Padding(4);
            this.switch1.Name = "switch1";
            this.switch1.Size = new System.Drawing.Size(51, 20);
            this.switch1.TabIndex = 30;
            this.switch1.Click += new System.EventHandler(this.Switch1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "CH1:";
            // 
            // button_Port
            // 
            this.button_Port.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Port.Location = new System.Drawing.Point(13, 158);
            this.button_Port.Name = "button_Port";
            this.button_Port.Size = new System.Drawing.Size(95, 27);
            this.button_Port.TabIndex = 28;
            this.button_Port.Text = "打开光源";
            this.button_Port.UseVisualStyleBackColor = true;
            this.button_Port.Click += new System.EventHandler(this.Button_Port_Click);
            // 
            // serialPortConfigurationControl1
            // 
            this.serialPortConfigurationControl1.BaudRate = 19200;
            this.serialPortConfigurationControl1.DataBits = 8;
            this.serialPortConfigurationControl1.Font = new System.Drawing.Font("宋体", 9F);
            this.serialPortConfigurationControl1.Location = new System.Drawing.Point(13, 28);
            this.serialPortConfigurationControl1.Margin = new System.Windows.Forms.Padding(4);
            this.serialPortConfigurationControl1.Name = "serialPortConfigurationControl1";
            this.serialPortConfigurationControl1.Parity = System.IO.Ports.Parity.None;
            this.serialPortConfigurationControl1.PortName = "COM2";
            this.serialPortConfigurationControl1.Size = new System.Drawing.Size(159, 123);
            this.serialPortConfigurationControl1.StopBits = System.IO.Ports.StopBits.One;
            this.serialPortConfigurationControl1.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(115, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 27);
            this.button1.TabIndex = 41;
            this.button1.Text = "关闭光源";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form_LightSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 190);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.serialPortConfigurationControl1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.button_Port);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.switch1);
            this.Controls.Add(this.switch4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.switch3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.switch2);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideMaxButtom = false;
            this.HideMinButtom = false;
            this.HideOrClose = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_LightSource";
            this.Text = "光源控制";
            this.Load += new System.EventHandler(this.Form_LightSource_Load);
            this.Controls.SetChildIndex(this.switch2, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.switch3, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.switch4, 0);
            this.Controls.SetChildIndex(this.switch1, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.numericUpDown2, 0);
            this.Controls.SetChildIndex(this.button_Port, 0);
            this.Controls.SetChildIndex(this.numericUpDown3, 0);
            this.Controls.SetChildIndex(this.serialPortConfigurationControl1, 0);
            this.Controls.SetChildIndex(this.numericUpDown4, 0);
            this.Controls.SetChildIndex(this.numericUpDown5, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label10;
        private ToolKit.HYControls.SwitchControl switch4;
        private ToolKit.HYControls.SwitchControl switch3;
        private ToolKit.HYControls.SwitchControl switch2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private ToolKit.HYControls.SwitchControl switch1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_Port;
        private ToolKit.HYControls.SerialPortConfigurationControl serialPortConfigurationControl1;
        private System.Windows.Forms.Button button1;
    }
}