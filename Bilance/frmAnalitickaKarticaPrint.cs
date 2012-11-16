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
    public partial class frmAnalitickaKarticaPrint : Form
    {
       
        public Korisnik selectedKorisnik = null;
  
        public SortableSearchableList<AnalitickaKartica> kartica = null;

        public AnalitickiKonto selectedKonto = null;
        public SintetickiKonto selectedSintKonto = null;

        public DateTime odDatuma;
        public DateTime doDatuma;
        
        public frmAnalitickaKarticaPrint()
        {
            InitializeComponent();
        }

        private void frmAnalitickaKarticaPrint_Load(object sender, EventArgs e)
        {

            ReportParameter rp = new ReportParameter("SifraKorisnika", selectedKorisnik.SifraKor);
            this.reportViewer1.LocalReport.SetParameters(rp);

            ReportParameter rp1 = new ReportParameter("NazivKorisnika", selectedKorisnik.NazivKor);
            this.reportViewer1.LocalReport.SetParameters(rp1);

            ReportParameter rp2 = new ReportParameter("SjedisteKorisnika", selectedKorisnik.Adresa2);
            this.reportViewer1.LocalReport.SetParameters(rp2);

            ReportParameter rp3 = new ReportParameter("Konto", selectedKonto.KontoFormated);
            this.reportViewer1.LocalReport.SetParameters(rp3);
            
            ReportParameter rp4 = new ReportParameter("NazivKonta", selectedKonto.NazivKonta);
            this.reportViewer1.LocalReport.SetParameters(rp4);

            ReportParameter rp5 = new ReportParameter("NazivSintetickogKonta", selectedSintKonto.NazivKonta);
            this.reportViewer1.LocalReport.SetParameters(rp5);
            
            ReportParameter rp6 = new ReportParameter("OdDatuma", odDatuma.ToShortDateString());
            this.reportViewer1.LocalReport.SetParameters(rp6);

            ReportParameter rp7 = new ReportParameter("DoDatuma", doDatuma.ToShortDateString());
            this.reportViewer1.LocalReport.SetParameters(rp7);
            
            ReportParameter rp8 = new ReportParameter("RedniBroj", 1.ToString());
            this.reportViewer1.LocalReport.SetParameters(rp8);

            this.analitickaKarticaBindingSource.DataSource = kartica;
            this.reportViewer1.RefreshReport();

          
        }
    }
}
