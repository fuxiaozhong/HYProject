﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HslCommunication;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HYProject.ToolForm
{
    public partial class Form_PLC : Form
    {
        public Form_PLC()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Fx3uPLC == null)
            {
                AppParam.Instance.Fx3uPLC = new HslCommunication.Profinet.Melsec.MelsecA1ENet();
            }

            AppParam.Instance.Fx3uPLC.IpAddress = PLC_IP.Text;
            AppParam.Instance.Fx3uPLC.Port = int.Parse(PLC_Port.Text);
            AppParam.Instance.Fx3uPLC.ConnectTimeOut = 1000;
            AppParam.Instance.Fx3uPLCResult = AppParam.Instance.Fx3uPLC.ConnectServer();
            if (AppParam.Instance.Fx3uPLCResult.IsSuccess)
            {
                materialLabel5.Text = "连接成功";
                materialLabel5.ForeColor = Color.Lime;
                AppParam.Instance.Fx3uPLC_IP = PLC_IP.Text;
                AppParam.Instance.Fx3uPLC_Port = int.Parse(PLC_Port.Text);
                groupBox2.Enabled = true;
            }
            else
            {
                materialLabel5.Text = "连接失败";
                materialLabel5.ForeColor = Color.Red;
                groupBox2.Enabled = false;
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Fx3uPLCResult != null && AppParam.Instance.Fx3uPLCResult.IsSuccess)
            {
                int value = AppParam.Instance.Fx3uPLC.ReadInt32(PLC_Address.Text).Content;
                materialLabel3.Text = value.ToString();
                materialLabel3.ForeColor = Color.Blue;
            }
        }

        private void Form_PLC_Load(object sender, EventArgs e)
        {

            PLC_IP.Text = AppParam.Instance.Fx3uPLC_IP;
            PLC_Port.Text = AppParam.Instance.Fx3uPLC_Port.ToString();

            if (AppParam.Instance.Fx3uPLCResult != null && AppParam.Instance.Fx3uPLCResult.IsSuccess)
            {
                materialLabel5.Text = "连接成功";
                materialLabel5.ForeColor = Color.Lime;
                groupBox2.Enabled = true;

            }
            else
            {
                materialLabel5.Text = "连接失败";
                materialLabel5.ForeColor = Color.Red;
                groupBox2.Enabled = false;

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Fx3uPLCResult != null && AppParam.Instance.Fx3uPLCResult.IsSuccess)
            {
                OperateResult operateResult = AppParam.Instance.Fx3uPLC.Write(PLC_Address.Text, PLC_Value.Text);
                if (operateResult.IsSuccess)
                {
                    materialLabel3.Text = "写入成功";
                    materialLabel3.ForeColor = Color.Lime;

                }
                else
                {
                    materialLabel3.Text = "写入失败";
                    materialLabel3.ForeColor = Color.Red;
                }
            }

        }

        private void Button_save_Click(object sender, EventArgs e)
        {
            AppParam.Instance.Fx3uPLC_IP = PLC_IP.Text;
            AppParam.Instance.Fx3uPLC_Port = int.Parse(PLC_Port.Text);

            AppParam.Instance.Save_To_File();
            MessageBox.Show("保存成功");
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}