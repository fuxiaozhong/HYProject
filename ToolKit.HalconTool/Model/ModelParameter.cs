using System;

using HalconDotNet;

namespace ToolKit.HalconTool.Model
{
    /// <summary>
    /// 模板类型
    /// </summary>
    public enum MatchMode
    {
        /// <summary>
        /// 形状模板
        /// </summary>
        ShapeModel,

        /// <summary>
        /// 灰度模板
        /// </summary>
        GrayModel,
    }

    /// <summary>
    /// 模板参数 可序列化保存
    /// </summary>
    [Serializable]
    public class ModelParameter
    {
        /// <summary>
        /// 模板类型
        /// </summary>
        public MatchMode ModelType;

        /// <summary>
        /// 是否显示匹配到的模板
        /// </summary>
        public bool dispModel = true;

        /// <summary>
        /// 显示搜索范围
        /// </summary>
        public bool dispFindRegion = false;

        /// <summary>
        /// 显示搜索范围
        /// </summary>
        public bool findRegionEnable = false;

        /// <summary>
        ///模板图像(框选的模板图像)
        /// </summary>
        public HObject ModelBaseImage;

        /// <summary>
        /// 模板句柄
        /// </summary>
        public HTuple ModelID = -1;

        /// <summary>
        /// 模板区域
        /// </summary>
        public HObject ModelRegion;

        /// <summary>
        /// 模板图片(创建模板的图像)
        /// </summary>
        public HObject ModelImage;

        /// <summary>
        /// 模板查找区域
        /// </summary>
        public HObject FindModelRegion;

        /// <summary>
        /// 最小匹配分数
        /// </summary>
        public double minScore = 0.5;

        /// <summary>
        /// 匹配个数
        /// </summary>
        public int matchNum = 1;

        /// <summary>
        /// 起始角度
        /// </summary>
        public int AngleStart = -30;

        /// <summary>
        /// 角度范围
        /// </summary>
        public int AngleExtent = 30;

        /// <summary>
        /// 角度步长
        /// </summary>
        public int AngleStep = 1;

        /// <summary>
        /// 对比度
        /// </summary>
        public int Contrast = 30;

        /// <summary>
        /// 极性
        /// </summary>
        public string polarity = "use_polarity";

        /// <summary>
        /// 最小缩放
        /// </summary>
        public double ScaleMin;

        /// <summary>
        /// 最大缩放
        /// </summary>
        public double ScaleMax;

        /// <summary>
        /// 模板中心点Row
        /// </summary>
        public HTuple modelCenterRow;

        /// <summary>
        /// 模板中心点Colimn
        /// </summary>
        public HTuple modelCenterColumn;

        /// <summary>
        /// 模板角度
        /// </summary>
        public HTuple modelCenterPhi;
    }
}