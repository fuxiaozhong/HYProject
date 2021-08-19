using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HYProject.Properties;

using IWshRuntimeLibrary;

namespace HYProject.ToolForm
{
    public partial class Form_Lock : Form
    {
        public Form_Lock()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((AppParam.Instance.Power == "管理员" && tbx_password.Text == "Admin") || (AppParam.Instance.Power == "操作员" && tbx_password.Text == "123456") || (AppParam.Instance.Power == "未登录" && tbx_password.Text == "123456"))
                {
                    this.Close();
                }
                else
                {
                    tbx_password.PasswordChar = new char();
                    tbx_password.Text = "密码错误，请重新输入";
                    button1.Select();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Form_Lock_Load(object sender, EventArgs e)
        {
            tbx_password.Select();
        }

        #region 窗体拖动
        private static bool IsDrag = false;
        private int enterX;
        private int enterY;
        private void setForm_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                IsDrag = true;
                enterX = e.Location.X;
                enterY = e.Location.Y;
            }
            catch (Exception)
            {

            }
        }
        private void setForm_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                IsDrag = false;
                enterX = 0;
                enterY = 0;
            }
            catch (Exception)
            {

            }
        }
        private void setForm_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (IsDrag)
                {
                    Left += e.Location.X - enterX;
                    Top += e.Location.Y - enterY;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        /// <summary>
        /// X向自动增加
        /// </summary>
        private bool Xadd = true;
        /// <summary>
        /// Y向自动增加
        /// </summary>
        private bool Yadd = true;
        /// <summary>
        /// 窗体是否移动
        /// </summary>
        private bool isMove = true;
        /// <summary>
        /// 一段时间不操作则自动恢复飘动
        /// </summary>
        private int waitTime = 0;
        /// <summary>
        /// 是否停止刷新
        /// </summary>
        private bool stopUpdata = false;
        private void UpdataStatu(object o)
        {
            try
            {
                while (!stopUpdata)
                {
                    tbx_password.Focus();
                    Application.DoEvents();
                    if (!isMove)
                    {
                        waitTime++;
                        if (waitTime > 5000000)
                        {
                            isMove = true;
                            waitTime = 0;
                        }
                        continue;
                    }

                    if (Xadd)
                        this.Location = new System.Drawing.Point(this.Location.X + 1, this.Location.Y);
                    if (Yadd)
                        this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + 1);
                    if (!Xadd)
                        this.Location = new System.Drawing.Point(this.Location.X - 1, this.Location.Y);
                    if (!Yadd)
                        this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y - 1);

                    if (this.Location.X >= MainForm.Instance.Location.X + MainForm.Instance.Width - this.Width - 10)
                        Xadd = false;
                    if (this.Location.Y >= MainForm.Instance.Location.Y + MainForm.Instance.Height - this.Height - 10)
                        Yadd = false;
                    if (this.Location.X <= MainForm.Instance.Location.X + 10)
                        Xadd = true;
                    if (this.Location.Y <= MainForm.Instance.Location.Y)
                        Yadd = true;

                    Application.DoEvents();
                    Thread.Sleep(15);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Form_Lock_Shown(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(UpdataStatu);
        }

        private void Tbx_password_TextChanged(object sender, EventArgs e)
        {
            isMove = false;
            this.Opacity = 1;
        }

        private void Form_Lock_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopUpdata = true;
        }

        private void Tbx_password_Click(object sender, EventArgs e)
        {
            tbx_password.PasswordChar = '*';

        }

        private void Form_Lock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(null, null);
            }
        }
    }
}
