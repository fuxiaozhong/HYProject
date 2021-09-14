using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
                    Director(AppParam.Instance.Save_Image_Path);
                }
                else
                {
                    Directory.CreateDirectory(AppParam.Instance.Save_Image_Path);
                }
                Thread.Sleep(1000 * 10);//10S检查一次
            }
        }
        private static void Director(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)     //判断是否为文件夹
                {
                    Director(fsinfo.FullName);//递归调用
                }
                else
                {
                    Console.WriteLine(fsinfo.FullName);//输出文件的全部路径
                                                       //FileInfo fileInfo = new FileInfo(file);
                    TimeSpan t = DateTime.Now - fsinfo.CreationTime;  //当前时间  减去 文件创建时间
                    int day = t.Days;
                    if (day > AppParam.Instance.Save_Image_Days)   //保存的时间 ;  单位：天
                    {
                        Log.WriteRunLog(fsinfo.Name + "储存到期,已自动删除.");
                        File.Delete(fsinfo.FullName);  //删除超过时间的文件
                    }
                }
            }


        }

    }
}