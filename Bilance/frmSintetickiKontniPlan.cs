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
    public partial class frmSintetickiKontniPlan : Form
    {
        public ProgramItem selectedProgram = null;
        public Korisnik selectedKorisnik = null;
        private string dbfFolderName = "";
        private SortableSearchableList<SintetickiKonto> listaSKP = null;

        public frmSintetickiKontniPlan()
        {
            InitializeComponent();
        }

        private void frmSintetickiKontniPlan_Load(object sender, EventArgs e)
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

                this.txtDbfFajl.Text = dbfFolderName + "\\" + SintetickiKontoDB.DbfFileName;

                if (SintetickiKontoDB.DbfFileExists(dbfFolderName))
                {

                    try
                    {
                        listaSKP = SintetickiKontoDB.GetSintetickiKontniPlan(dbfFolderName);
                        List<String> listaAOP = SintetickiKontoDB.GetAOPOznake(listaSKP);

                        this.sintetickiKontoBindingSource.DataSource = listaSKP;
                        
                        this.bindingNavigatorKonto.ComboBox.DataSource = listaSKP;
                        this.bindingNavigatorKonto.ComboBox.DisplayMember = "Konto";
                        this.bindingNavigatorKonto.ComboBox.ValueMember = "Konto";
                        
                        this.bindingNavigatorAOP.ComboBox.DataSource = listaAOP;
                        //this.bindingNavigatorAOP.ComboBox.DisplayMember = "AOPOznaka";
                        //this.bindingNavigatorAOP.ComboBox.ValueMember = "Konto";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška u toku čitanja sintetičkog kontnog plana." + "\n" +
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

        private void sintetickiKontoDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.PageDown) && (e.Modifiers == Keys.Control))
            {
                this.sintetickiKontoBindingSource.MoveLast();
                e.Handled = true;
            }
            if ((e.KeyCode == Keys.PageUp) && (e.Modifiers == Keys.Control))
            {
                this.sintetickiKontoBindingSource.MoveFirst();
                e.Handled = true;
            }
        }


        private void bindingNavigatorKonto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sintetickiKontoBindingSource.SupportsSearching)
            {
                int rowIndex = sintetickiKontoBindingSource.Find("Konto", bindingNavigatorKonto.Text);
                if (rowIndex >= 0)
                {
                    sintetickiKontoBindingSource.Position = rowIndex;
                }
            }
        }

        private void bindingNavigatorAOP_TextChanged(object sender, EventArgs e)
        {
            if (sintetickiKontoBindingSource.SupportsSearching)
            {
                int rowIndex = sintetickiKontoBindingSource.Find("AOPOznaka", bindingNavigatorAOP.Text);
                if (rowIndex >= 0)
                {
                    sintetickiKontoBindingSource.Position = rowIndex;
                }
            }

        }

        private void bindingNavigatorBtnTrazi_Click(object sender, EventArgs e)
        {
            try
            {
                listaSKP = SintetickiKontoDB.GetSintetickiKontniPlanByName(dbfFolderName, bindingNavigatorNazivKonta.Text);

                List<String> listaAOP = SintetickiKontoDB.GetAOPOznake(listaSKP);

                this.sintetickiKontoBindingSource.Clear();

                this.sintetickiKontoBindingSource.DataSource = listaSKP;

                this.bindingNavigatorKonto.ComboBox.DataSource = listaSKP;
                this.bindingNavigatorKonto.ComboBox.DisplayMember = "Konto";
                this.bindingNavigatorKonto.ComboBox.ValueMember = "Konto";

                this.bindingNavigatorAOP.ComboBox.DataSource = listaAOP;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Greška u toku čitanja sintetičkog kontnog plana." + "\n" +
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
                bindingNavigatorBtnTrazi.PerformClick();
            }
        }

        private void bindingNavigatorKonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bindingNavigatorKonto.ComboBox.Refresh();

            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmSintetickiKontniPlanPrint frm = new frmSintetickiKontniPlanPrint();
            frm.listaSKP = this.listaSKP;
            frm.selectedKorisnik = this.selectedKorisnik;
            frm.Show();
        }

        private void bindingNavigatorBtnPrint_Click(object sender, EventArgs e)
        {
            this.btnPrint.PerformClick();
        }

       

        
    }
}
