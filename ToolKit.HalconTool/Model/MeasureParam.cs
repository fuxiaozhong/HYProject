using System;
using System.ComponentModel;
using System.Reflection;

using HalconDotNet;

namespace ToolKit.HalconTool.Model
{
    [Serializable]
    public class MeasureParam
    {
        //卡尺宽度（卡尺一半的宽度）
        private int _CaliperWidth = 200;

        private int _SingleCaliperWidth = 2;
        private int num_Instances = 50;

        //卡茨间隔(卡尺数量 越小卡尺间隔越大)
        private int _CaliperNumber = 30;

        private HTuple _InputShapeParam;

        //阈值
        private int _AmplitudeThreshold = 30;

        //找到的点的最小分数
        private double _Min_Score = 0.8;

        //西格玛
        private double _Sigma = 13;

        //all 全部    positive 黑到白(暗到亮)    'negative'白到黑(亮到暗)
        private MeasureTransition _Transition = MeasureTransition.all;

        //'all' 全部  'first' 第一个点 last最后一个点
        private MeasureSelect _Select = MeasureSelect.all;

        private MeasureShapes _InputShapeStyle = MeasureShapes.line;

        private bool isDispCaliper = true;

        private bool isDispCross = true;

        private bool isDispInputRegion = true;

        private int _CrossSize = 30;

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("卡尺宽度")]
        public int CaliperWidth
        {
            get
            {
                return this._CaliperWidth;
            }

            set
            {
                this._CaliperWidth = value;
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("卡尺数量")]
        public int CaliperNumber
        {
            get
            {
                return this._CaliperNumber;
            }

            set
            {
                this._CaliperNumber = value;
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("阈值0-255")]
        public int AmplitudeThreshold
        {
            get
            {
                return this._AmplitudeThreshold;
            }

            set
            {
                if (value >= 1 && value <= 255)
                {
                    this._AmplitudeThreshold = value;
                }
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("最小分数0-1")]
        public double Min_Score
        {
            get
            {
                return this._Min_Score;
            }

            set
            {
                if (value >= 0.1 && value <= 1)
                {
                    this._Min_Score = value;
                }
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("西格玛0.4-100")]
        public double Sigma
        {
            get
            {
                return this._Sigma;
            }

            set
            {
                if (value >= 0.4 && value <= 100)
                {
                    this._Sigma = value;
                }
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("要寻找的形状,\nline从左往右,\n其他由内往外")]
        public MeasureShapes Shape
        {
            get
            {
                return this._InputShapeStyle;
            }

            set
            {
                this._InputShapeStyle = value;
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("亮/暗或暗/亮边缘。")]
        public MeasureTransition Transition
        {
            get
            {
                return this._Transition;
            }

            set
            {
                this._Transition = value;
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("端点的选择。")]
        public MeasureSelect Select
        {
            get
            {
                return this._Select;
            }

            set
            {
                this._Select = value;
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("形状参数")]
        public HTuple InputShapeParam
        {
            get
            {
                return this._InputShapeParam;
            }

            set
            {
                this._InputShapeParam = value;
            }
        }

        [CategoryAttribute("显示参数"), DescriptionAttribute("是否显示卡尺")]
        public bool IsDispCaliper
        {
            get
            {
                return this.isDispCaliper;
            }

            set
            {
                this.isDispCaliper = value;
            }
        }

        [CategoryAttribute("显示参数"), DescriptionAttribute("是否显示点位十字架")]
        public bool IsDispCross
        {
            get
            {
                return this.isDispCross;
            }

            set
            {
                this.isDispCross = value;
            }
        }

        [CategoryAttribute("显示参数"), DescriptionAttribute("点位十字架大小")]
        public int CrossSize
        {
            get
            {
                return this._CrossSize;
            }

            set
            {
                this._CrossSize = value;
            }
        }

        [CategoryAttribute("显示参数"), DescriptionAttribute("是否显示输入的基准线")]
        public bool IsDispInputRegion
        {
            get
            {
                return this.isDispInputRegion;
            }

            set
            {
                this.isDispInputRegion = value;
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("单个卡尺的宽度")]
        public int SingleCaliperWidth
        {
            get
            {
                return this._SingleCaliperWidth;
            }

            set
            {
                this._SingleCaliperWidth = value;
            }
        }

        [CategoryAttribute("卡尺参数"), DescriptionAttribute("每个计量对象成功拟合实例的最大数量")]
        public int Num_Instances
        {
            get
            {
                return this.num_Instances;
            }

            set
            {
                this.num_Instances = value;
            }
        }


        public object Colne()
        {

            return this.MemberwiseClone();

        }
    }

    public enum MeasureShapes
    {
        circle, rectangle2, ellipse, line
    }

    public enum MeasureSelect
    {
        all, first, last
    }

    public enum MeasureTransition
    {
        all, positive, negative
    }
}