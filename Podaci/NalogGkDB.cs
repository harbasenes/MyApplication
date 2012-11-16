using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Podaci
{
    public class NalogGkDB
    {

        public const string DbfFileName = "NALOG.DBF";

        public static SortableSearchableList<NalogGk> GetListaNalogaGk(string folderName)
        {
            SortableSearchableList<NalogGk> listaNalogaGk = new SortableSearchableList<NalogGk>();
            string sqlStatement =
                "SELECT BrojNal, DatumNal, PocSt, OpisNal " +
                "FROM Nalog " +
                "ORDER BY BrojNal";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

           try
            {
                conn.Open();
               
               OleDbDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    NalogGk nalogGk = new NalogGk();

                    nalogGk.BrojNaloga = reader["BrojNal"].ToString();
                    nalogGk.DatumNaloga = Convert.ToDateTime(reader["DatumNal"]);
                    nalogGk.VrstaNaloga = reader["PocSt"].ToString();
                    nalogGk.OpisNaloga = reader["OpisNal"].ToString();

                    listaNalogaGk.Add(nalogGk);
                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
           //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return listaNalogaGk;
        }

        public static SortableSearchableList<NalogGk> GetListaNalogaGkByOpis(string folderName, string opisNal)
        {
            SortableSearchableList<NalogGk> listaNalogaGk = new SortableSearchableList<NalogGk>();
            string sqlStatement =
                "SELECT BrojNal, DatumNal, PocSt, OpisNal " +
                "FROM Nalog " +
                "WHERE UCASE(OpisNal) LIKE @OpisNal " + 
                "ORDER BY BrojNal";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("OpisNal", "%" + opisNal.ToUpper() + "%");

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NalogGk nalogGk = new NalogGk();

                    nalogGk.BrojNaloga = reader["BrojNal"].ToString();
                    nalogGk.DatumNaloga = Convert.ToDateTime(reader["DatumNal"]);
                    nalogGk.VrstaNaloga = reader["PocSt"].ToString();
                    nalogGk.OpisNaloga = reader["OpisNal"].ToString();

                    listaNalogaGk.Add(nalogGk);
                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return listaNalogaGk;
        }


        public static NalogGk GetNalogGkByPocSt(string folderName, string pocSt)
        {
            NalogGk nalogGk = null;
            
            string sqlStatement =
                "SELECT BrojNal, DatumNal, PocSt, OpisNal " +
                "FROM Nalog " +
                "WHERE PocSt = @PocSt";
            
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);
            
            command.Parameters.AddWithValue("PocSt", pocSt);

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    nalogGk = new NalogGk();

                    nalogGk.BrojNaloga = reader["BrojNal"].ToString();
                    nalogGk.DatumNaloga = Convert.ToDateTime(reader["DatumNal"]);
                    nalogGk.VrstaNaloga = reader["PocSt"].ToString();
                    nalogGk.OpisNaloga = reader["OpisNal"].ToString();

                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return nalogGk;
        }

        public static List<DateTime> GetDatumeGk(string folderName)
        {
            List<DateTime> listaDatumaGk = new List<DateTime>();
            string sqlStatement =
                "SELECT MAX(DatumNal) AS MaxDatum, MIN(DatuMNal) AS MinDatum " +
                "FROM Nalog";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DateTime datum1 = Convert.ToDateTime(reader["MinDatum"]);
                    DateTime datum2 = Convert.ToDateTime(reader["MaxDatum"]);

                    listaDatumaGk.Add(datum1);
                    listaDatumaGk.Add(datum2);
                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                //     global::System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return listaDatumaGk;
        }


        public static List<string> GetDatumeNaloga(SortableSearchableList<NalogGk> listaNalogGk)
        {
            List<DateTime> listaDatuma = new List<DateTime>(); //bitan za ispravno sortiranje
            List<string> listaDatumaString = new List<string>();

            //foreach (NalogGk nalog in listaNalogGk)
            //{
            //    if ((nalog.DatumNaloga.HasValue) && (!listaDatuma.Contains(nalog.DatumNaloga.Value)))
            //    {
            //        listaDatuma.Add(nalog.DatumNaloga.Value);
            //    }
            //}
            
            foreach (NalogGk nalog in listaNalogGk)
            {
                    listaDatuma.Add(nalog.DatumNaloga);
            }
            
            
            if (listaDatuma.Count > 1)
            {
                listaDatuma.Sort(); 
                foreach (DateTime d in listaDatuma)
                {
                    listaDatumaString.Add(d.ToShortDateString());
                }
            }

            return listaDatumaString;
        }

        public static bool DbfFileExists(string dbfFolderName)
        {
            return File.Exists(dbfFolderName + "\\" + NalogGkDB.DbfFileName);
        }

    
  


    }
}
