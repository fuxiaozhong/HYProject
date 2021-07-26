using System;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.Model;

namespace HYProject.MenuForm
{
    public partial class Form_Camera : Form
    {
        public Form_Camera()
        {
            InitializeComponent();
        }

        private void Form_Camera_Load(object sender, EventArgs e)
        {
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
            comboBox_TriggerMode.SelectedIndex = 0;
            comboBox_TriggerSource.SelectedIndex = 0;
        }

        private void Form_Camera_ImageProcessEvent(string cameraName, HalconDotNet.HObject ho_image)
        {
            QueueSaveImage.Instance.QueueEnqueue2(ho_image);
            displayWindow1.Disp_Image(ho_image);
        }

        private void ComboBox_CamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
            num__exposuretime.Value = (decimal)Cameras.Instance[this.comboBox_CamList.Text].Get_Exposure_Time();
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
            Cameras.Instance[comboBox_CamList.Text].Set_Exposure_Time((double)this.num__exposuretime.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_Gain((double)this.num_gain.Value);
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerMode(this.comboBox_TriggerMode.Text);
            Cameras.Instance[comboBox_CamList.Text].Set_TriggerSource(this.comboBox_TriggerSource.Text);
            Refresh();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Cameras.Instance[comboBox_CamList.Text].Soft_Trigger();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "实时模式")
            {
                button3.Text = "停止实时";
                Cameras.Instance[comboBox_CamList.Text].Start_Real_Mode();
            }
            else
            {
                button3.Text = "实时模式";
                Cameras.Instance[comboBox_CamList.Text].End_Real_Mode();
            }
            Refresh();
        }

        private void Form_Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                Cameras.Instance[item].ClearImageProcessEvents();
                Cameras.Instance[item].ImageProcessEvent += Cameras.Instance.Dahua_ImageProcessEvent;
            }
        }
    }
}