using HYProject.ToolForm;

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
            DisplayForm.Instance["Cam1"].Disp_Image(ho_image);
            //DisplayForm.Instance[1].Disp_Image(ho_image);
        }
    }
}