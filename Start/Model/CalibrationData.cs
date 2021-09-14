using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalconDotNet;

namespace HYProject.Model
{
    [Serializable]
    public class CalibrationData
    {

        /// <summary>
        /// 相机1 9点标定仿射矩阵
        /// </summary>
        internal HTuple Cam1_HomMat2d;
        /// <summary>
        /// 相机2 9点标定仿射矩阵
        /// </summary>
        internal HTuple Cam2_HomMat2d;
        /// <summary>
        /// 相机3 9点标定仿射矩阵
        /// </summary>
        internal HTuple Cam3_HomMat2d;


        internal RobotPoint Cam1_Rotate1_Point1 = new RobotPoint();
        internal RobotPoint Cam1_Rotate1_Point2 = new RobotPoint();
        internal RobotPoint Cam1_Rotate1_Point3 = new RobotPoint();
        internal RobotPoint Cam1_Rotate2_Point1 = new RobotPoint();
        internal RobotPoint Cam1_Rotate2_Point2 = new RobotPoint();
        internal RobotPoint Cam1_Rotate2_Point3 = new RobotPoint();
        internal RobotPoint Cam1_Rotate_Center1_Point = new RobotPoint();
        internal RobotPoint Cam1_Rotate_Center2_Point = new RobotPoint();
        internal RobotPoint Cam1_Standard1_Point = new RobotPoint();
        internal RobotPoint Cam1_Standard2_Point = new RobotPoint();
        internal List<RobotPoint> Cam1_Robot_Location = new List<RobotPoint>();
        internal List<RobotPoint> Cam1_Pixel_Location = new List<RobotPoint>();

        internal RobotPoint Cam2_Rotate1_Point1 = new RobotPoint();
        internal RobotPoint Cam2_Rotate1_Point2 = new RobotPoint();
        internal RobotPoint Cam2_Rotate1_Point3 = new RobotPoint();
        internal RobotPoint Cam2_Rotate2_Point1 = new RobotPoint();
        internal RobotPoint Cam2_Rotate2_Point2 = new RobotPoint();
        internal RobotPoint Cam2_Rotate2_Point3 = new RobotPoint();
        internal RobotPoint Cam2_Rotate_Center1_Point = new RobotPoint();
        internal RobotPoint Cam2_Rotate_Center2_Point = new RobotPoint();
        internal RobotPoint Cam2_Standard1_Point = new RobotPoint();
        internal RobotPoint Cam2_Standard2_Point = new RobotPoint();
        internal List<RobotPoint> Cam2_Robot_Location = new List<RobotPoint>();
        internal List<RobotPoint> Cam2_Pixel_Location = new List<RobotPoint>();



        internal RobotPoint Cam3_Rotate1_Point1 = new RobotPoint();
        internal RobotPoint Cam3_Rotate1_Point2 = new RobotPoint();
        internal RobotPoint Cam3_Rotate1_Point3 = new RobotPoint();
        internal RobotPoint Cam3_Rotate2_Point1 = new RobotPoint();
        internal RobotPoint Cam3_Rotate2_Point2 = new RobotPoint();
        internal RobotPoint Cam3_Rotate2_Point3 = new RobotPoint();
        internal RobotPoint Cam3_Rotate_Center1_Point = new RobotPoint();
        internal RobotPoint Cam3_Rotate_Center2_Point = new RobotPoint();
        internal RobotPoint Cam3_Standard1_Point = new RobotPoint();
        internal RobotPoint Cam3_Standard2_Point = new RobotPoint();
        internal List<RobotPoint> Cam3_Robot_Location = new List<RobotPoint>();
        internal List<RobotPoint> Cam3_Pixel_Location = new List<RobotPoint>();





    }
}
