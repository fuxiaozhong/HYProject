using HalconDotNet;

using ToolKit.DisplayWindow;
using ToolKit.HalconTool;

namespace HYProject.Arithmetic
{
    public class Slicing
    {
        public static void Test(HObject iamge, HalconDisplayWindow displayWindow)
        {
            // Local iconic variables

            HObject ho_ImageScaled, ho_Region, ho_ConnectedRegions;
            HObject ho_SelectedRegions, ho_SortedRegions, ho_RegionUnion;
            HObject ho_RegionDilation, ho_ImageReduced, ho_Region1;
            HObject ho_RegionFillUp, ho_Cross, ho_Cross1, ho_Arrow1;
            HObject ho_FirstObj, ho_LastObj, ho_SecondObj;

            // Local control variables

            HTuple hv_UsedThreshold = new HTuple();
            HTuple hv_Count = new HTuple(), hv_Row2 = new HTuple();
            HTuple hv_Column2 = new HTuple(), hv_Phi2 = new HTuple();
            HTuple hv_Length12 = new HTuple(), hv_Length22 = new HTuple();
            HTuple hv_UsedThreshold1 = new HTuple(), hv_Row1 = new HTuple();
            HTuple hv_Column1 = new HTuple(), hv_Phi1 = new HTuple();
            HTuple hv_Length11 = new HTuple(), hv_Length21 = new HTuple();
            HTuple hv_Rows = new HTuple(), hv_Columns = new HTuple();
            HTuple hv_Rows1 = new HTuple(), hv_Columns1 = new HTuple();
            HTuple hv_W_Distance = new HTuple(), hv_RowCenter1 = new HTuple();
            HTuple hv_ColCenter1 = new HTuple(), hv_Length3 = new HTuple();
            HTuple hv_Phi3 = new HTuple(), hv_FirstObj_Area = new HTuple();
            HTuple hv_FirstObj_Row = new HTuple(), hv_FirstObj_Column = new HTuple();
            HTuple hv_M1_Distance = new HTuple(), hv_LastObj_Area = new HTuple();
            HTuple hv_LastObj_Row = new HTuple(), hv_LastObj_Column = new HTuple();
            HTuple hv_M2_Distance = new HTuple(), hv_Pitch_Distance = new HTuple();
            HTuple hv_PT_Distance = new HTuple(), hv_SecondObj_Area = new HTuple();
            HTuple hv_SecondObj_Row = new HTuple(), hv_SecondObj_Column = new HTuple();
            HTuple hv_P_Distance = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SortedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region1);
            HOperatorSet.GenEmptyObj(out ho_RegionFillUp);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Cross1);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            HOperatorSet.GenEmptyObj(out ho_FirstObj);
            HOperatorSet.GenEmptyObj(out ho_LastObj);
            HOperatorSet.GenEmptyObj(out ho_SecondObj);
            try
            {
                displayWindow.Disp_Image(iamge);
                //*************************************************************************************************************************************
                ho_ImageScaled.Dispose();
                HOperatorSet.ScaleImage(iamge, out ho_ImageScaled, 25.5, -3289);
                ho_Region.Dispose(); hv_UsedThreshold.Dispose();
                HOperatorSet.BinaryThreshold(ho_ImageScaled, out ho_Region, "max_separability",
                    "dark", out hv_UsedThreshold);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, (((new HTuple("area")).TupleConcat("height")).TupleConcat("width")).TupleConcat("rectangularity"), "and",
                    (((new HTuple(1761.84)).TupleConcat(353.525)).TupleConcat(20.9184)).TupleConcat(0.878015),
                    (((new HTuple(10000)).TupleConcat(505.8)).TupleConcat(27.5417)).TupleConcat(1));
                ho_SortedRegions.Dispose();
                HOperatorSet.SortRegion(ho_SelectedRegions, out ho_SortedRegions, "first_point", "true", "column");
                hv_Count.Dispose();
                HOperatorSet.CountObj(ho_SortedRegions, out hv_Count);
                ho_RegionUnion.Dispose();
                HOperatorSet.Union1(ho_SortedRegions, out ho_RegionUnion);
                hv_Row2.Dispose(); hv_Column2.Dispose(); hv_Phi2.Dispose(); hv_Length12.Dispose(); hv_Length22.Dispose();
                HOperatorSet.SmallestRectangle2(ho_RegionUnion, out hv_Row2, out hv_Column2, out hv_Phi2, out hv_Length12, out hv_Length22);
                ho_RegionDilation.Dispose();
                HOperatorSet.DilationRectangle1(ho_RegionUnion, out ho_RegionDilation, 100, 50);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_ImageScaled, ho_RegionDilation, out ho_ImageReduced);
                ho_Region1.Dispose(); hv_UsedThreshold1.Dispose();
                HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region1, "max_separability", "light", out hv_UsedThreshold1);
                ho_RegionFillUp.Dispose();
                HOperatorSet.FillUp(ho_Region1, out ho_RegionFillUp);
                hv_Row1.Dispose(); hv_Column1.Dispose(); hv_Phi1.Dispose(); hv_Length11.Dispose(); hv_Length21.Dispose();
                HOperatorSet.SmallestRectangle2(ho_RegionFillUp, out hv_Row1, out hv_Column1,
                    out hv_Phi1, out hv_Length11, out hv_Length21);
                //外矩形
                ho_Cross.Dispose(); hv_Rows.Dispose(); hv_Columns.Dispose();
                HalconUtils.RectangleVertices(out ho_Cross, hv_Row1, hv_Column1, hv_Phi1, hv_Length11,
                    hv_Length21, out hv_Rows, out hv_Columns);
                //内矩形
                ho_Cross1.Dispose(); hv_Rows1.Dispose(); hv_Columns1.Dispose();
                HalconUtils.RectangleVertices(out ho_Cross1, hv_Row2, hv_Column2, hv_Phi2, hv_Length12,
                    hv_Length22, out hv_Rows1, out hv_Columns1);

                //*********************************  W  ***************************************************
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_W_Distance.Dispose();
                    HOperatorSet.DistancePp(hv_Rows.TupleSelect(0), hv_Columns.TupleSelect(0),
                        hv_Rows.TupleSelect(1), hv_Columns.TupleSelect(1), out hv_W_Distance);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    ho_Arrow1.Dispose();
                    HalconUtils.double_sided_arrow(out ho_Arrow1, hv_Rows.TupleSelect(0), hv_Columns.TupleSelect(
                        0), hv_Rows.TupleSelect(1), hv_Columns.TupleSelect(1), 20, 30);
                }
                displayWindow.Disp_Region(ho_Arrow1, "blue", "margin");
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_RowCenter1.Dispose(); hv_ColCenter1.Dispose(); hv_Length3.Dispose(); hv_Phi3.Dispose();
                    HOperatorSet.LinePosition(hv_Rows.TupleSelect(0), hv_Columns.TupleSelect(0),
                        hv_Rows.TupleSelect(1), hv_Columns.TupleSelect(1), out hv_RowCenter1, out hv_ColCenter1,
                        out hv_Length3, out hv_Phi3);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    displayWindow.Disp_Message("W:" + hv_W_Distance.D.ToString("0.000"), 16, 0, 10, "green");
                }
                //*****************************************************************************************

                //*********************************  M1  ***************************************************
                //第一个
                ho_FirstObj.Dispose();
                HOperatorSet.SelectObj(ho_SortedRegions, out ho_FirstObj, 1);
                hv_FirstObj_Area.Dispose(); hv_FirstObj_Row.Dispose(); hv_FirstObj_Column.Dispose();
                HOperatorSet.AreaCenter(ho_FirstObj, out hv_FirstObj_Area, out hv_FirstObj_Row,
                    out hv_FirstObj_Column);
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_M1_Distance.Dispose();
                    HOperatorSet.DistancePl(hv_FirstObj_Row, hv_FirstObj_Column, hv_Rows.TupleSelect(
                        0), hv_Columns.TupleSelect(0), hv_Rows.TupleSelect(3), hv_Columns.TupleSelect(
                        3), out hv_M1_Distance);
                }

                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    displayWindow.Disp_Message("M1: " + hv_M1_Distance.D.ToString("0.000"), 16, 100, 10, "green");
                }
                //*****************************************************************************************

                //*********************************  M2  ***************************************************
                //第一个
                ho_LastObj.Dispose();
                HOperatorSet.SelectObj(ho_SortedRegions, out ho_LastObj, hv_Count);
                hv_LastObj_Area.Dispose(); hv_LastObj_Row.Dispose(); hv_LastObj_Column.Dispose();
                HOperatorSet.AreaCenter(ho_LastObj, out hv_LastObj_Area, out hv_LastObj_Row,
                    out hv_LastObj_Column);
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_M2_Distance.Dispose();
                    HOperatorSet.DistancePl(hv_LastObj_Row, hv_LastObj_Column, hv_Rows.TupleSelect(
                        1), hv_Columns.TupleSelect(1), hv_Rows.TupleSelect(2), hv_Columns.TupleSelect(
                        2), out hv_M2_Distance);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    displayWindow.Disp_Message("M2: " + hv_M2_Distance.D.ToString("0.000"), 16, 200, 10, "green");
                }

                //*****************************************************************************************

                //*********************************  孔距  ***************************************************
                //第一个

                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_Pitch_Distance.Dispose();
                    HOperatorSet.DistancePp(hv_Rows1.TupleSelect(2), hv_Columns1.TupleSelect(2),
                        hv_Rows1.TupleSelect(1), hv_Columns1.TupleSelect(1), out hv_Pitch_Distance);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    ho_Arrow1.Dispose();
                    HalconUtils.double_sided_arrow(out ho_Arrow1, hv_Rows1.TupleSelect(2), hv_Columns1.TupleSelect(
                        2), hv_Rows1.TupleSelect(1), hv_Columns1.TupleSelect(1), 20, 30);
                }
                displayWindow.Disp_Region(ho_Arrow1, "blue", "margin");
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_RowCenter1.Dispose(); hv_ColCenter1.Dispose(); hv_Length3.Dispose(); hv_Phi3.Dispose();
                    HOperatorSet.LinePosition(hv_Rows1.TupleSelect(2), hv_Columns1.TupleSelect(
                        2), hv_Rows1.TupleSelect(1), hv_Columns1.TupleSelect(1), out hv_RowCenter1,
                        out hv_ColCenter1, out hv_Length3, out hv_Phi3);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    displayWindow.Disp_Message("孔距: " + hv_Pitch_Distance.D.ToString("0.000"), 16, 300, 10, "green");
                }
                //*****************************************************************************************

                //*********************************  PT  ***************************************************
                //第一个
                ho_FirstObj.Dispose();
                HOperatorSet.SelectObj(ho_SortedRegions, out ho_FirstObj, 1);
                //最后一个
                ho_LastObj.Dispose();
                HOperatorSet.SelectObj(ho_SortedRegions, out ho_LastObj, hv_Count);
                hv_FirstObj_Area.Dispose(); hv_FirstObj_Row.Dispose(); hv_FirstObj_Column.Dispose();
                HOperatorSet.AreaCenter(ho_FirstObj, out hv_FirstObj_Area, out hv_FirstObj_Row,
                    out hv_FirstObj_Column);
                hv_LastObj_Area.Dispose(); hv_LastObj_Row.Dispose(); hv_LastObj_Column.Dispose();
                HOperatorSet.AreaCenter(ho_LastObj, out hv_LastObj_Area, out hv_LastObj_Row,
                    out hv_LastObj_Column);
                //PT距离
                hv_PT_Distance.Dispose();
                HOperatorSet.DistancePp(hv_FirstObj_Row, hv_FirstObj_Column, hv_LastObj_Row,
                    hv_LastObj_Column, out hv_PT_Distance);
                ho_Arrow1.Dispose();
                HalconUtils.double_sided_arrow(out ho_Arrow1, hv_FirstObj_Row, hv_FirstObj_Column, hv_LastObj_Row,
                    hv_LastObj_Column, 20, 30);
                displayWindow.Disp_Region(ho_Arrow1, "blue", "margin");
                hv_RowCenter1.Dispose(); hv_ColCenter1.Dispose(); hv_Length3.Dispose(); hv_Phi3.Dispose();
                HOperatorSet.LinePosition(hv_FirstObj_Row, hv_FirstObj_Column, hv_LastObj_Row,
                    hv_LastObj_Column, out hv_RowCenter1, out hv_ColCenter1, out hv_Length3,
                    out hv_Phi3);
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    displayWindow.Disp_Message("PT: " + hv_PT_Distance.D.ToString("0.000"), 16, 400, 10, "green");
                }

                //*****************************************************************************************

                //*********************************  P  ***************************************************
                //第一个
                ho_FirstObj.Dispose();
                HOperatorSet.SelectObj(ho_SortedRegions, out ho_FirstObj, 1);
                //第二个
                ho_SecondObj.Dispose();
                HOperatorSet.SelectObj(ho_SortedRegions, out ho_SecondObj, 2);
                hv_FirstObj_Area.Dispose(); hv_FirstObj_Row.Dispose(); hv_FirstObj_Column.Dispose();
                HOperatorSet.AreaCenter(ho_FirstObj, out hv_FirstObj_Area, out hv_FirstObj_Row,
                    out hv_FirstObj_Column);

                hv_SecondObj_Area.Dispose(); hv_SecondObj_Row.Dispose(); hv_SecondObj_Column.Dispose();
                HOperatorSet.AreaCenter(ho_SecondObj, out hv_SecondObj_Area, out hv_SecondObj_Row,
                    out hv_SecondObj_Column);

                //P距离
                hv_P_Distance.Dispose();
                HOperatorSet.DistancePp(hv_FirstObj_Row, hv_FirstObj_Column, hv_SecondObj_Row,
                    hv_SecondObj_Column, out hv_P_Distance);
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    displayWindow.Disp_Message("P: " + hv_P_Distance.D.ToString("0.000"), 16, 500, 10, "green");
                }
                //*****************************************************************************************
            }
            catch (HalconException HDevExpDefaultException)
            {
                Log.WriteErrorLog(HDevExpDefaultException.Message, HDevExpDefaultException);
                ho_ImageScaled.Dispose();
                ho_Region.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                ho_SortedRegions.Dispose();
                ho_RegionUnion.Dispose();
                ho_RegionDilation.Dispose();
                ho_ImageReduced.Dispose();
                ho_Region1.Dispose();
                ho_RegionFillUp.Dispose();
                ho_Cross.Dispose();
                ho_Cross1.Dispose();
                ho_Arrow1.Dispose();
                ho_FirstObj.Dispose();
                ho_LastObj.Dispose();
                ho_SecondObj.Dispose();

                hv_UsedThreshold.Dispose();
                hv_Count.Dispose();
                hv_Row2.Dispose();
                hv_Column2.Dispose();
                hv_Phi2.Dispose();
                hv_Length12.Dispose();
                hv_Length22.Dispose();
                hv_UsedThreshold1.Dispose();
                hv_Row1.Dispose();
                hv_Column1.Dispose();
                hv_Phi1.Dispose();
                hv_Length11.Dispose();
                hv_Length21.Dispose();
                hv_Rows.Dispose();
                hv_Columns.Dispose();
                hv_Rows1.Dispose();
                hv_Columns1.Dispose();
                hv_W_Distance.Dispose();
                hv_RowCenter1.Dispose();
                hv_ColCenter1.Dispose();
                hv_Length3.Dispose();
                hv_Phi3.Dispose();
                hv_FirstObj_Area.Dispose();
                hv_FirstObj_Row.Dispose();
                hv_FirstObj_Column.Dispose();
                hv_M1_Distance.Dispose();
                hv_LastObj_Area.Dispose();
                hv_LastObj_Row.Dispose();
                hv_LastObj_Column.Dispose();
                hv_M2_Distance.Dispose();
                hv_Pitch_Distance.Dispose();
                hv_PT_Distance.Dispose();
                hv_SecondObj_Area.Dispose();
                hv_SecondObj_Row.Dispose();
                hv_SecondObj_Column.Dispose();
                hv_P_Distance.Dispose();
            }
            ho_ImageScaled.Dispose();
            ho_Region.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_SelectedRegions.Dispose();
            ho_SortedRegions.Dispose();
            ho_RegionUnion.Dispose();
            ho_RegionDilation.Dispose();
            ho_ImageReduced.Dispose();
            ho_Region1.Dispose();
            ho_RegionFillUp.Dispose();
            ho_Cross.Dispose();
            ho_Cross1.Dispose();
            ho_Arrow1.Dispose();
            ho_FirstObj.Dispose();
            ho_LastObj.Dispose();
            ho_SecondObj.Dispose();

            hv_UsedThreshold.Dispose();
            hv_Count.Dispose();
            hv_Row2.Dispose();
            hv_Column2.Dispose();
            hv_Phi2.Dispose();
            hv_Length12.Dispose();
            hv_Length22.Dispose();
            hv_UsedThreshold1.Dispose();
            hv_Row1.Dispose();
            hv_Column1.Dispose();
            hv_Phi1.Dispose();
            hv_Length11.Dispose();
            hv_Length21.Dispose();
            hv_Rows.Dispose();
            hv_Columns.Dispose();
            hv_Rows1.Dispose();
            hv_Columns1.Dispose();
            hv_W_Distance.Dispose();
            hv_RowCenter1.Dispose();
            hv_ColCenter1.Dispose();
            hv_Length3.Dispose();
            hv_Phi3.Dispose();
            hv_FirstObj_Area.Dispose();
            hv_FirstObj_Row.Dispose();
            hv_FirstObj_Column.Dispose();
            hv_M1_Distance.Dispose();
            hv_LastObj_Area.Dispose();
            hv_LastObj_Row.Dispose();
            hv_LastObj_Column.Dispose();
            hv_M2_Distance.Dispose();
            hv_Pitch_Distance.Dispose();
            hv_PT_Distance.Dispose();
            hv_SecondObj_Area.Dispose();
            hv_SecondObj_Row.Dispose();
            hv_SecondObj_Column.Dispose();
            hv_P_Distance.Dispose();
        }
    }
}