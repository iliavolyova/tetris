using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Pravila : Form
    {
        private PictureBox[] gumbi;
        private Panel[] paneli;

        public Pravila()
        {
            InitializeComponent();

            gumbi = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            paneli = new Panel[] { panelPravila, panelDvostruki, panelNagradniBodovi, panelPrepreke };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            oznaciGumb(0);
            prikaziPanel(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            oznaciGumb(1);
            prikaziPanel(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            oznaciGumb(2);
            prikaziPanel(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            oznaciGumb(3);
            prikaziPanel(3);
        }

        private void oznaciGumb(int poz)
        {
            for(int i = 0; i < gumbi.Count(); i++)
            {
                if (i == poz) gumbi[i].Image = Properties.Resources.button_on;
                else
                    gumbi[i].Image = Properties.Resources.button;
            }
        }
        
        private void prikaziPanel(int poz)
        {
            for(int i = 0; i < paneli.Count(); i++)
            {
                if (i == poz) paneli[i].Visible = true;
                else paneli[i].Visible = false;
            }
        }
    }
}
