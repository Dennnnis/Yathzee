using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Yathzee
{
    public partial class Game : Form
    {
        //Dice animation
        private float animatieLengte = 1.5f;

        //Variables
        private int animationFrame = 0;
        public bool rolling = false;

        //Check vast/buttons
        bool[] vast = new bool[5];
        Button[] buttons = new Button[5];

        public Game()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Load buttons
            buttons[0] = button38;
            buttons[1] = button67;
            buttons[2] = button66;
            buttons[3] = button65;
            buttons[4] = button40;
        }

        private void button39_Click(object sender, EventArgs e) //Roll Dice
        {
            if (!rolling)
            {
                rolling = true;
                DobbelsteenTimer.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Alleen vast zetten in frame 0
            if (animationFrame == 0)
            {
                vast[0] = checkBox1.Checked;
                vast[1] = checkBox2.Checked;
                vast[2] = checkBox5.Checked;
                vast[3] = checkBox4.Checked;
                vast[4] = checkBox3.Checked;
            }

            //End of animation
            if (animationFrame > animatieLengte * (1000/DobbelsteenTimer.Interval))
            {
                animationFrame = 0;
                rolling = false;
                DobbelsteenTimer.Stop();
            }
            else
            {
                animationFrame++;

                //Randomize
                Dobbelstenen.Randomize(buttons, vast);
            }
        }
    }
}
