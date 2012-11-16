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
    public partial class frmAnalitickiKontniPlan : Form
    {
        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        private string dbfFolderName = "";
        private SortableSearchableList<AnalitickiKonto> listaAKP = null;

        public frmAnalitickiKontniPlan()
        {
            InitializeComponent();
        }

       

        private void frmAnalitickiKontniPlan_Load(object sender, EventArgs e)
        {
            selectedProgram = ProgramItem.GetSelectedProgramFromXml();
            Korisnik korisnikFromXml = KorisnikXML.GetSelectedKorisnikFromXml();
            if (korisnikFromXml != null)
            {
                try
                {
                    selectedKorisnik = KorisnikDB.GetKorisnik(korisnikFromXml.Lokacija, korisnikFromXml.SifraKor);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Greška u toku čitanja baze korisnika." + "\n" +
                    ex.Message, 
                    "Greška tokom čitanja podataka",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                }
            }

            if ((selectedProgram != null) && (selectedKorisnik != null))
            {
                this.txtProgram.Text = selectedProgram.ImeMape;
                this.txtKorisnik.Text = selectedKorisnik.SifraKor + ": " + selectedKorisnik.NazivKor;

                dbfFolderName = Utility.GetDbfFolderKonta(selectedProgram, selectedKorisnik);

                this.txtDbfFajl.Text = dbfFolderName + "\\" + AnalitickiKontoDB.DbfFileName;

                if (SintetickiKontoDB.DbfFileExists(dbfFolderName))
                {

                    try
                    {
                        listaAKP = AnalitickiKontoDB.GetAnalitickiKontniPlan(dbfFolderName);
                        this.analitickiKontoBindingSource.DataSource = listaAKP;

                        this.bindingNavigatorKonto.ComboBox.DataSource = listaAKP;
                        this.bindingNavigatorKonto.ComboBox.DisplayMember = "Konto";
                        this.bindingNavigatorKonto.ComboBox.ValueMember = "Konto";

                        List<String> listaAOP = AnalitickiKontoDB.GetAOPOznake(listaAKP);

                        this.bindingNavigatorAOP.ComboBox.DataSource = listaAOP;

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Greška u toku čitanja analitičkog kontnog plana." + "\n" +
                                        ex.Message, 
                                        "Greška tokom čitanja podataka",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void analitickiKontoDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.PageDown) && (e.Modifiers == Keys.Control))
            {
                this.analitickiKontoBindingSource.MoveLast();
                e.Handled = true;
            }
            if ((e.KeyCode == Keys.PageUp) && (e.Modifiers == Keys.Control))
            {
                this.analitickiKontoBindingSource.MoveFirst();
                e.Handled = true;
            }
        }

        private void bindingNavigatorKonto_TextUpdate(object sender, EventArgs e)
        {
            if (analitickiKontoBindingSource.SupportsSearching)
            {
                int rowIndex = analitickiKontoBindingSource.Find("Konto", bindingNavigatorKonto.Text);
                if (rowIndex >= 0)
                {
                    analitickiKontoBindingSource.Position = rowIndex;
                }
            }

        }

        private void bindingNavigatorAOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (analitickiKontoBindingSource.SupportsSearching)
            {
                int rowIndex = analitickiKontoBindingSource.Find("AOPOznaka", bindingNavigatorAOP.Text);
                if (rowIndex >= 0)
                {
                    analitickiKontoBindingSource.Position = rowIndex;
                }
            }

        }

        private void bindingNavigatorBtnTraziNaziv_Click(object sender, EventArgs e)
        {
            try
            {
                listaAKP = AnalitickiKontoDB.GetAnalitickiKontniPlanByName(dbfFolderName, bindingNavigatorNazivKonta.Text);

                List<String> listaAOP = AnalitickiKontoDB.GetAOPOznake(listaAKP);

                this.analitickiKontoBindingSource.Clear();

                this.analitickiKontoBindingSource.DataSource = listaAKP;

                this.bindingNavigatorKonto.ComboBox.DataSource = listaAKP;
                this.bindingNavigatorKonto.ComboBox.DisplayMember = "Konto";
                this.bindingNavigatorKonto.ComboBox.ValueMember = "Konto";

                this.bindingNavigatorAOP.ComboBox.DataSource = listaAOP;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Greška u toku čitanja analitičkog kontnog plana." + "\n" +
                ex.Message, 
                "Greška tokom čitanja podataka",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            }


        }

        private void bindingNavigatorNazivKonta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bindingNavigatorBtnTraziNaziv.PerformClick();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmAnalitickiKontniPlanPrint frm = new frmAnalitickiKontniPlanPrint();
            frm.listaAKP = this.listaAKP;
            frm.selectedKorisnik = this.selectedKorisnik;
          //  frm.MdiParent = this;
            frm.Show();
        }

        private void bindingNavigatorBtnPrint_Click(object sender, EventArgs e)
        {
            this.btnPrint.PerformClick();
        }

        private void analitickiKontoDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            DataGridViewRow row = analitickiKontoDataGridView.Rows[rowIndex];

            string analitickiKonto = row.Cells[1].Value.ToString();

            this.Tag = analitickiKonto;

            this.DialogResult = DialogResult.OK;
        }

    }
}
