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
    public partial class frmBrutoBilans : Form
    {
        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        private string dbfFolderName = "";
        private string dbfKontaFolderName = "";

        private SortableSearchableList<BrutoBilans> brutoBilans = null;

        
        private List<string> listaKontaGk = null;
        private List<DateTime> listaDatumaGk = null;
       
        public frmBrutoBilans()
        {
            InitializeComponent();
            listaKontaGk = new List<string>();
            listaDatumaGk = new List<DateTime>();
            brutoBilans = new SortableSearchableList<BrutoBilans>();
            progressBar.Visible = false;


        }

        private void frmBrutoBilans_Load(object sender, EventArgs e)
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
                      

                        listaDatumaGk = NalogGkDB.GetDatumeGk(dbfFolderName);

                        if (listaDatumaGk.Count == 2)
                        {
                            dtpOdDatuma.Value = listaDatumaGk[0];
                            dtpDoDatuma.Value = listaDatumaGk[1];
                        }


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message); ;
                    }

                }
            }

        }

        private void RefreshBrutoBilans()
        {

            if (ValidData())
            {
                ClearBrutoBilans();

                backgroundWorker.RunWorkerAsync();
      
            }

        }

        private void ClearBrutoBilans()
        {

            brutoBilans.Clear();

            brutoBilansBindingSource.Clear();

            brutoBilansBindingSource.DataSource = brutoBilans;
            brutoBilansBindingSource.Position = 0;
            
            decimal[] ukupno = BrutoBilans.GetUkupnoBrutoBilans(brutoBilans);
            DisplayObracun(ukupno);

        }

        private bool ValidData()
        {
            return Validator.IsPeriod(dtpOdDatuma.Value.Date, dtpDoDatuma.Value.Date);
        }

        private void btnPrikaziBilans_Click(object sender, EventArgs e)
        {
        
            progressBar.Visible = true;
            this.Tag = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
   
            RefreshBrutoBilans();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            brutoBilans = BrutoBilansDB.GetBrutoBilans(dbfFolderName, dbfKontaFolderName, dtpOdDatuma.Value.Date, dtpDoDatuma.Value.Date);
            decimal[] ukupno = BrutoBilans.GetUkupnoBrutoBilans(brutoBilans);
            DisplayObracun(ukupno);

        }
      
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
  
            brutoBilansBindingSource.Clear();

            brutoBilansBindingSource.DataSource = brutoBilans;
            brutoBilansBindingSource.Position = 0;
            brutoBilansDataGridView.Focus();

            progressBar.Visible = false;
            this.Cursor = (Cursor)this.Tag;
            
        }

        private void DisplayObracun(decimal[] ukupnoBilans)
        {
            txtDugujePS.Text = ukupnoBilans[0].ToString("N2");
            txtPotrazujePS.Text = ukupnoBilans[1].ToString("N2");
            txtSaldoPS.Text = ukupnoBilans[2].ToString("N2");

            txtDugujeTP.Text = ukupnoBilans[3].ToString("N2");
            txtPotrazujeTP.Text = ukupnoBilans[4].ToString("N2");
            txtSaldoTP.Text = ukupnoBilans[5].ToString("N2");

            txtDugujeUP.Text = ukupnoBilans[6].ToString("N2");
            txtPotrazujeUP.Text = ukupnoBilans[7].ToString("N2");
            txtSaldoUP.Text = ukupnoBilans[8].ToString("N2");

            txtBrojKnjizenja.Text = ukupnoBilans[9].ToString();

        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = !panel4.Visible;
            if (panel4.Visible)
            {
                btnPrikaziUkupno.Text = "Sakrij ukupno";
            }
            else
            {
                btnPrikaziUkupno.Text = "Prikaži ukupno";
            }
        }

        private void btnKartica_Click(object sender, EventArgs e)
        {
            if ((this.selectedProgram != null) && (this.selectedKorisnik != null))
            {
                DataGridViewSelectedRowCollection rows = brutoBilansDataGridView.SelectedRows;

                if (rows.Count > 0)
                {
                    DataGridViewRow row = rows[0];
                    BrutoBilans bb = (BrutoBilans)row.DataBoundItem;

                    PrikaziKarticu(bb);
                    
                }

            }

        }

        private void brutoBilansDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            DataGridViewRow row = brutoBilansDataGridView.Rows[rowIndex];

            BrutoBilans bb = (BrutoBilans)row.DataBoundItem;

            PrikaziKarticu(bb);
            
        }

        private void PrikaziKarticu(BrutoBilans bb)
        {
            frmAnalitickaKartica frm = new frmAnalitickaKartica();

            frm.externalInput = true;
            frm.inputKonto = bb.KontoFormated;
            frm.inputOdDatuma = dtpOdDatuma.Value;
            frm.inputDoDatuma = dtpDoDatuma.Value;

            frm.Show();

        }

        private void dtpOdDatuma_ValueChanged(object sender, EventArgs e)
        {
            ClearBrutoBilans();
        }

        private void dtpDoDatuma_ValueChanged(object sender, EventArgs e)
        {
            ClearBrutoBilans();
        }

        private void btnPoGrupama_Click(object sender, EventArgs e)
        {
            frmBrutoBilansPoGrupama frm = new frmBrutoBilansPoGrupama(brutoBilans, dtpOdDatuma.Value.Date, dtpDoDatuma.Value.Date, selectedProgram, selectedKorisnik);
        //    frm.brutoBilans = this.brutoBilans;
            frm.Show();
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            frmBrutoBilansPrint frm = new frmBrutoBilansPrint();

            frm.brutoBilans = this.brutoBilans;
            frm.selectedKorisnik = this.selectedKorisnik;
           
            frm.odDatuma = dtpOdDatuma.Value.Date;
            frm.doDatuma = dtpDoDatuma.Value.Date;

            frm.Show();
        }

        private void btnIspisPS_Click(object sender, EventArgs e)
        {
            frmBrutoBilansPrintExt frm = new frmBrutoBilansPrintExt();

            frm.brutoBilans = this.brutoBilans;
            frm.selectedKorisnik = this.selectedKorisnik;

            frm.odDatuma = dtpOdDatuma.Value.Date;
            frm.doDatuma = dtpDoDatuma.Value.Date;

            frm.Show();
        }

       

    }
}
