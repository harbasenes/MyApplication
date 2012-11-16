using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Podaci;

namespace Bilance
{
    public partial class frmIzborPrograma : Form
    {
        private ProgramItem prog = null;

        public frmIzborPrograma()
        {
            InitializeComponent();
        }


        private void frmIzborPrograma_Load(object sender, EventArgs e)
        {
            LoadComboBoxGodina();
            LoadComboBoxVrstaPrograma();
            cboGodina.SelectedIndex = 0;
            cboVrstaPrograma.SelectedIndex = 0;
            
            lvListaPrograma.ItemCheck -= lvListaPrograma_ItemCheck;

            FillFromXml();
            
            SelectCurrentProgram();
            lvListaPrograma.ItemCheck += lvListaPrograma_ItemCheck;

      

        }

        private void LoadComboBoxGodina()
        {
            int currentYear = DateTime.Today.Year;
            for (int i = 0; i <= 10; i++)
            {
                cboGodina.Items.Add(currentYear - i);
            }
        }


        private void LoadComboBoxVrstaPrograma()
        {
            string[] vrstePrograma = {"ROB", "MFP", "POS", "POSLAN", "PLA", "OSR"};
            
            for (int i = 0; i <= vrstePrograma.Length - 1; i++)
            {
                cboVrstaPrograma.Items.Add(vrstePrograma[i]);
            }
        }

        private void FillFromXml()
        {
            List<ProgramItem> lista = ProgramItem.GetItemsFromXml();
            ProgramItem.FillListView(this.lvListaPrograma);
        }

        private void SelectCurrentProgram()
        {
            ProgramItem selProgram = ProgramItem.GetSelectedProgramFromXml();


            if (selProgram != null)
            {
                int i = 0;
                foreach (ListViewItem item in lvListaPrograma.Items)
                {
                    if (ProgramItem.IsEqual(selProgram, item))
                    {
                        lvListaPrograma.Items[i].Selected = true;
                        lvListaPrograma.Items[i].Checked = true;
                        lvListaPrograma.Select();
                        break;
                    }
                    i++;
                }
                FillStatusBar(selProgram);

            }
        }

        private void UnCheckAll()
        {

            for (int i = 0; i < lvListaPrograma.Items.Count; i++)
            {
                lvListaPrograma.Items[i].Checked = false;
            }

            //foreach (ListViewItem item in lvListaPrograma.Items)
            //{
            //    item.Checked = false;
               
            //}
     

        }

        private void ClearAll()
        {

            MessageBox.Show("ClearAll" + "\n" + lvListaPrograma.CheckedItems.Count.ToString());

            foreach (ListViewItem item in lvListaPrograma.Items)
            {
                item.SubItems.Clear();
            }
            lvListaPrograma.Items.Clear();
            lvListaPrograma.SelectedItems.Clear();
            

        }

        public void FillStatusBar(ProgramItem selProgram)
        {
       
            if (selProgram != null)
            {
                toolStripStatusLabel1.Text = "Program je izabran";
                toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel2.Text = selProgram.Godina;
                toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel3.Text = selProgram.VrstaPrograma;
                toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel4.Text = selProgram.ImeMape;
                toolStripStatusLabel4.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel5.Text = selProgram.IzvrsnaDatoteka;
                toolStripStatusLabel5.BorderSides = ToolStripStatusLabelBorderSides.Right;
                
                toolStripStatusLabel6.Text = selProgram.OpisPrograma;
                toolStripStatusLabel6.BorderSides = ToolStripStatusLabelBorderSides.Right;
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
                
                toolStripStatusLabel5.Text = "";
                toolStripStatusLabel5.BorderSides = ToolStripStatusLabelBorderSides.None;
                
                toolStripStatusLabel6.Text = "";
                toolStripStatusLabel6.BorderSides = ToolStripStatusLabelBorderSides.None;
            }
        }
        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtImeMape.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnFindExeFile_Click(object sender, EventArgs e)
        {
            if (txtImeMape.Text != "")
            {
                openFileDialog.InitialDirectory = txtImeMape.Text;
            }

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtIzvrsnaDatoteka.Text = openFileDialog.FileName;
            }
        }

        private void FormProgramItem()
        {
            prog = new ProgramItem();

            prog.Godina = cboGodina.Text;
            prog.ImeMape = txtImeMape.Text;
            prog.VrstaPrograma = cboVrstaPrograma.Text;
            prog.IzvrsnaDatoteka = txtIzvrsnaDatoteka.Text;
            prog.OpisPrograma = txtOpisPrograma.Text;

            if (prog.OpisPrograma == "")
            {
                prog.OpisPrograma = prog.VrstaPrograma + prog.Godina;
            }
        }

        private bool ValidData()
        {
            return Validator.IsPresent(cboGodina, "Godina") &&
                   Validator.IsPresent(txtImeMape, "Ime mape") &&
                   Validator.IsPresent(cboVrstaPrograma, "Vrsta programa") &&
                   Validator.IsPresent(txtIzvrsnaDatoteka, "Ime izvršne datoteke") &&
                   Validator.IsFolderExist(txtImeMape, "Mapa u koju je program instaliran") &&
                   Validator.IsFileExist(txtIzvrsnaDatoteka, "Izvršna datoteka za pokretanje programa");
        }

        private void btnDodajNaListu_Click(object sender, EventArgs e)
        {
            if (ValidData())
            {
                FormProgramItem();

                ProgramItem.AddItemToListView(lvListaPrograma, prog);
                ClearData();

                btnSpremi.PerformClick();

            }
        }

