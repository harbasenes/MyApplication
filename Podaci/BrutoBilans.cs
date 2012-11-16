using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podaci
{
    public class BrutoBilans
    {
        //public AnalitickiKonto Konto { get; set; }
       
        public string Konto { get; set; }
        public string NazivKonta { get; set; }
        public string AOPOznaka { get; set; }
        public string KontoIspravke { get; set; }
       
        public decimal Duguje { get; set; }
        public decimal Potrazuje { get; set; }
        public decimal DugujePS { get; set; }
        public decimal PotrazujePS { get; set; }

        public int BrojKnjizenja { get; set; }


        public string SintetickiDio
        {
            get
            {
                return Konto.Substring(0, 3);
            }
        }

        public string KlasaKonta
        {
            get
            {
                return Konto.Substring(0, 1);
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

        public static decimal[] GetUkupnoBrutoBilans(SortableSearchableList<BrutoBilans> listaItems)
        {
            decimal[] obrBilans = new decimal[10];

            foreach (BrutoBilans bb in listaItems)
            {
                obrBilans[0] += bb.DugujePS;
                obrBilans[1] += bb.PotrazujePS;
                obrBilans[2] += bb.SaldoPS;

                obrBilans[3] += bb.DugujeTP;
                obrBilans[4] += bb.PotrazujeTP;
                obrBilans[5] += bb.SaldoTP;

                obrBilans[6] += bb.Duguje;
                obrBilans[7] += bb.Potrazuje;
                obrBilans[8] += bb.Saldo;
                
                obrBilans[9] += bb.BrojKnjizenja;

            }

            return obrBilans;
        }

    }


}
