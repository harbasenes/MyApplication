using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podaci
{
    public class Korisnik
    {
        public const string ImeTabele = "Korisn";

        public string Lokacija { get; set; } //folder u kom se nalazi korisn.dbf

        public string SifraKor { get; set; }
        public string NazivKor { get; set; }
        public string Adresa1 { get; set; }
        public string Adresa2 { get; set; }
        public string Adresa3 { get; set; }
        public string BrojUl { get; set; }
        public string SifraOpc { get; set; }
        public string PttBroj { get; set; }
        public string VrstaKor { get; set; }

        public string Aktivan { get; set; }
        
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Mobitel { get; set; }
        public string Email { get; set; }

        public string Direktor { get; set; }
        public string KontaktO { get; set; }

        public string Jmbg { get; set; }
        public string PorDjBr { get; set; }
        public string MatBroj { get; set; }
        public string CarBroj { get; set; }
        public string RegBrPIO { get; set; }
        public string PpaSifra { get; set; }

        public string PdvStatus { get; set; }
        public string PdvBroj { get; set; }
        public DateTime? PdvOdDat { get; set; }
        public DateTime? PdvDoDat { get; set; }
        public string PdvPotp { get; set; }

        public string BrojRje { get; set; }
        public DateTime? DatumRje { get; set; }
        public string RegInst { get; set; }
        
        public string ZiroRac { get; set; }
        public string Banka { get; set; }
        public string ZiroRac2 { get; set; }
        public string Banka2 { get; set; }
        public string ZiroRac3 { get; set; }
        public string Banka3 { get; set; }
        public string ZiroRac4 { get; set; }
        public string Banka4 { get; set; }
        public string ZiroRac5 { get; set; }
        public string Banka5 { get; set; }

        public string StPotpL { get; set; }
        public string NaslPL { get; set; }
        public string ImePL { get; set; }

        public string StPotpD { get; set; }
        public string NaslPD { get; set; }
        public string ImePD { get; set; }
        
        public string StPotpS { get; set; }
        public string NaslPS { get; set; }
        public string ImePS { get; set; }
        
        public string Zagl11 { get; set; }
        public string Zagl12 { get; set; }
        public string Zagl13 { get; set; }
        public string Zagl14 { get; set; }
        public string Zagl15 { get; set; }
        public string Zagl16 { get; set; }
        public string Zagl17 { get; set; }
        public string Zagl21 { get; set; }
        public string Zagl22 { get; set; }
        public string Zagl23 { get; set; }
        public string Zagl24 { get; set; }
        public string Zagl25 { get; set; }
        public string Zagl26 { get; set; }
        public string Zagl27 { get; set; }
        public string Zagl28 { get; set; }
        public string Zagl29 { get; set; }
        public string Zagl30 { get; set; }

        public string NaslovR { get; set; }
        public string NaslovP { get; set; }
        public string NaslovIR { get; set; }
        public string NaslovAR { get; set; }
        public string NaslovPP { get; set; }
        public string NaslIR { get; set; }

        public string OznIza { get; set; }
        public string OznVal { get; set; }
        public string NacZaokr { get; set; }
        public string BrDecKol { get; set; }
        public string BrDecCij { get; set; }
        public string IzborZgl { get; set; }
        public string StrKupca { get; set; }
        public string OznIspred { get; set; }
        public string FixPrvi { get; set; }
        public string VrstaOtp { get; set; }
        public int BrRedObr { get; set; }


        public string ImeRac { get; set; }
        public string DozvRac { get; set; }
        public string TelRac { get; set; }
        public string Adr1Rac { get; set; }
        public string Adr2Rac { get; set; }

        public string ImeZast { get; set; }
        public string Adr1Zast { get; set; }
        public string Adr2Zast { get; set; }

        public string PodnosDP { get; set; }
        public string JmbgPodn { get; set; }
        public string SpcSacin { get; set; }
        public string SpcPotp { get; set; }

        public string ImePorBi { get; set; }

        public string SifraDje { get; set; }
        public string NazivDje { get; set; }

        public string IzbSifAr { get; set; }
        public string KontniPl { get; set; }
        public string PoslPar { get; set; }
        public string SifMat { get; set; }
        public string AmortGr { get; set; }
        public string RevalGr { get; set; }

        public string Lozinka { get; set; }
        public string Napom { get; set; }

        //dodano u zadnjem update-u
        public string NasloSAR { get; set; }
        public string Fiskaliz { get; set; }
        public string IspisFR { get; set; }
        public DateTime? FisOdDat { get; set; }

    }
}
