using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineBattleSim
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        Army FrenchArmy = new Army();
        Army EnglishArmy = new Army();

        private void StartBattle()
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FrenchArmy.StilAlive() && EnglishArmy.StilAlive())
            {
                Timer.Tick(FrenchArmy, EnglishArmy);

                UpdateCasualities();
                UpdateArmyCount();
            }
            else
            {
                timer1.Stop();
                StartButton.Enabled = true;
            }
        }

        private void UpdateCasualities()
        {
            // UI French Deathcounts.

            FrenchInfantryCasualities.Text = Convert.ToString(FrenchArmy.GetInfantryDeathCount());
            FrenchCavalryCasualities.Text = Convert.ToString(FrenchArmy.GetCavalryDeathCount());
            FrenchArtileryCasualities.Text = Convert.ToString(FrenchArmy.GetArtileryDeathCount());

            FrenchTotalCasualities.Text = Convert.ToString(FrenchArmy.GetTotalDeathCount());

            // UI English Deathcounts.

            EnglishInfantryCasualities.Text = Convert.ToString(EnglishArmy.GetInfantryDeathCount());
            EnglishCavalryCasualities.Text = Convert.ToString(EnglishArmy.GetCavalryDeathCount());
            EnglishArtileryCasualities.Text = Convert.ToString(EnglishArmy.GetArtileryDeathCount());
            
            EnglishTotalCasualities.Text = Convert.ToString(EnglishArmy.GetTotalDeathCount());
        }

        private void UpdateArmyCount()
        {
            // UI French Armie counts.

            FrenchInfantryAlive.Text = Convert.ToString(FrenchArmy.GetInfantryCount());
            FrenchCavalryAlive.Text = Convert.ToString(FrenchArmy.GetCavalryCount());
            FrenchArtileryAlive.Text = Convert.ToString(FrenchArmy.GetArtileryCount());

            FrenchTotalAlive.Text = Convert.ToString(FrenchArmy.GetTotalCount());


            // UI English Armie Counts.

            EnglishInfantryAlive.Text = Convert.ToString(EnglishArmy.GetInfantryCount());
            EnglishCavalryAlive.Text = Convert.ToString(EnglishArmy.GetCavalryCount());
            EnglishArtileryAlive.Text = Convert.ToString(EnglishArmy.GetArtileryCount());

            EnglishTotalAlive.Text = Convert.ToString(EnglishArmy.GetTotalCount());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            FrenchArmy.Setup();
            EnglishArmy.Setup();
            UpdateArmyCount();
            StartBattle();
            StartButton.Enabled = false;
        }

   
    }

}

