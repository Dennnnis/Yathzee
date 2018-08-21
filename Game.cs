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
        private int animationFrame = 0; //Variable
        private float animatieLengte = 1.5f;

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
            vast[0] = checkBox1.Checked; vast[1] = checkBox2.Checked; vast[2] = checkBox5.Checked; vast[3] = checkBox4.Checked; vast[4] = checkBox3.Checked;
            buttons[0] = button38; buttons[1] = button67; buttons[2] = button66; buttons[3] = button65; buttons[4] = button40;
        }

        private void button39_Click(object sender, EventArgs e) //Roll Dice
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (animationFrame > animatieLengte * (1000/timer1.Interval))
            {
                animationFrame = 0;
                timer1.Stop();
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
