
namespace HYProject.MenuForm
{
    partial class Form_Plugin
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("系统设置");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("光源设置");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("相机设置");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("图像保存");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("图像设置", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("PLC设置");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("添加用户");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("修改用户");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("删除用户");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("用户设置", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("TCP通讯");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("COM通讯");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("通讯设置", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControlEx1 = new ToolKit.HYControls.TabControlEx();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlEx1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 418);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("华文楷体", 15F, System.Drawing.FontStyle.Bold);
            this.treeView1.ItemHeight = 30;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "系统设置";
            treeNode2.Name = "节点1";
            treeNode2.Text = "光源设置";
            treeNode3.Name = "节点2";
            treeNode3.Text = "相机设置";
            treeNode4.Name = "节点11";
            treeNode4.Text = "图像保存";
            treeNode5.Name = "节点3";
            treeNode5.Text = "图像设置";
            treeNode6.Name = "节点0";
            treeNode6.Text = "PLC设置";
            treeNode7.Name = "节点7";
            treeNode7.Text = "添加用户";
            treeNode8.Name = "节点8";
            treeNode8.Text = "修改用户";
            treeNode9.Name = "节点9";
            treeNode9.Text = "删除用户";
            treeNode10.Name = "节点1";
            treeNode10.Text = "用户设置";
            treeNode11.Name = "节点13";
            treeNode11.Text = "TCP通讯";
            treeNode12.Name = "节点15";
            treeNode12.Text = "COM通讯";
            treeNode13.Name = "节点12";
            treeNode13.Text = "通讯设置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode5,
            treeNode6,
            treeNode10,
            treeNode13});
            this.treeView1.Size = new System.Drawing.Size(182, 418);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseDoubleClick);
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEx1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlEx1.ItemSize = new System.Drawing.Size(150, 30);
            this.tabControlEx1.Location = new System.Drawing.Point(0, 0);
            this.tabControlEx1.Multiline = true;
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.Padding = new System.Drawing.Point(15, 5);
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(609, 418);
            this.tabControlEx1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlEx1.TabIndex = 0;
            // 
            // Form_Plugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.HideAll = true;
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideOrClose = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Name = "Form_Plugin";
            this.Text = "插件";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private ToolKit.HYControls.TabControlEx tabControlEx1;
    }
}