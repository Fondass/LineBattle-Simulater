using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBattleSim
{
    abstract class Regiment
    {
        int Count;
        int Deaths;

        int Total;
        int TotalDeaths;

        public Regiment()
        {

        }

        public void Setup()
        {
            Total = 1000;
            Count = Total;
        }

        public bool StilAlive()
        {
            if (Count >= 100)
            {
                return true;
            }
            else
            {
                Count = 0;
                return false;
            }
        }

        public int GetCount()
        {
            return Count;
        }

        public void SetDeaths(int DamageReceived)
        {
                int DamageCalculated;

                int MinDamage = ((DamageReceived / 100) / 2) + 1;
                int MaxDamage = (DamageReceived / 100) + 4;


                DamageCalculated = Utilities.GetRandom(MinDamage, MaxDamage);

                TotalDeaths = TotalDeaths + DamageCalculated;

                Count = Count - DamageCalculated;
        }

        public int GetDeaths()
        {
            return TotalDeaths;
        }

        public int DoDamage()
        {
            int MinDamage = (Count / 11);
            int MaxDamage = (Count / 9);

            int DamageDone = Utilities.GetRandom(MinDamage, MaxDamage);

            return DamageDone;
        }
    }
}
