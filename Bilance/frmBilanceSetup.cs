using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Podaci;

using Excel = Microsoft.Office.Interop.Excel;

namespace Bilance
{

    public partial class frmBilanceSetup : Form
    {
        private Korisnik selectedKorisnik = null;
   
        private BilanceSetup setup;

        public frmBilanceSetup()
        {
            InitializeComponent();
        }

        private void btnGetPrazneBilance_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPrazanObrazac.Text = openFileDialog.FileName;
            }
        }

        private void btnGetFolderPopunjeni_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolderPopunjeniObrasci.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSetupToXml()
        {
            

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";

                XmlWriter xmlOut = XmlWriter.Create(BilanceSetup.XmlFileName, settings);

                xmlOut.WriteStartDocument();
                xmlOut.WriteStartElement("Setup");

                xmlOut.WriteStartElement("OpciParametri");
                xmlOut.WriteElementString("BilanceFile", setup.BilanceFile);
                xmlOut.WriteElementString("BilanceFolder", setup.BilanceFolder);
                xmlOut.WriteElementString("BilanceOdDatuma", setup.BilanceOdDatuma.ToShortDateString());
                xmlOut.WriteElementString("BilanceDoDatuma", setup.BilanceDoDatuma.ToShortDateString());
                xmlOut.WriteElementString("BilanceDatumPredaje", setup.BilanceDatumPredaje.ToShortDateString());
                xmlOut.WriteElementString("CreateFileName", setup.CreateFileName.ToString());
                xmlOut.WriteElementString("KnjigovodjaIme", setup.KnjigovodjaIme);
                xmlOut.WriteElementString("KnjigovodjaAdresa", setup.KnjigovodjaAdresa);
                xmlOut.WriteElementString("KnjigovodjaID", setup.KnjigovodjaID);
                xmlOut.WriteElementString("KnjigovodjaLicenca", setup.KnjigovodjaLicenca);
                xmlOut.WriteElementString("KnjigovodjaTelefon", setup.KnjigovodjaTelefon);
                xmlOut.WriteEndElement();
                
                xmlOut.WriteEndElement();

                xmlOut.Close();

        }

        private void CreateSetup()
        {
            
            setup = new BilanceSetup();
            
            setup.BilanceFile = txtPrazanObrazac.Text;
            setup.BilanceFolder = txtFolderPopunjeniObrasci.Text;
            setup.BilanceOdDatuma = dtpOdDatuma.Value.Date;
            setup.BilanceDoDatuma = dtpDoDatuma.Value.Date;
            setup.BilanceDatumPredaje = dtpDatumPredaje.Value.Date;
            
            if (rdoSifraKorisnika.Checked)
	        {
                setup.CreateFileName = NameOfBilanceFile.SifraBilancePeriod;
		 
	        }
            
            if (rdoIdKorisnika.Checked)
	        {
                setup.CreateFileName = NameOfBilanceFile.IdBilancePeriod;
		 
	        }
            if (rdoSifraKorisnika2.Checked)
	        {
                setup.CreateFileName = NameOfBilanceFile.SifraDatum;
		 
	        }

            if (rdoIdKorisnika2.Checked)
            {
                setup.CreateFileName = NameOfBilanceFile.IdDatum;

            }
            
            if (rdoNazivKorisnika.Checked)
            {
                setup.CreateFileName = NameOfBilanceFile.NazivSifraDatum;

            }
    
            setup.KnjigovodjaIme = txtImeRacunovodje.Text;
            setup.KnjigovodjaAdresa = txtAdresaRacunovodje.Text;
            setup.KnjigovodjaID = txtIDbrojRacunovodje.Text;
            setup.KnjigovodjaLicenca = txtLicencaRacunovodje.Text;
            setup.KnjigovodjaTelefon = txtTelefonRacunovodje.Text;

          
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            CreateSetup();
            SaveSetupToXml();
        }

        private void frmBilanceSetup_Load(object sender, EventArgs e)
        {
            setup = BilanceSetup.GetSetupFromXml();
            DisplaySetup();
            
         
            folderBrowserDialog.SelectedPath = txtFolderPopunjeniObrasci.Text;

            Korisnik korisnikFromXml = KorisnikXML.GetSelectedKorisnikFromXml();
            if (korisnikFromXml != null)
            {
                selectedKorisnik = KorisnikDB.GetKorisnik(korisnikFromXml.Lokacija, korisnikFromXml.SifraKor);
            }

        }

        private void DisplaySetup()
        {
            if (setup != null)
            {
                txtPrazanObrazac.Text = setup.BilanceFile;
                txtFolderPopunjeniObrasci.Text = setup.BilanceFolder;
                dtpOdDatuma.Value = setup.BilanceOdDatuma;
                dtpDoDatuma.Value = setup.BilanceDoDatuma;
                dtpDatumPredaje.Value = setup.BilanceDatumPredaje;
            
                if (setup.CreateFileName == NameOfBilanceFile.SifraBilancePeriod)
	            {
                    rdoSifraKorisnika.Checked = true;
	            }
            
                if (setup.CreateFileName == NameOfBilanceFile.IdBilancePeriod)
	            {
                    rdoIdKorisnika.Checked = true;
	            }

                if (setup.CreateFileName == NameOfBilanceFile.SifraDatum)
                {
                    rdoSifraKorisnika2.Checked = true;
                }

                if (setup.CreateFileName == NameOfBilanceFile.IdDatum)
                {
                    rdoIdKorisnika2.Checked = true;
                }
                if (setup.CreateFileName == NameOfBilanceFile.NazivSifraDatum)
                {
                    rdoNazivKorisnika.Checked = true;
                }

                txtImeRacunovodje.Text = setup.KnjigovodjaIme;
                txtAdresaRacunovodje.Text = setup.KnjigovodjaAdresa;
                txtIDbrojRacunovodje.Text = setup.KnjigovodjaID;
                txtLicencaRacunovodje.Text = setup.KnjigovodjaLicenca;
                txtTelefonRacunovodje.Text = setup.KnjigovodjaTelefon;

            
            }
        }

    }
   
}
