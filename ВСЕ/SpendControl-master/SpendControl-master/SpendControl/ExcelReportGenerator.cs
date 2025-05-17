using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.Linq;
using System.Drawing;
using Ookii.Dialogs.Wpf;
using System.Windows.Forms;

namespace SpendControl
{
    static class ExcelReportGenerator
    {
        #region RowAndColumnConsts
        private const int START_ROW = 2;
        private const int START_COLUMN = 2;
        private const int END_COLUMN = 5;

        private const int CATEGORY_COLUMN = 2;
        private const int VALUE_COLUMN = 3;
        private const int DATE_COLUMN = 4;
        private const int DESCRIPTION_COLUMN = 5;
        #endregion

        #region ColorConsts
        private const string HEADER_COLOR = "#0077b6"; // Темно-синий заголовок
        private static readonly Dictionary<string, string> CategoryColors = new Dictionary<string, string>
        {
            { "Продукты", "#ffcc00" },
            { "Транспорт", "#0099ff" },
            { "Развлечения", "#ff6699" },
            { "Коммунальные услуги", "#66cc66" },
            { "Здоровье", "#ff3300" },
            { "Прочее", "#cccccc" } // Цвет по умолчанию
        };
        #endregion

        public static void MakeReport(List<Operation> data)
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("История операций");

            // Заполняем заголовок таблицы
            var header = sheet.Cells[START_ROW, START_COLUMN, START_ROW, END_COLUMN];
            header.LoadFromArrays(new object[][] { new[] { "Категория", "Сумма", "Дата", "Описание" } });
            header.Style.Fill.PatternType = ExcelFillStyle.Solid;
            header.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(HEADER_COLOR));
            header.Style.Font.Bold = true;
            header.Style.Font.Size = 12;
            header.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            int row = 3;
            foreach (var op in data)
            {
                // Проверяем наличие категории в словаре
                if (!CategoryColors.ContainsKey(op.Category))
                {
                    op.Category = "Прочее"; // Если категории нет, заменяем на "Прочее"
                }

                sheet.Cells[row, CATEGORY_COLUMN].Value = op.Category;
                sheet.Cells[row, VALUE_COLUMN].Value = op.Value;
                sheet.Cells[row, DATE_COLUMN].Value = op.OperationDate.ToString("dd.MM.yyyy");
                sheet.Cells[row, DESCRIPTION_COLUMN].Value = op.Description;

                var dataRow = sheet.Cells[row, START_COLUMN, row, END_COLUMN];

                string rowColor = CategoryColors[op.Category];
                dataRow.Style.Fill.PatternType = ExcelFillStyle.Solid;
                dataRow.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(rowColor));

                // Добавляем тонкие границы
                dataRow.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Gray);

                row++;
            }
            row--;

            // Форматируем даты
            sheet.Cells[START_ROW, DATE_COLUMN, row, DATE_COLUMN].Style.Numberformat.Format = "dd.MM.yyyy";

            // Форматируем суммы (BYN)
            sheet.Cells[START_ROW, VALUE_COLUMN, row, VALUE_COLUMN].Style.Numberformat.Format = "#,##0.00 BYN";

            // Проверяем, есть ли данные для диаграммы
            var chartData = data.Where(op => !string.IsNullOrEmpty(op.Category)).ToList();
            if (chartData.Any())
            {
                // Добавляем диаграмму расходов по категориям
                var chart = sheet.Drawings.AddChart("ExpenseChart", eChartType.Pie);
                chart.SetPosition(START_ROW, 0, END_COLUMN + 1, 0);
                chart.SetSize(400, 300);
                chart.Series.Add(sheet.Cells[START_ROW + 1, VALUE_COLUMN, row, VALUE_COLUMN],
                                 sheet.Cells[START_ROW + 1, CATEGORY_COLUMN, row, CATEGORY_COLUMN]);
                chart.Title.Text = "Распределение расходов по категориям";
            }

            MakeFile(package.GetAsByteArray());
        }

        private static void MakeFile(byte[] data)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Сохранение отчёта об операциях";
            dialog.DefaultExt = ".xlsx";
            dialog.CheckPathExists = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(dialog.FileName, data);
                MessageBox.Show("Отчёт сохранён");
            }
        }
    }
}
