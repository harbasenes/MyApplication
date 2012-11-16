using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Podaci;
using System.Reflection;

namespace Bilance
{
    public partial class frmSpecijalniNaloziGk : Form
    {
        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        private string dbfFolderName = "";
        private string dbfKontaFolderName = "";
        private SortableSearchableList<ItemGk> listaItemsGk = null;
        private NalogGk selectedNalogGk = null;
        
        public frmSpecijalniNaloziGk()
        {
            InitializeComponent();
            listaItemsGk = new SortableSearchableList<ItemGk>();
            itemGkBindingSource.DataSource = listaItemsGk;

        }

        private void frmSpecijalniNaloziGk_Load(object sender, EventArgs e)
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


                dbfFolderName = Utility.GetDbfFolder(selectedProgram, selectedKorisnik);
                dbfKontaFolderName = Utility.GetDbfFolderKonta(selectedProgram, selectedKorisnik);
                
               cboVrstaNaloga.SelectedIndex = 0;
               progressBar.Visible = false;
              
            }

        }

        private void cboVrstaNaloga_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vrstaNaloga = "";

            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            vrstaNaloga = GetVrstaNaloga(selectedIndex);
            selectedNalogGk = null;
            DisplayNalogGk();
            GetNalogGk(vrstaNaloga);
        }

        private void GetNalogGk(string vrstaNaloga)
        {

            if ((vrstaNaloga != "") && NalogGkDB.DbfFileExists(dbfFolderName) && ItemGkDB.DbfFileExists(dbfFolderName))
            {
                FillItemsGk(vrstaNaloga);

            }
            else
            {
                selectedNalogGk = null;
                DisplayNalogGk();
            }

        }

        private void FillItemsGk(string vrstaNaloga)
        {

            try
            {
                selectedNalogGk = NalogGkDB.GetNalogGkByPocSt(dbfFolderName, vrstaNaloga);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška u toku čitanja naloga glavne knjige." + "\n" +
                ex.Message,
                "Greška tokom čitanja podataka",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            }

            if (selectedNalogGk != null)
            {
                try
                {
                    progressBar.Visible = true;

                    bckWorkerGetGk.RunWorkerAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška u toku čitanja knjiženja naloga glavne knjige." + "\n" +
                    ex.Message,
                    "Greška tokom čitanja podataka",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                }
            }
        }

        private static string GetVrstaNaloga(int selectedIndex)
        {
            string vrstaNaloga = "";

            switch (selectedIndex)
            {
                case 1:
                    vrstaNaloga = "D";
                    break;
                case 2:
                    vrstaNaloga = "3";
                    break;
                case 3:
                    vrstaNaloga = "6";
                    break;
                default:
                    vrstaNaloga = "";
                    break;
            }
            return vrstaNaloga;
        }


        private void DisplayNalogGk()
        {
            if (selectedNalogGk != null)
            {
                txtBrojNaloga.Text = selectedNalogGk.BrojNalogaFormated;
                txtDatumNaloga.Text = selectedNalogGk.DatumNaloga.ToShortDateString();
                txtOpisNaloga.Text = selectedNalogGk.OpisNaloga;
                decimal duguje = 0m;
                decimal potrazuje = 0m;

                foreach (ItemGk item in listaItemsGk)
                {
                    duguje += item.Duguje;
                    potrazuje += item.Potrazuje;

                }
                decimal saldo = duguje - potrazuje;

                txtDuguje.Text = duguje.ToString("N2");
                txtPotrazuje.Text = potrazuje.ToString("N2");
                txtSaldo.Text = saldo.ToString("N2");

                this.itemGkBindingSource.DataSource = listaItemsGk;
                if (itemGkDataGridView.Rows.Count > 0)
                {
                    itemGkBindingSource.Position = 0;

                    itemGkDataGridView.Rows[0].Selected = true;
                    btnIspis.Enabled = true;
                }

            }
            else
            {
                txtBrojNaloga.Text = "";
                txtDatumNaloga.Text = "";
                txtOpisNaloga.Text = "";

                txtDuguje.Text = "";
                txtPotrazuje.Text = "";
                txtSaldo.Text = "";

                
                listaItemsGk.Clear();

                this.itemGkBindingSource.Clear();
                this.itemGkBindingSource.DataSource = listaItemsGk;

                btnIspis.Enabled = false;

            }
        }

        private void bindingNavigatorPrint_Click(object sender, EventArgs e)
        {
            btnIspis.PerformClick();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            frmGlavnaKnjigaPrint frm = new frmGlavnaKnjigaPrint();
            frm.listaItemsGk = this.listaItemsGk;
            frm.selectedKorisnik = this.selectedKorisnik;
            frm.selectedNalogGk = this.selectedNalogGk;

            frm.Show();
        }

       
        private void bckWorkerGetGk_DoWork(object sender, DoWorkEventArgs e)
        {
            listaItemsGk = ItemGkDB.GetItemsGkByBrojNaloga(dbfFolderName, selectedNalogGk.BrojNaloga, dbfKontaFolderName);

        }

        private void bckWorkerGetGk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            DisplayNalogGk();

        }

        
         
       
    }
}
