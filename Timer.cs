using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBattleSim
{
    static class Timer
    {

        static public void Tick(Army FrenchArmy, Army EnglishArmy)
        {
                int FrenchDamage = FrenchArmy.GetDamage();
                int EnglishDamage = EnglishArmy.GetDamage();

                FrenchArmy.ApplyDamage(EnglishDamage);
                EnglishArmy.ApplyDamage(FrenchDamage);

                FrenchArmy.UpdateDeathCounts();
                EnglishArmy.UpdateDeathCounts();

                FrenchArmy.UpdateLiveCounts();
                EnglishArmy.UpdateLiveCounts();
        }
    }
}
