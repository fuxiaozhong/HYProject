using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Model;

using NPOI.SS.Formula.Functions;

namespace HYProject.Plugin
{
    public partial class Form_Robot_Calibration : ToolKit.HYControls.HYForm.HYBaseForm
    {
        private static Form_Robot_Calibration instance;

        public static Form_Robot_Calibration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form_Robot_Calibration();
                }
                return instance;
            }
        }
        private Form_Robot_Calibration()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 标定相机添加数据
        /// </summary>
        /// <param name="CamStep">工位号</param>
        /// <param name="Column">Column</param>
        /// <param name="Row">Row</param>
        /// <param name="RobotX">X</param>
        /// <param name="RobotY">Y</param>
        public void AddData(int CamStep, double Column, double Row, double RobotX, double RobotY)
        {
            if (CamStep == 1)
            {
                int index = Cam1_Data.Rows.Add();
                Cam1_Data.Rows[index].Cells[0].Value = index;
                Cam1_Data.Rows[index].Cells[1].Value = RobotX;
                Cam1_Data.Rows[index].Cells[2].Value = RobotY;
                Cam1_Data.Rows[index].Cells[3].Value = Column;
                Cam1_Data.Rows[index].Cells[4].Value = Row;

            }
            else if (CamStep == 2)
            {
                int index = Cam2_Data.Rows.Add();
                Cam2_Data.Rows[index].Cells[0].Value = index;
                Cam2_Data.Rows[index].Cells[1].Value = RobotX;
                Cam2_Data.Rows[index].Cells[2].Value = RobotY;
                Cam2_Data.Rows[index].Cells[3].Value = Column;
                Cam2_Data.Rows[index].Cells[4].Value = Row;

            }
            else if (CamStep == 3)
            {
                int index = Cam3_Data.Rows.Add();
                Cam3_Data.Rows[index].Cells[0].Value = index;
                Cam3_Data.Rows[index].Cells[1].Value = RobotX;
                Cam3_Data.Rows[index].Cells[2].Value = RobotY;
                Cam3_Data.Rows[index].Cells[3].Value = Column;
                Cam3_Data.Rows[index].Cells[4].Value = Row;
            }

        }

        private void VectorToHomMat2d_Cam(int CamStep)
        {
            if (CamStep == 1)
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(Cam1_Data.Rows[i].Cells[1].Value.ToString());
                    Y[i] = Convert.ToDouble(Cam1_Data.Rows[i].Cells[2].Value.ToString());
                    Column[i] = Convert.ToDouble(Cam1_Data.Rows[i].Cells[3].Value.ToString());
                    Row[i] = Convert.ToDouble(Cam1_Data.Rows[i].Cells[4].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Column, Row, X, Y, out AppParam.Instance.CalibrationData.Cam1_HomMat2d);
                label1.Text = AppParam.Instance.CalibrationData.Cam1_HomMat2d[0].D.ToString() + AppParam.Instance.CalibrationData.Cam1_HomMat2d[1].D.ToString() + "\n" +
                    AppParam.Instance.CalibrationData.Cam1_HomMat2d[2].D.ToString() + AppParam.Instance.CalibrationData.Cam1_HomMat2d[3].D.ToString() + "\n" +
                    AppParam.Instance.CalibrationData.Cam1_HomMat2d[4].D.ToString() + AppParam.Instance.CalibrationData.Cam1_HomMat2d[5].D.ToString();
                AppParam.Instance.Save_To_File();
                Log.WriteRunLog(CamStep + "标定成功");
            }
            else if (CamStep == 2)
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(Cam2_Data.Rows[i].Cells[1].Value.ToString());
                    Y[i] = Convert.ToDouble(Cam2_Data.Rows[i].Cells[2].Value.ToString());
                    Column[i] = Convert.ToDouble(Cam2_Data.Rows[i].Cells[3].Value.ToString());
                    Row[i] = Convert.ToDouble(Cam2_Data.Rows[i].Cells[4].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Column, Row, X, Y, out AppParam.Instance.CalibrationData.Cam2_HomMat2d);
                label2.Text = AppParam.Instance.CalibrationData.Cam2_HomMat2d[0].D.ToString() + AppParam.Instance.CalibrationData.Cam2_HomMat2d[1].D.ToString() + "\n" +
                    AppParam.Instance.CalibrationData.Cam2_HomMat2d[2].D.ToString() + AppParam.Instance.CalibrationData.Cam2_HomMat2d[3].D.ToString() + "\n" +
                    AppParam.Instance.CalibrationData.Cam2_HomMat2d[4].D.ToString() + AppParam.Instance.CalibrationData.Cam2_HomMat2d[5].D.ToString();
                AppParam.Instance.Save_To_File();
                Log.WriteRunLog(CamStep + "标定成功");
            }
            else if (CamStep == 3)
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(Cam3_Data.Rows[i].Cells[1].Value.ToString());
                    Y[i] = Convert.ToDouble(Cam3_Data.Rows[i].Cells[2].Value.ToString());
                    Column[i] = Convert.ToDouble(Cam3_Data.Rows[i].Cells[3].Value.ToString());
                    Row[i] = Convert.ToDouble(Cam3_Data.Rows[i].Cells[4].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Column, Row, X, Y, out AppParam.Instance.CalibrationData.Cam3_HomMat2d);
                label3.Text = AppParam.Instance.CalibrationData.Cam3_HomMat2d[0].D.ToString() + AppParam.Instance.CalibrationData.Cam3_HomMat2d[1].D.ToString() + "\n" +
                    AppParam.Instance.CalibrationData.Cam3_HomMat2d[2].D.ToString() + AppParam.Instance.CalibrationData.Cam3_HomMat2d[3].D.ToString() + "\n" +
                    AppParam.Instance.CalibrationData.Cam3_HomMat2d[4].D.ToString() + AppParam.Instance.CalibrationData.Cam3_HomMat2d[5].D.ToString();
                AppParam.Instance.Save_To_File();
                Log.WriteRunLog(CamStep + "标定成功");
            }
        }
        public RobotPoint CenterRotation(RobotPoint p1, RobotPoint p2, RobotPoint p3)
        {
            RobotPoint rpoint = new RobotPoint();
            double a = p1.X - p2.X;
            double b = p1.Y - p2.Y;
            double c = p1.X - p3.X;
            double d = p1.Y - p3.Y;
            double e = (Math.Pow(p1.X, 2) - Math.Pow(p2.X, 2) + Math.Pow(p1.Y, 2) - Math.Pow(p2.Y, 2)) / 2.0;
            double f = (Math.Pow(p1.X, 2) - Math.Pow(p3.X, 2) + Math.Pow(p1.Y, 2) - Math.Pow(p3.Y, 2)) / 2.0;
            double det = b * c - a * d;
            if (Math.Abs(det) > 0)
            {
                //x0,y0为计算得到的原点
                double x0 = -(d * e - b * f) / det;
                double y0 = -(a * f - c * e) / det;
                rpoint.X = x0;
                rpoint.Y = y0;
                return rpoint;
            }
            else
            {
                RobotPoint ab = new RobotPoint();
                ab.X = 9999;
                ab.Y = 9999;
                return ab;
            }
        }
        public void Cam1Center_Rotation_Calibration(string Cam, int SuctionNozzleNumber)
        {
            if (Cam == "Cam1")
            {
                if (SuctionNozzleNumber == 1)
                {
                    RobotPoint p1 = new RobotPoint() { X = double.Parse(textBox_Cam1_Point1_X1.Text), Y = double.Parse(textBox_Cam1_Point1_Y1.Text) };
                    RobotPoint p2 = new RobotPoint() { X = double.Parse(textBox_Cam1_Point1_X2.Text), Y = double.Parse(textBox_Cam1_Point1_Y2.Text) };
                    RobotPoint p3 = new RobotPoint() { X = double.Parse(textBox_Cam1_Point1_X3.Text), Y = double.Parse(textBox_Cam1_Point1_Y3.Text) };
                    RobotPoint robotPoint = CenterRotation(p1, p2, p3);
                    textBox_Cam1_Center1_X.Text = robotPoint.X.ToString();
                    textBox_Cam1_Center1_Y.Text = robotPoint.Y.ToString();
                }
                else if (SuctionNozzleNumber == 2)
                {
                    RobotPoint p1 = new RobotPoint() { X = double.Parse(textBox_Cam1_Point2_X1.Text), Y = double.Parse(textBox_Cam1_Point2_Y1.Text) };
                    RobotPoint p2 = new RobotPoint() { X = double.Parse(textBox_Cam1_Point2_X2.Text), Y = double.Parse(textBox_Cam1_Point2_Y2.Text) };
                    RobotPoint p3 = new RobotPoint() { X = double.Parse(textBox_Cam1_Point2_X3.Text), Y = double.Parse(textBox_Cam1_Point2_Y3.Text) };
                    RobotPoint robotPoint = CenterRotation(p1, p2, p3);
                    textBox_Cam1_Center2_X.Text = robotPoint.X.ToString();
                    textBox_Cam1_Center2_Y.Text = robotPoint.Y.ToString();
                }
            }
            else if (Cam == "Cam2")
            {
                if (SuctionNozzleNumber == 1)
                {
                    RobotPoint p1 = new RobotPoint() { X = double.Parse(textBox_Cam2_Point1_X1.Text), Y = double.Parse(textBox_Cam2_Point1_Y1.Text) };
                    RobotPoint p2 = new RobotPoint() { X = double.Parse(textBox_Cam2_Point1_X2.Text), Y = double.Parse(textBox_Cam2_Point1_Y2.Text) };
                    RobotPoint p3 = new RobotPoint() { X = double.Parse(textBox_Cam2_Point1_X3.Text), Y = double.Parse(textBox_Cam2_Point1_Y3.Text) };
                    RobotPoint robotPoint = CenterRotation(p1, p2, p3);
                    textBox_Cam2_Center1_X.Text = robotPoint.X.ToString();
                    textBox_Cam2_Center1_Y.Text = robotPoint.Y.ToString();
                }
                else if (SuctionNozzleNumber == 2)
                {
                    RobotPoint p1 = new RobotPoint() { X = double.Parse(textBox_Cam2_Point2_X1.Text), Y = double.Parse(textBox_Cam2_Point2_Y1.Text) };
                    RobotPoint p2 = new RobotPoint() { X = double.Parse(textBox_Cam2_Point2_X2.Text), Y = double.Parse(textBox_Cam2_Point2_Y2.Text) };
                    RobotPoint p3 = new RobotPoint() { X = double.Parse(textBox_Cam2_Point2_X3.Text), Y = double.Parse(textBox_Cam2_Point2_Y3.Text) };
                    RobotPoint robotPoint = CenterRotation(p1, p2, p3);
                    textBox_Cam2_Center2_X.Text = robotPoint.X.ToString();
                    textBox_Cam2_Center2_Y.Text = robotPoint.Y.ToString();
                }
            }
            else if (Cam == "Cam3")
            {
                if (SuctionNozzleNumber == 1)
                {
                    RobotPoint p1 = new RobotPoint() { X = double.Parse(textBox_Cam3_Point1_X1.Text), Y = double.Parse(textBox_Cam3_Point1_Y1.Text) };
                    RobotPoint p2 = new RobotPoint() { X = double.Parse(textBox_Cam3_Point1_X2.Text), Y = double.Parse(textBox_Cam3_Point1_Y2.Text) };
                    RobotPoint p3 = new RobotPoint() { X = double.Parse(textBox_Cam3_Point1_X3.Text), Y = double.Parse(textBox_Cam3_Point1_Y3.Text) };
                    RobotPoint robotPoint = CenterRotation(p1, p2, p3);
                    textBox_Cam3_Center1_X.Text = robotPoint.X.ToString();
                    textBox_Cam3_Center1_Y.Text = robotPoint.Y.ToString();
                }
                else if (SuctionNozzleNumber == 2)
                {
                    RobotPoint p1 = new RobotPoint() { X = double.Parse(textBox_Cam3_Point2_X1.Text), Y = double.Parse(textBox_Cam3_Point2_Y1.Text) };
                    RobotPoint p2 = new RobotPoint() { X = double.Parse(textBox_Cam3_Point2_X2.Text), Y = double.Parse(textBox_Cam3_Point2_Y2.Text) };
                    RobotPoint p3 = new RobotPoint() { X = double.Parse(textBox_Cam3_Point2_X3.Text), Y = double.Parse(textBox_Cam3_Point2_Y3.Text) };
                    RobotPoint robotPoint = CenterRotation(p1, p2, p3);
                    textBox_Cam3_Center2_X.Text = robotPoint.X.ToString();
                    textBox_Cam3_Center2_Y.Text = robotPoint.Y.ToString();
                }
            }
        }


        private void Form_Robot_Calibration_Load(object sender, EventArgs e)
        {
            textBox_Cam1_Point1_X1.Text = AppParam.Instance.CalibrationData.Cam1_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam1_Point1_Y1.Text = AppParam.Instance.CalibrationData.Cam1_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam1_Point1_X2.Text = AppParam.Instance.CalibrationData.Cam1_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam1_Point1_Y2.Text = AppParam.Instance.CalibrationData.Cam1_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam1_Point1_X3.Text = AppParam.Instance.CalibrationData.Cam1_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam1_Point1_Y3.Text = AppParam.Instance.CalibrationData.Cam1_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam1_Point2_X1.Text = AppParam.Instance.CalibrationData.Cam1_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam1_Point2_Y1.Text = AppParam.Instance.CalibrationData.Cam1_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam1_Point2_X2.Text = AppParam.Instance.CalibrationData.Cam1_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam1_Point2_Y2.Text = AppParam.Instance.CalibrationData.Cam1_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam1_Point2_X3.Text = AppParam.Instance.CalibrationData.Cam1_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam1_Point2_Y3.Text = AppParam.Instance.CalibrationData.Cam1_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam1_Center1_X.Text = AppParam.Instance.CalibrationData.Cam1_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam1_Center1_Y.Text = AppParam.Instance.CalibrationData.Cam1_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam1_Center2_X.Text = AppParam.Instance.CalibrationData.Cam1_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam1_Center2_Y.Text = AppParam.Instance.CalibrationData.Cam1_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point1_X.Text = AppParam.Instance.CalibrationData.Cam1_Standard1_Point.X.ToString("0.00000");
            text_Cam1_Standard_Point1_Y.Text = AppParam.Instance.CalibrationData.Cam1_Standard1_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point1_U.Text = AppParam.Instance.CalibrationData.Cam1_Standard1_Point.U.ToString("0.00000");
            text_Cam1_Standard_Point2_X.Text = AppParam.Instance.CalibrationData.Cam1_Standard2_Point.X.ToString("0.00000");
            text_Cam1_Standard_Point2_Y.Text = AppParam.Instance.CalibrationData.Cam1_Standard2_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point2_U.Text = AppParam.Instance.CalibrationData.Cam1_Standard2_Point.U.ToString("0.00000");

            textBox_Cam2_Point1_X1.Text = AppParam.Instance.CalibrationData.Cam2_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam2_Point1_Y1.Text = AppParam.Instance.CalibrationData.Cam2_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam2_Point1_X2.Text = AppParam.Instance.CalibrationData.Cam2_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam2_Point1_Y2.Text = AppParam.Instance.CalibrationData.Cam2_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam2_Point1_X3.Text = AppParam.Instance.CalibrationData.Cam2_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam2_Point1_Y3.Text = AppParam.Instance.CalibrationData.Cam2_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam2_Point2_X1.Text = AppParam.Instance.CalibrationData.Cam2_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam2_Point2_Y1.Text = AppParam.Instance.CalibrationData.Cam2_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam2_Point2_X2.Text = AppParam.Instance.CalibrationData.Cam2_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam2_Point2_Y2.Text = AppParam.Instance.CalibrationData.Cam2_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam2_Point2_X3.Text = AppParam.Instance.CalibrationData.Cam2_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam2_Point2_Y3.Text = AppParam.Instance.CalibrationData.Cam2_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam2_Center1_X.Text = AppParam.Instance.CalibrationData.Cam2_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam2_Center1_Y.Text = AppParam.Instance.CalibrationData.Cam2_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam2_Center2_X.Text = AppParam.Instance.CalibrationData.Cam2_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam2_Center2_Y.Text = AppParam.Instance.CalibrationData.Cam2_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point1_X.Text = AppParam.Instance.CalibrationData.Cam2_Standard1_Point.X.ToString("0.00000");
            text_Cam2_Standard_Point1_Y.Text = AppParam.Instance.CalibrationData.Cam2_Standard1_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point1_U.Text = AppParam.Instance.CalibrationData.Cam2_Standard1_Point.U.ToString("0.00000");
            text_Cam2_Standard_Point2_X.Text = AppParam.Instance.CalibrationData.Cam2_Standard2_Point.X.ToString("0.00000");
            text_Cam2_Standard_Point2_Y.Text = AppParam.Instance.CalibrationData.Cam2_Standard2_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point2_U.Text = AppParam.Instance.CalibrationData.Cam2_Standard2_Point.U.ToString("0.00000");

            textBox_Cam3_Point1_X1.Text = AppParam.Instance.CalibrationData.Cam3_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam3_Point1_Y1.Text = AppParam.Instance.CalibrationData.Cam3_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam3_Point1_X2.Text = AppParam.Instance.CalibrationData.Cam3_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam3_Point1_Y2.Text = AppParam.Instance.CalibrationData.Cam3_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam3_Point1_X3.Text = AppParam.Instance.CalibrationData.Cam3_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam3_Point1_Y3.Text = AppParam.Instance.CalibrationData.Cam3_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam3_Point2_X1.Text = AppParam.Instance.CalibrationData.Cam3_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam3_Point2_Y1.Text = AppParam.Instance.CalibrationData.Cam3_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam3_Point2_X2.Text = AppParam.Instance.CalibrationData.Cam3_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam3_Point2_Y2.Text = AppParam.Instance.CalibrationData.Cam3_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam3_Point2_X3.Text = AppParam.Instance.CalibrationData.Cam3_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam3_Point2_Y3.Text = AppParam.Instance.CalibrationData.Cam3_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam3_Center1_X.Text = AppParam.Instance.CalibrationData.Cam3_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam3_Center1_Y.Text = AppParam.Instance.CalibrationData.Cam3_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam3_Center2_X.Text = AppParam.Instance.CalibrationData.Cam3_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam3_Center2_Y.Text = AppParam.Instance.CalibrationData.Cam3_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point1_X.Text = AppParam.Instance.CalibrationData.Cam3_Standard1_Point.X.ToString("0.00000");
            text_Cam3_Standard_Point1_Y.Text = AppParam.Instance.CalibrationData.Cam3_Standard1_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point1_U.Text = AppParam.Instance.CalibrationData.Cam3_Standard1_Point.U.ToString("0.00000");
            text_Cam3_Standard_Point2_X.Text = AppParam.Instance.CalibrationData.Cam3_Standard2_Point.X.ToString("0.00000");
            text_Cam3_Standard_Point2_Y.Text = AppParam.Instance.CalibrationData.Cam3_Standard2_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point2_U.Text = AppParam.Instance.CalibrationData.Cam3_Standard2_Point.U.ToString("0.00000");


            for (int i = 0; i < AppParam.Instance.CalibrationData.Cam1_Robot_Location.Count; i++)
            {
                int index = Cam1_Data.Rows.Add();
                Cam1_Data.Rows[index].Cells[0].Value = index;
                Cam1_Data.Rows[index].Cells[1].Value = AppParam.Instance.CalibrationData.Cam1_Robot_Location[i].X;
                Cam1_Data.Rows[index].Cells[2].Value = AppParam.Instance.CalibrationData.Cam1_Robot_Location[i].Y;
                Cam1_Data.Rows[index].Cells[3].Value = AppParam.Instance.CalibrationData.Cam1_Pixel_Location[i].X;
                Cam1_Data.Rows[index].Cells[4].Value = AppParam.Instance.CalibrationData.Cam1_Pixel_Location[i].Y;

            }

            for (int i = 0; i < AppParam.Instance.CalibrationData.Cam2_Robot_Location.Count; i++)
            {
                int index = Cam2_Data.Rows.Add();
                Cam2_Data.Rows[index].Cells[0].Value = index;
                Cam2_Data.Rows[index].Cells[1].Value = AppParam.Instance.CalibrationData.Cam2_Robot_Location[i].X;
                Cam2_Data.Rows[index].Cells[2].Value = AppParam.Instance.CalibrationData.Cam2_Robot_Location[i].Y;
                Cam2_Data.Rows[index].Cells[3].Value = AppParam.Instance.CalibrationData.Cam2_Pixel_Location[i].X;
                Cam2_Data.Rows[index].Cells[4].Value = AppParam.Instance.CalibrationData.Cam2_Pixel_Location[i].Y;

            }
            for (int i = 0; i < AppParam.Instance.CalibrationData.Cam3_Robot_Location.Count; i++)
            {
                int index = Cam3_Data.Rows.Add();
                Cam3_Data.Rows[index].Cells[0].Value = index;
                Cam3_Data.Rows[index].Cells[1].Value = AppParam.Instance.CalibrationData.Cam3_Robot_Location[i].X;
                Cam3_Data.Rows[index].Cells[2].Value = AppParam.Instance.CalibrationData.Cam3_Robot_Location[i].Y;
                Cam3_Data.Rows[index].Cells[3].Value = AppParam.Instance.CalibrationData.Cam3_Pixel_Location[i].X;
                Cam3_Data.Rows[index].Cells[4].Value = AppParam.Instance.CalibrationData.Cam3_Pixel_Location[i].Y;

            }

        }


        public void SaveData()
        {
            AppParam.Instance.CalibrationData.Cam1_Rotate1_Point1.X = double.Parse(textBox_Cam1_Point1_X1.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate1_Point1.Y = double.Parse(textBox_Cam1_Point1_Y1.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate1_Point2.X = double.Parse(textBox_Cam1_Point1_X2.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate1_Point2.Y = double.Parse(textBox_Cam1_Point1_Y2.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate1_Point3.X = double.Parse(textBox_Cam1_Point1_X3.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate1_Point3.Y = double.Parse(textBox_Cam1_Point1_Y3.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate2_Point1.X = double.Parse(textBox_Cam1_Point2_X1.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate2_Point1.Y = double.Parse(textBox_Cam1_Point2_Y1.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate2_Point2.X = double.Parse(textBox_Cam1_Point2_X2.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate2_Point2.Y = double.Parse(textBox_Cam1_Point2_Y2.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate2_Point3.X = double.Parse(textBox_Cam1_Point2_X3.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate2_Point3.Y = double.Parse(textBox_Cam1_Point2_Y3.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate_Center1_Point.X = double.Parse(textBox_Cam1_Center1_X.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate_Center1_Point.Y = double.Parse(textBox_Cam1_Center1_Y.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate_Center2_Point.X = double.Parse(textBox_Cam1_Center2_X.Text);
            AppParam.Instance.CalibrationData.Cam1_Rotate_Center2_Point.Y = double.Parse(textBox_Cam1_Center2_Y.Text);
            AppParam.Instance.CalibrationData.Cam1_Standard1_Point.X = double.Parse(text_Cam1_Standard_Point1_X.Text);
            AppParam.Instance.CalibrationData.Cam1_Standard1_Point.Y = double.Parse(text_Cam1_Standard_Point1_Y.Text);
            AppParam.Instance.CalibrationData.Cam1_Standard1_Point.U = double.Parse(text_Cam1_Standard_Point1_U.Text);
            AppParam.Instance.CalibrationData.Cam1_Standard2_Point.X = double.Parse(text_Cam1_Standard_Point2_X.Text);
            AppParam.Instance.CalibrationData.Cam1_Standard2_Point.Y = double.Parse(text_Cam1_Standard_Point2_Y.Text);
            AppParam.Instance.CalibrationData.Cam1_Standard2_Point.U = double.Parse(text_Cam1_Standard_Point2_U.Text);



            AppParam.Instance.CalibrationData.Cam2_Rotate1_Point1.X = double.Parse(textBox_Cam2_Point1_X1.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate1_Point1.Y = double.Parse(textBox_Cam2_Point1_Y1.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate1_Point2.X = double.Parse(textBox_Cam2_Point1_X2.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate1_Point2.Y = double.Parse(textBox_Cam2_Point1_Y2.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate1_Point3.X = double.Parse(textBox_Cam2_Point1_X3.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate1_Point3.Y = double.Parse(textBox_Cam2_Point1_Y3.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate2_Point1.X = double.Parse(textBox_Cam2_Point2_X1.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate2_Point1.Y = double.Parse(textBox_Cam2_Point2_Y1.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate2_Point2.X = double.Parse(textBox_Cam2_Point2_X2.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate2_Point2.Y = double.Parse(textBox_Cam2_Point2_Y2.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate2_Point3.X = double.Parse(textBox_Cam2_Point2_X3.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate2_Point3.Y = double.Parse(textBox_Cam2_Point2_Y3.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate_Center1_Point.X = double.Parse(textBox_Cam2_Center1_X.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate_Center1_Point.Y = double.Parse(textBox_Cam2_Center1_Y.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate_Center2_Point.X = double.Parse(textBox_Cam2_Center2_X.Text);
            AppParam.Instance.CalibrationData.Cam2_Rotate_Center2_Point.Y = double.Parse(textBox_Cam2_Center2_Y.Text);
            AppParam.Instance.CalibrationData.Cam2_Standard1_Point.X = double.Parse(text_Cam2_Standard_Point1_X.Text);
            AppParam.Instance.CalibrationData.Cam2_Standard1_Point.Y = double.Parse(text_Cam2_Standard_Point1_Y.Text);
            AppParam.Instance.CalibrationData.Cam2_Standard1_Point.U = double.Parse(text_Cam2_Standard_Point1_U.Text);
            AppParam.Instance.CalibrationData.Cam2_Standard2_Point.X = double.Parse(text_Cam2_Standard_Point2_X.Text);
            AppParam.Instance.CalibrationData.Cam2_Standard2_Point.Y = double.Parse(text_Cam2_Standard_Point2_Y.Text);
            AppParam.Instance.CalibrationData.Cam2_Standard2_Point.U = double.Parse(text_Cam2_Standard_Point2_U.Text);



            AppParam.Instance.CalibrationData.Cam3_Rotate1_Point1.X = double.Parse(textBox_Cam3_Point1_X1.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate1_Point1.Y = double.Parse(textBox_Cam3_Point1_Y1.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate1_Point2.X = double.Parse(textBox_Cam3_Point1_X2.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate1_Point2.Y = double.Parse(textBox_Cam3_Point1_Y2.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate1_Point3.X = double.Parse(textBox_Cam3_Point1_X3.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate1_Point3.Y = double.Parse(textBox_Cam3_Point1_Y3.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate2_Point1.X = double.Parse(textBox_Cam3_Point2_X1.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate2_Point1.Y = double.Parse(textBox_Cam3_Point2_Y1.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate2_Point2.X = double.Parse(textBox_Cam3_Point2_X2.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate2_Point2.Y = double.Parse(textBox_Cam3_Point2_Y2.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate2_Point3.X = double.Parse(textBox_Cam3_Point2_X3.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate2_Point3.Y = double.Parse(textBox_Cam3_Point2_Y3.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate_Center1_Point.X = double.Parse(textBox_Cam3_Center1_X.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate_Center1_Point.Y = double.Parse(textBox_Cam3_Center1_Y.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate_Center2_Point.X = double.Parse(textBox_Cam3_Center2_X.Text);
            AppParam.Instance.CalibrationData.Cam3_Rotate_Center2_Point.Y = double.Parse(textBox_Cam3_Center2_Y.Text);
            AppParam.Instance.CalibrationData.Cam3_Standard1_Point.X = double.Parse(text_Cam3_Standard_Point1_X.Text);
            AppParam.Instance.CalibrationData.Cam3_Standard1_Point.Y = double.Parse(text_Cam3_Standard_Point1_Y.Text);
            AppParam.Instance.CalibrationData.Cam3_Standard1_Point.U = double.Parse(text_Cam3_Standard_Point1_U.Text);
            AppParam.Instance.CalibrationData.Cam3_Standard2_Point.X = double.Parse(text_Cam3_Standard_Point2_X.Text);
            AppParam.Instance.CalibrationData.Cam3_Standard2_Point.Y = double.Parse(text_Cam3_Standard_Point2_Y.Text);
            AppParam.Instance.CalibrationData.Cam3_Standard2_Point.U = double.Parse(text_Cam3_Standard_Point2_U.Text);

            AppParam.Instance.CalibrationData.Cam1_Robot_Location = new List<RobotPoint>();
            AppParam.Instance.CalibrationData.Cam1_Pixel_Location = new List<RobotPoint>();
            AppParam.Instance.CalibrationData.Cam2_Robot_Location = new List<RobotPoint>();
            AppParam.Instance.CalibrationData.Cam2_Pixel_Location = new List<RobotPoint>();
            AppParam.Instance.CalibrationData.Cam3_Robot_Location = new List<RobotPoint>();
            AppParam.Instance.CalibrationData.Cam3_Pixel_Location = new List<RobotPoint>();


            for (int i = 0; i < Cam1_Data.Rows.Count - 1; i++)
            {
                AppParam.Instance.CalibrationData.Cam1_Robot_Location.Add(new RobotPoint() { X = (double)Cam1_Data.Rows[i].Cells[1].Value, Y = (double)Cam1_Data.Rows[i].Cells[2].Value });
                AppParam.Instance.CalibrationData.Cam1_Pixel_Location.Add(new RobotPoint() { X = (double)Cam1_Data.Rows[i].Cells[3].Value, Y = (double)Cam1_Data.Rows[i].Cells[4].Value });
            }
            for (int i = 0; i < Cam2_Data.Rows.Count - 1; i++)
            {
                AppParam.Instance.CalibrationData.Cam2_Robot_Location.Add(new RobotPoint() { X = (double)Cam2_Data.Rows[i].Cells[1].Value, Y = (double)Cam2_Data.Rows[i].Cells[2].Value });
                AppParam.Instance.CalibrationData.Cam2_Pixel_Location.Add(new RobotPoint() { X = (double)Cam2_Data.Rows[i].Cells[3].Value, Y = (double)Cam2_Data.Rows[i].Cells[4].Value });
            }
            for (int i = 0; i < Cam3_Data.Rows.Count - 1; i++)
            {
                AppParam.Instance.CalibrationData.Cam3_Robot_Location.Add(new RobotPoint() { X = (double)Cam3_Data.Rows[i].Cells[1].Value, Y = (double)Cam3_Data.Rows[i].Cells[2].Value });
                AppParam.Instance.CalibrationData.Cam3_Pixel_Location.Add(new RobotPoint() { X = (double)Cam3_Data.Rows[i].Cells[3].Value, Y = (double)Cam3_Data.Rows[i].Cells[4].Value });
            }
        }

        private void Form_Robot_Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
            AppParam.Instance.Save_To_File();
        }
    }
}
