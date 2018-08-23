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
        private int   maximaalAantalGooien = 3;

        //Variables
        private static TextBox[,]  playerField = new TextBox[4, 16];
        private Player[]           players = new Player[4];
        private int                animationFrame = 0;
        private int                curPlayer = 0;
        private bool               thrown = false;
        public  static int         throwCount = 0;
        public  bool               rolling = false;
        public static Button[]     buttons = new Button[5];
        public static bool[]       vast = new bool[5];
        
        public Game(Player[] in_players)
        {
            InitializeComponent();
            players = in_players;
            load();
        }

        private void NextPlayer()
        {
            curPlayer++;
            curPlayer %= players.Length;  
            label5.Text = players[curPlayer].name;
        }

        public void load()
        {
            //Add click events
            this.Activate_One.Click += new System.EventHandler(this.update_Click); this.Activate_TOAK.Click += new System.EventHandler(this.update_Click);
            this.Activate_Two.Click += new System.EventHandler(this.update_Click); this.Activate_Carré.Click += new System.EventHandler(this.update_Click);
            this.Activate_Three.Click += new System.EventHandler(this.update_Click); this.Activate_FullHouse.Click += new System.EventHandler(this.update_Click);
            this.Activate_Four.Click += new System.EventHandler(this.update_Click); this.Activate_KleineStraat.Click += new System.EventHandler(this.update_Click);
            this.Activate_Five.Click += new System.EventHandler(this.update_Click); this.Activate_GroteStraat.Click += new System.EventHandler(this.update_Click);
            this.Activate_Six.Click += new System.EventHandler(this.update_Click); this.Activate_Chance.Click += new System.EventHandler(this.update_Click);
            this.Activate_Yahtzee.Click += new System.EventHandler(this.update_Click);

            //Load buttons
            buttons[0] = button38;
            buttons[1] = button67;
            buttons[2] = button66;
            buttons[3] = button65;
            buttons[4] = button40;

            //Set player fields
            playerField[0, 0] = _S1_1;   playerField[1, 0] = _S2_1;   playerField[2, 0] = _S3_1;   playerField[3, 0] = _S4_1;
            playerField[0, 1] = _S1_2;   playerField[1, 1] = _S2_2;   playerField[2, 1] = _S3_2;   playerField[3, 1] = _S4_2;
            playerField[0, 2] = _S1_3;   playerField[1, 2] = _S2_3;   playerField[2, 2] = _S3_3;   playerField[3, 2] = _S4_3;
            playerField[0, 3] = _S1_4;   playerField[1, 3] = _S2_4;   playerField[2, 3] = _S3_4;   playerField[3, 3] = _S4_4;
            playerField[0, 4] = _S1_5;   playerField[1, 4] = _S2_5;   playerField[2, 4] = _S3_5;   playerField[3, 4] = _S4_5;
            playerField[0, 5] = _S1_6;   playerField[1, 5] = _S2_6;   playerField[2, 5] = _S3_6;   playerField[3, 5] = _S4_6;
            playerField[0, 6] = _S1_Sub; playerField[1, 6] = _S2_Sub; playerField[2, 6] = _S3_Sub; playerField[3, 6] = _S4_Sub;

            playerField[0, 7] = _S1_7;     playerField[1, 7] = _S2_7;     playerField[2, 7] = _S3_7;     playerField[3, 7] = _S4_7;
            playerField[0, 8] = _S1_8;     playerField[1, 8] = _S2_8;     playerField[2, 8] = _S3_8;     playerField[3, 8] = _S4_8;
            playerField[0, 9] = _S1_9;     playerField[1, 9] = _S2_9;     playerField[2, 9] = _S3_9;     playerField[3, 9] = _S4_9;
            playerField[0, 10] = _S1_10;   playerField[1, 10] = _S2_10;   playerField[2, 10] = _S3_10;   playerField[3, 10] = _S4_10;
            playerField[0, 11] = _S1_11;   playerField[1, 11] = _S2_11;   playerField[2, 11] = _S3_11;   playerField[3, 11] = _S4_11;
            playerField[0, 12] = _S1_12;   playerField[1, 12] = _S2_12;   playerField[2, 12] = _S3_12;   playerField[3, 12] = _S4_12;
            playerField[0, 13] = _S1_13;   playerField[1, 13] = _S2_13;   playerField[2, 13] = _S3_13;   playerField[3, 13] = _S4_13;
            playerField[0, 14] = _S1_Sub2; playerField[1, 14] = _S2_Sub2; playerField[2, 14] = _S3_Sub2; playerField[3, 14] = _S4_Sub2;
            playerField[0, 15] = _S1_Tot;  playerField[1, 15] = _S2_Tot;  playerField[2, 15] = _S3_Tot;  playerField[3, 15] = _S4_Tot;

            if (players.Length > 0) { label1.Text =  players[0].name; label12.Text = players[0].name; };
            if (players.Length > 1) { label9.Text =  players[1].name; label4.Text = players[1].name; };
            if (players.Length > 2) { label11.Text = players[2].name; label2.Text = players[2].name; };
            if (players.Length > 3) { label10.Text = players[3].name; label3.Text = players[3].name; };

            for (int i = 0; i < players.Length; i++)
            { 
                for (int j = 0; j < 13; j++)
                {
                    players[i].buttons[j] = true;
                }
            }

            //Set the current player name
            label5.Text = players[curPlayer].name;
            label13.Text = maximaalAantalGooien.ToString();
        }

        private void button39_Click(object sender, EventArgs e) //Roll Dice
        {
            if (throwCount >= maximaalAantalGooien) { MessageBox.Show($"Je mag maar {maximaalAantalGooien} keer gooien", "oops"); return; }
            if (!rolling)
            {
                thrown = true; throwCount++;
                rolling = true;
                label13.Text = (maximaalAantalGooien - throwCount).ToString();
                DobbelsteenTimer.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Alleen vast zetten in frame 0
            if (animationFrame == 0)
            {
                vast[0] = checkBox1.Checked; vast[1] = checkBox2.Checked;
                vast[2] = checkBox5.Checked; vast[3] = checkBox4.Checked;
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
                animationFrame++; //Increase frame
                Dice.Randomize(); //Randomize
            }
        }

        private void update_Click(object sender, EventArgs e) //Update
        {
            if (rolling || !thrown) { MessageBox.Show("Je moet eerst gooien!",">:("); return; }
            thrown = false; throwCount = 0;

            //Buttons
            int[] toak = { 3, 4, 5 }; int[] carr = { 4, 5 }; int[] full = { 3, 2 }; int[] yath = { 5 }; int[] klst = { 1, 2, 3, 4, 5 }; int[] grst = { 2, 3, 4, 5, 6 };

            if ($"{sender}".Contains("Text: Een"))       {playerField[curPlayer,  0].Text = (Dice.Count[0] * 1).ToString(); players[curPlayer].buttons[0] = false; } //een
            if ($"{sender}".Contains("Text: Twee"))      {playerField[curPlayer,  1].Text = (Dice.Count[1] * 2).ToString(); players[curPlayer].buttons[1] = false; } //twee
            if ($"{sender}".Contains("Text: Drie"))      {playerField[curPlayer,  2].Text = (Dice.Count[2] * 3).ToString(); players[curPlayer].buttons[2] = false; } //drie
            if ($"{sender}".Contains("Text: Vier"))      {playerField[curPlayer,  3].Text = (Dice.Count[3] * 4).ToString(); players[curPlayer].buttons[3] = false; } //vier
            if ($"{sender}".Contains("Text: Vijf"))      {playerField[curPlayer,  4].Text = (Dice.Count[4] * 5).ToString(); players[curPlayer].buttons[4] = false; } //vijf
            if ($"{sender}".Contains("Text: Zes"))       {playerField[curPlayer,  5].Text = (Dice.Count[5] * 6).ToString(); players[curPlayer].buttons[5] = false; } //zes
            if ($"{sender}".Contains("Text: ToaK"))      {playerField[curPlayer,  7].Text = Dice.CountContains(toak,true) ? $"{Dice.Dices.Sum()}" : "0"; players[curPlayer].buttons[6] = false;}   //Toak
            if ($"{sender}".Contains("Text: Carré"))     {playerField[curPlayer,  8].Text = Dice.CountContains(carr, true) ? $"{Dice.Dices.Sum()}" : "0"; players[curPlayer].buttons[7] = false; } //Carre
            if ($"{sender}".Contains("Text: Full House")){playerField[curPlayer,  9].Text = Dice.CountContains(full, false) ? $"25" : "0"; players[curPlayer].buttons[8] = false; }                //Full house
            if ($"{sender}".Contains("Text: Kl. Straat")){playerField[curPlayer, 10].Text = $"{Convert.ToInt32(Dice.Match(klst)) * 30}"; players[curPlayer].buttons[9] = false; }                  //Kleine straat
            if ($"{sender}".Contains("Text: Gr. Straat")){playerField[curPlayer, 11].Text = $"{Convert.ToInt32(Dice.Match(grst)) * 40}"; players[curPlayer].buttons[10] = false; }                 //Grote straat
            if ($"{sender}".Contains("Text: Chance"))    {playerField[curPlayer, 12].Text = $"{Convert.ToInt32(Dice.Dices.Sum())}"; players[curPlayer].buttons[11] = false; }                      //Chance
            if ($"{sender}".Contains("Text: Yahtzee"))   {playerField[curPlayer, 13].Text = Dice.CountContains(yath, false) ? $"50" : "0"; players[curPlayer].buttons[12] = false; }               //Yahtzee
              
            //Calculate total
            int subTotal1 = 0; int subTotal2 = 0; int bonus = 0;

            for (int i = 0; i < 6; i++)
            {
                subTotal1 += (playerField[curPlayer, i].Text != "") ? Convert.ToInt32(playerField[curPlayer, i].Text) : 0;
                subTotal2 += (playerField[curPlayer, i+7].Text != "") ? Convert.ToInt32(playerField[curPlayer, i+7].Text) : 0;
            }

            //35 Bonus
            if (subTotal1 > 63) { bonus += 35; } 

            playerField[curPlayer,  6].Text = subTotal1.ToString();
            playerField[curPlayer, 14].Text = subTotal2.ToString();
            playerField[curPlayer, 15].Text = (subTotal1 + subTotal2).ToString();

            NextPlayer();

            //Disable buttons for next player
            Activate_One.Enabled = players[curPlayer].buttons[0]; Activate_TOAK.Enabled = players[curPlayer].buttons[6];
            Activate_Two.Enabled = players[curPlayer].buttons[1]; Activate_Carré.Enabled = players[curPlayer].buttons[7];
            Activate_Three.Enabled = players[curPlayer].buttons[2]; Activate_FullHouse.Enabled = players[curPlayer].buttons[8];
            Activate_Four.Enabled = players[curPlayer].buttons[3]; Activate_KleineStraat.Enabled = players[curPlayer].buttons[9];
            Activate_Five.Enabled = players[curPlayer].buttons[4]; Activate_GroteStraat.Enabled = players[curPlayer].buttons[10];
            Activate_Six.Enabled = players[curPlayer].buttons[5]; Activate_Chance.Enabled = players[curPlayer].buttons[11];
            Activate_Yahtzee.Enabled = players[curPlayer].buttons[12];

            Dice.Hide();
        }
    }
}
