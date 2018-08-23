using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yathzee
{

    static class Dice
    {
        public static int[] Dices = {1,1,1,1,1};
        public static int[] Count = new int[6];
        private static Random rnd = new Random();

        public static bool CountContains(int[] cmp,bool or)
        {
            bool good = !or;
            foreach (int i in cmp)
            {
                good = or ? good || Count.Contains(i) : good && Count.Contains(i);     
            }
            return good;
        }

        public static bool Match(int[] full)
        {
            for (int i = 0; i < Dices.Length; i++)
            {
                if (full[i] != Dices[i]) return false;
            }
            return true;
        }

        public static void Hide()
        {
            foreach (var i in Game.buttons) i.BackgroundImage = null;
        }

        public static void Randomize()
        {
            Array.Clear(Count, 0, Count.Length);
            for (int i = 0; i < Dices.Length; i++)
            {
                if (Game.vast[i] && Game.throwCount != 1) { Count[Dices[i] - 1]++; continue; }

                Dices[i] = rnd.Next(1, 7);
                Count[Dices[i] - 1]++;

                switch (Dices[i])
                {
                    case 1: Game.buttons[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_one;   break;
                    case 2: Game.buttons[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_two;   break;
                    case 3: Game.buttons[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_three; break;
                    case 4: Game.buttons[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_four;  break;
                    case 5: Game.buttons[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_five;  break;
                    case 6: Game.buttons[i].BackgroundImage = Yathzee.Properties.Resources.dice_six_faces_six;   break;
                }
            }
        }
    }
}
