using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Podaci;

namespace Bilance
{
    public partial class frmAnalitickaKartica : Form
    {
        public string inputKonto;
        public DateTime inputOdDatuma;
        public DateTime inputDoDatuma;
        public bool externalInput = false;

        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        private string dbfFolderName = "";
        private string dbfKontaFolderName = "";
       
        private SortableSearchableList<AnalitickaKartica> listaItemsKonta = null;
       
        private AnalitickiKonto selectedKonto = null;
        private SintetickiKonto selectedSintKonto = null;
        private List<string> listaKontaGk = null;
        private List<DateTime> listaDatumaGk = null;

        public frmAnalitickaKartica()
        {
            InitializeComponent();
            listaKontaGk = new List<string>();
            listaDatumaGk = new List<DateTime>();
            listaItemsKonta = new SortableSearchableList<AnalitickaKartica>();
        }

        private void frmAnalitickaKartica_Load(object sender, EventArgs e)
        {
            selectedProgram = ProgramItem.GetSelectedProgramFromXml();
            Korisnik korisnikFromXml = KorisnikXML.GetSelectedKorisnikFromXml();
            if (korisnikFromXml != null)
            {
                selectedKorisnik = KorisnikDB.GetKorisnik(korisnikFromXml.Lokacija, korisnikFromXml.SifraKor);
            }

            if ((selectedProgram != null) && (selectedKorisnik != null))
            {
                this.txtProgram.Text = selectedProgram.ImeMape;
                this.txtKorisnik.Text = selectedKorisnik.SifraKor + ": " + selectedKorisnik.NazivKor;

                dbfFolderName = Utility.GetDbfFolder(selectedProgram, selectedKorisnik);
                dbfKontaFolderName = Utility.GetDbfFolderKonta(selectedProgram, selectedKorisnik);

                if ((NalogGkDB.DbfFileExists(dbfFolderName)) && (ItemGkDB.DbfFileExists(dbfFolderName)))

                {

                    try
                    {
                        listaKontaGk = ItemGkDB.GetKontaGk(dbfFolderName);
                        cboKonto.DataSource = listaKontaGk;

                        listaDatumaGk = NalogGkDB.GetDatumeGk(dbfFolderName);

                        if (listaDatumaGk.Count == 2)
                        {
                            dtpOdDatuma.Value = listaDatumaGk[0];
                            dtpDoDatuma.Value = listaDatumaGk[1];
                        }

                        if (externalInput)
                        {
                            cboKonto.Text = inputKonto;
                            dtpOdDatuma.Value = inputOdDatuma;
                            dtpDoDatuma.Value = inputDoDatuma;
                            btnPrikaziKarticu.PerformClick();
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message); ;
                    }

                }
            }

        }


        private void RefreshAnalitickaKartica()
        {

            if (ValidData())
            {
                ClearAnalitickaKartica();

                listaItemsKonta = AnalitickaKarticaDB.GetItemsGkByKonto(dbfFolderName, cboKonto.Text, dtpOdDatuma.Value.Date, dtpDoDatuma.Value.Date);

                decimal[] ukupno = AnalitickaKartica.GetUkupnoKartice(listaItemsKonta);
                DisplayObracun(ukupno);

                analitickaKarticaBindingSource.Clear();

                analitickaKarticaBindingSource.DataSource = listaItemsKonta;
                analitickaKarticaBindingSource.Position = 0; 
            }

        }

        private void ClearAnalitickaKartica()
        {

            listaItemsKonta.Clear();

            analitickaKarticaBindingSource.Clear();

            analitickaKarticaBindingSource.DataSource = listaItemsKonta;
            analitickaKarticaBindingSource.Position = 0;
            
            decimal[] ukupno = AnalitickaKartica.GetUkupnoKartice(listaItemsKonta);
            DisplayObracun(ukupno);

        }

        private void DisplayKonto()
        {
            string sintKonto = "";

            if (cboKonto.Text.Length >= 3)
            {
                sintKonto = cboKonto.Text.Substring(0, 3);
                selectedSintKonto = SintetickiKontoDB.GetSintetickiKonto(dbfKontaFolderName, sintKonto);
            }
            else
            {
                selectedSintKonto = null;
            }

            selectedKonto = AnalitickiKontoDB.GetAnalitickiKonto(dbfKontaFolderName, cboKonto.Text);

            if (selectedKonto != null)
            {
                txtAOPOznaka.Text = selectedKonto.AOPOznaka;
                txtNazivAnalitickogKonta.Text = selectedKonto.NazivKonta;

            }
            else
            {
                txtNazivAnalitickogKonta.Text = "";
                txtAOPOznaka.Text = "";
                chbKontoIspravke.Checked = false;
            }

            if (selectedSintKonto != null)
            {
                txtNazivSintetickogKonta.Text = selectedSintKonto.NazivKonta;
            }
            else
            {
                txtNazivSintetickogKonta.Text = "";
            }
 
        }

        private void cboKonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisplayKonto();
                ClearAnalitickaKartica(); 
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void DisplayObracun(decimal[] ukupnoKartice)
        {
            txtDugujePS.Text = ukupnoKartice[0].ToString("N2");
            txtPotrazujePS.Text = ukupnoKartice[1].ToString("N2");
            txtSaldoPS.Text = ukupnoKartice[2].ToString("N2");

            txtDugujeTP.Text = ukupnoKartice[3].ToString("N2");
            txtPotrazujeTP.Text = ukupnoKartice[4].ToString("N2");
            txtSaldoTP.Text = ukupnoKartice[5].ToString("N2");

            txtDugujeUP.Text = ukupnoKartice[6].ToString("N2");
            txtPotrazujeUP.Text = ukupnoKartice[7].ToString("N2");
            txtSaldoUP.Text = ukupnoKartice[8].ToString("N2");

        }

        private void btnPrikaziKarticu_Click(object sender, EventArgs e)
        {
            RefreshAnalitickaKartica();
        }

        private void cboKonto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayKonto();
            ClearAnalitickaKartica();
        }

        private bool ValidData()
        {
            return (Validator.IsPresent(cboKonto, "Analitički konto") || (cboKonto.Text.Length >=7)) &&
                   Validator.IsPeriod(dtpOdDatuma.Value.Date, dtpDoDatuma.Value.Date);
        }

        private void dtpOdDatuma_ValueChanged(object sender, EventArgs e)
        {
            ClearAnalitickaKartica();

        }

        private void btnKontniPlan_Click(object sender, EventArgs e)
        {
            if ((this.selectedProgram != null) && (this.selectedKorisnik != null))
            {
                frmAnalitickiKontniPlan frm = new frmAnalitickiKontniPlan();

           //     frm.MdiParent = this;

                frm.ShowDialog();


                if (frm.Tag != null)
                {
                    string selKonto = frm.Tag.ToString();

                    if (selKonto != "")
                    {
                        cboKonto.Text = selKonto;
                        DisplayKonto();
                        ClearAnalitickaKartica();
                        // cboKonto.SelectedValue = selKonto;
                    } 
                }
            }

        }

        private void btnIspisKartice_Click(object sender, EventArgs e)
        {
            frmAnalitickaKarticaPrint frm = new frmAnalitickaKarticaPrint();
            
            frm.kartica = this.listaItemsKonta;
            frm.selectedKorisnik = this.selectedKorisnik;
            frm.selectedKonto = this.selectedKonto;
            frm.selectedSintKonto = this.selectedSintKonto;
            frm.odDatuma = dtpOdDatuma.Value.Date;
            frm.doDatuma = dtpDoDatuma.Value.Date;
   
            frm.Show();
        }


    }
}
