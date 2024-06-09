using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RocnikovaHRA
{
    internal class Azeroth
    {
        Konzole konzole = new Konzole();
        Enemy zombie = new Enemy();

        public int Parsovani(int min, int max)
        {
            int cislo = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out cislo);
            } while (cislo < min || cislo > max);
            return cislo;
        }

        public static bool KeyPress(int milsek)
        {
            bool passed = false;
            Timer timer = null;
            ManualResetEventSlim timeHandle = new ManualResetEventSlim(false);

            Console.WriteLine($"Máš {milsek / 1000} sekund, aby si stiskl nějaké tlačítko");

            timer = new Timer((state) =>
            {
                if (!passed)
                {
                    Console.WriteLine("\nNestihl si to");
                    timeHandle.Set();
                }
            }, null, milsek, Timeout.Infinite);

            while (!timeHandle.IsSet)
            {
                if (Console.KeyAvailable)
                {
                    passed = true;
                    Console.ReadKey(true);
                    timer.Dispose();
                    timeHandle.Set();
                    break;
                }

                Thread.Sleep(100);
            }

            timer.Dispose();
            return passed;
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
            if (choice > 2 || choice < 1)
            {
                konzole.Red();
                Console.WriteLine("Musíš si vybrat.. jinak to nejde");
                konzole.Reset();
                Pub();
            }
            return choice;
        }

        public void PubBezKonfrontace()
        {
            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Ty: Ne, promiň že jsem se tě dotkl");
            konzole.DarkCyan();
            Console.WriteLine("Pardál: Tak si dávej příště sakra velkej pozor");
            konzole.Kurator();
            Console.WriteLine("Kurátor: Pardál te pustil a nic se nestalo");
            konzole.Reset();
        }

        public string PubBitka(string zbran)
        {
            int choice;
            string specialniItem = "";
            int randomCislo;
            int missCount = 0;
            Random rnd = new Random();

            do
            {
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
                        randomCislo = rnd.Next(1, 4);
                        if (randomCislo <= 3)
                        {
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Uhl si úspěšně a rozpáral si ho na kusy, které si vyhodil do kadiboudy");
                            Console.WriteLine("Kurátor: Když si ho porcoval, vypadl z něj kříšťálovéj kámen, tak sis ho vzal.");
                            specialniItem = "Kamen";
                            break;
                        }
                        else
                        {
                            missCount++;
                        }
                    }
                    else if (zbran == "Dyka")
                    {
                        randomCislo = rnd.Next(1, 5);
                        if (randomCislo <= 3)
                        {
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Uhl si úspěšně a pobodal si ho 43x");
                            Console.WriteLine("Kurátor: Rozhodl ses prohledat ho a našel si u něj krvavej kříšťálovéj kámen, který sis ponechal.");
                            specialniItem = "Kamen";
                            break;
                        }
                        else
                        {
                            missCount++;
                        }
                    }
                    else if (zbran == "Mec")
                    {  
                        randomCislo = rnd.Next(1, 6);
                        if (randomCislo <= 2)
                        {
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Uhl si úspěšně a setnul jsi mu hlavu");
                            Console.WriteLine("Kurátor: Okolo krku měl náhrdelník s kříšťálovým kamenem, který sis ponechal.");
                            specialniItem = "Kamen";
                            break;
                        }
                        else
                        {
                            missCount++;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        konzole.Red();
                        Console.WriteLine("Jak se ti to povedlo???");
                        zbran = "Mec";
                    }
                }
                else
                {
                    Console.Clear();
                    konzole.Red();
                    Console.WriteLine("Bohužel, jeho ruka není chléb. Zkus to znova");
                }

                if (missCount == 3)
                {
                    konzole.Red();
                    Console.WriteLine("Měl si 3 pokusy a stejne si to nedal\nKončís!");
                    specialniItem = "Nic";
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
                }

            } while (missCount < 3);

            return specialniItem;
        }

        public void PubUvnitr()
        {
            int choice;

            konzole.Pokracuj();
            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: V hospodě si šel k baru");
            Console.WriteLine("Kurátor: Máš na výběr:");
            konzole.Reset();
            Console.WriteLine("1) Pozdravit barmanku \n2) Vytřít s ní podlahu");
            choice = Parsovani(1, 2);

            if (choice == 1)
            {
                Console.Clear();
                konzole.Reset();
                Console.WriteLine("Ty: Čau čaje, co tu máš za pití");
                konzole.DarkCyan();
                Console.WriteLine("Barmanka: Nejsem čaje ale Marika. Máme tady jupíka, Capri Sun a limošku");
                konzole.Reset();
                Console.WriteLine("Ty: Takže žádnej chlast?");
                konzole.DarkCyan();
                Console.WriteLine("Barmanka: Nuh uh. Mám tady ale jinou nabídku.");
                Console.WriteLine("Barmanka: Jestli si zajdeš pro barel s pivem, tak ti to mile ráda načepuju.");
                konzole.Reset();
                Console.WriteLine("Ty: To zní lákavě, ale kde je háček?");
                konzole.DarkCyan();
                Console.WriteLine("Barmanka: Po cestě potkáš asi hodně nestvůr, jelikož se v noci probouzejí");
                konzole.Reset();
                Console.WriteLine("Ty: To není žáden problém, jednu jsem už potkal");
                Console.WriteLine("Ty: Ale kde je vubec ten barel?");
                konzole.DarkCyan();
                Console.WriteLine("Barmanka: Půjdeš nahoru ke kostelu, je to celkem štreka. Ale až budeš blízko piva, poznáš to");
                konzole.Kurator();
                Console.WriteLine("Kurátor: A tak ses vydal na cestu");
                konzole.Pokracuj();
            } else if (choice == 2)
            {
                Console.Clear();
                konzole.Reset();
                Console.WriteLine("Vyběhl si po židli a chystal ses skákat na barmanku a ona rázem vytáhla kvér.");
                konzole.DarkCyan();
                Console.WriteLine("Barmanka: Lol co si myslel.");
                konzole.Red();
                Console.WriteLine("Skončil si");
                PubUvnitr();
            } else
            {
                Console.Clear();
                konzole.Red();
                Console.WriteLine("Prosím vyber si číslo 1 nebo 2. :)");
                PubUvnitr();
            }
        }

        public int Mise1(int sila, int zivoty, int zivotyZombie)
        {
            int choice;

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Slyšel si jasně, musíš po cestě ke kostelu");
            Console.WriteLine("Kurátor: Takže pokračuj.");
            konzole.Reset();
            konzole.Pokracuj();

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Máme tady prvních pár prašivců, vypadájí jako zombie; nebo jsou možná na piku");
            konzole.DarkCyan();
            Console.WriteLine("Zombie: Vawadhshahh!!!");
            konzole.Kurator();
            Console.WriteLine("Kurátor: Co chceš podniknout?");
            konzole.Reset();
            Console.WriteLine("1) Zkusit se proplížit\n2) Zaůtočit");
            choice = Parsovani(1, 2);
            if (choice == 1)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Dobře, tohle bude težké.");
                Console.WriteLine("Kurátor: Musíš se strefit ve správný čas, jinak si tě zombie všimnou");
                konzole.Reset();
                konzole.Pokracuj();
                bool passed = KeyPress(6000);
                if  (passed == false)
                {
                    Console.Clear();
                    konzole.Red();
                    Console.WriteLine("Zombie si tě všiml a upozornil celou hordu, která tě zabila");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    konzole.Kurator();
                    Console.WriteLine("Kurátor: Povedlo se ti to! Prvního máš za sebou");
                    konzole.Reset();
                    konzole.Pokracuj();

                    Console.Clear();
                    konzole.Kurator();
                    Console.WriteLine("Dobře, teď musíš kolem toho druhého, ale bacha občas se podívá i za sebe");
                    konzole.Reset();
                    konzole.Pokracuj();
                    passed = KeyPress(3000);
                    if (passed == false)
                    {
                        Console.Clear();
                        konzole.Red();
                        Console.WriteLine("Zombie se otočil, všiml si tě a upozornil celou hordu, která tě zabila");
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        konzole.Kurator();
                        Console.WriteLine("Kurátor: Dobře ty, za tohodle se nikdo jěště nedostal");
                        konzole.Reset();
                        konzole.Pokracuj();

                        Console.Clear();
                        konzole.Kurator();
                        Console.WriteLine("Kurátor: Tak, a teď ten poslední. Dávej si ULTRA velký pozor, máš jen jednu šanci");
                        Console.WriteLine("Kurátor: Tenhle jen sedí a jednou za čas se rozhlídne jinam. Takže se připrav.");
                        konzole.Reset();
                        konzole.Pokracuj();
                        passed = KeyPress(1000);
                        if (passed == false)
                        {
                            Console.Clear();
                            konzole.Red();
                            Console.WriteLine("Man you dead");
                            Console.ReadKey(true);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Kurátor: Skvěle! To bylo o fous. Vzpamatuj se a pokračujem");
                            konzole.Reset();
                            konzole.Pokracuj();
                        }
                    }
                }
            }
            else if (choice == 2)
            {
                    Console.Clear();
                    zivoty = Mise1Boje(sila, zivoty, zivotyZombie);
            }
            return zivoty;
        }

        public int Mise1Boje(int sila, int zivoty, int zivotyZombie)
        {
            bool superAttackPouzit = false;
            bool konec = false;

            do
            {
                bool jeNazivu = true;

                while (zivotyZombie > 0 && zivoty > 0)
                {
                    Console.Clear();
                    konzole.Kurator();
                    Console.WriteLine("Kurátor: Ok, tenhle bude lehkéj, takže se tak nemusíš bát");
                    Console.WriteLine("Kurátor: To neznamení že ti ale nemůže nic udělat");
                    konzole.Reset();
                    Console.WriteLine("Přistupuješ blíž k zombíkovi");
                    konzole.Pokracuj();

                    Console.Clear();
                    konzole.Reset();
                    Console.WriteLine("Tvoje síla: {0}", sila);
                    Console.WriteLine("Tvoje životy: {0}", zivoty);
                    Console.WriteLine("Životy zombíka: {0}", zivotyZombie);
                    konzole.Kurator();
                    Console.WriteLine("Kurátor: Jak na něj chceš zaútočit?");
                    konzole.Reset();

                    if (superAttackPouzit)
                    {
                        Console.WriteLine("1) Klasický útok");
                    }
                    else
                    {
                        Console.WriteLine("1) Klasický útok\n2) Super útok");
                    }

                    int choice2 = superAttackPouzit ? Parsovani(1, 1) : Parsovani(1, 2);

                    if (choice2 == 1)
                    {
                        // Classic attack
                        Console.Clear();
                        konzole.Kurator();
                        Console.WriteLine("Rozběhl ses a rozhodl že na něj zaůtočíš klasickým útokem");
                        zivotyZombie = zombie.basicUtok(sila, zivotyZombie);
                    }
                    else if (choice2 == 2 && !superAttackPouzit)
                    {
                        // Super attack
                        Console.Clear();
                        konzole.Kurator();
                        Console.WriteLine("Rozběhl ses a rozhodl že na něj zaůtočíš SUPER útokem!");
                        zivotyZombie = zombie.superUtok(sila, zivotyZombie);
                        superAttackPouzit = true;
                    }

                    if (zivotyZombie > 0)
                    {
                        zivoty -= 10;
                        konzole.Red();
                        Console.WriteLine("Zombie na tebe zautočil a vzal ti 10 HP");
                        if (zivoty <= 0)
                        {
                            Console.Clear();
                            konzole.Red();
                            Console.WriteLine("Umřel si, smolík");
                            Console.ReadKey(true);
                            Environment.Exit(0);
                            jeNazivu = false;
                            break;
                        }
                    }
                }

                if (jeNazivu && zivotyZombie <= 0)
                {
                    Console.Clear();
                    konzole.Kurator();
                    Console.WriteLine("Kurátor: Skvěle, vidíš že ten první nebyl tak těžký");
                    Console.WriteLine("Kurátor: Ten druhý bude o něco horší, musíš takticky");
                    Console.WriteLine("Kurátor: Nezapomeň že na tebe čeká jěště jeden");
                    konzole.Reset();
                    Console.WriteLine("Přistupuješ blíž k zombíkovi");
                    konzole.Pokracuj();

                    zivotyZombie = 30;
                    while (zivotyZombie > 0 && zivoty > 0)
                    {
                        Console.Clear();
                        konzole.Reset();
                        Console.WriteLine("Tvoje síla: {0}", sila);
                        Console.WriteLine("Tvoje životy: {0}", zivoty);
                        Console.WriteLine("Životy zombíka: {0}", zivotyZombie);
                        konzole.Kurator();
                        Console.WriteLine("Kurátor: Jak na něj chceš zaútočit?");
                        konzole.Reset();

                        if (superAttackPouzit)
                        {
                            Console.WriteLine("1) Klasický útok");
                        }
                        else
                        {
                            Console.WriteLine("1) Klasický útok\n2) Super útok");
                        }

                        int choice2 = superAttackPouzit ? Parsovani(1, 1) : Parsovani(1, 2);

                        if (choice2 == 1)
                        {
                            // Classic attack
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Rozběhl ses a rozhodl že na něj zaůtočíš klasickým útokem");
                            zivotyZombie = zombie.basicUtok(sila, zivotyZombie);
                        }
                        else if (choice2 == 2 && !superAttackPouzit)
                        {
                            // Super attack
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Rozběhl ses a rozhodl že na něj zaůtočíš SUPER útokem!");
                            zivotyZombie = zombie.superUtok(sila, zivotyZombie);
                            superAttackPouzit = true;
                        }

                        if (zivotyZombie > 0)
                        {
                            zivoty -= 15;
                            konzole.Red();
                            Console.WriteLine("Zombie na tebe zautočil a vzal ti 10 HP");
                            if (zivoty <= 0)
                            {
                                Console.Clear();
                                konzole.Red();
                                Console.WriteLine("Umřel si, smolík");
                                Console.ReadKey(true);
                                Environment.Exit(0);
                                jeNazivu = false;
                                break;
                            }
                        }
                    }

                    if (jeNazivu && zivotyZombie <= 0)
                    {
                        Console.Clear();
                        konzole.Kurator();
                        Console.WriteLine("Kurátor: WOW, seš dobrý, ale postačíě na tohodle?");
                        Console.WriteLine("Kurátor: Má více životů a více síly");
                        Console.WriteLine("Kurátor: Tady bych šel na jistotu");
                        konzole.Reset();
                        Console.WriteLine("Přistupuješ blíž k zombíkovi");
                        konzole.Pokracuj();

                        zivotyZombie = 45;
                        while (zivotyZombie > 0 && zivoty > 0)
                        {
                            Console.Clear();
                            konzole.Reset();
                            Console.WriteLine("Tvoje síla: {0}", sila);
                            Console.WriteLine("Tvoje životy: {0}", zivoty);
                            Console.WriteLine("Životy třetího zombíka: {0}", zivotyZombie);
                            konzole.Kurator();
                            Console.WriteLine("Kurátor: Jak na něj chceš zaútočit?");
                            konzole.Reset();

                            if (superAttackPouzit)
                            {
                                Console.WriteLine("1) Klasický útok");
                            }
                            else
                            {
                                Console.WriteLine("1) Klasický útok\n2) Super útok");
                            }

                            int choice2 = superAttackPouzit ? Parsovani(1, 1) : Parsovani(1, 2);

                            if (choice2 == 1)
                            {
                                // Classic attack
                                Console.Clear();
                                konzole.Kurator();
                                Console.WriteLine("Rozběhl ses a rozhodl že na něj zaůtočíš klasickým útokem");
                                zivotyZombie = zombie.basicUtok(sila, zivotyZombie);
                            }
                            else if (choice2 == 2 && !superAttackPouzit)
                            {
                                // Super attack
                                Console.Clear();
                                konzole.Kurator();
                                Console.WriteLine("Rozběhl ses a rozhodl že na něj zaůtočíš SUPER útokem!");
                                zivotyZombie = zombie.superUtok(sila, zivotyZombie);
                                superAttackPouzit = true;
                            }

                            if (zivotyZombie > 0)
                            {
                                zivoty -= 25;
                                konzole.Red();
                                Console.WriteLine("Zombie na tebe zautočil a vzal ti 10 HP");
                                if (zivoty <= 0)
                                {
                                    Console.Clear();
                                    konzole.Red();
                                    Console.WriteLine("Umřel si, smolík");
                                    Console.ReadKey(true);
                                    Environment.Exit(0);
                                    jeNazivu = false;
                                    break;
                                }
                            }
                        }

                        if (jeNazivu && zivotyZombie <= 0)
                        {
                            Console.Clear();
                            konzole.Kurator();
                            Console.WriteLine("Kurátor: Skvělé zabil si posledního zombíka!");
                            Console.WriteLine("Doufej že už žádné nepotkáme");
                            konec = true;
                        }
                    }
                }

            } while (zivoty > 0 && !konec);

            if (konec == true)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Skvělé zabil si posledního zombíka!");
                Console.WriteLine("Kurátor: Doufej že už žádné nepotkáme");
            }
            else
            {
                Console.Clear();
                konzole.Red();
                Console.WriteLine("Prohrál si, už se nevracej");
            }
            return zivoty;
        }

        public string Kompadre()
        {
            string pomocnik = "Ne";
            int choice;

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Podařilo se ti to na výbornou, máš u mě respekt");
            Console.WriteLine("Teď se ale vydáme dál");
            konzole.Pokracuj();

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Cestou si to takhle štráduješ, a najednou někoho vidíš");
            konzole.Reset();
            Console.WriteLine("1) Obejít ho\n2) Zajít za ním");
            choice = Parsovani(1, 2);
            if (choice == 1)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Rozhodl ses, že tě nezajímá a pokračoval si v cestě");
            }
            else
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Rozhodl ses, že ho oslovíš");
                Console.WriteLine("Ty: Co tady děláš ty magore?");
                konzole.DarkCyan();
                Console.WriteLine("Bloudník: T-To je na mě?");
                konzole.Kurator();
                Console.WriteLine("Ty: Si piš");
                konzole.DarkCyan();
                Console.WriteLine("Bloudník: Uvízl jsem tady, když jsem běžel před těma fetkama");
                konzole.Kurator();
                Console.WriteLine("Takže to byly fetky - pomyslel sis");
                Console.WriteLine("Ty: Počkej pomůžu ti.");
                konzole.DarkCyan();
                Console.WriteLine("Bloudník: To bys moh, ale ten kámen je fakt težkej");
                konzole.Pokracuj();

                pomocnik = KompadreMise();
                if (pomocnik == "Ano")
                {
                    Console.Clear();
                    konzole.DarkCyan();
                    Console.WriteLine("Bloudník: Díky moc, jsem ti moc vděčný");
                    konzole.Kurator();
                    Console.WriteLine("Ty: Jasně, žáden problém. Jak se vůbec jmenuješ?");
                    konzole.DarkCyan();
                    Console.WriteLine("Bloudník: Danny DeVito, těší mě. Jak se ti mohu zavděčit?");
                    konzole.Kurator();
                    Console.WriteLine("Ty: Můžeě jít semnou pro basu piva, ale je u ní asi nějaký BOSS všech feťáků.");
                    Console.WriteLine("Ty: Pak ji můžem vypít.");
                    konzole.DarkCyan();
                    Console.WriteLine("Denny: To zní dobře, mám pár triků v rukávu na toho bosse.");
                }
                else
                {
                    Console.Clear();
                    konzole.Kurator();
                    Console.WriteLine("Kurátor: Nechal si ho tam ležet ani si mu neřekl čau");
                }
            }

            return pomocnik;
        }

        public string KompadreMise()
        {
            string vysvobodil = "Ne";
            int keyPressHandle = 0;

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Aby jsi pomohl bloudníkovi, musíš ho vysvobodit z kamene");
            konzole.Reset();
            Console.WriteLine("Zmáčkni 10x jakékoliv tlačítko");

            while (keyPressHandle < 10)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                keyPressHandle++;
                Console.WriteLine("Zmáčkl si: {0}x", keyPressHandle);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    konzole.Red();
                    Console.WriteLine("Tak se měj");
                    Console.ReadKey(true);
                    Environment.Exit(0);                
                }
            }

            if (keyPressHandle == 10)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Supr, podařilo se ti ho vysvobodit!");
                vysvobodil = "Ano";
            }

            return vysvobodil;
        }

        public void BossFight(int sila, string pomocnik, int zivoty, int pomocnikZivoty, string specialniItem)
        {
            int bossZivoty = 200;
            bool superAttackPouzit = false;
            bool specialniItemPouzit = false;

            bool healPouzit = false;
            bool damagePouzit = false;
            bool magPouzit = false;

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Po 2 hodinách cesty jste se konečně dostali ku branám kostela");
            Console.WriteLine("Kurátor: Vypadal prázdně a brány byly otevřené");
            konzole.Pokracuj();

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Vešli jste do areálu, všude bylo podezřelé ticho");
            Console.WriteLine("Pokračovali jste dál a vešli jste do kostela");
            konzole.Red();
            Console.WriteLine("Grunt: Co je to tady za smrad");
            konzole.Kurator();
            Console.WriteLine("Kurátor: To je ten hajzl! Pusťte se do něho!");
            konzole.Pokracuj();

            while (bossZivoty > 0 && zivoty > 0)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Tvoje síla: {0}", sila);
                Console.WriteLine("Tvoje životy: {0} HP", zivoty);
                Console.WriteLine("Životy pomocníka: {0} HP", pomocnikZivoty);
                konzole.Red();
                Console.WriteLine("Životy Grunta: {0} HP", bossZivoty);
                konzole.Reset();
                Console.WriteLine("Vyber si útok:");

                if (superAttackPouzit)
                {
                    Console.WriteLine("1) Klasický útok");
                }
                else
                {
                    Console.WriteLine("1) Klasický útok\n2) Super útok");
                }

                Console.WriteLine("3) Pomocník");

                if (!specialniItemPouzit && specialniItem == "Kamen")
                {
                    Console.WriteLine("4) Použít speciální item");
                }


                int maxParse = !specialniItemPouzit && specialniItem == "Kamen" ? 4 : 3;
                int choice = Parsovani(1, maxParse);

                switch (choice)
                {
                    case 1:
                        // Classic attack
                        bossZivoty -= sila;
                        break;

                    case 2:
                        if (!superAttackPouzit)
                        {
                            // Super attack
                            bossZivoty -= sila * 2;
                            superAttackPouzit = true;
                        }
                        else
                        {
                            Console.WriteLine("Super útok už byl použitý");
                            zivoty += 15;
                            pomocnikZivoty += 15;
                            Console.ReadKey(true);
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Vyber útok pomocníka:");
                        Console.WriteLine("1) Heal (Vyléčení)");
                        Console.WriteLine("2) Extra Damage (Extra poškození)");
                        Console.WriteLine("3) Special Spell (Speciální kouzlo)");

                        int pomocnikChoice = Parsovani(1, 3);

                        switch (pomocnikChoice)
                        {
                            case 1:
                                if (healPouzit == true && pomocnik == "Ano")
                                {
                                    Console.WriteLine("Danny už tenhle spell použil ty hlupáku!");
                                    zivoty += 15;
                                    pomocnikZivoty += 15;
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    zivoty += 30;
                                    pomocnikZivoty += 15;
                                    Console.WriteLine("Danny tě vyléčil o 30 životů!");
                                    healPouzit = true;
                                }
                                break;

                            case 2:
                                if (damagePouzit == true && pomocnik == "Ano")
                                {
                                    Console.WriteLine("Danny už tenhle spell použil ty hlupáku!");
                                    zivoty += 15;
                                    pomocnikZivoty += 15;
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    bossZivoty -= sila + 20;
                                    Console.WriteLine("Danny způsobil Gruntovi extra damage");
                                    damagePouzit = true;
                                }
                                break;

                            case 3:
                                if (magPouzit == true && pomocnik == "Ano")
                                {
                                    Console.WriteLine("Danny už tenhle spell použil ty hlupáku!");
                                    zivoty += 15;
                                    pomocnikZivoty += 15;
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    bossZivoty -= sila;
                                    zivoty += 10;
                                    Console.WriteLine("Danny podělal Grunta o love a o čaje a vyhealil tě. Taky mu dal facku");
                                    magPouzit = true;
                                }
                                break;
                        }
                        break;

                    case 4:
                        if (!specialniItemPouzit && specialniItem == "Kamen")
                        {
                            bossZivoty -= sila * 3;
                            zivoty += 50;
                            pomocnikZivoty += 50;
                            Console.WriteLine("Nastřelil sis svuj křištálový kámen a teď je z tebe pokřivenéj perníkovej potomek");
                            Console.WriteLine("Máš síly na dva dny a dostal si heal");
                            specialniItemPouzit = true;
                        }
                        break;
                }

                if (bossZivoty > 0)
                {
                    Console.WriteLine("Grunt útočí!");
                    zivoty -= 15;
                    pomocnikZivoty -= 15;
                    if (zivoty <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Umřel jsi. Geňo over");
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    } else if (pomocnikZivoty <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Tvůj pomocník umřel");
                    }
                }
            }

            if (bossZivoty <= 0)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: LETS GOOO! Zabili jste Grunta!");
                konzole.Pokracuj();

                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Šli jste do sklepa kde bylo několik sudů piva.");
                Console.WriteLine("Ty: Tohle je boží požehnání");
                Console.WriteLine("Kurátor: Vrátili jste se do hospody se sudy");
                konzole.DarkCyan();
                Console.WriteLine("Marika: Tak ses vrátil! A vyšlo ti to a dokonce máš i amíga");
                Console.WriteLine("Marika: Abych řekla pravdu, myslela jsem si že to nedáš, ale jsi statečný");
                konzole.Pokracuj();

                Console.Clear();
                Console.WriteLine("Odešel si s Marikou do pokoje a zbytek je historie");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
        }

        public void BossFightBezPomocnika(int sila, int zivoty, string specialniItem)
        {
            int bossZivoty = 200;
            bool specialniItemPouzit = false;
            int superAttackCount = 0;

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Po 2 hodinách cesty ses konečně dostal ku branám kostela");
            Console.WriteLine("Kurátor: Vypadal prázdně a brány byly otevřené");
            konzole.Pokracuj();

            Console.Clear();
            konzole.Kurator();
            Console.WriteLine("Kurátor: Vešel si do areálu, všude bylo podezřelé ticho");
            Console.WriteLine("Pokračoval si dál a vešel si do kostela");
            konzole.Red();
            Console.WriteLine("Grunt: Co je to tady za smrad");
            konzole.Kurator();
            Console.WriteLine("Kurátor: To je ten hajzl! Postarej se o něho!");
            konzole.Pokracuj();

            while (bossZivoty > 0 && zivoty > 0)
            {
                Console.Clear();
                Console.WriteLine("Tvoje síla: {0}", sila);
                Console.WriteLine("Tvoje životy: {0} HP", zivoty);
                Console.WriteLine("Životy bosse: {0} HP", bossZivoty);
                Console.WriteLine("Vyber si útok:");

                if (superAttackCount < 2)
                {
                    Console.WriteLine("1) Klasický útok\n2) Super útok");
                }
                else
                {
                    Console.WriteLine("1) Klasický útok");
                }

                if (!specialniItemPouzit && specialniItem == "Kamen")
                {
                    Console.WriteLine("3) Použít speciální item");
                }

                int maxParse = !specialniItemPouzit && specialniItem == "Kamen" ? 3 : 2;
                int choice = Parsovani(1, maxParse);

                switch (choice)
                {
                    case 1:
                        // Classic attack
                        bossZivoty -= sila;
                        break;

                    case 2:
                        if (superAttackCount < 2)
                        {
                            // Super attack
                            bossZivoty -= sila * 2;
                            superAttackCount++;
                            zivoty += 25;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Super útok nemůžeš použít víc jak 2x");
                            Console.ReadKey(true);
                        }
                        break;

                    case 3:
                        if (!specialniItemPouzit && specialniItem == "Kamen")
                        {
                            bossZivoty -= sila * 3;
                            zivoty += 50;
                            Console.WriteLine("Nastřelil sis svuj křištálový kámen a teď je z tebe pokřivenéj perníkovej potomek");
                            Console.WriteLine("Máš síly na dva dny a dostal si heal");
                            specialniItemPouzit = true;
                        }
                        break;
                }

                if (bossZivoty > 0)
                {
                    Console.WriteLine("Grunt útočí!");
                    zivoty -= 25;
                    if (zivoty <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Umřel jsi, smraďochu");
                        Console.ReadKey(true);
                        Environment.Exit(0);
                    }
                }
            }
            if (bossZivoty <= 0)
            {
                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: LETS GOOO! Zabil si Grunta!");
                konzole.Pokracuj();

                Console.Clear();
                konzole.Kurator();
                Console.WriteLine("Kurátor: Šel si do sklepa kde bylo několik sudů piva.");
                Console.WriteLine("Ty: Tohle je boží požehnání");
                Console.WriteLine("Ty: Jeden vypiju tady, 2 si vezmu na ramena a jdu zpátky hjahahah");
                konzole.Red();
                Console.WriteLine("Něco te najednou probodne zezadu, když piješ ze sudu");
                konzole.DarkCyan();
                Console.WriteLine("Bloudník: Hele hele kampak. Karty se nějak obrátily");
                Console.WriteLine("Bloudník: Nojo, měl si mi pomoct - teď si za to zaplatil");
                konzole.Pokracuj();

                Console.Clear();
                konzole.Red();
                Console.WriteLine("Bloudník odešel se sudy a tebe nikdo nikdy nenašel");
                Console.WriteLine("Marika si řekla že ses na to vybod a zrhl si jako srab");
                Console.WriteLine("HOLT, CHLAST NENÍ VŠE");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
        }
    }
}