using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalconDotNet;

using ToolKit.DisplayWindow;

namespace ToolKit.HalconTool
{
    [Serializable]
    public class Measure
    {
        [NonSerialized]
        private HalconDisplayWindow hWinControl;

        private HObject input_Image;

        //卡尺宽度（卡尺一半的宽度）
        private int _CaliperWidth = 200;

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

        private MeasureShapes _InputShapeStyle;

        private bool isDispCaliper = true;

        private bool isDispCross = true;

        private bool isDispInputRegion = true;

        private int _CrossSize = 30;

        private HObject _OutShapeRegion;

        private HTuple _OutShapeParam;

        [CategoryAttribute("输入图像"), DescriptionAttribute("输入图像")]
        public HObject Input_Image

        {
            get
            {
                return this.input_Image;
            }

            set
            {
                this.input_Image = value; this.Run();
            }
        }

        [CategoryAttribute("卡尺宽度"), DescriptionAttribute("卡尺宽度")]
        public int CaliperWidth
        {
            get
            {
                return this._CaliperWidth;
            }

            set
            {
                this._CaliperWidth = value; this.Run();
            }
        }

        [CategoryAttribute("卡尺数量"), DescriptionAttribute("卡尺数量")]
        public int CaliperNumber
        {
            get
            {
                return this._CaliperNumber;
            }

            set
            {
                this._CaliperNumber = value; this.Run();
            }
        }

