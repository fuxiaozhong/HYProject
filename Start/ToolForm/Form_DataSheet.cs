using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;

using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_DataSheet : Form
    {

        private static Form_DataSheet instance;
        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static Form_DataSheet Instance
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
                            instance = new Form_DataSheet();
                        }
                    }
                }
                return instance;
            }
        }

        private Form_DataSheet()
        {
            InitializeComponent();
        }

        public void AddData(MeasureData measureData)
        {
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = index;
            dataGridView1.Rows[index].Cells[1].Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ffff");
            dataGridView1.Rows[index].Cells[2].Value = measureData.W_Value;
            dataGridView1.Rows[index].Cells[3].Value = measureData.PT_Value;
            dataGridView1.Rows[index].Cells[4].Value = measureData.M1_Value;
            dataGridView1.Rows[index].Cells[5].Value = measureData.M2_Value;
            dataGridView1.Rows[index].Cells[6].Value = measureData.P_Value;
            dataGridView1.Rows[index].Cells[7].Value = measureData.KJ_Value;
            dataGridView1.Rows[index].Cells[8].Value = measureData.S1_Value;
            dataGridView1.Rows[index].Cells[9].Value = measureData.S2_Value;
        }

        private void 导出到ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageWindow.Show("无数据导出!");
                return;
            }
            DataTable dataTable = NPOIExcel.DataGridViewToTable(dataGridView1);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文件(*.xls)|*.xls|Csv文件(*.csv)|*.csv|所有文件(*.*)|*.*";
            sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");//设置默认文件名
            sfd.DefaultExt = "xls";//设置默认格式（可以不设）
            sfd.AddExtension = true;//设置自动在文件名中添加扩展名
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (NPOIExcel.DataTableToExcel(dataTable, sfd.FileName))
                {
                    MessageWindow.Show(sfd.FileName + "导出成功");
                    Log.WriteRunLog("手动导出数据成功,\n" + sfd.FileName);
                }
                else
                {
                    MessageWindow.ShowError(sfd.FileName + "导出失败");
                    Log.WriteErrorLog("手动导出数据失败,\n" + sfd.FileName);
                }
            }
        }
    }
}
