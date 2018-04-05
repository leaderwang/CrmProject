using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using OfficeOpenXml;

namespace Common
{
    /// <summary>
    ///  Output <see cref="DataTable"/> to Excel2007 or above version that base on open xml formater
    /// </summary>
    public class OpenXmlExcelHelper
    {
        #region Constants and Fields

        public const int MaxSheetRows2007 = 1048576;

        #endregion

        #region Public Methods

        public static void Export(DataTable table, string fileName)
        {
            var rows = 0;
            Export(table, fileName, string.Empty, ref rows);
        }

        public static void Export(DataTable table, string fileName, string sheetName, ref int rowWrited)
        {
            if (table == null || table.Rows.Count == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(sheetName))
            {
                sheetName = "Sheet";
            }
            //if (table.Rows.Count > ExcelUtil.GetMaxRowSupported(fileName))
            //    throw new ArgumentException(string.Format("data rows cann't be more than {0}",
            //        ExcelUtil.GetMaxRowSupported(fileName)));
            var excel = new ExcelPackage(new FileInfo(fileName));
            using (excel)
            {
                WriteSheets(table, excel, sheetName);
                excel.Save();
            }
        }


        public static void ExportByWeb(DataTable table, string fileName, string sheetName)
        {
            using (var excel = new ExcelPackage())
            {
                WriteSheets(table, excel, sheetName);
                var context = HttpContext.Current;
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.Charset = "";
                context.Response.AppendHeader(
                    "Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
                context.Response.BinaryWrite(excel.GetAsByteArray());
                context.Response.Flush();
                context.Response.End();
            }
        }


        public static DataTable Import(string fileName)
        {
            var dt = new DataTable();
            using (var excel = new ExcelPackage(new FileInfo(fileName)))
            {
                var sheet = excel.Workbook.Worksheets.First();
                if (sheet == null)
                {
                    return null;
                }
                foreach (var cell in sheet.Cells[1, 1, 1, sheet.Dimension.End.Column])
                {
                    dt.Columns.Add(cell.Value.ToString());
                }
                var rows = sheet.Dimension.End.Row;
                for (var i = 1; i <= rows; i++)
                {
                    var row = sheet.Cells[i, 1, i, sheet.Dimension.End.Column];
                    dt.Rows.Add(row.Select(cell => cell.Value).ToArray());
                }
                return dt;
            }
        }


        private static void FormatCell(ExcelRangeBase cell, DataColumn column)
        {
            //if (column.DataType == typeof(DateTime))
            //{
            //    cell.Style.Numberformat.Format = System.Globalization.DateTimeFormatInfo.CurrentInfo.LongDatePattern;
            //    return;
            //}
            //if (column.DataType.IsValueType) // == typeof(Decimal) || column.DataType == typeof(Double) || column.DataType == typeof(Single))
            //{
            //    cell.Style.Numberformat.Format = "#,##0.00";
            //}
        }

        #endregion

        #region Methods

        private static ExcelWorksheet CreateSheet(ExcelPackage excel, string sheetName)
        {
            foreach (var sheet in excel.Workbook.Worksheets)
            {
                if (String.Compare(sheet.Name, sheetName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return sheet;
                }
            }
            return excel.Workbook.Worksheets.Add(sheetName);
        }


        private static void WriteSheet(DataTable table, ExcelPackage excel, string sheetName, int startRowIndex,
                                       int endRowIndex)
        {
            var sheet = CreateSheet(excel, sheetName);
            var i = 1;
            foreach (DataColumn col in table.Columns)
            {
                FormatCell(sheet.Cells[1, i], col);
                sheet.Cells[1, i].Value = col.ColumnName;
                i++;
            }
            var columnCount = table.Columns.Count;
            i = 2;
            for (var m = startRowIndex; m <= endRowIndex; m++)
            {
                var row = table.Rows[m];
                for (var j = 1; j <= columnCount; j++)
                {
                    FormatCell(sheet.Cells[i, j], table.Columns[j - 1]);
                    sheet.Cells[i, j].Value = row[j - 1].ToString();
                }
                i++;
            }
        }

        //private static void WriteSheet(DataTable table, ExcelPackage excel, string sheetName)
        //{
        //    var sheet = CreateSheet(excel, sheetName);
        //    var i = 1;
        //    foreach (DataColumn col in table.Columns)
        //    {
        //        sheet.Cells[1, i].Value = col.ColumnName;
        //        i++;
        //    }
        //    var columnCount = table.Columns.Count;
        //    var rows = table.Rows.Count;
        //    for (i = 2 ; i <= rows; i++)
        //    {
        //        var row = table.Rows[i];
        //        for (var j = 1; j <= columnCount; j++)
        //        {
        //            sheet.Cells[i, j].Value = row[j - 1].ToString();
        //        }
        //    }
        //}

        private static void WriteSheets(DataTable table, ExcelPackage excel, string sheetName)
        {
            const int max = MaxSheetRows2007 - 1;
            var rows = table.Rows.Count;
            var sheetCount = (rows % max == 0) ? rows / max : rows / max + 1;
            for (var sheetNo = 0; sheetNo < sheetCount; sheetNo++)
            {
                WriteSheet(
                    table,
                    excel,
                    (sheetNo == 0) ? sheetName : sheetName + "_" + sheetNo,
                    sheetNo * max,
                    (sheetNo + 1) * max < rows ? (sheetNo + 1) * max - 1 : rows - 1
                    );
            }
            //WriteSheet(table, sheetIndex, ref rowWrited);
        }

        #endregion

        #region 导出多个sheel
        /// <summary>
        /// 导出多个sheel
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fileName"></param>
        public static void ExportByWebList(Dictionary<string, DataTable> list, string fileName)
        {
            using (var excel = new ExcelPackage())
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        WriteSheets(item.Value, excel, item.Key);
                    }
                }

                var context = HttpContext.Current;
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.Charset = "";
                context.Response.AppendHeader(
                    "Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
                context.Response.BinaryWrite(excel.GetAsByteArray());
                context.Response.Flush();
                context.Response.End();
            }
        } 
        #endregion
    }
}
