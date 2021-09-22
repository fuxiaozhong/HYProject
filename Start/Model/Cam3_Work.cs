using System;

using HalconDotNet;

using HYProject.Plugin;
using HYProject.ToolForm;

namespace HYProject.Model

{
    public class Cam3_Work
    {
        public static void Cam3_Work_Method(HalconDotNet.HObject ho_image)
        {
            bool result = true;
            double X = 0.000;
            double Y = 0.000;
            double U = 0.000;
            if (Work.Cam3_Calibration_Mode)
            {
                Cam3_Calibration(ho_image);
                return;
            }

            //1号吸嘴定位
            if (Work.Cam3_Suction_Nozzle_Number == 1)
            {
                DisplayForm.Instance[2].Disp_Image(ho_image);
                DisplayForm.Instance[2].Disp_Message("相机3 1号吸嘴", 16, 10, 10, "green");

                HTuple Center_Row = new HTuple(0.00);
                HTuple Center_Column = new HTuple(0.00);
                HTuple Angle = new HTuple(0.00);

                result = Work.Test(DisplayForm.Instance[2], ho_image, "Cam3", 1, out Center_Row, out Center_Column, out Angle);

                if (result)
                {
                    #region 旧计算方式

                    ////已知  放料位 XYR
                    ////已知  物料位定位(row column)
                    ////已知  旋转中心点 (row column)
                    ////已知  物料角度(angle)            √
                    ////已知  旋转后的点 XY(row column)  √
                    ////已知  相机中心 XY   --映射-->   refPos(x,y,u)

                    ////绕点公式 x0= (x - rx0)* cos(a) - (y - ry0)*sin(a) + rx0 ;
                    ////         y0= (x - rx0)* sin(a) + (y - ry0)*cos(a) + ry0 ;

                    ////重新吸取一个新的物料，拍照得到当前物料特征中心坐标值以及角度：curPos(x, y, u)
                    ////x=curPos_x;  y=curPos_y;

                    ////rx0 = Ox2; ry0 = Oy2;

                    ////a = curPos_u - refPos_u;

                    ////offsetx = x0 - refPos_x，
                    ////旋转后的点x - 相机中心x
                    ////offsety = y0 - refPos_y
                    ////旋转后的点y - 相机中心y
                    ////r = curPos_u - refPos_u;
                    ////r = 得到的角度 - 放料的角度

                    ////最后发送给机器人或者执行机构的偏移值为：x0 - refPos_x，y0 - refPos_y，a

                    //double 补偿U = Angle.D - CalibrationData.Instance.Cam3_1_Angle ;

                    ////定位绕点旋转   像素坐标
                    //RobotPoint 旋转后的点_Pix = Work.RotateAngle(
                    //    CalibrationData.Instance.Cam3_Rotate_Center1_Point,
                    //    补偿U,
                    //    new RobotPoint() { X = Center_Row.D, Y = Center_Column.D });

                    //HTuple 旋转后的Robot_x = new HTuple(0.0);
                    //HTuple 旋转后的Robot_y = new HTuple(0.0);

                    ////机械坐标了
                    //HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d,
                    //                                new HTuple(旋转后的点_Pix.X), new HTuple(旋转后的点_Pix.Y),
                    //                                out 旋转后的Robot_x, out 旋转后的Robot_y);

                    //// xy补偿
                    //double offsetX = 旋转后的Robot_x - Work.Cam3_X1;
                    //double offsetY = 旋转后的Robot_y - Work.Cam3_Y1;

                    //X = CalibrationData.Instance.Cam3_Standard1_Point.X - offsetX;
                    //Y = CalibrationData.Instance.Cam3_Standard1_Point.Y + offsetY;
                    //U = CalibrationData.Instance.Cam3_Standard1_Point.U +补偿U;

                    #endregion 旧计算方式

                    //得到角度差单位是rad弧度，相机是下向上拍照和旋转方向的方向相反，所以乘 - 1.
                    double CmpAngleDeg = (Angle.TupleDeg().D - CalibrationData.Instance.Cam3_1_Standard_Angle) * (-1);
                    //hom_mat2d_identity(HomMat2DRotate)

                    HTuple HomMat2DRotate;
                    HOperatorSet.HomMat2dIdentity(out HomMat2DRotate);
                    HOperatorSet.HomMat2dRotate(HomMat2DRotate, new HTuple(CmpAngleDeg),
                       new HTuple(CalibrationData.Instance.Cam3_Rotate_Center1_Point.X),
                        new HTuple(CalibrationData.Instance.Cam3_Rotate_Center1_Point.Y), out HomMat2DRotate);

                    HTuple 旋转后的Row;
                    HTuple 旋转后的Column;

                    HTuple RobotX;
                    HTuple RobotY;

                    HOperatorSet.AffineTransPoint2d(HomMat2DRotate, Center_Row, Center_Column, out 旋转后的Row, out 旋转后的Column);
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d, 旋转后的Row, 旋转后的Column, out RobotX, out RobotY);

                    double MoveX = RobotX.D - Work.Cam1_X1;
                    double MoveY = RobotY.D - Work.Cam1_Y1;
                    double MoveAngle = CmpAngleDeg;

                    //需实际观察
                    X = CalibrationData.Instance.Cam1_Standard1_Point.X + MoveX;
                    Y = CalibrationData.Instance.Cam1_Standard1_Point.Y + MoveY;
                    U = CalibrationData.Instance.Cam1_Standard1_Point.U + MoveAngle;

                    Log.WriteRunLog("Cam3-1 Robot定位成功：[" + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000") + "]");
                    DisplayForm.Instance[2].Disp_Message("X:" + X.ToString("0.00000") + "\nY:" + Y.ToString("0.00000") + "\nR:" + U.ToString("0.00000"), 16, 1000, 10, result ? "green" : "red");
                }
                else
                {
                    Log.WriteErrorLog("Cam3-1 定位失败：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                }
                AppParam.Instance.TCPSocketServer_Cam3.SendMessage("&OBG,1,1," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                Work.SaveImage("相机3", "1号吸嘴", result, DisplayForm.Instance[2]);
                if (result)
                {
                    Cam3_OK1 = 1;
                }
                else
                {
                    Cam3_NG1 = 1;
                }
            }
            //2号吸嘴定位
            else if (Work.Cam3_Suction_Nozzle_Number == 2)
            {
                DisplayForm.Instance[5].Disp_Image(ho_image);
                DisplayForm.Instance[5].Disp_Message("相机3 2号吸嘴", 16, 10, 10, "green");

                HTuple Center_Row = new HTuple(0.00);
                HTuple Center_Column = new HTuple(0.00);
                HTuple Angle = new HTuple(0.00);

                result = Work.Test(DisplayForm.Instance[5], ho_image, "Cam3", 2, out Center_Row, out Center_Column, out Angle);

                if (result)
                {
                    Log.WriteRunLog("Cam3-2 Pix定位成功：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                    double 补偿U = Angle.D - CalibrationData.Instance.Cam3_2_Standard_Angle;

                    //定位绕点旋转   像素坐标
                    RobotPoint 旋转后的点_Pix = Work.RotateAngle(
                        CalibrationData.Instance.Cam3_Rotate_Center2_Point,
                        补偿U,
                        new RobotPoint() { X = Center_Row.D, Y = Center_Column.D });

                    HTuple 旋转后的Robot_x = new HTuple(0.0);
                    HTuple 旋转后的Robot_y = new HTuple(0.0);

                    //机械坐标了
                    HOperatorSet.AffineTransPoint2d(CalibrationData.Instance.Cam3_HomMat2d,
                                                    new HTuple(旋转后的点_Pix.X), new HTuple(旋转后的点_Pix.Y),
                                                    out 旋转后的Robot_x, out 旋转后的Robot_y);

                    double camoffsetX = Work.Cam3_X2 - Work.Cam3_X1;
                    double camoffsetY = Work.Cam3_Y2 - Work.Cam3_Y1;

                    旋转后的Robot_x += camoffsetX;
                    旋转后的Robot_y += camoffsetY;

                    // xy补偿
                    double offsetX = 旋转后的Robot_x - Work.Cam3_X2;
                    double offsetY = 旋转后的Robot_y - Work.Cam3_Y2;

                    X = CalibrationData.Instance.Cam3_Standard2_Point.X - offsetX;
                    Y = CalibrationData.Instance.Cam3_Standard2_Point.Y + offsetY;
                    U = CalibrationData.Instance.Cam3_Standard2_Point.U + 补偿U;

                    Log.WriteRunLog("Cam3-2 Robot定位成功：[" + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000") + "]");
                    DisplayForm.Instance[5].Disp_Message("X:" + X.ToString("0.00000") + "\nY:" + Y.ToString("0.00000") + "\nR:" + U.ToString("0.00000"), 16, 1000, 10, result ? "green" : "red");
                }
                else
                {
                    Log.WriteErrorLog("Cam3-2 定位失败：[" + Center_Row.D.ToString("0.00000") + "," + Center_Column.D.ToString("0.00000") + "," + Angle.D.ToString("0.00000") + "]");
                }

                AppParam.Instance.TCPSocketServer_Cam3.SendMessage("&OBG,1,2," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                Log.WriteRunLog("Cam3-2 发送指令：&OBG,1,2," + (result ? "1" : "0") + "," + X.ToString("0.00000") + "," + Y.ToString("0.00000") + "," + U.ToString("0.00000"));
                Work.SaveImage("相机3", "2号吸嘴", result, DisplayForm.Instance[5]);
                if (result)
                {
                    Cam3_OK2 = 1;
                }
                else
                {
                    Cam3_NG2 = 1;
                }
            }
            AppParam.Instance.lightSource.StateCH3 = false;
        }

        private static void Cam3_Calibration(HalconDotNet.HObject ho_image)
        {
            try
            {
                if (Work.Cam3_Calibration_Mode)
                {
                    Form_Robot_Calibration.Instance.Window.Disp_Image(ho_image);
                    if (Work.Cam3_Suction_Nozzle_Number == 1)
                    {
                        //9点标定+ 1号吸嘴旋转标定

                        if (Work.Cam3_Calibration_Index == 0)
                        {
                            Form_Robot_Calibration.Instance.ClearData(3);
                        }

                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam3_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam3_minScore1, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");
                            Work.DispModelXLD(CalibrationData.Instance.Cam3_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, Angle, "blue");
                            Form_Robot_Calibration.Instance.AddData(3, Column.D, Row.D, Work.Cam3_X1, Work.Cam3_Y1);
                            AppParam.Instance.TCPSocketServer_Cam3.SendMessage("&CAE,1");
                            Log.WriteRunLog("相机3 回复指令 ： & CAE, 1");
                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam3.SendMessage("&CAE,0");
                            Log.WriteRunLog("相机3 回复指令 ： & CAE, 0");
                        }
                        if (Work.Cam3_Calibration_Index == 10)
                        {
                            //Work.Cam3_Calibration_Mode = false;
                            Work.Cam3_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机3 9点标定+1号吸嘴旋转标定结束");
                        }
                    }
                    else if (Work.Cam3_Suction_Nozzle_Number == 2)
                    {
                        //2号吸嘴旋转标定

                        //像素位置
                        HTuple Row = 0.0, Column = 0.0, Angle = 0.0;
                        //第4点是1号吸嘴旋转第二点
                        //9是旋转中心第一点
                        //10是旋转中心第三点
                        HOperatorSet.FindShapeModel(ho_image, CalibrationData.Instance.Cam3_hv_ModelID, new HTuple(-180).TupleRad(), new HTuple(360).TupleRad(), CalibrationData.Instance.Cam3_minScore2, 1, 0.5, "least_squares", 0, 0.7, out Row, out Column, out Angle, out _);
                        if (Row > 0)
                        {
                            Form_Robot_Calibration.Instance.Window.Disp_Message("Row:" + Row.D + "\nColumn:" + Column.D + "\nAngle:" + Angle.TupleDeg().D, 16, 10, 10, "blue");
                            Work.DispModelXLD(CalibrationData.Instance.Cam3_hv_ModelID, Row, Column, Angle);
                            Form_Robot_Calibration.Instance.Window.Disp_Cross(Row, Column, 200, Angle, "blue");
                            Form_Robot_Calibration.Instance.AddData(3, Column.D, Row.D, Work.Cam3_X1, Work.Cam3_Y1);
                            AppParam.Instance.TCPSocketServer_Cam3.SendMessage("&CAE,1");
                            Log.WriteRunLog("相机3 回复指令 ： & CAE, 1");
                        }
                        else
                        {
                            AppParam.Instance.TCPSocketServer_Cam3.SendMessage("&CAE,0");
                            Log.WriteRunLog("相机3 回复指令 ： & CAE, 1");
                        }

                        if (Work.Cam3_Calibration_Index == 10)
                        {
                            Work.Cam3_Calibration_Mode = false;
                            Work.Cam3_Suction_Nozzle_Number = -1;
                            Log.WriteRunLog("相机3 2号吸嘴旋转标定结束");
                            Form_Robot_Calibration.Instance.Auto(3);
                        }
                    }
                }
            }
            catch (Exception)
            {
                AppParam.Instance.TCPSocketServer_Cam3.SendMessage("&CAE,0");
            }
            AppParam.Instance.lightSource.StateCH3 = false;
        }

        public static int Cam3_OK1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam3_OK1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam3_OK1.Text);
                MainForm.Instance.label_Cam3_OK1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam3_TOTAL1.Text = (Cam3_OK1 + Cam3_NG1).ToString();
            }
        }

        public static int Cam3_NG1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam3_NG1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam3_NG1.Text);
                MainForm.Instance.label_Cam3_NG1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam3_TOTAL1.Text = (Cam3_OK1 + Cam3_NG1).ToString();
            }
        }

        public static int Cam3_OK2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam3_OK2.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam3_OK2.Text);
                MainForm.Instance.label_Cam3_OK2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam3_TOTAL2.Text = (Cam3_OK2 + Cam3_NG2).ToString();
            }
        }

        public static int Cam3_NG2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam3_NG2.Text);
            }

            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam3_NG2.Text);
                MainForm.Instance.label_Cam3_NG2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam3_TOTAL2.Text = (Cam3_OK2 + Cam3_NG2).ToString();
            }
        }
    }
}