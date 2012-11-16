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
    public partial class frmIzborKorisnika : Form
    {
        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        private SortableSearchableList<Korisnik> listaKorisnika = null;
 
        private string dbfFolderName;

        public frmIzborKorisnika()
        {
            InitializeComponent();
        }

        public void GetDbfFolder()
        {

            if (selectedProgram != null)
            {
                dbfFolderName = selectedProgram.ImeMape;
            }
            else
            {
                dbfFolderName  = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDbfFolder();

            if (dbfFolderName != "")
            {
                string pAkt = GetParamAktivni();
                string pPDV = GetParamPdv();
                string pOrg = GetParamOrg();

                listaKorisnika = KorisnikDB.GetListaKorisnika(dbfFolderName, pAkt, pPDV, pOrg);
                if (listaKorisnika.Count() > 0)
                {
                    this.korisnikBindingSource.DataSource = listaKorisnika;
                    CheckSelected();

                }
            }
            else
            {
                MessageBox.Show("Folder u kom je instalirano knjigovodsvo nije upisan.", "Folder nij upisan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void frmIzborKorisnika_Load(object sender, EventArgs e)
        {
            GetSelectedProgram();
            
            selectedKorisnik = KorisnikXML.GetSelectedKorisnikFromXml();
            if (selectedKorisnik != null)
            {
                selectedKorisnik = KorisnikDB.GetKorisnik(dbfFolderName, selectedKorisnik.SifraKor);
            }
            
            WriteToStatusBar();
        }

        private void GetSelectedProgram()
        {
            selectedProgram = ProgramItem.GetSelectedProgramFromXml();
            DisplaySelectedProgram();
            GetDbfFolder();
        }

        public void DisplaySelectedProgram()
        {

            if (selectedProgram != null)
            {
                this.txtGodina.Text = selectedProgram.Godina;
                this.txtImeMape.Text = selectedProgram.ImeMape;
                this.txtVrstaPrograma.Text = selectedProgram.VrstaPrograma;
                this.txtIzvrsnaDatoteka.Text = selectedProgram.IzvrsnaDatoteka;
                this.txtOpisPrograma.Text = selectedProgram.OpisPrograma;
            }
            else
            {
                this.txtGodina.Text = "";
                this.txtImeMape.Text = "";
                this.txtVrstaPrograma.Text = "";
                this.txtIzvrsnaDatoteka.Text = "";
                this.txtOpisPrograma.Text = "";
            }
        }

        private void btnIzborPrograma_Click(object sender, EventArgs e)
        {
            frmIzborPrograma frm = new frmIzborPrograma();
            frm.ShowDialog();
            GetSelectedProgram();
        }

        private string GetParamAktivni()
        {
            if (rdbAktivniAktivni.Checked)
            {
                return "D%";
            }
            if (rdbAktivniNeaktivni.Checked)
            {
                return "N%";
            }
            if (rdbAktivniSvi.Checked)
            {
                return "%";
            }
            return "%";

        }

        private string GetParamPdv()
        {
            if (rdbPDVObveznici.Checked)
            {
                return "R%";
            }
            if (rdbPDVNeobveznici.Checked)
            {
                return "N%";
            }
            if (rdbPDVSvi.Checked)
            {
                return "%";
            }

            return "$";

        }


        private string GetParamOrg()
        {
            if (rdbOrgPreduzeca.Checked)
            {
                return "P%";
            }
            if (rdbOrgRadnje.Checked)
            {
                return "S%";
            }
            if (rdbOrgSvi.Checked)
            {
                return "%";
            }

            return "%";

        }

        private void korisnikDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            DataGridViewRow row = korisnikDataGridView.Rows[rowIndex];

            selectedKorisnik = (Korisnik)row.DataBoundItem;
            selectedKorisnik.Lokacija = selectedProgram.ImeMape;
            
            KorisnikXML.SaveSelectedToXml(selectedKorisnik);
            WriteToStatusBar();

            CheckDataGrid(row);
            
         

        }

        private void btnIzborKorisnika_Click(object sender, EventArgs e)
        {
            if (selectedProgram != null)
            {
                DataGridViewSelectedRowCollection selected = korisnikDataGridView.SelectedRows;
                if (selected.Count > 0)
                {
                    DataGridViewRow row = selected[0];

                    selectedKorisnik = (Korisnik)row.DataBoundItem;
                    selectedKorisnik.Lokacija = selectedProgram.ImeMape;

                    KorisnikXML.SaveSelectedToXml(selectedKorisnik);
                    WriteToStatusBar();

                    CheckDataGrid(row);
                   

                }
                else
                {
                    MessageBox.Show("Nije izabran korisnik na listi korisnika." + "\n" +
                        "Izabrati odgovarajući program i popuniti listu korisnika.",
                        "Nije izabran korisnik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nije izabran program čiji korisnici se žele prikazati." + "\n" +
                    "Izabrati odgovarajući program i popuniti listu korisnika." +"\n" +
                    "Sa liste korisnika izabrati korisnika čiji podaci će se obrađivati.", 
                    "Nije izabran program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CheckDataGrid(DataGridViewRow currentRow)
        {
            foreach (DataGridViewRow  row in korisnikDataGridView.Rows)
            {
                row.Cells[0].Value = false;
            }
            currentRow.Cells[0].Value = true;
        }

        private void CheckSelected()
        {
            foreach (DataGridViewRow row in korisnikDataGridView.Rows)
            {
                if (selectedKorisnik != null)
                {
                    string sifraKor = row.Cells[1].Value.ToString();
                    if (sifraKor == selectedKorisnik.SifraKor)
                    {
                        row.Cells[0].Value = true;
                        row.Selected = true;
                    }
                    else
                    {
                        row.Cells[0].Value = false;
                        row.Selected = false;
                    }
                }
                else
                {
                    row.Cells[0].Value = false;
                    row.Selected = false;
                }
            }
        }

        private void WriteToStatusBar()
        {
            if (selectedKorisnik != null)
            {
                toolStripStatusLabel1.Text = "Korisnik je izabran";
                toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel2.Text = selectedKorisnik.SifraKor;
                toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel3.Text = selectedKorisnik.MatBroj;
                toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel4.Text = selectedKorisnik.NazivKor;
                toolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Right;
            }
            else
            {
                toolStripStatusLabel1.Text = "Korisnik nije izabran";
                toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel2.Text = "";
                toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.None;
                
                toolStripStatusLabel3.Text = "";
                toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.None;
                
                toolStripStatusLabel4.Text = "";
                toolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.None;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPonistiIzbor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Obrisati: " + "\n\n" +
              "1. Listu upisanih korisnika" + "\n" +
              "2. XML datoteku u kojoj je upisan izabrani korisnik (IzabraniKorisnik.xml)",
              "Poništi izbor korisnika", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                
                korisnikDataGridView.Rows.Clear();
                KorisnikXML.DeleteXmlFileIzabraniKorisnik();
                selectedKorisnik = null;
                WriteToStatusBar();

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmIzborKorisnikaPrint frm = new frmIzborKorisnikaPrint();
            frm.listaKorisnika = this.listaKorisnika;
            frm.Show();

        }

        private void korisnikDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            if (colIndex == 0)
            {
                DataGridViewRow row = korisnikDataGridView.Rows[rowIndex];

                selectedKorisnik = (Korisnik)row.DataBoundItem;
                selectedKorisnik.Lokacija = selectedProgram.ImeMape;

                KorisnikXML.SaveSelectedToXml(selectedKorisnik);
                WriteToStatusBar();

                CheckDataGrid(row);
                
            }

        }

        
        

       

    }
}
