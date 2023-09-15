using ClosedXML.Excel;
using ConversorJsonParaXlsx.Models;

namespace ConversorJsonParaXlsx.Methods
{
    public class ConverterMtd
    {
        internal static void Converter(IEnumerable<Item> itens, String path)
        {
            using (var workbook = new XLWorkbook())
            {
                // Add a worksheet
                var worksheet = workbook.Worksheets.Add("Dados");

                // Define the header row
                Type type = (new Item()).GetType();
                var props = type.GetProperties();


                int ascii = 65;
                foreach (var prop in props)
                {
                    worksheet.Cells(((Char)ascii++) + "1").Value = prop.Name;
                }

                // Fill the data
                int row = 2;
                foreach (var item in itens)
                {
                    ascii = 65;
                    foreach (var prop in props)
                    {
                        worksheet.Cells(((Char)ascii++) + row.ToString()).Value = prop.GetValue(item) != null ? prop.GetValue(item).ToString() : null;
                    }

                    row++;
                }

                // Save the Excel package to a file
                workbook.SaveAs(path);

                Console.WriteLine("Excel file created successfully.");
            }
        }
    }
}
