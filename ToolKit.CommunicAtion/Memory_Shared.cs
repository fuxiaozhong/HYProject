using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ToolKit.CommunicAtion
{
    public class Memory_Shared
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFileMapping(int hFile, IntPtr lpAttributes, uint flProtect, uint dwMaxSizeHi, uint dwMaxSizeLow, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr OpenFileMapping(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr MapViewOfFile(IntPtr hFileMapping, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool UnmapViewOfFile(IntPtr pvBaseAddress);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32", EntryPoint = "GetLastError")]
        public static extern int GetLastError();

        private const int ERROR_ALREADY_EXISTS = 183;

        private const int FILE_MAP_COPY = 0x0001;
        private const int FILE_MAP_WRITE = 0x0002;
        private const int FILE_MAP_READ = 0x0004;
        private const int FILE_MAP_ALL_ACCESS = 0x0002 | 0x0004;

        private const int PAGE_READONLY = 0x02;
        private const int PAGE_READWRITE = 0x04;
        private const int PAGE_WRITECOPY = 0x08;
        private const int PAGE_EXECUTE = 0x10;
        private const int PAGE_EXECUTE_READ = 0x20;
        private const int PAGE_EXECUTE_READWRITE = 0x40;

        private const int SEC_COMMIT = 0x8000000;
        private const int SEC_IMAGE = 0x1000000;
        private const int SEC_NOCACHE = 0x10000000;
        private const int SEC_RESERVE = 0x4000000;

        private const int INVALID_HANDLE_VALUE = -1;

        private IntPtr m_hSharedMemoryFile = IntPtr.Zero;
        private IntPtr m_pwData = IntPtr.Zero;
        private bool m_bAlreadyExist = false;
        private bool m_bInit = false;
        private long m_MemSize = 0;

        /// <summary>
        /// 初始化
        /// </summary>
        public Memory_Shared()
        {
        }

        /// <summary>
        /// 初始化的同时开启内存共享
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="lngSize"></param>
        public Memory_Shared(string strName = "SharedMemoryName", long lngSize = 1024 * 1024)
        {
            Init(strName, lngSize);
        }

        ~Memory_Shared()
        {
            Close();
        }

        /// <summary>
        /// 初始化共享内存
        /// </summary>
        /// <param name="strName">共享内存名称</param>
        /// <param name="lngSize">共享内存大小</param>
        /// <returns></returns>
        public int Init(string strName = "SharedMemoryName", long lngSize = 1024 * 1024)
        {
            if (lngSize <= 0 || lngSize > 0x00800000) lngSize = 0x00800000;
            m_MemSize = lngSize;
            if (strName.Length > 0)
            {
                //创建内存共享体(INVALID_HANDLE_VALUE)
                m_hSharedMemoryFile = CreateFileMapping(INVALID_HANDLE_VALUE, IntPtr.Zero, (uint)PAGE_READWRITE, 0, (uint)lngSize, strName);
                if (m_hSharedMemoryFile == IntPtr.Zero)
                {
                    m_bAlreadyExist = false;
                    m_bInit = false;
                    return 2; //创建共享体失败
                }
                else
                {
                    if (GetLastError() == ERROR_ALREADY_EXISTS)  //已经创建
                    {
                        m_bAlreadyExist = true;
                    }
                    else                                         //新创建
                    {
                        m_bAlreadyExist = false;
                    }
                }
                //---------------------------------------
                //创建内存映射
                m_pwData = MapViewOfFile(m_hSharedMemoryFile, FILE_MAP_WRITE, 0, 0, (uint)lngSize);
                if (m_pwData == IntPtr.Zero)
                {
                    m_bInit = false;
                    CloseHandle(m_hSharedMemoryFile);
                    return 3; //创建内存映射失败
                }
                else
                {
                    m_bInit = true;
                    if (m_bAlreadyExist == false)
                    {
                        //初始化
                    }
                }
                //----------------------------------------
            }
            else
            {
                return 1; //参数错误
            }

            return 0;     //创建成功
        }

        /// <summary>
        /// 关闭共享内存
        /// </summary>
        public void Close()
        {
            if (m_bInit)
            {
                UnmapViewOfFile(m_pwData);
                CloseHandle(m_hSharedMemoryFile);
            }
        }

        /// <summary>
        /// 读数据
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            byte[] bytData = new byte[m_MemSize];
            if (m_bInit)
            {
                Marshal.Copy(m_pwData, bytData, 0, (int)m_MemSize);
                return Encoding.UTF8.GetString(bytData); ;
            }
            else
            {
                return "1"; //共享内存未初始化
            }
        }

        /// <summary>
        /// 写数据
        /// </summary>
        /// <returns></returns>
        public int Write(string message)
        {
            if (m_bInit)
            {
                byte[] bytData = Encoding.UTF8.GetBytes(string.Join("\r\n", message));
                byte[] test = new byte[m_MemSize];
                for (int i = 0; i < bytData.Length; i++)
                {
                    test[i] = bytData[i];
                }
                Marshal.Copy(test, 0, m_pwData, (int)m_MemSize);
            }
            else
            {
                return 1; //共享内存未初始化
            }
            return 0;     //写成功
        }
    }
}