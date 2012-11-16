using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
//using System.Windows.Forms;

namespace Podaci
{
    class ZaBrutoBilans
    {
        public string Konto { get; set; }
        public string Strana { get; set; }
        public string PocSt { get; set; }

        public decimal Iznos { get; set; }
        
        public int BrojKnjizenja { get; set; }


    }

    public class BrutoBilansDB
    {
        public static SortableSearchableList<BrutoBilans> GetBrutoBilans(string folderName, string dbfKontaFolderName, DateTime odDatuma, DateTime doDatuma)
        {
            SortableSearchableList<BrutoBilans> brutoBilans = new SortableSearchableList<BrutoBilans>();
            List<ZaBrutoBilans> zaBrutoBilans = new List<ZaBrutoBilans>();

            string sqlStatement =
                "SELECT GK.AnalKto, GK.Strana, SUM(GK.IznosKnj) AS Iznos, COUNT(GK.AnalKto) AS BrojKnjizenja, " +
                "       NAL.PocSt " +
                "FROM GKnjiga AS GK " +
                "INNER JOIN Nalog AS NAL " +
                "ON NAL.BrojNal = GK.BrojNal " +
                "WHERE (NAL.DatumNal >= @OdDatuma) AND (NAL.DatumNal <= @DoDatuma)  " +
                "GROUP BY GK.AnalKto, GK.Strana, NAL.PocSt " +
                "ORDER BY GK.AnalKto, GK.Strana";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@OdDatuma", odDatuma);
            command.Parameters.AddWithValue("@DoDatuma", doDatuma);

            try
            {

                conn.Open();
                zaBrutoBilans = ReadItems(command);
                brutoBilans = FormBrutoBilans(zaBrutoBilans, dbfKontaFolderName);
            }
            catch (OleDbException ex)
            {
                //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return brutoBilans;
        }

        private static List<ZaBrutoBilans> ReadItems(OleDbCommand command)
        {

            List<ZaBrutoBilans> zaBrutoBilans = new List<ZaBrutoBilans>();

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ZaBrutoBilans zbb = new ZaBrutoBilans();

                zbb.Konto = reader["AnalKto"].ToString();

                zbb.PocSt = reader["PocSt"].ToString();
                zbb.Strana = reader["Strana"].ToString();
                zbb.Iznos = Convert.ToDecimal(reader["Iznos"]);
                zbb.BrojKnjizenja = Convert.ToInt32(reader["BrojKnjizenja"]);

                zaBrutoBilans.Add(zbb);
            }
            reader.Close();
            return zaBrutoBilans;
        }

        private static SortableSearchableList<BrutoBilans> FormBrutoBilans(List<ZaBrutoBilans> lista, string dbfKontaFolderName)
        {

            SortableSearchableList<BrutoBilans> brutoBilans = new SortableSearchableList<BrutoBilans>();
            
            BrutoBilans bb;
            string t_konto;

            int i = 0;
            
            while (i < lista.Count)
	        {

                bb = new BrutoBilans();
              
                t_konto = lista[i].Konto;
                AnalitickiKonto selectedKonto = AnalitickiKontoDB.GetAnalitickiKonto(dbfKontaFolderName, t_konto);

                bb.Konto = t_konto;

                if (selectedKonto != null)
                {
                    bb.NazivKonta = selectedKonto.NazivKonta;
                    bb.AOPOznaka = selectedKonto.AOPOznaka;
                    bb.KontoIspravke = selectedKonto.KontoIspravke; 
                }

                while ((i < lista.Count) && (lista[i].Konto == t_konto)) 
                {
                    if (lista[i].Strana == "D")
                    {
                        bb.Duguje += lista[i].Iznos;
                        if (lista[i].PocSt == "D")
                        {
                            bb.DugujePS += lista[i].Iznos;
                        }
                    }
                    else
                    {
                        bb.Potrazuje += lista[i].Iznos;
                        if (lista[i].PocSt == "D")
                        {
                            bb.PotrazujePS += lista[i].Iznos;
                        }
                    }

                    bb.BrojKnjizenja += lista[i].BrojKnjizenja;

                    i++;
                }

                brutoBilans.Add(bb);
	         
	        }

            return brutoBilans;
        }


