// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.NPOIHelper
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;

namespace RoadFlow.Utility
{
    public class NPOIHelper
    {
        public static void ExportToFile(DataTable dtSource, string strHeaderText, string strFileName, string templateFile = "")
        {
            using (MemoryStream memoryStream = NPOIHelper.ExportToMemoryStream(dtSource, strHeaderText, templateFile, strFileName))
            {
                using (FileStream fileStream = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] array = memoryStream.ToArray();
                    fileStream.Write(array, 0, array.Length);
                    fileStream.Flush();
                }
            }
        }

        public static MemoryStream ExportToMemoryStream(DataTable dtSource, string strHeaderText, string templateFile = "", string fileName = "")
        {
            IWorkbook workbook = (IWorkbook)null;
            ISheet sheet = (ISheet)null;
            bool flag1 = false;
            int rownum = 0;
            bool flag2;
            if (!templateFile.IsNullOrEmpty() && File.Exists(templateFile))
            {
                string path = templateFile;
                flag2 = path.EndsWith("xlsx", StringComparison.CurrentCultureIgnoreCase);
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    workbook = !flag2 ? (IWorkbook)new HSSFWorkbook((Stream)fileStream) : (IWorkbook)new XSSFWorkbook((Stream)fileStream);
                if (workbook != null)
                {
                    sheet = workbook.GetSheetAt(0);
                    if (sheet != null)
                    {
                        flag1 = true;
                        rownum = sheet.LastRowNum + 1;
                    }
                }
            }
            else
                flag2 = fileName.EndsWith("xlsx", StringComparison.CurrentCultureIgnoreCase);
            if (workbook == null)
                workbook = !flag2 ? (IWorkbook)new HSSFWorkbook() : (IWorkbook)new XSSFWorkbook();
            if (sheet == null)
                sheet = workbook.CreateSheet("Sheet1");
            int[] numArray = new int[0];
            string[] strArray = new string[0];
            if (!flag1)
            {
                numArray = new int[dtSource.Columns.Count];
                strArray = new string[dtSource.Columns.Count];
                foreach (DataColumn column in (InternalDataCollectionBase)dtSource.Columns)
                {
                    numArray[column.Ordinal] = !column.Caption.IsInt() ? Encoding.GetEncoding(936).GetBytes(column.ColumnName.ToString()).Length : column.Caption.ToInt();
                    strArray[column.Ordinal] = column.DataType.ToString();
                }
                if (dtSource.Rows.Count > 0)
                {
                    for (int index = 0; index < dtSource.Columns.Count; ++index)
                    {
                        if (!dtSource.Columns[index].Caption.IsInt())
                        {
                            int length = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[0][index].ToString()).Length;
                            if (length > numArray[index])
                                numArray[index] = length;
                        }
                    }
                }
            }
            bool flag3 = !strHeaderText.IsNullOrEmpty();
            if (!flag1 && (rownum == (int)ushort.MaxValue || rownum == 0))
            {
                if (flag3)
                {
                    IRow row = sheet.CreateRow(0);
                    row.HeightInPoints = 25f;
                    row.CreateCell(0).SetCellValue(strHeaderText);
                    ICellStyle cellStyle = workbook.CreateCellStyle();
                    cellStyle.Alignment = HorizontalAlignment.Center;
                    IFont font = workbook.CreateFont();
                    font.FontHeightInPoints = (short)20;
                    font.Boldweight = (short)700;
                    cellStyle.SetFont(font);
                    cellStyle.BorderLeft = BorderStyle.Thin;
                    cellStyle.BorderRight = BorderStyle.Thin;
                    cellStyle.BorderTop = BorderStyle.Thin;
                    cellStyle.BorderBottom = BorderStyle.Thin;
                    row.GetCell(0).CellStyle = cellStyle;
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                }
                IRow row1 = sheet.CreateRow(flag3 ? 1 : 0);
                ICellStyle cellStyle1 = workbook.CreateCellStyle();
                cellStyle1.Alignment = HorizontalAlignment.Center;
                IFont font1 = workbook.CreateFont();
                font1.FontHeightInPoints = (short)10;
                font1.Boldweight = (short)700;
                cellStyle1.BorderLeft = BorderStyle.Thin;
                cellStyle1.BorderRight = BorderStyle.Thin;
                cellStyle1.BorderTop = BorderStyle.Thin;
                cellStyle1.BorderBottom = BorderStyle.Thin;
                cellStyle1.IsLocked = true;
                cellStyle1.SetFont(font1);
                workbook.CreateCellStyle();
                foreach (DataColumn column in (InternalDataCollectionBase)dtSource.Columns)
                {
                    row1.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    row1.GetCell(column.Ordinal).CellStyle = cellStyle1;
                    if (numArray.Length != 0)
                        sheet.SetColumnWidth(column.Ordinal, (numArray[column.Ordinal] + 1) * 256);
                }
                rownum = flag3 ? 2 : 1;
            }
            int count = dtSource.Columns.Count;
            ICellStyle cellStyle2 = workbook.CreateCellStyle();
            cellStyle2.BorderLeft = BorderStyle.Thin;
            cellStyle2.BorderRight = BorderStyle.Thin;
            cellStyle2.BorderTop = BorderStyle.Thin;
            cellStyle2.BorderBottom = BorderStyle.Thin;
            foreach (DataRow row1 in (InternalDataCollectionBase)dtSource.Rows)
            {
                IRow row2 = sheet.CreateRow(rownum);
                for (int column = 0; column < count; ++column)
                {
                    ICell cell = row2.CreateCell(column);
                    cell.CellStyle = cellStyle2;
                    string s = row1[column].ToString();
                    switch (strArray.Length > column ? strArray[column] : "System.String")
                    {
                        case "System.Boolean":
                            bool result1 = false;
                            bool.TryParse(s, out result1);
                            cell.SetCellValue(result1);
                            break;
                        case "System.Byte":
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                            int result2 = 0;
                            int.TryParse(s, out result2);
                            cell.SetCellValue((double)result2);
                            break;
                        case "System.DBNull":
                            cell.SetCellValue("");
                            break;
                        case "System.DateTime":
                            DateTime result3;
                            DateTime.TryParse(s, out result3);
                            cell.SetCellValue(result3);
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            double result4 = 0.0;
                            double.TryParse(s, out result4);
                            cell.SetCellValue(result4);
                            break;
                        case "System.String":
                            cell.SetCellValue(s);
                            break;
                        default:
                            cell.SetCellValue("");
                            break;
                    }
                }
                ++rownum;
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.Write((Stream)memoryStream);
                memoryStream.Flush();
                return memoryStream;
            }
        }

        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string templateFile = "")
        {
            HttpContext current = HttpContext.Current;
            current.Response.ContentType = "application/vnd.ms-excel";
            current.Response.ContentEncoding = Encoding.UTF8;
            current.Response.Charset = "";
            string str = strFileName;
            if (current.Request != null && current.Request.Browser != null && (current.Request.Browser.Type.StartsWith("IE", StringComparison.CurrentCultureIgnoreCase) || current.Request.Browser.Type.StartsWith("InternetExplorer", StringComparison.CurrentCultureIgnoreCase)))
                str = str.UrlEncode();
            current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + str);
            MemoryStream memoryStream = NPOIHelper.ExportToMemoryStream(dtSource, strHeaderText, templateFile, strFileName);
            current.Response.BinaryWrite(memoryStream.ToArray());
            current.Response.End();
        }

        public static DataTable ReadToDataTable(string strFileName, int headerRows = 1)
        {
            DataTable dataTable = new DataTable();
            IWorkbook workbook;
            using (FileStream fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                workbook = !Path.GetExtension(strFileName).Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase) ? (IWorkbook)new HSSFWorkbook((Stream)fileStream) : (IWorkbook)new XSSFWorkbook((Stream)fileStream);
            ISheet sheetAt = workbook.GetSheetAt(0);
            sheetAt.GetRowEnumerator();
            IRow row1 = sheetAt.GetRow(0);
            int lastCellNum = (int)row1.LastCellNum;
            for (int cellnum = 0; cellnum < lastCellNum; ++cellnum)
            {
                ICell cell = row1.GetCell(cellnum);
                dataTable.Columns.Add(cell.ToString());
            }
            for (int rownum = sheetAt.FirstRowNum + headerRows; rownum <= sheetAt.LastRowNum; ++rownum)
            {
                IRow row2 = sheetAt.GetRow(rownum);
                DataRow row3 = dataTable.NewRow();
                for (int firstCellNum = (int)row2.FirstCellNum; firstCellNum < lastCellNum; ++firstCellNum)
                {
                    if (row2.GetCell(firstCellNum) != null)
                        row3[firstCellNum] = (object)row2.GetCell(firstCellNum).ToString();
                }
                dataTable.Rows.Add(row3);
            }
            return dataTable;
        }

        public static void ExportCSV(DataTable dt, string strFileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < dt.Columns.Count; ++index)
            {
                stringBuilder.Append(dt.Columns[index].ColumnName);
                if (index < dt.Columns.Count - 1)
                    stringBuilder.Append(",");
            }
            stringBuilder.Append("\n");
            foreach (DataRow row in (InternalDataCollectionBase)dt.Rows)
            {
                for (int index = 0; index < dt.Columns.Count; ++index)
                {
                    stringBuilder.Append(row[index]);
                    if (index < dt.Columns.Count - 1)
                        stringBuilder.Append(",");
                }
                stringBuilder.Append("\n");
            }
            stringBuilder.Append("\n");
            using (FileStream fileStream = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
            {
                byte[] bytes = Encoding.Default.GetBytes(stringBuilder.ToString());
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }
        }
    }
}