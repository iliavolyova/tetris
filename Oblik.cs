using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace Tetris
{
    public class Oblik
    {
        public string Ime { get; set; }

        public bool[,] Celije { get; set; }

        public Tuple<int, int> Pozicija { get; set; }

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


        public Oblik(string _Ime = "", bool[,] _Celije = null)
        {
            Ime = _Ime;
            Celije = _Celije ?? new bool[4, 4];
        }

        public static Oblik NapraviOblik(XElement x)
        {
            Oblik o = new Oblik();
            o.FromXML(x);
            return o;
        }

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
                new XAttribute("celije", celije_u_string()));
        }

        public void FromXML(XElement x)
        {
            Ime = x.Attribute("ime").Value;
            celije_iz_stringa(
                x.Attribute("celije").Value
                //Postavke.Oblici.Find(obl => obl.Ime == Ime).celije_u_string()
            );
        }
    }
}
