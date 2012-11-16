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
    public partial class frmBrutoBilansPoGrupama : Form
    {
        public SortableSearchableList<BrutoBilans> brutoBilans = null;
        private SortableSearchableList<BrutoBilans> grupeBilans = null;
        private Korisnik selectedKorisnik;

        public frmBrutoBilansPoGrupama(SortableSearchableList<BrutoBilans> bb, DateTime odDatuma, DateTime doDatuma, ProgramItem selectedProgram, Korisnik selectedKorisnik )
        {
            InitializeComponent();
            txtOdDatuma.Text = odDatuma.ToShortDateString();
            txtDoDatuma.Text = doDatuma.ToShortDateString();
            
            this.txtProgram.Text = selectedProgram.ImeMape;
            this.txtKorisnik.Text = selectedKorisnik.SifraKor + ": " + selectedKorisnik.NazivKor;
            this.selectedKorisnik = selectedKorisnik;

            brutoBilans = bb;

            brutoBilansDataGridView.Focus();
            
            cboGrupa.SelectedIndex = 0;

        }

        private void frmBrutoBilansPoGrupama_Load(object sender, EventArgs e)
        {
            PrikaziPoGrupama();

        }

        private void PrikaziPoGrupama()
        {
            brutoBilansBindingSource.Clear();

            grupeBilans = BrutoBilansDB.BrutoBilansPoGrupma(brutoBilans, cboGrupa.Text);

            brutoBilansBindingSource.DataSource = grupeBilans;
            brutoBilansBindingSource.Position = 0;
            brutoBilansDataGridView.Focus();
        }

        private void cboGrupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziPoGrupama();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            frmBrutoBilansPoGrupamaPrint frm = new frmBrutoBilansPoGrupamaPrint();
            frm.grupeBilans = this.grupeBilans;
            frm.selectedKorisnik = this.selectedKorisnik;

            frm.odDatuma = txtOdDatuma.Text;
            frm.doDatuma = txtDoDatuma.Text;
            frm.Show();
        }

        private void btnIspisPS_Click(object sender, EventArgs e)
        {
            frmBrutoBilansPoGrupamaPrintExt frm = new frmBrutoBilansPoGrupamaPrintExt();
            frm.grupeBilans = this.grupeBilans;
            frm.selectedKorisnik = this.selectedKorisnik;

            frm.odDatuma = txtOdDatuma.Text;
            frm.doDatuma = txtDoDatuma.Text;
            frm.Show();
        }
    }
}
