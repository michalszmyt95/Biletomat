using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat
{
    class BiletK : Bilet
    {
        double dlugoscTrasy;
        public override void ObliczCene(RodzajBiletu rodzajBiletu)
        {
            if (rodzajBiletu == RodzajBiletu.U)
            {
                if (dlugoscTrasy <= 100)
                    this.cena = Math.Round(dlugoscTrasy * 1.04 / 2,2);
                else
                    this.cena = Math.Round(dlugoscTrasy * 0.73 / 2, 2);
            }
            else
            {
                if (dlugoscTrasy <= 100)
                    this.cena = Math.Round(dlugoscTrasy * 1.04, 2);
                else
                    this.cena = Math.Round(dlugoscTrasy * 0.73, 2);
            }
        }
        public double PodajCene()
        {
            return this.cena;
        }
        public void WczytajDlugosc(double dl)
        {
            this.dlugoscTrasy = dl;
        }
    }
}
