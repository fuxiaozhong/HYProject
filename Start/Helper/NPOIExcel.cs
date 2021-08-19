using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace HYProject.Helper
{
    public class NPOIExcel
    {
        /// <summary>
        /// 读取Execl数据到DataTable(DataSet)中
        /// </summary>
        /// <param name="filePath">指定Execl文件路径</param>
        /// <param name="isFirstLineColumnName">设置第一行是否是列名</param>
        /// <returns>返回一个DataTable数据集</returns>
        public static DataSet ExcelToDataSet(string filePath, bool isFirstLineColumnName)
        {
            DataSet dataSet = new DataSet();
            int startRow = 0;
            try
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    IWorkbook workbook = null;
                    // 如果是2007+的Excel版本
                    if (filePath.IndexOf(".xlsx") > 0)
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    // 如果是2003-的Excel版本
                    else if (filePath.IndexOf(".xls") > 0)
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    if (workbook != null)
                    {
                        //循环读取Excel的每个sheet，每个sheet页都转换为一个DataTable，并放在DataSet中
                        for (int p = 0; p < workbook.NumberOfSheets; p++)
                        {
                            ISheet sheet = workbook.GetSheetAt(p);
                            DataTable dataTable = new DataTable();
                            dataTable.TableName = sheet.SheetName;
                            if (sheet != null)
                            {
                                int rowCount = sheet.LastRowNum;//获取总行数
                                if (rowCount > 0)
                                {
                                    IRow firstRow = sheet.GetRow(0);//获取第一行
                                    int cellCount = firstRow.LastCellNum;//获取总列数

                                    //构建datatable的列
                                    if (isFirstLineColumnName)
                                    {
                                        startRow = 1;//如果第一行是列名，则从第二行开始读取
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            ICell cell = firstRow.GetCell(i);
                                            if (cell != null)
                                            {
                                                if (cell.StringCellValue != null)
                                                {
                                                    DataColumn column = new DataColumn(cell.StringCellValue);
                                                    dataTable.Columns.Add(column);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            DataColumn column = new DataColumn("column" + (i + 1));
                                            dataTable.Columns.Add(column);
                                        }
                                    }

                                    //填充行
                                    for (int i = startRow; i <= rowCount; ++i)
                                    {
                                        IRow row = sheet.GetRow(i);
                                        if (row == null) continue;

                                        DataRow dataRow = dataTable.NewRow();
                                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                                        {
                                            ICell cell = row.GetCell(j);
                                            if (cell == null)
                                            {
                                                dataRow[j] = "";
                                            }
                                            else
                                            {
                                                switch (cell.CellType)
                                                {
                                                    case CellType.Blank:
                                                        dataRow[j] = "";
                                                        break;

                                                    case CellType.Numeric:
                                                        short format = cell.CellStyle.DataFormat;
                                                        //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                                        if (format == 14 || format == 31 || format == 57 || format == 58)
                                                            dataRow[j] = cell.DateCellValue;
                                                        else
                                                            dataRow[j] = cell.NumericCellValue;
                                                        break;

                                                    case CellType.String:
                                                        dataRow[j] = cell.StringCellValue;
                                                        break;
                                                }
                                            }
                                        }
                                        dataTable.Rows.Add(dataRow);
                                    }
                                }
                            }
                            dataSet.Tables.Add(dataTable);
                        }
                    }
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 将DataTable导出到Execl文档
        /// </summary>
        /// <param name="dt">传入一个DataTable数据集</param>
        /// <returns>返回一个Bool类型的值，表示是否导出成功</returns>
        /// True表示导出成功，Flase表示导出失败
        public static bool DataTableToExcel(DataTable dt, string Outpath = "Default.xls")
        {
            bool result = false;
            IWorkbook workbook = null;
            FileStream fs = null;
            IRow row = null;
            ISheet sheet = null;
            ICell cell = null;
            try
            {
                if (dt != null && dt.Rows.Count > 1)
                {
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet("Sheet0");//创建一个名称为Sheet0的表
                    int rowCount = dt.Rows.Count;//行数
                    int columnCount = dt.Columns.Count;//列数

                    //设置列头
                    row = sheet.CreateRow(0);//excel第一行设为列头
                    for (int c = 0; c < columnCount; c++)
                    {
                        cell = row.CreateCell(c);
                        cell.SetCellValue(dt.Columns[c].ColumnName);
                    }

                    //设置每行每列的单元格,
                    for (int i = 0; i < rowCount; i++)
                    {
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < columnCount; j++)
                        {
                            cell = row.CreateCell(j);//excel第二行开始写入数据
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }
                    //向outPath输出数据
                    using (fs = File.OpenWrite(Outpath))
                    {
                        workbook.Write(fs);//向打开的这个xls文件中写入数据
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return false;
            }
        }

        public static DataTable DataGridViewToTable(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            // 循环列标题名称，处理了隐藏的行不显示
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                if (dgv.Columns[count].Visible == true)
                {
                    dt.Columns.Add(dgv.Columns[count].HeaderText.ToString());
                }
            }

            // 循环行，处理了隐藏的行不显示
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                int curr = 0;
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    if (dgv.Columns[countsub].Visible == true)
                    {
                        if (dgv.Rows[count].Cells[countsub].Value != null)
                        {
                            dr[curr] = dgv.Rows[count].Cells[countsub].Value.ToString();
                        }
                        else
                        {
                            dr[curr] = "";
                        }
                        curr++;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}