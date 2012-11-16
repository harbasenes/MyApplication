using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace Bilance
{
    public class ProgramItem
    {
        private const string _XmlFileName = "Programi.xml";
        private const string _SelectedXmlFileName = "SelectedProgram.xml";

        public string Godina { get; set; }
        public string ImeMape { get; set; }
        public string VrstaPrograma { get; set; }
        public string IzvrsnaDatoteka { get; set; }
        public string OpisPrograma { get; set; }

        private static string XmlFileName
        {
            get
            {
                return Utility.GetFilePath(_XmlFileName);
            }
        }
        
        private static string SelectedXmlFileName
        {
            get
            {
                return Utility.GetFilePath(_SelectedXmlFileName);
            }
        }

        public static void SaveToXml(List<ProgramItem> lista)
        {
            if (lista.Count > 0)
            {

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";

                XmlWriter xmlOut = XmlWriter.Create(XmlFileName, settings);

                xmlOut.WriteStartDocument();
                xmlOut.WriteStartElement("Programi");

                foreach (ProgramItem item in lista)
                {
                    xmlOut.WriteStartElement("Program");
                    xmlOut.WriteElementString("Godina", item.Godina);
                    xmlOut.WriteElementString("ImeMape", item.ImeMape);
                    xmlOut.WriteElementString("VrstaPrograma", item.VrstaPrograma);
                    xmlOut.WriteElementString("IzvrsnaDatoteka", item.IzvrsnaDatoteka);
                    xmlOut.WriteElementString("OpisPrograma", item.OpisPrograma);
                    xmlOut.WriteEndElement();

                }

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

        public static List<ProgramItem> GetItemsFromListView(ListView lv)
        {
            List<ProgramItem> lista = new List<ProgramItem>();

            foreach (ListViewItem item in lv.Items)
            {
                ProgramItem prog = new ProgramItem();

                prog.Godina = item.Text;
                prog.ImeMape = item.SubItems[1].Text;
                prog.VrstaPrograma = item.SubItems[2].Text;
                prog.IzvrsnaDatoteka = item.SubItems[3].Text;
                prog.OpisPrograma = item.SubItems[4].Text;

                lista.Add(prog);

            }

            return lista;
        }

        public static void Save(ListView lv)
        {
            List<ProgramItem> lista = GetItemsFromListView(lv);
            SaveToXml(lista);
        }

        public static List<ProgramItem> GetItemsFromXml()
        {
            List<ProgramItem> lista = new List<ProgramItem>();

            if (File.Exists(XmlFileName))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;

                XmlReader xmlIn = XmlReader.Create(XmlFileName, settings);

                if (xmlIn.ReadToDescendant("Program"))
                {
                    do
                    {
                        ProgramItem prog = new ProgramItem();
                        xmlIn.ReadStartElement("Program");

                        prog.Godina = xmlIn.ReadElementContentAsString();
                        prog.ImeMape = xmlIn.ReadElementContentAsString();
                        prog.VrstaPrograma = xmlIn.ReadElementContentAsString();
                        prog.IzvrsnaDatoteka = xmlIn.ReadElementContentAsString();
                        prog.OpisPrograma = xmlIn.ReadElementContentAsString();

                        lista.Add(prog);

                    } while (xmlIn.ReadToNextSibling("Program"));
                }

                xmlIn.Close();
                
            }

            return lista;
        }

        public static void FillListView(ListView lv)
        {
            List<ProgramItem> lista = GetItemsFromXml();

            if (lista.Count > 0)
            {
                foreach (ProgramItem prog in lista)
                {
                    AddItemToListView(lv, prog);

                }

            }
        }

        public static void AddItemToListView(ListView lv, ProgramItem prog)
        {
            ListViewItem item = new ListViewItem(prog.Godina);
           
            item.SubItems.Add(prog.ImeMape);
            item.SubItems.Add(prog.VrstaPrograma);
            item.SubItems.Add(prog.IzvrsnaDatoteka);
            item.SubItems.Add(prog.OpisPrograma);

            lv.Items.Add(item);
        }

        public static ProgramItem GetProgramFromListViewItem(ListViewItem item)
        {
            ProgramItem prog = null;

            if (item != null)
            {
                prog = new ProgramItem();

                prog.Godina = item.Text;
                prog.ImeMape = item.SubItems[1].Text;
                prog.VrstaPrograma = item.SubItems[2].Text;
                prog.IzvrsnaDatoteka = item.SubItems[3].Text;
                prog.OpisPrograma = item.SubItems[4].Text;

            }

            return prog;
        }

        public static void SaveSelectedToXml(ProgramItem prog)
        {
            if (prog != null)
            {

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";

                XmlWriter xmlOut = XmlWriter.Create(SelectedXmlFileName, settings);

                xmlOut.WriteStartDocument();
                xmlOut.WriteStartElement("Programi");

                    xmlOut.WriteStartElement("SelectedProgram");
                    xmlOut.WriteElementString("Godina", prog.Godina);
                    xmlOut.WriteElementString("ImeMape", prog.ImeMape);
                    xmlOut.WriteElementString("VrstaPrograma", prog.VrstaPrograma);
                    xmlOut.WriteElementString("IzvrsnaDatoteka", prog.IzvrsnaDatoteka);
                    xmlOut.WriteElementString("OpisPrograma", prog.OpisPrograma);
                    xmlOut.WriteEndElement();

                xmlOut.WriteEndElement();

                xmlOut.Close();

            }
            else
            {
                if (File.Exists(SelectedXmlFileName))
                {
                    File.Delete(SelectedXmlFileName);
                }

            }

        }

        public static ProgramItem GetSelectedProgramFromXml()
        {
            ProgramItem prog = null;

            if (File.Exists(SelectedXmlFileName))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;

                XmlReader xmlIn = XmlReader.Create(SelectedXmlFileName, settings);

                if (xmlIn.ReadToDescendant("SelectedProgram"))
                {
                   
                        prog = new ProgramItem();
                        xmlIn.ReadStartElement("SelectedProgram");

                        prog.Godina = xmlIn.ReadElementContentAsString();
                        prog.ImeMape = xmlIn.ReadElementContentAsString();
                        prog.VrstaPrograma = xmlIn.ReadElementContentAsString();
                        prog.IzvrsnaDatoteka = xmlIn.ReadElementContentAsString();
                        prog.OpisPrograma = xmlIn.ReadElementContentAsString();
                   
                }

                xmlIn.Close();

            }

            return prog;
        }


        public static bool IsEqual(ProgramItem prog, ListViewItem item)
        {
            return (prog.Godina == item.Text) &&
                (prog.ImeMape == item.SubItems[1].Text) &&
                (prog.VrstaPrograma == item.SubItems[2].Text) &&
                (prog.IzvrsnaDatoteka == item.SubItems[3].Text) &&
                (prog.OpisPrograma == item.SubItems[4].Text);
        }

        public static void DeleteXmlFileProgramList()
        {
            if (File.Exists(XmlFileName))
            {
                File.Delete(XmlFileName);
            }

        }
        
        public static void DeleteXmlFileSelectedProgram()
        {
            if (File.Exists(SelectedXmlFileName))
            {
                File.Delete(SelectedXmlFileName);
            }

        }


    }
}
