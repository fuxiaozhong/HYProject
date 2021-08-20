using ToolKit.HYControls.HYForm;

namespace ToolKit.HYControls
{
    public class HYInputDialog
    {
        /// <summary>
        /// 输入字符串弹窗
        /// </summary>
        /// <param name="value">弹窗输入的值</param>
        /// <param name="checkEmpty">检查是否为空</param>
        /// <param name="desc">提示</param>
        /// <param name="topMost">输入框是否置顶</param>
        /// <returns>输入状态</returns>
        public static bool InputStringDialog(ref string value, bool checkEmpty = true, string desc = "请输入字符串:", bool topMost = false)
        {
            HYForm_Edit form_Edit = new HYForm_Edit(desc, checkEmpty, "string");
            form_Edit.TopMost = topMost;
            form_Edit.Value = value;
            if (form_Edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                value = form_Edit.Value;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 输入int类型弹窗
        /// </summary>
        /// <param name="value">弹窗输入的值</param>
        /// <param name="checkEmpty">检查是否为空</param>
        /// <param name="desc">提示</param>
        /// <param name="topMost">输入框是否置顶</param>
        /// <returns>输入状态</returns>
        public static bool InputIntegerDialog(ref int value, bool checkEmpty = true, string desc = "请输入数字:", bool topMost = false)
        {
            HYForm_Edit form_Edit = new HYForm_Edit(desc, checkEmpty, "int");
            form_Edit.TopMost = topMost;
            form_Edit.Value = value.ToString();
            if (form_Edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                value = int.Parse(form_Edit.Value);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 输入double类型弹窗
        /// </summary>
        /// <param name="value">弹窗输入的值</param>
        /// <param name="checkEmpty">检查是否为空</param>
        /// <param name="desc">提示</param>
        /// <param name="topMost">输入框是否置顶</param>
        /// <returns>输入状态</returns>
        public static bool InputDoubleDialog(ref double value, bool checkEmpty = true, string desc = "请输入数字:", bool topMost = false)
        {
            HYForm_Edit form_Edit = new HYForm_Edit(desc, checkEmpty, "double");
            form_Edit.TopMost = topMost;
            form_Edit.Value = value.ToString();
            if (form_Edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                value = double.Parse(form_Edit.Value) * 0.0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}