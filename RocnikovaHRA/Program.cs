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
            Postava Marcel = new Postava();
            Azeroth svet = new Azeroth();
            PraceSeSouborem soubor = new PraceSeSouborem();

            // Hook up the application exit event handler

            // Game loop
            while (true)
            {
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Save and Quit");
                Console.WriteLine("3. Load Progress");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Your game logic goes here
                        Console.WriteLine("Playing...");

                        Marcel.name = Marcel.pojmenujPostavu();
                        soubor.ZapisBodu("progress.txt", 10, Marcel.name);
                        svet.Intro(Marcel.name);
                        Marcel.zbran = svet.vyberZbrane();
                        soubor.ZapisBodu("progress.txt", 20, Marcel.name, Marcel.zbran);
                        Marcel.Sila(Marcel.zbran);
                        Console.ReadKey();
                        break;
                    case "2":
                        // Save progress and exit
                        return;
                    case "3":
                        GameProgress gameProgress = soubor.NacteniHry("progress.txt");
                        int score = gameProgress.Score;
                        string jmeno = gameProgress.Jmeno;
                        string zbran = gameProgress.Zbran;

                        Marcel.name = jmeno;
                        Marcel.zbran = zbran;
                        Marcel.Sila(Marcel.zbran);
                        Console.WriteLine(Marcel.name + Marcel.zbran);
                        break;
                }
            }
        }
    }
}