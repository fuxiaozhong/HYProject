using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using HalconDotNet;

namespace ToolKit.DisplayWindow
{
    public partial class DisplayWindow : UserControl
    {
        public DisplayWindow()
        {
            InitializeComponent();
        }

        private HObject ho_image;
        private List<RegionP> Regions = new List<RegionP>();
        private List<CrossPoint> Cross = new List<CrossPoint>();
        private List<MessageP> Message = new List<MessageP>();
        private double ratioWidth, ratioHeight;
        private HTuple ImageWidth = 0, ImageHeight = 0;
        private double x, y;
        private HTuple row1, column1, row2, column2;

        public HWindow HalconWindow
        {
            get { return hWindowControl1.HalconWindow; }
        }

        public HObject GetImage
        {
            get
            {
                if (ho_image == null)
                    return null;
                return ho_image;
            }
        }

        private void 自适应ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ho_image == null)
                return;
            Adaptive_Display();
        }

        /// <summary>
        /// 自适应显示
        /// </summary>
        private void Adaptive_Display()
        {
            try
            {
                if (ho_image == null)
                    return;

                ratioWidth = (1.0) * ImageWidth / hWindowControl1.Width;
                ratioHeight = (1.0) * ImageHeight / hWindowControl1.Height;
                if (ratioWidth >= ratioHeight)
                {
                    row1 = -(1.0) * ((hWindowControl1.Height * ratioWidth) - ImageHeight) / 2;
                    column1 = 0;
                    row2 = ((hWindowControl1.Height * ratioWidth) - ImageHeight) / 2 + ImageHeight;
                    column2 = ImageWidth;
                }
                else
                {
                    row1 = 0;
                    column1 = -(1.0) * ((hWindowControl1.Width * ratioHeight) - ImageWidth) / 2;
                    row2 = ImageHeight;
                    column2 = column1 + hWindowControl1.Width * ratioHeight;
                }
                HOperatorSet.SetDraw(HalconWindow, "margin");
                HOperatorSet.ClearWindow(HalconWindow);
                HOperatorSet.SetPart(hWindowControl1.HalconWindow, row1, column1, row2, column2);//顯示整個圖像
                Disp();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 保存团团
        /// </summary>
        /// <param name="path"></param>
        /// <param name="format"></param>
        public void SaveImage(string path, HSaveImageFormat format)
        {
            if (ho_image == null)
                return;
            HOperatorSet.WriteImage(ho_image, format.ToString(), 0, path);
        }

        public void SaveImage(string patn, string camName, bool ok = true, bool savedump = true, bool savebmp = true)
        {
            if (!Directory.Exists(patn))
            {
                Directory.CreateDirectory(patn);
            }
            if (!Directory.Exists(patn + "\\" + camName))
            {
                Directory.CreateDirectory(patn + "\\" + camName);
            }
            if (savedump)
            {
                if (!Directory.Exists(patn + "\\" + camName + "\\截图"))
                {
                    Directory.CreateDirectory(patn + "\\" + camName + "\\截图");
                }
                if (ok)
                {
                    if (!Directory.Exists(patn + "\\" + camName + "\\截图\\OK"))
                    {
                        Directory.CreateDirectory(patn + "\\" + camName + "\\截图\\OK");
                    }
                    SaveDumpImage(patn + "\\" + camName + "\\截图\\OK" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), HSaveImageFormat.png);

                }
                else
                {
                    if (!Directory.Exists(patn + "\\" + camName + "\\截图\\NG"))
                    {
                        Directory.CreateDirectory(patn + "\\" + camName + "\\截图\\NG");
                    }
                    SaveDumpImage(patn + "\\" + camName + "\\截图\\NG" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), HSaveImageFormat.png);
                }
            }

            if (savebmp)
            {
                if (!Directory.Exists(patn + "\\" + camName + "\\原图"))
                {
                    Directory.CreateDirectory(patn + "\\" + camName + "\\原图");
                }
                if (ok)
                {
                    if (!Directory.Exists(patn + "\\" + camName + "\\原图\\OK"))
                    {
                        Directory.CreateDirectory(patn + "\\" + camName + "\\原图\\OK");
                    }
                    SaveImage(patn + "\\" + camName + "\\原图\\OK" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), HSaveImageFormat.png);
                }
                else
                {
                    if (!Directory.Exists(patn + "\\" + camName + "\\原图\\NG"))
                    {
                        Directory.CreateDirectory(patn + "\\" + camName + "\\原图\\NG");
                    }
                    SaveImage(patn + "\\" + camName + "\\原图\\NG" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), HSaveImageFormat.png);
                }

            }



        }


        /// <summary>
        /// 保存截图
        /// </summary>
        /// <param name="path"></param>
        /// <param name="format"></param>
        public void SaveDumpImage(string path, HSaveImageFormat format)
        {
            if (ho_image == null)
                return;
            HObject dumpImage = new HObject();
            HOperatorSet.GenEmptyObj(out dumpImage);
            dumpImage.Dispose();
            HOperatorSet.DumpWindowImage(out dumpImage, HalconWindow);
            HOperatorSet.WriteImage(dumpImage, format.ToString(), 0, path);
            dumpImage.Dispose();
        }

        /// <summary>
        /// 显示图片(重置)
        /// </summary>
        /// <param name="image"></param>
        public void Disp_Image(HObject image)
        {
            lock (this)
            {
                try
                {
                    if (image == null)
                        return;
                    //清空十字架
                    Cross.Clear();
                    //清空区域
                    foreach (RegionP item in Regions)
                    {
                        item.Region.Dispose();
                    }
                    Regions.Clear();
                    Message.Clear();

                    if (ho_image == null)
                    {
                        HOperatorSet.GenEmptyObj(out ho_image);
                        ho_image.Dispose();
                        HOperatorSet.CopyImage(image, out ho_image);
                    }
                    else
                    {
                        ho_image.Dispose();
                        HOperatorSet.CopyImage(image, out ho_image);
                    }
                    HTuple _ImageWidth, _ImageHeight;

                    HOperatorSet.GetImageSize(ho_image, out _ImageWidth, out _ImageHeight);

                    //uiLabel1.Text = "Size:" + _ImageWidth.D + "*" + _ImageHeight.D;

                    if (ImageWidth.D == _ImageWidth.D || ImageHeight.D == _ImageHeight.D)
                    {
                        HOperatorSet.ClearWindow(HalconWindow);
                        HOperatorSet.DispObj(ho_image, hWindowControl1.HalconWindow);
                        return;
                    }
                    ImageWidth = _ImageWidth;
                    ImageHeight = _ImageHeight;
                    ratioWidth = (1.0) * _ImageWidth / hWindowControl1.Width;
                    ratioHeight = (1.0) * _ImageHeight / hWindowControl1.Height;
                    if (ratioWidth >= ratioHeight)
                    {
                        row1 = -(1.0) * ((hWindowControl1.Height * ratioWidth) - _ImageHeight) / 2;
                        column1 = 0;
                        row2 = ((hWindowControl1.Height * ratioWidth) - _ImageHeight) / 2 + _ImageHeight;
                        column2 = _ImageWidth;
                    }
                    else
                    {
                        row1 = 0;
                        column1 = -(1.0) * ((hWindowControl1.Width * ratioHeight) - _ImageWidth) / 2;
                        row2 = _ImageHeight;
                        column2 = column1 + hWindowControl1.Width * ratioHeight;
                    }
                    HOperatorSet.SetDraw(HalconWindow, "margin");
                    HOperatorSet.ClearWindow(HalconWindow);
                    HOperatorSet.SetPart(hWindowControl1.HalconWindow, row1, column1, row2, column2);//顯示整個圖像
                    HOperatorSet.DispObj(ho_image, hWindowControl1.HalconWindow);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 内部重新显示
        /// </summary>
        private void Disp()
        {
            if (ho_image != null)
            {
                lock (ho_image)
                {
                    try
                    {
                        HOperatorSet.DispObj(ho_image, HalconWindow);
                        HOperatorSet.SetDraw(HalconWindow, "margin");
                        foreach (RegionP item in Regions)
                        {
                            HOperatorSet.SetDraw(HalconWindow, item.Draw);

                            if (Regex.IsMatch(item.ColorName, @"^[0-9]+$"))
                            {
                                HOperatorSet.SetColored(HalconWindow, int.Parse(item.ColorName));
                            }
                            else
                            {
                                HOperatorSet.SetColor(HalconWindow, new HTuple(item.ColorName));
                            }
                            HOperatorSet.DispObj(item.Region, HalconWindow);
                        }
                        foreach (CrossPoint item in Cross)
                        {
                            if (Regex.IsMatch(item.ColorName, @"^[0-9]+$"))
                            {
                                HOperatorSet.SetColored(HalconWindow, int.Parse(item.ColorName));
                            }
                            else
                            {
                                HOperatorSet.SetColor(HalconWindow, new HTuple(item.ColorName));
                            }
                            HOperatorSet.DispCross(HalconWindow, item.row, item.column, item.size, 0);
                        }
                        if (!拖动缩放屏蔽文字ToolStripMenuItem.Checked)
                        {
                            foreach (MessageP item in Message)
                            {
                                Disp_message(HalconWindow, item.message, "image", new HTuple(item.row), new HTuple(item.column), new HTuple(item.colorName), "false", new HTuple(item.fontSize));
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// 打开图像
        /// </summary>
        /// <returns></returns>
        public HObject Open_Image()
        {
            HObject image;
            HOperatorSet.GenEmptyObj(out image);
            image.Dispose();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件(*.jpg,*.bmp,*.png)|*.jpg;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.ReadImage(out image, openFileDialog.FileName);
                return image;
            }
            return null;
        }

        /// <summary>
        /// 打开对话框保存图像
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public bool Save_Image(HObject image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;
                string fil = name.Substring(name.LastIndexOf('.') + 1);
                HOperatorSet.WriteImage(image, fil, 0, name);

                return true;
            }
            return false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ho_image == null)
                return;
            CenterCross(ImageHeight, ImageWidth);
        }

        private void 显示中心线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ho_image == null)
                return;

            timer1.Enabled = 显示中心线ToolStripMenuItem.Checked;
            Disp();
        }

        /// <summary>
        /// 设置线宽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in 线宽ToolStripMenuItem.DropDownItems)
            {
                if (item.Text == toolStripItem.Text)
                {
                    item.Checked = true;
                    HOperatorSet.SetLineWidth(HalconWindow, int.Parse(item.Text));
                    Disp();
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        /// <summary>
        /// 显示区域
        /// </summary>
        /// <param name="region"></param>
        /// <param name="colorName"></param>
        public void Disp_Region(HObject region, string colorName, string draw)
        {
            if (draw != "fill" && draw != "margin")
            {
                draw = "margin";
            }
            this.Regions.Add(new RegionP()
            {
                Region = region.Clone(),
                ColorName = colorName,
                Draw = new HTuple(draw)
            });
            if (Regex.IsMatch(colorName, @"^[0-9]+$"))
            {
                HOperatorSet.SetColored(HalconWindow, int.Parse(colorName));
            }
            else
            {
                HOperatorSet.SetColor(HalconWindow, new HTuple(colorName));
            }
            HOperatorSet.SetDraw(HalconWindow, new HTuple(draw));

            HOperatorSet.DispObj(region, HalconWindow);
        }

        /// <summary>
        /// 显示十字架
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="size"></param>
        /// <param name="angle"></param>
        /// <param name="colorName"></param>
        public void Disp_Cross(HTuple row, HTuple column, HTuple size, string colorName)
        {
            this.Cross.Add(new CrossPoint()
            {
                row = row,
                column = column,
                size = size,
                ColorName = colorName
            });
            if (Regex.IsMatch(colorName, @"^[0-9]+$"))
            {
                HOperatorSet.SetColored(HalconWindow, int.Parse(colorName));
            }
            else
            {
                HOperatorSet.SetColor(HalconWindow, new HTuple(colorName));
            }
            HOperatorSet.DispCross(HalconWindow, row, column, size, 0);
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fontSize"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="colorName"></param>
        public void Disp_Message(string message, int fontSize, int row, int column, string colorName)
        {
            Message.Add(new MessageP()
            {
                message = message,
                fontSize = fontSize,
                row = row,
                colorName = colorName,
                column = column
            });
            Disp_message(HalconWindow, message, "image", new HTuple(row), new HTuple(column), new HTuple(colorName), "false", new HTuple(fontSize));
        }

        private void HWindowControl1_HMouseWheel(object sender, HMouseEventArgs e)
        {
            try
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    if (ho_image == null)
                        return;
                    Rectangle rec = new Rectangle();
                    rec = hWindowControl1.ImagePart;

                    if (e.Delta > 0)
                    {
                        rec.Width = (int)(rec.Width * 0.8);
                        rec.Height = (int)(rec.Height * 0.8);
                        int org_x = (int)((double)rec.X + (e.X - (double)rec.X) * 0.2);//
                        int org_y = (int)((double)rec.Y + (e.Y - (double)rec.Y) * 0.2);//
                        rec.X = org_x;
                        rec.Y = org_y;
                        hWindowControl1.ImagePart = rec;
                    }
                    else if (e.Delta < 0)
                    {
                        rec.Width = (int)(rec.Width * 1.2);
                        rec.Height = (int)(rec.Height * 1.2);
                        int org_x = (int)((double)rec.X - (e.X - (double)rec.X) * 0.2);
                        int org_y = (int)((double)rec.Y - (e.Y - (double)rec.Y) * 0.2);
                        rec.X = org_x;
                        rec.Y = org_y;
                        hWindowControl1.ImagePart = rec;
                    }
                    hWindowControl1.HalconWindow.ClearWindow();
                    Disp();
                    hWindowControl1.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        private void HWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {
            try
            {
                if (ho_image == null)
                    return;

                if (e.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    HOperatorSet.GetPart(hWindowControl1.HalconWindow, out row1, out column1, out row2, out column2);//顯示整個圖像
                    HOperatorSet.SetPart(hWindowControl1.HalconWindow, row1 - e.Y + y, column1 - e.X + x, row2 - e.Y + y, column2 - e.X + x);//顯示整個圖像

                    hWindowControl1.HalconWindow.ClearWindow();
                    Disp();
                }

                try
                {
                    string value = "Size:" + ImageWidth.D.ToString("0") + "*" + ImageHeight.D.ToString("0") + "";

                    int button_state;
                    double positionX, positionY;
                    string str_value;
                    string str_position;
                    bool _isXOut = true, _isYOut = true;
                    HTuple channel_count;

                    HOperatorSet.CountChannels(ho_image, out channel_count);
                    //form_ImageZoom.label_Channel.Text = channel_count.ToString() + " 通道";
                    HalconWindow.GetMpositionSubPix(out positionY, out positionX, out button_state);
                    str_position = String.Format("\nRow: {0:0000}\nColumn: {1:0000}", positionY, positionX);
                    value += str_position;
                    //form_ImageZoom.label_Row.Text = positionY.ToString("0");
                    //form_ImageZoom.label_Column.Text = positionX.ToString("0");
                    _isXOut = (positionX < 0 || positionX >= ImageWidth);
                    _isYOut = (positionY < 0 || positionY >= ImageHeight);

                    if (!_isXOut && !_isYOut)
                    {
                        if ((int)channel_count == 1)
                        {
                            HTuple grayVal;
                            HOperatorSet.GetGrayval(ho_image, (int)positionY, (int)positionX, out grayVal);
                            str_value = String.Format("\nVal: {0:000}", grayVal.D);
                            value += str_value;
                        }
                        else if ((int)channel_count == 3)
                        {
                            HTuple grayValRed = new HTuple(0), grayValGreen = new HTuple(0), grayValBlue = new HTuple(0);
                            HObject _RedChannel, _GreenChannel, _BlueChannel;

                            HOperatorSet.AccessChannel(ho_image, out _RedChannel, 1);
                            HOperatorSet.AccessChannel(ho_image, out _GreenChannel, 2);
                            HOperatorSet.AccessChannel(ho_image, out _BlueChannel, 3);

                            HOperatorSet.GetGrayval(_RedChannel, (int)positionY, (int)positionX, out grayValRed);
                            HOperatorSet.GetGrayval(_GreenChannel, (int)positionY, (int)positionX, out grayValGreen);
                            HOperatorSet.GetGrayval(_BlueChannel, (int)positionY, (int)positionX, out grayValBlue);

                            _RedChannel.Dispose();
                            _GreenChannel.Dispose();
                            _BlueChannel.Dispose();

                            str_value = String.Format("\nR: {0:000}  G: {1:000}  B: {2:000}", grayValRed, grayValGreen, grayValBlue);
                            value += str_value;
                        }
                        else
                        {
                            str_value = "";
                        }
                    }
                    this.Text = value;
                }
                catch
                {
                    //不处理
                }

                if (form_ImageZoom != null && !form_ImageZoom.IsDisposed && form_ImageZoom.Visible == true && form_ImageZoom.checkBox1.Checked == true)
                    Refresh_the_zoom();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 中心线
        /// </summary>
        /// <param name="hv_Height"></param>
        /// <param name="hv_Width"></param>
        private void CenterCross(HTuple hv_Height, HTuple hv_Width)
        {
            HOperatorSet.SetDraw(HalconWindow, "margin");
            HOperatorSet.SetColor(HalconWindow, "blue");

            HObject ho_Cross, ho_Rectangle, ho_RegionLines1;
            HObject ho_RegionLines2, ho_RegionLines3, ho_RegionLines4;
            HObject ho_RegionUnion, ho_RegionUnion1, ho_RegionUnion2;
            HObject ho_RegionUnion3;

            // Local control variables

            HTuple hv_CenterRow = new HTuple(), hv_CenterColumn = new HTuple();
            // Initialize local and output iconic variables
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_RegionLines1);
            HOperatorSet.GenEmptyObj(out ho_RegionLines2);
            HOperatorSet.GenEmptyObj(out ho_RegionLines3);
            HOperatorSet.GenEmptyObj(out ho_RegionLines4);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion1);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion2);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion3);
            hv_CenterRow.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_CenterRow = hv_Height / 2;
            }
            hv_CenterColumn.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_CenterColumn = hv_Width / 2;
            }
            ho_Cross.Dispose();
            HTuple lenght = 0;

            if (hv_CenterRow > hv_CenterColumn)
            {
                lenght = hv_CenterColumn * 0.1;
            }
            else
            {
                lenght = hv_CenterRow * 0.1;
            }

            HOperatorSet.GenCrossContourXld(out ho_Cross, hv_CenterRow, hv_CenterColumn, lenght, 0);
            ho_Rectangle.Dispose();
            HOperatorSet.GenRectangle2(out ho_Rectangle, hv_CenterRow, hv_CenterColumn, 0, lenght / 1.8, lenght / 1.8);
            HOperatorSet.DispObj(ho_Rectangle, HalconWindow);
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                ho_RegionLines1.Dispose();
                //上
                HOperatorSet.GenRegionLine(out ho_RegionLines1, 0, hv_CenterColumn, hv_CenterRow - lenght, hv_CenterColumn);
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                ho_RegionLines2.Dispose();
                HOperatorSet.GenRegionLine(out ho_RegionLines2, hv_CenterRow + lenght, hv_CenterColumn, hv_Height, hv_CenterColumn);
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                ho_RegionLines3.Dispose();
                HOperatorSet.GenRegionLine(out ho_RegionLines3, hv_CenterRow, 0, hv_CenterRow, hv_CenterColumn - lenght);
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                ho_RegionLines4.Dispose();
                HOperatorSet.GenRegionLine(out ho_RegionLines4, hv_CenterRow, hv_CenterColumn + lenght, hv_CenterRow, hv_Width);
            }
            ho_RegionUnion.Dispose();
            HOperatorSet.Union2(ho_RegionLines1, ho_RegionLines2, out ho_RegionUnion);
            ho_RegionUnion1.Dispose();
            HOperatorSet.Union2(ho_RegionLines3, ho_RegionLines4, out ho_RegionUnion1);
            ho_RegionUnion2.Dispose();
            HOperatorSet.Union2(ho_RegionUnion, ho_RegionUnion1, out ho_RegionUnion2);
            ho_RegionUnion3.Dispose();
            HOperatorSet.Union2(ho_RegionUnion2, ho_Rectangle, out ho_RegionUnion3);

            HOperatorSet.DispObj(ho_RegionUnion3, HalconWindow);

            HOperatorSet.DispObj(ho_Cross, HalconWindow);

            ho_Cross.Dispose();
            ho_Rectangle.Dispose();
            ho_RegionLines1.Dispose();
            ho_RegionLines2.Dispose();
            ho_RegionLines3.Dispose();
            ho_RegionLines4.Dispose();
            ho_RegionUnion.Dispose();
            ho_RegionUnion1.Dispose();
            ho_RegionUnion2.Dispose();
            ho_RegionUnion3.Dispose();

            hv_CenterRow.Dispose();
            hv_CenterColumn.Dispose();
            return;
        }

        private void Disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem, HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box, HTuple hv_Size)
        {
            Set_display_font(hv_WindowHandle, hv_Size, "mono", "true", "false");

            HTuple hv_GenParamName = new HTuple(), hv_GenParamValue = new HTuple();
            HTuple hv_Color_COPY_INP_TMP = new HTuple(hv_Color);
            HTuple hv_Column_COPY_INP_TMP = new HTuple(hv_Column);
            HTuple hv_CoordSystem_COPY_INP_TMP = new HTuple(hv_CoordSystem);
            HTuple hv_Row_COPY_INP_TMP = new HTuple(hv_Row);

            // Initialize local and output iconic variables
            try
            {
                if ((int)((new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(new HTuple())))) != 0)
                {
                    hv_Color_COPY_INP_TMP.Dispose();
                    hv_Column_COPY_INP_TMP.Dispose();
                    hv_CoordSystem_COPY_INP_TMP.Dispose();
                    hv_Row_COPY_INP_TMP.Dispose();
                    hv_GenParamName.Dispose();
                    hv_GenParamValue.Dispose();

                    return;
                }
                if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Row_COPY_INP_TMP.Dispose();
                    hv_Row_COPY_INP_TMP = 12;
                }
                if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Column_COPY_INP_TMP.Dispose();
                    hv_Column_COPY_INP_TMP = 12;
                }
                //
                //Convert the parameter Box to generic parameters.
                hv_GenParamName.Dispose();
                hv_GenParamName = new HTuple();
                hv_GenParamValue.Dispose();
                hv_GenParamValue = new HTuple();
                if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
                {
                    if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
                    {
                        //Display no box
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "box");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    "false");
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                    else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual(
                        "true"))) != 0)
                    {
                        //Set a color other than the default.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "box_color");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    hv_Box.TupleSelect(0));
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                }
                if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
                {
                    if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
                    {
                        //Display no shadow.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "shadow");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    "false");
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                    else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual(
                        "true"))) != 0)
                    {
                        //Set a shadow color other than the default.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "shadow_color");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    hv_Box.TupleSelect(1));
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                }
                //Restore default CoordSystem behavior.
                if ((int)(new HTuple(hv_CoordSystem_COPY_INP_TMP.TupleNotEqual("window"))) != 0)
                {
                    hv_CoordSystem_COPY_INP_TMP.Dispose();
                    hv_CoordSystem_COPY_INP_TMP = "image";
                }
                //
                if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    //disp_text does not accept an empty string for Color.
                    hv_Color_COPY_INP_TMP.Dispose();
                    hv_Color_COPY_INP_TMP = new HTuple();
                }
                //
                HOperatorSet.DispText(hv_WindowHandle, hv_String, hv_CoordSystem_COPY_INP_TMP,
                    hv_Row_COPY_INP_TMP, hv_Column_COPY_INP_TMP, hv_Color_COPY_INP_TMP, hv_GenParamName,
                    hv_GenParamValue);

                hv_Color_COPY_INP_TMP.Dispose();
                hv_Column_COPY_INP_TMP.Dispose();
                hv_CoordSystem_COPY_INP_TMP.Dispose();
                hv_Row_COPY_INP_TMP.Dispose();
                hv_GenParamName.Dispose();
                hv_GenParamValue.Dispose();

                return;
            }
            catch (HalconException)
            {
                hv_Color_COPY_INP_TMP.Dispose();
                hv_Column_COPY_INP_TMP.Dispose();
                hv_CoordSystem_COPY_INP_TMP.Dispose();
                hv_Row_COPY_INP_TMP.Dispose();
                hv_GenParamName.Dispose();
                hv_GenParamValue.Dispose();
            }
        }

        private void 保存图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ho_image == null)
                return;
            HObject saveimage = ho_image.Clone();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;
                string fil = name.Substring(name.LastIndexOf('.') + 1);
                name = name.Substring(0, name.LastIndexOf('.'));
                HOperatorSet.WriteImage(saveimage, fil, 0, name + "-原图");
            }
            saveimage.Dispose();
        }

        private void 保存截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ho_image == null)
                return;
            Adaptive_Display();
            HObject saveimage;
            HOperatorSet.GenEmptyObj(out saveimage);
            saveimage.Dispose();
            HOperatorSet.DumpWindowImage(out saveimage, HalconWindow);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog.FileName;
                string fil = name.Substring(name.LastIndexOf('.') + 1);
                name = name.Substring(0, name.LastIndexOf('.'));

                HOperatorSet.WriteImage(saveimage, fil, 0, name + "-截图");
            }
            saveimage.Dispose();
        }

        private Control control;
        private Form form = null;
        private Point OldLocation;
        private Size OldSize;
        private AnchorStyles anchor;

        private DockStyle thisStyle;

        private void 全屏显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form == null || form.IsDisposed)
            {
                form = new Form()
                {
                    ShowInTaskbar = true,
                    MaximumSize = Screen.PrimaryScreen.Bounds.Size,
                    WindowState = FormWindowState.Maximized,
                    MinimizeBox = true,
                    MaximizeBox = true,
                    //ExtendSymbol = 57374,
                    //ExtendBox = true,
                    MinimumSize = new Size(400, 400),
                    Size = new Size(400, 400),
                    //ShowTitleIcon = true,
                    //ShowDragStretch = true,
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowIcon = true,
                    //TopMost = true,
                    //Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(typeof(MainForm)).GetObject("$this.Icon"))),
                    Text = "显示窗口 - " + this.Name,
                };
                form.Resize += this.Form_Resize;
                form.FormClosing += this.Form_FormClosing;
                //form.ExtendBoxClick += this.Form_ExtendBoxClick;
            }

            if (全屏显示ToolStripMenuItem.Checked)
            {
                OldLocation = this.Location;
                OldSize = this.Size;
                control = this.Parent;
                thisStyle = this.Dock;
                anchor = this.Anchor;
                this.Dock = DockStyle.Fill;
                form.Controls.Add(this);
                form.Show();

                if (ho_image == null)
                    return;
                Adaptive_Display();
            }
            else
            {
                if (form != null && form.Controls.Count != 0 && control != null)
                {
                    form.Hide();
                    this.Dock = thisStyle;
                    control.Controls.Add(this);
                    this.Location = OldLocation;
                    this.Size = OldSize;
                    this.Anchor = anchor;
                    form.Controls.Clear();
                    if (ho_image == null)
                        return;
                    Adaptive_Display();
                }
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form != null && form.Controls.Count != 0 && control != null)
            {
                全屏显示ToolStripMenuItem.Checked = false;
                form.Hide();

                this.Dock = thisStyle;
                control.Controls.Add(this);
                this.Location = OldLocation;
                this.Size = OldSize;
                this.Anchor = anchor;

                form.Controls.Clear();
                if (ho_image == null)
                    return;
                Adaptive_Display();
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (ho_image == null)
                return;
            Adaptive_Display();
        }

        private void HWindowControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (form != null && form.Controls.Count != 0 && control != null)
                {
                    全屏显示ToolStripMenuItem.Checked = false;
                    form.Hide();
                    this.Dock = thisStyle;
                    control.Controls.Add(this);
                    this.Location = OldLocation;
                    this.Size = OldSize;
                    this.Anchor = anchor;

                    form.Controls.Clear();
                    if (ho_image == null)
                        return;
                    Adaptive_Display();
                }
            }
        }

        private void HWindowControl1_HMouseDown(object sender, HMouseEventArgs e)
        {
            if (ho_image == null)
                return;
            if (e.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                x = e.X;
                y = e.Y;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (form_ImageZoom != null && !form_ImageZoom.IsDisposed && form_ImageZoom.Visible == true && form_ImageZoom.checkBox1.Checked == false)
                    Refresh_the_zoom();
            }
        }

        public void Refresh_the_zoom()
        {
            if (form_ImageZoom != null && !form_ImageZoom.IsDisposed && form_ImageZoom.Visible == true)
            {
                int MethodsRatio = 0;
                int.TryParse(form_ImageZoom.comboBox1.Text.Replace("%", ""), out MethodsRatio);
                if (MethodsRatio == -1)
                {
                    return;
                }

                double width = ImageWidth / 2, height = ImageHeight / 2;
                int button_state;
                double positionX, positionY;
                HalconWindow.GetMpositionSubPix(out positionY, out positionX, out button_state);

                form_ImageZoom.displayWindow1.Disp_Image(ho_image);

                try
                {
                    string str_value;
                    string str_position;
                    bool _isXOut = true, _isYOut = true;
                    HTuple channel_count;

                    HOperatorSet.CountChannels(ho_image, out channel_count);
                    form_ImageZoom.label_Channel.Text = channel_count.ToString() + " 通道";
                    HalconWindow.GetMpositionSubPix(out positionY, out positionX, out button_state);
                    str_position = String.Format("RC: {0:0000},{1:0000}", positionY, positionX);
                    form_ImageZoom.label_Row.Text = positionY.ToString("0");
                    form_ImageZoom.label_Column.Text = positionX.ToString("0");
                    _isXOut = (positionX < 0 || positionX >= ImageWidth);
                    _isYOut = (positionY < 0 || positionY >= ImageHeight);

                    if (!_isXOut && !_isYOut)
                    {
                        if ((int)channel_count == 1)
                        {
                            HTuple grayVal;
                            HOperatorSet.GetGrayval(ho_image, (int)positionY, (int)positionX, out grayVal);
                            str_value = String.Format("Val: {0:000}", grayVal.D);
                            form_ImageZoom.label_Gray.Text = str_value;

                            form_ImageZoom.label_r.BackColor = Color.Silver;
                            form_ImageZoom.label_g.BackColor = Color.Silver;
                            form_ImageZoom.label_b.BackColor = Color.Silver;

                            form_ImageZoom.label_r.Width = (int)(form_ImageZoom.panel1.Width * (grayVal.D / 255));
                            form_ImageZoom.label_g.Width = (int)(form_ImageZoom.panel1.Width * (grayVal.D / 255));
                            form_ImageZoom.label_b.Width = (int)(form_ImageZoom.panel1.Width * (grayVal.D / 255));
                        }
                        else if ((int)channel_count == 3)
                        {
                            HTuple grayValRed = new HTuple(0), grayValGreen = new HTuple(0), grayValBlue = new HTuple(0);
                            HObject _RedChannel, _GreenChannel, _BlueChannel;

                            HOperatorSet.AccessChannel(ho_image, out _RedChannel, 1);
                            HOperatorSet.AccessChannel(ho_image, out _GreenChannel, 2);
                            HOperatorSet.AccessChannel(ho_image, out _BlueChannel, 3);

                            HOperatorSet.GetGrayval(_RedChannel, (int)positionY, (int)positionX, out grayValRed);
                            HOperatorSet.GetGrayval(_GreenChannel, (int)positionY, (int)positionX, out grayValGreen);
                            HOperatorSet.GetGrayval(_BlueChannel, (int)positionY, (int)positionX, out grayValBlue);

                            _RedChannel.Dispose();
                            _GreenChannel.Dispose();
                            _BlueChannel.Dispose();

                            str_value = String.Format("Gray: ({0:000}, {1:000}, {2:000})", grayValRed, grayValGreen, grayValBlue);
                            form_ImageZoom.label_Gray.Text = str_value;

                            form_ImageZoom.label_r.BackColor = Color.Red;
                            form_ImageZoom.label_g.BackColor = Color.Green;
                            form_ImageZoom.label_b.BackColor = Color.Blue;

                            form_ImageZoom.label_r.Width = (int)(form_ImageZoom.panel1.Width * (grayValRed.D / 255));
                            form_ImageZoom.label_g.Width = (int)(form_ImageZoom.panel1.Width * (grayValGreen.D / 255));
                            form_ImageZoom.label_b.Width = (int)(form_ImageZoom.panel1.Width * (grayValBlue.D / 255));
                        }
                        else
                        {
                            str_value = "";
                        }
                    }
                }
                catch
                {
                    //不处理
                }
            }
        }

        private void HWindowControl1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private Form_ImageZoom form_ImageZoom;

        private void 缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form_ImageZoom == null || form_ImageZoom.IsDisposed)
            {
                form_ImageZoom = new Form_ImageZoom();
                form_ImageZoom.TopMost = true;
            }
            form_ImageZoom.Show();
        }

        private void DisplayWindow_Resize(object sender, EventArgs e)
        {
            Disp();
        }

        private void 打开图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HObject image = Open_Image();
            if (image != null)
            {
                Disp_Image(image);
            }
        }

        private void Set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font, HTuple hv_Bold, HTuple hv_Slant)
        {
            // Local iconic variables

            // Local control variables

            HTuple hv_OS = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_Style = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_AvailableFonts = new HTuple(), hv_Fdx = new HTuple();
            HTuple hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = new HTuple(hv_Font);
            HTuple hv_Size_COPY_INP_TMP = new HTuple(hv_Size);

            // Initialize local and output iconic variables
            try
            {
                //This procedure sets the text font of the current window with
                //the specified attributes.
                //
                //Input parameters:
                //WindowHandle: The graphics window for which the font will be set
                //Size: The font size. If Size=-1, the default of 16 is used.
                //Bold: If set to 'true', a bold font is used
                //Slant: If set to 'true', a slanted font is used
                //
                hv_OS.Dispose();
                HOperatorSet.GetSystem("operating_system", out hv_OS);
                if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
                {
                    hv_Size_COPY_INP_TMP.Dispose();
                    hv_Size_COPY_INP_TMP = 16;
                }
                if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
                {
                    //Restore previous behaviour
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = hv_Size_COPY_INP_TMP.TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Courier";
                    hv_Fonts[1] = "Courier 10 Pitch";
                    hv_Fonts[2] = "Courier New";
                    hv_Fonts[3] = "CourierNew";
                    hv_Fonts[4] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Consolas";
                    hv_Fonts[1] = "Menlo";
                    hv_Fonts[2] = "Courier";
                    hv_Fonts[3] = "Courier 10 Pitch";
                    hv_Fonts[4] = "FreeMono";
                    hv_Fonts[5] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Luxi Sans";
                    hv_Fonts[1] = "DejaVu Sans";
                    hv_Fonts[2] = "FreeSans";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Liberation Sans";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Times New Roman";
                    hv_Fonts[1] = "Luxi Serif";
                    hv_Fonts[2] = "DejaVu Serif";
                    hv_Fonts[3] = "FreeSerif";
                    hv_Fonts[4] = "Utopia";
                    hv_Fonts[5] = "Liberation Serif";
                }
                else
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple(hv_Font_COPY_INP_TMP);
                }
                hv_Style.Dispose();
                hv_Style = "";
                if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Bold";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Italic";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
                {
                    hv_Style.Dispose();
                    hv_Style = "Normal";
                }
                hv_AvailableFonts.Dispose();
                HOperatorSet.QueryFont(hv_WindowHandle, out hv_AvailableFonts);
                hv_Font_COPY_INP_TMP.Dispose();
                hv_Font_COPY_INP_TMP = "";
                for (hv_Fdx = 0; (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1); hv_Fdx = (int)hv_Fdx + 1)
                {
                    hv_Indices.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Indices = hv_AvailableFonts.TupleFind(
                            hv_Fonts.TupleSelect(hv_Fdx));
                    }
                    if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(
                        0))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                        {
                            hv_Font_COPY_INP_TMP.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(
                                    hv_Fdx);
                            }
                            break;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter Font");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                          ExpTmpLocalVar_Font = (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;
                        hv_Font_COPY_INP_TMP.Dispose();
                        hv_Font_COPY_INP_TMP = ExpTmpLocalVar_Font;
                    }
                }
                HOperatorSet.SetFont(hv_WindowHandle, hv_Font_COPY_INP_TMP);

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                return;
            }
            catch (HalconException)
            {
                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();
            }
        }

        /// <summary>
        /// 画平行矩形
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public Rectangle1 Draw_Rectangle1(string colorName)
        {
            HOperatorSet.SetLineStyle(HalconWindow, 4);
            hWindowControl1.ContextMenuStrip = null;
            MessageBox.Show("请在图像窗口开始画平行矩形\n按住鼠标左键开始框选,鼠标右键结束", "提示-平行矩形");
            HOperatorSet.SetColor(HalconWindow, colorName);

            HObject Rectangle1;
            HOperatorSet.GenEmptyObj(out Rectangle1);
            Rectangle1.Dispose();
            HTuple row1 = new HTuple(0);
            HTuple row2 = new HTuple(0);

            HTuple column1 = new HTuple(0);
            HTuple column2 = new HTuple(0);
            HOperatorSet.SetLineStyle(HalconWindow, 4);
            HOperatorSet.DrawRectangle1(HalconWindow, out row1, out column1, out row2, out column2);
            HOperatorSet.GenRectangle1(out Rectangle1, row1, column1, row2, column2);
            Rectangle1 rectangle = new Rectangle1()
            {
                left_up_row = row1,
                left_up_column = column2,

                right_down_row = row2,
                right_down_column = column1,

                rectangle1 = Rectangle1
            }; hWindowControl1.ContextMenuStrip = contextMenu_Hal;
            HOperatorSet.SetLineStyle(HalconWindow, new HTuple());
            return rectangle;
        }

        /// <summary>
        /// 画旋转矩形
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public Rectangle2 Draw_Rectangle2(string colorName)
        {
            HOperatorSet.SetLineStyle(HalconWindow, 4);
            hWindowControl1.ContextMenuStrip = null;
            MessageBox.Show("请在图像窗口开始画旋转矩形\n按住鼠标左键开始框选,鼠标右键结束", "提示-旋转矩形");
            HOperatorSet.SetColor(HalconWindow, colorName);
            HObject Rectangle2;
            HOperatorSet.GenEmptyObj(out Rectangle2);
            Rectangle2.Dispose();
            HTuple row = new HTuple(0);

            HTuple column = new HTuple(0);
            HTuple phi = new HTuple(0);
            HTuple lenght1 = new HTuple(0);
            HTuple lenght2 = new HTuple(0);
            HOperatorSet.SetLineStyle(HalconWindow, 4);
            HOperatorSet.DrawRectangle2(HalconWindow, out row, out column, out phi, out lenght1, out lenght2);
            HOperatorSet.GenRectangle2(out Rectangle2, row, column, phi, lenght1, lenght2);
            Rectangle2 rectangle2 = new Rectangle2()
            {
                row = row,
                column = column,
                phi = phi,
                lenght1 = lenght1,
                lenght2 = lenght2,
                rectangle2 = Rectangle2
            }; hWindowControl1.ContextMenuStrip = contextMenu_Hal;
            HOperatorSet.SetLineStyle(HalconWindow, new HTuple());
            return rectangle2;
        }

        /// <summary>
        /// 画直线
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public Line Draw_Line(string colorName)
        {
            HOperatorSet.SetLineStyle(HalconWindow, 4);
            hWindowControl1.ContextMenuStrip = null;
            MessageBox.Show("请在图像窗口开始画直线\n按住鼠标左键开始框选,鼠标右键结束", "提示-直线");
            HOperatorSet.SetColor(HalconWindow, colorName);
            HObject line;
            HOperatorSet.GenEmptyObj(out line);
            line.Dispose();
            HTuple start_row = new HTuple(0);
            HTuple start_column = new HTuple(0);
            HTuple end_row = new HTuple(0);
            HTuple end_column = new HTuple(0); HOperatorSet.SetLineStyle(HalconWindow, 4);
            HOperatorSet.DrawLine(HalconWindow, out start_row, out start_column, out end_row, out end_column);
            HOperatorSet.GenRegionLine(out line, start_row, start_column, end_row, end_column);
            Line line1 = new Line()
            {
                start_row = start_row,
                start_column = start_column,
                end_row = end_row,
                end_column = end_column,
                line = line
            }; hWindowControl1.ContextMenuStrip = contextMenu_Hal;
            HOperatorSet.SetLineStyle(HalconWindow, new HTuple());
            return line1;
        }

        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public Circle Draw_Circle(string colorName)
        {
            HOperatorSet.SetLineStyle(HalconWindow, 4);
            hWindowControl1.ContextMenuStrip = null;

            MessageBox.Show("请在图像窗口开始画圆\n按住鼠标左键开始框选,鼠标右键结束", "提示-圆");
            HOperatorSet.SetColor(HalconWindow, colorName);
            HObject cir;
            HOperatorSet.GenEmptyObj(out cir);
            cir.Dispose();
            HTuple row = new HTuple(0);
            HTuple column = new HTuple(0);
            HTuple radius = new HTuple(0); HOperatorSet.SetLineStyle(HalconWindow, 4);
            HOperatorSet.DrawCircle(HalconWindow, out row, out column, out radius);
            HOperatorSet.GenCircle(out cir, row, column, radius);
            Circle circle = new Circle()
            {
                row = row,
                column = column,
                radius = radius,
                circle = cir
            };
            hWindowControl1.ContextMenuStrip = contextMenu_Hal;
            HOperatorSet.SetLineStyle(HalconWindow, new HTuple());
            return circle;
        }

        /// <summary>
        /// 画椭圆
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public Ellipse Draw_Ellipse(string colorName)
        {
            hWindowControl1.ContextMenuStrip = null;

            MessageBox.Show("请在图像窗口开始画椭圆\n按住鼠标左键开始框选,鼠标右键结束", "提示-椭圆");
            HOperatorSet.SetColor(HalconWindow, colorName);
            HObject ell;
            HOperatorSet.GenEmptyObj(out ell);
            ell.Dispose();
            HTuple row = new HTuple(0);
            HTuple column = new HTuple(0);
            HTuple phi = new HTuple(0);
            HTuple radius1 = new HTuple(0);
            HTuple radius2 = new HTuple(0); HOperatorSet.SetLineStyle(HalconWindow, 4);
            HOperatorSet.DrawEllipse(HalconWindow, out row, out column, out phi, out radius1, out radius2);
            HOperatorSet.GenEllipse(out ell, row, column, phi, radius1, radius2);
            Ellipse circle = new Ellipse()
            {
                row = row,
                column = column,
                phi = phi,
                radius1 = radius1,
                radius2 = radius2,
                ellipse = ell
            };
            hWindowControl1.ContextMenuStrip = contextMenu_Hal;
            HOperatorSet.SetLineStyle(HalconWindow, new HTuple());
            return circle;
        }
    }

    public struct Ellipse
    {
        public HTuple row;
        public HTuple column;
        public HTuple phi;
        public HTuple radius1;
        public HTuple radius2;
        public HObject ellipse;
    }

    public struct Circle
    {
        public HTuple row;
        public HTuple column;
        public HTuple radius;
        public HObject circle;
    }

    public struct Line
    {
        public HTuple start_row;
        public HTuple start_column;
        public HTuple end_row;
        public HTuple end_column;
        public HObject line;
    }

    public struct Rectangle1
    {
        public HTuple left_up_row;
        public HTuple right_down_row;
        public HTuple left_up_column;
        public HTuple right_down_column;
        public HObject rectangle1;
    }

    public struct Rectangle2
    {
        public HTuple row;
        public HTuple column;
        public HTuple lenght1;
        public HTuple lenght2;
        public HTuple phi;
        public HObject rectangle2;
    }

    public struct CrossPoint
    {
        public HTuple row;
        public HTuple column;
        public HTuple size;
        public string ColorName;
    }

    public struct RegionP
    {
        public HObject Region;
        public string ColorName;
        public HTuple Draw;
    }

    public struct MessageP
    {
        public int row;
        public int column;
        public int fontSize;
        public string colorName;
        public string message;
    }

    public enum HSaveImageFormat
    {
        hobj, ima, tif, tiff, bmp, jpg, jpeg, jp2, jxr, png
    }
}