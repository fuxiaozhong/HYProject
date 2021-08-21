using System;
using System.Windows.Forms;

using HalconDotNet;

using ToolKit.DisplayWindow;
using ToolKit.HalconTool.Model;

namespace ToolKit.HalconTool
{
    public class HalconUtils
    {
        /// <summary>
        /// 创建模板(使用模板参数类)
        /// </summary>
        /// <param name="modelPar">模板参数</param>
        /// <returns></returns>
        public static bool CreateModel(ref ModelParameter modelPar)
        {
            HObject grayImage;
            HOperatorSet.GenEmptyObj(out grayImage);
            HObject template;
            HOperatorSet.GenEmptyObj(out template);
            try
            {
                if (modelPar.matchMode == MatchMode.BasedShape)
                {
                    modelPar.modelID = null;

                    HOperatorSet.ReduceDomain(modelPar.baseImage, modelPar.modelRegion, out template);

                    HOperatorSet.CreateScaledShapeModel(template,
                                                        (HTuple)"auto",
                                                        ((HTuple)modelPar.startAngle).TupleRad(),
                                                        ((HTuple)modelPar.angleRange).TupleRad(),
                                                        (HTuple)("auto"),
                                                        (HTuple)modelPar.minScale,
                                                        (HTuple)modelPar.maxScale,
                                                        (HTuple)"auto",
                                                        (HTuple)"auto",
                                                        (HTuple)modelPar.polarity,
                                                        modelPar.contrast == -1 ? (HTuple)"auto" : (HTuple)modelPar.contrast,
                                                        (HTuple)"auto",
                                                        out modelPar.modelID);
                }
                else
                {
                    modelPar.modelID = null;

                    grayImage.Dispose();
                    HOperatorSet.Rgb1ToGray(modelPar.baseImage, out grayImage);
                    HOperatorSet.ReduceDomain(grayImage, modelPar.modelRegion, out template);
                    HOperatorSet.CreateNccModel(template,
                                                (HTuple)"auto",
                                                ((HTuple)modelPar.startAngle).TupleRad(),
                                                ((HTuple)modelPar.angleRange).TupleRad(),
                                                (HTuple)("auto"),
                                                (HTuple)modelPar.polarity,
                                                out modelPar.modelID);
                }
            }
            catch
            {
                MessageBox.Show("状态：" + "特征过少，或者参数异常,无法完成训练", "提示");
                return false;
            }

            grayImage.Dispose();
            template.Dispose();
            return true;
        }

        /// <summary>
        /// 查找模板
        /// </summary>
        /// <param name="winControl">显示窗口</param>
        /// <param name="image">要查找的图片</param>
        /// <param name="modelPar">模板参数</param>
        /// <param name="resultRow">返回row</param>
        /// <param name="resultColumn">返回column</param>
        /// <param name="resultAngle">返回angle</param>
        /// <param name="resultScores">返回分数</param>
        public static void FindModel(HalconDisplayWindow winControl, HObject image, ModelParameter modelPar, out HTuple resultRow, out HTuple resultColumn, out HTuple resultAngle, out HTuple resultScores)
        {
            if (image == null)
            {
                resultRow = 0; resultColumn = 0; resultAngle = 0; resultScores = 0;
                return;
            }

            winControl.Disp_Image(image);
            HObject findImage;
            HOperatorSet.GenEmptyObj(out findImage);
            findImage.Dispose();
            if (modelPar.findRegionEnable && modelPar.findModelRegion != null)
            {//有搜索范围
                HOperatorSet.ReduceDomain(image, modelPar.findModelRegion, out findImage);
                if (modelPar.dispFindRegion)
                {
                    winControl.Disp_Region(modelPar.findModelRegion, "blue", "margin");
                }
            }
            else
            {
                findImage = image;
            }
            HTuple count = 0;
            HOperatorSet.CountChannels(image, out count);
            HObject modelRegion;
            HOperatorSet.GenEmptyObj(out modelRegion);
            modelRegion.Dispose();
            try
            {
                if (modelPar.matchMode == MatchMode.BasedShape)
                {
                    HTuple temp;

                    HOperatorSet.FindScaledShapeModel(findImage,
                                                      modelPar.modelID,
                                                      ((HTuple)modelPar.startAngle).TupleRad(),
                                                      ((HTuple)modelPar.angleRange - modelPar.startAngle).TupleRad(),
                                                      (HTuple)modelPar.minScale,
                                                      (HTuple)modelPar.maxScale,
                                                      (HTuple)modelPar.minScore,
                                                      (HTuple)modelPar.matchNum,
                                                      (HTuple)0.5,
                                                      (HTuple)"least_squares",
                                                      (HTuple)0,
                                                      (HTuple)0.9,
                                                      out resultRow,
                                                      out resultColumn,
                                                      out resultAngle,
                                                      out temp,
                                                      out resultScores);

                    if (modelPar.dispModel)
                    {
                        dev_display_shape_matching_results(winControl, modelPar.modelID, "red", resultRow, resultColumn, resultAngle, 1, 1, 0);
                    }
                }
                else
                {
                    if (count > 1)
                    {
                        HOperatorSet.Rgb1ToGray(findImage, out findImage);
                    }
                    HOperatorSet.FindNccModel(findImage,
                                              (HTuple)modelPar.modelID,
                                              ((HTuple)modelPar.startAngle).TupleRad(),
                                              ((HTuple)modelPar.angleRange - modelPar.startAngle).TupleRad(),
                                              (HTuple)modelPar.minScore,
                                              (HTuple)modelPar.matchNum,
                                              (HTuple)0.5,
                                              (HTuple)"true",
                                              (HTuple)0,
                                              out resultRow,
                                              out resultColumn,
                                              out resultAngle,
                                              out resultScores);
                    if (modelPar.dispModel)
                    {
                        dev_display_ncc_matching_results(winControl, modelPar.modelID, "red", resultRow, resultColumn, resultAngle, 0);
                    }
                }
            }
            catch (Exception)
            {
                CreateModel(ref modelPar);
                if (modelPar.matchMode == MatchMode.BasedShape)
                {
                    HTuple temp;

                    HOperatorSet.FindScaledShapeModel(findImage,
                                                      modelPar.modelID,
                                                      ((HTuple)modelPar.startAngle).TupleRad(),
                                                      ((HTuple)modelPar.angleRange - modelPar.startAngle).TupleRad(),
                                                      (HTuple)modelPar.minScale,
                                                      (HTuple)modelPar.maxScale,
                                                      (HTuple)modelPar.minScore,
                                                      (HTuple)modelPar.matchNum,
                                                      (HTuple)0.5,
                                                      (HTuple)"least_squares",
                                                      (HTuple)0,
                                                      (HTuple)0.9,
                                                      out resultRow,
                                                      out resultColumn,
                                                      out resultAngle,
                                                      out temp,
                                                      out resultScores);
                    if (modelPar.dispModel)
                    {
                        dev_display_shape_matching_results(winControl, modelPar.modelID, "red", resultRow, resultColumn, resultAngle, 1, 1, 0);
                    }
                }
                else
                {
                    if (count > 1)
                    {
                        HOperatorSet.Rgb1ToGray(findImage, out findImage);
                    }
                    HOperatorSet.FindNccModel(findImage,
                                              (HTuple)modelPar.modelID,
                                              ((HTuple)modelPar.startAngle).TupleRad(),
                                              ((HTuple)modelPar.angleRange - modelPar.startAngle).TupleRad(),
                                              (HTuple)modelPar.minScore,
                                              (HTuple)modelPar.matchNum,
                                              (HTuple)0.5,
                                              (HTuple)"true",
                                              (HTuple)0,
                                              out resultRow,
                                              out resultColumn,
                                              out resultAngle,
                                              out resultScores);
                    if (modelPar.dispModel)
                    {
                        dev_display_ncc_matching_results(winControl, modelPar.modelID, "red", resultRow, resultColumn, resultAngle, 0);
                    }
                }
            }
        }

