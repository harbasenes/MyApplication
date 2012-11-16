using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Podaci
{
    public class ItemGkDB
    {
        public const string DbfFileName = "GKNJIGA.DBF";

        public static SortableSearchableList<ItemGk> GetItemsGk(string folderName, string dbfKontaFolderName)
        {
            List<ItemGk> lista_ItemGk = new List<ItemGk>();
            SortableSearchableList<ItemGk> listaItemGk = new SortableSearchableList<ItemGk>();
            string sqlStatement =
                "SELECT BrojNal, DatumDok, OpisKnj, AnalKto, Strana, IznosKnj, SifraOJ " +
                "FROM GKnjiga " +
                "ORDER BY BrojNal";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            try
            {

                conn.Open();
                lista_ItemGk = ReadItems(command);
                listaItemGk = ExpandList(lista_ItemGk, dbfKontaFolderName);
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
            return listaItemGk;
        }

        public static SortableSearchableList<ItemGk> GetItemsGkByBrojNaloga(string folderName, string brojNaloga, string dbfKontaFolderName)
        {
            List<ItemGk> lista_ItemGk = new List<ItemGk>();
            SortableSearchableList<ItemGk> listaItemGk = new SortableSearchableList<ItemGk>();
            
            string sqlStatement =
                "SELECT BrojNal, DatumDok, OpisKnj, AnalKto, Strana, IznosKnj, SifraOJ " +
                "FROM GKnjiga " +
                "WHERE BrojNal = @BrojNal " +
                "ORDER BY BrojNal";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);
            command.Parameters.AddWithValue("@BrojNal", brojNaloga);
            
            try
            {
         
                conn.Open();
                lista_ItemGk = ReadItems(command);
                listaItemGk = ExpandList(lista_ItemGk, dbfKontaFolderName);
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
            return listaItemGk;
        }

        private static List<ItemGk> ReadItems(OleDbCommand command)
        {
            string strana = "";
            decimal iznos = 0m;
            List<ItemGk> listaItemGk = new List<ItemGk>();

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ItemGk itemGk = new ItemGk();

                itemGk.BrojNaloga = reader["BrojNal"].ToString();
                itemGk.DatumDokumenta = Convert.ToDateTime(reader["DatumDok"]);
                itemGk.OpisKnjizenja = reader["OpisKnj"].ToString();
                itemGk.Konto = reader["AnalKto"].ToString();
                itemGk.OrganizacionaJedinica = reader["SifraOJ"].ToString();

                strana = reader["Strana"].ToString();
                iznos = Convert.ToDecimal(reader["IznosKnj"]);

                switch (strana)
                {
                    case "D":
                        itemGk.Duguje = iznos;
                        itemGk.Potrazuje = 0m;
                        break;
                    case "P":
                        itemGk.Duguje = 0m;
                        itemGk.Potrazuje = iznos;
                        break;
                    default:
                        itemGk.Duguje = 0m;
                        itemGk.Potrazuje = iznos;
                        break;
                }

                listaItemGk.Add(itemGk);
            }
            reader.Close();
            return listaItemGk;
        }


        private static SortableSearchableList<ItemGk> ExpandList(List<ItemGk> lista, string dbfKontaFolderName)
        {
            //dodati podatak o kontu (naziv, aop i ostalo)
 
            SortableSearchableList<ItemGk> listaItemGk = new SortableSearchableList<ItemGk>();
            
            ItemGk newItemGk = null;

            string t_konto = "";

            int i = 0;

            while (i < lista.Count)
            {

                newItemGk = new ItemGk();

                t_konto = lista[i].Konto;

                AnalitickiKonto selectedKonto = AnalitickiKontoDB.GetAnalitickiKonto(dbfKontaFolderName, t_konto);

                newItemGk.Konto = lista[i].Konto;
                newItemGk.OpisKnjizenja = lista[i].OpisKnjizenja;
                newItemGk.OrganizacionaJedinica = lista[i].OrganizacionaJedinica;
                newItemGk.DatumDokumenta = lista[i].DatumDokumenta;
                newItemGk.BrojNaloga = lista[i].BrojNaloga;
                newItemGk.Duguje = lista[i].Duguje;
                newItemGk.Potrazuje = lista[i].Potrazuje;
                newItemGk.KontoKnjizenja = selectedKonto;

                listaItemGk.Add(newItemGk);

                i++;
            }


            return listaItemGk;
        }

        public static SortableSearchableList<ItemGk> GroupItemsGKBySK(SortableSearchableList<ItemGk> lista, string dbfKontaFolderName)
        {
            //grupirati po sintetickom kontu

            SortableSearchableList<ItemGk> listaItemGk = new SortableSearchableList<ItemGk>();

            ItemGk newItemGk = null;
            SintetickiKonto sintKonto;
     
            string t_konto = "";

            int i = 0;

      

          lista.Sort("Konto", System.ComponentModel.ListSortDirection.Ascending);


            while (i < lista.Count)
            {

                newItemGk = new ItemGk();

                t_konto = lista[i].Konto.Substring(0, 3);

                sintKonto = SintetickiKontoDB.GetSintetickiKonto(dbfKontaFolderName, t_konto);

                newItemGk.Konto = t_konto;
                newItemGk.OpisKnjizenja = sintKonto.NazivKonta;

                while ((i < lista.Count) && (lista[i].Konto.Substring(0, 3) == t_konto))
                {
                    newItemGk.Duguje += lista[i].Duguje;
                    newItemGk.Potrazuje += lista[i].Potrazuje;

                    i++;
                }

                listaItemGk.Add(newItemGk);
               
            }


            return listaItemGk;
        }


        public static List<string> GetKontaNaloga(SortableSearchableList<ItemGk> listaItemGk)
        {
            List<string> listaKontaNaloga = new List<string>();

            foreach (ItemGk item in listaItemGk)
            {
                if (!listaKontaNaloga.Contains(item.KontoFormated))
                {
                    listaKontaNaloga.Add(item.KontoFormated);
                }
            }
            if (listaKontaNaloga.Count > 1)
            {
                listaKontaNaloga.Sort();
            }

            return listaKontaNaloga;
        }

        public static List<decimal> GetIznoseNaloga(SortableSearchableList<ItemGk> listaItemGk)
        {
            List<decimal> listaIznosaNaloga = new List<decimal>();
            decimal iznos = 0m;

            foreach (ItemGk item in listaItemGk)
            {
                iznos = item.Duguje + item.Potrazuje;

                if ((iznos > 0) && (!listaIznosaNaloga.Contains(iznos)))
                {
                    listaIznosaNaloga.Add(iznos);
                }
            }
            if (listaIznosaNaloga.Count > 1)
            {
                listaIznosaNaloga.Sort();
            }

            return listaIznosaNaloga;
        }


        public static List<string> GetKontaGk(string folderName)
        {
            string konto = "";
            List<string> listaKontaGk = new List<string>();
            string sqlStatement =
                "SELECT DISTINCT AnalKto " +
                "FROM GKnjiga " +
                "ORDER BY AnalKto";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            try
            {

                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ItemGk itemGk = new ItemGk();

                    konto = reader["AnalKto"].ToString();

                    listaKontaGk.Add(AnalitickiKonto.GetKontoFormated(konto));
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
            return listaKontaGk;
        }

        public static bool DbfFileExists(string dbfFolderName)
        {
            return File.Exists(dbfFolderName + "\\" + ItemGkDB.DbfFileName);
        }

    }
}
