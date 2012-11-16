using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Podaci;

namespace Bilance
{
    class KorisnikXML
    {
        private const string _SelectedXmlFileName = "IzabraniKorisnik.xml";

        private static string SelectedXmlFileName
        {
            get
            {
                return Utility.GetFilePath(_SelectedXmlFileName);
            }
        }

        public static void SaveSelectedToXml(Korisnik korisnik)
        {
            if (korisnik != null)
            {

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";

                XmlWriter xmlOut = XmlWriter.Create(SelectedXmlFileName, settings);

                try
                {
                    xmlOut.WriteStartDocument();
                    xmlOut.WriteStartElement("Korisnici");

                    xmlOut.WriteStartElement("IzabraniKorisnik");
                    xmlOut.WriteElementString("Sifra", korisnik.SifraKor);
                    xmlOut.WriteElementString("Naziv", korisnik.NazivKor);
                    xmlOut.WriteElementString("MaticniBroj", korisnik.MatBroj);
                    xmlOut.WriteElementString("PDVBroj", korisnik.PdvBroj);
                    xmlOut.WriteElementString("Adresa1", korisnik.Adresa3);
                    xmlOut.WriteElementString("Adresa2", korisnik.Adresa1);
                    xmlOut.WriteElementString("Sjediste", korisnik.Adresa2);
                    xmlOut.WriteElementString("Lokacija", korisnik.Lokacija);
                    xmlOut.WriteEndElement();

                    xmlOut.WriteEndElement();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    xmlOut.Close();
                }


            }
            else
            {
                if (File.Exists(SelectedXmlFileName))
                {
                    File.Delete(SelectedXmlFileName);
                }

            }

        }

        public static Korisnik GetSelectedKorisnikFromXml()
        {
            Korisnik korisnik = null;

            if (File.Exists(SelectedXmlFileName))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;

                XmlReader xmlIn = XmlReader.Create(SelectedXmlFileName, settings);


                try
                {
                    if (xmlIn.ReadToDescendant("IzabraniKorisnik"))
                    {

                        korisnik = new Korisnik();
                        xmlIn.ReadStartElement("IzabraniKorisnik");

                        korisnik.SifraKor = xmlIn.ReadElementContentAsString();
                        korisnik.NazivKor = xmlIn.ReadElementContentAsString();
                        korisnik.MatBroj = xmlIn.ReadElementContentAsString();
                        korisnik.PdvBroj = xmlIn.ReadElementContentAsString();
                        korisnik.Adresa3 = xmlIn.ReadElementContentAsString();
                        korisnik.Adresa1 = xmlIn.ReadElementContentAsString();
                        korisnik.Adresa2 = xmlIn.ReadElementContentAsString();
                        korisnik.Lokacija = xmlIn.ReadElementContentAsString();

                    }


                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    xmlIn.Close();

                }

            }

            return korisnik;
        }

        public static void DeleteXmlFileIzabraniKorisnik()
        {
            if (File.Exists(SelectedXmlFileName))
            {
                File.Delete(SelectedXmlFileName);
            }

        }

    }
}
