using System;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;

using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_ProductOperation : BaseForm
    {
        private bool isNew = true;

        public Form_ProductOperation(string pro = "")
        {
            InitializeComponent();
            if (pro == "")
            {
                Text = "产品_添加";
                isNew = true;
            }
            else
            {
                product = (Product)Serialization.Read2(AppParam.Instance.ProductLibrary + "\\" + pro + ".pro");
                ProductName = product.ProductName;
                Text = "产品_修改" + ("-" + ProductName);
                isNew = false;
            }
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private string ProductName = "";
        private Product product;

        private void Button_save_Click(object sender, EventArgs e)
        {
            if (ProductName == "")
            {
                if (HYInputDialog.InputStringDialog(ref ProductName, true, "请输入产品名:"))
                {
                    Text += ("-" + ProductName);
                    Save();
                }
                else
                {
                    MessageWindow.Show("已取消保存!");
                }
            }
            else
            {
                Save();
            }
        }

        private void Save()
        {
            if (isNew)
            {
                product = new Product();
            }
            Serialization.Save2(product, AppParam.Instance.ProductLibrary + "\\" + ProductName + ".pro");
            MessageWindow.Show("保存成功");
        }
    }
}