        [CategoryAttribute("阈值0-255"), DescriptionAttribute("阈值0-255")]
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
                    this._AmplitudeThreshold = value; this.Run();
                }
            }
        }

        [CategoryAttribute("最小分数0-1"), DescriptionAttribute("最小分数0-1")]
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
                    this._Min_Score = value; this.Run();
                }
            }
        }

        [CategoryAttribute("西格玛0.4-100"), DescriptionAttribute("西格玛0.4-100")]
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
                    this._Sigma = value; this.Run();
                }
            }
        }

        [CategoryAttribute("要寻找的形状,line从左往右,其他由内往外"), DescriptionAttribute("要寻找的形状,\nline从左往右,\n其他由内往外")]
        public MeasureShapes Shape
        {
            get
            {
                return this._InputShapeStyle;
            }

            set
            {
                this._InputShapeStyle = value; this.Run();
            }
        }

        [CategoryAttribute("亮/暗或暗/亮边缘。"), DescriptionAttribute("亮/暗或暗/亮边缘。")]
        public MeasureTransition Transition
        {
            get
            {
                return this._Transition;
            }

            set
            {
                this._Transition = value; this.Run();
            }
        }

        [CategoryAttribute("端点的选择。"), DescriptionAttribute("端点的选择。")]
        public MeasureSelect Select
        {
            get
            {
                return this._Select;
            }

            set
            {
                this._Select = value; this.Run();
            }
        }

        [CategoryAttribute("形状参数"), DescriptionAttribute("形状参数")]
        public HTuple InputShapeParam
        {
            get
            {
                return this._InputShapeParam;
            }

            set
            {
                this._InputShapeParam = value; this.Run();
            }
        }

        [CategoryAttribute("显示控件"), DescriptionAttribute("显示控件")]
        public HalconDisplayWindow HWinControl
        {
            set
            {
                this.hWinControl = value;
            }
        }

        [CategoryAttribute("是否显示卡尺"), DescriptionAttribute("是否显示卡尺")]
        public bool IsDispCaliper
        {
            get
            {
                return this.isDispCaliper;
            }

            set
            {
                this.isDispCaliper = value; this.Run();
            }
        }

        [CategoryAttribute("是否显示点位十字架"), DescriptionAttribute("是否显示点位十字架")]
        public bool IsDispCross
        {
            get
            {
                return this.isDispCross;
            }

            set
            {
                this.isDispCross = value; this.Run();
            }
        }

        [CategoryAttribute("点位十字架大小"), DescriptionAttribute("点位十字架大小")]
        public int CrossSize
        {
            get
            {
                return this._CrossSize;
            }

            set
            {
                this._CrossSize = value;
                this.Run();
            }
        }

        [CategoryAttribute("输出的形状区域"), DescriptionAttribute("输出的形状区域")]
        public HObject OutShapeRegion
        {
            get
            {
                return this._OutShapeRegion;
            }
        }

        [CategoryAttribute("输出的形状区域参数"), DescriptionAttribute("输出的形状区域参数")]
        public HTuple OutShapeParam
        {
            get
            {
                return this._OutShapeParam;
            }
        }

        [CategoryAttribute("是否显示输入的基准图像"), DescriptionAttribute("是否显示输入的基准图像")]
        public bool IsDispInputRegion
        {
            get
            {
                return this.isDispInputRegion;
            }

            set
            {
                this.isDispInputRegion = value; this.Run();
            }
        }

        public void Run()
        {
            try
            {
                if (hWinControl == null || _InputShapeParam == null || _InputShapeStyle == null || input_Image == null)
                {
                    return;
                }

                HObject ho_Contours, ho_Cross, ho_Contour;
                HTuple hv_MetrologyHandle = new HTuple();
                HTuple hv_Index = new HTuple(), hv_Row = new HTuple();
                HTuple hv_Column = new HTuple(), hv_Nr = new HTuple();
                HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple();
                // Initialize local and output iconic variables
                HOperatorSet.GenEmptyObj(out _OutShapeRegion);
                HOperatorSet.GenEmptyObj(out ho_Contours);
                HOperatorSet.GenEmptyObj(out ho_Cross);
                HOperatorSet.GenEmptyObj(out ho_Contour);
                //创建句柄
                hv_MetrologyHandle.Dispose();
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HTuple hv_Width, hv_Height;
                hWinControl.Disp_Image(input_Image);
                HOperatorSet.GetImageSize(input_Image, out hv_Width, out hv_Height);
                //设置计量对象的图像大小
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);

                //------------判断参数是否合法------------
                HObject OldRegion = new HObject();
                HOperatorSet.GenEmptyObj(out OldRegion);
                OldRegion.Dispose();
                if (this._InputShapeStyle == MeasureShapes.line)
                {
                    try
                    {
                        Gen_Arrow_Contour_XLD(out OldRegion, _InputShapeParam.TupleSelect(0), _InputShapeParam.TupleSelect(1), _InputShapeParam.TupleSelect(2), _InputShapeParam.TupleSelect(3), 10, 10);

                        if (isDispCaliper)
                        {
                            HTuple hv_CenterRow = new HTuple(), hv_CenterCol = new HTuple();
                            HTuple hv_DirectionRow = new HTuple();
                            HTuple hv_DirectionCol = new HTuple();
                            //计算该直线的中点
                            hv_CenterRow.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_CenterRow = (_InputShapeParam.TupleSelect(0) + _InputShapeParam.TupleSelect(2)) / 2;
                            }
                            hv_CenterCol.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_CenterCol = (_InputShapeParam.TupleSelect(1) + _InputShapeParam.TupleSelect(3)) / 2;
                            }

                            HTuple ccrow = (hv_CenterRow + _InputShapeParam.TupleSelect(2)) / 2;
                            HTuple cccol = (hv_CenterCol + _InputShapeParam.TupleSelect(3)) / 2;



                            HTuple homMat2D = new HTuple();
                            HOperatorSet.VectorAngleToRigid(hv_CenterRow, hv_CenterCol, 0, hv_CenterRow, hv_CenterCol, new HTuple(-90).TupleRad(), out homMat2D);
                            HOperatorSet.AffineTransPoint2d(homMat2D, ccrow, cccol, out hv_DirectionRow, out hv_DirectionCol);

                            ccrow = (hv_CenterRow + hv_DirectionRow) / 2;
                            cccol = (hv_CenterCol + hv_DirectionCol) / 2;

                            HOperatorSet.VectorAngleToRigid(hv_CenterRow, hv_CenterCol, 0, hv_CenterRow, hv_CenterCol, new HTuple(0).TupleRad(), out homMat2D);
                            HOperatorSet.AffineTransPoint2d(homMat2D, ccrow, cccol, out hv_DirectionRow, out hv_DirectionCol);
                            HObject vertical;
                            HOperatorSet.GenEmptyObj(out vertical);
                            vertical.Dispose();
                            Gen_Arrow_Contour_XLD(out vertical, hv_CenterRow, hv_CenterCol, hv_DirectionRow, hv_DirectionCol, 20, 20);
                            hWinControl.Disp_Region(vertical.Clone(), "red", "margin");
                            vertical.Dispose();
                        }
                    }
                    catch { return; }
                }
                else if (this._InputShapeStyle == MeasureShapes.circle)
                {
                    try
                    {
                        HOperatorSet.GenCircle(out OldRegion, _InputShapeParam.TupleSelect(0), _InputShapeParam.TupleSelect(1), _InputShapeParam.TupleSelect(2));
                    }
                    catch { return; }
                }
                else if (this._InputShapeStyle == MeasureShapes.rectangle2)
                {
                    try
                    {
                        HOperatorSet.GenRectangle2(out OldRegion, _InputShapeParam.TupleSelect(0), _InputShapeParam.TupleSelect(1), _InputShapeParam.TupleSelect(2), _InputShapeParam.TupleSelect(3), _InputShapeParam.TupleSelect(4));
                    }
                    catch { return; }
                }
                else if (this._InputShapeStyle == MeasureShapes.ellipse)
                {
                    try
                    {
                        HOperatorSet.GenEllipse(out OldRegion, _InputShapeParam.TupleSelect(0), _InputShapeParam.TupleSelect(1), _InputShapeParam.TupleSelect(2), _InputShapeParam.TupleSelect(3), _InputShapeParam.TupleSelect(4));
                    }
                    catch { return; }
                }
                //--------------------------------------
                if (isDispInputRegion)
                {
                    hWinControl.Disp_Region(OldRegion.Clone(), "turquoise", "margin");
                }

                OldRegion.Dispose();
                //添加线模型
                hv_Index.Dispose();
                HOperatorSet.AddMetrologyObjectGeneric(hv_MetrologyHandle, new HTuple(this._InputShapeStyle.ToString()), _InputShapeParam, 20, 5, 1, 30, new HTuple(), new HTuple(), out hv_Index);
                //all 全部    positive 黑到白(暗到亮)    'negative'白到黑(亮到暗)
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_transition", _Transition.ToString());
                //指定所需度量区域的数量(卡尺数量  越小卡尺间隔越大)
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_measures", _CaliperNumber);
                //每个计量对象成功拟合实例的最大数量
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_instances", 100);
                //西格玛
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_sigma", _Sigma);
                //整个卡尺宽度（一半）
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length1", _CaliperWidth / 2);
                //单个卡尺的测量宽度
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length2", 5);
                //阈值
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_threshold", _AmplitudeThreshold);
                //参数指定要使用的插值类型   双立体
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_interpolation", "bicubic");
                //'all' 全部  'first' 第一个点            last最后一个点
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_select", _Select.ToString());
                //找的的最小分数
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "min_score", _Min_Score);
                HObject rgb1Image;
                HOperatorSet.GenEmptyObj(out rgb1Image);
                rgb1Image.Dispose();

                HOperatorSet.Rgb1ToGray(input_Image, out rgb1Image);

                //开始找边
                HOperatorSet.ApplyMetrologyModel(rgb1Image, hv_MetrologyHandle);
                //获取计量模型中计量对象的测量区域和边缘位置的结果。（获取坐标）
                ho_Contours.Dispose(); hv_Row.Dispose(); hv_Column.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_Contours, hv_MetrologyHandle, "all", "all", out hv_Row, out hv_Column);
                if (isDispCaliper)
                {
                    hWinControl.Disp_Region(ho_Contours, "12", "margin");
                }

                //把点显示出来
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, _CrossSize, new HTuple(45).TupleRad());
                if (isDispCross)
                {
                    hWinControl.Disp_Region(ho_Cross, "green", "margin");
                }
                //释放测量句柄
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);
                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Row, hv_Column);
                if (this._InputShapeStyle == MeasureShapes.line)
                {
                    HTuple hv_RowBegin = new HTuple(), hv_ColumnBegin = new HTuple(), hv_RowEnd = new HTuple(), hv_ColumnEnd = new HTuple();
                    hv_RowBegin.Dispose(); hv_ColumnBegin.Dispose(); hv_RowEnd.Dispose(); hv_ColumnEnd.Dispose(); hv_Nr.Dispose(); hv_Nc.Dispose(); hv_Dist.Dispose();
                    HOperatorSet.FitLineContourXld(ho_Contour, "tukey", -1, 0, 5, 2, out hv_RowBegin, out hv_ColumnBegin, out hv_RowEnd, out hv_ColumnEnd, out hv_Nr, out hv_Nc, out hv_Dist);
                    _OutShapeParam = new HTuple();
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = hv_RowBegin;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = hv_ColumnBegin;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = hv_RowEnd;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = hv_ColumnEnd;
                    _OutShapeRegion.Dispose();
                    HOperatorSet.GenRegionLine(out _OutShapeRegion, hv_RowBegin, hv_ColumnBegin, hv_RowEnd, hv_ColumnEnd);
                }
                else if (this._InputShapeStyle == MeasureShapes.circle)
                {
                    HTuple Row, Column, Radius, StartPhi, EndPhi, PointOrder;
                    HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 3, 2, out Row, out Column, out Radius, out StartPhi, out EndPhi, out PointOrder);
                    _OutShapeParam = new HTuple();
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Row;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Column;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Radius;
                    HOperatorSet.GenCircle(out _OutShapeRegion, Row, Column, Radius);
                }
                else if (this._InputShapeStyle == MeasureShapes.rectangle2)
                {
                    HTuple Row1, Column1, Phi, Length1, Length2, PointOrder1;
                    HOperatorSet.FitRectangle2ContourXld(ho_Contour, "regression", -1, 0, 0, 3, 2, out Row1, out Column1, out Phi, out Length1, out Length2, out PointOrder1);
                    _OutShapeParam = new HTuple();
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Row1;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Column1;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Phi;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Length1;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Length2;
                    HOperatorSet.GenRectangle2(out _OutShapeRegion, Row1, Column1, Phi, Length1, Length2);
                }
                else if (this._InputShapeStyle == MeasureShapes.ellipse)
                {
                    HTuple Row2, Column2, Phi1, Radius1, Radius2, StartPhi1, EndPhi1, PointOrder2;
                    HOperatorSet.FitEllipseContourXld(ho_Contour, "fitzgibbon", -1, 0, 0, 200, 3, 2, out Row2, out Column2, out Phi1, out Radius1, out Radius2, out StartPhi1, out EndPhi1, out PointOrder2);
                    _OutShapeParam = new HTuple();
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Row2;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Column2;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Phi1;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Radius1;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Radius2;
                    HOperatorSet.GenEllipse(out _OutShapeRegion, Row2, Column2, Phi1, Radius1, Radius2);
                }
                hWinControl.Disp_Region(_OutShapeRegion, "blue", "margin");
                ho_Contours.Dispose();
                ho_Cross.Dispose();
                ho_Contour.Dispose();

                hv_MetrologyHandle.Dispose();
                hv_Index.Dispose();
                hv_Row.Dispose();
                hv_Column.Dispose();
                hv_Nr.Dispose();
                hv_Nc.Dispose();
                hv_Dist.Dispose();
            }
            catch (Exception ee)
            {

            }
        }

        public HTuple Save()
        {
            HTuple save = new HTuple();
            HOperatorSet.CreateDict(out save);
            HOperatorSet.SetDictTuple(save, "_CaliperWidth", new HTuple(_CaliperWidth));
            HOperatorSet.SetDictTuple(save, "_CaliperNumber", new HTuple(_CaliperNumber));
            HOperatorSet.SetDictTuple(save, "_InputShapeParam", _InputShapeParam);
            HOperatorSet.SetDictTuple(save, "_AmplitudeThreshold", new HTuple(_AmplitudeThreshold));
            HOperatorSet.SetDictTuple(save, "_Min_Score", new HTuple(_Min_Score));
            HOperatorSet.SetDictTuple(save, "_Sigma", new HTuple(_Sigma));
            HOperatorSet.SetDictTuple(save, "_Transition", new HTuple(_Transition.ToString()));
            HOperatorSet.SetDictTuple(save, "_Select", new HTuple(_Select.ToString()));
            HOperatorSet.SetDictTuple(save, "_InputShapeStyle", new HTuple(_InputShapeStyle.ToString()));
            HOperatorSet.SetDictTuple(save, "isDispCaliper", new HTuple(isDispCaliper));
            HOperatorSet.SetDictTuple(save, "isDispCross", new HTuple(isDispCross));
            HOperatorSet.SetDictTuple(save, "isDispInputRegion", new HTuple(isDispInputRegion));
            return save;
        }

        public void Gen_Arrow_Contour_XLD(out HObject ho_Arrow,
                                          HTuple hv_Row1,
                                          HTuple hv_Column1,
                                          HTuple hv_Row2,
                                          HTuple hv_Column2,
                                          HTuple hv_HeadLength,
                                          HTuple hv_HeadWidth)
        {
            // Stack for temporary objects
            HObject[] OTemp = new HObject[20];

            // Local iconic variables

            HObject ho_TempArrow = null;

            // Local control variables

            HTuple hv_Length = new HTuple(), hv_ZeroLengthIndices = new HTuple();
            HTuple hv_DR = new HTuple(), hv_DC = new HTuple(), hv_HalfHeadWidth = new HTuple();
            HTuple hv_RowP1 = new HTuple(), hv_ColP1 = new HTuple();
            HTuple hv_RowP2 = new HTuple(), hv_ColP2 = new HTuple();
            HTuple hv_Index = new HTuple();
            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);
            //This procedure generates arrow shaped XLD contours,
            //pointing from (Row1, Column1) to (Row2, Column2).
            //If starting and end point are identical, a contour consisting
            //of a single point is returned.
            //
            //input parameteres:
            //Row1, Column1: Coordinates of the arrows' starting points
            //Row2, Column2: Coordinates of the arrows' end points
            //HeadLength, HeadWidth: Size of the arrow heads in pixels
            //
            //output parameter:
            //Arrow: The resulting XLD contour
            //
            //The input tuples Row1, Column1, Row2, and Column2 have to be of
            //the same length.
            //HeadLength and HeadWidth either have to be of the same length as
            //Row1, Column1, Row2, and Column2 or have to be a single element.
            //If one of the above restrictions is violated, an error will occur.
            //
            //
            //Init
            ho_Arrow.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            //
            //Calculate the arrow length
            hv_Length.Dispose();
            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
            //
            //Mark arrows with identical start and end point
            //(set Length to -1 to avoid division-by-zero exception)
            hv_ZeroLengthIndices.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ZeroLengthIndices = hv_Length.TupleFind(
                    0);
            }
            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
            {
                if (hv_Length == null)
                    hv_Length = new HTuple();
                hv_Length[hv_ZeroLengthIndices] = -1;
            }
            //
            //Calculate auxiliary variables.
            hv_DR.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
            }
            hv_DC.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
            }
            hv_HalfHeadWidth.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_HalfHeadWidth = hv_HeadWidth / 2.0;
            }
            //
            //Calculate end points of the arrow head.
            hv_RowP1.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
            }
            hv_ColP1.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
            }
            hv_RowP2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
            }
            hv_ColP2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
            }
            //
            //Finally create output XLD contour for each input point pair
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                {
                    //Create_ single points for arrows with identical start and end point
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(hv_Index),
                            hv_Column1.TupleSelect(hv_Index));
                    }
                }
                else
                {
                    //Create arrow contour
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                            hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                            ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                            hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                    }
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
                    ho_Arrow.Dispose();
                    ho_Arrow = ExpTmpOutVar_0;
                }
            }
            ho_TempArrow.Dispose();

            hv_Length.Dispose();
            hv_ZeroLengthIndices.Dispose();
            hv_DR.Dispose();
            hv_DC.Dispose();
            hv_HalfHeadWidth.Dispose();
            hv_RowP1.Dispose();
            hv_ColP1.Dispose();
            hv_RowP2.Dispose();
            hv_ColP2.Dispose();
            hv_Index.Dispose();

            return;
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
