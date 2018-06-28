using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Excel2XML
{
    static class Excel2XmlHelper
    {
        public static string ParseCulture(this string sheetName)
        {
                var pattern = new Regex(@"(?:[^ \n-]+-){1}(.*)$");
                ;
                var match = pattern.Match(sheetName);
            return match.Success ? match.Groups[1].Value : "en";
        }

        public static void SaveToXml(this IDictionary<string, string> dictionary, string fileName)
        {
            var doc = new XmlDocument();
            var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            var root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            var localizationDictionary = doc.CreateElement("localizationDictionary");
            localizationDictionary.SetAttribute("culture", fileName.ParseCulture());
            doc.AppendChild(localizationDictionary);

            var texts = doc.CreateElement("texts");
            localizationDictionary.AppendChild(texts);

            foreach (var pair in dictionary)
            {
                var text = doc.CreateElement("text");
                text.SetAttribute("name", pair.Key);
                text.InnerText = pair.Value;
                texts.AppendChild(text);
            }
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            directory.CreateSubdirectory("XMLs");
            doc.Save($"XMLs/{fileName}.xml");
        }

        public static string GetValueOfCell(Cell cell,SpreadsheetDocument spreadSheetDocument)
        {
            var sharedString = spreadSheetDocument.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return string.Empty;
            }


            var cellValue = cell.CellValue.InnerText;

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
