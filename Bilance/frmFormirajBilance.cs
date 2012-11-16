using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Podaci;
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Bilance
{
    public partial class frmFormirajBilance : Form
    {
        private ProgramItem selectedProgram = null;
        private Korisnik selectedKorisnik = null;
        
        private string dbfFolderName = "";
        private string dbfKontaFolderName = "";

        private SortableSearchableList<BrutoBilans> brutoBilans = null;
        private SortableSearchableList<BrutoBilans> grupeBilans1 = null;
        private SortableSearchableList<BrutoBilans> grupeBilans2 = null;
        private SortableSearchableList<BrutoBilans> grupeBilans3 = null;
        private SortableSearchableList<BrutoBilans> grupeBilans4 = null;
        private SortableSearchableList<BrutoBilans> grupeBilansSK = null;

        private SortableSearchableList<ItemGk> itemsGk5 = null;
        private SortableSearchableList<ItemGk> itemsGk5SK = null;
        private NalogGk nalogGk5 = null;

        private SortableSearchableList<ItemGk> itemsGk6 = null;
        private SortableSearchableList<ItemGk> itemsGk6SK = null;
        private NalogGk nalogGk6 = null;

        private BilanceSetup setup = null;

        private const string BrutoBilansSheet = "GK";
        private const string MaticniPodaciSheet = "MP";

        private Color color1;
        private Color color2;
        private Color color3;

        public frmFormirajBilance()
        {
            InitializeComponent();

            itemsGk5 = new SortableSearchableList<ItemGk>();
            itemsGk6 = new SortableSearchableList<ItemGk>();
            itemsGk5SK = new SortableSearchableList<ItemGk>();
            itemsGk6SK = new SortableSearchableList<ItemGk>();

            color1 = Color.Lime;
            color2 = Color.PaleTurquoise;
            color3 = Color.PapayaWhip;

        }

        private void frmFormirajBilance_Load(object sender, EventArgs e)
        {
            GetPreduvjete();
        }

        private void GetPreduvjete()
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

            dbfFolderName = Utility.GetDbfFolder(selectedProgram, selectedKorisnik);
            dbfKontaFolderName = Utility.GetDbfFolderKonta(selectedProgram, selectedKorisnik);

            setup = BilanceSetup.GetSetupFromXml();


            string[,] uvjeti = GetListuPreduvjeta();

            PrikaziPreduvjete(uvjeti);

            int brojNeispravnih = GetBrojNeispravnih();
            PrikaziPoruku(brojNeispravnih);

            
            string sourceFileName = setup.BilanceFile;
            string destinationFileName = setup.GetDestinationFileName(selectedKorisnik);

            txtPopunjenObrazac.Text = destinationFileName;
            
            if (File.Exists(destinationFileName))
            {
                txtStatusObrazaca.Text = "Obrasci za datog korisnika su vec formirani.";
            }
            else
            {
                txtStatusObrazaca.Text = "Obrasci za datog korisnika još nisu formirani.";
            }

            if (brojNeispravnih > 0)
            {
                btnPopuniObrazac.Enabled = false;
            }
            else
            {
                btnPopuniObrazac.Enabled = true;
            }

            
        }


        private void PrikaziPoruku(int brojNeispravnih)
        {
            string poruka = "Svi uvjeti za formiranje obrazaca su ispunjeni.";

            if (brojNeispravnih > 0)
            {
                poruka = "Nisu ispunjeni svu uvjeti za formiranje obrazaca. Ispraviti nepravilna podešenja i pokušati ponovo.";
            }

            label2.Text = poruka;

        }

        private int GetBrojNeispravnih()
        {
            int brojNeispravnih = 0;

            foreach (ListViewItem item in lvPreduvjeti.Items)
            {
                if (item.SubItems[2].Text == "Ne")
                {
                    brojNeispravnih++;
                }
            }

            return brojNeispravnih;

        }

        private void PrikaziPreduvjete(string[,] preduvjeti)
        {
            ListViewItem item;
            
            lvPreduvjeti.Items.Clear();

            for (int i = 0; i < preduvjeti.GetLength(0); i++)
			{
                item = new ListViewItem(preduvjeti[i, 0]);
                item.SubItems.Add(preduvjeti[i, 1]);
                item.SubItems.Add(preduvjeti[i, 2]);

                lvPreduvjeti.Items.Add(item);

			}

        }


        private string[,] GetListuPreduvjeta()
        {
            string[,] listaPreduvjeta = new string[12, 3];

            for (int i = 0; i < 12; i++)
            {
                listaPreduvjeta[i, 0] = "";
                listaPreduvjeta[i, 1] = "";
                listaPreduvjeta[i, 2] = "Ne";

            }

            listaPreduvjeta[0, 0] = "Šifra korisnika";
            listaPreduvjeta[1, 0] = "Naziv korisnika";
            listaPreduvjeta[2, 0] = "Mapa u kojoj je knjigovodstvo:";
            listaPreduvjeta[3, 0] = "Opis programa:";
            listaPreduvjeta[4, 0] = "Analitički kontni plan:";
            listaPreduvjeta[5, 0] = "Sintetički kontni plan:";
            listaPreduvjeta[6, 0] = "Nalozi glavne knjige:";
            listaPreduvjeta[7, 0] = "Knjiženja glavne knjige:";
            listaPreduvjeta[8, 0] = "Prazni obrasci:";
            listaPreduvjeta[9, 0] = "Mapa sa popunjenim obrascima:";
            listaPreduvjeta[10, 0] = "Period za koji se popunjavaju obrasci:";
            listaPreduvjeta[11, 0] = "Datum predaje obrazaca:";

            if (selectedKorisnik != null)
            {
                listaPreduvjeta[0, 1] = selectedKorisnik.SifraKor;
                listaPreduvjeta[0, 2] = "Da";

                listaPreduvjeta[1, 1] = selectedKorisnik.NazivKor;
                listaPreduvjeta[1, 2] = "Da";

            }

            if (selectedProgram != null)
            {
                listaPreduvjeta[2, 1] = selectedProgram.ImeMape;
                listaPreduvjeta[2, 2] = "Da";

                listaPreduvjeta[3, 1] = selectedProgram.OpisPrograma;
                listaPreduvjeta[3, 2] = "Da";

            }

            if (AnalitickiKontoDB.DbfFileExists(dbfKontaFolderName))
            {
                listaPreduvjeta[4, 1] = dbfKontaFolderName + "\\" + AnalitickiKontoDB.DbfFileName;
                listaPreduvjeta[4, 2] = "Da";
            }

            if (SintetickiKontoDB.DbfFileExists(dbfKontaFolderName))
            {
                listaPreduvjeta[5, 1] = dbfKontaFolderName + "\\" + SintetickiKontoDB.DbfFileName;
                listaPreduvjeta[5, 2] = "Da";
            }


            if (NalogGkDB.DbfFileExists(dbfFolderName))
            {
                listaPreduvjeta[6, 1] = dbfFolderName + "\\" + NalogGkDB.DbfFileName;
                listaPreduvjeta[6, 2] = "Da";
            }

            if (ItemGkDB.DbfFileExists(dbfFolderName))
            {
                listaPreduvjeta[7, 1] = dbfFolderName + "\\" + ItemGkDB.DbfFileName;
                listaPreduvjeta[7, 2] = "Da";
            }


            if (setup != null)
            {

                listaPreduvjeta[8, 1] = setup.BilanceFile;
                if (File.Exists(setup.BilanceFile))
                {
                    listaPreduvjeta[8, 2] = "Da";
                }

                listaPreduvjeta[9, 1] = setup.BilanceFolder;
                if (Directory.Exists(setup.BilanceFolder))
                {
                    listaPreduvjeta[9, 2] = "Da";
                }

                listaPreduvjeta[10, 1] = setup.BilanceOdDatuma.ToShortDateString() + " do " + setup.BilanceDoDatuma.ToShortDateString();

                if (setup.BilanceOdDatuma <= setup.BilanceDoDatuma)
                {
                    listaPreduvjeta[10, 2] = "Da";

                }

                listaPreduvjeta[11, 1] = setup.BilanceDatumPredaje.ToShortDateString(); 

                if (setup.BilanceDatumPredaje >= setup.BilanceDoDatuma)
                {
                    listaPreduvjeta[11, 2] = "Da";

                }
            }

            return listaPreduvjeta;
        }

        private void btnIzaberiProgram_Click(object sender, EventArgs e)
        {
            frmIzborPrograma frm = new frmIzborPrograma();
            frm.ShowDialog();
            GetPreduvjete();

        }

        private void btnIzaberiKorisnika_Click(object sender, EventArgs e)
        {
            frmIzborKorisnika frm = new frmIzborKorisnika();
            frm.ShowDialog();
            GetPreduvjete();
        }

        private void btnPodesenja_Click(object sender, EventArgs e)
        {
            frmBilanceSetup frm = new frmBilanceSetup();

            frm.ShowDialog();
            GetPreduvjete();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetPreduvjete();
        }

        private void btnOtvoriFolder_Click(object sender, EventArgs e)
        {
           
            try
            {
                Utility.OpenFolder(setup.BilanceFolder);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Mapa se ne može otvoriti." + "\n" + ex.Message, "Mapa se ne može otvoriti"); 
                
            }
            
        }



        private void btnOtvoriPrazan_Click(object sender, EventArgs e)
        {
            string sourceFileName = setup.BilanceFile;

            if (File.Exists(sourceFileName))
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;

                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(setup.BilanceFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlApp.Visible = true;

                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datoteka s praznim obrazcima se ne može otvoriti." + "\n" + ex.Message, "Datoteka se ne može otvoriti");

                }
            }
            else
            {
                MessageBox.Show("Datoteka s praznim obrascima ne postoji.\n" + sourceFileName, "Ne postoji datoteka");
            }
        }

        private bool KopirajPrazan()
        {
            
            string sourceFileName = setup.BilanceFile;
            string destinationFileName = setup.GetDestinationFileName(selectedKorisnik);

            if (!File.Exists(sourceFileName))
            {
                MessageBox.Show("Datoteka s praznim obrascima ne postoji.\n" + sourceFileName, "Ne postoje prazni obrasci");
                return false;
            }
            if (!Directory.Exists(setup.BilanceFolder))
            {
                MessageBox.Show("Mapa u koju se spremaju popunjeni obrasci ne postoji.\n" + setup.BilanceFolder, "Ne postoji direktorij");
                return false;
            }

            if (!File.Exists(destinationFileName))
            {
                File.Copy(sourceFileName, destinationFileName);
            }

            if (File.Exists(destinationFileName))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void btnOtvoriPopunjen_Click(object sender, EventArgs e)
        {
            string destinationFileName = setup.GetDestinationFileName(selectedKorisnik);

            if (File.Exists(destinationFileName))
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
      

                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(destinationFileName,
                                                      0,
                                                      false,
                                                      5,
                                                      "",
                                                      "",
                                                      true,
                                                      Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                                                      "\t",
                                                      false,
                                                      false,
                                                      0,
                                                      true,
                                                      1,
                                                      0);
                    xlApp.Visible = true;

                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datoteka s popunjenim obrascima se ne može otvoriti." + "\n" + ex.Message, "Datoteka se ne može otvoriti");
                } 
            }
        }

        private void btnOtvoriFolderSource_Click(object sender, EventArgs e)
        {
            string folderPath = Path.GetDirectoryName(setup.BilanceFile);
            try
            {
                Utility.OpenFolder(folderPath);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Mapa se ne može otvoriti." + "\n" + ex.Message, "Mapa se ne može otvoriti");

            }
            
        }

        private void btnPopuniObrazac_Click(object sender, EventArgs e)
        {
            if (KopirajPrazan())
            {
                this.progressBar.Visible = true;
                this.label5.Visible = true;
                this.btnPopuniObrazac.Enabled = false;

               
                this.Tag = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                toolStripStatusLabel1.Text = "Čitanje podataka iz knjigovodstva...";

                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Datoteka s praznim obrascima se ne može kopirati u mapu s popunjenim obrascima.", "Kopiranje datoteke");
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SintetickiKonto sintKonto;

            brutoBilans = BrutoBilansDB.GetBrutoBilans(dbfFolderName, dbfKontaFolderName, setup.BilanceOdDatuma, setup.BilanceDoDatuma);
            grupeBilans1 = BrutoBilansDB.BrutoBilansPoGrupma(brutoBilans, "1");
            grupeBilans2 = BrutoBilansDB.BrutoBilansPoGrupma(brutoBilans, "2");
            grupeBilans3 = BrutoBilansDB.BrutoBilansPoGrupma(brutoBilans, "3");
            grupeBilans4 = BrutoBilansDB.BrutoBilansPoGrupma(brutoBilans, "4");
            grupeBilansSK = BrutoBilansDB.BrutoBilansPoSK(brutoBilans, dbfKontaFolderName);

            //upis naziva sintetickog konta
            int i = 0;
            while (i < grupeBilans3.Count)
            {
                sintKonto = SintetickiKontoDB.GetSintetickiKonto(dbfKontaFolderName, grupeBilans3[i].Konto);
                grupeBilans3[i].NazivKonta = sintKonto.NazivKonta;
                
                i++;
            }


            nalogGk5 = NalogGkDB.GetNalogGkByPocSt(dbfFolderName, "3");
            itemsGk5 = ItemGkDB.GetItemsGkByBrojNaloga(dbfFolderName, nalogGk5.BrojNaloga, dbfKontaFolderName);
            itemsGk5SK =  ItemGkDB.GroupItemsGKBySK(itemsGk5, dbfKontaFolderName);
            
            nalogGk6 = NalogGkDB.GetNalogGkByPocSt(dbfFolderName, "6");
            itemsGk6 = ItemGkDB.GetItemsGkByBrojNaloga(dbfFolderName, nalogGk6.BrojNaloga, dbfKontaFolderName);
            itemsGk6SK = ItemGkDB.GroupItemsGKBySK(itemsGk6, dbfKontaFolderName);

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Popuna obrazaca u toku...";
            UpisiBrutoBilans();
                   
            toolStripStatusLabel1.Text = "Popuna obrazaca završena";
           
            this.Cursor = (Cursor)this.Tag;
            this.progressBar.Visible = false;
            this.btnPopuniObrazac.Enabled = true;
            this.label5.Visible = false;
        }

        private void UpisiBrutoBilans()
        {
            BrutoBilans bb;

            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Range range;
            int startRow = 1;
            int h = 3;
   
            object misValue = System.Reflection.Missing.Value;
            string destinationFileName = setup.GetDestinationFileName(selectedKorisnik);

            if (!KillProcess("EXCEL"))
            {
                return;
            }

            try
            {
                xlApp = new Excel.Application();
                
                xlWorkBook = xlApp.Workbooks.Open(destinationFileName,
                                                  0,
                                                  false,
                                                  5,
                                                  misValue,
                                                  misValue,
                                                  true,
                                                  Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
                                                  "\t",
                                                  false,
                                                  false,
                                                  0,
                                                  true,
                                                  1,
                                                  0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(BrutoBilansSheet);

                bool zakljucen = IsZakljucen(xlWorkSheet, startRow + 4, 2);

                if (!zakljucen)
                {
                    xlWorkSheet.Cells.Clear();

                    startRow = UpisiZaglavlje(xlWorkSheet, 1) + 2;
                    h = startRow + 2; //zaglavlje

                    xlWorkSheet.Cells[startRow, 1] = "Bruto bilans preuzet " + DateTime.Now.ToString();

                    range = xlWorkSheet.get_Range("a" + startRow.ToString(), "m" + startRow.ToString());

                    range.Merge();
                    range.Font.Bold = true;
                    range.Font.Size = 12;

                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                    range.HorizontalAlignment = 3;

                    xlWorkSheet.Cells[h, 1] = "Konto";
                    xlWorkSheet.Cells[h, 2] = "Naziv konta";
                    xlWorkSheet.Cells[h, 3] = "AOP";
                    xlWorkSheet.Cells[h, 4] = "Ispravka";
                    xlWorkSheet.Cells[h, 5] = "Duguje";
                    xlWorkSheet.Cells[h, 6] = "Potražuje";
                    xlWorkSheet.Cells[h, 7] = "SALDO";
                    xlWorkSheet.Cells[h, 8] = "Duguje PS";
                    xlWorkSheet.Cells[h, 9] = "Potražuje PS";
                    xlWorkSheet.Cells[h, 10] = "SALDO PS";
                    xlWorkSheet.Cells[h, 11] = "Duguje TP";
                    xlWorkSheet.Cells[h, 12] = "Potražuje TP";
                    xlWorkSheet.Cells[h, 13] = "SALDO TP";

                    int row = h + 1;
                    int endRow = row + brutoBilans.Count;

                    int j = 0;
                    for (int i = 0; i < brutoBilans.Count; i++)
                    {
                        bb = brutoBilans[i];


                        xlWorkSheet.Cells[row + i, j + 1] = "'" + bb.Konto;
                        xlWorkSheet.Cells[row + i, j + 2] = bb.NazivKonta;
                        
                        if ((bb.KontoIspravke == "D") && (bb.AOPOznaka != ""))
                        {
                            xlWorkSheet.Cells[row + i, j + 3] = "'" + bb.AOPOznaka + "I";
                        }
                        else
                        {
                            xlWorkSheet.Cells[row + i, j + 3] = "'" + bb.AOPOznaka;
                        }
                        
                        xlWorkSheet.Cells[row + i, j + 4] = bb.KontoIspravke;

                        xlWorkSheet.Cells[row + i, j + 5] = bb.Duguje;
                        xlWorkSheet.Cells[row + i, j + 6] = bb.Potrazuje;
                        xlWorkSheet.Cells[row + i, j + 7] = bb.Saldo;

                        xlWorkSheet.Cells[row + i, j + 8] = bb.DugujePS;
                        xlWorkSheet.Cells[row + i, j + 9] = bb.PotrazujePS;
                        xlWorkSheet.Cells[row + i, j + 10] = bb.SaldoPS;

                        xlWorkSheet.Cells[row + i, j + 11] = bb.DugujeTP;
                        xlWorkSheet.Cells[row + i, j + 12] = bb.PotrazujeTP;
                        xlWorkSheet.Cells[row + i, j + 13] = bb.SaldoTP;

                    }

                    xlWorkSheet.Cells[endRow, j + 4] = "UKUPNO:";
                    xlWorkSheet.Cells[endRow, j + 5] = "=SUM(e4:e" + (endRow - 1).ToString() + ")";
                    xlWorkSheet.Cells[endRow, j + 6] = "=SUM(f4:f" + (endRow - 1).ToString() + ")";
                    xlWorkSheet.Cells[endRow, j + 7] = "=SUM(g4:g" + (endRow - 1).ToString() + ")";

                    xlWorkSheet.Cells[endRow, j + 8] = "=SUM(h4:h" + (endRow - 1).ToString() + ")";
                    xlWorkSheet.Cells[endRow, j + 9] = "=SUM(i4:i" + (endRow - 1).ToString() + ")";
                    xlWorkSheet.Cells[endRow, j + 10] = "=SUM(j4:j" + (endRow - 1).ToString() + ")";

                    xlWorkSheet.Cells[endRow, j + 11] = "=SUM(k4:k" + (endRow - 1).ToString() + ")";
                    xlWorkSheet.Cells[endRow, j + 12] = "=SUM(l4:l" + (endRow - 1).ToString() + ")";
                    xlWorkSheet.Cells[endRow, j + 13] = "=SUM(m4:m" + (endRow - 1).ToString() + ")";

                    xlWorkBook.Names.Add("BrutoBilans", "=" + BrutoBilansSheet + "!$A$" + h.ToString() + ":$M$" + endRow.ToString());
                    xlWorkBook.Names.Add("AOPBB", "=" + BrutoBilansSheet + "!$C$" + (h + 1).ToString() + ":$C$" + (endRow - 1).ToString());
                    
                    xlWorkBook.Names.Add("Duguje", "=" + BrutoBilansSheet + "!$E$" + (h + 1).ToString() + ":$E$" + (endRow - 1).ToString());
                    xlWorkBook.Names.Add("Potrazuje", "=" + BrutoBilansSheet + "!$F$" + (h + 1).ToString() + ":$F$" + (endRow - 1).ToString());
                    xlWorkBook.Names.Add("Saldo", "=" + BrutoBilansSheet + "!$G$" + (h + 1).ToString() + ":$G$" + (endRow - 1).ToString());
                    
                    xlWorkBook.Names.Add("DugujePS", "=" + BrutoBilansSheet + "!$H$" + (h + 1).ToString() + ":$H$" + (endRow - 1).ToString());
                    xlWorkBook.Names.Add("PotrazujePS", "=" + BrutoBilansSheet + "!$I$" + (h + 1).ToString() + ":$I$" + (endRow - 1).ToString());
                    xlWorkBook.Names.Add("SaldoPS", "=" + BrutoBilansSheet + "!$J$" + (h + 1).ToString() + ":$J$" + (endRow - 1).ToString());
                    
                    xlWorkBook.Names.Add("DugujeTP", "=" + BrutoBilansSheet + "!$K$" + (h + 1).ToString() + ":$K$" + (endRow - 1).ToString());
                    xlWorkBook.Names.Add("PotrazujeTP", "=" + BrutoBilansSheet + "!$L$" + (h + 1).ToString() + ":$L$" + (endRow - 1).ToString());
                    xlWorkBook.Names.Add("SaldoTP", "=" + BrutoBilansSheet + "!$M$" + (h + 1).ToString() + ":$M$" + (endRow - 1).ToString());

                    range = xlWorkSheet.get_Range("a" + h.ToString(), "m" + h.ToString());
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                    range.Font.Bold = true;
                    range.HorizontalAlignment = 3;

                    range.Interior.Color = Color.Aqua;

                    range = xlWorkSheet.get_Range("a" + (h + 1).ToString(), "m" + (endRow).ToString());
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                    range.Borders.Weight = 1;

                    range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "m" + (endRow).ToString());
                    range.NumberFormatLocal = "#.##0,00";

                    range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "g" + (endRow).ToString());
                    range.Interior.Color = color1;

                    range = xlWorkSheet.get_Range("h" + (h + 1).ToString(), "j" + (endRow).ToString());
                    range.Interior.Color = color2;
                    range = xlWorkSheet.get_Range("k" + (h + 1).ToString(), "m" + (endRow).ToString());
                    range.Interior.Color = color3;

                    range = xlWorkSheet.get_Range("a" + endRow.ToString(), "m" + endRow.ToString());
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                    range.Font.Bold = true;


                    range = xlWorkSheet.get_Range("a" + startRow.ToString(), "m" + (endRow).ToString());
                    range.Columns.AutoFit();
                    range.Rows.AutoFit();

                    endRow = UpisiGrupu(xlWorkBook, xlWorkSheet, endRow + 3, grupeBilans1, "Bruto bilans po klasama konta", "Grupa1");
                    endRow = UpisiGrupu(xlWorkBook, xlWorkSheet, endRow + 3, grupeBilans2, "Bruto bilans po prve dvije znamenka konta", "Grupa2");
                    endRow = UpisiGrupu(xlWorkBook, xlWorkSheet, endRow + 3, grupeBilans3, "Bruto bilans po sintetičkim kontima", "Grupa3");
                    endRow = UpisiGrupu(xlWorkBook, xlWorkSheet, endRow + 3, grupeBilans4, "Bruto bilans po prve četiri znamenka konta", "Grupa4");
                    endRow = UpisiNalog(xlWorkBook, xlWorkSheet, endRow + 3, nalogGk5, itemsGk5, "Nalog za zatvaranje klase 5", "5", "Nalog5");
                    endRow = UpisiNalog(xlWorkBook, xlWorkSheet, endRow + 3, nalogGk6, itemsGk6, "Nalog za zatvaranje klase 6", "6", "Nalog6");
                    
                    endRow = UpisiGrupuSK(xlWorkBook, xlWorkSheet, endRow + 3, grupeBilansSK, "Bruto bilans po sintetičkim kontima i ispravci vrijednosti", "BrutoBilansSK");
                    endRow = UpisiNalog(xlWorkBook, xlWorkSheet, endRow + 3, nalogGk5, itemsGk5SK, "Nalog za zatvaranje klase 5 po sintetičkim kontima", "5SK", "Nalog5SK");
                    endRow = UpisiNalog(xlWorkBook, xlWorkSheet, endRow + 3, nalogGk6, itemsGk6SK, "Nalog za zatvaranje klase 6 po sintetičkim kontima", "6SK", "Nalog6SK");

                    UpisiKorisnika(xlWorkBook);

                }
                else
                {
                    MessageBox.Show("Automatski upis bruto bilansa nije moguć." + "\n" +
                                    "Radni list GK je zaključan (u polju B5 je upisano DA)." + "\n" +
                                    "U polje B5 upisati NE i spremiti fajl tako da pri sljedećem pokretanju " + 
                                    "bude omogućen automatski upis bruto bilansa.", "Onemogućen automatski upis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                xlApp.DisplayAlerts = false;

                xlWorkBook.SaveAs(destinationFileName, misValue, misValue, misValue, misValue,
                                                   misValue, Excel.XlSaveAsAccessMode.xlNoChange,
                                                   misValue, misValue, misValue, misValue, misValue);

                
                xlWorkBook.Worksheets["MP"].Activate();


                xlApp.Visible = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Greška u toku otvaranja ili upisa u Excel fajl." + "\n" + ex.Message + "\n" + ex.StackTrace, "Greška pri otvaranju Excel fajla");
            }
            finally
            {
                if (xlWorkSheet != null)
                {
                    releaseObject(xlWorkSheet);
                }
                if (xlWorkBook != null)
                {
              
                    releaseObject(xlWorkBook);
                }
                if (xlApp != null)
                {
           
                    releaseObject(xlApp);
                }

              

            }
        }

        private int UpisiGrupu(Excel.Workbook xlWorkBook, Excel.Worksheet xlWorkSheet, int startRow, SortableSearchableList<BrutoBilans> grupa, string naslov, string rangeName)
        {
            BrutoBilans bb;
            Excel.Range range;
            string sRow = startRow.ToString();
            int endRow = startRow + 1;

            try
            {
                xlWorkSheet.Cells[startRow, 1] = naslov;

               range = xlWorkSheet.get_Range("a" + sRow, "m" + sRow);
           

                range.Merge();
                range.Font.Bold = true;
                range.Font.Size = 12;

                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.HorizontalAlignment = 3;

                int h = startRow + 2;

                xlWorkSheet.Cells[h, 1] = "Grupa";
                xlWorkSheet.Cells[h, 2] = "";
                xlWorkSheet.Cells[h, 3] = "";
                xlWorkSheet.Cells[h, 4] = "";
                xlWorkSheet.Cells[h, 5] = "Duguje";
                xlWorkSheet.Cells[h, 6] = "Potražuje";
                xlWorkSheet.Cells[h, 7] = "SALDO";
                xlWorkSheet.Cells[h, 8] = "Duguje PS";
                xlWorkSheet.Cells[h, 9] = "Potražuje PS";
                xlWorkSheet.Cells[h, 10] = "SALDO PS";
                xlWorkSheet.Cells[h, 11] = "Duguje TP";
                xlWorkSheet.Cells[h, 12] = "Potražuje TP";
                xlWorkSheet.Cells[h, 13] = "SALDO TP";

                int row = h + 1;
                endRow = row + grupa.Count - 1;

                int j = 0;
                for (int i = 0; i < grupa.Count; i++)
                {
                    bb = grupa[i];


                    xlWorkSheet.Cells[row + i, j + 1] = "'" + bb.Konto;
                    xlWorkSheet.Cells[row + i, j + 2] = bb.NazivKonta;
                    xlWorkSheet.Cells[row + i, j + 3] = "";
                    xlWorkSheet.Cells[row + i, j + 4] = "";

                    xlWorkSheet.Cells[row + i, j + 5] = bb.Duguje;
                    xlWorkSheet.Cells[row + i, j + 6] = bb.Potrazuje;
                    xlWorkSheet.Cells[row + i, j + 7] = bb.Saldo;

                    xlWorkSheet.Cells[row + i, j + 8] = bb.DugujePS;
                    xlWorkSheet.Cells[row + i, j + 9] = bb.PotrazujePS;
                    xlWorkSheet.Cells[row + i, j + 10] = bb.SaldoPS;

                    xlWorkSheet.Cells[row + i, j + 11] = bb.DugujeTP;
                    xlWorkSheet.Cells[row + i, j + 12] = bb.PotrazujeTP;
                    xlWorkSheet.Cells[row + i, j + 13] = bb.SaldoTP;

                }

                xlWorkBook.Names.Add(rangeName, "=" + BrutoBilansSheet +  "!$A$" + h.ToString() + ":$M$" + endRow.ToString());

                range = xlWorkSheet.get_Range("a" + h.ToString(), "m" + h.ToString());
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                range.Font.Bold = true;
                range.HorizontalAlignment = 3;
                range.Interior.Color = Color.Aqua;

                range = xlWorkSheet.get_Range("a" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.Borders.Weight = 1;

                range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.NumberFormatLocal = "#.##0,00";

                range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "g" + (endRow).ToString());
                range.Interior.Color = color1;
                range = xlWorkSheet.get_Range("h" + (h + 1).ToString(), "j" + (endRow).ToString());
                range.Interior.Color = color2;
                range = xlWorkSheet.get_Range("k" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.Interior.Color = color3;

                range = xlWorkSheet.get_Range("a1", "m" + (endRow).ToString());
                range.Columns.AutoFit();
                range.Rows.AutoFit();
            }
            catch (Exception ex)
            {
               throw new Exception("Greška u toku formiranja bruto bilansa po grupama konta." + "\n" + ex.Message);
            }

            return endRow;
        }


        private int UpisiGrupuSK(Excel.Workbook xlWorkBook, Excel.Worksheet xlWorkSheet, int startRow, SortableSearchableList<BrutoBilans> grupa, string naslov, string rangeName)
        {
            BrutoBilans bb;
            Excel.Range range;
            string sRow = startRow.ToString();
            int endRow = startRow + 1;

            try
            {
                xlWorkSheet.Cells[startRow, 1] = naslov;

                range = xlWorkSheet.get_Range("a" + sRow, "m" + sRow);


                range.Merge();
                range.Font.Bold = true;
                range.Font.Size = 12;

                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.HorizontalAlignment = 3;

                int h = startRow + 2;

                xlWorkSheet.Cells[h, 1] = "Konto";
                xlWorkSheet.Cells[h, 2] = "Naziv konta";
                xlWorkSheet.Cells[h, 3] = "";
                xlWorkSheet.Cells[h, 4] = "Ispravka";
                xlWorkSheet.Cells[h, 5] = "Duguje";
                xlWorkSheet.Cells[h, 6] = "Potražuje";
                xlWorkSheet.Cells[h, 7] = "SALDO";
                xlWorkSheet.Cells[h, 8] = "Duguje PS";
                xlWorkSheet.Cells[h, 9] = "Potražuje PS";
                xlWorkSheet.Cells[h, 10] = "SALDO PS";
                xlWorkSheet.Cells[h, 11] = "Duguje TP";
                xlWorkSheet.Cells[h, 12] = "Potražuje TP";
                xlWorkSheet.Cells[h, 13] = "SALDO TP";

                int row = h + 1;
                endRow = row + grupa.Count - 1;

                int j = 0;
                for (int i = 0; i < grupa.Count; i++)
                {
                    bb = grupa[i];


                    xlWorkSheet.Cells[row + i, j + 1] = "'" + bb.Konto;
                    xlWorkSheet.Cells[row + i, j + 2] = bb.NazivKonta;
                    xlWorkSheet.Cells[row + i, j + 3] = "";
                    xlWorkSheet.Cells[row + i, j + 4] = bb.KontoIspravke;

                    xlWorkSheet.Cells[row + i, j + 5] = bb.Duguje;
                    xlWorkSheet.Cells[row + i, j + 6] = bb.Potrazuje;
                    xlWorkSheet.Cells[row + i, j + 7] = bb.Saldo;

                    xlWorkSheet.Cells[row + i, j + 8] = bb.DugujePS;
                    xlWorkSheet.Cells[row + i, j + 9] = bb.PotrazujePS;
                    xlWorkSheet.Cells[row + i, j + 10] = bb.SaldoPS;

                    xlWorkSheet.Cells[row + i, j + 11] = bb.DugujeTP;
                    xlWorkSheet.Cells[row + i, j + 12] = bb.PotrazujeTP;
                    xlWorkSheet.Cells[row + i, j + 13] = bb.SaldoTP;

                }

                xlWorkBook.Names.Add(rangeName, "=" + BrutoBilansSheet + "!$A$" + h.ToString() + ":$M$" + endRow.ToString());

                xlWorkBook.Names.Add("KontoSk", "=" + BrutoBilansSheet + "!$A$" + (h + 1).ToString() + ":$A$" + endRow.ToString());
                
                xlWorkBook.Names.Add("DugujeSk", "=" + BrutoBilansSheet + "!$E$" + (h + 1).ToString() + ":$E$" + endRow.ToString());
                xlWorkBook.Names.Add("PotrazujeSk", "=" + BrutoBilansSheet + "!$F$" + (h + 1).ToString() + ":$F$" + endRow.ToString());
                xlWorkBook.Names.Add("SaldoSk", "=" + BrutoBilansSheet + "!$G$" + (h + 1).ToString() + ":$G$" + endRow.ToString());

                xlWorkBook.Names.Add("DugujeSkPS", "=" + BrutoBilansSheet + "!$H$" + (h + 1).ToString() + ":$H$" + endRow.ToString());
                xlWorkBook.Names.Add("PotrazujeSkPS", "=" + BrutoBilansSheet + "!$I$" + (h + 1).ToString() + ":$I$" + endRow.ToString());
                xlWorkBook.Names.Add("SaldoSkPS", "=" + BrutoBilansSheet + "!$J$" + (h + 1).ToString() + ":$J$" + endRow.ToString());

                xlWorkBook.Names.Add("DugujeSkTP", "=" + BrutoBilansSheet + "!$K$" + (h + 1).ToString() + ":$K$" + endRow.ToString());
                xlWorkBook.Names.Add("PotrazujeSkTP", "=" + BrutoBilansSheet + "!$L$" + (h + 1).ToString() + ":$L$" + endRow.ToString());
                xlWorkBook.Names.Add("SaldoSkTP", "=" + BrutoBilansSheet + "!$M$" + (h + 1).ToString() + ":$M$" + endRow.ToString());


                range = xlWorkSheet.get_Range("a" + h.ToString(), "m" + h.ToString());
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                range.Font.Bold = true;
                range.HorizontalAlignment = 3;
                range.Interior.Color = Color.Aqua;

                range = xlWorkSheet.get_Range("a" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.Borders.Weight = 1;

                range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.NumberFormatLocal = "#.##0,00";

                range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "g" + (endRow).ToString());
                range.Interior.Color = color1;
                range = xlWorkSheet.get_Range("h" + (h + 1).ToString(), "j" + (endRow).ToString());
                range.Interior.Color = color2;
                range = xlWorkSheet.get_Range("k" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.Interior.Color = color3;

                range = xlWorkSheet.get_Range("a1", "m" + (endRow).ToString());
                range.Columns.AutoFit();
                range.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                throw new Exception("Greška u toku formiranja bruto bilansa po sintetičkim kontima." + "\n" + ex.Message);
            }

            return endRow;
        }

        private int UpisiNalog(Excel.Workbook xlWorkBook, Excel.Worksheet xlWorkSheet, int startRow, NalogGk nalogGk, SortableSearchableList<ItemGk> itemsGk, string naslov, string klasa, string rangeName)
        {
            ItemGk gk;
            Excel.Range range;
            string sRow = startRow.ToString();
            int endRow = startRow + 1;

            try
            {
                xlWorkSheet.Cells[startRow, 1] = naslov;

                range = xlWorkSheet.get_Range("a" + sRow, "m" + sRow);


                range.Merge();
                range.Font.Bold = true;
                range.Font.Size = 12;

                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.HorizontalAlignment = 3;

                int h = startRow + 2;

                xlWorkSheet.Cells[h, 1] = "Konto";
                xlWorkSheet.Cells[h, 2] = "Opis knjiženja";
                xlWorkSheet.Cells[h, 3] = "AOP";
                xlWorkSheet.Cells[h, 4] = "Oznaka";
                xlWorkSheet.Cells[h, 5] = "Duguje";
                xlWorkSheet.Cells[h, 6] = "Potražuje";
                xlWorkSheet.Cells[h, 7] = "SALDO";

                int row = h + 1;
                endRow = row + itemsGk.Count - 1;

                int j = 0;
                for (int i = 0; i < itemsGk.Count; i++)
                {
                    gk = itemsGk[i];


                    xlWorkSheet.Cells[row + i, j + 1] = "'" + gk.Konto;
                    xlWorkSheet.Cells[row + i, j + 2] = gk.OpisKnjizenja;
                    xlWorkSheet.Cells[row + i, j + 3] = "'" + gk.AOPOznaka;
                    xlWorkSheet.Cells[row + i, j + 4] = "'" + klasa;

                    xlWorkSheet.Cells[row + i, j + 5] = gk.Duguje;
                    xlWorkSheet.Cells[row + i, j + 6] = gk.Potrazuje;
                    xlWorkSheet.Cells[row + i, j + 7] = gk.Saldo;


                }
                
                xlWorkBook.Names.Add(rangeName, "=" + BrutoBilansSheet + "!$A$" + h.ToString() + ":$M$" + endRow.ToString());
                
                xlWorkBook.Names.Add("KontoZ" + klasa, "=" + BrutoBilansSheet + "!$A$" + (h + 1).ToString() + ":$A$" + endRow.ToString());
                xlWorkBook.Names.Add("AOPZ" + klasa, "=" + BrutoBilansSheet + "!$C$" + (h + 1).ToString() + ":$C$" + endRow.ToString());

                xlWorkBook.Names.Add("DugujeZ" + klasa, "=" + BrutoBilansSheet + "!$E$" + (h + 1).ToString() + ":$E$" + endRow.ToString());
                xlWorkBook.Names.Add("PotrazujeZ" + klasa, "=" + BrutoBilansSheet + "!$F$" + (h + 1).ToString() + ":$F$" + endRow.ToString());
                xlWorkBook.Names.Add("SaldoZ" + klasa, "=" + BrutoBilansSheet + "!$G$" + (h + 1).ToString() + ":$G$" + endRow.ToString());

                range = xlWorkSheet.get_Range("a" + h.ToString(), "m" + h.ToString());
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                range.Font.Bold = true;
                range.HorizontalAlignment = 3;
                range.Interior.Color = Color.Aqua;

                range = xlWorkSheet.get_Range("a" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.Borders.Weight = 1;

                range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.NumberFormatLocal = "#.##0,00";

                range = xlWorkSheet.get_Range("e" + (h + 1).ToString(), "g" + (endRow).ToString());
                range.Interior.Color = color1;
                range = xlWorkSheet.get_Range("h" + (h + 1).ToString(), "j" + (endRow).ToString());
                range.Interior.Color = color2;
                range = xlWorkSheet.get_Range("k" + (h + 1).ToString(), "m" + (endRow).ToString());
                range.Interior.Color = color3;

                range = xlWorkSheet.get_Range("a1", "m" + (endRow).ToString());
                range.Columns.AutoFit();
                range.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                throw new Exception("Greška u toku formiranja naloga za zatvaranje klase konta." + "\n" + ex.Message + "\n" + ex.StackTrace);
            }

            return endRow;
        }

        private int UpisiZaglavlje(Excel.Worksheet xlWorkSheet, int startRow)
        {
           
            Excel.Range range;
            
            string sRow = startRow.ToString();
            int endRow = startRow + 4;

            try
            {
                xlWorkSheet.Cells[startRow, 1] = selectedKorisnik.SifraKor + ":" + selectedKorisnik.NazivKor;
                xlWorkSheet.Cells[startRow + 1, 1] = selectedKorisnik.Adresa3;
                xlWorkSheet.Cells[startRow + 2, 1] = selectedKorisnik.Adresa1;
                xlWorkSheet.Cells[startRow + 3, 1] = selectedKorisnik.Adresa2;

                range = xlWorkSheet.get_Range("a" + startRow.ToString(), "m" + startRow.ToString());
                range.Merge();
                range = xlWorkSheet.get_Range("a" + (startRow + 1).ToString(), "m" + (startRow + 1).ToString());
                range.Merge();
                range = xlWorkSheet.get_Range("a" + (startRow + 2).ToString(), "m" + (startRow + 2).ToString());
                range.Merge();
                range = xlWorkSheet.get_Range("a" + (startRow + 3).ToString(), "m" + (startRow + 3).ToString());
                range.Merge();

                range = xlWorkSheet.get_Range("a" + startRow.ToString(), "m" + (startRow + 3).ToString());
                range.Font.Bold = true;
                range.Font.Size = 13;
                range.Interior.Color = Color.Beige;
                range.Rows.AutoFit();

                xlWorkSheet.Cells[startRow + 4, 1] = "Zaključen:";
                xlWorkSheet.Cells[startRow + 4, 2] = "NE";
                range = xlWorkSheet.get_Range("a" + (startRow + 4).ToString(), "b" + (startRow + 4).ToString());
                range.Font.Size = 9;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Greška u toku formiranja zaglavlja s podacima korisnika." + "\n" + ex.Message);
            }

            return endRow;
        }

        private int UpisiKorisnika(Excel.Workbook xlWorkBook)
        {
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            int startRow = 1;

            string sRow = startRow.ToString();
            int endRow = startRow + 4;

            try
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(MaticniPodaciSheet);
                xlWorkSheet.Cells.Clear();

                xlWorkSheet.Cells[startRow, 1] = "Podaci o pravnom licu/firmi";

                xlWorkSheet.Cells[startRow + 2, 1] = "Naziv pravnog lica:";
                xlWorkSheet.Cells[startRow + 2, 2] = "'" + selectedKorisnik.NazivKor;
                xlWorkBook.Names.Add("FirmaNaziv", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 2).ToString());
                
                xlWorkSheet.Cells[startRow + 3, 1] = "Adresa pravnog lica:";
                xlWorkSheet.Cells[startRow + 3, 2] = "'" + selectedKorisnik.Adresa3 + " " + selectedKorisnik.BrojUl;
                xlWorkBook.Names.Add("FirmaAdresa", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 3).ToString());
                
                xlWorkSheet.Cells[startRow + 4, 1] = "Sjedište pravnog lica:";
                xlWorkSheet.Cells[startRow + 4, 2] = "'" + selectedKorisnik.Adresa2;
                xlWorkBook.Names.Add("FirmaSjediste", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 4).ToString());
                
                xlWorkSheet.Cells[startRow + 5, 1] = "PTT broj sjedišta:";
                xlWorkSheet.Cells[startRow + 5, 2] = "'" + selectedKorisnik.PttBroj;
                xlWorkBook.Names.Add("FirmaPTT", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 5).ToString());
                
                xlWorkSheet.Cells[startRow + 6, 1] = "Šifra općine sjedišta:";
                xlWorkSheet.Cells[startRow + 6, 2] = "'" + selectedKorisnik.SifraOpc;
                xlWorkBook.Names.Add("FirmaOpcina", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 6).ToString());
                
                xlWorkSheet.Cells[startRow + 7, 1] = "ID broj pravnog lica:";
                xlWorkSheet.Cells[startRow + 7, 2] = "'" + selectedKorisnik.MatBroj;
                xlWorkBook.Names.Add("FirmaID", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 7).ToString());

                xlWorkSheet.Cells[startRow + 8, 1] = "PDV broj pravnog lica:";
                xlWorkSheet.Cells[startRow + 8, 2] = "'" + selectedKorisnik.PdvBroj;
                xlWorkBook.Names.Add("FirmaPDV", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 8).ToString());

                xlWorkSheet.Cells[startRow + 9, 1] = "Porezni djelovodni broj:";
                xlWorkSheet.Cells[startRow + 9, 2] = "'" + selectedKorisnik.PorDjBr;

                xlWorkSheet.Cells[startRow + 10, 1] = "Šifra djelatnosti:";
                xlWorkSheet.Cells[startRow + 10, 2] = "'" + selectedKorisnik.SifraDje;
                xlWorkBook.Names.Add("FirmaDjeSifra", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 10).ToString());

                xlWorkSheet.Cells[startRow + 11, 1] = "Naziv djelatnosti:";
                xlWorkSheet.Cells[startRow + 11, 2] = "'" + selectedKorisnik.NazivDje;
                xlWorkBook.Names.Add("FirmaDjeNaziv", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 11).ToString());

                xlWorkSheet.Cells[startRow + 12, 1] = "Prezime i ime direktora:";
                xlWorkSheet.Cells[startRow + 12, 2] = "'" + selectedKorisnik.Direktor;
                xlWorkBook.Names.Add("FirmaDirekor", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 12).ToString());

                xlWorkSheet.Cells[startRow + 13, 1] = "JMBG direktora:";
                xlWorkSheet.Cells[startRow + 13, 2] = "'" + selectedKorisnik.Jmbg;
                xlWorkBook.Names.Add("FirmaJMBG", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 13).ToString());

                xlWorkSheet.Cells[startRow + 14, 1] = "Zastupnik poreznog obveznika:";
                xlWorkSheet.Cells[startRow + 14, 2] = "'" + selectedKorisnik.ImeZast;
                xlWorkBook.Names.Add("FirmaZastupnik", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 14).ToString());

                xlWorkSheet.Cells[startRow + 15, 1] = "Adresa zastupnika:";
                xlWorkSheet.Cells[startRow + 15, 2] = "'" + selectedKorisnik.Adr1Zast + " " + selectedKorisnik.Adr2Zast;
                xlWorkBook.Names.Add("FirmaZastupnikAdresa", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 15).ToString());

                xlWorkSheet.Cells[startRow + 16, 1] = "Broj uloška u registraciji:";
                xlWorkSheet.Cells[startRow + 16, 2] = "'" + selectedKorisnik.BrojRje;
                xlWorkBook.Names.Add("FirmaRegistracija", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 16).ToString());

                xlWorkSheet.Cells[startRow + 17, 1] = "Kantonalni sud:";
                xlWorkSheet.Cells[startRow + 17, 2] = "'" + selectedKorisnik.RegInst;
                xlWorkBook.Names.Add("FirmaRegistracijaSud", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 17).ToString());

                xlWorkSheet.Cells[startRow + 18, 1] = "Telefon pravnog lica:";
                xlWorkSheet.Cells[startRow + 18, 2] = "'" + selectedKorisnik.Telefon;
                xlWorkBook.Names.Add("FirmaTelefon", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 18).ToString());

                xlWorkSheet.Cells[startRow + 19, 1] = "Fax pravnog lica:";
                xlWorkSheet.Cells[startRow + 19, 2] = "'" + selectedKorisnik.Fax;
                xlWorkBook.Names.Add("FirmaFax", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 19).ToString());

                xlWorkSheet.Cells[startRow + 20, 1] = "Banka 1 pravnog lica:";
                xlWorkSheet.Cells[startRow + 20, 2] = "'" + selectedKorisnik.Banka;
                xlWorkBook.Names.Add("FirmaBanka1", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 20).ToString());

                xlWorkSheet.Cells[startRow + 21, 1] = "Žiro račun u banci 1:";
                xlWorkSheet.Cells[startRow + 21, 2] = "'" + selectedKorisnik.ZiroRac;
                xlWorkBook.Names.Add("FirmaRacun1", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 21).ToString());

                xlWorkSheet.Cells[startRow + 22, 1] = "Banka 2 pravnog lica:";
                xlWorkSheet.Cells[startRow + 22, 2] = "'" + selectedKorisnik.Banka2;
                xlWorkBook.Names.Add("FirmaBanka2", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 22).ToString());

                xlWorkSheet.Cells[startRow + 23, 1] = "Žiro račun u banci 2:";
                xlWorkSheet.Cells[startRow + 23, 2] = "'" + selectedKorisnik.ZiroRac2;
                xlWorkBook.Names.Add("FirmaRacun2", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 23).ToString());

                xlWorkSheet.Cells[startRow + 24, 1] = "Banka 3 pravnog lica:";
                xlWorkSheet.Cells[startRow + 24, 2] = "'" + selectedKorisnik.Banka3;
                xlWorkBook.Names.Add("FirmaBanka3", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 24).ToString());

                xlWorkSheet.Cells[startRow + 25, 1] = "Žiro račun u banci 3:";
                xlWorkSheet.Cells[startRow + 25, 2] = "'" + selectedKorisnik.ZiroRac3;
                xlWorkBook.Names.Add("FirmaRacun3", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 25).ToString());



                range = xlWorkSheet.get_Range("a" + startRow.ToString(), "b" + startRow.ToString());
                range.Merge();
                range.Font.Bold = true;
                range.Font.Size = 13;
                range.Interior.Color = Color.Beige;
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.HorizontalAlignment = 3;
               

                range = xlWorkSheet.get_Range("a" + (startRow + 2).ToString(), "b" + (startRow + 25).ToString());
                range.Font.Bold = true;
                range.Font.Size = 12;
                
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.Borders.Weight = 1;
                
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                range = xlWorkSheet.get_Range("a" + (startRow + 2).ToString(), "a" + (startRow + 25).ToString());
                range.Interior.Color = color2;
                range = xlWorkSheet.get_Range("b" + (startRow + 2).ToString(), "b" + (startRow + 25).ToString());
                range.Interior.Color = color1;

                startRow += 27;
                xlWorkSheet.Cells[startRow, 1] = "Podaci o ovlaštenom računovođi pravnog lica";

                xlWorkSheet.Cells[startRow + 2, 1] = "Prezime i ime računovođe:";
                xlWorkSheet.Cells[startRow + 2, 2] = setup.KnjigovodjaIme;
                xlWorkBook.Names.Add("RacunovodjaIme", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 2).ToString());
                
                xlWorkSheet.Cells[startRow + 3, 1] = "Adresa računovođe:";
                xlWorkSheet.Cells[startRow + 3, 2] = setup.KnjigovodjaAdresa;
                xlWorkBook.Names.Add("RacunovodjaAdresa", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 3).ToString());

                xlWorkSheet.Cells[startRow + 4, 1] = "Broj dozvole računovođe:";
                xlWorkSheet.Cells[startRow + 4, 2] = "'" + setup.KnjigovodjaLicenca;
                xlWorkBook.Names.Add("RacunovodjaLicenca", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 4).ToString());

                xlWorkSheet.Cells[startRow + 5, 1] = "ID broj računovođe:";
                xlWorkSheet.Cells[startRow + 5, 2] = "'" + setup.KnjigovodjaID;
                xlWorkBook.Names.Add("RacunovodjaID", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 5).ToString());

                xlWorkSheet.Cells[startRow + 6, 1] = "Kontakt telefon računovođe:";
                xlWorkSheet.Cells[startRow + 6, 2] = "'" + setup.KnjigovodjaTelefon;
                xlWorkBook.Names.Add("RacunovodjaTelefon", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 6).ToString());

                range = xlWorkSheet.get_Range("a" + startRow.ToString(), "b" + startRow.ToString());
                range.Merge();
                range.Font.Bold = true;
                range.Font.Size = 13;
                range.Interior.Color = Color.Beige;
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.HorizontalAlignment = 3;

                range = xlWorkSheet.get_Range("a" + (startRow + 2).ToString(), "b" + (startRow + 6).ToString());
                range.Font.Bold = true;
                range.Font.Size = 12;

                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.Borders.Weight = 1;

                range = xlWorkSheet.get_Range("a" + (startRow + 2).ToString(), "a" + (startRow + 6).ToString());
                range.Interior.Color = color2;
                range = xlWorkSheet.get_Range("b" + (startRow + 2).ToString(), "b" + (startRow + 6).ToString());
                range.Interior.Color = color1;


                startRow += 8;
                xlWorkSheet.Cells[startRow, 1] = "Podaci periodu obračuna";

                xlWorkSheet.Cells[startRow + 2, 1] = "Obračun od datuma:";
                xlWorkSheet.Cells[startRow + 2, 2] = setup.BilanceOdDatuma.Day.ToString() + "." + setup.BilanceOdDatuma.Month.ToString() + ".";
                xlWorkBook.Names.Add("ObracunOdDatuma", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 2).ToString());

                xlWorkSheet.Cells[startRow + 3, 1] = "Obračun do datuma:";
                xlWorkSheet.Cells[startRow + 3, 2] = setup.BilanceDoDatuma.Day.ToString() + "." + setup.BilanceDoDatuma.Month.ToString() + ".";
                xlWorkBook.Names.Add("ObracunDoDatuma", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 3).ToString());

                xlWorkSheet.Cells[startRow + 4, 1] = "Godina obračuna:";
                xlWorkSheet.Cells[startRow + 4, 2] = "'" + setup.BilanceDoDatuma.Year.ToString();
                xlWorkBook.Names.Add("ObracunGodina", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 4).ToString());

                xlWorkSheet.Cells[startRow + 5, 1] = "Datum predaje obrazaca:";
                xlWorkSheet.Cells[startRow + 5, 2] = "'" + setup.BilanceDatumPredaje.ToShortDateString();
                xlWorkBook.Names.Add("ObracunPredaja", "=" + MaticniPodaciSheet + "!$B$" + (startRow + 5).ToString());

                range = xlWorkSheet.get_Range("a" + startRow.ToString(), "b" + startRow.ToString());
                range.Merge();
                range.Font.Bold = true;
                range.Font.Size = 13;
                range.Interior.Color = Color.Beige;
                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.HorizontalAlignment = 3;

                range = xlWorkSheet.get_Range("a" + (startRow + 2).ToString(), "b" + (startRow + 5).ToString());
                range.Font.Bold = true;
                range.Font.Size = 12;

                range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);
                range.Borders.Weight = 1;

                range = xlWorkSheet.get_Range("a" + (startRow + 2).ToString(), "a" + (startRow + 5).ToString());
                range.Interior.Color = color2;
                range = xlWorkSheet.get_Range("b" + (startRow + 2).ToString(), "b" + (startRow + 5).ToString());
                range.Interior.Color = color1;


                range = xlWorkSheet.get_Range("a" + (1).ToString(), "b" + (startRow + 5).ToString());
                range.Columns.AutoFit();
                range.Rows.AutoFit();

            }
            catch (Exception ex)
            {

                throw new Exception("Greška u toku upisa podataka o pravnom licu." + "\n" + ex.Message);
            }

            return endRow;
        }
        private bool IsZakljucen(Excel.Worksheet xlWorkSheet, int row, int col)
        {
            Excel.Range range;
            string zakljuceno = "NE";

            try
            {
               
                range = xlWorkSheet.UsedRange;
                if ((range.Rows.Count >= row) && (range.Columns.Count >= col))
                {
                    zakljuceno = (string)(range.Cells[row, col] as Excel.Range).Value2;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Provjera zaključenosti se ne može napraviti." + "\n" + ex.Message);
            }

            if (zakljuceno.ToUpper() == "DA")
            {
                return true;
            }
            else
            {
                return false;
            }
            
          
        }

       

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }


      
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private bool KillProcess(string processName)
        {
            Process[] aProc = Process.GetProcessesByName(processName);
            bool excelClosed = true;

            if (aProc.Length > 0)
            {
                 DialogResult result = MessageBox.Show("Excel proces je aktivan i mora se zatvoriti da bi se obrasci popunili." + "\n" +
                    "Ako ima otvorenih Excel datoteka one će se zatvoriti bez spremanja." + "\n" +
                    "Da li želite nastaviti i zatvoriti sve Excel datoteke bez spremanja?",
                    "Excel proces je aktivan",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                 if (result == DialogResult.Yes)
                 {
                   
                     foreach (Process p in aProc)
                     {
                       
                         p.Kill();
                     }
                 }
                 else
                 {
                     excelClosed = false;
                 }

            }

            return excelClosed;
            
        }



    }
}
