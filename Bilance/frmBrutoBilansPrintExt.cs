﻿using System;
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
    public partial class frmBrutoBilansPrintExt : Form
    {
        public Korisnik selectedKorisnik = null;

        public SortableSearchableList<BrutoBilans> brutoBilans = null;

        public DateTime odDatuma;
        public DateTime doDatuma;
        
        public frmBrutoBilansPrintExt()
        {
            InitializeComponent();
        }

        private void frmBrutoBilansPrintExt_Load(object sender, EventArgs e)
        {

            ReportParameter rp = new ReportParameter("SifraKorisnika", selectedKorisnik.SifraKor);
            this.reportViewer1.LocalReport.SetParameters(rp);

            ReportParameter rp1 = new ReportParameter("NazivKorisnika", selectedKorisnik.NazivKor);
            this.reportViewer1.LocalReport.SetParameters(rp1);

            ReportParameter rp2 = new ReportParameter("SjedisteKorisnika", selectedKorisnik.Adresa2);
            this.reportViewer1.LocalReport.SetParameters(rp2);


            ReportParameter rp6 = new ReportParameter("OdDatuma", odDatuma.ToShortDateString());
            this.reportViewer1.LocalReport.SetParameters(rp6);

            ReportParameter rp7 = new ReportParameter("DoDatuma", doDatuma.ToShortDateString());
            this.reportViewer1.LocalReport.SetParameters(rp7);


            this.BrutoBilansBindingSource.DataSource = brutoBilans;
            this.reportViewer1.RefreshReport();
        }
    }
}
