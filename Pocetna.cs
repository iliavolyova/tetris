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
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();
        }

        private void postavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new UredivanjeTipova()).ShowDialog();
        }

        private void novaIgraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void novaigra_handle(object sender, EventArgs e)
        {
            string tig = ((PrikazRezultata)((Button)sender).Parent).tipigre;
            new PrikazIgre(Postavke.TipoviIgara.Find(t => t.Ime == tig)).ShowDialog();
            ((PrikazRezultata)tabControl1.SelectedTab.Controls[0]).tipigre = tig; // reload rezultata
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();

            foreach (TipIgre t in Postavke.TipoviIgara)
            {
                TabPage tp = new TabPage();
                PrikazRezultata pr = new PrikazRezultata();
                tp.Text = pr.tipigre = t.Ime;

                pr.Parent = tp;
                //pr.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                pr.Dock = DockStyle.Fill;
                tp.Controls.Add(pr);


                pr.button1.Click += novaigra_handle;

                this.SuspendLayout();
                tabControl1.TabPages.Add(tp);
               
                this.ResumeLayout(false);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void oIgriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new OIgri()).Show();
        }

        private void urediOblikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new UredivanjeOblika()).ShowDialog();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pravilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pravila pravila = new Pravila();
            pravila.Show();
        }
    }
}
