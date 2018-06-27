using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Excel2XML
{
    static class Excel2XmlHelper
    {
        public static string ParseCulture(this FileInfo file)
        {
                var pattern = new Regex(@"(?:[^ \n-]+-){1}(.*)(?:\.[^.]*$)");
                ;
                var match = pattern.Match(file.Name);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
                return "en";
        }

        private static void SaveToXml(this IDictionary<string, string> dictionary, FileInfo file)
        {
            var doc = new XmlDocument();
            var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            var root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            var localizationDictionary = doc.CreateElement("localizationDictionary");
            localizationDictionary.SetAttribute("culture", file.ParseCulture());
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

            doc.Save($"{file.Name}.xml");
        }
    }
}
