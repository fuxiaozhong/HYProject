using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HYProject.Helper
{
    public class AutoCheckImage
    {

        /// <summary>
        /// 自动判断图像储存是否到期
        /// </summary>
        public static void DeleteFile()
        {
            while (true)
            {
                if (Directory.Exists(AppParam.Instance.Save_Image_Path))
                {
                    string[] fileNameX = Directory.GetFiles(AppParam.Instance.Save_Image_Path, "*.*");
                    List<string> lists = new List<string>();
                    for (int i = 0; i < fileNameX.Length; i++)
                    {
                        string fileNamei = fileNameX[i].ToLower();
                        if (fileNamei.EndsWith(".png") || fileNamei.EndsWith(".jpg") || fileNamei.EndsWith(".bmp"))
                        {
                            lists.Add(fileNamei);
                        }
                    }
                    Array array = Array.CreateInstance(typeof(string), lists.Count);
                    lists.CopyTo((string[])array, 0);
                    foreach (string file in lists)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        TimeSpan t = DateTime.Now - fileInfo.CreationTime;  //当前时间  减去 文件创建时间
                        int day = t.Days;
                        if (day > AppParam.Instance.Save_Image_Days)   //保存的时间 ;  单位：天
                        {
                            File.Delete(file);  //删除超过时间的文件
                        }
                    }
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(AppParam.Instance.Save_Image_Path);
                    }
                    catch (Exception)
                    {
                    }
                }
                Thread.Sleep(10000);//10S检查一次
            }
        }

    }
}
