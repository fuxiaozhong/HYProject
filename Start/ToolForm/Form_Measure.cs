using System;

using HalconDotNet;

using ToolKit.DisplayWindow;
using ToolKit.HalconTool;
using ToolKit.HalconTool.Model;
using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_Measure : BaseForm

    {
        public Form_Measure()
        {
            InitializeComponent();
        }

        private void Form_Measure_Load(object sender, EventArgs e)
        {
            if (AppParam.Instance.Measure == null)
            {
                AppParam.Instance.Measure = new MeasureParam();
            }
            comboBox1.Text = AppParam.Instance.Measure.Shape.ToString();
            propertyGrid1.SelectedObject = AppParam.Instance.Measure;
        }

        private HObject image;

        private void Button1_Click(object sender, EventArgs e)
        {
            image = halconDisplayWindow1.Open_Image();
            if (image != null)
            {
                halconDisplayWindow1.Disp_Image(image);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "圆":
                    Circle circle = halconDisplayWindow1.Draw_Circle("blue");
                    AppParam.Instance.Measure.Shape = MeasureShapes.circle;
                    AppParam.Instance.Measure.InputShapeParam = new HTuple(circle.row, circle.column, circle.radius);
                    break;

                case "长方形":
                    Rectangle2 rectangle = halconDisplayWindow1.Draw_Rectangle2("blue");
                    AppParam.Instance.Measure.Shape = MeasureShapes.rectangle2;
                    AppParam.Instance.Measure.InputShapeParam = new HTuple(rectangle.row, rectangle.column, rectangle.phi, rectangle.lenght1, rectangle.lenght2);
                    break;

                case "椭圆":
                    Ellipse ellipse = halconDisplayWindow1.Draw_Ellipse("blue");
                    AppParam.Instance.Measure.Shape = MeasureShapes.ellipse;
                    AppParam.Instance.Measure.InputShapeParam = new HTuple(ellipse.row, ellipse.column, ellipse.phi, ellipse.radius1, ellipse.radius2);
                    break;

                case "直线":
                    Line line = halconDisplayWindow1.Draw_Line("blue");
                    AppParam.Instance.Measure.Shape = MeasureShapes.line;
                    AppParam.Instance.Measure.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                    break;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            HalconUtils.CaliperMeasure(halconDisplayWindow1, AppParam.Instance.Measure, image, out _, out _);
        }
    }
}