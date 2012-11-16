using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podaci
{
    public class NalogGk
    {
        public string BrojNaloga { get; set; }
        public DateTime DatumNaloga { get; set; }
        public string OpisNaloga { get; set; }
        public string VrstaNaloga { get; set; }

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

        public string OpisVrsteNaloga
        {
            get
            {
                switch (VrstaNaloga)
                {
                    case "D":
                        return "Početno stanje";
                        break;
                    case "N":
                        return "Tekući promet";
                        break;
                    case "3":
                    case "5":
                        return "Zatvaranje klase 5";
                        break;
                    case "6":
                        return "Zatvaranje klase 6";
                        break;
                    default:
                        return "Tekući promet";
                        break;
                }
            }
        }
    }
}
