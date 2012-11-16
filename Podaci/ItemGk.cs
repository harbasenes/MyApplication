using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podaci
{
    public class ItemGk
    {
        public string BrojNaloga { get; set; }
        public DateTime DatumDokumenta { get; set; }
        public string OpisKnjizenja { get; set; }
        public string Konto { get; set; }
        public decimal Duguje { get; set; }
        public decimal Potrazuje { get; set; }
        public string OrganizacionaJedinica { get; set; }

        public AnalitickiKonto KontoKnjizenja { get; set; }

        public decimal Saldo 
        {
            get
            {
                return Duguje - Potrazuje;
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

        public string AOPOznaka
        {
            get
            {
                if (KontoKnjizenja != null)
                {
                    return KontoKnjizenja.AOPOznaka;
                }
                else
                {
                    return "";
                }
            }
        }
        
        public string NazivKonta
        {
            get
            {
                if (KontoKnjizenja != null)
                {
                    return KontoKnjizenja.NazivKonta;
                }
                else
                {
                    return "";
                }
               
            }
        }

        public string KontoIspravke
        {
            get
            {
                if (KontoKnjizenja != null)
                {
                    return KontoKnjizenja.KontoIspravke;
                }
                else
                {
                    return "";
                }
               
            }
        }

        public string SintetickiKonto
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


        
    }
}
