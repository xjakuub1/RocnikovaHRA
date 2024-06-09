using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocnikovaHRA
{
    internal class Enemy : Postava
    {
        public int basicUtok(int sila, int zombieZivoty)
        {
            zombieZivoty -= sila;

            return zombieZivoty;
        }

        public int superUtok(int sila, int zombieZivoty)
        {
            zombieZivoty -= sila * 2;

            return zombieZivoty;
        }
    }
}
