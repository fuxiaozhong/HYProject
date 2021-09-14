using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HYProject.ToolForm;

namespace HYProject.Model
{
    public class Cam2_Work : Work
    {
        public static void Cam2_Work_Method(HalconDotNet.HObject ho_image)
        {
            if (Work.Cam2_Calibration_Mode)
            {
                Cam2_Calibration(ho_image);
                return;
            }

            //1号吸嘴定位
            if (Work.Cam2_Suction_Nozzle_Number == 1)
            {
                SaveImage("相机2", "1号吸嘴", true, DisplayForm.Instance[1]);
            }
            //2号吸嘴定位
            else if (Work.Cam2_Suction_Nozzle_Number == 2)
            {
                SaveImage("相机2", "1号吸嘴", true, DisplayForm.Instance[4]);
            }
        }
        private static void Cam2_Calibration(HalconDotNet.HObject ho_image)
        {
            if (Work.Cam2_Calibration_Mode)
            {
                if (Work.Cam2_Suction_Nozzle_Number == 1)
                {
                    //9点标定+ 1号吸嘴旋转标定
                    if (Work.Cam2_Calibration_Index == 4)//步骤变换
                    {

                    }





                    if (Work.Cam2_Calibration_Index == 10)
                    {
                        Work.Cam2_Calibration_Mode = false;
                        Work.Cam2_Suction_Nozzle_Number = -1;
                        Log.WriteRunLog("相机2 9点标定+1号吸嘴旋转标定结束");
                    }
                    AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,1");
                }
                else if (Work.Cam2_Suction_Nozzle_Number == 2)
                {
                    //2号吸嘴旋转标定







                    if (Work.Cam2_Calibration_Index == 10)
                    {
                        Work.Cam2_Calibration_Mode = false;
                        Work.Cam2_Suction_Nozzle_Number = -1;
                        Log.WriteRunLog("相机2 2号吸嘴旋转标定结束");
                    }
                    AppParam.Instance.TCPSocketServer_Cam2.SendMessage("&CAE,1");
                }

            }
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
