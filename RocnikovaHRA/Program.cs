using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static RocnikovaHRA.PraceSeSouborem;

namespace RocnikovaHRA
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Postava postava = new Postava();
            Postava pomocnik = new Postava();
            Enemy zombie = new Enemy();
            Azeroth svet = new Azeroth();
            PraceSeSouborem soubor = new PraceSeSouborem();
            Konzole konzole = new Konzole();

            while (true)
            {
                konzole.Reset();
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Save and Quit");
                Console.WriteLine("3. Load Progress");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        postava.name = postava.pojmenujPostavu();
                        zombie.zivoty = 15;
                        soubor.ZapisBodu(10, postava.name, postava.zivoty);
                        svet.Intro(postava.name);
                        postava.zbran = svet.vyberZbrane();
                        soubor.ZapisBodu(20, postava.name, postava.zivoty, postava.zbran);
                        postava.Sila(postava.zbran);
                        konzole.Pokracuj();
                        int cesta = svet.Pub();
                        if (cesta == 1) 
                        {
                            postava.specialniItem = svet.PubBitka(postava.zbran);
                            soubor.ZapisBodu(30, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                        } else if (cesta == 2)
                        {
                            postava.specialniItem = "Nic";
                            svet.PubBezKonfrontace();
                            soubor.ZapisBodu(30, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                        }
                        svet.PubUvnitr();
                        soubor.ZapisBodu(40, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                        postava.zivoty = svet.Mise1(postava.sila, postava.zivoty, zombie.zivoty);
                        soubor.ZapisBodu(50, postava.name, postava.zivoty, postava.zbran, postava.specialniItem);
                        postava.pomocnik = svet.Kompadre();
                        postava.zivoty = 100;
                        pomocnik.zivoty = 100;
                        soubor.ZapisBodu(60, postava.name, postava.zivoty, postava.zbran, postava.specialniItem, postava.pomocnik);
                        if (postava.pomocnik == "Ano") 
                        {
                            svet.BossFight(postava.sila, postava.pomocnik, postava.zivoty, pomocnik.zivoty, postava.specialniItem);
                        } else
                        {
                            svet.BossFightBezPomocnika(postava.sila, postava.zivoty, postava.specialniItem);
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        Environment.Exit(0);
                        return;
                    case "3":
                        GameProgress gameProgress = soubor.NacteniHry("progress.txt");

                        if (gameProgress.Score == 10)
                        {
                            soubor.NacteniProgressu(gameProgress.Score);
                        }
                        else if (gameProgress.Score == 20)
                        {
                            soubor.NacteniProgressu(gameProgress.Score);
                        } else if (gameProgress.Score == 30)
                        {
                            soubor.NacteniProgressu(gameProgress.Score);
                        } else if (gameProgress.Score == 40)
                        {
                            soubor.NacteniProgressu(gameProgress.Score);
                        } else if (gameProgress.Score == 50)
                        {
                            soubor.NacteniProgressu(gameProgress.Score);
                        } else if (gameProgress.Score == 60)
                        {
                            soubor.NacteniProgressu(gameProgress.Score);
                        }
                        break;
                }
            }
        }
    }
}