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
    }
}
