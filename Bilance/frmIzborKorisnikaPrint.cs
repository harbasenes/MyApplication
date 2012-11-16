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
    public partial class frmIzborKorisnikaPrint : Form
    {
        public SortableSearchableList<Korisnik> listaKorisnika = null;

        public frmIzborKorisnikaPrint()
        {
            InitializeComponent();
        }

        private void frmIzborKorisnikaPrint_Load(object sender, EventArgs e)
        {
            this.KorisnikBindingSource.DataSource = listaKorisnika;
            this.reportViewer1.RefreshReport();
        }
    }
}
