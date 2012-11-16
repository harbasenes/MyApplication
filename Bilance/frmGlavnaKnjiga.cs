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
    public partial class frmGlavnaKnjiga : Form
    {
        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        private string dbfFolderName = "";
        private string dbfKontaFolderName = "";
        private SortableSearchableList<NalogGk> listaNalogaGk = null;
        private SortableSearchableList<ItemGk> listaItemsGk = null;
        private NalogGk selectedNalogGk = null;
        private List<string> listaKontaNaloga = null;
        private List<decimal> listaIznosaNaloga = null;
        List<string> listaDatuma = null;
    
        public frmGlavnaKnjiga()
        {
            InitializeComponent();
            listaKontaNaloga = new List<string>();
            listaIznosaNaloga = new List<decimal>();
   
        }

        private void frmGlavnaKnjiga_Load(object sender, EventArgs e)
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

            }
        }

        private void FillItemsGk(string brojNaloga)
        {
            if ((selectedProgram != null) && (selectedKorisnik != null))
            {
                dbfFolderName = Utility.GetDbfFolder(selectedProgram, selectedKorisnik);
                dbfKontaFolderName = Utility.GetDbfFolderKonta(selectedProgram, selectedKorisnik);

                if (ItemGkDB.DbfFileExists(dbfFolderName))
                {

                    try
                    {
                        this.itemGkBindingSource.Clear();
                        listaKontaNaloga.Clear();
                        listaIznosaNaloga.Clear();

                        
                            this.Cursor = Cursors.WaitCursor;
                            progressBar1.Visible = true;
                            backgroundWorker2.RunWorkerAsync(brojNaloga);

                        
                        if (itemGkDataGridView.Rows.Count > 0)
                        {
                            itemGkBindingSource.Position = 0;

                            itemGkDataGridView.Rows[0].Selected = true;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška u toku čitanja knjiženja glavne knjige." + "\n" +
                                        ex.Message,
                                        "Greška tokom čitanja podataka",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);

                    }

                }
            }
        
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            
            listaItemsGk = ItemGkDB.GetItemsGkByBrojNaloga(dbfFolderName, (string)e.Argument, dbfKontaFolderName);
            listaKontaNaloga = ItemGkDB.GetKontaNaloga(listaItemsGk);
            listaIznosaNaloga = ItemGkDB.GetIznoseNaloga(listaItemsGk);

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.itemGkBindingSource.DataSource = listaItemsGk;

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

            cboTraziKonto.ComboBox.DataSource = listaKontaNaloga;
            cboIznosKnjizenja.ComboBox.DataSource = listaIznosaNaloga;

            this.Cursor = Cursors.Default;
            progressBar1.Visible = false;
        }

        private void nalogGkDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (backgroundWorker2.IsBusy)
            {
                return;
            }

            if (nalogGkDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = nalogGkDataGridView.SelectedRows[0];

                selectedNalogGk = (NalogGk)row.DataBoundItem;

                string currentBrojNaloga = selectedNalogGk.BrojNaloga;

   
                FillItemsGk(currentBrojNaloga);
            }
            else
            {
                itemGkBindingSource.Clear();
                itemGkDataGridView.Rows.Clear();
                this.txtDuguje.Text = "";
                this.txtPotrazuje.Text = "";
                this.txtSaldo.Text = "";
            }

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

        private void cboBrojnaloga_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindBrojNaloga();
        }

        private void FindBrojNaloga()
        {
            if (nalogGkBindingSource.SupportsSearching)
            {
                string searchText = cboBrojnaloga.ComboBox.Text;
                int rowIndex = 0;

                if (searchText.Length == 6)
                {
                    rowIndex = nalogGkBindingSource.Find("BrojNalogaFormated", searchText);
                }
                else if (searchText.Length == 5)
                {
                    rowIndex = nalogGkBindingSource.Find("BrojNaloga", searchText);
                }

                if (rowIndex >= 0)
                {
                    nalogGkBindingSource.Position = rowIndex;
                }
            }
        }

        private void FindDatumNaloga()
        {
            if (nalogGkBindingSource.SupportsSearching)
            {
                try
                {
                    DateTime searchDatum = Convert.ToDateTime(cboDatumNaloga.ComboBox.Text);
                    int rowIndex = 0;

                    
                    rowIndex = nalogGkBindingSource.Find("DatumNaloga", searchDatum);
                   

                    if (rowIndex >= 0)
                    {
                        nalogGkBindingSource.Position = rowIndex;
                    }
                }
                catch (FormatException)
                {

                    MessageBox.Show("Zadat datum u nepravilnom formatu.\nFormat datuma treba biti dd.mm.gggg ili dd.mm.gg", "Nepravilan datum") ;
                }
            }
        }
        private void cboBrojnaloga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindBrojNaloga();
            }
        }

        private void cboDatumNaloga_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindDatumNaloga();
        }

        private void cboDatumNaloga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
                FindDatumNaloga();
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            btnIspis.PerformClick();
        }

        private void toolStripButtonTraziOpisNaloga_Click(object sender, EventArgs e)
        {
            FindOpisNaloga();

        }

        private void FindOpisNaloga()
        {
            listaNalogaGk = NalogGkDB.GetListaNalogaGkByOpis(dbfFolderName, txtTraziOpisNaloga.Text);
            List<string> listaDatuma = NalogGkDB.GetDatumeNaloga(listaNalogaGk);


            this.nalogGkBindingSource.Clear();

            this.nalogGkBindingSource.DataSource = listaNalogaGk;

            if (nalogGkDataGridView.Rows.Count > 0)
            {
                nalogGkDataGridView.Rows[0].Selected = true;
            }
            cboBrojnaloga.ComboBox.DataSource = listaNalogaGk;
            cboBrojnaloga.ComboBox.DisplayMember = "BrojNalogaFormated";
            cboBrojnaloga.ComboBox.ValueMember = "BrojNaloga";

            cboDatumNaloga.ComboBox.DataSource = listaDatuma;
        }

     

        private void txtTraziOpisNaloga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindOpisNaloga();
            }
        }

        private void btnTraziOpis_Click(object sender, EventArgs e)
        {
            FindOpisKnjizenja(txtTraziOpis.Text);

        }

        private void FindOpisKnjizenja(string opisToFind)
        {
            
            string find = opisToFind.ToUpper();
            int i = 0;
            foreach (DataGridViewRow row in itemGkDataGridView.Rows)
            {
                ItemGk itemGk = (ItemGk)row.DataBoundItem;

                string opisKnj = itemGk.OpisKnjizenja.ToUpper();
                if (opisKnj.IndexOf(find) >= 0)
                {
                    itemGkDataGridView.Rows[i].Selected = true;
                    itemGkBindingSource.Position = i;

                    break;

                }
                i++;
            }
         
        }

        private void FindKonto(string kontoToFind)
        {
            string find = kontoToFind.Replace("-", "");
            int i = 0;
            foreach (DataGridViewRow row in itemGkDataGridView.Rows)
            {
                ItemGk itemGk = (ItemGk)row.DataBoundItem;
              
                if (itemGk.Konto == find)
                {
                    itemGkDataGridView.Rows[i].Selected = true;
                    itemGkBindingSource.Position = i;

                    break;

                }
                i++;
            }
        }

        private void FindIznosKnjizenja(string txtIznos)
        {
            try
            {
                decimal find = Convert.ToDecimal(txtIznos);
                int i = 0;
                foreach (DataGridViewRow row in itemGkDataGridView.Rows)
                {
                    ItemGk itemGk = (ItemGk)row.DataBoundItem;

                    if ((itemGk.Duguje == find) || (itemGk.Potrazuje == find))
                    {
                        itemGkDataGridView.Rows[i].Selected = true;
                        itemGkBindingSource.Position = i;

                        break;

                    }
                    i++;
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("Upisani traženi iznos knjženja nije broj.", "Pogrešan upis iznosa") ;
            }
        }
        
        private void txtTraziOpis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindOpisKnjizenja(txtTraziOpis.Text);
            }
        }

        private void cboTraziKonto_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindKonto(cboTraziKonto.ComboBox.Text);
        }

        private void cboTraziKonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKonto(cboTraziKonto.ComboBox.Text);
            }
        }

        private void cboIznosKnjizenja_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindIznosKnjizenja(cboIznosKnjizenja.ComboBox.Text);
        }

        private void cboIznosKnjizenja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindIznosKnjizenja(cboIznosKnjizenja.ComboBox.Text);
            }
        }

        private void btnUcitajGK_Click(object sender, EventArgs e)
        {

            

            if (NalogGkDB.DbfFileExists(dbfFolderName))
            {

                try
                {
                    
                    this.nalogGkBindingSource.Clear();
                    this.nalogGkDataGridView.Rows.Clear();
                    this.itemGkBindingSource.Clear();
                    this.itemGkDataGridView.Rows.Clear();

                    UcitajNalogeGK();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška u toku čitanja naloga glavne knjige." + "\n" +
                                    ex.Message,
                                    "Greška tokom čitanja podataka",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Ne može se pronaći datoteka sa knjiženim nalozima glavne knjige." + "\n(" + dbfFolderName + "\\" + NalogGkDB.DbfFileName + ")\n",
                                "Greška tokom čitanja podataka",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            
        }

        private void UcitajNalogeGK()
        {
            this.Tag = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            progressBar.Visible = true;

            backgroundWorker1.RunWorkerAsync();
        }

        

    

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            listaNalogaGk = NalogGkDB.GetListaNalogaGk(dbfFolderName);
            listaDatuma = NalogGkDB.GetDatumeNaloga(listaNalogaGk);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar.Visible = false;
            this.Cursor = (Cursor)this.Tag;

            this.nalogGkBindingSource.DataSource = listaNalogaGk;

            if (nalogGkDataGridView.Rows.Count > 0)
            {
                nalogGkDataGridView.Rows[0].Selected = true;
            }

            cboBrojnaloga.ComboBox.DataSource = listaNalogaGk;
            cboBrojnaloga.ComboBox.DisplayMember = "BrojNalogaFormated";
            cboBrojnaloga.ComboBox.ValueMember = "BrojNaloga";

            cboDatumNaloga.ComboBox.DataSource = listaDatuma;


        }

       




    }
}
