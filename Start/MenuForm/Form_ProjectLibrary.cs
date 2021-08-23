using System;
using System.IO;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;
using HYProject.ToolForm;

using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;

namespace HYProject.MenuForm
{
    public partial class Form_ProjectLibrary : HYBaseForm
    {
        private static Form_ProjectLibrary instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static Form_ProjectLibrary Instance
        {
            get
            {
                //先判断是否存在，不存在再加锁处理
                if (instance == null)
                {
                    //在同一个时刻加了锁的那部分程序只有一个线程可以进入
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Form_ProjectLibrary();
                        }
                    }
                }
                return instance;
            }
        }

        private Form_ProjectLibrary()
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
                    HYProductInfo productInfo = new HYProductInfo();
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
            foreach (HYProductInfo item in flowLayoutPanel1.Controls)
            {
                if (item == (sender as HYProductInfo))
                    item.ShowBorder = true;
                else
                    item.ShowBorder = false;
            }
        }

        private void ProductInfo_DblClick(object sender, EventArgs e)
        {
            label_NowProductName.Text = (sender as HYProductInfo).ProductName;
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
                if (HYMessageBox.Show("确认删除此产品?", "提示") == DialogResult.OK)
                {
                    if (File.Exists(AppParam.Instance.ProductLibrary + "\\" + label_NowProductName.Text + ".HYProduct"))
                    {
                        File.Delete(AppParam.Instance.ProductLibrary + "\\" + label_NowProductName.Text + ".HYProduct");
                        HYMessageBox.Show("产品:" + label_NowProductName.Text + "删除成功", "删除提示");
                        Log.WriteRunLog("产品:" + label_NowProductName.Text + "删除成功");
                        label_NowProductName.Text = "";
                        Button_Refresh_Click(sender, e);
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
                HYMessageBox.Show("请先选择产品.");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Product product = (Product)Serialization.Read2(AppParam.Instance.ProductLibrary + "\\" + label_NowProductName.Text + ".HYProduct");



        }
    }
}