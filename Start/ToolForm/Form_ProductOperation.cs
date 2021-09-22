using System;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;

using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_ProductOperation : HYBaseForm
    {
        private bool isNew = true;

        public Form_ProductOperation(string HYProduct = "")
        {
            InitializeComponent();
            if (HYProduct == "")
            {
                Text = "产品_添加";
                isNew = true;
            }
            else
            {
                product = (Product)Serialization.Read2(AppParam.Instance.ProductLibrary + "\\" + HYProduct + ".HYProduct");
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
                    HYMessageBox.Show("已取消保存!");
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

            Serialization.Save2(product, AppParam.Instance.ProductLibrary + "\\" + ProductName + ".HYProduct");
            HYMessageBox.Show("保存成功");
        }

        private void Form_ProductOperation_Load(object sender, EventArgs e)
        {
        }

        private void HyCreateModel1_Load(object sender, EventArgs e)
        {
        }
    }
}