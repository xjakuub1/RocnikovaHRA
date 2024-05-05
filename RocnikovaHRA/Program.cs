﻿using System;
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
                            postava.specialniItem = svet.PubBitka();
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

                        if (gameProgress.Score == 10)
                        {
                            Console.WriteLine(postava.name);
                        }
                        else if (gameProgress.Score == 20)
                        {
                            Console.WriteLine(postava.name + postava.zbran);
                        }
                        break;
                }
            }
        }
    }
}