        public static SortableSearchableList<BrutoBilans> BrutoBilansPoGrupma(SortableSearchableList<BrutoBilans> brutoBilans, string grupa)
        {

            SortableSearchableList<BrutoBilans> grupeBilans = new SortableSearchableList<BrutoBilans>();

            BrutoBilans bb;
            string t_konto;
            int brojGrupe = Convert.ToInt32(grupa);

            int i = 0;

            while (i < brutoBilans.Count)
            {

                bb = new BrutoBilans();

                t_konto = brutoBilans[i].Konto.Substring(0, brojGrupe);

               // AnalitickiKonto selectedKonto = AnalitickiKontoDB.GetAnalitickiKonto(dbfKontaFolderName, t_konto);

                bb.Konto = t_konto;

                while ((i < brutoBilans.Count) && (brutoBilans[i].Konto.Substring(0, brojGrupe) == t_konto))
                {
                    bb.Duguje += brutoBilans[i].Duguje;
                    bb.Potrazuje += brutoBilans[i].Potrazuje;
                    bb.DugujePS += brutoBilans[i].DugujePS;
                    bb.PotrazujePS += brutoBilans[i].PotrazujePS;
                    bb.BrojKnjizenja += brutoBilans[i].BrojKnjizenja;
 

                    i++;
                }

                grupeBilans.Add(bb);

            }

            return grupeBilans;
        }


        /// <summary>
        /// Izvjestaj po sintetickim kontima iz bruto bilansa
        /// Razdvaja po oznaci ispravke
        /// </summary>
        /// <param name="brutoBilans"></param>
        /// <param name="dbfKontaFolderName"></param>
        /// <returns></returns>
        public static SortableSearchableList<BrutoBilans> BrutoBilansPoSK(SortableSearchableList<BrutoBilans> brutoBilans, string dbfKontaFolderName)
        {

            SortableSearchableList<BrutoBilans> grupeBilans = new SortableSearchableList<BrutoBilans>();

            BrutoBilans bbBruto;
            BrutoBilans bbIspravka;
            SintetickiKonto sintKonto;

            string t_konto;
            int brojGrupe = 3; //sinteticki konto

            int i = 0;

            while (i < brutoBilans.Count)
            {

                bbBruto = new BrutoBilans();
                bbIspravka = new BrutoBilans();

                t_konto = brutoBilans[i].Konto.Substring(0, brojGrupe);
                sintKonto = SintetickiKontoDB.GetSintetickiKonto(dbfKontaFolderName, t_konto); 

                bbBruto.Konto = t_konto;
                bbBruto.KontoIspravke = "N";
                bbBruto.NazivKonta = sintKonto.NazivKonta;

                bbIspravka.Konto = t_konto + "I";
                bbIspravka.KontoIspravke = "D";
                bbIspravka.NazivKonta = sintKonto.NazivKonta;

                while ((i < brutoBilans.Count) && (brutoBilans[i].Konto.Substring(0, brojGrupe) == t_konto))
                {
                    if (brutoBilans[i].KontoIspravke == "D")
                    {
                        bbIspravka.Duguje += brutoBilans[i].Duguje;
                        bbIspravka.Potrazuje += brutoBilans[i].Potrazuje;
                        bbIspravka.DugujePS += brutoBilans[i].DugujePS;
                        bbIspravka.PotrazujePS += brutoBilans[i].PotrazujePS;
                        bbIspravka.BrojKnjizenja += brutoBilans[i].BrojKnjizenja;
                    }
                    else
                    {
                        bbBruto.Duguje += brutoBilans[i].Duguje;
                        bbBruto.Potrazuje += brutoBilans[i].Potrazuje;
                        bbBruto.DugujePS += brutoBilans[i].DugujePS;
                        bbBruto.PotrazujePS += brutoBilans[i].PotrazujePS;
                        bbBruto.BrojKnjizenja += brutoBilans[i].BrojKnjizenja;
                    }

                    i++;
                }

                if (bbBruto.BrojKnjizenja > 0)
                {
                    grupeBilans.Add(bbBruto);
                }
                if (bbIspravka.BrojKnjizenja > 0)
                {
                    grupeBilans.Add(bbIspravka);
                }

            }
           
            return grupeBilans;
        }

    }
}
