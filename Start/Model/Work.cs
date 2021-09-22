using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using HalconDotNet;

using HYProject.Helper;
using HYProject.Plugin;
using HYProject.ToolForm;

using ToolKit.DisplayWindow;
using ToolKit.HalconTool;
using ToolKit.HalconTool.Model;

namespace HYProject.Model
{


    public class Work
    {
        /// <summary>
        /// 相机正常工作方法(数据处理)
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="ho_image">图像</param>
        public static void CameraWork(string cameraName, HalconDotNet.HObject ho_image)
        {
            switch (cameraName)
            {
                case "Cam1":
                    //DisplayForm.Instance[0].Disp_Image(ho_image);
                    Cam1_Work.Cam1_Work_Method(ho_image);
                    break;

                case "Cam2":
                    //DisplayForm.Instance[1].Disp_Image(ho_image);
                    Cam2_Work.Cam2_Work_Method(ho_image);
                    break;

                case "Cam3":
                    //DisplayForm.Instance[2].Disp_Image(ho_image);
                    Cam3_Work.Cam3_Work_Method(ho_image);
                    break;
            }
            //QueueSaveImage.Instance.QueueEnqueue2(ho_image);
        }






        public static bool Cam1_Calibration_Mode = false;
        public static int Cam1_Calibration_Index;
        public static int Cam1_Suction_Nozzle_Number;
        public static double Cam1_X1;
        public static double Cam1_Y1;
        public static double Cam1_U1;

        public static double Cam1_X2;
        public static double Cam1_Y2;
        public static double Cam1_U2;
        public static void TCPSocketServer_SocketReceiveMessage1(System.Net.Sockets.Socket client, string clientSocketIp, string message)
        {
            AppParam.Instance.lightSource.StateCH1 = true;
            Log.WriteRunLog("相机1 - 接收:" + message);

            //吸嘴旋转标定

            //九点标定 + 旋转标定
            if (message.StartsWith("&TAR"))
            {

                Form_Robot_Calibration.Instance.Disp_order(message);
                if (!Cam1_Calibration_Mode)
                {

                    Cam1_Calibration_Mode = true;
                    Log.WriteRunLog("相机1 进入标定模式");


                }
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam1_Calibration_Index = int.Parse(messageSplit[1]);
                Cam1_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                Cam1_X1 = double.Parse(messageSplit[3]);
                Cam1_Y1 = double.Parse(messageSplit[4]);
                Cam1_U1 = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam1"].Soft_Trigger();

            }
            //正常生产
            else if (message.StartsWith("&OBG"))
            {
                Cam1_Calibration_Mode = false;
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam1_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                if (Cam1_Suction_Nozzle_Number == 1)
                {
                    Cam1_X1 = double.Parse(messageSplit[3]);
                    Cam1_Y1 = double.Parse(messageSplit[4]);
                    Cam1_U1 = double.Parse(messageSplit[5]);
                }
                else
                {
                    Cam1_X2 = double.Parse(messageSplit[3]);
                    Cam1_Y2 = double.Parse(messageSplit[4]);
                    Cam1_U2 = double.Parse(messageSplit[5]);
                }



                Cameras.Instance["Cam1"].Soft_Trigger();
            }
            //动静态GRR    
            else if (message.StartsWith("&OBG1"))
            {

            }
        }



