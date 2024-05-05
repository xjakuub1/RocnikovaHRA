using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocnikovaHRA
{
    internal class Konzole
    {
        public void Kurator()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Reset()
        {
            Console.ForegroundColor= ConsoleColor.White;
        }

        public void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void DarkCyan()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        public void Pokracuj()
        {
            Reset();
            Console.WriteLine("\nZmáčkni jakékoliv tlačítko pro pokračování");
            Console.ReadKey(true);
        }
    }
}
