using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBattleSim
{
    public class Army
    {

        // How many are alive and / or dead
        int InfantryCount;
        int InfantryDeathCount;

        int CavalryCount;
        int CavalryDeathCount;

        int ArtileryCount;
        int ArtileryDeathCount;

        int TotalCount;
        int TotalDeathCount;

        int RegimentCount;

        int TotalDamage;

        // Numbers how many soldiers each side gets.
        // TODO: Make this variable and store it in a parameter so that different armies can have different sizes.

        public int InfRegNumbers = 10;
        public int CavRegNumbers = 4;
        public int ArtRegNumbers = 6;

        Regiment[] InfantryArray = new Infantry[20];
        Regiment[] CavalryArray = new Cavalry[20];
        Regiment[] ArtileryArray = new Artilery[20];

        Array[] ArmyArray = new Array[3];


        public Army()
        {

        }

        // Setting up the different sides, Settup numbers are done above.

        public void Setup()
        {
            RegimentCount = 0;

            ArmyArray[0] = InfantryArray;
            ArmyArray[1] = CavalryArray;
            ArmyArray[2] = ArtileryArray;

            for (int i = 0; i < InfRegNumbers; i++)
            {
                InfantryArray[i] = new Infantry();
                RegimentCount++;
                (InfantryArray[i] as Infantry).Setup();
                InfantryCount = InfantryCount + (InfantryArray[i] as Infantry).GetCount();
                TotalCount = TotalCount + (InfantryArray[i] as Infantry).GetCount();
            }

            for (int i = 0; i < CavRegNumbers; i++)
            {
                CavalryArray[i] = new Cavalry();
                RegimentCount++;
                (CavalryArray[i] as Cavalry).Setup();
                CavalryCount = CavalryCount + (CavalryArray[i] as Cavalry).GetCount();
                TotalCount = TotalCount + (CavalryArray[i] as Cavalry).GetCount();
            }

            for (int i = 0; i < ArtRegNumbers; i++)
            {
                ArtileryArray[i] = new Artilery();
                RegimentCount++;
                (ArtileryArray[i] as Artilery).Setup();
                ArtileryCount = ArtileryCount + (ArtileryArray[i] as Artilery).GetCount();
                TotalCount = TotalCount + (ArtileryArray[i] as Artilery).GetCount();
            }
        }

        public bool StilAlive()
        {
            bool Alive = false;

            foreach (Array type in ArmyArray)
            {
                foreach (Object regiment in type)
                {
                    if (type == InfantryArray && regiment != null && (regiment as Infantry).StilAlive())
                    {
                        Alive = true;
                        break;
                    }

                    if (type == CavalryArray && regiment != null && (regiment as Cavalry).StilAlive())
                    {
                        Alive = true;
                        break;
                    }

                    if (type == ArtileryArray && regiment != null && (regiment as Artilery).StilAlive())
                    {
                        Alive = true;
                        break;
                    }
                }
            }

            return Alive;
        }

        public int GetDamage()
        {
            TotalDamage = 0;

            foreach (Array type in ArmyArray)
            {
                foreach (Object regiment in type)
                {
                    int damage = 0;


                    if (type == InfantryArray && regiment != null && (regiment as Infantry).StilAlive())
                    {
                        damage = (regiment as Infantry).DoDamage();
                    }

                    if (type == CavalryArray && regiment != null && (regiment as Cavalry).StilAlive())
                    {
                        damage = (regiment as Cavalry).DoDamage();
                    }

                    if (type == ArtileryArray && regiment != null && (regiment as Artilery).StilAlive())
                    {
                        damage = (regiment as Artilery).DoDamage();
                    }

                    TotalDamage = TotalDamage + damage;
                }
            }
            return TotalDamage;
        }

        public void ApplyDamage(int Damage)
        {
            foreach (Array type in ArmyArray)
            {
                foreach (Object regiment in type)
                {
                    if (type == InfantryArray && regiment != null && (regiment as Infantry).StilAlive())
                    {
                        (regiment as Infantry).SetDeaths(Damage);
                    }

                    if (type == CavalryArray && regiment != null && (regiment as Cavalry).StilAlive())
                    {
                        (regiment as Cavalry).SetDeaths(Damage);
                    }

                    if (type == ArtileryArray && regiment != null && (regiment as Artilery).StilAlive())
                    {
                        (regiment as Artilery).SetDeaths(Damage);
                    }
                }
            }
        }

        public void UpdateDeathCounts()
        {
            InfantryDeathCount = 0;
            CavalryDeathCount = 0;
            ArtileryDeathCount = 0;
            TotalDeathCount = 0;

            foreach (Array type in ArmyArray)
            {
                foreach (Object regiment in type)
                {
                    int Deaths = 0;

                    if (type == InfantryArray && regiment != null)
                    {
                        Deaths = (regiment as Infantry).GetDeaths();
                        InfantryDeathCount = InfantryDeathCount + Deaths;
                    }

                    if (type == CavalryArray && regiment != null)
                    {
                        Deaths = (regiment as Cavalry).GetDeaths();
                        CavalryDeathCount = CavalryDeathCount + Deaths;
                    }

                    if (type == ArtileryArray && regiment != null)
                    {
                        Deaths = (regiment as Artilery).GetDeaths();
                        ArtileryDeathCount = ArtileryDeathCount + Deaths;
                    }

                    TotalDeathCount = TotalDeathCount + Deaths;
                }
            }
        }

   
        public void UpdateLiveCounts()
        {
            InfantryCount = 0;
            CavalryCount = 0;
            ArtileryCount = 0;
            TotalCount = 0;

            foreach (Array type in ArmyArray)
            {
                foreach (Object regiment in type)
                {
                    int troops = 0;

                    if (type == InfantryArray && regiment != null)
                    {
                        troops = (regiment as Infantry).GetCount();
                        InfantryCount = InfantryCount + troops;
                    }

                        if (type == CavalryArray && regiment != null)
                    {
                        troops = (regiment as Cavalry).GetCount();
                        CavalryCount = CavalryCount + troops;
                    }

                    if (type == ArtileryArray && regiment != null)
                    {
                        troops = (regiment as Artilery).GetCount();
                        ArtileryCount = ArtileryCount + troops;
                    }

                    TotalCount = TotalCount + troops;
                }
            }
        }

        public int GetInfantryCount()
        {
            return InfantryCount;
        }

        public int GetInfantryDeathCount()
        {
            return InfantryDeathCount;
        }

        public int GetCavalryCount()
        {
            return CavalryCount;
        }

        public int GetCavalryDeathCount()
        {
            return CavalryDeathCount;
        }

        public int GetArtileryCount()
        {
            return ArtileryCount;
        }

        public int GetArtileryDeathCount()
        {
            return ArtileryDeathCount;
        }

        public int GetTotalCount()
        {
            return TotalCount;
        }

        public int GetTotalDeathCount()
        {
            return TotalDeathCount;
        }
    }
}
