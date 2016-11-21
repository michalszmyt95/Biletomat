using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat
{
    class BiletA : Bilet
    {
        public override void ObliczCene(RodzajBiletu rodzajBiletu)
        {
            if (rodzajBiletu == RodzajBiletu.U)
            {
                this.cena = 1.45;
            }
            else
            {
                this.cena = 2.90;
            }
        }

        public double PodajCene()
        {
            return this.cena;
        }
    }
}
