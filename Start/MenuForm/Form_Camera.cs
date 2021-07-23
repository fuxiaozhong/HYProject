using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            }
            comboBox_TriggerMode.SelectedIndex = 0;
            comboBox_TriggerSource.SelectedIndex = 0;
        }

        private void ComboBox_CamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_exposuretime.Text = Cameras.Instance[comboBox_CamList.Text].Get_Exposure_Time().ToString();
            label_Gain.Text = Cameras.Instance[comboBox_CamList.Text].Get_Gain().ToString();

        }
    }
}