        private static void get_hom_mat2d_from_matching_result(HTuple hv_Row, HTuple hv_Column, HTuple hv_Angle, HTuple hv_ScaleR, HTuple hv_ScaleC, out HTuple hv_HomMat2D)
        {
            // Local control variables

            HTuple hv_HomMat2DIdentity = new HTuple();
            HTuple hv_HomMat2DScale = new HTuple(), hv_HomMat2DRotate = new HTuple();
            // Initialize local and output iconic variables
            hv_HomMat2D = new HTuple();
            try
            {
                //This procedure calculates the transformation matrix for the model contours
                //from the results of Shape-Based Matching.
                //
                hv_HomMat2DIdentity.Dispose();
                HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                hv_HomMat2DScale.Dispose();
                HOperatorSet.HomMat2dScale(hv_HomMat2DIdentity, hv_ScaleR, hv_ScaleC, 0, 0,
                    out hv_HomMat2DScale);
                hv_HomMat2DRotate.Dispose();
                HOperatorSet.HomMat2dRotate(hv_HomMat2DScale, hv_Angle, 0, 0, out hv_HomMat2DRotate);
                hv_HomMat2D.Dispose();
                HOperatorSet.HomMat2dTranslate(hv_HomMat2DRotate, hv_Row, hv_Column, out hv_HomMat2D);

                hv_HomMat2DIdentity.Dispose();
                hv_HomMat2DScale.Dispose();
                hv_HomMat2DRotate.Dispose();

                return;
            }
            catch
            {
                hv_HomMat2DIdentity.Dispose();
                hv_HomMat2DScale.Dispose();
                hv_HomMat2DRotate.Dispose();
            }
        }

