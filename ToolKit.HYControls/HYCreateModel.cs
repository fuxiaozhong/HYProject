using System;
using System.Windows.Forms;

using HalconDotNet;

using ToolKit.HalconTool;
using ToolKit.HalconTool.Model;

namespace ToolKit.HYControls
{
    public partial class HYCreateModel : UserControl
    {
        private ModelParameter model = new ModelParameter();

        public HYCreateModel()
        {
            InitializeComponent();
        }

        private void GetConfig()
        {
            if (model_Shple.Checked)
                model.matchMode = MatchMode.BasedShape;
            else
                model.matchMode = MatchMode.BasedGray;

            model.minScore = (double)model_minScore.Value;
            model.matchNum = (int)model_matchNum.Value;
            model.angleStep = (int)model_angleStep.Value;
            model.polarity = model_polarity.Text == "使用极性" ? "use_polarity" : "ignore_global_polarity";
            model.startAngle = (int)model_startAngle.Value;
            model.angleRange = (int)model_angleRange.Value;
            model.minScale = (double)model_minScale.Value;
            model.maxScale = (double)model_maxScale.Value;
            model.contrast = (int)(model_contrastAuto.Checked ? -1 : model_contrast.Value);
            model.dispFindRegion = model_DispFindRegion.Checked;
            model.dispModel = model_DispModel.Checked;
            model.findRegionEnable = model_findRegionEnable.Checked;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            GetConfig();

            if (model.baseImage == null)
            {
                MessageBox.Show("请先导入图像", "Tips");
                return;
            }
            if (model.modelRegion == null)
            {
                MessageBox.Show("请先框选模板区域", "Tips");
                return;
            }
            if (HalconUtils.CreateModel(ref model))
            {
                MessageBox.Show("模板学习成功", "Tips");
                label12.Text = "模板学习成功";
                if (model.matchMode == MatchMode.BasedGray)
                {
                    HObject modelregion;
                    HOperatorSet.GetNccModelRegion(out modelregion, model.modelID);
                    displayWindow1.Disp_Image(model.baseImage);
                    displayWindow1.Disp_Region(modelregion, "blue", "margin");
                }
                else
                {
                    HObject modelregion;
                    HOperatorSet.GetShapeModelContours(out modelregion, model.modelID, 1);
                    HTuple HomMat2DIdentity;
                    HOperatorSet.HomMat2dIdentity(out HomMat2DIdentity);
                    HOperatorSet.HomMat2dTranslate(HomMat2DIdentity, model.modelCenterRow, model.modelCenterColumn, out HomMat2DIdentity);
                    HOperatorSet.AffineTransContourXld(modelregion, out modelregion, HomMat2DIdentity);
                    displayWindow1.Disp_Image(model.baseImage);
                    displayWindow1.Disp_Region(modelregion, "blue", "margin");
                }
            }
            else
            {
                MessageBox.Show("创建失败", "Tips");
                label12.Text = "模板学习失败";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            HObject image = displayWindow1.Open_Image();
            if (image != null)
            {
                model.baseImage = image;
                displayWindow1.Disp_Image(model.baseImage);
                model_polarity.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            HObject drawRegion = new HObject();
            HOperatorSet.GenEmptyObj(out drawRegion);
            drawRegion.Dispose();
            switch (button.Text)
            {
                case "矩形":
                    drawRegion = displayWindow1.Draw_Rectangle1("blue").rectangle1;
                    break;

                case "仿矩":
                    drawRegion = displayWindow1.Draw_Rectangle2("blue").rectangle2;
                    break;

                case "圆":
                    drawRegion = displayWindow1.Draw_Circle("blue").circle;
                    break;

                case "椭圆":
                    drawRegion = displayWindow1.Draw_Ellipse("blue").ellipse;
                    break;
            }

            if (radioButton4.Checked)
            {
                if (model.modelRegion != null)
                {
                    HOperatorSet.Union2(drawRegion, model.modelRegion, out model.modelRegion);
                }
                else
                {
                    model.modelRegion = drawRegion.Clone();
                }
            }
            else
            {
                HOperatorSet.Difference(model.modelRegion, drawRegion, out model.modelRegion);
            }
            HTuple area = new HTuple(0);
            HOperatorSet.AreaCenter(model.modelRegion, out area, out model.modelCenterRow, out model.modelCenterColumn);
            if (area > 0)
            {
                HOperatorSet.OrientationRegion(model.modelRegion, out model.modelCenterPhi);
                HObject ReduceImage;
                HOperatorSet.GenEmptyObj(out ReduceImage);
                ReduceImage.Dispose();
                HOperatorSet.ReduceDomain(model.baseImage, model.modelRegion, out ReduceImage);
                HOperatorSet.CropDomain(ReduceImage, out ReduceImage);
                model.modelImage = ReduceImage.Clone();
                displayWindow2.Disp_Image(ReduceImage);
                drawRegion.Dispose();
            }
            else
            {
                displayWindow1.HalconWindowHandle.ClearWindow();
            }

            displayWindow1.Disp_Image(model.baseImage);
            displayWindow1.Disp_Region(model.modelRegion, "blue", "margin");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            FindModel();
        }

        private void FindModel()
        {
            GetConfig();
            HTuple rows, cols, angles, scores;
            HalconTool.HalconUtils.FindModel(displayWindow1, model.baseImage, model, out rows, out cols, out angles, out scores);
            label12.Text = "找到:" + angles.Length + "个";
        }

        private void 显示模板图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayWindow1.Disp_Image(model.baseImage);
        }

        private void 显示模板区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayWindow1.Disp_Region(model.modelRegion, "green", "margin");
        }

        private void 显示搜索区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayWindow1.Disp_Region(model.findModelRegion, "green", "margin");
        }

        private void 测试查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetConfig();
            HTuple rows, cols, angles, scores;
            HalconTool.HalconUtils.FindModel(displayWindow1, displayWindow1.Open_Image(), model, out rows, out cols, out angles, out scores);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            HObject drawRegion = new HObject();
            HOperatorSet.GenEmptyObj(out drawRegion);
            drawRegion.Dispose();
            switch (comboBox2.Text)
            {
                case "矩形":
                    drawRegion = displayWindow1.Draw_Rectangle1("green").rectangle1;
                    break;

                case "仿矩":
                    drawRegion = displayWindow1.Draw_Rectangle2("green").rectangle2;
                    break;

                case "圆":
                    drawRegion = displayWindow1.Draw_Circle("green").circle;
                    break;

                case "椭圆":
                    drawRegion = displayWindow1.Draw_Ellipse("green").ellipse;
                    break;
            }
            if (model.findModelRegion == null)
            {
                HOperatorSet.GenEmptyObj(out model.findModelRegion);
            }
            model.findModelRegion.Dispose();
            model.findModelRegion = drawRegion.Clone();
            displayWindow1.Disp_Region(model.baseImage, "green", "margin");
            displayWindow1.Disp_Region(model.findModelRegion, "green", "margin");
            drawRegion.Dispose();
        }

        private void Model_contrastAuto_CheckedChanged(object sender, EventArgs e)
        {
            model_contrast.Enabled = !model_contrastAuto.Checked;
        }
    }
}