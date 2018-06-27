using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            var root = doc.DocumentElement;

            doc.InsertBefore(xmlDeclaration, root);

            var localizationDictionary = doc.CreateElement("locallizationDictionary");
            localizationDictionary.SetAttribute("culture", "en");
            doc.AppendChild(localizationDictionary);

            var texts = doc.CreateElement("texts");
            localizationDictionary.AppendChild(texts);
            for ( int i = 0; i < 10; i++)
            {
                var text = doc.CreateElement("text");
                text.SetAttribute("name", $"someText_{i+2}");
                text.InnerText = $"targetValue_{i+1}";
                texts.AppendChild(text);
            }

            doc.Save("test.xml");
        }
    }
}
