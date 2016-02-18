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

        public PrikazIgre()
        {
            InitializeComponent();
        }

        public PrikazIgre(TipIgre tig)
        {
            igra = new Tetris(tig);
            this.tig = tig;

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

            //label color
            this.label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");
            this.label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");
            this.label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");
            this.label5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#282d34");

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
                null, panel5, new object[] { true });
          /*  typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel3, new object[] { true });*/
        }

        void render(Panel pan, Oblik o, Brush p)
        {
            Bitmap bm = new Bitmap(pan.Size.Width, pan.Size.Height);

            Image img = new Bitmap(Properties.Resources.tile_mask);
            Graphics g = Graphics.FromImage(bm);

            int w = (pan.Width) / (4);
            int h = (pan.Height) / (4);

            img = (Image)new Bitmap(img, new Size(w, h));

            if (o != null)
                 for (int r = 0; r < 4; ++r)
                 {
                     for (int s = 0; s < 4; ++s)
                     {
                        if (o[r, s])
                        {
                            //hardcoded
                            p = Brushes.Yellow;
                            g.FillRectangle(p, new Rectangle(new Point((s * w)+1, (r * h)+1), new Size(w-2, h-2)));
                            g.DrawImage(img, new Point(s * w, r * h));
                        }
                     }
                 }
            pan.BackgroundImage = bm;
        }

        void render()
        {
            Tetris.Kvadrat[,] ploca = igra.StanjePloce();
            Bitmap bm = new Bitmap(panel1.Size.Width, panel1.Size.Height);
            Graphics g = Graphics.FromImage(bm);

            Image img = new Bitmap(Properties.Resources.tile_mask);
            Image img1 = new Bitmap(Properties.Resources.pattern);

            g.Clear(Color.White);

            int w = panel1.Width / (tig.Stupaca + 2);
            int h = panel1.Height / (tig.Redaka + 2);

            img = (Image)new Bitmap(img, new Size(w, h));
            img1 = (Image)new Bitmap(img1, new Size(w, h));

            for (int r = 0; r < tig.Redaka + 2; ++r)
            {
                for (int s = 0; s < tig.Stupaca + 2; ++s)
                {
                    Brush p = Brushes.White;
                    switch (ploca[r, s])
                    {
                        case Tetris.Kvadrat.OkupiraPrviLik:
                            p = Brushes.LightBlue;
                            break;
                        case Tetris.Kvadrat.DeaktiviraniPrvi:
                            p = Brushes.DarkBlue;
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
                        //p = igra.SljedeciOblik().Boja;
                        g.FillRectangle(p, new Rectangle(new Point((s * w)+1, (r * h)+1), new Size(w-2, h-2)));
                        g.DrawImage(img, new Point(s * w, r * h));
                    }
                    else
                        g.DrawImage(img1, new Point(s * w, r * h));
                }
            }

            panel1.BackgroundImage = bm;
            
            render(panel5, igra.sljedeciOblikPrvi, Brushes.DarkBlue);
            /* render(panel3, igra.SljedeciDrugiOblik(), Brushes.DarkGreen);*/
        }

        int countdown = 56;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled && !igra.GotovaIgra())
            {
                igra.Korak(countdown);
                label2.Text = igra.Rezultat().ToString();

            }
            else
            {
                timer1.Enabled = false;
            }
            
          /*  lbl_bonus.Text = igra.NagradnihBodova().ToString();
            lbl_nivo.Text = (tig.Nivoi.IndexOf(igra.Nivo()) + 1).ToString() + ".";
            lbl_rez.Text = igra.Rezultat().ToString();
            lbl_smjer.Text = igra.Nivo().Smjer.ToString();*/

            countdown--;
            if (countdown == 0)
            {
                countdown = 28;
            }

            render();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           // render();
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
