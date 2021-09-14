using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Threading.Tasks;

using HYProject.Helper;
using HYProject.ToolForm;
using NPOI.OpenXmlFormats.Vml;
using ToolKit.DisplayWindow;

namespace HYProject.Model
{
    public class Cam1_Work : Work
    {
        public static void Cam1_Work_Method(HalconDotNet.HObject ho_image)
        {
            if (Work.Cam1_Calibration_Mode)
            {
                Cam1_Calibration(ho_image);
                return;
            }



            //1号吸嘴定位
            if (Work.Cam1_Suction_Nozzle_Number == 1)
            {


                SaveImage("相机1", "1号吸嘴", true, DisplayForm.Instance[0]);
            }
            //2号吸嘴定位
            else if (Work.Cam1_Suction_Nozzle_Number == 2)
            {


                SaveImage("相机1", "2号吸嘴", true, DisplayForm.Instance[3]);
            }



        }
        private static void Cam1_Calibration(HalconDotNet.HObject ho_image)
        {
            if (Work.Cam1_Calibration_Mode)
            {
                if (Work.Cam1_Suction_Nozzle_Number == 1)
                {
                    //9点标定+ 1号吸嘴旋转标定
                    if (Work.Cam1_Calibration_Index == 4)//步骤变换
                    {

                    }





                    if (Work.Cam1_Calibration_Index == 10)
                    {
                        Work.Cam1_Calibration_Mode = false;
                        Work.Cam1_Suction_Nozzle_Number = -1;
                        Log.WriteRunLog("相机1 9点标定+1号吸嘴旋转标定结束");
                    }
                    AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&CAE,1");
                }
                else if (Work.Cam1_Suction_Nozzle_Number == 2)
                {
                    //2号吸嘴旋转标定







                    if (Work.Cam1_Calibration_Index == 10)
                    {
                        Work.Cam1_Calibration_Mode = false;
                        Work.Cam1_Suction_Nozzle_Number = -1;
                        Log.WriteRunLog("相机1 2号吸嘴旋转标定结束");
                    }
                    AppParam.Instance.TCPSocketServer_Cam1.SendMessage("&CAE,1");
                }

            }
        }













        public static int Cam1_OK1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_OK1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_OK1.Text);
                MainForm.Instance.label_Cam1_OK1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL1.Text = (Cam1_OK1 + Cam1_NG1).ToString();
            }
        }
        public static int Cam1_NG1
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_NG1.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_NG1.Text);
                MainForm.Instance.label_Cam1_NG1.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL1.Text = (Cam1_OK1 + Cam1_NG1).ToString();
            }
        }


        public static int Cam1_OK2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_OK2.Text);
            }
            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_OK2.Text);
                MainForm.Instance.label_Cam1_OK2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL2.Text = (Cam1_OK2 + Cam1_NG2).ToString();
            }
        }

        public static int Cam1_NG2
        {
            get
            {
                return int.Parse(MainForm.Instance.label_Cam1_NG2.Text);
            }

            set
            {
                int count = int.Parse(MainForm.Instance.label_Cam1_NG2.Text);
                MainForm.Instance.label_Cam1_NG2.Text = (count += 1).ToString();
                MainForm.Instance.label_Cam1_TOTAL2.Text = (Cam1_OK2 + Cam1_NG2).ToString();
            }
        }
    }
}