        /// <summary>
        /// 显示shape模板(halcon算子)
        /// </summary>
        /// <param name="winControl"></param>
        /// <param name="hv_ModelID"></param>
        /// <param name="hv_Color"></param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Angle"></param>
        /// <param name="hv_ScaleR"></param>
        /// <param name="hv_ScaleC"></param>
        /// <param name="hv_Model"></param>
        public static void dev_display_shape_matching_results(HalconDisplayWindow winControl, HTuple hv_ModelID, HTuple hv_Color, HTuple hv_Row, HTuple hv_Column, HTuple hv_Angle, HTuple hv_ScaleR, HTuple hv_ScaleC, HTuple hv_Model)
        {
            // Local iconic variables

            HObject ho_ClutterRegion = null, ho_ModelContours = null;
            HObject ho_ContoursAffinTrans = null, ho_RegionAffineTrans = null;

            // Local control variables

            HTuple hv_UseClutter = new HTuple(), hv_UseClutter0 = new HTuple();
            HTuple hv_HomMat2D = new HTuple(), hv_ClutterContrast = new HTuple();
            HTuple hv_Index = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_NumMatches = new HTuple(), hv_GenParamValue = new HTuple();
            HTuple hv_HomMat2DInvert = new HTuple(), hv_Match = new HTuple();
            HTuple hv_HomMat2DTranslate = new HTuple(), hv_HomMat2DCompose = new HTuple();
            HTuple hv_Model_COPY_INP_TMP = new HTuple(hv_Model);
            HTuple hv_ScaleC_COPY_INP_TMP = new HTuple(hv_ScaleC);
            HTuple hv_ScaleR_COPY_INP_TMP = new HTuple(hv_ScaleR);

            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_ClutterRegion);
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);
            HOperatorSet.GenEmptyObj(out ho_RegionAffineTrans);
            try
            {
                //
                hv_UseClutter.Dispose();
                hv_UseClutter = "false";
                try
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_ClutterRegion.Dispose(); hv_UseClutter0.Dispose(); hv_HomMat2D.Dispose(); hv_ClutterContrast.Dispose();
                        HOperatorSet.GetShapeModelClutter(out ho_ClutterRegion, hv_ModelID.TupleSelect(
                            0), "use_clutter", out hv_UseClutter0, out hv_HomMat2D, out hv_ClutterContrast);
                    }
                    for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ModelID.TupleLength()
                        )) - 1); hv_Index = (int)hv_Index + 1)
                    {
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            ho_ClutterRegion.Dispose(); hv_UseClutter.Dispose(); hv_HomMat2D.Dispose(); hv_ClutterContrast.Dispose();
                            HOperatorSet.GetShapeModelClutter(out ho_ClutterRegion, hv_ModelID.TupleSelect(
                                hv_Index), "use_clutter", out hv_UseClutter, out hv_HomMat2D, out hv_ClutterContrast);
                        }
                        if ((int)(new HTuple(hv_UseClutter.TupleNotEqual(hv_UseClutter0))) != 0)
                        {
                            throw new HalconException("Shape models are not of the same clutter type");
                        }
                    }
                }
                // catch (Exception)
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                }
                if ((int)(new HTuple(hv_UseClutter.TupleEqual("true"))) != 0)
                {
                    //For clutter-enabled models, the Color tuple should have either
                    //exactly 2 entries, or 2* the number of models. The first color
                    //is used for the match and the second for the clutter region,
                    //respectively.
                    if ((int)((new HTuple((new HTuple(hv_Color.TupleLength())).TupleNotEqual(
                        2 * (new HTuple(hv_ModelID.TupleLength()))))).TupleAnd(new HTuple((new HTuple(hv_Color.TupleLength()
                        )).TupleNotEqual(2)))) != 0)
                    {
                        throw new HalconException("Length of Color does not correspond to models with enabled clutter parameters");
                    }
                }

                hv_NumMatches.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_NumMatches = new HTuple(hv_Row.TupleLength()
                        );
                }
                if ((int)(new HTuple(hv_NumMatches.TupleGreater(0))) != 0)
                {
                    if ((int)(new HTuple((new HTuple(hv_ScaleR_COPY_INP_TMP.TupleLength())).TupleEqual(
                        1))) != 0)
                    {
                        {
                            HTuple ExpTmpOutVar_0;
                            HOperatorSet.TupleGenConst(hv_NumMatches, hv_ScaleR_COPY_INP_TMP, out ExpTmpOutVar_0);
                            hv_ScaleR_COPY_INP_TMP.Dispose();
                            hv_ScaleR_COPY_INP_TMP = ExpTmpOutVar_0;
                        }
                    }
                    if ((int)(new HTuple((new HTuple(hv_ScaleC_COPY_INP_TMP.TupleLength())).TupleEqual(
                        1))) != 0)
                    {
                        {
                            HTuple ExpTmpOutVar_0;
                            HOperatorSet.TupleGenConst(hv_NumMatches, hv_ScaleC_COPY_INP_TMP, out ExpTmpOutVar_0);
                            hv_ScaleC_COPY_INP_TMP.Dispose();
                            hv_ScaleC_COPY_INP_TMP = ExpTmpOutVar_0;
                        }
                    }
                    if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength())).TupleEqual(
                        0))) != 0)
                    {
                        hv_Model_COPY_INP_TMP.Dispose();
                        HOperatorSet.TupleGenConst(hv_NumMatches, 0, out hv_Model_COPY_INP_TMP);
                    }
                    else if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength()
                        )).TupleEqual(1))) != 0)
                    {
                        {
                            HTuple ExpTmpOutVar_0;
                            HOperatorSet.TupleGenConst(hv_NumMatches, hv_Model_COPY_INP_TMP, out ExpTmpOutVar_0);
                            hv_Model_COPY_INP_TMP.Dispose();
                            hv_Model_COPY_INP_TMP = ExpTmpOutVar_0;
                        }
                    }
                    //Redirect all display calls to a buffer window and update the
                    //graphics window only at the end, to speed up the visualization.
                    HOperatorSet.SetWindowParam(winControl.HalconWindow, "flush", "false");
                    for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ModelID.TupleLength()
                        )) - 1); hv_Index = (int)hv_Index + 1)
                    {
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            ho_ModelContours.Dispose();
                            HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelID.TupleSelect(
                                hv_Index), 1);
                        }
                        if ((int)(new HTuple(hv_UseClutter.TupleEqual("true"))) != 0)
                        {
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                ho_ClutterRegion.Dispose(); hv_GenParamValue.Dispose(); hv_HomMat2D.Dispose(); hv_ClutterContrast.Dispose();
                                HOperatorSet.GetShapeModelClutter(out ho_ClutterRegion, hv_ModelID.TupleSelect(
                                    hv_Index), new HTuple(), out hv_GenParamValue, out hv_HomMat2D, out hv_ClutterContrast);
                            }
                            hv_HomMat2DInvert.Dispose();
                            HOperatorSet.HomMat2dInvert(hv_HomMat2D, out hv_HomMat2DInvert);
                        }

                        HTuple end_val56 = hv_NumMatches - 1;
                        HTuple step_val56 = 1;
                        for (hv_Match = 0; hv_Match.Continue(end_val56, step_val56); hv_Match = hv_Match.TupleAdd(step_val56))
                        {
                            if ((int)(new HTuple(hv_Index.TupleEqual(hv_Model_COPY_INP_TMP.TupleSelect(
                                hv_Match)))) != 0)
                            {
                                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                                {
                                    hv_HomMat2DTranslate.Dispose();
                                    get_hom_mat2d_from_matching_result(hv_Row.TupleSelect(hv_Match), hv_Column.TupleSelect(
                                        hv_Match), hv_Angle.TupleSelect(hv_Match), hv_ScaleR_COPY_INP_TMP.TupleSelect(
                                        hv_Match), hv_ScaleC_COPY_INP_TMP.TupleSelect(hv_Match), out hv_HomMat2DTranslate);
                                }
                                ho_ContoursAffinTrans.Dispose();
                                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursAffinTrans,
                                    hv_HomMat2DTranslate);
                                if ((int)(new HTuple(hv_UseClutter.TupleEqual("true"))) != 0)
                                {
                                    hv_HomMat2DCompose.Dispose();
                                    HOperatorSet.HomMat2dCompose(hv_HomMat2DTranslate, hv_HomMat2DInvert,
                                        out hv_HomMat2DCompose);
                                    ho_RegionAffineTrans.Dispose();
                                    HOperatorSet.AffineTransRegion(ho_ClutterRegion, out ho_RegionAffineTrans, hv_HomMat2DCompose, "constant");
                                    if ((int)(new HTuple((new HTuple(hv_Color.TupleLength())).TupleEqual(2))) != 0)
                                    {
                                        winControl.Disp_Region(ho_RegionAffineTrans, "blue", "margin");
                                    }
                                    else
                                    {
                                        winControl.Disp_Region(ho_RegionAffineTrans, "blue", "margin");
                                    }
                                }
                                winControl.Disp_Region(ho_ContoursAffinTrans, "blue", "margin");
                            }
                        }
                    }
                    //Copy the content of the buffer window to the graphics window.
                    HOperatorSet.SetWindowParam(winControl.HalconWindow, "flush", "true");
                    HOperatorSet.FlushBuffer(winControl.HalconWindow);
                }
                ho_ClutterRegion.Dispose();
                ho_ModelContours.Dispose();
                ho_ContoursAffinTrans.Dispose();
                ho_RegionAffineTrans.Dispose();

                hv_Model_COPY_INP_TMP.Dispose();
                hv_ScaleC_COPY_INP_TMP.Dispose();
                hv_ScaleR_COPY_INP_TMP.Dispose();

                hv_UseClutter.Dispose();
                hv_UseClutter0.Dispose();
                hv_HomMat2D.Dispose();
                hv_ClutterContrast.Dispose();
                hv_Index.Dispose();
                hv_Exception.Dispose();
                hv_NumMatches.Dispose();
                hv_GenParamValue.Dispose();
                hv_HomMat2DInvert.Dispose();
                hv_Match.Dispose();
                hv_HomMat2DTranslate.Dispose();
                hv_HomMat2DCompose.Dispose();

                return;
            }
            catch
            {
                ho_ClutterRegion.Dispose();
                ho_ModelContours.Dispose();
                ho_ContoursAffinTrans.Dispose();
                ho_RegionAffineTrans.Dispose();

                hv_Model_COPY_INP_TMP.Dispose();
                hv_ScaleC_COPY_INP_TMP.Dispose();
                hv_ScaleR_COPY_INP_TMP.Dispose();
                hv_UseClutter.Dispose();
                hv_UseClutter0.Dispose();
                hv_HomMat2D.Dispose();
                hv_ClutterContrast.Dispose();
                hv_Index.Dispose();
                hv_Exception.Dispose();
                hv_NumMatches.Dispose();
                hv_GenParamValue.Dispose();
                hv_HomMat2DInvert.Dispose();
                hv_Match.Dispose();
                hv_HomMat2DTranslate.Dispose();
                hv_HomMat2DCompose.Dispose();
            }
        }

        /// <summary>
        /// 显示NCC模板(halcon算子)
        /// </summary>
        /// <param name="winControl"></param>
        /// <param name="hv_ModelID"></param>
        /// <param name="hv_Color"></param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Angle"></param>
        /// <param name="hv_Model"></param>
        public static void dev_display_ncc_matching_results(HalconDisplayWindow winControl, HTuple hv_ModelID, HTuple hv_Color, HTuple hv_Row, HTuple hv_Column, HTuple hv_Angle, HTuple hv_Model)
        {
            // Local iconic variables

            HObject ho_ModelRegion = null, ho_ModelContours = null;
            HObject ho_ContoursAffinTrans = null, ho_Cross = null;

            // Local control variables

            HTuple hv_NumMatches = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Match = new HTuple(), hv_HomMat2DIdentity = new HTuple();
            HTuple hv_HomMat2DRotate = new HTuple(), hv_HomMat2DTranslate = new HTuple();
            HTuple hv_RowTrans = new HTuple(), hv_ColTrans = new HTuple();
            HTuple hv_Model_COPY_INP_TMP = new HTuple(hv_Model);

            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_ModelRegion);
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            try
            {
                //This procedure displays the results of Correlation-Based Matching.
                //
                hv_NumMatches.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_NumMatches = new HTuple(hv_Row.TupleLength());
                }
                if ((int)(new HTuple(hv_NumMatches.TupleGreater(0))) != 0)
                {
                    if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength())).TupleEqual(0))) != 0)
                    {
                        hv_Model_COPY_INP_TMP.Dispose();
                        HOperatorSet.TupleGenConst(hv_NumMatches, 0, out hv_Model_COPY_INP_TMP);
                    }
                    else if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength())).TupleEqual(1))) != 0)
                    {
                        {
                            HTuple ExpTmpOutVar_0;
                            HOperatorSet.TupleGenConst(hv_NumMatches, hv_Model_COPY_INP_TMP, out ExpTmpOutVar_0);
                            hv_Model_COPY_INP_TMP.Dispose();
                            hv_Model_COPY_INP_TMP = ExpTmpOutVar_0;
                        }
                    }
                    for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ModelID.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                    {
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            ho_ModelRegion.Dispose();
                            HOperatorSet.GetNccModelRegion(out ho_ModelRegion, hv_ModelID.TupleSelect(hv_Index));
                        }
                        ho_ModelContours.Dispose();
                        HOperatorSet.GenContourRegionXld(ho_ModelRegion, out ho_ModelContours, "border_holes");

                        HTuple end_val13 = hv_NumMatches - 1;
                        HTuple step_val13 = 1;
                        for (hv_Match = 0; hv_Match.Continue(end_val13, step_val13); hv_Match = hv_Match.TupleAdd(step_val13))
                        {
                            if ((int)(new HTuple(hv_Index.TupleEqual(hv_Model_COPY_INP_TMP.TupleSelect(hv_Match)))) != 0)
                            {
                                hv_HomMat2DIdentity.Dispose();
                                HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                                {
                                    hv_HomMat2DRotate.Dispose();
                                    HOperatorSet.HomMat2dRotate(hv_HomMat2DIdentity, hv_Angle.TupleSelect(hv_Match), 0, 0, out hv_HomMat2DRotate);
                                }
                                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                                {
                                    hv_HomMat2DTranslate.Dispose();
                                    HOperatorSet.HomMat2dTranslate(hv_HomMat2DRotate, hv_Row.TupleSelect(hv_Match), hv_Column.TupleSelect(hv_Match), out hv_HomMat2DTranslate);
                                }
                                ho_ContoursAffinTrans.Dispose();
                                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursAffinTrans, hv_HomMat2DTranslate);

                                winControl.Disp_Region(ho_ContoursAffinTrans, "red", "margin");
                                hv_RowTrans.Dispose(); hv_ColTrans.Dispose();
                                HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, 0, 0, out hv_RowTrans, out hv_ColTrans);
                                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                                {
                                    ho_Cross.Dispose();
                                    HOperatorSet.GenCrossContourXld(out ho_Cross, hv_RowTrans, hv_ColTrans, 6, hv_Angle.TupleSelect(hv_Match));
                                }
                                winControl.Disp_Region(ho_Cross, "red", "margin");
                            }
                        }
                    }
                }
                ho_ModelRegion.Dispose();
                ho_ModelContours.Dispose();
                ho_ContoursAffinTrans.Dispose();
                ho_Cross.Dispose();

                hv_Model_COPY_INP_TMP.Dispose();
                hv_NumMatches.Dispose();
                hv_Index.Dispose();
                hv_Match.Dispose();
                hv_HomMat2DIdentity.Dispose();
                hv_HomMat2DRotate.Dispose();
                hv_HomMat2DTranslate.Dispose();
                hv_RowTrans.Dispose();
                hv_ColTrans.Dispose();

                return;
            }
            catch
            {
                ho_ModelRegion.Dispose();
                ho_ModelContours.Dispose();
                ho_ContoursAffinTrans.Dispose();
                ho_Cross.Dispose();

                hv_Model_COPY_INP_TMP.Dispose();
                hv_NumMatches.Dispose();
                hv_Index.Dispose();
                hv_Match.Dispose();
                hv_HomMat2DIdentity.Dispose();
                hv_HomMat2DRotate.Dispose();
                hv_HomMat2DTranslate.Dispose();
                hv_RowTrans.Dispose();
                hv_ColTrans.Dispose();
            }
        }

        /// <summary>
        /// 创建箭头
        /// </summary>
        /// <param name="ho_Arrow">箭头区域</param>
        /// <param name="hv_Row1">起始坐标row</param>
        /// <param name="hv_Column1">起始坐标col</param>
        /// <param name="hv_Row2">结束坐标row</param>
        /// <param name="hv_Column2">结束坐标col</param>
        /// <param name="hv_HeadLength">箭头长度</param>
        /// <param name="hv_HeadWidth">箭头宽度</param>
        public static void Gen_Arrow_Contour_XLD(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
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

        /// <summary>
        /// 卡尺测量
        /// </summary>
        /// <param name="winControl">显示控件</param>
        /// <param name="measure">卡尺参数</param>
        /// <param name="image">输入图像</param>
        /// <param name="_OutShapeRegion">返回的找到的边</param>
        /// <param name="_OutShapeParam">返回的找到的边的参数</param>
        public static void CaliperMeasure(HalconDisplayWindow winControl, MeasureParam measure, HObject image, out HObject _OutShapeRegion, out HTuple _OutShapeParam)
        {
            try
            {
                if (measure.InputShapeParam == null || image == null)
                {
                    _OutShapeParam = new HTuple(0, 0, 0, 0, 0, 0, 0);
                    HOperatorSet.GenEmptyObj(out _OutShapeRegion);
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
                winControl?.Disp_Image(image);
                HOperatorSet.GetImageSize(image, out hv_Width, out hv_Height);
                //设置计量对象的图像大小
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);

                //------------判断参数是否合法------------
                HObject OldRegion = new HObject();
                HOperatorSet.GenEmptyObj(out OldRegion);
                OldRegion.Dispose();
                if (measure.Shape == MeasureShapes.line)
                {
                    try
                    {
                        Gen_Arrow_Contour_XLD(out OldRegion, measure.InputShapeParam.TupleSelect(0), measure.InputShapeParam.TupleSelect(1), measure.InputShapeParam.TupleSelect(2), measure.InputShapeParam.TupleSelect(3), 10, 10);

                        if (measure.IsDispCaliper)
                        {
                            HTuple hv_CenterRow = new HTuple(), hv_CenterCol = new HTuple();
                            HTuple hv_DirectionRow = new HTuple();
                            HTuple hv_DirectionCol = new HTuple();
                            //计算该直线的中点
                            hv_CenterRow.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_CenterRow = (measure.InputShapeParam.TupleSelect(0) + measure.InputShapeParam.TupleSelect(2)) / 2;
                            }
                            hv_CenterCol.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_CenterCol = (measure.InputShapeParam.TupleSelect(1) + measure.InputShapeParam.TupleSelect(3)) / 2;
                            }

                            HTuple ccrow = (hv_CenterRow + measure.InputShapeParam.TupleSelect(2)) / 2;
                            HTuple cccol = (hv_CenterCol + measure.InputShapeParam.TupleSelect(3)) / 2;

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
                            winControl?.Disp_Region(vertical.Clone(), "red", "margin");
                            vertical.Dispose();
                        }
                    }
                    catch { _OutShapeParam = new HTuple(0, 0, 0, 0); return; }
                }
                else if (measure.Shape == MeasureShapes.circle)
                {
                    try
                    {
                        HOperatorSet.GenCircle(out OldRegion, measure.InputShapeParam.TupleSelect(0), measure.InputShapeParam.TupleSelect(1), measure.InputShapeParam.TupleSelect(2));
                    }
                    catch { _OutShapeParam = new HTuple(0, 0, 0); return; }
                }
                else if (measure.Shape == MeasureShapes.rectangle2)
                {
                    try
                    {
                        HOperatorSet.GenRectangle2(out OldRegion, measure.InputShapeParam.TupleSelect(0), measure.InputShapeParam.TupleSelect(1), measure.InputShapeParam.TupleSelect(2), measure.InputShapeParam.TupleSelect(3), measure.InputShapeParam.TupleSelect(4));
                    }
                    catch { _OutShapeParam = new HTuple(0, 0, 0, 0, 0); return; }
                }
                else if (measure.Shape == MeasureShapes.ellipse)
                {
                    try
                    {
                        HOperatorSet.GenEllipse(out OldRegion, measure.InputShapeParam.TupleSelect(0), measure.InputShapeParam.TupleSelect(1), measure.InputShapeParam.TupleSelect(2), measure.InputShapeParam.TupleSelect(3), measure.InputShapeParam.TupleSelect(4));
                    }
                    catch { _OutShapeParam = new HTuple(0, 0, 0, 0, 0); return; }
                }
                //--------------------------------------
                if (measure.IsDispInputRegion)
                {
                    winControl?.Disp_Region(OldRegion.Clone(), "turquoise", "margin");
                }

                OldRegion.Dispose();
                //添加线模型
                hv_Index.Dispose();
                HOperatorSet.AddMetrologyObjectGeneric(hv_MetrologyHandle, new HTuple(measure.Shape.ToString()), measure.InputShapeParam, 20, 5, 1, 30, new HTuple(), new HTuple(), out hv_Index);
                //all 全部    positive 黑到白(暗到亮)    'negative'白到黑(亮到暗)
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_transition", measure.Transition.ToString());
                //指定所需度量区域的数量(卡尺数量  越小卡尺间隔越大)
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_measures", measure.CaliperNumber);
                //每个计量对象成功拟合实例的最大数量
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "num_instances", measure.Num_Instances);
                //西格玛
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_sigma", measure.Sigma);
                //整个卡尺宽度（一半）
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length1", measure.CaliperWidth / 2);
                //单个卡尺的测量宽度
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_length2", measure.SingleCaliperWidth);
                //阈值
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_threshold", measure.AmplitudeThreshold);
                //参数指定要使用的插值类型   双立体
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_interpolation", "bicubic");
                //'all' 全部  'first' 第一个点            last最后一个点
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "measure_select", measure.Select.ToString());
                //找的的最小分数
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, "all", "min_score", measure.Min_Score);
                HObject rgb1Image;
                HOperatorSet.GenEmptyObj(out rgb1Image);
                rgb1Image.Dispose();

                HOperatorSet.Rgb1ToGray(image, out rgb1Image);

                //开始找边
                HOperatorSet.ApplyMetrologyModel(rgb1Image, hv_MetrologyHandle);
                //获取计量模型中计量对象的测量区域和边缘位置的结果。（获取坐标）
                ho_Contours.Dispose(); hv_Row.Dispose(); hv_Column.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_Contours, hv_MetrologyHandle, "all", "all", out hv_Row, out hv_Column);
                if (measure.IsDispCaliper)
                {
                    winControl?.Disp_Region(ho_Contours, "12", "margin");
                }

                //把点显示出来
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, measure.CrossSize, new HTuple(45).TupleRad());
                if (measure.IsDispCross)
                {
                    winControl?.Disp_Region(ho_Cross, "green", "margin");
                }
                //释放测量句柄
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);
                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Row, hv_Column);
                if (measure.Shape == MeasureShapes.line)
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
                else if (measure.Shape == MeasureShapes.circle)
                {
                    HTuple Row, Column, Radius, StartPhi, EndPhi, PointOrder;
                    HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 3, 2, out Row, out Column, out Radius, out StartPhi, out EndPhi, out PointOrder);
                    _OutShapeParam = new HTuple();
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Row;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Column;
                    _OutShapeParam[new HTuple(_OutShapeParam.TupleLength())] = Radius;
                    HOperatorSet.GenCircle(out _OutShapeRegion, Row, Column, Radius);
                }
                else if (measure.Shape == MeasureShapes.rectangle2)
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
                else if (measure.Shape == MeasureShapes.ellipse)
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
                else
                {
                    _OutShapeParam = new HTuple(0, 0, 0, 0, 0, 0, 0);
                }
                winControl?.Disp_Region(_OutShapeRegion, "blue", "margin");
                ho_Contours.Dispose();
                ho_Cross.Dispose();
                ho_Contour.Dispose();
                rgb1Image.Dispose();
                hv_MetrologyHandle.Dispose();
                hv_Index.Dispose();
                hv_Row.Dispose();
                hv_Column.Dispose();
                hv_Nr.Dispose();
                hv_Nc.Dispose();
                hv_Dist.Dispose();

                return;
            }
            catch
            {
                _OutShapeParam = new HTuple(0, 0, 0, 0, 0, 0, 0);
                HOperatorSet.GenEmptyObj(out _OutShapeRegion);
            }
        }

        /// <summary>
        /// 双向箭头
        /// </summary>
        /// <param name="ho_Arrow"></param>
        /// <param name="hv_StartRow"></param>
        /// <param name="hv_StartColumn"></param>
        /// <param name="hv_EndRow"></param>
        /// <param name="hv_EndColumn"></param>
        /// <param name="hv_HeadLength"></param>
        /// <param name="hv_HeadWidth"></param>
        public static void double_sided_arrow(out HObject ho_Arrow, HTuple hv_StartRow, HTuple hv_StartColumn, HTuple hv_EndRow, HTuple hv_EndColumn, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {
            // Local iconic variables

            HObject ho_Arrow1, ho_Arrow2, ho_Region1, ho_Region2;
            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            HOperatorSet.GenEmptyObj(out ho_Arrow2);
            HOperatorSet.GenEmptyObj(out ho_Region1);
            HOperatorSet.GenEmptyObj(out ho_Region2);
            try
            {
                ho_Arrow1.Dispose();
                Gen_Arrow_Contour_XLD(out ho_Arrow1, hv_StartRow, hv_StartColumn, hv_EndRow,
                    hv_EndColumn, hv_HeadLength, hv_HeadWidth);
                ho_Arrow2.Dispose();
                Gen_Arrow_Contour_XLD(out ho_Arrow2, hv_EndRow, hv_EndColumn, hv_StartRow,
                    hv_StartColumn, hv_HeadLength, hv_HeadWidth);
                ho_Region1.Dispose();
                HOperatorSet.GenRegionContourXld(ho_Arrow1, out ho_Region1, "filled");
                ho_Region2.Dispose();
                HOperatorSet.GenRegionContourXld(ho_Arrow2, out ho_Region2, "filled");
                ho_Arrow.Dispose();
                HOperatorSet.Union2(ho_Region1, ho_Region2, out ho_Arrow);
                ho_Arrow1.Dispose();
                ho_Arrow2.Dispose();
                ho_Region1.Dispose();
                ho_Region2.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Arrow1.Dispose();
                ho_Arrow2.Dispose();
                ho_Region1.Dispose();
                ho_Region2.Dispose();

                throw HDevExpDefaultException;
            }
        }

        /// <summary>
        /// 计算矩形四个顶点
        /// </summary>
        /// <param name="ho_Cross"></param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Phi"></param>
        /// <param name="hv_Length1"></param>
        /// <param name="hv_Length2"></param>
        /// <param name="hv_Rows"></param>
        /// <param name="hv_Columns"></param>
        public static void RectangleVertices(out HObject ho_Cross, HTuple hv_Row, HTuple hv_Column, HTuple hv_Phi, HTuple hv_Length1, HTuple hv_Length2, out HTuple hv_Rows, out HTuple hv_Columns)
        {
            // Stack for temporary objects
            HObject[] OTemp = new HObject[20];

            // Local iconic variables

            HObject ho_ROI_0, ho_Cross1, ho_Cross2, ho_Cross3;
            HObject ho_Cross4;

            // Local control variables

            HTuple hv_Cos = new HTuple(), hv_Sin = new HTuple();
            HTuple hv_a = new HTuple(), hv_b = new HTuple(), hv_c = new HTuple();
            HTuple hv_d = new HTuple(), hv_e = new HTuple(), hv_f = new HTuple();
            HTuple hv_g = new HTuple(), hv_h = new HTuple();
            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            HOperatorSet.GenEmptyObj(out ho_Cross1);
            HOperatorSet.GenEmptyObj(out ho_Cross2);
            HOperatorSet.GenEmptyObj(out ho_Cross3);
            HOperatorSet.GenEmptyObj(out ho_Cross4);
            hv_Rows = new HTuple();
            hv_Columns = new HTuple();
            try
            {
                hv_Rows.Dispose();
                hv_Rows = new HTuple();
                hv_Columns.Dispose();
                hv_Columns = new HTuple();
                ho_ROI_0.Dispose();
                HOperatorSet.GenRectangle2(out ho_ROI_0, hv_Row, hv_Column, hv_Phi, hv_Length1,
                    hv_Length2);
                hv_Cos.Dispose();
                HOperatorSet.TupleCos(hv_Phi, out hv_Cos);
                hv_Sin.Dispose();
                HOperatorSet.TupleSin(hv_Phi, out hv_Sin);
                hv_a.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_a = ((-hv_Length1) * hv_Cos) - (hv_Length2 * hv_Sin);
                }
                hv_b.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_b = ((-hv_Length1) * hv_Sin) + (hv_Length2 * hv_Cos);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    ho_Cross1.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross1, hv_Row - hv_b, hv_Column + hv_a,
                        60, hv_Phi);
                }
                if (hv_Rows == null)
                    hv_Rows = new HTuple();
                hv_Rows[new HTuple(hv_Rows.TupleLength())] = hv_Row - hv_b;
                if (hv_Columns == null)
                    hv_Columns = new HTuple();
                hv_Columns[new HTuple(hv_Columns.TupleLength())] = hv_Column + hv_a;
                hv_c.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_c = (hv_Length1 * hv_Cos) - (hv_Length2 * hv_Sin);
                }
                hv_d.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_d = (hv_Length1 * hv_Sin) + (hv_Length2 * hv_Cos);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    ho_Cross2.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross2, hv_Row - hv_d, hv_Column + hv_c,
                        60, hv_Phi);
                }
                if (hv_Rows == null)
                    hv_Rows = new HTuple();
                hv_Rows[new HTuple(hv_Rows.TupleLength())] = hv_Row - hv_d;
                if (hv_Columns == null)
                    hv_Columns = new HTuple();
                hv_Columns[new HTuple(hv_Columns.TupleLength())] = hv_Column + hv_c;
                hv_e.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_e = (hv_Length1 * hv_Cos) + (hv_Length2 * hv_Sin);
                }
                hv_f.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_f = (hv_Length1 * hv_Sin) - (hv_Length2 * hv_Cos);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    ho_Cross3.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross3, hv_Row - hv_f, hv_Column + hv_e,
                        60, hv_Phi);
                }
                if (hv_Rows == null)
                    hv_Rows = new HTuple();
                hv_Rows[new HTuple(hv_Rows.TupleLength())] = hv_Row - hv_f;
                if (hv_Columns == null)
                    hv_Columns = new HTuple();
                hv_Columns[new HTuple(hv_Columns.TupleLength())] = hv_Column + hv_e;
                hv_g.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_g = ((-hv_Length1) * hv_Cos) + (hv_Length2 * hv_Sin);
                }
                hv_h.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_h = ((-hv_Length1) * hv_Sin) - (hv_Length2 * hv_Cos);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    ho_Cross4.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross4, hv_Row - hv_h, hv_Column + hv_g,
                        60, hv_Phi);
                }
                if (hv_Rows == null)
                    hv_Rows = new HTuple();
                hv_Rows[new HTuple(hv_Rows.TupleLength())] = hv_Row - hv_h;
                if (hv_Columns == null)
                    hv_Columns = new HTuple();
                hv_Columns[new HTuple(hv_Columns.TupleLength())] = hv_Column + hv_g;
                ho_Cross.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Cross);
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Cross, ho_Cross1, out ExpTmpOutVar_0);
                    ho_Cross.Dispose();
                    ho_Cross = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Cross, ho_Cross2, out ExpTmpOutVar_0);
                    ho_Cross.Dispose();
                    ho_Cross = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Cross, ho_Cross3, out ExpTmpOutVar_0);
                    ho_Cross.Dispose();
                    ho_Cross = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Cross, ho_Cross4, out ExpTmpOutVar_0);
                    ho_Cross.Dispose();
                    ho_Cross = ExpTmpOutVar_0;
                }

                ho_ROI_0.Dispose();
                ho_Cross1.Dispose();
                ho_Cross2.Dispose();
                ho_Cross3.Dispose();
                ho_Cross4.Dispose();

                hv_Cos.Dispose();
                hv_Sin.Dispose();
                hv_a.Dispose();
                hv_b.Dispose();
                hv_c.Dispose();
                hv_d.Dispose();
                hv_e.Dispose();
                hv_f.Dispose();
                hv_g.Dispose();
                hv_h.Dispose();

                return;
            }
            catch
            {
                ho_ROI_0.Dispose();
                ho_Cross1.Dispose();
                ho_Cross2.Dispose();
                ho_Cross3.Dispose();
                ho_Cross4.Dispose();

                hv_Cos.Dispose();
                hv_Sin.Dispose();
                hv_a.Dispose();
                hv_b.Dispose();
                hv_c.Dispose();
                hv_d.Dispose();
                hv_e.Dispose();
                hv_f.Dispose();
                hv_g.Dispose();
                hv_h.Dispose();
            }
        }

    }
}