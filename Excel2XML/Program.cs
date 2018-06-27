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
                Console.WriteLine($"{file.ParseCulture()}");
                XmlDocument xml = new XmlDocument();
                XmlElement localizationDictionary = (XmlElement) xml.AppendChild(xml.CreateElement("localizationDictionary"));
                localizationDictionary.SetAttribute("culture","en");
                var texts = localizationDictionary.AppendChild(xml.CreateElement("texts"));
                var text = texts.AppendChild(xml.CreateElement("text"));


                using (var document = SpreadsheetDocument.Open(file.FullName, false))
                {
                    var sheets = document.WorkbookPart.Workbook.Sheets.ToList();
                    if (!sheets.Any())
                    {
                        Console.WriteLine("No File!");
                        break;
                    }

                    foreach (var sheet in sheets)
                    {

                        foreach (var attribute in sheet.GetAttributes())
                        {
                            Console.WriteLine($"{attribute.LocalName}, {attribute.Value}, {attribute.NamespaceUri}");
                        }

                        var name = sheet.GetAttribute("name", String.Empty).Value;
                        var relationId = sheet.GetAttribute("id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships").Value;

                        var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationId);
                        var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                        var rows = sheetData.Descendants<Row>();
                        
                        if (!rows.Any())
                        {
                            break;
                        }

                        foreach (var row in rows.Skip(1))
                        {
                            //foreach (var attr in row.GetAttributes())
                            //{
                            //    Console.WriteLine($"{attr.LocalName}, {attr.Value}, {attr.NamespaceUri}");
                            //}
                            foreach (var cell in row.Descendants<Cell>())
                            {

                                Console.Write($"{GetValueOfCell(document,cell)}, ");
                            }
                            Console.WriteLine();
                        }
                    }

                }
            }
            Console.WriteLine("Press Any Key To Exit.");
            Console.ReadKey();
        }

        private static string GetValueOfCell(SpreadsheetDocument spreadsheetdocument, Cell cell)
        {
            SharedStringTablePart sharedString = spreadsheetdocument.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return string.Empty;
            }


            string cellValue = cell.CellValue.InnerText;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return sharedString.SharedStringTable.ChildElements[int.Parse(cellValue)].InnerText;
            }
            else
            {
                return cellValue;
            }
        }

       


    }
}
