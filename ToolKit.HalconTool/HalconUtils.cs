using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            catch (Exception e)
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

    }
}
