using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.IO;


namespace Podaci
{
    public class KorisnikDB
    {

        public static SortableSearchableList<Korisnik> GetListaKorisnika(string folderName, string aktivni, string pdvObveznici, string oblikOrg)
        {
            SortableSearchableList<Korisnik> listaKorisnika = new SortableSearchableList<Korisnik>();
            string sqlStatement =
                "SELECT SifraKor, MatBroj, PdvBroj, NazivKor, Adresa1, Adresa2, Adresa3, PttBroj, " +
                "       BrojUl, SifraOpc, VrstaKor, Aktivan, Telefon, Fax, Mobitel, Email, " +
                "       Direktor, KontaktO, Jmbg, PorDjBr, CarBroj, RegBrPIO, PpaSifra, " +
                "       PdvStatus, PdvOdDat, PdvDoDat, PdvPotp, BrojRje, DatumRje, RegInst, " +
                "       ZiroRac, Banka, ZiroRac2, Banka2, ZiroRac3, Banka3, ZiroRac4, Banka4, ZiroRac5, Banka5, " +
                "       StPotpL, NaslPL, ImePL, StPotpD, NaslPD, ImePD, StPotpS, NaslPS, ImePS, " +
                "       Zagl11, Zagl12, Zagl13, Zagl14, Zagl15, Zagl16, Zagl17, " +
                "       Zagl21, Zagl22, Zagl23, Zagl24, Zagl25, Zagl26, Zagl27, Zagl28, Zagl29, Zagl30, " +
                "       NaslovR, NaslovP, NaslovIR, NaslovAR, NaslovPP, NaslIR, " +
                "       OznIza, OznVal, NacZaokr, BrDecKol, BrDecCij, IzborZgl, " +
                "       StrKupca, OznIspred, FixPrvi, VrstaOtp, BrRedObr, " +
                "       ImeRac, DozvRac, TelRac, Adr1Rac, Adr2Rac, " +
                "       ImeZast, Adr1Zast, Adr2Zast, PodnosDP, JmbgPodn, SpcSacin, SpcPotp, " +
                "       ImePorBI, SifraDje, NazivDje, " +
                "       IzbSifAr, KontniPl, PoslPar, SifMat, AmortGr, RevalGr, " +
                "       Lozinka, Napom, " +
                "       Fiskaliz, IspisFR, FisOdDat, NasloSAR " +
                "FROM Korisn " +
                "WHERE (Aktivan LIKE @Aktivan) AND (PdvStatus LIKE @PdvStatus) AND (VrstaKor LIKE @VrstaKor) " +
                "ORDER BY SifraKor";
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@Aktivan", aktivni);
            command.Parameters.AddWithValue("@PdvStatus", pdvObveznici);
            command.Parameters.AddWithValue("@VrstaKor", oblikOrg);


            
            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Korisnik korisnik = GetKorisnikFromReader(reader);
                    listaKorisnika.Add(korisnik);
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
            return listaKorisnika;
        }


