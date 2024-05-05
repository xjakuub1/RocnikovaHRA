using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RocnikovaHRA
{
    internal class Azeroth
    {
        Konzole konzole = new Konzole();

        public int Parsovani(int min, int max)
        {
            int cislo = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out cislo);
            } while (cislo < min && cislo > max);
            return cislo;
        }

        public void Intro(string name)
        {
            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Vítej v Azerothu {0} - ve světě kde můžeš potkat svojí zkázu nebo svou spásu.", name);
        }

        public string vyberZbrane()
        {
            string zbran = "";

            konzole.Kurator();
            Console.WriteLine("Kurátor: Pro začátek si vyber svou zbraň:");
            konzole.Reset();
            Console.WriteLine("1) Kosa \n2) Dýka \n3) Hůl ničitele z Numenoru");
            int input = Parsovani(1, 3);

            if (input == 1)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Vybral sis Kosu, byl si požehnán darem samého Hadese");
                zbran = "Kosa";
            }
            else if (input == 2)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Vybral sis Dýku, pro začátečníka jak dělané");
                zbran = "Dyka";
            }
            else if (input == 3)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Vybral sis Hůl ničitele z Numenoru, která je zlomená takže dostáváš Meč");
                zbran = "Mec";
            }
            else
            {
                Console.Clear();
                konzole.Red();
                Console.WriteLine("Bez zbraně nemůžeš pokračovat");
                vyberZbrane();
            }
            return zbran;
        }

        public int Pub()
        {
            int choice;

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Jelikož ses probudil z neznámého delíria, rozhodl ses, že zajdeš do hostince, který je hned vedle tebe");
            konzole.Pokracuj();

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Vešel si do dveří a narazil do tebe nějaký pardál.");
            konzole.DarkCyan();
            Console.WriteLine("Pardál: Máš nějakéj problém ty močále?");
            konzole.Kurator();
            Console.WriteLine("Kurátor: Teď máš na výběr:");
            konzole.Reset();
            Console.WriteLine("1) Vyzvat ho k boji \n2) Omluvit se a pokračovat do hostince");
            choice = Parsovani(1, 2);

            return choice;
        }

        public void PubBezKonfrontace()
        {
            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Ty: Neˇ, promiň že jsem se tě dotkl");
            konzole.DarkCyan();
            Console.WriteLine("Pardál: Tak si dávej příště sakra velkej pozor");
            konzole.Kurator();
            Console.WriteLine("Kurátor: Pardál te pustil a nic se nestalo");
            konzole.Reset();
        }

        public string PubBitka()
        {
            int choice;
            string specialniItem = "";

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Ty: Jo mám, pojď ven ty smraďochu.");
            konzole.DarkCyan();
            Console.WriteLine("Pardál: Tak teď si mě vážně naštval");
            konzole.Kurator();
            Console.WriteLine("Kurátor: Pardál ti chce vypálit bombu, můžeš zkusit uhnout nebo tu ránu sníst");
            konzole.Reset();
            Console.WriteLine("1) Zkusit uhnout \n2) Sníst ránu");
            choice = Parsovani(1, 2);
            if (choice == 1)
            {
                Random random = new Random();
                int randomCislo = random.Next(1, 5);
                if (randomCislo <= 3)
                {
                    Console.Clear();
                    konzole.Kurator();
                    Console.WriteLine("Uhl si úspěšně a vypálil pardálovi hák, který ho poslal spát do hájenky hned vedle");
                    Console.WriteLine("Kurátor: Rozhodl ses prohledat ho a našel si u něj kříšťálovéj kámen.");
                    specialniItem = "Kamen";
                }
                else
                {
                    Console.Clear();
                    konzole.Red();
                    Console.WriteLine("Zkusil si no, teď ležíš s mokrou hubou vedle hospody.");
                    PubBitka();
                }
            } else
            {
                Console.Clear();
                konzole.Red();
                Console.WriteLine("Bohužel, jeho ruka není chléb. Zkus to znova");
                PubBitka();
            }
            return specialniItem;
        }
    }
}