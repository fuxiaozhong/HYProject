using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;

using ToolKit.HYControls;

namespace HYProject.ToolForm
{
    public partial class Form_ProductOperation : Form
    {
        public Form_ProductOperation(Product pro = null)
        {
            InitializeComponent();
            if (pro == null)
            {
                Text = "产品_添加";
            }
            else
            {
                product = pro;
                ProductName = product.ProductName;
                Text = "产品_修改" + ("-" + ProductName);
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
                    MessageBox.Show("已取消保存!");
                }
            }
            else
            {
                Save();
            }

        }

        private void Save()
        {
            product = new Product();
            Serialization.Save2(product, AppParam.Instance.ProductLibrary + "\\" + ProductName + ".pro");
            MessageBox.Show("保存成功");
        }
    }
}
