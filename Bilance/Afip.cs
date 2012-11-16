using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace Bilance
{
    class Afip
    {
        private const string _XmlFileName = "Afip.xml";

        public string ImePrazanAfip { get; set; }
        public string ImeBilanci { get; set; }
        public string FolderAfip { get; set; }

        private static string XmlFileName
        {
            get
            {
                return Utility.GetFilePath(_XmlFileName);
            }
        }

        public string ImePopunjenAfip()
        {
            string extension = Path.GetExtension(ImeBilanci);
            string fileName = "AFIP-" + Path.GetFileNameWithoutExtension(ImeBilanci);

            return FolderAfip + Path.DirectorySeparatorChar + fileName + extension;
        }

        public static void SaveAfipToXml(Afip af)
        {
            if (af != null)
            {

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";

                XmlWriter xmlOut = XmlWriter.Create(XmlFileName, settings);

                xmlOut.WriteStartDocument();
                xmlOut.WriteStartElement("PodaciAfip");

                xmlOut.WriteStartElement("Afip");
                xmlOut.WriteElementString("ImePrazanAfip", af.ImePrazanAfip);
                xmlOut.WriteElementString("FolderAfip", af.FolderAfip);
                xmlOut.WriteElementString("ImeBilanci", af.ImeBilanci);
                xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.Close();

            }
            else
            {
                if (File.Exists(XmlFileName))
                {
                    File.Delete(XmlFileName);
                }

            }

        }


        public static Afip GetAfipFromXml()
        {
            Afip af = null;

            if (File.Exists(XmlFileName))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;

                XmlReader xmlIn = XmlReader.Create(XmlFileName, settings);

                if (xmlIn.ReadToDescendant("Afip"))
                {

                    af = new Afip();
                    xmlIn.ReadStartElement("Afip");

                    af.ImePrazanAfip = xmlIn.ReadElementContentAsString();
                    af.FolderAfip = xmlIn.ReadElementContentAsString();
                    af.ImeBilanci = xmlIn.ReadElementContentAsString();

                }

                xmlIn.Close();

            }

            return af;
        }

        public static void DeleteXmlFile()
        {
            if (File.Exists(XmlFileName))
            {
                File.Delete(XmlFileName);
            }

        }


    }
}
