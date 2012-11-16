using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using Podaci;

namespace Bilance
{
    public enum NameOfBilanceFile
    {
        SifraBilancePeriod,
        IdBilancePeriod,
        SifraDatum,
        IdDatum,
        NazivSifraDatum
    }

    class BilanceSetup
    {
        private const string _XmlFileName = "BilanceSetup.xml";

        public string BilanceFile { get; set; }
        public string BilanceFolder { get; set; }
        public DateTime BilanceOdDatuma { get; set; }
        public DateTime BilanceDoDatuma { get; set; }
        public DateTime BilanceDatumPredaje { get; set; }
        public NameOfBilanceFile CreateFileName { get; set; }
        public string KnjigovodjaIme { get; set; }
        public string KnjigovodjaAdresa { get; set; }
        public string KnjigovodjaID { get; set; }
        public string KnjigovodjaLicenca { get; set; }
        public string KnjigovodjaTelefon { get; set; }


        public static string XmlFileName
        {
            get
            {
                return Utility.GetFilePath(_XmlFileName);
            }
        }
        public string GetBilanceName(Korisnik korisnik)
        {
            string bilanceName = "";
            string extension = "";

            extension = Path.GetExtension(BilanceFile);

            if (korisnik != null)
            {
                switch (CreateFileName)
                {
                    case NameOfBilanceFile.SifraBilancePeriod:
                        bilanceName = korisnik.SifraKor + "_Bilance_" + BilanceOdDatuma.ToShortDateString() + "-" + BilanceDoDatuma.ToShortDateString();
                        break;
                    case NameOfBilanceFile.IdBilancePeriod:
                        bilanceName = korisnik.MatBroj + "_Bilance_" + BilanceOdDatuma.ToShortDateString() + "-" + BilanceDoDatuma.ToShortDateString();
                        break;
                    case NameOfBilanceFile.SifraDatum:
                        bilanceName = korisnik.SifraKor + "_" + BilanceDoDatuma.ToShortDateString();
                        break;
                    case NameOfBilanceFile.IdDatum:
                        bilanceName = korisnik.MatBroj + "_" + BilanceDoDatuma.ToShortDateString();
                        break;
                    case NameOfBilanceFile.NazivSifraDatum:
                        bilanceName = GetNazivKorisnika(korisnik.NazivKor) + "_" + korisnik.SifraKor + "_Bilance_" + BilanceDoDatuma.ToShortDateString();
                        break;
                    default:
                        bilanceName = korisnik.SifraKor + "_" + BilanceDoDatuma.ToShortDateString();
                        break;
                }
            }
            else
            {
                bilanceName = "NepoznatKorisnik_" + BilanceDoDatuma.ToShortDateString();
            }

            return bilanceName + extension;
        }

        private string GetNazivKorisnika(string nazivKor)
        {
            string naziv = nazivKor;

            naziv = naziv.Replace("\'", String.Empty);
            naziv = naziv.Replace("\"", String.Empty);
            naziv = naziv.Replace(".", String.Empty);
            naziv = naziv.Replace("/", String.Empty);
            naziv = naziv.Replace("\\", String.Empty);
            naziv = naziv.Replace("<", String.Empty);
            naziv = naziv.Replace(">", String.Empty);
            naziv = naziv.Replace(":", "-");
            naziv = naziv.Replace("|", "-");
            naziv = naziv.Replace("?", String.Empty);
            naziv = naziv.Replace("*", String.Empty);
            
            if (naziv.Length > 0)
            {
                naziv = naziv.Substring(0, Math.Min(25, naziv.Length));
            }

            return naziv;
        }


        public static BilanceSetup GetSetupFromXml()
        {
            BilanceSetup bs = null;

            if (File.Exists(XmlFileName))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;

                XmlReader xmlIn = XmlReader.Create(XmlFileName, settings);

                if (xmlIn.ReadToDescendant("OpciParametri"))
                {

                    bs = new BilanceSetup();

                    xmlIn.ReadStartElement("OpciParametri");

                    bs.BilanceFile = xmlIn.ReadElementContentAsString();
                    bs.BilanceFolder = xmlIn.ReadElementContentAsString();
                    bs.BilanceOdDatuma = Convert.ToDateTime(xmlIn.ReadElementContentAsString());
                    bs.BilanceDoDatuma = Convert.ToDateTime(xmlIn.ReadElementContentAsString());
                    bs.BilanceDatumPredaje = Convert.ToDateTime(xmlIn.ReadElementContentAsString());

                    string createFileName = xmlIn.ReadElementContentAsString();
                    switch (createFileName)
                    {
                        case "SifraBilancePeriod":
                            bs.CreateFileName = NameOfBilanceFile.SifraBilancePeriod;
                            break;
                        case "IdBilancePeriod":
                            bs.CreateFileName = NameOfBilanceFile.IdBilancePeriod;
                            break;
                        case "SifraDatum":
                            bs.CreateFileName = NameOfBilanceFile.SifraDatum;
                            break;
                        case "IdDatum":
                            bs.CreateFileName = NameOfBilanceFile.IdDatum;
                            break;
                        case "NazivSifraDatum":
                            bs.CreateFileName = NameOfBilanceFile.NazivSifraDatum;
                            break;
                        default:
                            bs.CreateFileName = NameOfBilanceFile.SifraDatum;
                            break;
                    }

                    bs.KnjigovodjaIme = xmlIn.ReadElementContentAsString();
                    bs.KnjigovodjaAdresa = xmlIn.ReadElementContentAsString();
                    bs.KnjigovodjaID = xmlIn.ReadElementContentAsString();
                    bs.KnjigovodjaLicenca = xmlIn.ReadElementContentAsString();
                    bs.KnjigovodjaTelefon = xmlIn.ReadElementContentAsString();



                }

                xmlIn.Close();

            }
            return bs;
        }

        public string GetDestinationFileName(Korisnik korisnik)
        {
            return BilanceFolder + "\\" + GetBilanceName(korisnik);

        }

    }
}
