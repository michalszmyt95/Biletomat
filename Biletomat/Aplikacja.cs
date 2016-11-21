using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletomat
{
    class Aplikacja
    {
        enum RodzajLegendy { Powitanie, Dzialanie };

        BiletK bK = new BiletK();
        BiletA bA = new BiletA();

        public void WczytajKlawisz()
        {
            Legenda(RodzajLegendy.Powitanie);
                if (Console.ReadKey().Key == ConsoleKey.A)
                    WykonajDzialanie('A');
                if (Console.ReadKey().Key == ConsoleKey.K)
                    WykonajDzialanie('K');
            
        }
        private void WykonajDzialanie(char wybor)
        {
            Legenda(RodzajLegendy.Dzialanie);
                if (Console.ReadKey().Key == ConsoleKey.Z)
                    ZakupBiletu(wybor);
                if (Console.ReadKey().Key == ConsoleKey.X)
                    WczytajKlawisz();
            
        }

        private void ZakupBiletu(char wybor)
        {
            Console.WriteLine("Podaj rodzaj biletu");
            Console.WriteLine("U - Ulgowy");
            Console.WriteLine("N - Normalny");

            Console.WriteLine();
            RodzajBiletu rodzajBiletu = new RodzajBiletu();


                if (Console.ReadKey().Key == ConsoleKey.U)
                    rodzajBiletu = RodzajBiletu.U;
                else if (Console.ReadKey().Key == ConsoleKey.N)
                    rodzajBiletu = RodzajBiletu.N;
            

            if (wybor == 'K')
            {
                double dlugosc;
                Console.WriteLine("Podaj długość trasy. ");
                dlugosc = Double.Parse(Console.ReadLine());
                Console.WriteLine();
                bK.WczytajDlugosc(dlugosc);
                switch (rodzajBiletu)
                {
                    case RodzajBiletu.U: ZapiszDoPliku(wybor, RodzajBiletu.U); Console.WriteLine("Zakupiono kolejowy bilet ulgowy"); break;
                    case RodzajBiletu.N: ZapiszDoPliku(wybor, RodzajBiletu.N); Console.WriteLine("Zakupiono kolejowy bilet normalny"); break;
                }
                WczytajKlawisz();
            }

            if (wybor == 'A')
            {
                switch (rodzajBiletu)
                {
                    case RodzajBiletu.U: ZapiszDoPliku(wybor, RodzajBiletu.U); Console.WriteLine("Zakupiono autobusowy bilet ulgowy"); break;
                    case RodzajBiletu.N: ZapiszDoPliku(wybor, RodzajBiletu.N); Console.WriteLine("Zakupiono autobusowy bilet normalny"); break;
                }
                WczytajKlawisz();
            }
            Console.WriteLine();
        }

        private void Legenda(RodzajLegendy rodzajLegendy)
        {
            if (rodzajLegendy == RodzajLegendy.Powitanie)
            {
                Console.WriteLine("Dzień dobry");
                Console.WriteLine("Określ rodzaj biletu");
                Console.WriteLine("A - autobusowe");
                Console.WriteLine("K - kolejowe");
            }
            else
            {
                Console.WriteLine("Co chcesz zrobić?");
                Console.WriteLine("Z - Zakup biletu");
                Console.WriteLine("X - koniec i powrót do początkowego menu");
            }
            Console.WriteLine();
        }

        int Klicznik = 0;
        int Alicznik = 0;

        private void ZapiszDoPliku(char wybor, RodzajBiletu rodzajBiletu)
        {
            string rodzaj = " ";
            if (rodzajBiletu == RodzajBiletu.U)
                rodzaj = "Ulgowy";
            if (rodzajBiletu == RodzajBiletu.N)
                rodzaj = "Normalny";

            string text = "DDMMYYYYGGMMSS";
            text = DateTime.Now.ToString();

            double cena;

            if (wybor == 'K')
            {
                Klicznik++;
                bK.ObliczCene(rodzajBiletu);
                cena = bK.PodajCene();
                System.IO.File.WriteAllText(@"C:\Users\local\Desktop\mm\Biletomat\Biletomat\K" + Klicznik + ".txt", text + " " + rodzaj + ", cena: " + cena + "zł");
            }
            else if (wybor == 'A')
            {
                Alicznik++;
                bA.ObliczCene(rodzajBiletu);
                cena = bA.PodajCene();
                System.IO.File.WriteAllText(@"C:\Users\local\Desktop\mm\Biletomat\Biletomat\A" + Alicznik + ".txt", text + " " + rodzaj + ", cena: " + cena +"zł");
            }
        }

    }
}
