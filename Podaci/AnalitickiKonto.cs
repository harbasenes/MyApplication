using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podaci
{
    public class AnalitickiKonto
    {
        public string Konto { get; set; }
        public string NazivKonta { get; set; }
        public string AOPOznaka { get; set; }
        public string KontoIspravke { get; set; }

        public string SintetickiDio
        {
            get
            {
                if (Konto.Length >= 3)
                {
                    return Konto.Substring(0, 3);
                }
                else
                {
                    return "";
                }
            }
        }

        public string KlasaKonta
        {
            get
            {
                if (Konto.Length >= 1)
                {
                    return Konto.Substring(0, 1);
                }
                else
                {
                    return "";
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

        public static string GetKontoFormated(string konto)
        {
                if (konto.Length == 7)
                {
                    return konto.Substring(0, 3) + "-" + konto.Substring(3, 4);
                   
                }
                else
                {
                    return konto;
                }

        }

    }
}