        public static bool Cam2_Calibration_Mode = false;
        public static int Cam2_Calibration_Index;
        public static int Cam2_Suction_Nozzle_Number;
        public static double Cam2_X1;
        public static double Cam2_Y1;
        public static double Cam2_U1;
        public static double Cam2_X2;
        public static double Cam2_Y2;
        public static double Cam2_U2;
        internal static void TCPSocketServer_SocketReceiveMessage2(Socket client, string clientSocketIp, string message)
        {
            AppParam.Instance.lightSource.StateCH2 = true;
            Log.WriteRunLog("相机2 - 接收:" + message);
            //九点标定 + 旋转标定
            if (message.StartsWith("&TAR"))
            {

                Form_Robot_Calibration.Instance.Disp_order(message);
                if (!Cam2_Calibration_Mode)
                {
                    Cam2_Calibration_Mode = true;
                    Log.WriteRunLog("相机2 进入标定模式");

                }
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam2_Calibration_Index = int.Parse(messageSplit[1]);
                Cam2_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                Cam2_X1 = double.Parse(messageSplit[3]);
                Cam2_Y1 = double.Parse(messageSplit[4]);
                Cam2_U1 = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam2"].Soft_Trigger();

            }
            //正常生产
            else if (message.StartsWith("&OBG"))
            {
                Cam2_Calibration_Mode = false;
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam2_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                if (Cam2_Suction_Nozzle_Number == 1)
                {
                    Cam2_X1 = double.Parse(messageSplit[3]);
                    Cam2_Y1 = double.Parse(messageSplit[4]);
                    Cam2_U1 = double.Parse(messageSplit[5]);
                }
                else
                {
                    Cam2_X2 = double.Parse(messageSplit[3]);
                    Cam2_Y2 = double.Parse(messageSplit[4]);
                    Cam2_U2 = double.Parse(messageSplit[5]);
                }


                Cameras.Instance["Cam2"].Soft_Trigger();
            }
            //动静态GRR    
            else if (message.StartsWith("&OBG1"))
            {

            }
        }

        public static bool Cam3_Calibration_Mode = false;
        public static int Cam3_Calibration_Index;
        public static int Cam3_Suction_Nozzle_Number;
        public static double Cam3_X1;
        public static double Cam3_Y1;
        public static double Cam3_U1;

        public static double Cam3_X2;
        public static double Cam3_Y2;
        public static double Cam3_U2;
        internal static void TCPSocketServer_SocketReceiveMessage3(Socket client, string clientSocketIp, string message)
        {
            AppParam.Instance.lightSource.StateCH3 = true;
            Log.WriteRunLog("相机3 - 接收:" + message);
            //九点标定 + 旋转标定
            if (message.StartsWith("&TAR"))
            {

                Form_Robot_Calibration.Instance.Disp_order(message);
                if (!Cam3_Calibration_Mode)
                {
                    Cam3_Calibration_Mode = true;
                    Log.WriteRunLog("相机3 进入标定模式");
                }
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam3_Calibration_Index = int.Parse(messageSplit[1]);
                Cam3_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                Cam3_X1 = double.Parse(messageSplit[3]);
                Cam3_Y1 = double.Parse(messageSplit[4]);
                Cam3_U1 = double.Parse(messageSplit[5]);

                Cameras.Instance["Cam3"].Soft_Trigger();

            }
            //正常生产
            else if (message.StartsWith("&OBG"))
            {
                Cam3_Calibration_Mode = false;
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam3_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                if (Cam3_Suction_Nozzle_Number == 1)
                {
                    Cam3_X1 = double.Parse(messageSplit[3]);
                    Cam3_Y1 = double.Parse(messageSplit[4]);
                    Cam3_U1 = double.Parse(messageSplit[5]);
                }
                else
                {
                    Cam3_X2 = double.Parse(messageSplit[3]);
                    Cam3_Y2 = double.Parse(messageSplit[4]);
                    Cam3_U2 = double.Parse(messageSplit[5]);
                }

                Cameras.Instance["Cam3"].Soft_Trigger();
            }
            //动静态GRR    
            else if (message.StartsWith("&OBG1"))
            {

            }
        }



