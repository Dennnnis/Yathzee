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
    public partial class Form2 : Form
    {
        private int animationFrame = 0;


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e) //Roll Dice
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (animationFrame > 20)
            {
                animationFrame = 0;
                timer1.Stop();
            }
            animationFrame++;

            //Check vast checkboxes
            bool[] vast = new bool[5];
            vast[0] = checkBox1.Checked; vast[1] = checkBox2.Checked; vast[2] = checkBox5.Checked; vast[3] = checkBox4.Checked; vast[4] = checkBox3.Checked;

            //Select buttons
            Button[] buttons = new Button[5];
            buttons[0] = button38; buttons[1] = button67; buttons[2] = button66; buttons[3] = button65; buttons[4] = button40;

            //Randomize
            Dobbelstenen.Randomize(buttons, vast);
        }
    }
}
