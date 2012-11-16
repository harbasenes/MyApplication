using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace Podaci
{
    public class AnalitickiKontoDB
    {
        public const string DbfFileName = "ANALKP.DBF";

        public static SortableSearchableList<AnalitickiKonto> GetAnalitickiKontniPlan(string folderName)
        {
            SortableSearchableList<AnalitickiKonto> listaAKP = new SortableSearchableList<AnalitickiKonto>();
            string sqlStatement =
                "SELECT AnalKto, NazivKto, AOPOzn, Ispravka " +
                "FROM AnalKP " +
                "ORDER BY AnalKto";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AnalitickiKonto akp = new AnalitickiKonto();

                    akp.Konto  = reader["AnalKto"].ToString();
                    akp.NazivKonta = reader["NazivKto"].ToString();
                    akp.AOPOznaka = reader["AopOzn"].ToString();
                    akp.KontoIspravke = reader["Ispravka"].ToString();

                    listaAKP.Add(akp);
                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                //throw ex;
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return listaAKP;
        }


        public static SortableSearchableList<AnalitickiKonto> GetAnalitickiKontniPlanByName(string folderName, string nazivKonta)
        {
            SortableSearchableList<AnalitickiKonto> listaAKP = new SortableSearchableList<AnalitickiKonto>();
            string sqlStatement =
                "SELECT AnalKto, NazivKto, AOPOzn, Ispravka " +
                "FROM AnalKP " +
                "WHERE UCASE(NazivKto) LIKE @NazivKto " +
                "ORDER BY AnalKto";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@NazivKto", "%" + nazivKonta.ToUpper() + "%");

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AnalitickiKonto akp = new AnalitickiKonto();

                    akp.Konto = reader["AnalKto"].ToString();
                    akp.NazivKonta = reader["NazivKto"].ToString();
                    akp.AOPOznaka = reader["AopOzn"].ToString();
                    akp.KontoIspravke = reader["Ispravka"].ToString();

                    listaAKP.Add(akp);
                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                //throw ex;
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return listaAKP;
        }

        public static AnalitickiKonto GetAnalitickiKonto(string folderName, string konto)
        {
            AnalitickiKonto analitickiKonto = null;
            
            string sqlStatement =
                "SELECT AnalKto, NazivKto, AOPOzn, Ispravka " +
                "FROM AnalKP " +
                "WHERE AnalKto = @AnalKto";

            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@AnalKto", konto.Replace("-", ""));

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    analitickiKonto = new AnalitickiKonto();

                    analitickiKonto.Konto = reader["AnalKto"].ToString();
                    analitickiKonto.NazivKonta = reader["NazivKto"].ToString();
                    analitickiKonto.AOPOznaka = reader["AopOzn"].ToString();
                    analitickiKonto.KontoIspravke = reader["Ispravka"].ToString();

                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                //throw ex;
                throw new Exception(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            return analitickiKonto;
        }

        public static bool DbfFileExists(string dbfFolderName)
        {
            return File.Exists(dbfFolderName + "\\" + SintetickiKontoDB.DbfFileName);
        }

        public static List<String> GetAOPOznake(SortableSearchableList<AnalitickiKonto> listaAKP)
        {
            List<String> listaAOP = new List<string>();

            foreach (AnalitickiKonto konto in listaAKP)
            {
                if ((konto.AOPOznaka != "") && (!listaAOP.Contains(konto.AOPOznaka)))
                {
                    listaAOP.Add(konto.AOPOznaka);
                }
            }
            if (listaAOP.Count > 1)
            {
                listaAOP.Sort();
            }

            return listaAOP;
        }

    }
}
