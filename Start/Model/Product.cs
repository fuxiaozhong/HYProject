using HalconDotNet;
using System;
using System.Drawing;
using ToolKit.HalconTool.Model;

namespace HYProject.Model
{
    [Serializable]
    public class Product
    {
        public Image ProductImage;
        public DateTime CreateTime;
        public string ProductName;

        public HObject Cam1_Image1;
        public HObject Cam1_Image2;

        public HObject Cam2_Image1;
        public HObject Cam2_Image2;

        public HObject Cam3_Image1;
        public HObject Cam3_Image2;

        public MeasureParam Cam1_Top1 = new MeasureParam();
        public MeasureParam Cam1_Button1 = new MeasureParam();
        public MeasureParam Cam1_Left1 = new MeasureParam();
        public MeasureParam Cam1_Right1 = new MeasureParam();
        public MeasureParam Cam1_Top2 = new MeasureParam();
        public MeasureParam Cam1_Button2 = new MeasureParam();
        public MeasureParam Cam1_Left2 = new MeasureParam();
        public MeasureParam Cam1_Right2 = new MeasureParam();

        public MeasureParam Cam2_Top1 = new MeasureParam();
        public MeasureParam Cam2_Button1 = new MeasureParam();
        public MeasureParam Cam2_Left1 = new MeasureParam();
        public MeasureParam Cam2_Right1 = new MeasureParam();
        public MeasureParam Cam2_Top2 = new MeasureParam();
        public MeasureParam Cam2_Button2 = new MeasureParam();
        public MeasureParam Cam2_Left2 = new MeasureParam();
        public MeasureParam Cam2_Right2 = new MeasureParam();

        public MeasureParam Cam3_Top1 = new MeasureParam();
        public MeasureParam Cam3_Button1 = new MeasureParam();
        public MeasureParam Cam3_Left1 = new MeasureParam();
        public MeasureParam Cam3_Right1 = new MeasureParam();
        public MeasureParam Cam3_Top2 = new MeasureParam();
        public MeasureParam Cam3_Button2 = new MeasureParam();
        public MeasureParam Cam3_Left2 = new MeasureParam();
        public MeasureParam Cam3_Right2 = new MeasureParam();
        internal HTuple Cam3_Image2_Standard_Row;
        internal HTuple Cam3_Image2_Standard_Column;
        internal HTuple Cam2_Image1_Standard_Row;
        internal HTuple Cam2_Image1_Standard_Column;
        internal HTuple Cam3_Image1_Standard_Row;
        internal HTuple Cam3_Image1_Standard_Column;
        internal HTuple Cam1_Image1_Standard_Row;
        internal HTuple Cam1_Image1_Standard_Column;
        internal HTuple Cam2_Image2_Standard_Row;
        internal HTuple Cam2_Image2_Standard_Column;
        internal HObject Cam3_Image1_Standard_Rectangle1;
        internal HObject Cam3_Image2_Standard_Rectangle1;
        internal HObject Cam2_Image1_Standard_Rectangle1;
        internal HObject Cam2_Image2_Standard_Rectangle1;
        internal HObject Cam1_Image1_Standard_Rectangle1;
        internal HTuple Cam1_Image2_Standard_Row;
        internal HTuple Cam1_Image2_Standard_Column;
        internal HObject Cam1_Image2_Standard_Rectangle1;
    }
}