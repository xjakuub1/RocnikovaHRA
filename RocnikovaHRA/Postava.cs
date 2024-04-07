using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocnikovaHRA
{
    internal class Postava
    {
        public string name = "Jmeno";
        public string zbran = "";
        public int sila;

        PraceSeSouborem soubor = new PraceSeSouborem();
        Konzole konzole = new Konzole();

        public int Parsovani()
        {
            int cislo = 0;
            while (!int.TryParse(Console.ReadLine(), out cislo))
            {
                Console.WriteLine("Musíte zadat číslo!");
            }
            return cislo;
        }

        public int Parsovani(int min)
        {
            int cislo = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out cislo);
            } while (cislo < min);
            return cislo;
        }

        public int Parsovani(int min, int max)
        {
            int cislo = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out cislo);
            } while (cislo < min && cislo > max);
            return cislo;
        }

        public string pojmenujPostavu()
        {
            Console.WriteLine("1) Pojmenuj svou postavu");
            Console.WriteLine("2) Pojmenuj svou postavu náhodně");
            int input = Parsovani(1, 2);

            if (input == 1)
            {
                Console.Clear();
                Console.WriteLine("Zadejte jméno postavy: ");
                name = Console.ReadLine();
            }
            else if (input == 2)
            {
                Random random = new Random();
                string[] jmena = soubor.NacteniVet("randomjmena");
                int randomCislo = random.Next(0, jmena.Length);
                name = jmena[randomCislo];
            } else
            {
                Console.Clear();
                Console.WriteLine("Zadejte prosím čislo 1 nebo 2");
                pojmenujPostavu();
            }

            return name;
        }

        public int Sila(string zbran)
        {
            switch (zbran)
            {
                case "Kosa":
                    sila = 30;
                    Console.WriteLine("Vybral sis dobře, tvá zbraň má sílů 30. romálů");
                    break;
                case "Dyka":
                    sila = 25;
                    konzole.Reset();
                    Console.WriteLine("Tvá volba není vůbec špatná - máš sílu 25. romálů");
                    break;
                case "Mec":
                    sila = 15;
                    konzole.Red();
                    Console.WriteLine("Dostal si podel, máš sílu jen 15. romálů");
                    break;

            }

            /*if (zbran == "Kosa")
            {
                sila = 30;
                Console.WriteLine("Tvá síla je 30");
            } else if (zbran == "Dyka")
            {
                sila = 25;
                Console.WriteLine("Tvá síla je 25");
            }
            else
            {
                sila = 15;
                Console.WriteLine("Tvá síla je 15");
            }*/

            return sila;
        }
    }
}
