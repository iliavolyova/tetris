using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Drawing;

namespace Tetris
{
    public class Oblik
    {
        // tip oblika
        public string Ime { get; set; }

        public bool[,] Celije { get; set; }

        public Color Boja { get; set; } 

        public bool this[int r, int s]
        {
            get
            {
                return Celije[r, s];
            }
            set
            {
                Celije[r, s] = value;
            }
        }

        public Oblik(string _Ime = "", bool[,] _Celije = null, Color? _Boja = null)
        {
            Ime = _Ime;
            Celije = _Celije ?? new bool[4, 4];
            Boja = _Boja ?? Color.Red;
        }

        public static Oblik NapraviOblik(XElement x)
        {
            Oblik o = new Oblik();
            o.FromXML(x);
            return o;
        }

        private string celije_u_string()
        {
            string rez = "";
            for (int i = 0; i < 16; ++i)
                rez += Celije[i / 4, i % 4] ? "1" : "0";
            return rez;
        }

        private void celije_iz_stringa(string s)
        {
            for (int i = 0; i < 16; ++i)
                Celije[i / 4, i % 4] = (s[i] == '1');
        }

        public XElement ToXML()
        {
            return new XElement("oblik",
                new XAttribute("ime", Ime),
                new XAttribute("celije", celije_u_string()),
                new XAttribute("boja", Boja.ToArgb().ToString()));
        }

        public void FromXML(XElement x)
        {
            Ime = x.Attribute("ime").Value;
            celije_iz_stringa(x.Attribute("celije").Value);
            //Boja = Color.FromArgb(int.Parse(x.Attribute("boja").Value));
        }




        // instancirani oblik
        public Tuple<int, int> Pozicija { get; set; }

        public bool[,] SimulirajRotaciju()
        {
            bool[,] ret = new bool[4, 4];

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    ret[i, j] = Celije[4 - j - 1, i];
                }
            }

            return ret;
        }

        public void Rotiraj()
        {
            bool[,] ret = new bool[4, 4];

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    ret[i, j] = Celije[4 - j - 1, i];
                }
            }

            Celije = ret;
        }

    }
}
