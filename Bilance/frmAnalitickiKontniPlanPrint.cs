using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Podaci;
using Microsoft.Reporting.WinForms;

namespace Bilance
{
    public partial class frmAnalitickiKontniPlanPrint : Form
    {
        public SortableSearchableList<AnalitickiKonto> listaAKP;
        public Korisnik selectedKorisnik = null;

        public frmAnalitickiKontniPlanPrint()
        {
            InitializeComponent();
        }

        private void frmAnalitickiKontniPlanPrint_Load(object sender, EventArgs e)
        {
            ReportParameter rp = new ReportParameter("SifraKorisnika", selectedKorisnik.SifraKor);
            this.reportViewer1.LocalReport.SetParameters(rp);

            ReportParameter rp1 = new ReportParameter("NazivKorisnika", selectedKorisnik.NazivKor);
            this.reportViewer1.LocalReport.SetParameters(rp1);

            ReportParameter rp2 = new ReportParameter("SjedisteKorisnika", selectedKorisnik.Adresa2);
            this.reportViewer1.LocalReport.SetParameters(rp2);


            this.AnalitickiKontoBindingSource.DataSource = listaAKP;
            this.reportViewer1.RefreshReport();
        }
    }
}