        private void ClearData()
        {
            txtIzvrsnaDatoteka.Text = "";
            txtImeMape.Text = "";
            txtOpisPrograma.Text = "";

            cboGodina.SelectedIndex = 0;
            cboVrstaPrograma.SelectedIndex = 0;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            ProgramItem.Save(this.lvListaPrograma);
        }
        
        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUkloni_Click(object sender, EventArgs e)
        {
            if (lvListaPrograma.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection selected = lvListaPrograma.SelectedItems;
                if (selected.Count > 0)
                {
                    ListViewItem item =  selected[0];
                    DialogResult result = MessageBox.Show("Ukloniti program sa liste:" + "\n" +
                        "Godina: " + item.Text + "\n" +
                        "Mapa: " + item.SubItems[1].Text + "\n" +
                        "Vrsta: " + item.SubItems[2].Text + "\n" +
                        "Izvršna datoteka: " + item.SubItems[3].Text + "\n" +
                        "Opis: " + item.SubItems[4].Text, "Potvrda brisanja sa liste", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        item.Checked = false;
                        item.Remove();
                        btnSpremi.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("Program mora biti selektiran da bi se uklonio sa liste.\nSelektirati program koji se želi ukloniti sa liste i pokušati ponovo.", "Program nije selektiran");
                }
            }
            else
            {
                MessageBox.Show("Lista programa je prazna.\nDodati jedan ili više programa na listu i pokušati ponovo.", "Lista programa je prazna");
            }

        }

        private void btnIzaberi_Click(object sender, EventArgs e)
        {
            if (lvListaPrograma.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection selected = lvListaPrograma.SelectedItems;
                
                if (selected.Count > 0)
                {
                    ListViewItem item =  selected[0];
                    
                        lvListaPrograma.ItemCheck -= lvListaPrograma_ItemCheck;
                        UnCheckAll();
                        item.Checked = true;
                        item.Selected = true;
                        lvListaPrograma.ItemCheck += lvListaPrograma_ItemCheck;

                        ProgramItem p = ProgramItem.GetProgramFromListViewItem(item);
                        ProgramItem.SaveSelectedToXml(p);
                        FillStatusBar(p);

                        KorisnikXML.DeleteXmlFileIzabraniKorisnik();
                    
                }
                else
                {
                    MessageBox.Show("Program mora biti selektiran da bi se izabrao za obradu.\nSelektirati program sa kojim se želi raditi i pokušati ponovo.", "Program nije selektiran");
                }
            }
            else
            {
                MessageBox.Show("Lista programa je prazna.\nDodati jedan ili više programa na listu i pokušati ponovo.", "Lista programa je prazna");
            }

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Obrisati: " + "\n\n" +
                "1. Listu upisanih programa" + "\n" +
                "2. XML datoteku sa upisanom listom programa (Programi.xml)" + "\n" +
                "3. XML datoteku u kojoj je upisan izabrani program (SelectedProgram.xml)" + "\n" +
                "4. XML datoteku u kojoj je upisan izabrani korisnik (IzabraniKorisnik.xml)",
                "Brisanje svih postavki", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                lvListaPrograma.Items.Clear();
                ProgramItem.DeleteXmlFileProgramList();
                ProgramItem.DeleteXmlFileSelectedProgram();
                KorisnikXML.DeleteXmlFileIzabraniKorisnik();
           
                FillStatusBar(null);

            }
        }

        private void btnRunApp_Click(object sender, EventArgs e)
        {
            if (lvListaPrograma.Items.Count > 0)
            {
                ListView.SelectedListViewItemCollection selected = lvListaPrograma.SelectedItems;
                if (selected.Count > 0)
                {
                    ListViewItem item = selected[0];

                    string exeFileName = item.SubItems[3].Text;
                    string workingDir = Path.GetDirectoryName(exeFileName);

                    if ((exeFileName != "") && (workingDir != ""))
                    {
                        try
                        {
                            Process p = new Process();

                            p.StartInfo.FileName = exeFileName;
                            p.StartInfo.WorkingDirectory = workingDir;


                            p.Start();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Program se ne može pokrenuti." + "\n" +
                                            ex.Message,
                                            "Greška pri pokretanju programa",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error); 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Program mora biti selektiran da bi se mogao pokrenuti.\nSelektirati program koji se želi pokrenuti i pokušati ponovo.\nProgram se može pokrenuti i dvostrukim klikom na red na listi.", "Program nije selektiran");
                }

            }
            else
            {
                MessageBox.Show("Lista programa je prazna.\nDodati jedan ili više programa na listu i pokušati ponovo.", "Lista programa je prazna");
            }

        }

      

        private void lvListaPrograma_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem itemToBeSelected = ((ListView)sender).Items[e.Index];

            if (e.CurrentValue == CheckState.Unchecked)
            {
              //  MessageBox.Show("Event ItemCheck-Check");
                itemToBeSelected.Selected  = true;
                btnIzaberi.PerformClick();

            }
            else if ((e.CurrentValue == CheckState.Checked))
            {
//                MessageBox.Show("Event ItemCheck-UnCheck");
                ProgramItem.DeleteXmlFileSelectedProgram();
                KorisnikXML.DeleteXmlFileIzabraniKorisnik();
                FillStatusBar(null);

            }

          
           

        }

       

       

        
    }
}
