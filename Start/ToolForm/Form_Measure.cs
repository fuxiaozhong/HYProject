using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HalconDotNet;

using ToolKit.DisplayWindow;
using ToolKit.HalconTool;
using ToolKit.HalconTool.Model;

namespace HYProject.ToolForm
{
    public partial class Form_Measure : Form
    {
        public MeasureParam measure;
        public Form_Measure()
        {
            InitializeComponent();
        }

        private void Form_Measure_Load(object sender, EventArgs e)
        {
            measure = new MeasureParam();
            propertyGrid1.SelectedObject = measure;
        }
        HObject image;
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
                    measure.Shape = MeasureShapes.circle;
                    measure.InputShapeParam = new HTuple(circle.row, circle.column, circle.radius);
                    break;
                case "长方形":
                    Rectangle2 rectangle = halconDisplayWindow1.Draw_Rectangle2("blue");
                    measure.Shape = MeasureShapes.rectangle2;
                    measure.InputShapeParam = new HTuple(rectangle.row, rectangle.column, rectangle.phi, rectangle.lenght1, rectangle.lenght2);
                    break;
                case "椭圆":
                    Ellipse ellipse = halconDisplayWindow1.Draw_Ellipse("blue");
                    measure.Shape = MeasureShapes.ellipse;
                    measure.InputShapeParam = new HTuple(ellipse.row, ellipse.column, ellipse.phi, ellipse.radius1, ellipse.radius2);
                    break;
                case "直线":
                    Line line = halconDisplayWindow1.Draw_Line("blue");
                    measure.Shape = MeasureShapes.line;
                    measure.InputShapeParam = new HTuple(line.start_row, line.start_column, line.end_row, line.end_column);
                    break;
            }



        }

        private void Button3_Click(object sender, EventArgs e)
        {
            HalconUtils.CaliperMeasure(halconDisplayWindow1, measure, image, out _, out _);
        }
    }
}
