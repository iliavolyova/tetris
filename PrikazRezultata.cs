using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class PrikazRezultata : UserControl
    {
        string _tipigre;
        public string tipigre {
            get
            {
                return _tipigre;
            }
            set
            {
                _tipigre = value;
                foreach (var rez in Postavke.RezultatiZa(value))
                    listView1.Items.Add(new ListViewItem(new string[]{
                        rez.Item2.ToString(), rez.Item3.ToString(), rez.Item1.ToString()
                    }));
            }
        }


        public PrikazRezultata()
        {
            InitializeComponent();
            tipigre = "nepoznat";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
