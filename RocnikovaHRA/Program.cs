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
                        soubor.ZapisBodu("progress.txt", 10, postava.name);
                        svet.Intro(postava.name);
                        postava.zbran = svet.vyberZbrane();
                        soubor.ZapisBodu("progress.txt", 20, postava.name, postava.zbran);
                        postava.Sila(postava.zbran);
                        konzole.Pokracuj();
                        int cesta = svet.Pub();
                        if (cesta == 1) 
                        {
                            postava.specialniItem = svet.PubBitka(postava.zbran);
                            soubor.ZapisBodu("progress.txt", 30, postava.name, postava.zbran, postava.specialniItem);
                        } else if (cesta == 2)
                        {
                            postava.specialniItem = "Nic";
                            svet.PubBezKonfrontace();
                            soubor.ZapisBodu("progress.txt", 30, postava.name, postava.zbran, postava.specialniItem);
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        // Save a exit
                        return;
                    case "3":
                        GameProgress gameProgress = soubor.NacteniHry("progress.txt");
                        int score = gameProgress.Score;
                        string jmeno = gameProgress.Jmeno;
                        string zbran = gameProgress.Zbran;
                        string specialItem = gameProgress.SpecialniItem;

                        if (gameProgress.Score == 10)
                        {
                            svet.Intro(jmeno);
                            postava.zbran = svet.vyberZbrane();
                            soubor.ZapisBodu("progress.txt", 20, jmeno, zbran);
                            postava.Sila(zbran);
                            konzole.Pokracuj();
                            int cesta1 = svet.Pub();
                            if (cesta1 == 1)
                            {
                                postava.specialniItem = svet.PubBitka(zbran);
                                soubor.ZapisBodu("progress.txt", 30, jmeno, zbran, postava.specialniItem);
                            }
                            else if (cesta1 == 2)
                            {
                                postava.specialniItem = "Nic";
                                svet.PubBezKonfrontace();
                                soubor.ZapisBodu("progress.txt", 30, jmeno, zbran, postava.specialniItem);
                            }
                        }
                        else if (gameProgress.Score == 20)
                        {
                            postava.Sila(zbran);
                            konzole.Pokracuj();
                            int cesta2 = svet.Pub();
                            if (cesta2 == 1)
                            {
                                postava.specialniItem = svet.PubBitka(zbran);
                                soubor.ZapisBodu("progress.txt", 30, jmeno, zbran, postava.specialniItem);
                            }
                            else if (cesta2 == 2)
                            {
                                postava.specialniItem = "Nic";
                                svet.PubBezKonfrontace();
                                soubor.ZapisBodu("progress.txt", 30, jmeno, zbran, postava.specialniItem);
                            }
                        }
                        break;
                }
            }
        }
    }
}