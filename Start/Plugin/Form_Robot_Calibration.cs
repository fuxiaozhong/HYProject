using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Model;

using ToolKit.DisplayWindow;

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

        public HalconWindow Window
        {
            get
            {
                return halconWindow1;
            }
        }

        private Form_Robot_Calibration()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void ClearData(int CamStep)
        {
            if (CamStep == 1)
            {
                dataGridView_Cam1.Rows.Clear();
            }
            else if (CamStep == 2)
            {
                dataGridView_Cam2.Rows.Clear();
            }
            else if (CamStep == 3)
            {
                dataGridView_Cam3.Rows.Clear();
            }
        }

        public void Disp_order(string order)
        {
            this.Invoke(new Action(delegate
            {
                label2.Text = order;
            }));
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
            //这里采用委托的方式解决线程卡死问题；
            //在需要添加行的地方直接copy如下代码即可；
            this.Invoke(new Action(delegate
            {
                if (CamStep == 1)
                {
                    int index = dataGridView_Cam1.Rows.Add();
                    dataGridView_Cam1.Rows[index].Cells[0].Value = index + 1;
                    dataGridView_Cam1.Rows[index].Cells[1].Value = Row.ToString("0.00000");
                    dataGridView_Cam1.Rows[index].Cells[2].Value = Column.ToString("0.00000");
                    dataGridView_Cam1.Rows[index].Cells[3].Value = RobotX.ToString("0.00000");
                    dataGridView_Cam1.Rows[index].Cells[4].Value = RobotY.ToString("0.00000");
                }
                else if (CamStep == 2)
                {
                    int index = dataGridView_Cam2.Rows.Add();
                    dataGridView_Cam2.Rows[index].Cells[0].Value = index + 1;
                    dataGridView_Cam2.Rows[index].Cells[1].Value = Row.ToString("0.00000");
                    dataGridView_Cam2.Rows[index].Cells[2].Value = Column.ToString("0.00000");
                    dataGridView_Cam2.Rows[index].Cells[3].Value = RobotX.ToString("0.00000");
                    dataGridView_Cam2.Rows[index].Cells[4].Value = RobotY.ToString("0.00000");
                }
                else if (CamStep == 3)
                {
                    int index = dataGridView_Cam3.Rows.Add();
                    dataGridView_Cam3.Rows[index].Cells[0].Value = index + 1;
                    dataGridView_Cam3.Rows[index].Cells[1].Value = Row.ToString("0.00000");
                    dataGridView_Cam3.Rows[index].Cells[2].Value = Column.ToString("0.00000");
                    dataGridView_Cam3.Rows[index].Cells[3].Value = RobotX.ToString("0.00000");
                    dataGridView_Cam3.Rows[index].Cells[4].Value = RobotY.ToString("0.00000");
                }
            }));
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

        public double[] RotateCenter(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double a, b, c, d, e, f;
            a = 2 * (x2 - x1);
            b = 2 * (y2 - y1);
            c = x2 * x2 + y2 * y2 - x1 * x1 - y1 * y1;
            d = 2 * (x3 - x2);
            e = 2 * (y3 - y2);
            f = x3 * x3 + y3 * y3 - x2 * x2 - y2 * y2;
            double x = (b * f - e * c) / (b * d - e * a);
            double y = (d * c - a * f) / (b * d - e * a);
            double r = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - x) * (y1 - x));
            double[] xyr = new double[3];
            xyr[0] = x;
            xyr[1] = y;
            xyr[2] = r;
            return xyr;
        }

        private void Form_Robot_Calibration_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        label75.Text = Work.Cam1_Calibration_Mode ? "标定模式" : "待机模式";
                        label75.BackColor = Work.Cam1_Calibration_Mode ? Color.Green : Color.Cyan;

                        label76.Text = Work.Cam2_Calibration_Mode ? "标定模式" : "待机模式";
                        label76.BackColor = Work.Cam2_Calibration_Mode ? Color.Green : Color.Cyan;

                        label77.Text = Work.Cam3_Calibration_Mode ? "标定模式" : "待机模式";
                        label77.BackColor = Work.Cam3_Calibration_Mode ? Color.Green : Color.Cyan;
                    }
                    catch (Exception)
                    {
                    }
                    Thread.Sleep(500);
                }
            });

            textBox_Cam1_minScore1.Text = CalibrationData.Instance.Cam1_minScore1.ToString("0.00000");
            textBox_Cam1_minScore2.Text = CalibrationData.Instance.Cam1_minScore2.ToString("0.00000");
            textBox_Cam2_minScore1.Text = CalibrationData.Instance.Cam2_minScore1.ToString("0.00000");
            textBox_Cam2_minScore2.Text = CalibrationData.Instance.Cam2_minScore2.ToString("0.00000");
            textBox_Cam3_minScore1.Text = CalibrationData.Instance.Cam3_minScore1.ToString("0.00000");
            textBox_Cam3_minScore2.Text = CalibrationData.Instance.Cam3_minScore2.ToString("0.00000");

            textBox_Cam1_Point1_X1.Text = CalibrationData.Instance.Cam1_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam1_Point1_Y1.Text = CalibrationData.Instance.Cam1_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam1_Point1_X2.Text = CalibrationData.Instance.Cam1_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam1_Point1_Y2.Text = CalibrationData.Instance.Cam1_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam1_Point1_X3.Text = CalibrationData.Instance.Cam1_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam1_Point1_Y3.Text = CalibrationData.Instance.Cam1_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam1_Point2_X1.Text = CalibrationData.Instance.Cam1_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam1_Point2_Y1.Text = CalibrationData.Instance.Cam1_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam1_Point2_X2.Text = CalibrationData.Instance.Cam1_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam1_Point2_Y2.Text = CalibrationData.Instance.Cam1_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam1_Point2_X3.Text = CalibrationData.Instance.Cam1_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam1_Point2_Y3.Text = CalibrationData.Instance.Cam1_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam1_Center1_X.Text = CalibrationData.Instance.Cam1_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam1_Center1_Y.Text = CalibrationData.Instance.Cam1_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam1_Center2_X.Text = CalibrationData.Instance.Cam1_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam1_Center2_Y.Text = CalibrationData.Instance.Cam1_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point1_X.Text = CalibrationData.Instance.Cam1_Standard1_Point.X.ToString("0.00000");
            text_Cam1_Standard_Point1_Y.Text = CalibrationData.Instance.Cam1_Standard1_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point1_U.Text = CalibrationData.Instance.Cam1_Standard1_Point.U.ToString("0.00000");
            text_Cam1_Standard_Point2_X.Text = CalibrationData.Instance.Cam1_Standard2_Point.X.ToString("0.00000");
            text_Cam1_Standard_Point2_Y.Text = CalibrationData.Instance.Cam1_Standard2_Point.Y.ToString("0.00000");
            text_Cam1_Standard_Point2_U.Text = CalibrationData.Instance.Cam1_Standard2_Point.U.ToString("0.00000");

            textBox_Cam2_Point1_X1.Text = CalibrationData.Instance.Cam2_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam2_Point1_Y1.Text = CalibrationData.Instance.Cam2_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam2_Point1_X2.Text = CalibrationData.Instance.Cam2_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam2_Point1_Y2.Text = CalibrationData.Instance.Cam2_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam2_Point1_X3.Text = CalibrationData.Instance.Cam2_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam2_Point1_Y3.Text = CalibrationData.Instance.Cam2_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam2_Point2_X1.Text = CalibrationData.Instance.Cam2_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam2_Point2_Y1.Text = CalibrationData.Instance.Cam2_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam2_Point2_X2.Text = CalibrationData.Instance.Cam2_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam2_Point2_Y2.Text = CalibrationData.Instance.Cam2_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam2_Point2_X3.Text = CalibrationData.Instance.Cam2_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam2_Point2_Y3.Text = CalibrationData.Instance.Cam2_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam2_Center1_X.Text = CalibrationData.Instance.Cam2_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam2_Center1_Y.Text = CalibrationData.Instance.Cam2_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam2_Center2_X.Text = CalibrationData.Instance.Cam2_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam2_Center2_Y.Text = CalibrationData.Instance.Cam2_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point1_X.Text = CalibrationData.Instance.Cam2_Standard1_Point.X.ToString("0.00000");
            text_Cam2_Standard_Point1_Y.Text = CalibrationData.Instance.Cam2_Standard1_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point1_U.Text = CalibrationData.Instance.Cam2_Standard1_Point.U.ToString("0.00000");
            text_Cam2_Standard_Point2_X.Text = CalibrationData.Instance.Cam2_Standard2_Point.X.ToString("0.00000");
            text_Cam2_Standard_Point2_Y.Text = CalibrationData.Instance.Cam2_Standard2_Point.Y.ToString("0.00000");
            text_Cam2_Standard_Point2_U.Text = CalibrationData.Instance.Cam2_Standard2_Point.U.ToString("0.00000");

            textBox_Cam3_Point1_X1.Text = CalibrationData.Instance.Cam3_Rotate1_Point1.X.ToString("0.00000");
            textBox_Cam3_Point1_Y1.Text = CalibrationData.Instance.Cam3_Rotate1_Point1.Y.ToString("0.00000");
            textBox_Cam3_Point1_X2.Text = CalibrationData.Instance.Cam3_Rotate1_Point2.X.ToString("0.00000");
            textBox_Cam3_Point1_Y2.Text = CalibrationData.Instance.Cam3_Rotate1_Point2.Y.ToString("0.00000");
            textBox_Cam3_Point1_X3.Text = CalibrationData.Instance.Cam3_Rotate1_Point3.X.ToString("0.00000");
            textBox_Cam3_Point1_Y3.Text = CalibrationData.Instance.Cam3_Rotate1_Point3.Y.ToString("0.00000");
            textBox_Cam3_Point2_X1.Text = CalibrationData.Instance.Cam3_Rotate2_Point1.X.ToString("0.00000");
            textBox_Cam3_Point2_Y1.Text = CalibrationData.Instance.Cam3_Rotate2_Point1.Y.ToString("0.00000");
            textBox_Cam3_Point2_X2.Text = CalibrationData.Instance.Cam3_Rotate2_Point2.X.ToString("0.00000");
            textBox_Cam3_Point2_Y2.Text = CalibrationData.Instance.Cam3_Rotate2_Point2.Y.ToString("0.00000");
            textBox_Cam3_Point2_X3.Text = CalibrationData.Instance.Cam3_Rotate2_Point3.X.ToString("0.00000");
            textBox_Cam3_Point2_Y3.Text = CalibrationData.Instance.Cam3_Rotate2_Point3.Y.ToString("0.00000");
            textBox_Cam3_Center1_X.Text = CalibrationData.Instance.Cam3_Rotate_Center1_Point.X.ToString("0.00000");
            textBox_Cam3_Center1_Y.Text = CalibrationData.Instance.Cam3_Rotate_Center1_Point.Y.ToString("0.00000");
            textBox_Cam3_Center2_X.Text = CalibrationData.Instance.Cam3_Rotate_Center2_Point.X.ToString("0.00000");
            textBox_Cam3_Center2_Y.Text = CalibrationData.Instance.Cam3_Rotate_Center2_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point1_X.Text = CalibrationData.Instance.Cam3_Standard1_Point.X.ToString("0.00000");
            text_Cam3_Standard_Point1_Y.Text = CalibrationData.Instance.Cam3_Standard1_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point1_U.Text = CalibrationData.Instance.Cam3_Standard1_Point.U.ToString("0.00000");
            text_Cam3_Standard_Point2_X.Text = CalibrationData.Instance.Cam3_Standard2_Point.X.ToString("0.00000");
            text_Cam3_Standard_Point2_Y.Text = CalibrationData.Instance.Cam3_Standard2_Point.Y.ToString("0.00000");
            text_Cam3_Standard_Point2_U.Text = CalibrationData.Instance.Cam3_Standard2_Point.U.ToString("0.00000");

            for (int i = 0; i < CalibrationData.Instance.Cam1_Robot_Location.Count; i++)
            {
                int index = dataGridView_Cam1.Rows.Add();
                dataGridView_Cam1.Rows[index].Cells[0].Value = index;
                dataGridView_Cam1.Rows[index].Cells[0].Value = index + 1;
                dataGridView_Cam1.Rows[index].Cells[1].Value = CalibrationData.Instance.Cam1_Pixel_Location[i].X;
                dataGridView_Cam1.Rows[index].Cells[2].Value = CalibrationData.Instance.Cam1_Pixel_Location[i].Y;
                dataGridView_Cam1.Rows[index].Cells[3].Value = CalibrationData.Instance.Cam1_Robot_Location[i].X;
                dataGridView_Cam1.Rows[index].Cells[4].Value = CalibrationData.Instance.Cam1_Robot_Location[i].Y;
            }

            for (int i = 0; i < CalibrationData.Instance.Cam2_Robot_Location.Count; i++)
            {
                int index = dataGridView_Cam2.Rows.Add();
                dataGridView_Cam2.Rows[index].Cells[0].Value = index;
                dataGridView_Cam2.Rows[index].Cells[0].Value = index + 1;
                dataGridView_Cam2.Rows[index].Cells[1].Value = CalibrationData.Instance.Cam2_Pixel_Location[i].X;
                dataGridView_Cam2.Rows[index].Cells[2].Value = CalibrationData.Instance.Cam2_Pixel_Location[i].Y;
                dataGridView_Cam2.Rows[index].Cells[3].Value = CalibrationData.Instance.Cam2_Robot_Location[i].X;
                dataGridView_Cam2.Rows[index].Cells[4].Value = CalibrationData.Instance.Cam2_Robot_Location[i].Y;
            }
            for (int i = 0; i < CalibrationData.Instance.Cam3_Robot_Location.Count; i++)
            {
                int index = dataGridView_Cam3.Rows.Add();
                dataGridView_Cam3.Rows[index].Cells[0].Value = index + 1;
                dataGridView_Cam3.Rows[index].Cells[1].Value = CalibrationData.Instance.Cam3_Pixel_Location[i].X;
                dataGridView_Cam3.Rows[index].Cells[2].Value = CalibrationData.Instance.Cam3_Pixel_Location[i].Y;
                dataGridView_Cam3.Rows[index].Cells[3].Value = CalibrationData.Instance.Cam3_Robot_Location[i].X;
                dataGridView_Cam3.Rows[index].Cells[4].Value = CalibrationData.Instance.Cam3_Robot_Location[i].Y;
            }
        }

        public void SaveData()
        {
            CalibrationData.Instance.Cam1_minScore1 = double.Parse(textBox_Cam1_minScore1.Text.Trim());
            CalibrationData.Instance.Cam1_minScore2 = double.Parse(textBox_Cam1_minScore2.Text.Trim());
            CalibrationData.Instance.Cam2_minScore1 = double.Parse(textBox_Cam2_minScore1.Text.Trim());
            CalibrationData.Instance.Cam2_minScore2 = double.Parse(textBox_Cam2_minScore2.Text.Trim());
            CalibrationData.Instance.Cam3_minScore1 = double.Parse(textBox_Cam3_minScore1.Text.Trim());
            CalibrationData.Instance.Cam3_minScore2 = double.Parse(textBox_Cam3_minScore2.Text.Trim());

            CalibrationData.Instance.Cam1_Rotate1_Point1.X = double.Parse(textBox_Cam1_Point1_X1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point1.Y = double.Parse(textBox_Cam1_Point1_Y1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point2.X = double.Parse(textBox_Cam1_Point1_X2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point2.Y = double.Parse(textBox_Cam1_Point1_Y2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point3.X = double.Parse(textBox_Cam1_Point1_X3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate1_Point3.Y = double.Parse(textBox_Cam1_Point1_Y3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point1.X = double.Parse(textBox_Cam1_Point2_X1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point1.Y = double.Parse(textBox_Cam1_Point2_Y1.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point2.X = double.Parse(textBox_Cam1_Point2_X2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point2.Y = double.Parse(textBox_Cam1_Point2_Y2.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point3.X = double.Parse(textBox_Cam1_Point2_X3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate2_Point3.Y = double.Parse(textBox_Cam1_Point2_Y3.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center1_Point.X = double.Parse(textBox_Cam1_Center1_X.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center1_Point.Y = double.Parse(textBox_Cam1_Center1_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center2_Point.X = double.Parse(textBox_Cam1_Center2_X.Text.Trim());
            CalibrationData.Instance.Cam1_Rotate_Center2_Point.Y = double.Parse(textBox_Cam1_Center2_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Standard1_Point.X = double.Parse(text_Cam1_Standard_Point1_X.Text.Trim());
            CalibrationData.Instance.Cam1_Standard1_Point.Y = double.Parse(text_Cam1_Standard_Point1_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Standard1_Point.U = double.Parse(text_Cam1_Standard_Point1_U.Text.Trim());
            CalibrationData.Instance.Cam1_Standard2_Point.X = double.Parse(text_Cam1_Standard_Point2_X.Text.Trim());
            CalibrationData.Instance.Cam1_Standard2_Point.Y = double.Parse(text_Cam1_Standard_Point2_Y.Text.Trim());
            CalibrationData.Instance.Cam1_Standard2_Point.U = double.Parse(text_Cam1_Standard_Point2_U.Text.Trim());

            CalibrationData.Instance.Cam2_Rotate1_Point1.X = double.Parse(textBox_Cam2_Point1_X1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point1.Y = double.Parse(textBox_Cam2_Point1_Y1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point2.X = double.Parse(textBox_Cam2_Point1_X2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point2.Y = double.Parse(textBox_Cam2_Point1_Y2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point3.X = double.Parse(textBox_Cam2_Point1_X3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate1_Point3.Y = double.Parse(textBox_Cam2_Point1_Y3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point1.X = double.Parse(textBox_Cam2_Point2_X1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point1.Y = double.Parse(textBox_Cam2_Point2_Y1.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point2.X = double.Parse(textBox_Cam2_Point2_X2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point2.Y = double.Parse(textBox_Cam2_Point2_Y2.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point3.X = double.Parse(textBox_Cam2_Point2_X3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate2_Point3.Y = double.Parse(textBox_Cam2_Point2_Y3.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center1_Point.X = double.Parse(textBox_Cam2_Center1_X.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center1_Point.Y = double.Parse(textBox_Cam2_Center1_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center2_Point.X = double.Parse(textBox_Cam2_Center2_X.Text.Trim());
            CalibrationData.Instance.Cam2_Rotate_Center2_Point.Y = double.Parse(textBox_Cam2_Center2_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Standard1_Point.X = double.Parse(text_Cam2_Standard_Point1_X.Text.Trim());
            CalibrationData.Instance.Cam2_Standard1_Point.Y = double.Parse(text_Cam2_Standard_Point1_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Standard1_Point.U = double.Parse(text_Cam2_Standard_Point1_U.Text.Trim());
            CalibrationData.Instance.Cam2_Standard2_Point.X = double.Parse(text_Cam2_Standard_Point2_X.Text.Trim());
            CalibrationData.Instance.Cam2_Standard2_Point.Y = double.Parse(text_Cam2_Standard_Point2_Y.Text.Trim());
            CalibrationData.Instance.Cam2_Standard2_Point.U = double.Parse(text_Cam2_Standard_Point2_U.Text.Trim());

            CalibrationData.Instance.Cam3_Rotate1_Point1.X = double.Parse(textBox_Cam3_Point1_X1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point1.Y = double.Parse(textBox_Cam3_Point1_Y1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point2.X = double.Parse(textBox_Cam3_Point1_X2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point2.Y = double.Parse(textBox_Cam3_Point1_Y2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point3.X = double.Parse(textBox_Cam3_Point1_X3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate1_Point3.Y = double.Parse(textBox_Cam3_Point1_Y3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point1.X = double.Parse(textBox_Cam3_Point2_X1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point1.Y = double.Parse(textBox_Cam3_Point2_Y1.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point2.X = double.Parse(textBox_Cam3_Point2_X2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point2.Y = double.Parse(textBox_Cam3_Point2_Y2.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point3.X = double.Parse(textBox_Cam3_Point2_X3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate2_Point3.Y = double.Parse(textBox_Cam3_Point2_Y3.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center1_Point.X = double.Parse(textBox_Cam3_Center1_X.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center1_Point.Y = double.Parse(textBox_Cam3_Center1_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center2_Point.X = double.Parse(textBox_Cam3_Center2_X.Text.Trim());
            CalibrationData.Instance.Cam3_Rotate_Center2_Point.Y = double.Parse(textBox_Cam3_Center2_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Standard1_Point.X = double.Parse(text_Cam3_Standard_Point1_X.Text.Trim());
            CalibrationData.Instance.Cam3_Standard1_Point.Y = double.Parse(text_Cam3_Standard_Point1_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Standard1_Point.U = double.Parse(text_Cam3_Standard_Point1_U.Text.Trim());
            CalibrationData.Instance.Cam3_Standard2_Point.X = double.Parse(text_Cam3_Standard_Point2_X.Text.Trim());
            CalibrationData.Instance.Cam3_Standard2_Point.Y = double.Parse(text_Cam3_Standard_Point2_Y.Text.Trim());
            CalibrationData.Instance.Cam3_Standard2_Point.U = double.Parse(text_Cam3_Standard_Point2_U.Text.Trim());

            CalibrationData.Instance.Cam1_Robot_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam1_Pixel_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam2_Robot_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam2_Pixel_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam3_Robot_Location = new List<RobotPoint>();
            CalibrationData.Instance.Cam3_Pixel_Location = new List<RobotPoint>();

            for (int i = 0; i < dataGridView_Cam1.Rows.Count - 1; i++)
            {
                CalibrationData.Instance.Cam1_Robot_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam1.Rows[i].Cells[3].Value.ToString()), Y = double.Parse(dataGridView_Cam1.Rows[i].Cells[4].Value.ToString()) });
                CalibrationData.Instance.Cam1_Pixel_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString()), Y = double.Parse(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString()) });
            }
            for (int i = 0; i < dataGridView_Cam2.Rows.Count - 1; i++)
            {
                CalibrationData.Instance.Cam2_Robot_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam2.Rows[i].Cells[3].Value.ToString()), Y = double.Parse(dataGridView_Cam2.Rows[i].Cells[4].Value.ToString()) });
                CalibrationData.Instance.Cam2_Pixel_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString()), Y = double.Parse(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString()) });
            }
            for (int i = 0; i < dataGridView_Cam3.Rows.Count - 1; i++)
            {
                CalibrationData.Instance.Cam3_Robot_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam3.Rows[i].Cells[3].Value.ToString()), Y = double.Parse(dataGridView_Cam3.Rows[i].Cells[4].Value.ToString()) });
                CalibrationData.Instance.Cam3_Pixel_Location.Add(new RobotPoint() { X = double.Parse(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString()), Y = double.Parse(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString()) });
            }
        }

        private void Form_Robot_Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveData();
            //AppParam.Instance.Save_To_File();
        }

        public void Auto(int CamIndex)
        {
            if (CamIndex == 1)
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[3].Value.ToString());
                    Y[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[4].Value.ToString());
                    Column[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString());
                    Row[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam1_HomMat2d);
                textBox_Cam1_Point1_X1.Text = dataGridView_Cam1.Rows[4].Cells[1].Value.ToString();
                textBox_Cam1_Point1_Y1.Text = dataGridView_Cam1.Rows[4].Cells[2].Value.ToString();
                textBox_Cam1_Point1_X2.Text = dataGridView_Cam1.Rows[9].Cells[1].Value.ToString();
                textBox_Cam1_Point1_Y2.Text = dataGridView_Cam1.Rows[9].Cells[2].Value.ToString();
                textBox_Cam1_Point1_X3.Text = dataGridView_Cam1.Rows[10].Cells[1].Value.ToString();
                textBox_Cam1_Point1_Y3.Text = dataGridView_Cam1.Rows[10].Cells[2].Value.ToString();
                HTuple Point1_X1 = double.Parse(textBox_Cam1_Point1_X1.Text);
                HTuple Point1_Y1 = double.Parse(textBox_Cam1_Point1_Y1.Text);
                HTuple Point1_X2 = double.Parse(textBox_Cam1_Point1_X2.Text);
                HTuple Point1_Y2 = double.Parse(textBox_Cam1_Point1_Y2.Text);
                HTuple Point1_X3 = double.Parse(textBox_Cam1_Point1_X3.Text);
                HTuple Point1_Y3 = double.Parse(textBox_Cam1_Point1_Y3.Text);
                RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },

                                                        new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });
                textBox_Cam1_Center1_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam1_Center1_Y.Text = Center_Point.Y.ToString("0.00000");
                textBox_Cam1_Point2_X1.Text = dataGridView_Cam1.Rows[11].Cells[1].Value.ToString();
                textBox_Cam1_Point2_Y1.Text = dataGridView_Cam1.Rows[11].Cells[2].Value.ToString();
                textBox_Cam1_Point2_X2.Text = dataGridView_Cam1.Rows[12].Cells[1].Value.ToString();
                textBox_Cam1_Point2_Y2.Text = dataGridView_Cam1.Rows[12].Cells[2].Value.ToString();
                textBox_Cam1_Point2_X3.Text = dataGridView_Cam1.Rows[13].Cells[1].Value.ToString();
                textBox_Cam1_Point2_Y3.Text = dataGridView_Cam1.Rows[13].Cells[2].Value.ToString();
                HTuple Point2_X1 = double.Parse(textBox_Cam1_Point2_X1.Text);
                HTuple Point2_Y1 = double.Parse(textBox_Cam1_Point2_Y1.Text);
                HTuple Point2_X2 = double.Parse(textBox_Cam1_Point2_X2.Text);
                HTuple Point2_Y2 = double.Parse(textBox_Cam1_Point2_Y2.Text);
                HTuple Point2_X3 = double.Parse(textBox_Cam1_Point2_X3.Text);
                HTuple Point2_Y3 = double.Parse(textBox_Cam1_Point2_Y3.Text);

                Center_Point = CenterRotation(new RobotPoint() { X = Point2_X1.D, Y = Point2_Y1.D }, new RobotPoint() { X = Point2_X2.D, Y = Point2_Y2.D },

                                                       new RobotPoint() { X = Point2_X3.D, Y = Point2_Y3.D });

                textBox_Cam1_Center2_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam1_Center2_Y.Text = Center_Point.Y.ToString("0.00000");
                SaveData();
                AppParam.Instance.Save_To_File();
                Log.WriteRunLog("相机1 自动标定完成");
            }
            else if (CamIndex == 2)
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[3].Value.ToString());
                    Y[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[4].Value.ToString());
                    Column[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString());
                    Row[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam2_HomMat2d);
                textBox_Cam2_Point1_X1.Text = dataGridView_Cam2.Rows[4].Cells[1].Value.ToString();
                textBox_Cam2_Point1_Y1.Text = dataGridView_Cam2.Rows[4].Cells[2].Value.ToString();
                textBox_Cam2_Point1_X2.Text = dataGridView_Cam2.Rows[9].Cells[1].Value.ToString();
                textBox_Cam2_Point1_Y2.Text = dataGridView_Cam2.Rows[9].Cells[2].Value.ToString();
                textBox_Cam2_Point1_X3.Text = dataGridView_Cam2.Rows[10].Cells[1].Value.ToString();
                textBox_Cam2_Point1_Y3.Text = dataGridView_Cam2.Rows[10].Cells[2].Value.ToString();
                HTuple Point1_X1 = double.Parse(textBox_Cam2_Point1_X1.Text);
                HTuple Point1_Y1 = double.Parse(textBox_Cam2_Point1_Y1.Text);
                HTuple Point1_X2 = double.Parse(textBox_Cam2_Point1_X2.Text);
                HTuple Point1_Y2 = double.Parse(textBox_Cam2_Point1_Y2.Text);
                HTuple Point1_X3 = double.Parse(textBox_Cam2_Point1_X3.Text);
                HTuple Point1_Y3 = double.Parse(textBox_Cam2_Point1_Y3.Text);
                RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },

                                                        new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });
                textBox_Cam2_Center1_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam2_Center1_Y.Text = Center_Point.Y.ToString("0.00000");
                textBox_Cam2_Point2_X1.Text = dataGridView_Cam2.Rows[11].Cells[1].Value.ToString();
                textBox_Cam2_Point2_Y1.Text = dataGridView_Cam2.Rows[11].Cells[2].Value.ToString();
                textBox_Cam2_Point2_X2.Text = dataGridView_Cam2.Rows[12].Cells[1].Value.ToString();
                textBox_Cam2_Point2_Y2.Text = dataGridView_Cam2.Rows[12].Cells[2].Value.ToString();
                textBox_Cam2_Point2_X3.Text = dataGridView_Cam2.Rows[13].Cells[1].Value.ToString();
                textBox_Cam2_Point2_Y3.Text = dataGridView_Cam2.Rows[13].Cells[2].Value.ToString();
                HTuple Point2_X1 = double.Parse(textBox_Cam2_Point2_X1.Text);
                HTuple Point2_Y1 = double.Parse(textBox_Cam2_Point2_Y1.Text);
                HTuple Point2_X2 = double.Parse(textBox_Cam2_Point2_X2.Text);
                HTuple Point2_Y2 = double.Parse(textBox_Cam2_Point2_Y2.Text);
                HTuple Point2_X3 = double.Parse(textBox_Cam2_Point2_X3.Text);
                HTuple Point2_Y3 = double.Parse(textBox_Cam2_Point2_Y3.Text);

                Center_Point = CenterRotation(new RobotPoint() { X = Point2_X1.D, Y = Point2_Y1.D }, new RobotPoint() { X = Point2_X2.D, Y = Point2_Y2.D },

                                                       new RobotPoint() { X = Point2_X3.D, Y = Point2_Y3.D });

                textBox_Cam2_Center2_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam2_Center2_Y.Text = Center_Point.Y.ToString("0.00000");
                SaveData();
                AppParam.Instance.Save_To_File();

                Log.WriteRunLog("相机2 自动标定完成");
            }
            else if (true)
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[3].Value.ToString());
                    Y[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[4].Value.ToString());
                    Column[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString());
                    Row[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam3_HomMat2d);
                textBox_Cam3_Point1_X1.Text = dataGridView_Cam3.Rows[4].Cells[1].Value.ToString();
                textBox_Cam3_Point1_Y1.Text = dataGridView_Cam3.Rows[4].Cells[2].Value.ToString();
                textBox_Cam3_Point1_X2.Text = dataGridView_Cam3.Rows[9].Cells[1].Value.ToString();
                textBox_Cam3_Point1_Y2.Text = dataGridView_Cam3.Rows[9].Cells[2].Value.ToString();
                textBox_Cam3_Point1_X3.Text = dataGridView_Cam3.Rows[10].Cells[1].Value.ToString();
                textBox_Cam3_Point1_Y3.Text = dataGridView_Cam3.Rows[10].Cells[2].Value.ToString();
                HTuple Point1_X1 = double.Parse(textBox_Cam3_Point1_X1.Text);
                HTuple Point1_Y1 = double.Parse(textBox_Cam3_Point1_Y1.Text);
                HTuple Point1_X2 = double.Parse(textBox_Cam3_Point1_X2.Text);
                HTuple Point1_Y2 = double.Parse(textBox_Cam3_Point1_Y2.Text);
                HTuple Point1_X3 = double.Parse(textBox_Cam3_Point1_X3.Text);
                HTuple Point1_Y3 = double.Parse(textBox_Cam3_Point1_Y3.Text);
                RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },

                                                        new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });
                textBox_Cam3_Center1_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam3_Center1_Y.Text = Center_Point.Y.ToString("0.00000");
                textBox_Cam3_Point2_X1.Text = dataGridView_Cam3.Rows[11].Cells[1].Value.ToString();
                textBox_Cam3_Point2_Y1.Text = dataGridView_Cam3.Rows[11].Cells[2].Value.ToString();
                textBox_Cam3_Point2_X2.Text = dataGridView_Cam3.Rows[12].Cells[1].Value.ToString();
                textBox_Cam3_Point2_Y2.Text = dataGridView_Cam3.Rows[12].Cells[2].Value.ToString();
                textBox_Cam3_Point2_X3.Text = dataGridView_Cam3.Rows[13].Cells[1].Value.ToString();
                textBox_Cam3_Point2_Y3.Text = dataGridView_Cam3.Rows[13].Cells[2].Value.ToString();
                HTuple Point2_X1 = double.Parse(textBox_Cam3_Point2_X1.Text);
                HTuple Point2_Y1 = double.Parse(textBox_Cam3_Point2_Y1.Text);
                HTuple Point2_X2 = double.Parse(textBox_Cam3_Point2_X2.Text);
                HTuple Point2_Y2 = double.Parse(textBox_Cam3_Point2_Y2.Text);
                HTuple Point2_X3 = double.Parse(textBox_Cam3_Point2_X3.Text);
                HTuple Point2_Y3 = double.Parse(textBox_Cam3_Point2_Y3.Text);

                Center_Point = CenterRotation(new RobotPoint() { X = Point2_X1.D, Y = Point2_Y1.D }, new RobotPoint() { X = Point2_X2.D, Y = Point2_Y2.D },

                                                       new RobotPoint() { X = Point2_X3.D, Y = Point2_Y3.D });

                textBox_Cam3_Center2_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam3_Center2_Y.Text = Center_Point.Y.ToString("0.00000");
                SaveData();
                AppParam.Instance.Save_To_File();
                Log.WriteRunLog("相机3 自动标定完成");
            }
        }

        /// <summary>
        /// 相机1 9点标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button9_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cam1.Rows.Count <= 8)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            try
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[3].Value.ToString());
                    Y[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[4].Value.ToString());
                    Column[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[2].Value.ToString());
                    Row[i] = Convert.ToDouble(dataGridView_Cam1.Rows[i].Cells[1].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam1_HomMat2d);
                AppParam.Instance.Save_To_File();
                ShowNormal("标定成功");
            }
            catch (Exception)
            {
                ShowError("标定失败");
            }
        }

        /// <summary>
        /// 相机2  9点标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button8_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cam2.Rows.Count <= 8)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            try
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[3].Value.ToString());
                    Y[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[4].Value.ToString());
                    Column[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[2].Value.ToString());
                    Row[i] = Convert.ToDouble(dataGridView_Cam2.Rows[i].Cells[1].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam2_HomMat2d);
                AppParam.Instance.Save_To_File();
                ShowNormal("标定成功");
            }
            catch (Exception)
            {
                ShowError("标定失败");
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cam3.Rows.Count <= 8)
            {
                ShowWarn("数据不够,无法标定");
                return;
            }
            try
            {
                HTuple Row = new HTuple();
                HTuple Column = new HTuple();
                HTuple X = new HTuple();
                HTuple Y = new HTuple();
                for (int i = 0; i < 9; i++)
                {
                    X[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[3].Value.ToString());
                    Y[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[4].Value.ToString());
                    Column[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[2].Value.ToString());
                    Row[i] = Convert.ToDouble(dataGridView_Cam3.Rows[i].Cells[1].Value.ToString());
                }
                HOperatorSet.VectorToHomMat2d(Row, Column, X, Y, out CalibrationData.Instance.Cam3_HomMat2d);
                AppParam.Instance.Save_To_File();
                ShowNormal("标定成功");
            }
            catch (Exception)
            {
                ShowError("标定失败");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox_Cam1_Point1_X1.Text = dataGridView_Cam1.Rows[4].Cells[1].Value.ToString();
            textBox_Cam1_Point1_Y1.Text = dataGridView_Cam1.Rows[4].Cells[2].Value.ToString();
            textBox_Cam1_Point1_X2.Text = dataGridView_Cam1.Rows[9].Cells[1].Value.ToString();
            textBox_Cam1_Point1_Y2.Text = dataGridView_Cam1.Rows[9].Cells[2].Value.ToString();
            textBox_Cam1_Point1_X3.Text = dataGridView_Cam1.Rows[10].Cells[1].Value.ToString();
            textBox_Cam1_Point1_Y3.Text = dataGridView_Cam1.Rows[10].Cells[2].Value.ToString();
            HTuple Point1_X1 = double.Parse(textBox_Cam1_Point1_X1.Text);
            HTuple Point1_Y1 = double.Parse(textBox_Cam1_Point1_Y1.Text);
            HTuple Point1_X2 = double.Parse(textBox_Cam1_Point1_X2.Text);
            HTuple Point1_Y2 = double.Parse(textBox_Cam1_Point1_Y2.Text);
            HTuple Point1_X3 = double.Parse(textBox_Cam1_Point1_X3.Text);
            HTuple Point1_Y3 = double.Parse(textBox_Cam1_Point1_Y3.Text);

            RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D },
                                                    new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },
                                                    new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });

            if (Center_Point.X != 9999)
            {
                textBox_Cam1_Center1_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam1_Center1_Y.Text = Center_Point.Y.ToString("0.00000");
                ShowNormal("标定成功");
            }
            else
            {
                ShowWarn("标定失败");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox_Cam1_Point2_X1.Text = dataGridView_Cam1.Rows[11].Cells[1].Value.ToString();
            textBox_Cam1_Point2_Y1.Text = dataGridView_Cam1.Rows[11].Cells[2].Value.ToString();
            textBox_Cam1_Point2_X2.Text = dataGridView_Cam1.Rows[12].Cells[1].Value.ToString();
            textBox_Cam1_Point2_Y2.Text = dataGridView_Cam1.Rows[12].Cells[2].Value.ToString();
            textBox_Cam1_Point2_X3.Text = dataGridView_Cam1.Rows[13].Cells[1].Value.ToString();
            textBox_Cam1_Point2_Y3.Text = dataGridView_Cam1.Rows[13].Cells[2].Value.ToString();
            HTuple Point2_X1 = double.Parse(textBox_Cam1_Point2_X1.Text);
            HTuple Point2_Y1 = double.Parse(textBox_Cam1_Point2_Y1.Text);
            HTuple Point2_X2 = double.Parse(textBox_Cam1_Point2_X2.Text);
            HTuple Point2_Y2 = double.Parse(textBox_Cam1_Point2_Y2.Text);
            HTuple Point2_X3 = double.Parse(textBox_Cam1_Point2_X3.Text);
            HTuple Point2_Y3 = double.Parse(textBox_Cam1_Point2_Y3.Text);

            RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point2_X1.D, Y = Point2_Y1.D }, new RobotPoint() { X = Point2_X2.D, Y = Point2_Y2.D },

                                                    new RobotPoint() { X = Point2_X3.D, Y = Point2_Y3.D });

            if (Center_Point.X != 9999)
            {
                textBox_Cam1_Center2_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam1_Center2_Y.Text = Center_Point.Y.ToString("0.00000");
                ShowNormal("标定成功");
            }
            else
            {
                ShowWarn("标定失败");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox_Cam2_Point1_X1.Text = dataGridView_Cam2.Rows[4].Cells[1].Value.ToString();
            textBox_Cam2_Point1_Y1.Text = dataGridView_Cam2.Rows[4].Cells[2].Value.ToString();
            textBox_Cam2_Point1_X2.Text = dataGridView_Cam2.Rows[9].Cells[1].Value.ToString();
            textBox_Cam2_Point1_Y2.Text = dataGridView_Cam2.Rows[9].Cells[2].Value.ToString();
            textBox_Cam2_Point1_X3.Text = dataGridView_Cam2.Rows[10].Cells[1].Value.ToString();
            textBox_Cam2_Point1_Y3.Text = dataGridView_Cam2.Rows[10].Cells[2].Value.ToString();

            HTuple Point1_X1 = double.Parse(textBox_Cam2_Point1_X1.Text);
            HTuple Point1_Y1 = double.Parse(textBox_Cam2_Point1_Y1.Text);
            HTuple Point1_X2 = double.Parse(textBox_Cam2_Point1_X2.Text);
            HTuple Point1_Y2 = double.Parse(textBox_Cam2_Point1_Y2.Text);
            HTuple Point1_X3 = double.Parse(textBox_Cam2_Point1_X3.Text);
            HTuple Point1_Y3 = double.Parse(textBox_Cam2_Point1_Y3.Text);

            RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },

                                                    new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });

            if (Center_Point.X != 9999)
            {
                textBox_Cam2_Center1_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam2_Center1_Y.Text = Center_Point.Y.ToString("0.00000");
                ShowNormal("标定成功");
            }
            else
            {
                ShowWarn("标定失败");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox_Cam2_Point2_X1.Text = dataGridView_Cam2.Rows[11].Cells[1].Value.ToString();
            textBox_Cam2_Point2_Y1.Text = dataGridView_Cam2.Rows[11].Cells[2].Value.ToString();
            textBox_Cam2_Point2_X2.Text = dataGridView_Cam2.Rows[12].Cells[1].Value.ToString();
            textBox_Cam2_Point2_Y2.Text = dataGridView_Cam2.Rows[12].Cells[2].Value.ToString();
            textBox_Cam2_Point2_X3.Text = dataGridView_Cam2.Rows[13].Cells[1].Value.ToString();
            textBox_Cam2_Point2_Y3.Text = dataGridView_Cam2.Rows[13].Cells[2].Value.ToString();
            HTuple Point1_X1 = double.Parse(textBox_Cam2_Point2_X1.Text);
            HTuple Point1_Y1 = double.Parse(textBox_Cam2_Point2_Y1.Text);
            HTuple Point1_X2 = double.Parse(textBox_Cam2_Point2_X2.Text);
            HTuple Point1_Y2 = double.Parse(textBox_Cam2_Point2_Y2.Text);
            HTuple Point1_X3 = double.Parse(textBox_Cam2_Point2_X3.Text);
            HTuple Point1_Y3 = double.Parse(textBox_Cam2_Point2_Y3.Text);

            RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },

                                                    new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });

            if (Center_Point.X != 9999)
            {
                textBox_Cam2_Center2_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam2_Center2_Y.Text = Center_Point.Y.ToString("0.00000");
                ShowNormal("标定成功");
            }
            else
            {
                ShowWarn("标定失败");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox_Cam3_Point1_X1.Text = dataGridView_Cam3.Rows[4].Cells[1].Value.ToString();
            textBox_Cam3_Point1_Y1.Text = dataGridView_Cam3.Rows[4].Cells[2].Value.ToString();
            textBox_Cam3_Point1_X2.Text = dataGridView_Cam3.Rows[9].Cells[1].Value.ToString();
            textBox_Cam3_Point1_Y2.Text = dataGridView_Cam3.Rows[9].Cells[2].Value.ToString();
            textBox_Cam3_Point1_X3.Text = dataGridView_Cam3.Rows[10].Cells[1].Value.ToString();
            textBox_Cam3_Point1_Y3.Text = dataGridView_Cam3.Rows[10].Cells[2].Value.ToString();
            HTuple Point1_X1 = double.Parse(textBox_Cam3_Point1_X1.Text);
            HTuple Point1_Y1 = double.Parse(textBox_Cam3_Point1_Y1.Text);
            HTuple Point1_X2 = double.Parse(textBox_Cam3_Point1_X2.Text);
            HTuple Point1_Y2 = double.Parse(textBox_Cam3_Point1_Y2.Text);
            HTuple Point1_X3 = double.Parse(textBox_Cam3_Point1_X3.Text);
            HTuple Point1_Y3 = double.Parse(textBox_Cam3_Point1_Y3.Text);

            RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },

                                                    new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });

            if (Center_Point.X != 9999)
            {
                textBox_Cam3_Center1_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam3_Center1_Y.Text = Center_Point.Y.ToString("0.00000");
                ShowNormal("标定成功");
            }
            else
            {
                ShowWarn("标定失败");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox_Cam3_Point2_X1.Text = dataGridView_Cam3.Rows[11].Cells[1].Value.ToString();
            textBox_Cam3_Point2_Y1.Text = dataGridView_Cam3.Rows[11].Cells[2].Value.ToString();
            textBox_Cam3_Point2_X2.Text = dataGridView_Cam3.Rows[12].Cells[1].Value.ToString();
            textBox_Cam3_Point2_Y2.Text = dataGridView_Cam3.Rows[12].Cells[2].Value.ToString();
            textBox_Cam3_Point2_X3.Text = dataGridView_Cam3.Rows[13].Cells[1].Value.ToString();
            textBox_Cam3_Point2_Y3.Text = dataGridView_Cam3.Rows[13].Cells[2].Value.ToString();

            HTuple Point1_X1 = double.Parse(textBox_Cam3_Point2_X1.Text);
            HTuple Point1_Y1 = double.Parse(textBox_Cam3_Point2_Y1.Text);
            HTuple Point1_X2 = double.Parse(textBox_Cam3_Point2_X2.Text);
            HTuple Point1_Y2 = double.Parse(textBox_Cam3_Point2_Y2.Text);
            HTuple Point1_X3 = double.Parse(textBox_Cam3_Point2_X3.Text);
            HTuple Point1_Y3 = double.Parse(textBox_Cam3_Point2_Y3.Text);

            RobotPoint Center_Point = CenterRotation(new RobotPoint() { X = Point1_X1.D, Y = Point1_Y1.D }, new RobotPoint() { X = Point1_X2.D, Y = Point1_Y2.D },

                                                    new RobotPoint() { X = Point1_X3.D, Y = Point1_Y3.D });

            if (Center_Point.X != 9999)
            {
                textBox_Cam3_Center2_X.Text = Center_Point.X.ToString("0.00000");
                textBox_Cam3_Center2_Y.Text = Center_Point.Y.ToString("0.00000");
                ShowNormal("标定成功");
            }
            else
            {
                ShowWarn("标定失败");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppParam.Instance.Robot_Calibration_State = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveData();
            AppParam.Instance.Save_To_File();
            ShowNormal("保存成功");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle1 rectangle1 = halconWindow1.Draw_Rectangle1("blue");
                HObject ho_ImageReduced;
                HOperatorSet.GenEmptyObj(out ho_ImageReduced);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(halconWindow1.Image, rectangle1.rectangle1, out ho_ImageReduced);
                HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out CalibrationData.Instance.Cam1_hv_ModelID);
                // HOperatorSet.CreateNccModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "use_polarity",        out CalibrationData.Instance.Cam1_hv_ModelID);
                ShowNormal("创建成功");
            }
            catch (Exception)
            {
                ShowError("创建失败");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle1 rectangle1 = halconWindow1.Draw_Rectangle1("blue");
                HObject ho_ImageReduced;
                HOperatorSet.GenEmptyObj(out ho_ImageReduced);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(halconWindow1.Image, rectangle1.rectangle1, out ho_ImageReduced);
                HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out CalibrationData.Instance.Cam3_hv_ModelID);
                ShowNormal("创建成功");
            }
            catch (Exception)
            {
                ShowError("创建失败");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle1 rectangle1 = halconWindow1.Draw_Rectangle1("blue");
                HObject ho_ImageReduced;
                HOperatorSet.GenEmptyObj(out ho_ImageReduced);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(halconWindow1.Image, rectangle1.rectangle1, out ho_ImageReduced);
                HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out CalibrationData.Instance.Cam2_hv_ModelID);
                ShowNormal("创建成功");
            }
            catch (Exception)
            {
                ShowError("创建失败");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void Form_Robot_Calibration_Activated(object sender, EventArgs e)
        {
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new Form_Angle_Calibration().ShowDialog();
        }
    }
}