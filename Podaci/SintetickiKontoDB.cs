using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Podaci
{


    public class SintetickiKontoDB
    {
        public const string DbfFileName = "SINTKP.DBF";
        
        public static SortableSearchableList<SintetickiKonto> GetSintetickiKontniPlan(string folderName)
        {
            SortableSearchableList<SintetickiKonto> listaSKP = new SortableSearchableList<SintetickiKonto>();
            string sqlStatement =
                "SELECT SintKto, NazivKto, AktPas, AOPOzn " +
                "FROM SintKP " +
                "ORDER BY SintKto";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SintetickiKonto skp = new SintetickiKonto();

                    skp.Konto = reader["SintKto"].ToString();
                    skp.NazivKonta = reader["NazivKto"].ToString();
                    skp.AktivniPasivni = reader["AktPas"].ToString();
                    skp.AOPOznaka = reader["AopOzn"].ToString();

                    listaSKP.Add(skp);
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
            return listaSKP;
        }

        public static SortableSearchableList<SintetickiKonto> GetSintetickiKontniPlanByName(string folderName, string nazivKto)
        {
            SortableSearchableList<SintetickiKonto> listaSKP = new SortableSearchableList<SintetickiKonto>();
            string sqlStatement =
                "SELECT SintKto, NazivKto, AktPas, AOPOzn " +
                "FROM SintKP " +
                "WHERE UCASE(NazivKto) LIKE @NazivKto " +
                "ORDER BY SintKto";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@NazivKto", "%" + nazivKto.ToUpper() + "%");

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SintetickiKonto skp = new SintetickiKonto();

                    skp.Konto = reader["SintKto"].ToString();
                    skp.NazivKonta = reader["NazivKto"].ToString();
                    skp.AktivniPasivni = reader["AktPas"].ToString();
                    skp.AOPOznaka = reader["AopOzn"].ToString();

                    listaSKP.Add(skp);
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
            return listaSKP;
        }


        public static SintetickiKonto GetSintetickiKonto(string folderName, string sintKto)
        {
            SintetickiKonto sintetickiKonto = null;

            string sqlStatement =
                "SELECT SintKto, NazivKto, AktPas, AOPOzn " +
                "FROM SintKP " +
                "WHERE SintKto = @SintKto";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@SintKto", sintKto);

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    sintetickiKonto = new SintetickiKonto();

                    sintetickiKonto.Konto = reader["SintKto"].ToString();
                    sintetickiKonto.NazivKonta = reader["NazivKto"].ToString();
                    sintetickiKonto.AktivniPasivni = reader["AktPas"].ToString();
                    sintetickiKonto.AOPOznaka = reader["AopOzn"].ToString();

                    
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
            return sintetickiKonto;
        }

        public static bool DbfFileExists(string dbfFolderName)
        {
            return File.Exists(dbfFolderName + "\\" + SintetickiKontoDB.DbfFileName);
        }

        public static List<String> GetAOPOznake(SortableSearchableList<SintetickiKonto> listaSKP)
        {
            List<String> listaAOP = new List<string>();

            foreach (SintetickiKonto konto in listaSKP)
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
