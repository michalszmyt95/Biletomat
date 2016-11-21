using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat
{
    enum RodzajBiletu { N, U };
    class Program
    {
        static void Main(string[] args)
        {
            Aplikacja apka = new Aplikacja();

            apka.WczytajKlawisz();
        }
    }
}
