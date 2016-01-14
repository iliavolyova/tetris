using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace Tetris
{
    static class Postavke
    {
        private static string adresa_postavki;

        public static List<TipIgre> TipoviIgara { get; set; }
        public static List<Oblik> Oblici { get; set; }

        private static Dictionary<string, List<Tuple<int, string, int>>> Rezultati {get; set;}

        public static XElement ToXML()
        {
            var novi = new XElement("tetris");

            foreach (var o in TipoviIgara)
                novi.Add(o.ToXML());

            foreach (var o in Oblici)
                novi.Add(o.ToXML());

            foreach (var o in Rezultati.Keys)
                foreach (var r in Rezultati[o])
                    novi.Add(new XElement("rezultat",
                        new XAttribute("tipigre", o),
                        new XAttribute("igrac", r.Item2),
                        new XAttribute("nivo", r.Item3),
                        new XAttribute("bodovi", r.Item1)));

            return novi;
        }

        public static void DodajRezultat(string tipigre, string igrac,
            int nivo, int bodovi)
        {
            if (!Rezultati.ContainsKey(tipigre))
                Rezultati[tipigre] = new List<Tuple<int, string, int>>();

            Rezultati[tipigre].Add(new Tuple<int, string, int>(bodovi, igrac,
                nivo));
        }

        public static List<Tuple<int,string,int>> RezultatiZa(string tipigre)
        {
            if (!Rezultati.ContainsKey(tipigre))
                Rezultati[tipigre] = new List<Tuple<int, string, int>>();

            Rezultati[tipigre].Sort((r1, r2) => -r1.Item1.CompareTo(r2.Item1));

            return Rezultati[tipigre];
        }


        public static void FromXML(XElement x)
        {
            foreach (var o in x.Elements("oblik"))
                Oblici.Add(Oblik.NapraviOblik(o));

            foreach (var o in x.Elements("igra"))
                TipoviIgara.Add(TipIgre.NapraviTipIgre(o));

            foreach (var o in x.Elements("rezultat"))
            {
                DodajRezultat(o.Attribute("tipigre").Value,
                    o.Attribute("igrac").Value,
                    int.Parse(o.Attribute("nivo").Value),
                    int.Parse(o.Attribute("bodovi").Value));
            }

        }

        public static void Pohrani()
        {
            XDocument xdoc = new XDocument();
            xdoc.Add(ToXML());
            xdoc.Save(adresa_postavki);

            //System.Windows.Forms.MessageBox.Show(xdoc.ToString());
        }
        
        public static void Ucitaj()
        {
            if (adresa_postavki == null)
                throw new Exception("Objekt Postavke nije inicijaliziran");

            TipoviIgara.Clear();
            Oblici.Clear();
            Rezultati.Clear();
            XDocument xdoc = XDocument.Load(adresa_postavki);
            FromXML(xdoc.Root);
        }

        public static void Init(string _AdresaPostavki)
        {
            adresa_postavki = _AdresaPostavki;
            Ucitaj();
        }

        static Postavke()
        {
            adresa_postavki = null;

            TipoviIgara = new List<TipIgre>();
            Oblici = new List<Oblik>();
            Rezultati = new Dictionary<string, List<Tuple<int, string, int>>>();
        }
  

    }
}
