using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Podaci
{
    public class AnalitickaKarticaDB
    {
        public static SortableSearchableList<AnalitickaKartica> GetItemsGkByKonto(string folderName, string analKto, DateTime odDatuma, DateTime doDatuma)
        {
            SortableSearchableList<AnalitickaKartica> listaItemGk = new SortableSearchableList<AnalitickaKartica>();

            string sqlStatement =
                "SELECT GK.BrojNal, GK.DatumDok, GK.OpisKnj, GK.AnalKto, GK.Strana, GK.IznosKnj, GK.SifraOJ, " +
                "       NAL.DatumNal, NAL.PocSt, NAL.OpisNal " +
                "FROM GKnjiga AS GK " +
                "INNER JOIN Nalog AS NAL " +
                "ON NAL.BrojNal = GK.BrojNal " +
                "WHERE (GK.AnalKto = @AnalKto) AND (NAL.DatumNal >= @OdDatuma) AND (NAL.DatumNal <= @DoDatuma)  " +
                "ORDER BY NAL.DatumNal, GK.BrojNal";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);
            
            command.Parameters.AddWithValue("@AnalKto", analKto.Replace("-", ""));
            command.Parameters.AddWithValue("@OdDatuma", odDatuma);
            command.Parameters.AddWithValue("@DoDatuma", doDatuma);
            
            try
            {

                conn.Open();
                listaItemGk = ReadItems(command);
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
            return listaItemGk;
        }

        private static SortableSearchableList<AnalitickaKartica> ReadItems(OleDbCommand command)
        {
            string strana = "";
            decimal iznos = 0m;
            string vrstaNaloga = "";

            SortableSearchableList<AnalitickaKartica> listaItemGk = new SortableSearchableList<AnalitickaKartica>();

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AnalitickaKartica itemGk = new AnalitickaKartica();

                itemGk.BrojNaloga = reader["BrojNal"].ToString();

                itemGk.DatumDokumenta = Convert.ToDateTime(reader["DatumDok"]);

                
                itemGk.OpisKnjizenja = reader["OpisKnj"].ToString();
                itemGk.Konto = reader["AnalKto"].ToString();
                itemGk.OrganizacionaJedinica = reader["SifraOJ"].ToString();

                itemGk.OpisNaloga = reader["OpisNal"].ToString();
                itemGk.VrstaNaloga = reader["PocSt"].ToString();
               
               
                itemGk.DatumNaloga = Convert.ToDateTime(reader["DatumNal"]);
               

                vrstaNaloga = reader["PocSt"].ToString();
                strana = reader["Strana"].ToString();
                iznos = Convert.ToDecimal(reader["IznosKnj"]);

                switch (strana)
                {
                    case "D":
                        itemGk.Duguje = iznos;
                        itemGk.Potrazuje = 0m;
                        if (vrstaNaloga == "D")
                        {
                            itemGk.DugujePS = iznos;
                            itemGk.PotrazujePS = 0m;
                        }
                        break;
                    case "P":
                        itemGk.Duguje = 0m;
                        itemGk.Potrazuje = iznos;
                        if (vrstaNaloga == "D")
                        {
                            itemGk.DugujePS = 0m;
                            itemGk.PotrazujePS = iznos;
                        }
                        break;
                    default:
                        itemGk.Duguje = 0m;
                        itemGk.Potrazuje = iznos;
                        if (vrstaNaloga == "D")
                        {
                            itemGk.DugujePS = iznos;
                            itemGk.PotrazujePS = 0m;
                        }
                        break;
                }

                listaItemGk.Add(itemGk);
            }
            reader.Close();
            return listaItemGk;
        }

    }
}
