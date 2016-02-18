using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class PrikazIgre : Form
    {
        Tetris igra;
        TipIgre tig;
        Image img;  // tile
        Image img1; // tile
        Image img2; // pattern

        //proba
        Bitmap bit;
        Bitmap bit_sljedeci;

        public PrikazIgre()
        {
            InitializeComponent();
        }

        public PrikazIgre(TipIgre tig)
        {
            igra = new Tetris(tig);
            this.tig = tig;

            //tig.Nivoi[igra.trenutni_nivo].ViseLikova = true;

            //ucitavanje
            img = new Bitmap(Properties.Resources.tile_mask);
            img1 = new Bitmap(Properties.Resources.tile_mask);
            img2 = new Bitmap(Properties.Resources.pattern);

            InitializeComponent();

            //velicina kockice
            int velicina = 24;
            //resize kockice s obzirom na formu max(1000px, 800px)
            while((((tig.Stupaca + 2) * velicina) +300)>1000 && (((tig.Redaka + 2) * 24) + 20)> 800){
                velicina -= 2;
            }
            //resize forme
            this.ClientSize = new Size(((tig.Stupaca + 2) * velicina) + 300, ((tig.Redaka + 2) * velicina) + 20);
            this.panel1.Width = (tig.Stupaca + 2) * velicina;
            this.panel1.Height = (tig.Redaka + 2) * velicina;

            //resize bitmapa
            img1 = (Image)new Bitmap(img1, new Size(panelSljedeciPrvi.Width / 4, panelSljedeciPrvi.Height / 4));
            img = (Image)new Bitmap(img, new Size(panel1.Width / (tig.Stupaca + 2), panel1.Height / (tig.Redaka + 2)));
            img2 = (Image)new Bitmap(img2, new Size(panel1.Width / (tig.Stupaca + 2), panel1.Height / (tig.Redaka + 2)));

            //bitmap
            bit = new Bitmap(panel1.Size.Width, panel1.Size.Height);
            Graphics g = Graphics.FromImage(bit);

            g.Clear(Color.White);

            int w = panel1.Width / (tig.Stupaca + 2);
            int h = panel1.Height / (tig.Redaka + 2);

            for (int r = 0; r < tig.Redaka + 2; ++r)
            {
                for (int s = 0; s < tig.Stupaca + 2; ++s)
                {
                    if (r == 0 || s == 0 || r == (tig.Redaka + 1) || s == (tig.Stupaca + 1))
                    {
                        g.FillRectangle(Brushes.DarkGray, new Rectangle(new Point((s * w) + 1, (r * h) + 1), new Size(w - 3, h - 3)));
                        g.DrawImage(img, new Point(s * w, r * h));
                    }
                    else
                    {
                        g.DrawImage(img2, new Point(s * w, r * h));
                    }
                }
            }
            panel1.BackgroundImage = bit;
            
            //Bitmap sljedeci
            bit_sljedeci = new Bitmap(panelSljedeciPrvi.Size.Width, panelSljedeciPrvi.Size.Height);

            //label color
            this.label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");
            this.lbl_nivo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");
            this.label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");
            this.label5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");
            this.lbl_brzina.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel1, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panelSljedeciPrvi, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
                  BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                  null, panelSljedeciDrugi, new object[] { true });
        }

        void render(Panel pan, Oblik o, Brush p)
        {
            Bitmap bm = new Bitmap(bit_sljedeci);
            Graphics g = Graphics.FromImage(bm);

            int w = (pan.Width) / (4);
            int h = (pan.Height) / (4);

            if (o != null)
                 for (int r = 0; r < 4; ++r)
                 {
                     for (int s = 0; s < 4; ++s)
                     {
                        if (o[r, s])
                        {
                            g.FillRectangle(p, new Rectangle(new Point((s * w)+1, (r * h)+1), new Size(w - 3, h - 3)));
                            g.DrawImage(img, new Point(s * w, r * h));
                        }
                     }
                 }
           pan.BackgroundImage = bm;
        }

        void render()
        {
            Tetris.Kvadrat[,] ploca = igra.StanjePloce();
            Bitmap bm = new Bitmap(bit);
            Graphics g = Graphics.FromImage(bm);
            
            g.Clear(Color.White);

            int w = panel1.Width / (tig.Stupaca + 2);
            int h = panel1.Height / (tig.Redaka + 2);

            for (int r = 0; r < tig.Redaka + 2; ++r)
            {
                for (int s = 0; s < tig.Stupaca + 2; ++s)
                {
                    Brush p = Brushes.White;
                    switch (ploca[r, s])
                    {
                        case Tetris.Kvadrat.OkupiraPrviLik:
                            p = igra.SljedeciOblik().vratiBrush();
                            p = Brushes.Yellow;
                            break;
                        case Tetris.Kvadrat.DeaktiviraniPrvi:
                            p = igra.SljedeciOblik().vratiBrush();
                            p = Brushes.Yellow;
                            break;
                        case Tetris.Kvadrat.OkupiraPrepreka:
                            p = Brushes.DarkGray;
                            break;
                        case Tetris.Kvadrat.OkupiraDrugiLik:
                            p = Brushes.LightGreen;
                            break;
                        case Tetris.Kvadrat.DeaktiviraniDrugi:
                            p = Brushes.DarkGreen;
                            break;
                        case Tetris.Kvadrat.OkupiraNagradni:
                            p = Brushes.Yellow;
                            break;
                        default:
                            break;
                    }
                    if (ploca[r, s] != 0)
                    {
                        g.FillRectangle(p, new Rectangle(new Point((s * w) + 1, (r * h) + 1), new Size(w - 3, h - 3)));
                        g.DrawImage(img, new Point(s * w, r * h));
                    }
                    else
                        g.DrawImage(img2, new Point(s * w, r * h));
                }
            }

            panel1.BackgroundImage = bm;

            render(panelSljedeciPrvi, igra.sljedeciOblikPrvi, Brushes.Yellow);

            //ako imamo dvostruki lik
            if (tig.Nivoi[igra.trenutni_nivo].ViseLikova == true)
                render(panelSljedeciDrugi, igra.sljedeciOblikDrugi, Brushes.DarkGreen);
        }

        int countdown = 56;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled && !igra.GotovaIgra())
            {
                igra.Korak(countdown);
                lbl_rez.Text = igra.Rezultat().ToString();
                lbl_bonus.Text = igra.NagradnihBodova().ToString();
                lbl_nivo.Text = "Nivo: " + (igra.trenutni_nivo + 1);
                lbl_brzina.Text = "Brzina: " + (tig.Nivoi[igra.trenutni_nivo].Brzina) + "x";

                switch (tig.Nivoi[igra.trenutni_nivo].Smjer)
                {
                    case Smjerovi.Dolje:
                        pictureBox1.Image = Properties.Resources.smjer_dolje;
                        break;
                    case Smjerovi.Desno:
                        pictureBox1.Image = Properties.Resources.smjer_desno;
                        break;
                    case Smjerovi.Lijevo:
                        pictureBox1.Image = Properties.Resources.smjer_lijevo;
                        break;
                    case Smjerovi.Gore:
                        pictureBox1.Image = Properties.Resources.smjer_gore;
                        break;
                }

                if (tig.Nivoi[igra.trenutni_nivo].ViseLikova == true)
                {
                    panel7.Visible = true;
                    panelSljedeciDrugi.Visible = true;
                    pictureBox1.Location = new Point(pictureBox1.Location.X, panel7.Location.Y + 140);
                    if (this.ClientSize.Height < 580)
                    {
                        this.ClientSize = new Size(this.ClientSize.Width, 580);
                    }
                }
                else
                {
                    panel7.Visible = false;
                    panelSljedeciDrugi.Visible = false;
                    pictureBox1.Location = new Point(pictureBox1.Location.X, panel7.Location.Y);
                    if (this.ClientSize.Height < pictureBox1.Location.Y + 70)
                    {
                        this.ClientSize = new Size(this.ClientSize.Width, pictureBox1.Location.Y + 70);
                    }
                }

            }
            else
            {
                timer1.Enabled = false;
            }       

            countdown--;
            if (countdown == 0)
            {
                countdown = 28;
            }

            render();
        }

        private void PrikazIgre_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        0, Smjerovi.Gore);
                    break;
                case Keys.Down:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        0, Smjerovi.Dolje);
                    break;
                case Keys.Left:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        0, Smjerovi.Lijevo);
                    break;
                case Keys.Right:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        0, Smjerovi.Desno);
                    break;
                case Keys.W:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        1, Smjerovi.Gore);
                    break;
                case Keys.S:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        1, Smjerovi.Dolje);
                    break;
                case Keys.A:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        1, Smjerovi.Lijevo);
                    break;
                case Keys.D:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Pomak,
                        1, Smjerovi.Desno);
                    break;
                case Keys.Return:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Rotacija,
                        0, Smjerovi.Gore);
                    break;
                case Keys.Space:
                    igra.ZatraziAkciju(Tetris.TipInterakcije.Rotacija,
                        1, Smjerovi.Gore);
                    break;
            }
        }

    }
}