        public static string RotateAngle(double XRotation, double YRotation, double ARotate, double XBefore, double YBefore, ref double XAfter, ref double YAfter)
        {
            try
            {
                double Rad = 0;
                Rad = ARotate * Math.Acos(-1) / 180;
                XAfter = (XBefore - XRotation) * Math.Cos(Rad) - (YBefore - YRotation) * Math.Sin(Rad) + XRotation;
                YAfter = (YBefore - YRotation) * Math.Cos(Rad) + (XBefore - XRotation) * Math.Sin(Rad) + YRotation;
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        /// <summary>
        /// 绕点旋转
        /// </summary>
        /// <param name="centerPoint">中心店</param>
        /// <param name="ARotate">角度</param>
        /// <param name="BeforePoint">要旋转的点</param>
        /// <returns>旋转后的点</returns>
        public static RobotPoint RotateAngle(RobotPoint centerPoint, double ARotate, RobotPoint BeforePoint)
        {

            RobotPoint AfterBoint = new RobotPoint();
            try
            {
                double Rad = 0;
                Rad = ARotate * Math.Acos(-1) / 180;
                AfterBoint.X = (BeforePoint.X - centerPoint.X) * Math.Cos(Rad) - (BeforePoint.Y - centerPoint.X) * Math.Sin(Rad) + centerPoint.X;
                AfterBoint.Y = (BeforePoint.Y - centerPoint.Y) * Math.Cos(Rad) + (BeforePoint.X - centerPoint.Y) * Math.Sin(Rad) + centerPoint.Y;

            }
            catch (Exception)
            {
                AfterBoint.X = 999999;
                AfterBoint.Y = 999999;
            }

            return AfterBoint;
        }







        public static void DispModelXLD(HTuple Model, HTuple Row, HTuple Column, HTuple Angle)
        {
            HObject ModelXLD;
            HOperatorSet.GetShapeModelContours(out ModelXLD, Model, 1);
            HTuple VectorAngleToRigidModel;
            HOperatorSet.VectorAngleToRigid(0, 0, 0, Row, Column, Angle, out VectorAngleToRigidModel);
            HOperatorSet.AffineTransContourXld(ModelXLD, out ModelXLD, VectorAngleToRigidModel);
            Form_Robot_Calibration.Instance.Window.Disp_Region(ModelXLD, "green", "margin");
        }



        public static void Find_Left_Up_Point(HalconWindow halconWindow, string CamName, int NozzleIndex, HObject image, out HTuple row, out HTuple column)
        {

            HObject ho_ImageReduced, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            HTuple hv_UsedThreshold = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), Length1 = new HTuple();
            HTuple length2 = new HTuple(), angle = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);

            if (CamName == "Cam1")
            {
                if (NozzleIndex == 1)
                {
                    HOperatorSet.ReduceDomain(image, AppParam.Instance.product.Cam1_Image1_Standard_Rectangle1, out ho_ImageReduced);
                    halconWindow.Disp_Region(AppParam.Instance.product.Cam1_Image1_Standard_Rectangle1,"blue","margin");
                }
                else
                {
                    halconWindow.Disp_Region(AppParam.Instance.product.Cam1_Image2_Standard_Rectangle1,"blue","margin");
                    HOperatorSet.ReduceDomain(image, AppParam.Instance.product.Cam1_Image2_Standard_Rectangle1, out ho_ImageReduced);
                }
            }
            else if (CamName == "Cam2")
            {
                if (NozzleIndex == 1)
                {
                    halconWindow.Disp_Region(AppParam.Instance.product.Cam2_Image1_Standard_Rectangle1, "blue", "margin");

                    HOperatorSet.ReduceDomain(image, AppParam.Instance.product.Cam2_Image1_Standard_Rectangle1, out ho_ImageReduced);
                }
                else
                {
                    halconWindow.Disp_Region(AppParam.Instance.product.Cam2_Image2_Standard_Rectangle1, "blue", "margin");

                    HOperatorSet.ReduceDomain(image, AppParam.Instance.product.Cam2_Image2_Standard_Rectangle1, out ho_ImageReduced);
                }
            }
            else if (CamName == "Cam3")
            {
                if (NozzleIndex == 1)
                {
                    halconWindow.Disp_Region(AppParam.Instance.product.Cam3_Image1_Standard_Rectangle1, "blue", "margin");

                    HOperatorSet.ReduceDomain(image, AppParam.Instance.product.Cam3_Image1_Standard_Rectangle1, out ho_ImageReduced);
                }
                else
                {
                    halconWindow.Disp_Region(AppParam.Instance.product.Cam3_Image2_Standard_Rectangle1, "blue", "margin");

                    HOperatorSet.ReduceDomain(image, AppParam.Instance.product.Cam3_Image2_Standard_Rectangle1, out ho_ImageReduced);
                }
            }
            ho_Region.Dispose(); hv_UsedThreshold.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region, "max_separability", "dark", out hv_UsedThreshold);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningRectangle1(ho_Region, out ho_RegionOpening, 50, 50);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShapeStd(ho_ConnectedRegions, out ho_SelectedRegions, "max_area", 70);
            hv_Row1.Dispose(); hv_Column1.Dispose(); Length1.Dispose(); length2.Dispose();
            HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out row, out column, out angle, out Length1, out length2);
            if (NozzleIndex == 1)
            {
                row = row + length2;
                column = column - Length1;
            }
            else
            {
                row = row + length2;
                column = column + Length1;
            }
           
