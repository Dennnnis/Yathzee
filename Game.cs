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
        static TextBox[,] PlayersFields = new TextBox[4,16];
        int[] arr = new int[6];

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

            InitializeComponent();

            //One
            this.Activate_One.Click += new System.EventHandler(this.button34_Click);
            this.Activate_One.Click += new System.EventHandler(this.update_Click);

            this.Activate_Two.Click += new System.EventHandler(this.button29_Click);
            this.Activate_Two.Click += new System.EventHandler(this.update_Click);

            this.Activate_Three.Click += new System.EventHandler(this.button4_Click);
            this.Activate_Three.Click += new System.EventHandler(this.update_Click);

            this.Activate_Four.Click += new System.EventHandler(this.button3_Click);
            this.Activate_Four.Click += new System.EventHandler(this.update_Click);

            this.Activate_Five.Click += new System.EventHandler(this.button2_Click);
            this.Activate_Five.Click += new System.EventHandler(this.update_Click);

            this.Activate_Six.Click += new System.EventHandler(this.button1_Click);
            this.Activate_Six.Click += new System.EventHandler(this.update_Click);

            this.Activate_TOAK.Click += new System.EventHandler(this.button36_Click);
            this.Activate_TOAK.Click += new System.EventHandler(this.update_Click);

            this.Activate_Carré.Click += new System.EventHandler(this.button30_Click);
            this.Activate_Carré.Click += new System.EventHandler(this.update_Click);

            this.Activate_FullHouse.Click += new System.EventHandler(this.button31_Click);
            this.Activate_FullHouse.Click += new System.EventHandler(this.update_Click);

            this.Activate_KleineStraat.Click += new System.EventHandler(this.button32_Click);
            this.Activate_KleineStraat.Click += new System.EventHandler(this.update_Click);

            this.Activate_GroteStraat.Click += new System.EventHandler(this.button33_Click);
            this.Activate_GroteStraat.Click += new System.EventHandler(this.update_Click);

            this.Activate_Chance.Click += new System.EventHandler(this.button35_Click);
            this.Activate_Chance.Click += new System.EventHandler(this.update_Click);

            this.Activate_Yahtzee.Click += new System.EventHandler(this.button37_Click);
            this.Activate_Yahtzee.Click += new System.EventHandler(this.update_Click);






            
            players = in_players;
            Form2_Load();
        }

        private void nextPlayer()
        {
            label5.Text = players[currentPlayer].name;
            currentPlayer++;

            if (currentPlayer >= players.Length)
            {
                currentPlayer = 0;
            }
        }

        public void Form2_Load()
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

            //Set
            PlayersFields[0, 7] =  _S1_7;
            PlayersFields[0, 8] =  _S1_8;
            PlayersFields[0, 9] =  _S1_9;
            PlayersFields[0, 10] = _S1_10;
            PlayersFields[0, 11] = _S1_11;
            PlayersFields[0, 12] = _S1_12;
            PlayersFields[0, 13] = _S1_13;
            PlayersFields[0, 14] = _S1_Sub2;
            PlayersFields[0, 15] = _S1_Tot;

            PlayersFields[1, 7] =  _S2_7;
            PlayersFields[1, 8] =  _S2_8;
            PlayersFields[1, 9] =  _S2_9;
            PlayersFields[1, 10] = _S2_10;
            PlayersFields[1, 11] = _S2_11;
            PlayersFields[1, 12] = _S2_12;
            PlayersFields[1, 13] = _S2_13;
            PlayersFields[1, 14] = _S2_Sub2;
            PlayersFields[1, 15] = _S2_Tot;

            PlayersFields[2, 7] =  _S3_7;
            PlayersFields[2, 8] =  _S3_8;
            PlayersFields[2, 9] =  _S3_9;
            PlayersFields[2, 10] = _S3_10;
            PlayersFields[2, 11] = _S3_11;
            PlayersFields[2, 12] = _S3_12;
            PlayersFields[2, 13] = _S3_13;
            PlayersFields[2, 14] = _S3_Sub2;
            PlayersFields[2, 15] = _S3_Tot;

            PlayersFields[3, 7] =  _S4_7;
            PlayersFields[3, 8] =  _S4_8;
            PlayersFields[3, 9] =  _S4_9;
            PlayersFields[3, 10] = _S4_10;
            PlayersFields[3, 11] = _S4_11;
            PlayersFields[3, 12] = _S4_12;
            PlayersFields[3, 13] = _S4_13;
            PlayersFields[3, 14] = _S4_Sub2;
            PlayersFields[3, 15] = _S4_Tot;



            try
            {
                label1.Text = players[0].name;
                label12.Text = players[0].name;
                label9.Text = players[1].name;
                label4.Text = players[1].name;
                label11.Text = players[2].name;
                label2.Text = players[2].name;
                label10.Text = players[3].name;
                label3.Text = players[3].name;
            }
            catch(Exception)
            {

            }

            

            for (int i = 0; i < players.Length; i++)
            { 
                for (int j = 0; j < 13; j++)
                {
                    players[i].buttons[j] = true;
                }
            }

            label5.Text = players[currentPlayer].name;


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

        private int countArray(int[] a,int find)
        {
            int count = 0;
            foreach (int i in a)
            {
                if (i == find)
                {
                    count++;
                }
            }
            return count;
        }

        private void update_Click(object sender, EventArgs e) //Update
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
            Activate_TOAK.Enabled = players[currentPlayer].buttons[6];
            Activate_Carré.Enabled = players[currentPlayer].buttons[7];
            Activate_FullHouse.Enabled = players[currentPlayer].buttons[8];
            Activate_KleineStraat.Enabled = players[currentPlayer].buttons[9];
            Activate_GroteStraat.Enabled = players[currentPlayer].buttons[10];
            Activate_Chance.Enabled = players[currentPlayer].buttons[11];
            Activate_Yahtzee.Enabled = players[currentPlayer].buttons[12];

            
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

        private void button36_Click(object sender, EventArgs e) //TOAK Knop 7
        {
            int score = 0;
            players[currentPlayer].buttons[6] = false;
            for (int i = 0; i < arr.Length; i++) arr[i] = countArray(Dobbelstenen.Dices, i + 1);
            
            if (arr.Contains(3) || (arr.Contains(4) || (arr.Contains(5))))
            {
                foreach (int i in Dobbelstenen.Dices)
                {
                    score += i;
                }
            }
            PlayersFields[currentPlayer, 7].Text = score.ToString();
        }

        private void button30_Click(object sender, EventArgs e) //Carré Knop 8
        {
            players[currentPlayer].buttons[7] = false;

            int score = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = countArray(Dobbelstenen.Dices, i + 1);
            }

            if (arr.Contains(4) || (arr.Contains(5)))
            {
                foreach (int i in Dobbelstenen.Dices)
                {
                    score += i;
                }
            }

            PlayersFields[currentPlayer, 8].Text = score.ToString();
        }

        private void button31_Click(object sender, EventArgs e) //Full House Knop 9
        {
            players[currentPlayer].buttons[5] = false;

            int score = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = countArray(Dobbelstenen.Dices, i + 1);
            }

            if (arr.Contains(3) && (arr.Contains(2)))
            {
                score = 25;                
            }

            PlayersFields[currentPlayer, 9].Text = score.ToString();
        }

        private void button32_Click(object sender, EventArgs e) //Kleine Straat Knop 10
        {

        }

        private void button33_Click(object sender, EventArgs e) //Grote Straat Knop 11
        {

        }

        private void button35_Click(object sender, EventArgs e) //Chance Knop 12
        {

        }

        private void button37_Click(object sender, EventArgs e) //Yahtzee Knop 13
        {

        }
    }
}
