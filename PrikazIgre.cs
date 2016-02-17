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
                null, panel2, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel3, new object[] { true });
        }

        void render(Panel pan, Oblik o, Brush p)
        {
            Bitmap bm = new Bitmap(pan.Size.Width, pan.Size.Height);
            Graphics g = Graphics.FromImage(bm);

            g.Clear(Color.White);

            double w = pan.Width / (4);
            double h = pan.Height / (4);

            if (o != null)
            for (int r = 0; r < 4; ++r)
            {
                for (int s = 0; s < 4; ++s)
                {
                    if (o[r, s])
                    g.FillRectangle(p, new Rectangle(
                         (int)(s * w),
                         (int)(r * h),
                         (int)(w),
                         (int)(h)
                         ));
                }
            }

            pan.BackgroundImage = bm;
        }

        void render()
        {
            Tetris.Kvadrat[,] ploca = igra.StanjePloce();
            Bitmap bm = new Bitmap(panel1.Size.Width, panel1.Size.Height);
            Graphics g = Graphics.FromImage(bm);

            g.Clear(Color.White);

            double w = panel1.Width / (2.0 + tig.Stupaca);
            double h = panel1.Height / (2.0 + tig.Redaka);

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
                    
                    g.FillRectangle(p, new Rectangle(
                        (int)(s * w),
                        (int)(r * h),
                        (int)(w),
                        (int)(h)
                        ));
                }
            }

            panel1.BackgroundImage = bm;
            render(panel2, igra.sljedeciOblikPrvi, Brushes.DarkBlue);
            render(panel3, igra.sljedeciOblikDrugi, Brushes.DarkGreen);
        }

        int countdown = 56;
        private void timer1_Tick(object sender, EventArgs e)
        {
            igra.Korak(countdown);
            lbl_bonus.Text = igra.NagradnihBodova().ToString();
            lbl_nivo.Text = (tig.Nivoi.IndexOf(igra.Nivo()) + 1).ToString() + ".";
            lbl_rez.Text = igra.Rezultat().ToString();
            lbl_smjer.Text = igra.Nivo().Smjer.ToString();

            countdown--;
            if (countdown == 0)
            {
                countdown = 28;
            }

            render();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //render();
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
