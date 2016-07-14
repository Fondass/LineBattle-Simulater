using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBattleSim
{
    class Distance
    {
        int distance;

        public void Setup()
        {
            distance = 150;
        }

        public void Update(int order)
        {
            distance = distance - order;
        }

        public int GetDistance()
        {
            return distance;
        }

    }
}
