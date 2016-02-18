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
    public partial class UredivanjeTipova : Form
    {
        public UredivanjeTipova()
        {
            InitializeComponent();
        }

        private void UredivanjeTipIgrea_Load(object sender, EventArgs e)
        {
            foreach (TipIgre o in Postavke.TipoviIgara)
            {
                listBox1.Items.Add(o.Ime);
            }

            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                    ((CheckBox)c).CheckedChanged += c00_CheckedChanged;
            }

            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // brisanje
            if (listBox1.SelectedIndex != -1)
            {
                prikazivanje_u_tijeku = true;
                panel1.Hide();
                prikazivanje_u_tijeku = false;

                Postavke.TipoviIgara.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                Postavke.Pohrani();
                aktivni_tipigre = -1;
            }
        }

        int aktivni_tipigre = -1;

        bool prikazivanje_u_tijeku = false;
        void prikazi()
        {
            prikazivanje_u_tijeku = true;
            panel1.Show();

            TipIgre t = Postavke.TipoviIgara[aktivni_tipigre];
            this.numericUpDown1.Value = t.Redaka;
            this.numericUpDown2.Value = t.Stupaca;
            checkBox1.Checked = t.Nivoi[0].NagradniKvadratici;
            checkBox2.Checked = t.Nivoi[0].Prepreke;
            checkBox3.Checked = t.Nivoi[0].ViseLikova;
            checkBox6.Checked = t.Nivoi[1].NagradniKvadratici;
            checkBox5.Checked = t.Nivoi[1].Prepreke;
            checkBox4.Checked = t.Nivoi[1].ViseLikova;
            checkBox9.Checked = t.Nivoi[2].NagradniKvadratici;
            checkBox8.Checked = t.Nivoi[2].Prepreke;
            checkBox7.Checked = t.Nivoi[2].ViseLikova;
            trackBar1.Value = t.Nivoi[0].Brzina;
            trackBar2.Value = t.Nivoi[1].Brzina;
            trackBar3.Value = t.Nivoi[2].Brzina;
            comboBox1.SelectedItem = t.Nivoi[0].Smjer.ToString();
            comboBox2.SelectedItem = t.Nivoi[1].Smjer.ToString();
            comboBox3.SelectedItem = t.Nivoi[2].Smjer.ToString();


            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            foreach (Oblik o in Postavke.Oblici)
            {
                checkedListBox1.Items.Add(o.Ime,
                    t.Nivoi[0].Oblici.Count(obl => obl.Ime == o.Ime) == 1);
                checkedListBox2.Items.Add(o.Ime,
                    t.Nivoi[1].Oblici.Count(obl => obl.Ime == o.Ime) == 1);
                checkedListBox3.Items.Add(o.Ime,
                    t.Nivoi[2].Oblici.Count(obl => obl.Ime == o.Ime) == 1);
            }

            prikazivanje_u_tijeku = false;
        }

        void pohrani()
        {
            if (prikazivanje_u_tijeku)
                return;

            TipIgre t = Postavke.TipoviIgara[aktivni_tipigre];
            t.Redaka = (int)this.numericUpDown1.Value;
            t.Stupaca = (int)this.numericUpDown2.Value;
            t.Nivoi[0].NagradniKvadratici = checkBox1.Checked;
            t.Nivoi[0].Prepreke = checkBox2.Checked;
            t.Nivoi[0].ViseLikova = checkBox3.Checked;
            t.Nivoi[1].NagradniKvadratici = checkBox6.Checked;
            t.Nivoi[1].Prepreke = checkBox5.Checked;
            t.Nivoi[1].ViseLikova = checkBox4.Checked;
            t.Nivoi[2].NagradniKvadratici = checkBox9.Checked;
            t.Nivoi[2].Prepreke = checkBox8.Checked;
            t.Nivoi[2].ViseLikova = checkBox7.Checked;
            t.Nivoi[0].Brzina = trackBar1.Value;
            t.Nivoi[1].Brzina = trackBar2.Value;
            t.Nivoi[2].Brzina = trackBar3.Value;
            t.Nivoi[0].Smjer = (Smjerovi)Enum.Parse(typeof(Smjerovi), comboBox1.SelectedItem.ToString());
            t.Nivoi[1].Smjer = (Smjerovi)Enum.Parse(typeof(Smjerovi), comboBox2.SelectedItem.ToString());
            t.Nivoi[2].Smjer = (Smjerovi)Enum.Parse(typeof(Smjerovi), comboBox3.SelectedItem.ToString());

            t.Nivoi[0].Oblici.Clear();
            t.Nivoi[1].Oblici.Clear();
            t.Nivoi[2].Oblici.Clear();
            int i = 0;
            foreach (Oblik o in Postavke.Oblici)
            {
                if (checkedListBox1.GetItemChecked(i))
                    t.Nivoi[0].Oblici.Add(o);
                if (checkedListBox2.GetItemChecked(i))
                    t.Nivoi[1].Oblici.Add(o);
                if (checkedListBox3.GetItemChecked(i))
                    t.Nivoi[2].Oblici.Add(o);

                ++i;
            }

          
            Postavke.Pohrani();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // uredivanje
            if (listBox1.SelectedIndex != -1)
            {
                aktivni_tipigre = listBox1.SelectedIndex;
                prikazi();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // dodavanje
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nazovite novi tip igre:", "Novi tip igre", "");
            if ((input == "") || (listBox1.Items.IndexOf(input) != -1))
            {
                MessageBox.Show("Ime tipa igre mora biti neprazno i jedinstveno.");
            }
            else
            {
                listBox1.Items.Add(input);
                Postavke.TipoviIgara.Add(new TipIgre(input));

                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                aktivni_tipigre = listBox1.Items.Count - 1;
                
                //prikazi();
                pohrani();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // uredivanje
            if (listBox1.SelectedIndex != -1)
            {
                aktivni_tipigre = listBox1.SelectedIndex;
                prikazi();
            }
        }

        private void c00_CheckedChanged(object sender, EventArgs e)
        {
            if (aktivni_tipigre != -1)
                pohrani();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkedListBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            c00_CheckedChanged(sender, e);
        }
    }
}
