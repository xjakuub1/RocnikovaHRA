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

        public int ZapisBodu(string NazevSouboru, int score)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.Flush();
            }

            return score;
        }

        public int ZapisBodu(string NazevSouboru, int score, string jmeno)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.WriteLine(jmeno);
                sw.Flush();
            }

            return score;
        }

        public int ZapisBodu(string NazevSouboru, int score, string jmeno, string zbran)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.WriteLine(jmeno);
                sw.WriteLine(zbran);
                sw.Flush();
            }

            return score;
        }

        public int ZapisBodu(string NazevSouboru, int score, string jmeno, string zbran, string specialniItem)
        {
            string zapisScore = score.ToString();
            using (StreamWriter sw = new StreamWriter(@"progress.txt"))
            {
                sw.WriteLine(zapisScore);
                sw.WriteLine(jmeno);
                sw.WriteLine(zbran);
                sw.WriteLine(specialniItem);
                sw.Flush();
            }

            return score;
        }

        public class GameProgress
        {
            public int Score { get; set; }
            public string Jmeno { get; set; }
            public string Zbran { get; set; }
            public string SpecialniItem { get; set; }
        }

        public GameProgress NacteniHry(string NazevSouboru)
        {
            GameProgress progress = new GameProgress();

            string[] NactenyProgres = new string[4];
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
                    progress.Zbran = NactenyProgres[2];
                    progress.SpecialniItem = NactenyProgres[3];
                    i++;
                }

            }
            return progress;
        }
    }
}
