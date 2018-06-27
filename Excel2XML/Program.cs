using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Excel2XML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing Excel File...");
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = directory.GetFiles("*.xlsx",SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                using (var document = SpreadsheetDocument.Open(file.FullName, false))
                {
                    var sheets = document.WorkbookPart.Workbook.Sheets;

                    foreach (var sheet in sheets)
                    {

                        var sheetName = sheet.GetAttribute("name", String.Empty).Value;
                        var relationId = sheet.GetAttribute("id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships").Value;

                        var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationId);
                        var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                        var rows = sheetData.Descendants<Row>();
                        var dictionary= new Dictionary<string,string>();

                        foreach (var row in rows.Skip(1))
                        {
                            var key = Excel2XmlHelper.GetValueOfCell(row.Elements<Cell>().ElementAt(0),document);
                            var value = Excel2XmlHelper.GetValueOfCell(row.Elements<Cell>().ElementAt(1),document);

                            dictionary.Add(key, value);
                        }

                        dictionary.SaveToXml(sheetName);
                    }

                }
            }
            Console.WriteLine("Press Any Key To Exit.");
            Console.ReadKey();
        }
    }
 }
