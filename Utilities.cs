using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBattleSim
{
    public static class Utilities
    {
        private static Random rnd = new Random();

        public static int GetRandom(int a, int b)
        {
            return rnd.Next(a, b);
        }
    }
}
