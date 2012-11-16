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
    public partial class frmMain : Form
    {
        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        private string helpFile = "bilance.chm";

        public frmMain()
        {
            InitializeComponent();
        }

        private void programaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzborPrograma frm = new frmIzborPrograma();
            frm.ShowDialog();
            
            selectedProgram = ProgramItem.GetSelectedProgramFromXml();
            GetSelectedKorisnik();
            FillWindowTitle();

            FillStatusBar();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            selectedProgram = ProgramItem.GetSelectedProgramFromXml();

            GetSelectedKorisnik();
            
            FillWindowTitle();
            FillStatusBar();
        }

        private void GetSelectedKorisnik()
        {
            if (selectedProgram != null)
            {
                selectedKorisnik = KorisnikXML.GetSelectedKorisnikFromXml();
            }
            else
            {
                selectedKorisnik = null;
            }

        }

        private void FillWindowTitle()
        {
            if (selectedKorisnik != null)
            {
                this.Text = "Bilance za korisnika: " + selectedKorisnik.SifraKor + " " + selectedKorisnik.NazivKor;
                label1.Text = selectedKorisnik.SifraKor + ": " + selectedKorisnik.NazivKor;
                label1.ForeColor = Color.Black;

            }
            else
            {
                this.Text = "Bilance-Korisnik nije izabran";
                label1.Text = "Korisnik nije izabran";
                label1.ForeColor = Color.Red;
            }
             
        }

        public void FillStatusBar()
        {

            if (selectedProgram != null)
            {
                toolStripStatusLabel1.Text = selectedProgram.Godina;
                toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel2.Text = selectedProgram.VrstaPrograma;
                toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel3.Text = selectedProgram.ImeMape;
                toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel4.Text = selectedProgram.OpisPrograma;
                toolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Right;
            }
            else
            {
                toolStripStatusLabel1.Text = "Program nije izabran";
                toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel2.Text = "";
                toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.None;
                
                toolStripStatusLabel3.Text = "";
                toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.None;
                
                toolStripStatusLabel4.Text = "";
                toolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.None;
            }
        }

        private void korisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzborKorisnika frm = new frmIzborKorisnika();
            frm.ShowDialog();
            selectedProgram = ProgramItem.GetSelectedProgramFromXml();
            GetSelectedKorisnik();            
            FillWindowTitle();
            FillStatusBar();
            

        }

        private void sintrtičkiKontniPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectedProgram == null)
            {
                MessageBox.Show("Knjigovodstveni program za obradu nije izabran." + "\n" +
                                "Izabrati program i pokušati ponovo",
                                "Program  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (this.selectedKorisnik == null)
            {
                MessageBox.Show("Korisnik čiji podaci se obrađuju nije izabran." + "\n" +
                                "Izabrati korisnika i pokušati ponovo",
                                "Korisnik  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmSintetickiKontniPlan frm = new frmSintetickiKontniPlan();

            frm.MdiParent = this;

            frm.Show();
            
        }

        private void analitičkiKontniPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.selectedProgram == null)
            {
                MessageBox.Show("Knjigovodstveni program za obradu nije izabran." + "\n" +
                                "Izabrati program i pokušati ponovo",
                                "Program  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (this.selectedKorisnik == null)
            {
                MessageBox.Show("Korisnik čiji podaci se obrađuju nije izabran." + "\n" +
                                "Izabrati korisnika i pokušati ponovo",
                                "Korisnik  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmAnalitickiKontniPlan frm = new frmAnalitickiKontniPlan();

            frm.MdiParent = this;

            frm.Show();

        }

        private void glavnaKnjigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectedProgram == null)
            {
                MessageBox.Show("Knjigovodstveni program za obradu nije izabran." + "\n" +
                                "Izabrati program i pokušati ponovo",
                                "Program  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (this.selectedKorisnik == null)
            {
                MessageBox.Show("Korisnik čiji podaci se obrađuju nije izabran." + "\n" +
                                "Izabrati korisnika i pokušati ponovo",
                                "Korisnik  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmGlavnaKnjiga frm = new frmGlavnaKnjiga();

            frm.MdiParent = this;

            frm.Show();

        }

        private void analitičkaKarticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectedProgram == null)
            {
                MessageBox.Show("Knjigovodstveni program za obradu nije izabran." + "\n" +
                                "Izabrati program i pokušati ponovo",
                                "Program  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (this.selectedKorisnik == null)
            {
                MessageBox.Show("Korisnik čiji podaci se obrađuju nije izabran." + "\n" +
                                "Izabrati korisnika i pokušati ponovo",
                                "Korisnik  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmAnalitickaKartica frm = new frmAnalitickaKartica();

            frm.MdiParent = this;

            frm.Show();
            

        }

        private void brutoBilansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectedProgram == null)
            {
                MessageBox.Show("Knjigovodstveni program za obradu nije izabran." + "\n" +
                                "Izabrati program i pokušati ponovo",
                                "Program  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (this.selectedKorisnik == null)
            {
                MessageBox.Show("Korisnik čiji podaci se obrađuju nije izabran." + "\n" +
                                "Izabrati korisnika i pokušati ponovo",
                                "Korisnik  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

                frmBrutoBilans frm = new frmBrutoBilans();

                frm.MdiParent = this;

                frm.Show();

        }

        private void podešenjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBilanceSetup frm = new frmBilanceSetup();

            frm.ShowDialog();
        }

        private void formirajBilanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormirajBilance frm = new frmFormirajBilance();
            frm.ShowDialog();
        }

        private void specijalniNaloziGlavneKnjigeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectedProgram == null)
            {
                MessageBox.Show("Knjigovodstveni program za obradu nije izabran." + "\n" +
                                "Izabrati program i pokušati ponovo",
                                "Program  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (this.selectedKorisnik == null)
            {
                MessageBox.Show("Korisnik čiji podaci se obrađuju nije izabran." + "\n" +
                                "Izabrati korisnika i pokušati ponovo",
                                "Korisnik  nije izabran",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmSpecijalniNaloziGk frm = new frmSpecijalniNaloziGk();

            frm.MdiParent = this;

            frm.Show();

        }

        private void poredajUKaskaduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void pločiceHorizontalnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void pločiceVertikalnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();

            frm.ShowDialog();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpFile);
        }

        private void formirajDatotekuZaAfipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAfip frm = new frmAfip();

            frm.MdiParent = this;

            frm.Show();

        }
    }
}
