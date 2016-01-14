using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace Tetris
{

    public enum Smjerovi
    {
        Dolje,
        Gore,
        Lijevo,
        Desno
    };

    public class TipNivoa
    {

        public int ID { get; set; }

        public List<Oblik> Oblici { get; set; }

        public int Brzina { get; set; }

        public Smjerovi Smjer { get; set; }

        public bool NagradniKvadratici,
            ViseLikova,
            Prepreke;

        public TipNivoa(int _ID = 0, List<Oblik> _Oblici = null, int _Brzina = 1, Smjerovi _Smjer = Smjerovi.Dolje,
            bool _NagKv = false, bool _ViLik = false, bool _Prep = false)
        {
            ID = _ID; Brzina = _Brzina; Smjer = _Smjer;
            NagradniKvadratici = _NagKv; ViseLikova = _ViLik; Prepreke = _Prep;

            Oblici = _Oblici ?? new List<Oblik>();
        }

        public static TipNivoa NapraviTipNivoa(XElement x)
        {
            TipNivoa t = new TipNivoa();
            t.FromXML(x);
            return t;
        }

        public XElement ToXML()
        {
            var novi = new XElement("nivo",
                new XAttribute("id", ID.ToString()),
                new XAttribute("brzina", Brzina.ToString()),
                new XAttribute("nagradnikvadratici", NagradniKvadratici),
                new XAttribute("viselikova", ViseLikova),
                new XAttribute("smjer", Smjer.ToString()),
                new XAttribute("prepreke", Prepreke));
            foreach (var o in Oblici)
                novi.Add(o.ToXML());
            return novi;
        }

        public void FromXML(XElement x)
        {
            ID = int.Parse(x.Attribute("id").Value);
            Brzina = int.Parse(x.Attribute("brzina").Value);
            NagradniKvadratici = bool.Parse(x.Attribute("nagradnikvadratici").Value);
            Prepreke = bool.Parse(x.Attribute("prepreke").Value);
            ViseLikova = bool.Parse(x.Attribute("viselikova").Value);
            Smjer = (Smjerovi) Enum.Parse(typeof(Smjerovi), x.Attribute("smjer").Value);
            foreach (var o in x.Elements("oblik"))
            {
                Oblik c = Postavke.Oblici.Find(obl => obl.Ime == o.Attribute("ime").Value);
                if (c != null)
                    Oblici.Add(c);
            }
        }
    }

    public class TipIgre
    {
        public string Ime { get; set; }

        public List<TipNivoa> Nivoi { get; set; }

        public int Redaka { get; set; }

        public int Stupaca { get; set; }


        public TipIgre(string _Ime = "", List<TipNivoa> _Nivoi = null,
            int _Redaka = 8, int _Stupaca = 8)
        {
            Ime = _Ime;
            Redaka = _Redaka;
            Stupaca = _Stupaca;
            Nivoi = _Nivoi ?? new List<TipNivoa>(new TipNivoa[3] {
                new TipNivoa(0), new TipNivoa(1), new TipNivoa(2)
            });
        }

        public static TipIgre NapraviTipIgre(XElement x)
        {
            TipIgre t = new TipIgre();
            t.FromXML(x);
            return t;
        }

        public XElement ToXML()
        {
            var novi = new XElement("igra",
                new XAttribute("ime", Ime),
                new XAttribute("redaka", Redaka.ToString()),
                new XAttribute("stupaca", Stupaca.ToString()));
            foreach (var o in Nivoi)
                novi.Add(o.ToXML());
            return novi;
        }

        public void FromXML(XElement x)
        {
            Ime = x.Attribute("ime").Value;
            Redaka = int.Parse(x.Attribute("redaka").Value);
            Stupaca = int.Parse(x.Attribute("stupaca").Value);
            Nivoi.Clear();
            foreach (var o in x.Elements("nivo"))
                Nivoi.Add(TipNivoa.NapraviTipNivoa(o));
        }

    }
}
