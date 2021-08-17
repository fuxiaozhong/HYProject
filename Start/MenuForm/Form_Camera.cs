using System;
using System.Windows.Forms;

using HYProject.Model;
using HYProject.ToolForm;

using ToolKit.HYControls.HYForm;
using ToolKit.MaterialSkin.Controls;

namespace HYProject.MenuForm
{
    public partial class Form_Camera : BaseForm
    {
        public Form_Camera()
        {
            InitializeComponent();
        }

        private void Form_Camera_Load(object sender, EventArgs e)
        {
            ///初始化相机  列举相机列表
            comboBox_CamList.Items.Clear();
            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                comboBox_CamList.Items.Add(item);
                Cameras.Instance[item].ClearImageProcessEvents();
                Cameras.Instance[item].ImageProcessEvent += this.Form_Camera_ImageProcessEvent;
            }
            if (comboBox_CamList.Items.Count > 0)
            {
                comboBox_CamList.SelectedIndex = 0;
            }
            else
            {
                num_gain.Enabled = false;
                num_exposuretime.Enabled = false;
                comboBox_TriggerMode.Enabled = false;
                comboBox_TriggerSource.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button_Save.Enabled = false;
            }
            comboBox_TriggerMode.SelectedIndex = 0;
            comboBox_TriggerSource.SelectedIndex = 0;
        }

        private void Form_Camera_ImageProcessEvent(string cameraName, HalconDotNet.HObject ho_image)
        {
            //显示图像
            //QueueSaveImage.Instance.QueueEnqueue2(ho_image);
            displayWindow1.Disp_Image(ho_image);
            DisplayForm.Instance["1"].Disp_Image(ho_image);
            DisplayForm.Instance["2"].Disp_Image(ho_image);
            DisplayForm.Instance["3"].Disp_Image(ho_image);
            DisplayForm.Instance["4"].Disp_Image(ho_image);
            DisplayForm.Instance["5"].Disp_Image(ho_image);
        }

        private void ComboBox_CamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button3.Text == "停止实时")
            {
                foreach (var item in Cameras.Instance.GetCameras.Keys)
                {
                    Cameras.Instance[item].End_Real_Mode();
                }
                button3.Text = "实时模式";
            }
            //刷新数据
            Refresh();
            num_exposuretime.Value = (decimal)Cameras.Instance[this.comboBox_CamList.Text].Get_Exposure_Time();
            num_gain.Value = (decimal)Cameras.Instance[this.comboBox_CamList.Text].Get_Gain();
            comboBox_TriggerMode.Text = Cameras.Instance[this.comboBox_CamList.Text].Get_TriggerMode();
            comboBox_TriggerSource.Text = Cameras.Instance[this.comboBox_CamList.Text].Get_TriggerSource();
        }

        private void Refresh()
        {
            label_exposuretime.Text = Cameras.Instance[comboBox_CamList.Text].Get_Exposure_Time().ToString();
            label_Gain.Text = Cameras.Instance[comboBox_CamList.Text].Get_Gain().ToString("0");
            label_TriggerMode.Text = Cameras.Instance[comboBox_CamList.Text].Get_TriggerMode().ToString();
            label_TriggerSource.Text = Cameras.Instance[comboBox_CamList.Text].Get_TriggerSource().ToString();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            //设置相机参数
            Cameras.Instance[comboBox_CamList.Text].Set_Exposure_Time((double)this.num_exposuretime.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_Gain((double)this.num_gain.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerMode(this.comboBox_TriggerMode.Text);
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerSource(this.comboBox_TriggerSource.Text);
            Refresh();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //软触发
            Cameras.Instance[comboBox_CamList.Text].Soft_Trigger();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "实时模式")
            {
                button3.Text = "停止实时";
                Cameras.Instance[comboBox_CamList.Text].Start_Real_Mode();
                comboBox_CamList.Enabled = false;
            }
            else
            {
                button3.Text = "实时模式";
                Cameras.Instance[comboBox_CamList.Text].End_Real_Mode();
                comboBox_CamList.Enabled = true;
            }
            Refresh();
        }

        /// <summary>
        /// 退出小计操作 绑定运行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                //关闭实时
                Cameras.Instance[item].End_Real_Mode();
                System.Threading.Thread.Sleep(300);
                //清空事件
                Cameras.Instance[item].ClearImageProcessEvents();
                //重新绑定运行事件
                Cameras.Instance[item].ImageProcessEvent += Cameras.Instance.Camera_ImageProcessEvent;
            }
        }
    }
}