        public static Korisnik GetKorisnik(string folderName, string sifrakor)
        {
            Korisnik korisnik = null;

            string sqlStatement =
                "SELECT SifraKor, MatBroj, PdvBroj, NazivKor, Adresa1, Adresa2, Adresa3, PttBroj, " +
                "       BrojUl, SifraOpc, VrstaKor, Aktivan, Telefon, Fax, Mobitel, Email, " +
                "       Direktor, KontaktO, Jmbg, PorDjBr, CarBroj, RegBrPIO, PpaSifra, " +
                "       PdvStatus, PdvOdDat, PdvDoDat, PdvPotp, BrojRje, DatumRje, RegInst, " +
                "       ZiroRac, Banka, ZiroRac2, Banka2, ZiroRac3, Banka3, ZiroRac4, Banka4, ZiroRac5, Banka5, " +
                "       StPotpL, NaslPL, ImePL, StPotpD, NaslPD, ImePD, StPotpS, NaslPS, ImePS, " +
                "       Zagl11, Zagl12, Zagl13, Zagl14, Zagl15, Zagl16, Zagl17, " +
                "       Zagl21, Zagl22, Zagl23, Zagl24, Zagl25, Zagl26, Zagl27, Zagl28, Zagl29, Zagl30, " +
                "       NaslovR, NaslovP, NaslovIR, NaslovAR, NaslovPP, NaslIR, " +
                "       OznIza, OznVal, NacZaokr, BrDecKol, BrDecCij, IzborZgl, " +
                "       StrKupca, OznIspred, FixPrvi, VrstaOtp, BrRedObr, " +
                "       ImeRac, DozvRac, TelRac, Adr1Rac, Adr2Rac, " +
                "       ImeZast, Adr1Zast, Adr2Zast, PodnosDP, JmbgPodn, SpcSacin, SpcPotp, " +
                "       ImePorBI, SifraDje, NazivDje, " +
                "       IzbSifAr, KontniPl, PoslPar, SifMat, AmortGr, RevalGr, " +
                "       Lozinka, Napom, " +
                "       Fiskaliz, IspisFR, FisOdDat, NasloSAR " +
                "FROM Korisn " +
                "WHERE (SifraKor = @SifraKor)";
            
            OleDbConnection conn = KnjigovodstvoDB.GetConnection(folderName);
            OleDbCommand command = new OleDbCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@SifraKor", sifrakor);


            try
            {
                conn.Open();

                OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    korisnik = GetKorisnikFromReader(reader);
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
            return korisnik;
        }

        private static Korisnik GetKorisnikFromReader(OleDbDataReader reader)
        {
            Korisnik korisnik = new Korisnik();

            korisnik.SifraKor = reader["SifraKor"].ToString();
            korisnik.NazivKor = reader["NazivKor"].ToString();
            korisnik.Adresa1 = reader["Adresa1"].ToString();
            korisnik.Adresa2 = reader["Adresa2"].ToString();
            korisnik.Adresa3 = reader["Adresa3"].ToString();
            korisnik.PttBroj = reader["PttBroj"].ToString();
            korisnik.BrojUl = reader["BrojUl"].ToString();
            korisnik.SifraOpc = reader["SifraOpc"].ToString();
            korisnik.VrstaKor = reader["VrstaKor"].ToString();

            korisnik.Aktivan = reader["Aktivan"].ToString();

            korisnik.Telefon = reader["Telefon"].ToString();
            korisnik.Fax = reader["Fax"].ToString();
            korisnik.Mobitel = reader["Mobitel"].ToString();
            korisnik.Email = reader["Email"].ToString();

            korisnik.Direktor = reader["Direktor"].ToString();
            korisnik.KontaktO = reader["KontaktO"].ToString();

            korisnik.Jmbg = reader["Jmbg"].ToString();
            korisnik.PorDjBr = reader["PorDjBr"].ToString();
            korisnik.MatBroj = reader["MatBroj"].ToString();
            korisnik.CarBroj = reader["CarBroj"].ToString();
            korisnik.RegBrPIO = reader["RegBrPIO"].ToString();
            korisnik.PpaSifra = reader["PpaSifra"].ToString();

            korisnik.PdvStatus = reader["PdvStatus"].ToString();
            korisnik.PdvBroj = reader["PdvBroj"].ToString();

            if (reader["PdvOdDat"] == DBNull.Value)
            {
                korisnik.PdvOdDat = null;

            }
            else
            {
                korisnik.PdvOdDat = Convert.ToDateTime(reader["PdvOdDat"]);
            }

            if (reader["PdvDoDat"] == DBNull.Value)
            {
                korisnik.PdvDoDat = null;

            }
            else
            {
                korisnik.PdvDoDat = Convert.ToDateTime(reader["PdvDoDat"]);
            }


            korisnik.PdvPotp = reader["PdvPotp"].ToString();

            korisnik.BrojRje = reader["BrojRje"].ToString();

            if (reader["DatumRje"] == DBNull.Value)
            {
                korisnik.DatumRje = null;

            }
            else
            {
                korisnik.DatumRje = Convert.ToDateTime(reader["DatumRje"]);
            }

            korisnik.RegInst = reader["RegInst"].ToString();

            korisnik.ZiroRac = reader["ZiroRac"].ToString();
            korisnik.Banka = reader["Banka"].ToString();
            korisnik.ZiroRac2 = reader["ZiroRac2"].ToString();
            korisnik.Banka2 = reader["Banka2"].ToString();
            korisnik.ZiroRac3 = reader["ZiroRac3"].ToString();
            korisnik.Banka3 = reader["Banka3"].ToString();
            korisnik.ZiroRac4 = reader["ZiroRac4"].ToString();
            korisnik.Banka4 = reader["Banka4"].ToString();
            korisnik.ZiroRac5 = reader["ZiroRac5"].ToString();
            korisnik.Banka5 = reader["Banka5"].ToString();

            korisnik.StPotpL = reader["StPotpL"].ToString();
            korisnik.NaslPL = reader["NaslPL"].ToString();
            korisnik.ImePL = reader["ImePL"].ToString();

            korisnik.StPotpD = reader["StPotpD"].ToString();
            korisnik.NaslPD = reader["NaslPD"].ToString();
            korisnik.ImePD = reader["ImePD"].ToString();

            korisnik.StPotpS = reader["StPotpS"].ToString();
            korisnik.NaslPS = reader["NaslPS"].ToString();
            korisnik.ImePS = reader["ImePS"].ToString();

            korisnik.Zagl11 = reader["Zagl11"].ToString();
            korisnik.Zagl12 = reader["Zagl12"].ToString();
            korisnik.Zagl13 = reader["Zagl13"].ToString();
            korisnik.Zagl14 = reader["Zagl14"].ToString();
            korisnik.Zagl15 = reader["Zagl15"].ToString();
            korisnik.Zagl16 = reader["Zagl16"].ToString();
            korisnik.Zagl17 = reader["Zagl17"].ToString();

            korisnik.Zagl21 = reader["Zagl21"].ToString();
            korisnik.Zagl22 = reader["Zagl22"].ToString();
            korisnik.Zagl23 = reader["Zagl23"].ToString();
            korisnik.Zagl24 = reader["Zagl24"].ToString();
            korisnik.Zagl25 = reader["Zagl25"].ToString();
            korisnik.Zagl26 = reader["Zagl26"].ToString();
            korisnik.Zagl27 = reader["Zagl27"].ToString();
            korisnik.Zagl28 = reader["Zagl28"].ToString();
            korisnik.Zagl29 = reader["Zagl29"].ToString();
            korisnik.Zagl30 = reader["Zagl30"].ToString();

            korisnik.NaslovR = reader["NaslovR"].ToString();
            korisnik.NaslovP = reader["NaslovP"].ToString();
            korisnik.NaslovIR = reader["NaslovIR"].ToString();
            korisnik.NaslovAR = reader["NaslovAR"].ToString();
            korisnik.NaslovPP = reader["NaslovPP"].ToString();
            korisnik.NaslIR = reader["NaslIR"].ToString();

            korisnik.OznIza = reader["OznIza"].ToString();
            korisnik.OznVal = reader["OznVal"].ToString();
            korisnik.NacZaokr = reader["NacZaokr"].ToString();
            korisnik.BrDecKol = reader["BrDecKol"].ToString();
            korisnik.BrDecCij = reader["BrDecCij"].ToString();
            korisnik.IzborZgl = reader["IzborZgl"].ToString();
            korisnik.StrKupca = reader["StrKupca"].ToString();
            korisnik.OznIspred = reader["OznIspred"].ToString();
            korisnik.FixPrvi = reader["FixPrvi"].ToString();
            korisnik.VrstaOtp = reader["VrstaOtp"].ToString();
            korisnik.BrRedObr = Convert.ToInt32(reader["BrRedObr"]);

            korisnik.ImeRac = reader["ImeRac"].ToString();
            korisnik.DozvRac = reader["DozvRac"].ToString();
            korisnik.TelRac = reader["TelRac"].ToString();
            korisnik.Adr1Rac = reader["Adr1Rac"].ToString();
            korisnik.Adr2Rac = reader["Adr2Rac"].ToString();

            korisnik.ImeZast = reader["ImeZast"].ToString();
            korisnik.Adr1Zast = reader["Adr1Zast"].ToString();
            korisnik.Adr2Zast = reader["Adr2Zast"].ToString();

            korisnik.PodnosDP = reader["PodnosDP"].ToString();
            korisnik.JmbgPodn = reader["JmbgPodn"].ToString();
            korisnik.SpcSacin = reader["SpcSacin"].ToString();
            korisnik.SpcPotp = reader["SpcPotp"].ToString();

            korisnik.ImePorBi = reader["ImePorBi"].ToString();

            korisnik.SifraDje = reader["SifraDje"].ToString();
            korisnik.NazivDje = reader["NazivDje"].ToString();

            korisnik.IzbSifAr = reader["IzbSifAr"].ToString();
            korisnik.KontniPl = reader["KontniPl"].ToString();
            korisnik.PoslPar = reader["PoslPar"].ToString();
            korisnik.SifMat = reader["SifMat"].ToString();
            korisnik.AmortGr = reader["AmortGr"].ToString();
            korisnik.RevalGr = reader["RevalGr"].ToString();

            korisnik.Lozinka = reader["Lozinka"].ToString();
            korisnik.Napom = reader["Napom"].ToString();

            korisnik.NasloSAR = reader["NasloSAR"].ToString();
            korisnik.Fiskaliz = reader["Fiskaliz"].ToString();
            korisnik.IspisFR = reader["IspisFR"].ToString();

            if (reader["FisOdDat"] == DBNull.Value)
            {
                korisnik.FisOdDat = null;
            }
            else
            {
                korisnik.FisOdDat = Convert.ToDateTime(reader["FisOdDat"]);
            }
            return korisnik;
        }







    }
}
