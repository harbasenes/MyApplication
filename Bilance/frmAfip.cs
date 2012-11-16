using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Bilance
{
    public partial class frmAfip : Form
    {
        private Afip afip;

        public frmAfip()
        {
            InitializeComponent();
        }

        private void btnGetPrazanAfip_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPrazanAfip.Text = openFileDialog.FileName;
            }
        }

        private void btnGetFolderPopunjeni_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolderPopunjeniAfip.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnGetObrasci_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPopunjenObrazac.Text = openFileDialog.FileName;
            }
        }

        private void btnOtvoriFolderSource_Click(object sender, EventArgs e)
        {
            string folderPath = Path.GetDirectoryName(txtPrazanAfip.Text);
            try
            {
                Utility.OpenFolder(folderPath);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Mapa se ne može otvoriti." + "\n" + ex.Message, "Mapa se ne može otvoriti");

            }
            
        }

        private void btnOtvoriPrazan_Click(object sender, EventArgs e)
        {
            string sourceFileName = txtPrazanAfip.Text;

            if (File.Exists(sourceFileName))
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;

                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(sourceFileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlApp.Visible = true;

                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Prazna Afip datoteka se ne može otvoriti." + "\n" + ex.Message, "Datoteka se ne može otvoriti");

                }
            }
            else
            {
                MessageBox.Show("Prazna Afip datoteka ne postoji.\n" + sourceFileName, "Ne postoji datoteka");
            }
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

        private void btnOtvoriPopunjenAfip_Click(object sender, EventArgs e)
        {
            string sourceFileName = GetNamePopunjenAfip(txtPopunjenObrazac.Text, txtFolderPopunjeniAfip.Text);

            if (File.Exists(sourceFileName))
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;

                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(sourceFileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlApp.Visible = true;

                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Popunjena Afip datoteka se ne može otvoriti." + "\n" + ex.Message, "Datoteka se ne može otvoriti");

                }
            }
            else
            {
                MessageBox.Show("Popunjena Afip datoteka ne postoji.\n" + sourceFileName, "Ne postoji datoteka");
            }
        }

        private string GetNamePopunjenAfip(string bilanceName, string folderName)
        {
            string extension = Path.GetExtension(bilanceName);
            string fileName = "AFIP-" + Path.GetFileNameWithoutExtension(bilanceName);

            return folderName + Path.DirectorySeparatorChar + fileName + extension;
        }

        private void txtFolderPopunjeniAfip_TextChanged(object sender, EventArgs e)
        {
            txtPopunjenAfip.Text = GetNamePopunjenAfip(txtPopunjenObrazac.Text, txtFolderPopunjeniAfip.Text);
        }

        private void frmAfip_Load(object sender, EventArgs e)
        {
            afip = Afip.GetAfipFromXml();

            if (afip != null)
            {
                txtFolderPopunjeniAfip.Text = afip.FolderAfip;
                txtPrazanAfip.Text = afip.ImePrazanAfip;
                txtPopunjenObrazac.Text = afip.ImeBilanci;
                txtPopunjenAfip.Text = afip.ImePopunjenAfip();
            }
        }

        private void frmAfip_FormClosed(object sender, FormClosedEventArgs e)
        {
            afip = new Afip();

            afip.ImePrazanAfip = txtPrazanAfip.Text;
            afip.FolderAfip = txtFolderPopunjeniAfip.Text;
            afip.ImeBilanci = txtPopunjenObrazac.Text;

            Afip.SaveAfipToXml(afip);
        }

        private void btnOtvoriFolder_Click(object sender, EventArgs e)
        {
            string folderPath = txtFolderPopunjeniAfip.Text;
            try
            {
                Utility.OpenFolder(folderPath);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Mapa se ne može otvoriti." + "\n" + ex.Message, "Mapa se ne može otvoriti");

            }
        }

        private void btnOtvoriFolderBilanci_Click(object sender, EventArgs e)
        {
            string folderPath = Path.GetDirectoryName(txtPopunjenObrazac.Text);
            try
            {
                Utility.OpenFolder(folderPath);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Mapa se ne može otvoriti." + "\n" + ex.Message, "Mapa se ne može otvoriti");

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnOtvoriBilance_Click(object sender, EventArgs e)
        {
            string sourceFileName = txtPopunjenObrazac.Text;

            if (File.Exists(sourceFileName))
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;

                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(sourceFileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlApp.Visible = true;

                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Popunjen obrazac bilanci datoteka se ne može otvoriti." + "\n" + ex.Message, "Datoteka se ne može otvoriti");

                }
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPopuni_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtPrazanAfip.Text))
            {

                MessageBox.Show("Prazna Afip datoteka ne postoji.\n" + txtPrazanAfip.Text, "Ne postoji datoteka");
                return;
            }
            
            if (!File.Exists(txtPopunjenObrazac.Text))
            {

                MessageBox.Show("Ne postoji popunjen obrazac bilanci.\n" + txtPopunjenObrazac.Text, "Ne postoji datoteka");
                return;
            }

            if (!Directory.Exists(txtFolderPopunjeniAfip.Text))
            {
                try
                {
                    Directory.CreateDirectory(txtFolderPopunjeniAfip.Text);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Ne postoji mapa u koju će se spremati Afip datoteke.\n" + txtFolderPopunjeniAfip.Text + "\n\n" + ex.Message, "Ne postoji mapa/folder");
                    return;

                }
            }

            if (File.Exists(txtPopunjenAfip.Text))
            {
                DialogResult result;

                result = MessageBox.Show("Popunjena Afip datoteka već postoji.\n" + txtPopunjenAfip.Text + "\n\n" + "Popuniti Afip datoteku ponovo?", "Datoteka već postoji", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            if (!KopirajPrazan())
            {
                    MessageBox.Show("Kopiranje prazne Afip datoteke nije uspjelo.\n" + txtPrazanAfip.Text, "Greška u kopiranju");
                    return;
                
            }

            FormirajAfip();


        }

        private bool KopirajPrazan()
        {

            string sourceFileName = txtPrazanAfip.Text;
            string destinationFileName = txtPopunjenAfip.Text;
            string destinationFolder = Path.GetDirectoryName(destinationFileName);

            if (!File.Exists(sourceFileName))
            {
                MessageBox.Show("Prazna Afip datoteka ne postoji.\n" + sourceFileName, "Ne postoji datoteka");
                return false;
            }
            if (!Directory.Exists(destinationFolder))
            {
                MessageBox.Show("Mapa u koju se spremaju popunjene Afip datoteke ne postoji.\n" + destinationFolder, "Ne postoji mapa/folder");
                return false;
            }

            File.Copy(sourceFileName, destinationFileName, true);

            if (File.Exists(destinationFileName))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void FormirajAfip()
        {
            string sourceFileName = txtPopunjenObrazac.Text;
            string destinationFileName = txtPopunjenAfip.Text;

            if (File.Exists(sourceFileName) && File.Exists(destinationFileName) )
            {
                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWBSource;
                    Excel.Workbook xlWBDest;
                    Excel.Worksheet xlWSSource;
                    Excel.Worksheet xlWSDest;
                    Excel.Range range;

                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWBSource = xlApp.Workbooks.Open(sourceFileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWBDest = xlApp.Workbooks.Open(destinationFileName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                    xlWSSource = (Excel.Worksheet)xlWBSource.Worksheets.get_Item("bilans-stanja");
                    xlWSDest = (Excel.Worksheet)xlWBDest.Worksheets.get_Item("#BS_A");

                    for (int i = 0; i <= 12; i++)
                    {
                        xlWSDest.Cells[2 + i, "B"] = xlWSSource.Cells[26 + i, "Z"];
                        xlWSDest.Cells[2 + i, "C"] = xlWSSource.Cells[26 + i, "AG"];
                        xlWSDest.Cells[2 + i, "D"] = xlWSSource.Cells[26 + i, "AN"];
                        xlWSDest.Cells[2 + i, "E"] = xlWSSource.Cells[26 + i, "AU"]; 
                    }

                    for (int i = 0; i <= 35; i++)
                    {
                        xlWSDest.Cells[15 + i, "B"] = xlWSSource.Cells[43 + i, "Z"];
                        xlWSDest.Cells[15 + i, "C"] = xlWSSource.Cells[43 + i, "AG"];
                        xlWSDest.Cells[15 + i, "D"] = xlWSSource.Cells[43 + i, "AN"];
                        xlWSDest.Cells[15 + i, "E"] = xlWSSource.Cells[43 + i, "AU"];
                    }
                    
                    for (int i = 0; i <= 17; i++)
                    {
                        xlWSDest.Cells[51 + i, "B"] = xlWSSource.Cells[83 + i, "Z"];
                        xlWSDest.Cells[51 + i, "C"] = xlWSSource.Cells[83 + i, "AG"];
                        xlWSDest.Cells[51 + i, "D"] = xlWSSource.Cells[83 + i, "AN"];
                        xlWSDest.Cells[51 + i, "E"] = xlWSSource.Cells[83 + i, "AU"];
                    }
                    
                    xlWSDest = (Excel.Worksheet)xlWBDest.Worksheets.get_Item("#BS_P");

                    for (int i = 0; i <= 13; i++)
                    {
                        xlWSDest.Cells[2 + i, "B"] = xlWSSource.Cells[106 + i, "AH"];
                        xlWSDest.Cells[2 + i, "C"] = xlWSSource.Cells[106 + i, "AR"];
                    }
                    for (int i = 0; i <= 36; i++)
                    {
                        xlWSDest.Cells[16 + i, "B"] = xlWSSource.Cells[123 + i, "AH"];
                        xlWSDest.Cells[16 + i, "C"] = xlWSSource.Cells[123 + i, "AR"];
                    }
                    for (int i = 0; i <= 16; i++)
                    {
                        xlWSDest.Cells[53 + i, "B"] = xlWSSource.Cells[163 + i, "AH"];
                        xlWSDest.Cells[53 + i, "C"] = xlWSSource.Cells[163 + i, "AR"];
                    }

                    xlWSSource = (Excel.Worksheet)xlWBSource.Worksheets.get_Item("bilans-uspjeha");
                    xlWSDest = (Excel.Worksheet)xlWBDest.Worksheets.get_Item("#BU");

                    for (int i = 0; i <= 10; i++)
                    {
                        xlWSDest.Cells[2 + i, "B"] = xlWSSource.Cells[28 + i, "AH"];
                        xlWSDest.Cells[2 + i, "C"] = xlWSSource.Cells[28 + i, "AR"];
                    }
                    
                    for (int i = 0; i <= 14; i++)
                    {
                        xlWSDest.Cells[13 + i, "B"] = xlWSSource.Cells[42 + i, "AH"];
                        xlWSDest.Cells[13 + i, "C"] = xlWSSource.Cells[42 + i, "AR"];
                    }

                    for (int i = 0; i <= 12; i++)
                    {
                        xlWSDest.Cells[28 + i, "B"] = xlWSSource.Cells[58 + i, "AH"];
                        xlWSDest.Cells[28 + i, "C"] = xlWSSource.Cells[58 + i, "AR"];
                    }
                    
                    for (int i = 0; i <= 3; i++)
                    {
                        xlWSDest.Cells[41 + i, "B"] = xlWSSource.Cells[74 + i, "AH"];
                        xlWSDest.Cells[41 + i, "C"] = xlWSSource.Cells[74 + i, "AR"];
                    }

                    for (int i = 0; i <= 21; i++)
                    {
                        xlWSDest.Cells[45 + i, "B"] = xlWSSource.Cells[79 + i, "AH"];
                        xlWSDest.Cells[45 + i, "C"] = xlWSSource.Cells[79 + i, "AR"];
                    }

                    for (int i = 0; i <= 26; i++)
                    {
                        xlWSDest.Cells[67 + i, "B"] = xlWSSource.Cells[105 + i, "AH"];
                        xlWSDest.Cells[67 + i, "C"] = xlWSSource.Cells[105 + i, "AR"];
                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        xlWSDest.Cells[94 + i, "B"] = xlWSSource.Cells[135 + i, "AH"];
                        xlWSDest.Cells[94 + i, "C"] = xlWSSource.Cells[135 + i, "AR"];
                    }

                    for (int i = 0; i <= 1; i++)
                    {
                        xlWSDest.Cells[98 + i, "B"] = xlWSSource.Cells[140 + i, "AH"];
                        xlWSDest.Cells[98 + i, "C"] = xlWSSource.Cells[140 + i, "AR"];
                    }
                    for (int i = 0; i <= 2; i++)
                    {
                        xlWSDest.Cells[100 + i, "B"] = xlWSSource.Cells[143 + i, "AH"];
                        xlWSDest.Cells[100 + i, "C"] = xlWSSource.Cells[143 + i, "AR"];
                    }
                    for (int i = 0; i <= 1; i++)
                    {
                        xlWSDest.Cells[103 + i, "B"] = xlWSSource.Cells[147 + i, "AH"];
                        xlWSDest.Cells[103 + i, "C"] = xlWSSource.Cells[147 + i, "AR"];
                    }
                    for (int i = 0; i <= 6; i++)
                    {
                        xlWSDest.Cells[105 + i, "B"] = xlWSSource.Cells[150 + i, "AH"];
                        xlWSDest.Cells[105 + i, "C"] = xlWSSource.Cells[150 + i, "AR"];                    
                    }
                    for (int i = 0; i <= 2; i++)
                    {
                        xlWSDest.Cells[112 + i, "B"] = xlWSSource.Cells[158 + i, "AH"];
                        xlWSDest.Cells[112 + i, "C"] = xlWSSource.Cells[158 + i, "AR"];
                    }
                    for (int i = 0; i <= 17; i++)
                    {
                        xlWSDest.Cells[115 + i, "B"] = xlWSSource.Cells[165 + i, "AH"];
                        xlWSDest.Cells[115 + i, "C"] = xlWSSource.Cells[165 + i, "AR"];
                    }
                    for (int i = 0; i <= 1; i++)
                    {
                        xlWSDest.Cells[133 + i, "B"] = xlWSSource.Cells[184 + i, "AH"];
                        xlWSDest.Cells[133 + i, "C"] = xlWSSource.Cells[184 + i, "AR"];
                    }
                    for (int i = 0; i <= 8; i++)
                    {
                        xlWSDest.Cells[135 + i, "B"] = xlWSSource.Cells[191 + i, "AH"];
                        xlWSDest.Cells[135 + i, "C"] = xlWSSource.Cells[191 + i, "AR"];
                    }
                    for (int i = 0; i <= 1; i++)
                    {
                        xlWSDest.Cells[144 + i, "B"] = xlWSSource.Cells[202 + i, "AH"];
                        xlWSDest.Cells[144 + i, "C"] = xlWSSource.Cells[202 + i, "AR"];
                    }

                    xlWSSource = (Excel.Worksheet)xlWBSource.Worksheets.get_Item("prom.kap2.");
                    xlWSDest = (Excel.Worksheet)xlWBDest.Worksheets.get_Item("#IPK");

                    for (int i = 0; i <= 22; i++)
                    {
                        xlWSDest.Cells[2 + i, "B"] = xlWSSource.Cells[4 + i, "V"];
                        xlWSDest.Cells[2 + i, "C"] = xlWSSource.Cells[4 + i, "Z"];
                        xlWSDest.Cells[2 + i, "D"] = xlWSSource.Cells[4 + i, "AD"];
                        xlWSDest.Cells[2 + i, "E"] = xlWSSource.Cells[4 + i, "AH"];
                        xlWSDest.Cells[2 + i, "F"] = xlWSSource.Cells[4 + i, "AL"];
                        xlWSDest.Cells[2 + i, "G"] = xlWSSource.Cells[4 + i, "AP"];
                        xlWSDest.Cells[2 + i, "H"] = xlWSSource.Cells[4 + i, "AT"];
                        xlWSDest.Cells[2 + i, "I"] = xlWSSource.Cells[4 + i, "AX"];
                    }

                    xlWSSource = (Excel.Worksheet)xlWBSource.Worksheets.get_Item("got.tok_ind");
                    xlWSDest = (Excel.Worksheet)xlWBDest.Worksheets.get_Item("#GT_2");

                    for (int i = 0; i <= 0; i++)
                    {
                        xlWSDest.Cells[2 + i, "C"] = xlWSSource.Cells[28 + i, "AR"];
                        xlWSDest.Cells[2 + i, "D"] = xlWSSource.Cells[28 + i, "BA"];
                    }

                    for (int i = 0; i <= 16; i++)
                    {
                        xlWSDest.Cells[3 + i, "C"] = xlWSSource.Cells[30 + i, "AR"];
                        xlWSDest.Cells[3 + i, "D"] = xlWSSource.Cells[30 + i, "BA"];
                    }
                    for (int i = 0; i <= 13; i++)
                    {
                        xlWSDest.Cells[20 + i, "C"] = xlWSSource.Cells[52 + i, "AR"];
                        xlWSDest.Cells[20 + i, "D"] = xlWSSource.Cells[52 + i, "BA"];
                    }
                    for (int i = 0; i <= 21; i++)
                    {
                        xlWSDest.Cells[34 + i, "C"] = xlWSSource.Cells[67 + i, "AR"];
                        xlWSDest.Cells[34 + i, "D"] = xlWSSource.Cells[67 + i, "BA"];
                    }
                    xlApp.DisplayAlerts = false;

                    xlWBDest.SaveAs(destinationFileName, misValue, misValue, misValue, misValue,
                                                       misValue, Excel.XlSaveAsAccessMode.xlNoChange,
                                                       misValue, misValue, misValue, misValue, misValue);
                    xlWBSource.Close(false);

                    xlWBDest.Worksheets["#BS_A"].Activate();

                    xlApp.Caption = "Formiranje datoteke za AFIP";

                    xlApp.Visible = true;

                    releaseObject(xlWBSource);
                    releaseObject(xlWBDest);
                    releaseObject(xlApp);
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel-ove datoteke se ne mogu otvoriti." + "\n" + ex.Message, "Excel");

                }
            }
        }

    }
}
