using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Podaci;

namespace Bilance
{
    class Utility
    {
        public static bool OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "explorer";
                    psi.Arguments = string.Format("/root,{0}", folderPath);
                    psi.UseShellExecute = true;

                    Process process = new Process();
                    process.StartInfo = psi;
                    process.Start();
                    return true;

                }
                catch (Exception ex)
                {
                    throw ex;
                    
                }

            }
            return false;

        }

        public static string GetDbfFolder(ProgramItem selectedProgram, Korisnik selectedKorisnik)
        {
            string dbfFolderName = "";

            if ((selectedProgram != null) && (selectedKorisnik != null))
            {
                dbfFolderName = selectedProgram.ImeMape + "\\" + selectedKorisnik.SifraKor;
            }

            return dbfFolderName;
        }

        public static string GetDbfFolderKonta(ProgramItem selectedProgram, Korisnik selectedKorisnik)
        {
            string dbfKontaFolderName = "";

            if ((selectedProgram != null) && (selectedKorisnik != null))
            {


                if (selectedKorisnik.KontniPl == "Z")
                    dbfKontaFolderName = selectedProgram.ImeMape;
                else
                    dbfKontaFolderName = selectedProgram.ImeMape + "\\" + selectedKorisnik.SifraKor;

            }

            return dbfKontaFolderName;
        }

        public static string GetFilePath(string fileName)
        {
            string dir = Application.StartupPath + @"\XML";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                
            }
            return Path.Combine(dir, fileName);
        }


    }
}
