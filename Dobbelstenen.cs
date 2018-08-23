using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yathzee
{

    static class Dobbelstenen
    {
        public static int[] Dices = new int[5];
        private static Random rnd = new Random();
        public static void Randomize(Button[] knoppen, bool[] vast)
        {
        
            for (int i = 0; i < Dices.Length; i++)
            {
                if (vast[i]) continue;

                int RandomI = rnd.Next(1, 7);
                Dices[i] = RandomI;

                switch(RandomI)
                {
                    case 1: knoppen[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_one; break;
                    case 2: knoppen[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_two; break;
                    case 3: knoppen[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_three; break;
                    case 4: knoppen[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_four; break;
                    case 5: knoppen[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_five; break;
                    case 6: knoppen[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_six; break;
                }
            }
        }
    }
}
