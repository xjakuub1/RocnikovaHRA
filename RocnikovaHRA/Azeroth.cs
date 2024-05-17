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

        public string PubBitka(string zbran)
        {
            Random random = new Random();
            int choice;
            string specialniItem = "";
            int randomCislo;
            

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
                if (zbran == "Kosa")
                {
                    randomCislo = random.Next(1, 4);
                    if (randomCislo <= 3)
                    {
                        Console.Clear();
                        konzole.Kurator();
                        Console.WriteLine("Uhl si úspěšně a rozpáral si ho na kusy, které si vyhodil do kadiboudy");
                        Console.WriteLine("Kurátor: Když si ho porcoval, vypadl z něj kříšťálovéj kámen, tak sis ho vzal.");
                        specialniItem = "Kamen";
                    }
                    else
                    {
                        konzole.Red();
                        Console.WriteLine("Zkusil si no, teď ležíš s mokrou hubou vedle hospody.");
                        PubBitka(zbran);
                    }
                } else if (zbran == "Dyka")
                {
                    randomCislo = random.Next(1, 5);
                    if (randomCislo <= 3)
                    {
                        konzole.Kurator();
                        Console.WriteLine("Uhl si úspěšně a pobodal si ho 43x");
                        Console.WriteLine("Kurátor: Rozhodl ses prohledat ho a našel si u něj krvavej kříšťálovéj kámen, který sis ponechal.");
                        specialniItem = "Kamen";
                    }
                    else
                    {
                        konzole.Red();
                        Console.WriteLine("Zkusil si no, teď ležíš s mokrou hubou vedle hospody.");
                        PubBitka(zbran);
                    }
                } else if (zbran == "Mec")
                {
                    randomCislo = random.Next(1, 6);
                    int missCount = 0;
                    bool pokracovani = false;

                    while(missCount < 3 && !pokracovani)
                    {
                        if (randomCislo <= 3)
                        {
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Uhl si úspěšně a setnul si mu hlavu");
                            Console.WriteLine("Kurátor: Když si mu setnul hlavu, řetízek s kříšťálovým kamenem spadl a vzal sis ho.");
                            specialniItem = "Kamen";
                            pokracovani = true;
                        }
                        else
                        {
                            missCount++;
                            konzole.Red();
                            Console.WriteLine("Zkusil si no, teď ležíš s mokrou hubou vedle hospody.");
                            PubBitka(zbran);
                        }

                        if (missCount == 3)
                        {
                            Console.Clear();
                            konzole.Red();
                            Console.WriteLine("Tak ty se už nebij kamo, umřel si");
                        }
                    }

                } else
                {
                    Console.Clear();
                    konzole.Red();
                    Console.WriteLine("Jak se ti to povedlo???");
                    zbran = "Mec";
                    PubBitka(zbran);
                }
            } else
            {
                Console.Clear();
                konzole.Red();
                Console.WriteLine("Bohužel, jeho ruka není chléb. Zkus to znova");
                PubBitka(zbran);
            }
            return specialniItem;
        }
    }
}