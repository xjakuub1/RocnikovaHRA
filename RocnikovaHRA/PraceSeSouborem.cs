using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocnikovaHRA
{
    internal class PraceSeSouborem
    {
        public string[] NacteniVet(string NazevSouboru)
        {
            string[] NacteneJmena = new string[10];
            int i = 0;
            using (StreamReader sr = new StreamReader(@NazevSouboru + ".txt"))

            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    NacteneJmena[i] = s;
                    i++;
                }

            }
            return NacteneJmena;
        }


        public int ZapisBodu(int score, string jmeno, int zivoty)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.WriteLine(jmeno);
                sw.WriteLine(zivoty);
                sw.Flush();
            }

            return score;
        }

        public int ZapisBodu(int score, string jmeno, int zivoty, string zbran)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.WriteLine(jmeno);
                sw.WriteLine(zivoty);
                sw.WriteLine(zbran);
                sw.Flush();
            }

            return score;
        }

        public int ZapisBodu(int score, string jmeno, int zivoty, string zbran, string specialniItem)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.WriteLine(jmeno);
                sw.WriteLine(zivoty);
                sw.WriteLine(zbran);
                sw.WriteLine(specialniItem);
                sw.Flush();
            }

            return score;
        }

        public int ZapisBodu(int score, string jmeno, int zivoty, string zbran, string specialniItem, string pomocnik)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.WriteLine(jmeno);
                sw.WriteLine(zivoty);
                sw.WriteLine(zbran);
                sw.WriteLine(specialniItem);
                sw.WriteLine(pomocnik);
                sw.Flush();
            }

            return score;
        }

        public class GameProgress
        {
            public int Score { get; set; }
            public string Jmeno { get; set; }
            public string Zivoty { get; set; }
            public string Zbran { get; set; }
            public string SpecialniItem { get; set; }
            public string Pomocnik { get; set; }
        }

        public GameProgress NacteniHry(string NazevSouboru)
        {
            GameProgress progress = new GameProgress();

            string[] NactenyProgres = new string[6];
            int i = 0;

            using (StreamReader sr = new StreamReader(@NazevSouboru))

            {
                string s;
                int score = 0;

                while ((s = sr.ReadLine()) != null)
                {
                    NactenyProgres[i] = s;
                    int.TryParse(NactenyProgres[0], out score);
                    progress.Score = score;
                    progress.Jmeno = NactenyProgres[1];
                    progress.Zivoty = NactenyProgres[2];
                    progress.Zbran = NactenyProgres[3];
                    progress.SpecialniItem = NactenyProgres[4];
                    progress.Pomocnik = NactenyProgres[5];
                    i++;
                }

            }
            return progress;
        }

        public GameProgress NacteniProgressu(int score)
        {
            GameProgress gameProgress = NacteniHry("progress.txt");
            Postava postava = new Postava();
            Postava pomocnik = new Postava();
            Postava zombie = new Postava();
            Azeroth svet = new Azeroth();
            Konzole konzole = new Konzole();
            zombie.zivoty = 15;

            if (score == 10)
            {
                svet.Intro(postava.name);
                postava.zbran = svet.vyberZbrane();
                ZapisBodu(20, postava.name, postava.zivoty, postava.zbran);
                postava.Sila(postava.zbran);
                konzole.Pokracuj();
                int cesta = svet.Pub();
                if (cesta == 1)
                {
                    postava.specialniItem = svet.PubBitka(postava.zbran);
                    ZapisBodu(30, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                }
                else if (cesta == 2)
                {
                    postava.specialniItem = "Nic";
                    svet.PubBezKonfrontace();
                    ZapisBodu(30, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                }
                svet.PubUvnitr();
                ZapisBodu(40, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                postava.zivoty = svet.Mise1(postava.sila, postava.zivoty, zombie.zivoty);
                ZapisBodu(50, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                postava.pomocnik = svet.Kompadre();
                postava.zivoty = 100;
                pomocnik.zivoty = 100;
                ZapisBodu(60, postava.name, postava.zivoty, postava.zbran, postava.specialniItem, postava.pomocnik);
                if (postava.pomocnik == "Ano")
                {
                    svet.BossFight(postava.sila, postava.pomocnik, postava.zivoty, pomocnik.zivoty, postava.specialniItem);
                }
                else
                {
                    svet.BossFightBezPomocnika(postava.sila, postava.zivoty, postava.specialniItem);
                }
                Console.ReadKey();
            }
            else if (score == 20)
            {
                postava.Sila(postava.zbran);
                konzole.Pokracuj();
                int cesta = svet.Pub();
                if (cesta == 1)
                {
                    postava.specialniItem = svet.PubBitka(postava.zbran);
                    ZapisBodu(30, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                }
                else if (cesta == 2)
                {
                    postava.specialniItem = "Nic";
                    svet.PubBezKonfrontace();
                    ZapisBodu(30, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                }
                svet.PubUvnitr();
                ZapisBodu(40, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                postava.zivoty = svet.Mise1(postava.sila, postava.zivoty, zombie.zivoty);
                ZapisBodu(50, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                postava.pomocnik = svet.Kompadre();
                postava.zivoty = 100;
                pomocnik.zivoty = 100;
                ZapisBodu(60, postava.name, postava.zivoty, postava.zbran, postava.specialniItem, postava.pomocnik);
                if (postava.pomocnik == "Ano")
                {
                    svet.BossFight(postava.sila, postava.pomocnik, postava.zivoty, pomocnik.zivoty, postava.specialniItem);
                }
                else
                {
                    svet.BossFightBezPomocnika(postava.sila, postava.zivoty, postava.specialniItem);
                }
                Console.ReadKey();
            }
            else if (score == 30)
            {
                svet.PubUvnitr();
                ZapisBodu(40, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                postava.zivoty = svet.Mise1(postava.sila, postava.zivoty, zombie.zivoty);
                ZapisBodu(50, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                postava.pomocnik = svet.Kompadre();
                postava.zivoty = 100;
                pomocnik.zivoty = 100;
                ZapisBodu(60, postava.name, postava.zivoty, postava.zbran, postava.specialniItem, postava.pomocnik);
                if (postava.pomocnik == "Ano")
                {
                    svet.BossFight(postava.sila, postava.pomocnik, postava.zivoty, pomocnik.zivoty, postava.specialniItem);
                }
                else
                {
                    svet.BossFightBezPomocnika(postava.sila, postava.zivoty, postava.specialniItem);
                }
                Console.ReadKey();
            }
            else if (score == 40) 
            {
                postava.zivoty = svet.Mise1(postava.sila, postava.zivoty, zombie.zivoty);
                ZapisBodu(50, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                postava.pomocnik = svet.Kompadre();
                postava.zivoty = 100;
                pomocnik.zivoty = 100;
                ZapisBodu(60, postava.name, postava.zivoty, postava.zbran, postava.specialniItem, postava.pomocnik);
                if (postava.pomocnik == "Ano")
                {
                    svet.BossFight(postava.sila, postava.pomocnik, postava.zivoty, pomocnik.zivoty, postava.specialniItem);
                }
                else
                {
                    svet.BossFightBezPomocnika(postava.sila, postava.zivoty, postava.specialniItem);
                }
                Console.ReadKey();
            }
            else if (score == 50)
            {
                postava.pomocnik = svet.Kompadre();
                postava.zivoty = 100;
                pomocnik.zivoty = 100;
                ZapisBodu(60, postava.name, postava.zivoty, postava.zbran, postava.specialniItem, postava.pomocnik);
                if (postava.pomocnik == "Ano")
                {
                    svet.BossFight(postava.sila, postava.pomocnik, postava.zivoty, pomocnik.zivoty, postava.specialniItem);
                }
                else
                {
                    svet.BossFightBezPomocnika(postava.sila, postava.zivoty, postava.specialniItem);
                }
                Console.ReadKey();
            } else if (score == 60)
            {
                Console.WriteLine("Však už si to dokočil tak si to zahrej znova chci spat je 23:00");
            }
            return gameProgress;
        }
    }
}
