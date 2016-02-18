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
    public partial class UredivanjeOblika : Form
    {
        public UredivanjeOblika()
        {
            InitializeComponent();
        }

        private void UredivanjeOblika_Load(object sender, EventArgs e)
        {
            foreach (Oblik o in Postavke.Oblici)
            {
                listBox1.Items.Add(o.Ime);
            }

            foreach (CheckBox c in panel1.Controls)
            {
                c.CheckedChanged += c00_CheckedChanged;
            }

            panel1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // brisanje
            if (listBox1.SelectedIndex != -1)
            {
                prikazivanje_u_tijeku = true;
                foreach (CheckBox c in panel1.Controls)
                    c.Checked = false;
                prikazivanje_u_tijeku = false;

                Postavke.Oblici.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                Postavke.Pohrani();
                aktivni_oblik = -1;
                panel1.Enabled = false;
            }
        }

        int aktivni_oblik = -1;

        bool prikazivanje_u_tijeku = false;
        void prikazi()
        {
            prikazivanje_u_tijeku = true;
            panel1.Enabled = true;
            foreach (Control c in panel1.Controls)
                c.Enabled = true;

            Oblik o = Postavke.Oblici[aktivni_oblik];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string ime_g = "c" + i.ToString() + j.ToString();
                    Control[] r = panel1.Controls.Find(ime_g, false);
                    ((CheckBox)r[0]).Checked = o[i, j];
                }
            }
            panel2.BackColor = o.Boja;
            prikazivanje_u_tijeku = false;
        }

        void pohrani()
        {
            if (prikazivanje_u_tijeku)
                return;

            Oblik o = Postavke.Oblici[aktivni_oblik];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string ime_g = "c" + i.ToString() + j.ToString();
                    Control[] r = panel1.Controls.Find(ime_g, false);
                    o[i, j] = ((CheckBox)r[0]).Checked;
                }
            }
            o.Boja = panel2.BackColor;
            Postavke.Pohrani();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // uredivanje
            if (listBox1.SelectedIndex != -1)
            {
                aktivni_oblik = listBox1.SelectedIndex;
                prikazi();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // dodavanje
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nazovite novi oblik:", "Novi oblik", "");
            if (input == "" || (listBox1.Items.IndexOf(input) != -1))
            {
                MessageBox.Show("Ime oblika mora biti neprazno i jedinstveno.");
            }
            else
            {
                listBox1.Items.Add(input);
                Postavke.Oblici.Add(new Oblik(input));

                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                aktivni_oblik = listBox1.Items.Count - 1;
                
                //prikazi();
                pohrani();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // uredivanje
            if (listBox1.SelectedIndex != -1)
            {
                aktivni_oblik = listBox1.SelectedIndex;
                prikazi();
            }
        }

        private void c00_CheckedChanged(object sender, EventArgs e)
        {
            if (aktivni_oblik != -1)
                pohrani();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (aktivni_oblik != -1)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    panel2.BackColor = colorDialog1.Color;
                    pohrani();
                }
            }
        }
    }
}
