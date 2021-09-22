using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYProject.Plugin;
using HYProject.ToolForm;
using HalconDotNet;

namespace HYProject.Model
{
    public class Cam2_Work
    {
        public static void Cam2_Work_Method(HalconDotNet.HObject ho_image)
        {
            bool result = true;
            double X = 0.000;
            double Y = 0.000;
            double U = 0.000;
            if (Work.Cam2_Calibration_Mode)
            {
                Cam2_Calibration(ho_image);
                return;
            }

            //1号吸嘴定位
            if (Work.Cam2_Suction_Nozzle_Number == 1)
            {
                DisplayForm.Instance[1].Disp_Image(ho_image);
                DisplayForm.Instance[1].Disp_Message("相机2 1号吸嘴", 16, 10, 10, "blue");



                HTuple Row;
                HTuple Column;
                HTuple Angle;


                result = Work.Test(DisplayForm.Instance[1], ho_image, "Cam2", 1, out Row, out Column, out Angle);



                if (result)
                {
                    Log.WriteRunLog("定位成功：[" + Row.D.ToString("0.00000") + "," + Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");

                    HTuple Robot_x;
                    HTuple Robot_y;

                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d, Row, Column, out Robot_x, out Robot_y);


                    //角度需要在计算

                    double AbsAngle = Math.Abs(Angle.D);

                    RobotPoint RotateAnglePoint = Work.RotateAngle(CalibrationData.Instance.Cam2_Rotate_Center1_Point, 90 - AbsAngle, new RobotPoint() { X = Row.D, Y = Column.D });


                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d, new HTuple(RotateAnglePoint.X), new HTuple(RotateAnglePoint.Y), out Robot_x, out Robot_y);


                    X = Robot_x.D;
                    Y = Robot_y.D;
                    U = 90 - AbsAngle;
                    Log.WriteRunLog("Robot定位成功：[" + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000") + "]");
                }
                else
                {
                    Log.WriteErrorLog("定位失败：[" + Row.D.ToString("0.00000") + "," + Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                }









                AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&OBG,1,1," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                Work.SaveImage("相机2", "1号吸嘴", result, DisplayForm.Instance[1]);
                if (result)
                {
                    Cam2_OK1 = 1;
                }
                else
                {
                    Cam2_NG1 = 1;
                }
            }
            //2号吸嘴定位
            else if (Work.Cam2_Suction_Nozzle_Number == 2)
            {
                DisplayForm.Instance[4].Disp_Image(ho_image);
                DisplayForm.Instance[4].Disp_Message("相机2 2号吸嘴", 16, 10, 10, "blue");


                HTuple Row;
                HTuple Column;
                HTuple Angle;


                result = Work.Test(DisplayForm.Instance[4], ho_image, "Cam2", 2, out Row, out Column, out Angle);




                if (result)
                {
                    Log.WriteRunLog("定位成功：[" + Row.D.ToString("0.00000") + "," + Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");

                    HTuple Robot_x;
                    HTuple Robot_y;

                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d, Row, Column, out Robot_x, out Robot_y);


                    //角度需要在计算

                    double AbsAngle = Math.Abs(Angle.D);

                    RobotPoint RotateAnglePoint = Work.RotateAngle(CalibrationData.Instance.Cam2_Rotate_Center2_Point, 90 - AbsAngle, new RobotPoint() { X = Row.D, Y = Column.D });


                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam2_HomMat2d, new HTuple(RotateAnglePoint.X), new HTuple(RotateAnglePoint.Y), out Robot_x, out Robot_y);


                    X = Robot_x.D;
                    Y = Robot_y.D;
                    U = 90 - AbsAngle;
                    Log.WriteRunLog("Robot定位成功：[" + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000") + "]");
                }
                else
                {
                    Log.WriteErrorLog("定位失败：[" + Row.D.ToString("0.00000") + "," + Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                }













                AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&OBG,1,2," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                Work.SaveImage("相机2", "2号吸嘴", result, DisplayForm.Instance[4]);
                if (result)
                {
                    Cam2_OK2 = 1;
                }
                else
                {
                    Cam2_NG2 = 1;
                }
            }
            AppParam.Instance.lightSource.StateCH2 = false;

        }
        private static void Cam2_Calibration(HalconDotNet.HObject ho_image)
        {
            try
            {


                if (Work.Cam2_Calibration_Mode)
                {
                    Form_Robot_Calibration.Instance.Window.Disp_Image(ho_image);
                    if (Work.Cam2_Suction_Nozzle_Number == 1)
                    {
                        //9点标定+ 1号吸嘴旋转标定
                        if (Work.Cam2_Calibration_Index == 0)
                        {
                            Form_Robot_Calibration.Instance.ClearData(2);
                        }
                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam2_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam2_minScore1, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");
                            Work.DispModelXLD(CalibrationData.Instance.Cam2_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, Angle, "blue");
                            Form_Robot_Calibration.Instance.AddData(2, Column.D, Row.D, Work.Cam2_X1, Work.Cam2_Y1);
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,1");

                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 1");
                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,0");
                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 0");
                        }
                        if (Work.Cam2_Calibration_Index == 10)
                        {
                            //Work.Cam2_Calibration_Mode = false;
                            Work.Cam2_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机2 9点标定+1号吸嘴旋转标定结束");
                        }
                    }
                    else if (Work.Cam2_Suction_Nozzle_Number == 2)
                    {
                        //2号吸嘴旋转标定

                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam2_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam2_minScore2, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");

                            Work.DispModelXLD(CalibrationData.Instance.Cam2_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, Angle, "blue");
                            Form_Robot_Calibration.Instance.AddData(2, Column.D, Row.D, Work.Cam3_X1, Work.Cam3_Y1);
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,1");
                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 1");

                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,0");

                            Log.WriteRunLog("相机2 回复指令 ： & CAE, 0");
                        }
                        if (Work.Cam2_Calibration_Index == 10)
                        {
                            Work.Cam2_Calibration_Mode = false;
                            Work.Cam2_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机2 2号吸嘴旋转标定结束");
                            Form_Robot_Calibration.Instance.Auto(2);
                        }
                    }

                }
            }
            catch (Exception)
            {
                AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,0");
            }
            AppParam.Instance.lightSource.StateCH2 = false;

        }

        public static int Cam2_OK1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_OK1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_OK1.Text);
                MainForm.Instance.label_Cam2_OK1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL1.Text = (Cam2_OK1 + Cam2_NG1).ToString();
            }
        }
        public static int Cam2_NG1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_NG1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_NG1.Text);
                MainForm.Instance.label_Cam2_NG1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL1.Text = (Cam2_OK1 + Cam2_NG1).ToString();
            }
        }


        public static int Cam2_OK2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_OK2.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_OK2.Text);
                MainForm.Instance.label_Cam2_OK2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL2.Text = (Cam2_OK2 + Cam2_NG2).ToString();
            }
        }

        public static int Cam2_NG2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam2_NG2.Text);
            }

            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam2_NG2.Text);
                MainForm.Instance.label_Cam2_NG2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam2_TOTAL2.Text = (Cam2_OK2 + Cam2_NG2).ToString();
            }
        }
    }
}
