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

        //Player fields
        static TextBox[,] PlayersFields = new TextBox[4,7];

        //Dice animation
        private float animatieLengte = 1.5f;

        //Variables
        private Player[] players = new Player[4];
        public int currentPlayer = 0;
        private int animationFrame = 0;
        public bool rolling = false;

        //Check vast/buttons
        bool[] vast = new bool[5];
        Button[] buttons = new Button[5];

        public Game(Player[] in_players)
        {
            players = in_players;
            InitializeComponent();
        }

        private void nextPlayer()
        {
            currentPlayer++;

            if (currentPlayer >= players.Length)
            {
                currentPlayer = 0;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Load buttons
            buttons[0] = button38;
            buttons[1] = button67;
            buttons[2] = button66;
            buttons[3] = button65;
            buttons[4] = button40;

            //Set 
            PlayersFields[0, 0] = _S1_1;
            PlayersFields[0, 1] = _S1_2;
            PlayersFields[0, 2] = _S1_3;
            PlayersFields[0, 3] = _S1_4;
            PlayersFields[0, 4] = _S1_5;
            PlayersFields[0, 5] = _S1_6;
            PlayersFields[0, 6] = _S1_Sub;

            PlayersFields[1, 0] = _S2_1;
            PlayersFields[1, 1] = _S2_2;
            PlayersFields[1, 2] = _S2_3;
            PlayersFields[1, 3] = _S2_4;
            PlayersFields[1, 4] = _S2_5;
            PlayersFields[1, 5] = _S2_6;
            PlayersFields[1, 6] = _S2_Sub;

            PlayersFields[2, 0] = _S3_1;
            PlayersFields[2, 1] = _S3_2;
            PlayersFields[2, 2] = _S3_3;
            PlayersFields[2, 3] = _S3_4;
            PlayersFields[2, 4] = _S3_5;
            PlayersFields[2, 5] = _S3_6;
            PlayersFields[2, 6] = _S3_Sub;

            PlayersFields[3, 0] = _S4_1;
            PlayersFields[3, 1] = _S4_2;
            PlayersFields[3, 2] = _S4_3;
            PlayersFields[3, 3] = _S4_4;
            PlayersFields[3, 4] = _S4_5;
            PlayersFields[3, 5] = _S4_6;
            PlayersFields[3, 6] = _S4_Sub;


            label1.Text  = players[0].name;
            label12.Text = players[0].name;
            label9.Text =  players[1].name;
            label4.Text =  players[1].name;
            label11.Text = players[2].name;
            label2.Text =  players[2].name;
            label10.Text = players[3].name;
            label3.Text =  players[3].name;

            

            for (int i = 0; i < players.Length; i++)
            { 
                for (int j = 0; j < 6; j++)
                {
                    players[i].buttons[j] = true;
                }
            }
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
        private void update_Click(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < 6; i++)
            {
                if (PlayersFields[currentPlayer, i].Text != "")
                {
                    total += Convert.ToInt32(PlayersFields[currentPlayer, i].Text);
                }
            }
            PlayersFields[currentPlayer, 6].Text = total.ToString();

            nextPlayer();

            Activate_One.Enabled = players[currentPlayer].buttons[0];
            Activate_Two.Enabled = players[currentPlayer].buttons[1];
            Activate_Three.Enabled = players[currentPlayer].buttons[2];
            Activate_Four.Enabled = players[currentPlayer].buttons[3];
            Activate_Five.Enabled = players[currentPlayer].buttons[4];
            Activate_Six.Enabled = players[currentPlayer].buttons[5];

            

            
        }
        private void button34_Click(object sender, EventArgs e) //Knop 1
        {
            players[currentPlayer].buttons[0] = false;
            int score = 0;
            foreach (int i in Dobbelstenen.Dices)
            {
                
                if (i == 1)
                {
                    score += 1;
                }

            }
            PlayersFields[currentPlayer, 0].Text = score.ToString();

        }

        private void button29_Click(object sender, EventArgs e) //Knop 2
        {
            players[currentPlayer].buttons[1] = false;

            int score = 0;
            foreach (int i in Dobbelstenen.Dices)
            {

                if (i == 2)
                {
                    score += 2;
                }

            }
            PlayersFields[currentPlayer, 1].Text = score.ToString();
        }

        private void button4_Click(object sender, EventArgs e) //Knop 3
        {
            players[currentPlayer].buttons[2] = false;

            int score = 0;
            foreach (int i in Dobbelstenen.Dices)
            {

                if (i == 3)
                {
                    score += 3;
                }

            }
            PlayersFields[currentPlayer, 2].Text = score.ToString();
        }

        private void button3_Click(object sender, EventArgs e) //Knop 4
        {
            players[currentPlayer].buttons[3] = false;

            int score = 0;
            foreach (int i in Dobbelstenen.Dices)
            {

                if (i == 4)
                {
                    score += 4;
                }

            }
            PlayersFields[currentPlayer, 3].Text = score.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //Knop 5
        {
            players[currentPlayer].buttons[4] = false;

            int score = 0;
            foreach (int i in Dobbelstenen.Dices)
            {

                if (i == 5)
                {
                    score += 5;
                }

            }
            PlayersFields[currentPlayer, 4].Text = score.ToString();
        }

        private void button1_Click(object sender, EventArgs e) //Knop 6
        {
            players[currentPlayer].buttons[5] = false;

            int score = 0;
            foreach (int i in Dobbelstenen.Dices)
            {

                if (i == 6)
                {
                    score += 6;
                }

            }
            PlayersFields[currentPlayer, 5].Text = score.ToString();
        }
    }
}