            halconWindow.Disp_Cross(row, column, 200, 0, "blue");
            ho_ImageReduced.Dispose();
            ho_Region.Dispose();
            ho_RegionOpening.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_SelectedRegions.Dispose();

        }



        public static bool Test(HalconWindow halconWindow, HObject image, string CamName, int NozzleIndex, out HTuple Row, out HTuple Column, out HTuple Angle)
        {
            Row = new HTuple(0.0);
            Column = new HTuple(0.0);
            Angle = new HTuple(0.0);
            try
            {


                HObject CopyImage;
                HOperatorSet.GenEmptyObj(out CopyImage);
                HTuple Top = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Left = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Button = new HTuple(0.0, 0.0, 0.0, 0.0);
                HTuple Right = new HTuple(0.0, 0.0, 0.0, 0.0);

                HTuple rr = new HTuple(0.00);
                HTuple cc = new HTuple(0.00);



                if (CamName == "Cam1")
                {
                    if (NozzleIndex == 1)
                    {
                        Work.Find_Left_Up_Point(halconWindow, CamName, NozzleIndex, image, out rr, out cc);
                        HTuple startRow = new HTuple(0);
                        HTuple startColumn = new HTuple(0);
                        HTuple endRow = new HTuple(0);
                        HTuple endColumn = new HTuple(0);

                        HTuple homMet_2d;

                        HOperatorSet.HomMat2dIdentity(out homMet_2d);
                        HOperatorSet.HomMat2dTranslate(homMet_2d, rr.D - AppParam.Instance.product.Cam1_Image1_Standard_Row.D, cc.D - AppParam.Instance.product.Cam1_Image1_Standard_Column.D, out homMet_2d);

                        MeasureParam TopmeasureParam = (MeasureParam)AppParam.Instance.product.Cam1_Left1.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[0], TopmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[2], TopmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        TopmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HOperatorSet.CopyImage(image, out CopyImage);
                        HalconUtils.CaliperMeasure(halconWindow, TopmeasureParam, CopyImage, out _, out Top);


                        MeasureParam BottonmeasureParam = (MeasureParam)AppParam.Instance.product.Cam1_Right1.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[0], BottonmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[2], BottonmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        BottonmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HalconUtils.CaliperMeasure(halconWindow, BottonmeasureParam, CopyImage, out _, out Button);

                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam1_Top1, CopyImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam1_Button1, CopyImage, out _, out Right);
                    }
                    else
                    {
                        Work.Find_Left_Up_Point(halconWindow, CamName, NozzleIndex, image, out rr, out cc);
                        HTuple startRow = new HTuple(0);
                        HTuple startColumn = new HTuple(0);
                        HTuple endRow = new HTuple(0);
                        HTuple endColumn = new HTuple(0);

                        HTuple homMet_2d;

                        HOperatorSet.HomMat2dIdentity(out homMet_2d);
                        HOperatorSet.HomMat2dTranslate(homMet_2d, rr.D - AppParam.Instance.product.Cam1_Image2_Standard_Row.D, cc.D - AppParam.Instance.product.Cam1_Image2_Standard_Column.D, out homMet_2d);

                        MeasureParam TopmeasureParam = (MeasureParam)AppParam.Instance.product.Cam1_Left2.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[0], TopmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[2], TopmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        TopmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HOperatorSet.CopyImage(image, out CopyImage);
                        HalconUtils.CaliperMeasure(halconWindow, TopmeasureParam, CopyImage, out _, out Top);


                        MeasureParam BottonmeasureParam = (MeasureParam)AppParam.Instance.product.Cam1_Right1.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[0], BottonmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[2], BottonmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        BottonmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HalconUtils.CaliperMeasure(halconWindow, BottonmeasureParam, CopyImage, out _, out Button);


                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam1_Top1, CopyImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam1_Button2, CopyImage, out _, out Right);
                    }
                }
                else if (CamName == "Cam2")
                {
                    if (NozzleIndex == 1)
                    {
                        Work.Find_Left_Up_Point(halconWindow, CamName, NozzleIndex, image, out rr, out cc);
                        HTuple startRow = new HTuple(0);
                        HTuple startColumn = new HTuple(0);
                        HTuple endRow = new HTuple(0);
                        HTuple endColumn = new HTuple(0);

                        HTuple homMet_2d;

                        HOperatorSet.HomMat2dIdentity(out homMet_2d);
                        HOperatorSet.HomMat2dTranslate(homMet_2d, rr.D - AppParam.Instance.product.Cam2_Image1_Standard_Row.D, cc.D - AppParam.Instance.product.Cam2_Image1_Standard_Column.D, out homMet_2d);

                        MeasureParam TopmeasureParam = (MeasureParam)AppParam.Instance.product.Cam2_Left1.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[0], TopmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[2], TopmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        TopmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HOperatorSet.CopyImage(image, out CopyImage);
                        HalconUtils.CaliperMeasure(halconWindow, TopmeasureParam, CopyImage, out _, out Top);


                        MeasureParam BottonmeasureParam = (MeasureParam)AppParam.Instance.product.Cam2_Right1.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[0], BottonmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[2], BottonmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        BottonmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HalconUtils.CaliperMeasure(halconWindow, BottonmeasureParam, CopyImage, out _, out Button);

                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam2_Top1, CopyImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam2_Button1, CopyImage, out _, out Right);
                    }
                    else
                    {
                        Work.Find_Left_Up_Point(halconWindow, CamName, NozzleIndex, image, out rr, out cc);
                        HTuple startRow = new HTuple(0);
                        HTuple startColumn = new HTuple(0);
                        HTuple endRow = new HTuple(0);
                        HTuple endColumn = new HTuple(0);

                        HTuple homMet_2d;

                        HOperatorSet.HomMat2dIdentity(out homMet_2d);
                        HOperatorSet.HomMat2dTranslate(homMet_2d, rr.D - AppParam.Instance.product.Cam2_Image2_Standard_Row.D, cc.D - AppParam.Instance.product.Cam2_Image2_Standard_Column.D, out homMet_2d);

                        MeasureParam TopmeasureParam = (MeasureParam)AppParam.Instance.product.Cam2_Left2.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[0], TopmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[2], TopmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        TopmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HOperatorSet.CopyImage(image, out CopyImage);
                        HalconUtils.CaliperMeasure(halconWindow, TopmeasureParam, CopyImage, out _, out Top);


                        MeasureParam BottonmeasureParam = (MeasureParam)AppParam.Instance.product.Cam2_Right2.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[0], BottonmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[2], BottonmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        BottonmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HalconUtils.CaliperMeasure(halconWindow, BottonmeasureParam, CopyImage, out _, out Button);


                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam2_Top2, CopyImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam2_Button2, CopyImage, out _, out Right);
                    }
                }
                else if (CamName == "Cam3")
                {
                    if (NozzleIndex == 1)
                    {
                        Work.Find_Left_Up_Point(halconWindow, CamName, NozzleIndex, image, out rr, out cc);
                        HTuple startRow = new HTuple(0);
                        HTuple startColumn = new HTuple(0);
                        HTuple endRow = new HTuple(0);
                        HTuple endColumn = new HTuple(0);

                        HTuple homMet_2d;

                        HOperatorSet.HomMat2dIdentity(out homMet_2d);
                        HOperatorSet.HomMat2dTranslate(homMet_2d, rr.D - AppParam.Instance.product.Cam3_Image1_Standard_Row.D, cc.D - AppParam.Instance.product.Cam3_Image1_Standard_Column.D, out homMet_2d);

                        MeasureParam TopmeasureParam = (MeasureParam)AppParam.Instance.product.Cam3_Left1.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[0], TopmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[2], TopmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        TopmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HOperatorSet.CopyImage(image, out CopyImage);
                        HalconUtils.CaliperMeasure(halconWindow, TopmeasureParam, CopyImage, out _, out Top);


                        MeasureParam BottonmeasureParam = (MeasureParam)AppParam.Instance.product.Cam3_Right1.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[0], BottonmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[2], BottonmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        BottonmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HalconUtils.CaliperMeasure(halconWindow, BottonmeasureParam, CopyImage, out _, out Button);

                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam3_Top1, CopyImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam3_Button1, CopyImage, out _, out Right);
                    }
                    else
                    {


                        Work.Find_Left_Up_Point(halconWindow, CamName, NozzleIndex, image, out rr, out cc);
                        HTuple startRow = new HTuple(0);
                        HTuple startColumn = new HTuple(0);
                        HTuple endRow = new HTuple(0);
                        HTuple endColumn = new HTuple(0);
                        HTuple homMet_2d;

                        //  HOperatorSet.VectorToRigid(AppParam.Instance.product.Cam3_Image2_Standard_Row, AppParam.Instance.product.Cam3_Image2_Standard_Column, rr, cc, out homMet_2d);

                        HOperatorSet.HomMat2dIdentity(out homMet_2d);
                        HOperatorSet.HomMat2dTranslate(homMet_2d, rr.D - AppParam.Instance.product.Cam3_Image2_Standard_Row.D, cc.D - AppParam.Instance.product.Cam3_Image2_Standard_Column.D, out homMet_2d);


                        MeasureParam TopmeasureParam = (MeasureParam)AppParam.Instance.product.Cam3_Left2.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[0], TopmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, TopmeasureParam.InputShapeParam[2], TopmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        TopmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HOperatorSet.CopyImage(image, out CopyImage);
                        HalconUtils.CaliperMeasure(halconWindow, TopmeasureParam, CopyImage, out _, out Top);


                        MeasureParam BottonmeasureParam = (MeasureParam)AppParam.Instance.product.Cam3_Right2.Colne();
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[0], BottonmeasureParam.InputShapeParam[1], out startRow, out startColumn);
                        HOperatorSet.AffineTransPoint2d(homMet_2d, BottonmeasureParam.InputShapeParam[2], BottonmeasureParam.InputShapeParam[3], out endRow, out endColumn);
                        BottonmeasureParam.InputShapeParam = new HTuple(startRow, startColumn, endRow, endColumn);

                        HalconUtils.CaliperMeasure(halconWindow, BottonmeasureParam, CopyImage, out _, out Button);


                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam3_Top2, CopyImage, out _, out Left);
                        HalconUtils.CaliperMeasure(halconWindow, AppParam.Instance.product.Cam3_Button2, CopyImage, out _, out Right);
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
                // HOperatorSet.DispArrow(halconWindow.HalconWindowHandle, LeftDownRow, LeftDownColumn, LeftUpRow, LeftUpColumn,20);
                HObject arrow;
                gen_arrow_contour_xld(out arrow, LeftDownRow, LeftDownColumn, LeftUpRow, LeftUpColumn, 20, 30);

                halconWindow.Disp_Region(Line1, "green", "margin");
                halconWindow.Disp_Region(arrow, "blue", "margin");
                halconWindow.Disp_Region(Line2, "green", "margin");
                halconWindow.Disp_Cross(LeftUpRow, LeftUpColumn, 200, Phi, "green");
                halconWindow.Disp_Cross(LeftDownRow, LeftDownColumn, 200, Phi, "green");
                halconWindow.Disp_Cross(RightUpRow, RightUpColumn, 200, Phi, "green");
                halconWindow.Disp_Cross(RightDownRow, RightDownColumn, 200, Phi, "green");
                halconWindow.Disp_Cross(CenterRow, CenterColumn, 200, Phi, "green");
                halconWindow.Disp_Message("Row:" + CenterRow.D + "\nColumn:" + CenterColumn + "\nAngle:" + Phi.TupleDeg().D, 16, 300, 10, "green");



                Row = CenterRow;
                Column = CenterColumn;
                Angle = Phi.TupleDeg();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public static void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
      HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {



            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_TempArrow = null;

            // Local control variables 

            HTuple hv_Length = new HTuple(), hv_ZeroLengthIndices = new HTuple();
            HTuple hv_DR = new HTuple(), hv_DC = new HTuple(), hv_HalfHeadWidth = new HTuple();
            HTuple hv_RowP1 = new HTuple(), hv_ColP1 = new HTuple();
            HTuple hv_RowP2 = new HTuple(), hv_ColP2 = new HTuple();
            HTuple hv_Index = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);
            //This procedure generates arrow shaped XLD contours,
            //pointing from (Row1, Column1) to (Row2, Column2).
            //If starting and end point are identical, a contour consisting
            //of a single point is returned.
            //
            //input parameteres:
            //Row1, Column1: Coordinates of the arrows' starting points
            //Row2, Column2: Coordinates of the arrows' end points
            //HeadLength, HeadWidth: Size of the arrow heads in pixels
            //
            //output parameter:
            //Arrow: The resulting XLD contour
            //
            //The input tuples Row1, Column1, Row2, and Column2 have to be of
            //the same length.
            //HeadLength and HeadWidth either have to be of the same length as
            //Row1, Column1, Row2, and Column2 or have to be a single element.
            //If one of the above restrictions is violated, an error will occur.
            //
            //
            //Init
            ho_Arrow.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            //
            //Calculate the arrow length
            hv_Length.Dispose();
            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
            //
            //Mark arrows with identical start and end point
            //(set Length to -1 to avoid division-by-zero exception)
            hv_ZeroLengthIndices.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ZeroLengthIndices = hv_Length.TupleFind(
                    0);
            }
            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
            {
                if (hv_Length == null)
                    hv_Length = new HTuple();
                hv_Length[hv_ZeroLengthIndices] = -1;
            }
            //
            //Calculate auxiliary variables.
            hv_DR.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
            }
            hv_DC.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
            }
            hv_HalfHeadWidth.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_HalfHeadWidth = hv_HeadWidth / 2.0;
            }
            //
            //Calculate end points of the arrow head.
            hv_RowP1.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
            }
            hv_ColP1.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
            }
            hv_RowP2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
            }
            hv_ColP2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
            }
            //
            //Finally create output XLD contour for each input point pair
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                {
                    //Create_ single points for arrows with identical start and end point
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(hv_Index),
                            hv_Column1.TupleSelect(hv_Index));
                    }
                }
                else
                {
                    //Create arrow contour
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                            hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                            ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                            hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                    }
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
                    ho_Arrow.Dispose();
                    ho_Arrow = ExpTmpOutVar_0;
                }
            }
            ho_TempArrow.Dispose();

            hv_Length.Dispose();
            hv_ZeroLengthIndices.Dispose();
            hv_DR.Dispose();
            hv_DC.Dispose();
            hv_HalfHeadWidth.Dispose();
            hv_RowP1.Dispose();
            hv_ColP1.Dispose();
            hv_RowP2.Dispose();
            hv_ColP2.Dispose();
            hv_Index.Dispose();

            return;
        }
































































































































        public static void SaveImage(string Cam, string Suction_nozzle_number, bool result, HalconWindow halconWindow)
        {
            if (AppParam.Instance.IsSaveImage)
            {
                if (result)
                {//OK
                    if (AppParam.Instance.IsSaveImage_BmpImage)
                    {//原图
                        if (AppParam.Instance.IsSaveImage_OK)
                            if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\OK"))
                            {
                                Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\OK");
                            }
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\OK\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = halconWindow.Image });
                    }
                }
                if (AppParam.Instance.IsSaveImage_DumpImage)
                {//截图
                    if (AppParam.Instance.IsSaveImage_OK)
                    {
                        if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\OK"))
                        {
                            Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\OK");
                        }
                        HalconDotNet.HObject dump_image;
                        HOperatorSet.GenEmptyObj(out dump_image);
                        dump_image.Dispose();
                        HOperatorSet.DumpWindowImage(out dump_image, halconWindow.HalconWindowHandle);
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\OK\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = dump_image.Clone() });
                        dump_image.Dispose();
                    }
                }
            }
            else
            {//NG
                if (AppParam.Instance.IsSaveImage_BmpImage)
                {//原图
                    if (AppParam.Instance.IsSaveImage_NG)
                    {


                        if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\NG"))
                        {
                            Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\NG");
                        }
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\NG\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = halconWindow.Image });
                    }
                }
                if (AppParam.Instance.IsSaveImage_DumpImage)
                {//截图
                    if (AppParam.Instance.IsSaveImage_NG)
                    {
                        if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\NG"))
                        {
                            Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\NG");
                        }
                        HalconDotNet.HObject dump_image;
                        HOperatorSet.GenEmptyObj(out dump_image);
                        dump_image.Dispose();
                        HOperatorSet.DumpWindowImage(out dump_image, halconWindow.HalconWindowHandle);
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\NG\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = dump_image.Clone() });
                        dump_image.Dispose();
                    }
                }
            }
        }








        internal static void TCPSocketServer_ClientsConnect1(Socket clients)
        {

            Log.WriteRunLog("相机1 客户端: " + clients.RemoteEndPoint.ToString() + "进入");

        }
        internal static void TCPSocketServer_ClientsConnect2(Socket clients)
        {

            Log.WriteRunLog("相机2 客户端: " + clients.RemoteEndPoint.ToString() + "进入");

        }
        public static void TCPSocketServer_ClientsConnect3(Socket clients)
        {

            Log.WriteRunLog("相机3 客户端: " + clients.RemoteEndPoint.ToString() + "进入");

        }

        internal static void TCPSocketServer_ClientsLoss2(Socket clients)
        {

            Log.WriteRunLog("相机2 客户端: " + clients.RemoteEndPoint.ToString() + " 掉线");

        }

        internal static void TCPSocketServer_ClientsLoss3(Socket clients)
        {

            Log.WriteRunLog("相机3 客户端: " + clients.RemoteEndPoint.ToString() + " 掉线");

        }

        internal static void TCPSocketServer_ClientsLoss1(Socket clients)
        {

            Log.WriteRunLog("相机1 客户端: " + clients.RemoteEndPoint.ToString() + " 掉线");

        }
    }
}