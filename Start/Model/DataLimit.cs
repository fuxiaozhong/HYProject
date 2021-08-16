using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HYProject.Helper;
using HYProject.ToolForm;

namespace HYProject.Model
{
    [Serializable]
    public class DataLimit
    {
        private static DataLimit instance;
        //屏蔽
        internal bool Check_W;
        internal bool Check_M1;
        internal bool Check_M2;
        internal bool Check_PT;
        internal bool Check_P;
        internal bool Check_KJ;
        internal bool Check_S1;
        internal bool Check_S2;
        //下限
        internal decimal LowerLimit_W;
        internal decimal LowerLimit_M1;
        internal decimal LowerLimit_M2;
        internal decimal LowerLimit_PT;
        internal decimal LowerLimit_P;
        internal decimal LowerLimit_KJ;
        internal decimal LowerLimit_S1;
        internal decimal LowerLimit_S2;
        //基准
        internal decimal Standard_W;
        internal decimal Standard_M1;
        internal decimal Standard_M2;
        internal decimal Standard_PT;
        internal decimal Standard_P;
        internal decimal Standard_KJ;
        internal decimal Standard_S1;
        internal decimal Standard_S2;
        //上限
        internal decimal UpperLimit_W;
        internal decimal UpperLimit_M1;
        internal decimal UpperLimit_M2;
        internal decimal UpperLimit_PT;
        internal decimal UpperLimit_P;
        internal decimal UpperLimit_KJ;
        internal decimal UpperLimit_S1;
        internal decimal UpperLimit_S2;
        //补偿
        internal decimal Offset_W;
        internal decimal Offset_M1;
        internal decimal Offset_M2;
        internal decimal Offset_PT;
        internal decimal Offset_P;
        internal decimal Offset_KJ;
        internal decimal Offset_S1;
        internal decimal Offset_S2;





        /// <summary>
        /// 校验数据
        /// </summary>
        /// <param name="step">W/M1/M2/PT/P/KJ/S1/S2</param>
        /// <param name="value">要校验的值</param>
        /// <returns></returns>
        public bool CheckData(string step, decimal value)
        {
            Form_DateVsualization.Instance.RefreshData();
            decimal newValue = 0.0M;
            switch (step)
            {
                case "W":
                    newValue = value + Offset_W;
                    Form_DateVsualization.Instance.label_W_Value.Text = newValue.ToString();
                    if (Check_W)
                    {
                        Form_DateVsualization.Instance.label_W_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_W_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_W + LowerLimit_W) && newValue <= (Standard_W + UpperLimit_W))
                    {
                        Form_DateVsualization.Instance.label_W_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_W_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_W_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_W_Result.BackColor = Color.Red;
                        return false;
                    }
                case "M1":
                    newValue = value + Offset_M1;
                    Form_DateVsualization.Instance.label_M1_Value.Text = newValue.ToString();
                    if (Check_M1)
                    {
                        Form_DateVsualization.Instance.label_M1_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_M1_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_M1 + LowerLimit_M1) && newValue <= (Standard_M1 + UpperLimit_M1))
                    {
                        Form_DateVsualization.Instance.label_M1_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_M1_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_M1_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_M1_Result.BackColor = Color.Red;
                        return false;
                    }
                case "M2":
                    newValue = value + Offset_M2;
                    Form_DateVsualization.Instance.label_M2_Value.Text = newValue.ToString();
                    if (Check_M2)
                    {
                        Form_DateVsualization.Instance.label_M2_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_M2_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_M2 + LowerLimit_M2) && newValue <= (Standard_M2 + UpperLimit_M2))
                    {
                        Form_DateVsualization.Instance.label_M2_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_M2_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_M2_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_M2_Result.BackColor = Color.Red;
                        return false;
                    }
                case "PT":
                    newValue = value + Offset_PT;
                    Form_DateVsualization.Instance.label_PT_Value.Text = newValue.ToString();
                    if (Check_PT)
                    {
                        Form_DateVsualization.Instance.label_PT_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_PT_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_PT + LowerLimit_PT) && newValue <= (Standard_PT + UpperLimit_PT))
                    {
                        Form_DateVsualization.Instance.label_PT_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_PT_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_PT_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_PT_Result.BackColor = Color.Red;
                        return false;
                    }
                case "P":
                    newValue = value + Offset_P;
                    Form_DateVsualization.Instance.label_P_Value.Text = newValue.ToString();
                    if (Check_P)
                    {
                        Form_DateVsualization.Instance.label_P_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_P_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_P + LowerLimit_P) && newValue <= (Standard_P + UpperLimit_P))
                    {
                        Form_DateVsualization.Instance.label_P_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_P_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_P_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_P_Result.BackColor = Color.Red;
                        return false;
                    }
                case "KJ":
                    newValue = value + Offset_KJ;
                    Form_DateVsualization.Instance.label_KJ_Value.Text = newValue.ToString();
                    if (Check_KJ)
                    {
                        Form_DateVsualization.Instance.label_KJ_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_KJ_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_KJ + LowerLimit_KJ) && newValue <= (Standard_KJ + UpperLimit_KJ))
                    {
                        Form_DateVsualization.Instance.label_KJ_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_KJ_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_KJ_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_KJ_Result.BackColor = Color.Red;
                        return false;
                    }
                case "S1":
                    newValue = value + Offset_S1;
                    Form_DateVsualization.Instance.label_S1_Value.Text = newValue.ToString();
                    if (Check_S1)
                    {
                        Form_DateVsualization.Instance.label_S1_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_S1_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_S1 + LowerLimit_S1) && newValue <= (Standard_S1 + UpperLimit_S1))
                    {
                        Form_DateVsualization.Instance.label_S1_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_S1_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_S1_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_S1_Result.BackColor = Color.Red;
                        return false;
                    }
                case "S2":
                    newValue = value + Offset_S2;
                    Form_DateVsualization.Instance.label_S2_Value.Text = newValue.ToString();
                    if (Check_S2)
                    {
                        Form_DateVsualization.Instance.label_S2_Result.Text = "BLOCK";
                        Form_DateVsualization.Instance.label_S2_Result.BackColor = Color.Orange;
                        return true;
                    }
                    if (newValue >= (Standard_S2 + LowerLimit_S2) && newValue <= (Standard_S2 + UpperLimit_S2))
                    {
                        Form_DateVsualization.Instance.label_S2_Result.Text = "OK";
                        Form_DateVsualization.Instance.label_S2_Result.BackColor = Color.Green;
                        return true;
                    }
                    else
                    {
                        Form_DateVsualization.Instance.label_S2_Result.Text = "NG";
                        Form_DateVsualization.Instance.label_S2_Result.BackColor = Color.Red;
                        return false;
                    }
            }

            return false;
        }


        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        private DataLimit()
        {
        }

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static DataLimit Instance
        {
            get
            {
                //先判断是否存在，不存在再加锁处理
                if (instance == null)
                {
                    //在同一个时刻加了锁的那部分程序只有一个线程可以进入
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DataLimit();
                        }
                    }
                }
                return instance;
            }
        }

        public void Save()
        {
            Serialization.Save(DataLimit.Instance,AppParam.Instance.NowProduct +"_DataLimit");
        }
        public void Read()
        {
            instance = (DataLimit)Serialization.Read( AppParam.Instance.NowProduct + "_DataLimit");
            if (instance == null)
            {
                instance = new DataLimit();
            }
        }



    }
}
