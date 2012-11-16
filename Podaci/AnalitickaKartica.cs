using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podaci
{
    public class AnalitickaKartica
    {
        public string BrojNaloga { get; set; }
        public DateTime DatumNaloga { get; set; }
        public DateTime DatumDokumenta { get; set; }
        public string OpisKnjizenja { get; set; }
        public string Konto { get; set; }
        public decimal Duguje { get; set; }
        public decimal Potrazuje { get; set; }
        public string OrganizacionaJedinica { get; set; }
        public decimal DugujePS { get; set; }
        public decimal PotrazujePS { get; set; }
        public string VrstaNaloga { get; set; }
        public string OpisNaloga { get; set; }

        public DateTime OdDatuma { get; set; }
        public DateTime DoDatuma { get; set; }
        public string OdOrgJedinice { get; set; }
        public string DoOrgJedinice { get; set; }

        public decimal Saldo
        {
            get
            {
                return Duguje - Potrazuje;
            }
        }
        
        public decimal SaldoPS
        {
            get
            {
                return DugujePS - PotrazujePS;
            }
        }

        public decimal DugujeTP
        {
            get
            {
                return Duguje - DugujePS;
            }
        }
        
        public decimal PotrazujeTP
        {
            get
            {
                return Potrazuje - PotrazujePS;
            }
        }

        public decimal SaldoTP
        {
            get
            {
                return Saldo - SaldoPS;
            }
        }

        public string BrojNalogaFormated
        {
            get
            {
                if (BrojNaloga.Length == 5)
                {
                    return BrojNaloga.Substring(0, 1) + "-" + BrojNaloga.Substring(1, 4);
                }
                else
                {
                    return BrojNaloga;
                }
            }
        }

        public string KontoFormated
        {
            get
            {

                if (Konto.Length == 7)
                {
                    return Konto.Substring(0, 3) + "-" + Konto.Substring(3, 4);

                }
                else
                {
                    return Konto;
                }
            }
        }

        public static decimal[] GetUkupnoKartice(SortableSearchableList<AnalitickaKartica> listaItems)
        {
            decimal[] obrKartice = new decimal[9];

            foreach (AnalitickaKartica ak in listaItems)
            {
                obrKartice[0] += ak.DugujePS;
                obrKartice[1] += ak.PotrazujePS;
                obrKartice[2] += ak.SaldoPS;

                obrKartice[3] += ak.DugujeTP;
                obrKartice[4] += ak.PotrazujeTP;
                obrKartice[5] += ak.SaldoTP;

                obrKartice[6] += ak.Duguje;
                obrKartice[7] += ak.Potrazuje;
                obrKartice[8] += ak.Saldo;

            }

            return obrKartice;
        }
    }
}
