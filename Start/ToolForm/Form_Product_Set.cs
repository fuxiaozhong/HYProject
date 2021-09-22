using System;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Model;

using ToolKit.DisplayWindow;
using ToolKit.HalconTool;

namespace HYProject.ToolForm
{
    public partial class Form_Product_Set : ToolKit.HYControls.HYForm.HYBaseForm
    {
        public Form_Product_Set()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Top")
            {
                if (AppParam.Instance.product.Cam1_Top1 == null)
                {
                    AppParam.Instance.product.Cam1_Top1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Top1;
            }
            else if (comboBox1.Text == "Button")
            {
                if (AppParam.Instance.product.Cam1_Button1 == null)
                {
                    AppParam.Instance.product.Cam1_Button1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Button1;
            }
            else if (comboBox1.Text == "Left")
            {
                if (AppParam.Instance.product.Cam1_Left1 == null)
                {
                    AppParam.Instance.product.Cam1_Left1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Left1;
            }
            else if (comboBox1.Text == "Right")
            {
                if (AppParam.Instance.product.Cam1_Right1 == null)
                {
                    AppParam.Instance.product.Cam1_Right1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Right1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image1);
            HObject InvertImage;
            HOperatorSet.GenEmptyObj(out InvertImage);
            HOperatorSet.CopyImage(AppParam.Instance.product.Cam1_Image1, out InvertImage);
            if (comboBox1.Text == "Top")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top1, InvertImage, out _, out _);
            }
            else if (comboBox1.Text == "Button")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Button1, InvertImage, out _, out _);
            }
            else if (comboBox1.Text == "Left")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left1, InvertImage, out _, out _);
            }
            else if (comboBox1.Text == "Right")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Right1, InvertImage, out _, out _);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HObject image = halconWindow1.Open_Image();
            if (image != null)
            {
                halconWindow1.Disp_Image(image);
                HOperatorSet.CopyImage(image, out AppParam.Instance.product.Cam1_Image1);
                image.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Line line = halconWindow1.Draw_Line("blue");
            if (comboBox1.Text == "Top")
            {
                AppParam.Instance.product.Cam1_Top1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Top1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox1.Text == "Button")
            {
                AppParam.Instance.product.Cam1_Button1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Button1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox1.Text == "Left")
            {
                AppParam.Instance.product.Cam1_Left1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Left1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox1.Text == "Right")
            {
                AppParam.Instance.product.Cam1_Right1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Right1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image1);
            Test(1, 1);
            //HObject InvertImage;
            //HOperatorSet.GenEmptyObj(out InvertImage);
            //HTuple Top = new HTuple(0.0, 0.0, 0.0, 0.0);
            //HTuple Left = new HTuple(0.0, 0.0, 0.0, 0.0);
            //HTuple Button = new HTuple(0.0, 0.0, 0.0, 0.0);
            //HTuple Right = new HTuple(0.0, 0.0, 0.0, 0.0);
            //HOperatorSet.InvertImage(AppParam.Instance.product.Cam1_Image1, out InvertImage);
            //HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top1, InvertImage, out _, out Top);
            //HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Button1, InvertImage, out _, out Button);
            //HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left1, InvertImage, out _, out Left);
            //HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Right1, InvertImage, out _, out Right);
            //HTuple LeftUpRow;
            //HTuple LeftUpColumn;
            //HTuple LeftDownRow;
            //HTuple LeftDownColumn;
            //HTuple RightUpRow;
            //HTuple RightUpColumn;
            //HTuple RightDownRow;
            //HTuple RightDownColumn;
            //HTuple CenterRow;
            //HTuple CenterColumn;
            //HTuple Phi;

            //HOperatorSet.IntersectionLines(Left[0], Left[1], Left[2], Left[3], Top[2], Top[3], Top[0], Top[1], out LeftUpRow, out LeftUpColumn, out _);
            //HOperatorSet.IntersectionLines(Left[0], Left[1], Left[2], Left[3], Button[0], Button[1], Button[2], Button[3], out LeftDownRow, out LeftDownColumn, out _);
            //HOperatorSet.IntersectionLines(Right[0], Right[1], Right[2], Right[3], Top[0], Top[1], Top[2], Top[3], out RightUpRow, out RightUpColumn, out _);
            //HOperatorSet.IntersectionLines(Button[0], Button[1], Button[2], Button[3], Right[0], Right[1], Right[2], Right[3], out RightDownRow, out RightDownColumn, out _);
            //HOperatorSet.IntersectionLines(LeftUpRow, LeftUpColumn, RightDownRow, RightDownColumn, RightUpRow, RightUpColumn, LeftDownRow, LeftDownColumn, out CenterRow, out CenterColumn, out _);

            //HObject Line1;
            //HOperatorSet.GenEmptyObj(out Line1);
            //HObject Line2;
            //HOperatorSet.GenEmptyObj(out Line2);

            //HOperatorSet.GenRegionLine(out Line1, LeftUpRow, LeftUpColumn, RightDownRow, RightDownColumn);
            //HOperatorSet.GenRegionLine(out Line2, RightUpRow, RightUpColumn, LeftDownRow, LeftDownColumn);

            //HObject LeftLine;
            //HOperatorSet.GenEmptyObj(out LeftLine);
            //HOperatorSet.GenRegionLine(out LeftLine, LeftUpRow, LeftUpColumn, LeftDownRow, LeftDownColumn);
            //HOperatorSet.LineOrientation(LeftDownRow, LeftDownColumn, LeftUpRow, LeftUpColumn, out Phi);

            //halconWindow1.Disp_Region(Line1, "green", "margin");
            //halconWindow1.Disp_Region(Line2, "green", "margin");
            //halconWindow1.Disp_Cross(LeftUpRow, LeftUpColumn, 200, "green");
            //halconWindow1.Disp_Cross(LeftDownRow, LeftDownColumn, 200, "green");
            //halconWindow1.Disp_Cross(RightUpRow, RightUpColumn, 200, "green");
            //halconWindow1.Disp_Cross(RightDownRow, RightDownColumn, 200, "green");
            //halconWindow1.Disp_Cross(CenterRow, CenterColumn, 200, "green");

            //halconWindow1.Disp_Message("Row:" + CenterRow.D + "\nColumn:" + CenterColumn + "\nAngle:" + Phi.TupleDeg().D, 16, 10, 10, "green");
        }

        public void Test(int CamIndex, int NozzleIndex)
        {
            try
            {
                HObject InvertImage;
                HOperatorSet.GenEmptyObj(out InvertImage);
                HTuple Top = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Left = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Button = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Right = new HTuple(0.0, 0.0, 0.0, 0.0);
                if (CamIndex == 1)
                {
                    if (NozzleIndex == 1)
                    {
                        HOperatorSet.CopyImage(AppParam.Instance.product.Cam1_Image1, out InvertImage);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top1, InvertImage, out _, out Top);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Button1, InvertImage, out _, out Button);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left1, InvertImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Right1, InvertImage, out _, out Right);
                    }
                    else
                    {
                        HOperatorSet.CopyImage(AppParam.Instance.product.Cam1_Image2, out InvertImage);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top2, InvertImage, out _, out Top);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Button2, InvertImage, out _, out Button);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left2, InvertImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Right2, InvertImage, out _, out Right);
                    }
                }
                else if (CamIndex == 2)
                {
                    if (NozzleIndex == 1)
                    {
                        HOperatorSet.CopyImage(AppParam.Instance.product.Cam2_Image1, out InvertImage);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top1, InvertImage, out _, out Top);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Button1, InvertImage, out _, out Button);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left1, InvertImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Right1, InvertImage, out _, out Right);
                    }
                    else
                    {
                        HOperatorSet.CopyImage(AppParam.Instance.product.Cam2_Image2, out InvertImage);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top2, InvertImage, out _, out Top);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Button2, InvertImage, out _, out Button);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left2, InvertImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Right2, InvertImage, out _, out Right);
                    }
                }
                else if (CamIndex == 3)
                {
                    if (NozzleIndex == 1)
                    {
                        HOperatorSet.CopyImage(AppParam.Instance.product.Cam3_Image1, out InvertImage);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top1, InvertImage, out _, out Top);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Button1, InvertImage, out _, out Button);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left1, InvertImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Right1, InvertImage, out _, out Right);
                    }
                    else
                    {
                        HOperatorSet.CopyImage(AppParam.Instance.product.Cam3_Image2, out InvertImage);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top2, InvertImage, out _, out Top);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Button2, InvertImage, out _, out Button);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left2, InvertImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Right2, InvertImage, out _, out Right);
                    }
                }

                HTuple LeftUpRow;
                HTuple LeftUpColumn;
                HTuple LeftDownRow;
                HTuple LeftDownColumn;
                HTuple RightUpRow;
                HTuple RightUpColumn;
                HTuple RightDownRow;
                HTuple RightDownColumn;
                HTuple CenterRow;
                HTuple CenterColumn;
                HTuple Phi;

                HOperatorSet.IntersectionLines(Left[0], Left[1], Left[2], Left[3], Top[2], Top[3], Top[0], Top[1], out LeftUpRow, out LeftUpColumn, out _);
                HOperatorSet.IntersectionLines(Left[0], Left[1], Left[2], Left[3], Button[0], Button[1], Button[2], Button[3], out LeftDownRow, out LeftDownColumn, out _);
                HOperatorSet.IntersectionLines(Right[0], Right[1], Right[2], Right[3], Top[0], Top[1], Top[2], Top[3], out RightUpRow, out RightUpColumn, out _);
                HOperatorSet.IntersectionLines(Button[0], Button[1], Button[2], Button[3], Right[0], Right[1], Right[2], Right[3], out RightDownRow, out RightDownColumn, out _);
                HOperatorSet.IntersectionLines(LeftUpRow, LeftUpColumn, RightDownRow, RightDownColumn, RightUpRow, RightUpColumn, LeftDownRow, LeftDownColumn, out CenterRow, out CenterColumn, out _);

                HObject Line1;
                HOperatorSet.GenEmptyObj(out Line1);
                HObject Line2;
                HOperatorSet.GenEmptyObj(out Line2);

                HOperatorSet.GenRegionLine(out Line1, LeftUpRow, LeftUpColumn, RightDownRow, RightDownColumn);
                HOperatorSet.GenRegionLine(out Line2, RightUpRow, RightUpColumn, LeftDownRow, LeftDownColumn);

                HObject LeftLine;
                HOperatorSet.GenEmptyObj(out LeftLine);
                HOperatorSet.GenRegionLine(out LeftLine, LeftUpRow, LeftUpColumn, LeftDownRow, LeftDownColumn);
                HOperatorSet.LineOrientation(LeftDownRow, LeftDownColumn, LeftUpRow, LeftUpColumn, out Phi);

                halconWindow1.Disp_Region(Line1, "green", "margin");
                halconWindow1.Disp_Region(Line2, "green", "margin");
                halconWindow1.Disp_Cross(LeftUpRow, LeftUpColumn, 200, Phi, "green");
                halconWindow1.Disp_Cross(LeftDownRow, LeftDownColumn, 200, Phi, "green");
                halconWindow1.Disp_Cross(RightUpRow, RightUpColumn, 200, Phi, "green");
                halconWindow1.Disp_Cross(RightDownRow, RightDownColumn, 200, Phi, "green");
                halconWindow1.Disp_Cross(CenterRow, CenterColumn, 200, Phi, "green");

                halconWindow1.Disp_Message("Row:" + CenterRow.D + "\nColumn:" + CenterColumn + "\nAngle:" + Phi.TupleDeg().D, 16, 10, 10, "green");
            }
            catch (Exception)
            {
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            index = 12;
            Cameras.Instance["Cam1"].Soft_Trigger();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            index = 11;
            Cameras.Instance["Cam1"].Soft_Trigger();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HObject image = halconWindow1.Open_Image();
            if (image != null)
            {
                halconWindow1.Disp_Image(image);
                HOperatorSet.CopyImage(image, out AppParam.Instance.product.Cam1_Image2);
                image.Dispose();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Line line = halconWindow1.Draw_Line("blue");
            if (comboBox2.Text == "Top")
            {
                AppParam.Instance.product.Cam1_Top2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Top2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox2.Text == "Button")
            {
                AppParam.Instance.product.Cam1_Button2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Button2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox2.Text == "Left")
            {
                AppParam.Instance.product.Cam1_Left2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Left2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox2.Text == "Right")
            {
                AppParam.Instance.product.Cam1_Right2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam1_Right2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image2);
            HObject InvertImage;
            HOperatorSet.GenEmptyObj(out InvertImage);
            HOperatorSet.CopyImage(AppParam.Instance.product.Cam1_Image2, out InvertImage);
            if (comboBox2.Text == "Top")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Top2, InvertImage, out _, out _);
            }
            else if (comboBox2.Text == "Button")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Button2, InvertImage, out _, out _);
            }
            else if (comboBox2.Text == "Left")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Left2, InvertImage, out _, out _);
            }
            else if (comboBox2.Text == "Right")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam1_Right2, InvertImage, out _, out _);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam1_Image2);
            Test(1, 2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Top")
            {
                if (AppParam.Instance.product.Cam1_Top2 == null)
                {
                    AppParam.Instance.product.Cam1_Top2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Top2;
            }
            else if (comboBox2.Text == "Button")
            {
                if (AppParam.Instance.product.Cam1_Button2 == null)
                {
                    AppParam.Instance.product.Cam1_Button2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Button2;
            }
            else if (comboBox2.Text == "Left")
            {
                if (AppParam.Instance.product.Cam1_Left2 == null)
                {
                    AppParam.Instance.product.Cam1_Left2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Left2;
            }
            else if (comboBox2.Text == "Right")
            {
                if (AppParam.Instance.product.Cam1_Right2 == null)
                {
                    AppParam.Instance.product.Cam1_Right2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid1.SelectedObject = AppParam.Instance.product.Cam1_Right2;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Top")
            {
                if (AppParam.Instance.product.Cam2_Top1 == null)
                {
                    AppParam.Instance.product.Cam2_Top1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Top1;
            }
            else if (comboBox4.Text == "Button")
            {
                if (AppParam.Instance.product.Cam2_Button1 == null)
                {
                    AppParam.Instance.product.Cam2_Button1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Button1;
            }
            else if (comboBox4.Text == "Left")
            {
                if (AppParam.Instance.product.Cam2_Left1 == null)
                {
                    AppParam.Instance.product.Cam2_Left1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Left1;
            }
            else if (comboBox4.Text == "Right")
            {
                if (AppParam.Instance.product.Cam2_Right1 == null)
                {
                    AppParam.Instance.product.Cam2_Right1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Right1;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Top")
            {
                if (AppParam.Instance.product.Cam2_Top2 == null)
                {
                    AppParam.Instance.product.Cam2_Top2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Top2;
            }
            else if (comboBox3.Text == "Button")
            {
                if (AppParam.Instance.product.Cam2_Button2 == null)
                {
                    AppParam.Instance.product.Cam2_Button2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Button2;
            }
            else if (comboBox3.Text == "Left")
            {
                if (AppParam.Instance.product.Cam2_Left2 == null)
                {
                    AppParam.Instance.product.Cam2_Left2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Left2;
            }
            else if (comboBox3.Text == "Right")
            {
                if (AppParam.Instance.product.Cam2_Right2 == null)
                {
                    AppParam.Instance.product.Cam2_Right2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid2.SelectedObject = AppParam.Instance.product.Cam2_Right2;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            HObject image = halconWindow1.Open_Image();
            if (image != null)
            {
                halconWindow1.Disp_Image(image);
                HOperatorSet.CopyImage(image, out AppParam.Instance.product.Cam2_Image2);
                image.Dispose();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            HObject image = halconWindow1.Open_Image();
            if (image != null)
            {
                halconWindow1.Disp_Image(image);
                HOperatorSet.CopyImage(image, out AppParam.Instance.product.Cam2_Image1);
                image.Dispose();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image2);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Line line = halconWindow1.Draw_Line("blue");
            if (comboBox4.Text == "Top")
            {
                AppParam.Instance.product.Cam2_Top1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Top1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox4.Text == "Button")
            {
                AppParam.Instance.product.Cam2_Button1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Button1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox4.Text == "Left")
            {
                AppParam.Instance.product.Cam2_Left1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Left1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox4.Text == "Right")
            {
                AppParam.Instance.product.Cam2_Right1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Right1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Line line = halconWindow1.Draw_Line("blue");
            if (comboBox3.Text == "Top")
            {
                AppParam.Instance.product.Cam2_Top2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Top2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox3.Text == "Button")
            {
                AppParam.Instance.product.Cam2_Button2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Button2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox3.Text == "Left")
            {
                AppParam.Instance.product.Cam2_Left2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Left2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox3.Text == "Right")
            {
                AppParam.Instance.product.Cam2_Right2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam2_Right2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image1);
            HObject InvertImage;
            HOperatorSet.GenEmptyObj(out InvertImage);
            HOperatorSet.CopyImage(AppParam.Instance.product.Cam2_Image1, out InvertImage);
            if (comboBox4.Text == "Top")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top1, InvertImage, out _, out _);
            }
            else if (comboBox4.Text == "Button")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Button1, InvertImage, out _, out _);
            }
            else if (comboBox4.Text == "Left")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left1, InvertImage, out _, out _);
            }
            else if (comboBox4.Text == "Right")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Right1, InvertImage, out _, out _);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image2);
            HObject InvertImage;
            HOperatorSet.GenEmptyObj(out InvertImage);
            HOperatorSet.CopyImage(AppParam.Instance.product.Cam2_Image2, out InvertImage);
            if (comboBox3.Text == "Top")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Top2, InvertImage, out _, out _);
            }
            else if (comboBox3.Text == "Button")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Button2, InvertImage, out _, out _);
            }
            else if (comboBox3.Text == "Left")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Left2, InvertImage, out _, out _);
            }
            else if (comboBox3.Text == "Right")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam2_Right2, InvertImage, out _, out _);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image1);
            Test(2, 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam2_Image2);
            Test(2, 2);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "Top")
            {
                if (AppParam.Instance.product.Cam3_Top1 == null)
                {
                    AppParam.Instance.product.Cam3_Top1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Top1;
            }
            else if (comboBox6.Text == "Button")
            {
                if (AppParam.Instance.product.Cam3_Button1 == null)
                {
                    AppParam.Instance.product.Cam3_Button1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Button1;
            }
            else if (comboBox6.Text == "Left")
            {
                if (AppParam.Instance.product.Cam3_Left1 == null)
                {
                    AppParam.Instance.product.Cam3_Left1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Left1;
            }
            else if (comboBox6.Text == "Right")
            {
                if (AppParam.Instance.product.Cam3_Right1 == null)
                {
                    AppParam.Instance.product.Cam3_Right1 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Right1;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Top")
            {
                if (AppParam.Instance.product.Cam3_Top2 == null)
                {
                    AppParam.Instance.product.Cam3_Top2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Top2;
            }
            else if (comboBox5.Text == "Button")
            {
                if (AppParam.Instance.product.Cam3_Button2 == null)
                {
                    AppParam.Instance.product.Cam3_Button2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Button2;
            }
            else if (comboBox5.Text == "Left")
            {
                if (AppParam.Instance.product.Cam3_Left2 == null)
                {
                    AppParam.Instance.product.Cam3_Left2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Left2;
            }
            else if (comboBox5.Text == "Right")
            {
                if (AppParam.Instance.product.Cam3_Right2 == null)
                {
                    AppParam.Instance.product.Cam3_Right2 = new ToolKit.HalconTool.Model.MeasureParam();
                }
                propertyGrid3.SelectedObject = AppParam.Instance.product.Cam3_Right2;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            HObject image = halconWindow1.Open_Image();
            if (image != null)
            {
                halconWindow1.Disp_Image(image);
                HOperatorSet.CopyImage(image, out AppParam.Instance.product.Cam3_Image1);
                image.Dispose();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            HObject image = halconWindow1.Open_Image();
            if (image != null)
            {
                halconWindow1.Disp_Image(image);
                HOperatorSet.CopyImage(image, out AppParam.Instance.product.Cam3_Image2);
                image.Dispose();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image1);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image2);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Line line = halconWindow1.Draw_Line("blue");
            if (comboBox6.Text == "Top")
            {
                AppParam.Instance.product.Cam3_Top1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Top1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox6.Text == "Button")
            {
                AppParam.Instance.product.Cam3_Button1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Button1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox6.Text == "Left")
            {
                AppParam.Instance.product.Cam3_Left1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Left1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox6.Text == "Right")
            {
                AppParam.Instance.product.Cam3_Right1.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Right1.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Line line = halconWindow1.Draw_Line("blue");
            if (comboBox5.Text == "Top")
            {
                AppParam.Instance.product.Cam3_Top2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Top2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox5.Text == "Button")
            {
                AppParam.Instance.product.Cam3_Button2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Button2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox5.Text == "Left")
            {
                AppParam.Instance.product.Cam3_Left2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Left2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
            else if (comboBox5.Text == "Right")
            {
                AppParam.Instance.product.Cam3_Right2.Shape = ToolKit.HalconTool.Model.MeasureShapes.line;
                AppParam.Instance.product.Cam3_Right2.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image1);
            HObject InvertImage;
            HOperatorSet.GenEmptyObj(out InvertImage);
            HOperatorSet.CopyImage(AppParam.Instance.product.Cam3_Image1, out InvertImage);
            if (comboBox6.Text == "Top")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top1, InvertImage, out _, out _);
            }
            else if (comboBox6.Text == "Button")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Button1, InvertImage, out _, out _);
            }
            else if (comboBox6.Text == "Left")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left1, InvertImage, out _, out _);
            }
            else if (comboBox6.Text == "Right")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Right1, InvertImage, out _, out _);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image2);
            HObject InvertImage;
            HOperatorSet.GenEmptyObj(out InvertImage);
            HOperatorSet.CopyImage(AppParam.Instance.product.Cam3_Image2, out InvertImage);
            if (comboBox5.Text == "Top")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Top2, InvertImage, out _, out _);
            }
            else if (comboBox5.Text == "Button")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Button2, InvertImage, out _, out _);
            }
            else if (comboBox5.Text == "Left")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Left2, InvertImage, out _, out _);
            }
            else if (comboBox5.Text == "Right")
            {
                HalconUtils.CaliperMeasure(halconWindow1, AppParam.Instance.product.Cam3_Right2, InvertImage, out _, out _);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image1);
            Test(3, 1);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Image(AppParam.Instance.product.Cam3_Image2);
            Test(3, 2);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            AppParam.Instance.Save_To_File();
            ShowNormal("保存成功");
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppParam.Instance.lightSource.OpenAllCH();

            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                Cameras.Instance[item].ClearImageProcessEvents();
                Cameras.Instance[item].ImageProcessEvent += this.Form_Camera_ImageProcessEvent;
            }
        }

        private void Form_Camera_ImageProcessEvent(string cameraName, HObject ho_image)
        {
            halconWindow1.Disp_Image(ho_image);
            if (ShowWarn("确认替换基准图?") == DialogResult.OK)
            {
                switch (index)
                {
                    case 11:

                        HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam1_Image1);

                        break;

                    case 12:
                        HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam1_Image2);
                        break;

                    case 21:
                        HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam2_Image1);
                        break;

                    case 22:
                        HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam2_Image2);
                        break;

                    case 31:
                        HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam3_Image1);
                        break;

                    case 32:
                        HOperatorSet.CopyImage(ho_image, out AppParam.Instance.product.Cam3_Image2);
                        break;
                }
            }
            index = 0;
            ho_image.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppParam.Instance.lightSource.CloseAllCH();

            foreach (var item in Cameras.Instance.GetCameras.Keys)
            {
                //关闭实时
                System.Threading.Thread.Sleep(300);
                //清空事件
                Cameras.Instance[item].ClearImageProcessEvents();
                //重新绑定运行事件
                Cameras.Instance[item].ImageProcessEvent += Cameras.Instance.Camera_ImageProcessEvent;
            }
        }

        private int index = 0;

        private void button36_Click(object sender, EventArgs e)
        {
            index = 31;
            Cameras.Instance["Cam3"].Soft_Trigger();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            index = 32;
            Cameras.Instance["Cam3"].Soft_Trigger();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            index = 21;
            Cameras.Instance["Cam2"].Soft_Trigger();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            index = 22;
            Cameras.Instance["Cam2"].Soft_Trigger();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            HObject ho_ImageReduced, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            HTuple hv_UsedThreshold = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), Length1 = new HTuple();
            HTuple Length2 = new HTuple(), hv_WindowHandle = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(AppParam.Instance.product.Cam3_Image1, rectangle.rectangle1, out ho_ImageReduced);
            ho_Region.Dispose(); hv_UsedThreshold.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability", "dark", out hv_UsedThreshold);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningRectangle1(ho_Region, out ho_RegionOpening, 50, 50);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 70);
            hv_Row1.Dispose(); hv_Column1.Dispose(); Length1.Dispose(); Length2.Dispose();

            HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out hv_Row1, out hv_Column1, out _, out Length1, out Length2);

            halconWindow1.Disp_Cross(hv_Row1 + Length2, hv_Column1 - Length1, 300, 0, "blue");
            AppParam.Instance.product.Cam3_Image1_Standard_Row = hv_Row1 + Length2;
            AppParam.Instance.product.Cam3_Image1_Standard_Column = hv_Column1 - Length1;
            AppParam.Instance.product.Cam3_Image1_Standard_Rectangle1 = rectangle.rectangle1;

            ho_ImageReduced.Dispose();
            ho_Region.Dispose();
            ho_RegionOpening.Dispose();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Region(AppParam.Instance.product.Cam3_Image1_Standard_Rectangle1, "blue", "margin");
            halconWindow1.Disp_Cross(AppParam.Instance.product.Cam3_Image1_Standard_Row, AppParam.Instance.product.Cam3_Image1_Standard_Column, 300, 0, "blue");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            HObject ho_ImageReduced, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            HTuple hv_UsedThreshold = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), Length1 = new HTuple();
            HTuple Length2 = new HTuple(), hv_WindowHandle = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(AppParam.Instance.product.Cam3_Image2, rectangle.rectangle1, out ho_ImageReduced);
            ho_Region.Dispose(); hv_UsedThreshold.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability", "dark", out hv_UsedThreshold);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningRectangle1(ho_Region, out ho_RegionOpening, 50, 50);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 70);
            hv_Row1.Dispose(); hv_Column1.Dispose(); Length1.Dispose(); Length2.Dispose();

            HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out hv_Row1, out hv_Column1, out _, out Length1, out Length2);

            halconWindow1.Disp_Cross(hv_Row1 + Length2, hv_Column1 + Length1, 300, 0, "blue");
            AppParam.Instance.product.Cam3_Image2_Standard_Row = hv_Row1 + Length2;
            AppParam.Instance.product.Cam3_Image2_Standard_Column = hv_Column1 + Length1;
            AppParam.Instance.product.Cam3_Image2_Standard_Rectangle1 = rectangle.rectangle1;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            HObject ho_ImageReduced, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            HTuple hv_UsedThreshold = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), Length1 = new HTuple();
            HTuple Length2 = new HTuple(), hv_WindowHandle = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(AppParam.Instance.product.Cam2_Image1, rectangle.rectangle1, out ho_ImageReduced);
            ho_Region.Dispose(); hv_UsedThreshold.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability", "dark", out hv_UsedThreshold);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningRectangle1(ho_Region, out ho_RegionOpening, 50, 50);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 70);
            hv_Row1.Dispose(); hv_Column1.Dispose(); Length1.Dispose(); Length2.Dispose();

            HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out hv_Row1, out hv_Column1, out _, out Length1, out Length2);

            halconWindow1.Disp_Cross(hv_Row1 + Length2, hv_Column1 - Length1, 300, 0, "blue");

            AppParam.Instance.product.Cam2_Image1_Standard_Row = hv_Row1 + Length2;
            AppParam.Instance.product.Cam2_Image1_Standard_Column = hv_Column1 - Length1;
            AppParam.Instance.product.Cam2_Image1_Standard_Rectangle1 = rectangle.rectangle1;

            ho_ImageReduced.Dispose();
            ho_Region.Dispose();
            ho_RegionOpening.Dispose();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Region(AppParam.Instance.product.Cam2_Image1_Standard_Rectangle1, "blue", "margin");
            halconWindow1.Disp_Cross(AppParam.Instance.product.Cam2_Image1_Standard_Row, AppParam.Instance.product.Cam2_Image1_Standard_Column, 300, 0, "blue");
        }

        private void button39_Click(object sender, EventArgs e)
        {
            HObject ho_ImageReduced, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            HTuple hv_UsedThreshold = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), Length1 = new HTuple();
            HTuple Length2 = new HTuple(), hv_WindowHandle = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(AppParam.Instance.product.Cam1_Image1, rectangle.rectangle1, out ho_ImageReduced);
            ho_Region.Dispose(); hv_UsedThreshold.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability", "dark", out hv_UsedThreshold);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningRectangle1(ho_Region, out ho_RegionOpening, 50, 50);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 70);
            hv_Row1.Dispose(); hv_Column1.Dispose(); Length1.Dispose(); Length2.Dispose();

            HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out hv_Row1, out hv_Column1, out _, out Length1, out Length2);

            halconWindow1.Disp_Cross(hv_Row1 + Length2, hv_Column1 - Length1, 300, 0, "blue");
            AppParam.Instance.product.Cam1_Image1_Standard_Row = hv_Row1 + Length2;
            AppParam.Instance.product.Cam1_Image1_Standard_Column = hv_Column1 - Length1;
            AppParam.Instance.product.Cam1_Image1_Standard_Rectangle1 = rectangle.rectangle1;

            ho_ImageReduced.Dispose();
            ho_Region.Dispose();
            ho_RegionOpening.Dispose();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Region(AppParam.Instance.product.Cam1_Image1_Standard_Rectangle1, "blue", "margin");
            halconWindow1.Disp_Cross(AppParam.Instance.product.Cam1_Image1_Standard_Row, AppParam.Instance.product.Cam1_Image1_Standard_Column, 300, 0, "blue");
        }

        private void button42_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Region(AppParam.Instance.product.Cam3_Image2_Standard_Rectangle1, "blue", "margin");
            halconWindow1.Disp_Cross(AppParam.Instance.product.Cam3_Image2_Standard_Row, AppParam.Instance.product.Cam3_Image2_Standard_Column, 300, 0, "blue");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            HObject ho_ImageReduced, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            HTuple hv_UsedThreshold = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), Length1 = new HTuple();
            HTuple Length2 = new HTuple(), hv_WindowHandle = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(AppParam.Instance.product.Cam2_Image2, rectangle.rectangle1, out ho_ImageReduced);
            ho_Region.Dispose(); hv_UsedThreshold.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability", "dark", out hv_UsedThreshold);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningRectangle1(ho_Region, out ho_RegionOpening, 50, 50);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 70);
            hv_Row1.Dispose(); hv_Column1.Dispose(); Length1.Dispose(); Length2.Dispose();

            HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out hv_Row1, out hv_Column1, out _, out Length1, out Length2);

            halconWindow1.Disp_Cross(hv_Row1 + Length2, hv_Column1 + Length1, 300, 0, "blue");
            AppParam.Instance.product.Cam2_Image2_Standard_Row = hv_Row1 + Length2;
            AppParam.Instance.product.Cam2_Image2_Standard_Column = hv_Column1 + Length1;
            AppParam.Instance.product.Cam2_Image2_Standard_Rectangle1 = rectangle.rectangle1;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Region(AppParam.Instance.product.Cam2_Image2_Standard_Rectangle1, "blue", "margin");
            halconWindow1.Disp_Cross(AppParam.Instance.product.Cam2_Image2_Standard_Row, AppParam.Instance.product.Cam2_Image2_Standard_Column, 300, 0, "blue");
        }

        private void button50_Click(object sender, EventArgs e)
        {
            HObject ho_ImageReduced, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            HTuple hv_UsedThreshold = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), Length1 = new HTuple();
            HTuple Length2 = new HTuple(), hv_WindowHandle = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            Rectangle1 rectangle = halconWindow1.Draw_Rectangle1("blue");
            HOperatorSet.ReduceDomain(AppParam.Instance.product.Cam1_Image2, rectangle.rectangle1, out ho_ImageReduced);
            ho_Region.Dispose(); hv_UsedThreshold.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability", "dark", out hv_UsedThreshold);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningRectangle1(ho_Region, out ho_RegionOpening, 50, 50);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 70);
            hv_Row1.Dispose(); hv_Column1.Dispose(); Length1.Dispose(); Length2.Dispose();

            HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out hv_Row1, out hv_Column1, out _, out Length1, out Length2);

            halconWindow1.Disp_Cross(hv_Row1 + Length2, hv_Column1 + Length1, 300, 0, "blue");
            AppParam.Instance.product.Cam1_Image2_Standard_Row = hv_Row1 + Length2;
            AppParam.Instance.product.Cam1_Image2_Standard_Column = hv_Column1 + Length1;
            AppParam.Instance.product.Cam1_Image2_Standard_Rectangle1 = rectangle.rectangle1;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            halconWindow1.Disp_Region(AppParam.Instance.product.Cam1_Image2_Standard_Rectangle1, "blue", "margin");
            halconWindow1.Disp_Cross(AppParam.Instance.product.Cam2_Image2_Standard_Row, AppParam.Instance.product.Cam2_Image2_Standard_Column, 300, 0, "blue");
        }
    }
}