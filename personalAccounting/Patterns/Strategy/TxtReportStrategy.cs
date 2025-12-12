using System.Collections.Generic;
using System.IO;
using System.Text;
using personalAccounting.Models;

namespace personalAccounting.Patterns.Strategy
{
    public class TxtReportStrategy : IReportStrategy
    {
        public void SaveReport(List<Transaction> transactions, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("ЗВІТ ПРО ВИТРАТИ");
            sb.AppendLine($"Дата генерації: {DateTime.Now}");
            sb.AppendLine("-------------------------------------------------");

            decimal total = 0;

            foreach (var t in transactions)
            {
                sb.AppendLine($"{t.Date.ToShortDateString()} | {t.Category}");
                sb.AppendLine($"   Сума: {t.Amount} UAH");
                sb.AppendLine($"   Опис: {t.Description}");
                sb.AppendLine("- - - - - - - - - - - - - - - -");

                total += t.Amount;
            }

            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine($"ВСЬОГО ВИТРАЧЕНО: {total} UAH");

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}