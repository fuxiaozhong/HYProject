using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;
using HYProject.ToolForm;

using ToolKit.HYControls;

namespace HYProject.MenuForm
{
    public partial class Form_ProjectLibrary : Form
    {
        public Form_ProjectLibrary()
        {
            InitializeComponent();
            Button_Refresh_Click(null, null);
        }
        private void Button_Refresh_Click(object sender, System.EventArgs e)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(AppParam.Instance.ProductLibrary);
            flowLayoutPanel1.Controls.Clear();
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                try
                {
                    Product product = (Product)Serialization.Read2(NextFile.FullName);
                    ProductInfo productInfo = new ProductInfo();
                    productInfo.CreateTime = product.CreateTime;
                    productInfo.ProductName = product.ProductName;
                    productInfo.ProductImage = product.ProductImage;
                    productInfo.DblClick += this.ProductInfo_DblClick;
                    productInfo.Click += this.ProductInfo_Click;
                    flowLayoutPanel1.Controls.Add(productInfo);
                }
                catch (Exception)
                {
                    // File.Delete(NextFile.FullName);
                }

            }
        }

        private void ProductInfo_Click(object sender, EventArgs e)
        {
            foreach (ProductInfo item in flowLayoutPanel1.Controls)
            {
                if (item == (sender as ProductInfo))
                    item.ShowBorder = true;
                else
                    item.ShowBorder = false;

            }
        }

        private void ProductInfo_DblClick(object sender, EventArgs e)
        {
            label_NowProductName.Text = (sender as ProductInfo).ProductName;
        }

        private void Button_Add_Click(object sender, System.EventArgs e)
        {
            Form_ProductOperation form_ProductOperation = new Form_ProductOperation();
            if (form_ProductOperation.ShowDialog() == DialogResult.OK)
            {
                label_NowProductName.Text = "";
                Button_Refresh_Click(sender, e);
            }
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (label_NowProductName.Text != "")
            {
                if (MessageBox.Show("确认删除此产品?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (File.Exists(AppParam.Instance.ProductLibrary + "\\" + label_NowProductName.Text + ".pro"))
                    {
                        File.Delete(AppParam.Instance.ProductLibrary + "\\" + label_NowProductName.Text + ".pro");
                        MessageBox.Show("产品:" + label_NowProductName.Text + "删除成功", "删除提示");
                        label_NowProductName.Text = "";
                        Button_Refresh_Click(sender, e);
                        Log.RunLog("产品:" + label_NowProductName.Text + "删除成功");
                    }
                }

            }
        }

        private void Button_Modify_Click(object sender, EventArgs e)
        {
            if (label_NowProductName.Text != "")
            {
                Form_ProductOperation form_ProductOperation = new Form_ProductOperation(label_NowProductName.Text);
                if (form_ProductOperation.ShowDialog() == DialogResult.OK)
                {
                    label_NowProductName.Text = "";
                    Button_Refresh_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("请先选择产品.");
            }

        }
    }
}