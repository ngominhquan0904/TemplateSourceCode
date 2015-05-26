using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;

namespace Utility
{
    public class ExcelTemplate
    {
        public static string path ;

        public static string Path
        {
            set { path = value; }
            get { return Directory.GetCurrentDirectory() + @"\Excel\"; }
        }
        public void CreateNewFileExcel()
        {

            string path = Directory.GetCurrentDirectory()+@"\Excel\";
            FileInfo newFile = new FileInfo(path+@"Template.xlsx");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(path + @"Template.xlsx");
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Inventry");
                //Add Header
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Product";
                worksheet.Cells[1, 3].Value = "Quality";
                worksheet.Cells[1, 4].Value = "Price";
                worksheet.Cells[1, 5].Value = "Value";
                //Add value
                worksheet.Cells["A2"].Value =1201;
                worksheet.Cells["B2"].Value ="Nail";
                worksheet.Cells["C2"].Value =10;
                worksheet.Cells["D2"].Value =20;

                worksheet.Cells["A3"].Value =1202;
                worksheet.Cells["B3"].Value ="Hamer";
                worksheet.Cells["C3"].Value =11;
                worksheet.Cells["D3"].Value =21;

                worksheet.Cells["A4"].Value =1203;
                worksheet.Cells["B4"].Value ="Steven";
                worksheet.Cells["C4"].Value =12;
                worksheet.Cells["D4"].Value =22;

                worksheet.Cells["A5"].Value =1204;
                worksheet.Cells["B5"].Value ="Herry";
                worksheet.Cells["C5"].Value =13;
                worksheet.Cells["D5"].Value =23;
                //Add fomula to Value column
                worksheet.Cells["E2:E4"].Formula = "C2*D2";
                //Create style for header
                using (var range = worksheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                    range.Style.Font.Color.SetColor(Color.White);
                }
                // Formatting the footer row
                // Setting top border of the footer row
                worksheet.Cells["A5:E5"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                // Setting font bold of the footer row
                worksheet.Cells["A5:E5"].Style.Font.Bold = true;

                // Now, we want to show the Sub total in the footer row for the 'Quantity', 'Price' and 'Value' column
                // Seeting formula for the footer row...
                worksheet.Cells[5, 3, 5, 5].Formula = string.Format("SUBTOTAL(9, {0})", new ExcelAddress(2, 3, 4, 3).Address);
                // Note: SUBTOTAL() is a Excel Function. If you don't know about this function, read this:
                // http://office.microsoft.com/en-in/excel-help/subtotal-function-HP010062463.aspx

                //Now we need to format the values, as the values here, some are string, some are double, some are int
                //Setting Number Format...
                //Setting integer format for the column 'Quantity' and Setting decimal format for the column 'Price' and 'Value'
                worksheet.Cells["C2:C5"].Style.Numberformat.Format = "#,##0";	// Setting integer format
                worksheet.Cells["D2:E5"].Style.Numberformat.Format = "#,##0.00";	// Setting decimal format
                // Here number format is the excel number format, if you don't know, please click and read:
                // http://office.microsoft.com/en-in/excel-help/create-a-custom-number-format-HP010342372.aspx

                // Now we enabling filter features of Excel in the cells
                // If you don't know Excel Filtering, please click and read:
                // http://office.microsoft.com/en-001/excel-help/filter-data-in-a-range-or-table-HP010073941.aspx
                // Creating an Auto Filter for the range
                worksheet.Cells["A1:E4"].AutoFilter = true;
                // Setting text format for the column 'Product', as it will helps you during filtering
                worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";

                // Setting AutoFit for all cells
                worksheet.Cells.AutoFitColumns(0);

                // Lets set the header text
                worksheet.HeaderFooter.OddHeader.CenteredText = "&24&U&\"Arial,Regular Bold\" Inventry";

                // Add the page number to the right of the footer + total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);

                // Add the sheet name to center of the footer
                worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                // Add the filepath to the left of the footer
                worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;

                // At the time of printing, when page page breaks, then the header will come in the next page by enabling this settings...
                worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:1"];
                worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:E"];

                // Change the sheet view to show it in page layout mode
                worksheet.View.PageLayoutView = true;

                // Setting some document properties
                package.Workbook.Properties.Title = "Invertory";
                package.Workbook.Properties.Author = "Debopam Pal";
                package.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 workbook using EPPlus";

                // set some extended property values
                package.Workbook.Properties.Company = "AdventureWorks Inc.";

                // set some custom property values
                package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Jan Källman");
                package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");

                // Now we are going to create the Pie Chart
                // Read about Pie Chart: http://office.microsoft.com/en-in/excel-help/present-your-data-in-a-pie-chart-HA010211848.aspx
                var chart = (worksheet.Drawings.AddChart("PieChart", OfficeOpenXml.Drawing.Chart.eChartType.Pie3D) as ExcelPieChart);

                // Setting title text of the Chart
                chart.Title.Text = "Total";

                // Setting 5 pixel offset from 5th column of the first row
                chart.SetPosition(0, 0, 5, 5);

                // Setting width & height of the chart area
                chart.SetSize(600, 300);

                //In the Pie Chart value will come from 'Value' column
                //and show in the form of percentage
                //Now I'll show you how to take values from the 'Value' column
                ExcelAddress valueAddress = new ExcelAddress(2, 5, 4, 5);
                // Setting Series and XSeries of the chart
                // Product name will be the item of the Chart
                var ser = (chart.Series.Add(valueAddress.Address, "B2:B4") as ExcelPieChartSerie);

                // Setting chart properties
                chart.DataLabel.ShowCategory = true;
                chart.DataLabel.ShowPercent = true;
                // Formatting Looks of the Chart
                chart.Legend.Border.LineStyle = eLineStyle.Solid;
                chart.Legend.Border.Fill.Style = eFillStyle.SolidFill;
                chart.Legend.Border.Fill.Color = Color.DarkBlue;

                // Switch the page layout view back to the normal
                worksheet.View.PageLayoutView = false;
                package.Save();
            }
        }

        public void ReadFileExcel()
        {
            string path = Directory.GetCurrentDirectory() + @"\Excel\";
            FileInfo oldFile = new FileInfo(path + @"newFile.xlsx");
            if (oldFile.Exists)
            {
                ExcelPackage  package = new ExcelPackage(oldFile);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                var x = worksheet.Cells[5, 2].Text;
                string s = "";
            }
        }
    }
}
