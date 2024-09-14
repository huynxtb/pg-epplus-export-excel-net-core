using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace ProGCoder_ExportExcel.Helpers;

public static class ExportExcelHelper<T>
{
    public static void GenerateExcel(List<T> listData, string path, string sheetName)
    {
        var dataTable = ConvertToDataTable(listData);

        // Set License for EPPLUS
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var pck = new ExcelPackage(path);
        // Create a Sheet with name = sheetName
        var ws = pck.Workbook.Worksheets.Add(sheetName);

        ws.Workbook.Properties.Author = "https://www.progcoder.com";

        // Load data from DataTable for Worksheet
        ws.Cells["A1"].LoadFromDataTable(dataTable, true);

        // Auto fit all column
        ws.Cells.AutoFitColumns();

        //Set format for header
        for (var i = 1; i <= ModelHelper<T>.GetDescriptionProperties().Count; i++)
        {
            var range = ws.Cells[1, i];
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Bold = true;
            range.Style.Font.Color.SetColor(Color.Blue);
        }

        pck.Save();
    }

    private static DataTable ConvertToDataTable<T>(List<T> models)
    {
        // creating a data table instance and typed it as our incoming model   
        // As I make it generic, if you want, you can make it the model typed you want.  
        var dataTable = new DataTable(typeof(T).Name);

        // Get Description each Property in model
        var headerColumns = ModelHelper<T>.GetDescriptionProperties();

        // Get all property in model
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Loop through all the properties              
        // Adding Column name to our datatable  
        foreach (var header in headerColumns)
        {
            //Setting column names as Property names    
            dataTable.Columns.Add(header);
        }

        // Adding Row and its value to our dataTable  
        foreach (var item in models)
        {
            var values = new object[headerColumns.Count];

            for (var i = 0; i < headerColumns.Count; i++)
            {
                // Inserting property values to datatable rows    
                values[i] = props[i].GetValue(item, null) ?? "";
            }

            // Finally add value to datatable    
            dataTable.Rows.Add(values);
        }

        return dataTable;
    }
}