using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Podaci;

namespace Bilance
{
    public partial class frmGlavnaKnjigaPrint : Form
    {
        public SortableSearchableList<ItemGk> listaItemsGk = null;
        public Korisnik selectedKorisnik = null;
        public NalogGk selectedNalogGk = null;

           

        public frmGlavnaKnjigaPrint()
        {
            InitializeComponent();
        }

        private void frmGlavnaKnjigaPrint_Load(object sender, EventArgs e)
        {
            ReportParameter rp = new ReportParameter("SifraKorisnika", selectedKorisnik.SifraKor);
            this.reportViewer1.LocalReport.SetParameters(rp);

            ReportParameter rp1 = new ReportParameter("NazivKorisnika", selectedKorisnik.NazivKor);
            this.reportViewer1.LocalReport.SetParameters(rp1);

            ReportParameter rp2 = new ReportParameter("SjedisteKorisnika", selectedKorisnik.Adresa2);
            this.reportViewer1.LocalReport.SetParameters(rp2);

            ReportParameter rp3 = new ReportParameter("BrojNaloga", selectedNalogGk.BrojNalogaFormated);
            this.reportViewer1.LocalReport.SetParameters(rp3);

            //if (selectedNalogGk.DatumNaloga.HasValue)
            //{
            //    ReportParameter rp4 = new ReportParameter("DatumNaloga", selectedNalogGk.DatumNaloga.Value.ToShortDateString());
            //    this.reportViewer1.LocalReport.SetParameters(rp4);
            //}
            //else
            //{
            //    ReportParameter rp4 = new ReportParameter("DatumNaloga", "");
            //    this.reportViewer1.LocalReport.SetParameters(rp4);
            //}


            ReportParameter rp4 = new ReportParameter("DatumNaloga", selectedNalogGk.DatumNaloga.ToShortDateString());
            this.reportViewer1.LocalReport.SetParameters(rp4);
            


            ReportParameter rp5 = new ReportParameter("OpisNaloga", selectedNalogGk.OpisNaloga);
            this.reportViewer1.LocalReport.SetParameters(rp5);

            ReportParameter rp6 = new ReportParameter("VrstaNaloga", selectedNalogGk.OpisVrsteNaloga);
            this.reportViewer1.LocalReport.SetParameters(rp6);

            this.ItemGkBindingSource.DataSource = listaItemsGk;

            this.reportViewer1.RefreshReport();
        }
    }
}
