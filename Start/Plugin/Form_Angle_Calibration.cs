using System;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Model;

using ToolKit.DisplayWindow;
using ToolKit.HalconTool;
using ToolKit.HalconTool.Model;

namespace HYProject.Plugin
{
    public partial class Form_Angle_Calibration : ToolKit.HYControls.HYForm.HYBaseForm
    {
        public Form_Angle_Calibration()
        {
            InitializeComponent();
        }

        private void Form_Angle_Calibration_Load(object sender, EventArgs e)
        {
            measureParam = new MeasureParam();
            measureParam.Shape = MeasureShapes.line;
            propertyGrid1.SelectedObject = measureParam;
            AppParam.Instance.lightSource.OpenAllCH();
            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                Cameras.Instance[item].ClearImageProcessEvents();
                Cameras.Instance[item].ImageProcessEvent += this.Form_Camera_ImageProcessEvent;
            }
            textBox_Cam1_1_Angle.Text = CalibrationData.Instance.Cam1_1_Standard_Angle.ToString("0.00000");
            textBox_Cam1_2_Angle.Text = CalibrationData.Instance.Cam1_2_Standard_Angle.ToString("0.00000");
            textBox_Cam2_1_Angle.Text = CalibrationData.Instance.Cam2_1_Standard_Angle.ToString("0.00000");
            textBox_Cam2_2_Angle.Text = CalibrationData.Instance.Cam2_2_Standard_Angle.ToString("0.00000");
            textBox_Cam3_1_Angle.Text = CalibrationData.Instance.Cam3_1_Standard_Angle.ToString("0.00000");
            textBox_Cam3_2_Angle.Text = CalibrationData.Instance.Cam3_2_Standard_Angle.ToString("0.00000");
        }

        private void Form_Camera_ImageProcessEvent(string cameraName, HObject ho_image)
        {
            halconWindow1.Disp_Image(ho_image);
        }

        private void Form_Angle_Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppParam.Instance.lightSource.CloseAllCH();

            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                //清空事件
                Cameras.Instance[item].ClearImageProcessEvents();
                //重新绑定运行事件
                Cameras.Instance[item].ImageProcessEvent += Cameras.Instance.Camera_ImageProcessEvent;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "相机1":
                    Cameras.Instance["Cam1"].Soft_Trigger();
                    break;

                case "相机2":
                    Cameras.Instance["Cam2"].Soft_Trigger();
                    break;

                case "相机3":
                    Cameras.Instance["Cam3"].Soft_Trigger();
                    break;
            }
        }

        private MeasureParam measureParam;

        private void button1_Click(object sender, EventArgs e)
        {
            Line line = halconWindow1.Draw_Line("blue");
            measureParam.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(halconWindow1.Image);
            HTuple tuple = new HTuple(0.0, 0.0, 0.0, 0.0);
            HTuple Phi = new HTuple(0);
            HalconUtils.CaliperMeasure(halconWindow1, measureParam, halconWindow1.Image, out _, out tuple);
            HOperatorSet.LineOrientation(tuple[0], tuple[1], tuple[2], tuple[3], out Phi);
            HObject arrow;
            Work.gen_arrow_contour_xld(out arrow, tuple[0], tuple[1], tuple[2], tuple[3], 150, 200);
            halconWindow1.Disp_Region(arrow, "red", "margin");
            halconWindow1.Disp_Message("角度：" + Phi.TupleDeg(), 16, 10, 10, "blue");
            arrow.Dispose();

            if (comboBox1.Text == "相机1")
            {
                if (comboBox2.Text == "1号吸嘴")
                {
                    textBox_Cam1_1_Angle.Text = Phi.TupleDeg().D.ToString("0.00000");
                }
                else if (comboBox2.Text == "2号吸嘴")
                {
                    textBox_Cam1_2_Angle.Text = Phi.TupleDeg().D.ToString("0.00000");
                }
            }
            else if (comboBox1.Text == "相机2")
            {
                if (comboBox2.Text == "1号吸嘴")
                {
                    textBox_Cam2_1_Angle.Text = Phi.TupleDeg().D.ToString("0.00000");
                }
                else if (comboBox2.Text == "2号吸嘴")
                {
                    textBox_Cam2_2_Angle.Text = Phi.TupleDeg().D.ToString("0.00000");
                }
            }
            else if (comboBox1.Text == "相机3")
            {
                if (comboBox2.Text == "1号吸嘴")
                {
                    textBox_Cam3_1_Angle.Text = Phi.TupleDeg().D.ToString("0.00000");
                }
                else if (comboBox2.Text == "2号吸嘴")
                {
                    textBox_Cam3_2_Angle.Text = Phi.TupleDeg().D.ToString("0.00000");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalibrationData.Instance.Cam1_1_Standard_Angle = double.Parse(textBox_Cam1_1_Angle.Text);
            CalibrationData.Instance.Cam1_2_Standard_Angle = double.Parse(textBox_Cam1_2_Angle.Text);
            CalibrationData.Instance.Cam2_1_Standard_Angle = double.Parse(textBox_Cam2_1_Angle.Text);
            CalibrationData.Instance.Cam2_2_Standard_Angle = double.Parse(textBox_Cam2_2_Angle.Text);
            CalibrationData.Instance.Cam3_1_Standard_Angle = double.Parse(textBox_Cam3_1_Angle.Text);
            CalibrationData.Instance.Cam3_2_Standard_Angle = double.Parse(textBox_Cam3_2_Angle.Text);
            AppParam.Instance.Save_To_File();
            ShowNormal("保存成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}