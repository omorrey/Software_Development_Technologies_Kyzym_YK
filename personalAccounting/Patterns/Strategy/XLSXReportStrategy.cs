using System.Collections.Generic;
using personalAccounting.Models;
using ClosedXML.Excel;

namespace personalAccounting.Patterns.Strategy
{
    public class XLSXReportStrategy : IReportStrategy
    {
        public void SaveReport(List<Transaction> transactions, string filePath)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Звіт");

            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Дата";
            worksheet.Cell(1, 3).Value = "Сума";
            worksheet.Cell(1, 4).Value = "Категорія";
            worksheet.Cell(1, 5).Value = "Тип";
            worksheet.Cell(1, 6).Value = "Опис";

            var headerRange = worksheet.Range("A1:F1");
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

            int row = 2;
            foreach (var t in transactions)
            {
                worksheet.Cell(row, 1).Value = t.TransactionId;
                worksheet.Cell(row, 2).Value = t.Date;
                worksheet.Cell(row, 3).Value = t.Amount;
                worksheet.Cell(row, 4).Value = t.Category;
                worksheet.Cell(row, 5).Value = t.Type.ToString(); ;
                worksheet.Cell(row, 6).Value = t.Description;

                worksheet.Cell(row, 2).Style.DateFormat.Format = "dd.MM.yyyy";

                row++;
            }

            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }
    }
}
