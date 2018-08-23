using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yathzee
{
    public partial class Menu : Form
    {
        private static List<Player> players = new List<Player>();

        public Menu()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Player nw = new Player() { name = textBox1.Text, buttons = new bool[6] };
                players.Add(nw);
            }

            if (textBox4.Text != "")
            {
                Player nw = new Player() { name = textBox4.Text, buttons = new bool[6] };
                players.Add(nw);
            }

            if (textBox5.Text != "")
            {
                Player nw = new Player() { name = textBox5.Text, buttons = new bool[6] };
                players.Add(nw);
            }

            if (textBox3.Text != "")
            {
                Player nw = new Player() { name = textBox3.Text, buttons = new bool[6] };
                players.Add(nw);
            }


            this.Hide();
            Form newGame = new Game(players.ToArray());
            newGame.Show();

        }
    }
}
