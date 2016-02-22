using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public class Tetris
    {
        TipIgre tip_igre;
        Kvadrat[,] ploca;

        public int trenutni_nivo { get; set; }
        int rezultat { get; set; }
        int nagradni_bodovi { get; set; }

        bool gotovaIgra { get; set; }

        public Oblik aktivniOblikPrvi { get; set; }
        public Oblik aktivniOblikDrugi { get; set; }

        public Oblik sljedeciOblikPrvi { get; set; }
        public Oblik sljedeciOblikDrugi { get; set; }

        public Tetris(TipIgre _tip_igre)
        {
            tip_igre = _tip_igre;
            trenutni_nivo = 0;
            rezultat = 0;
            nagradni_bodovi = 0;
            gotovaIgra = false;
            novaPloca();
        }

        public enum Kvadrat
        {
            Slobodan,
            OkupiraPrviLik,
            OkupiraDrugiLik,
            DeaktiviraniPrvi,
            DeaktiviraniDrugi,
            OkupiraNagradni,
            OkupiraPrepreka 
        }

        private void novaPloca()
        {
            // + 2 zbog okvira od prepreka
            ploca = new Kvadrat[tip_igre.Redaka + 2, tip_igre.Stupaca + 2];

            // okvir od prepreka
            for (int i = 0; i < tip_igre.Stupaca + 2; ++i)
                ploca[0, i] = ploca[tip_igre.Redaka + 1, i] = Kvadrat.OkupiraPrepreka;

            for (int i = 0; i < tip_igre.Redaka + 2; ++i)
                ploca[i, 0] = ploca[i, tip_igre.Stupaca + 1] = Kvadrat.OkupiraPrepreka;

            for (int i = 0; i < tip_igre.Redaka; ++i)
                for (int j = 0; j < tip_igre.Stupaca; j++)
                    ploca[i + 1, j + 1] = Kvadrat.Slobodan;

            if (tip_igre.Nivoi[trenutni_nivo].Prepreke)
            {
                postaviPrepreke();
            }

        }

        public Kvadrat[,] StanjePloce()
        {
            return ploca;
        }

        public Oblik SljedeciOblik()
        {
            Oblik odabrani = Nivo().sljedeciOblik();
            return Oblik.copy(odabrani);
        }

        public Oblik SljedeciDrugiOblik()
        {
            // ako je tip_igre.Nivoi[trenutni_nivo].ViseOblika true,
            // i ako je igra odlucila da ce dati dva oblika, onda funkcija
            // vraca taj drugi oblik (inace null)

            TipNivoa nivo = Nivo();

            if (nivo.NagradniKvadratici == true && nivo.Oblici.Count == 2)
            {
                return nivo.Oblici[1];
            }
            else
            {
                return null;
            }
            
        }

        public int Rezultat()
        {
            return rezultat;
        }

        public int NagradnihBodova()
        {
            return nagradni_bodovi;
        }

        public TipNivoa Nivo()
        {
            return tip_igre.Nivoi[trenutni_nivo];
        }

        private void iduciNivo(){
            trenutni_nivo += 1;
            if (tip_igre.Nivoi.Count <= trenutni_nivo)
            {
                gotovaIgra = true;
                PohraniRezultat();
            }
            else
            {
                novaPloca();
            }
        }

        public bool GotovaIgra()
        {
            return gotovaIgra;
        }

        public enum TipInterakcije
        {
            Pomak,
            Rotacija
        }
        
        public void ZatraziAkciju(TipInterakcije tip, 
            int redni_broj_lika, Smjerovi smjer)
        {
            Kvadrat likZaPomicanje = redni_broj_lika == 0 ? 
                Kvadrat.OkupiraPrviLik : Kvadrat.OkupiraDrugiLik;


            switch (tip)
            {
                case TipInterakcije.Pomak:
                    if (mozePomak(likZaPomicanje, smjer))
                    {
                        pomakni(likZaPomicanje, smjer);
                    }
                    break;
                case TipInterakcije.Rotacija:
                    if (mozeRotacija(likZaPomicanje))
                    {
                        rotiraj(likZaPomicanje);
                    }
                    break;
                default:
                    break;
            }
        }

        // poziva se 30x u sek pa bi neke iteracije trebalo preskociti
        // ovisno o tip_igre.Brzina (1 najsporija igra, 7 najbrza)
        public void Korak(int countdown)
        {
            if (countdown % 4 == 0 && countdown / 4 <= Nivo().Brzina)
            {
                if (!gotovaIgra)
                {
                    gravitacijaAktivni(Kvadrat.OkupiraPrviLik);
                    if (!gotovaIgra)
                        pocistiPopunjeno();
                }
            }
        }

        private void postaviPrepreke()
        {
            Random gen = new Random();

            for (int i = (tip_igre.Redaka/3); i < tip_igre.Redaka-1; ++i)
                for (int j = 1; j < tip_igre.Stupaca-1; j++)
                    if (gen.NextDouble() < 0.02)
                        ploca[i, j] = Kvadrat.OkupiraPrepreka;
        }

        private void gravitacijaAktivni(Kvadrat lik)
        {
            if (postojiAktivan(lik))
            {
                if (mozePomak(lik, Nivo().Smjer))
                {
                    pomakni(lik, Nivo().Smjer);
                }
                else
                {
                    deaktiviraj(lik);
                }
            }
            else
            {   
                if(!inicijaliziraj(lik)){
                    iduciNivo();
                }
            }
            
        }

        private bool mozeRotacija(Kvadrat kojiLik)
        {
            Oblik koji = kojiLik == Kvadrat.OkupiraPrviLik ? aktivniOblikPrvi : aktivniOblikDrugi;

            bool[,] rotirano = koji.SimulirajRotaciju();
            var boundingBox = koji.Pozicija;

            for (int i = boundingBox.Item1, k = 0; i < boundingBox.Item1 + 4; ++i, ++k)
                for (int j = boundingBox.Item2, l = 0; j < boundingBox.Item2 + 4; ++j, ++l)
                    if (i < 0 || j < 0 || rotirano[k, l] && ((ploca[i, j] != Kvadrat.Slobodan && ploca[i, j] != kojiLik) || !uGranicama(new Tuple<int,int>(i,j))))
                        return false;

            return true;
        }

        private void rotiraj(Kvadrat kojiLik)
        {
            Oblik koji = kojiLik == Kvadrat.OkupiraPrviLik ? aktivniOblikPrvi : aktivniOblikDrugi;

            koji.Rotiraj();
            var boundingBox = koji.Pozicija;

            for (int i = boundingBox.Item1, k = 0; i < boundingBox.Item1 + 4; ++i, ++k)
                for (int j = boundingBox.Item2, l = 0; j < boundingBox.Item2 + 4; ++j, ++l)
                {
                    if (koji.Celije[k, l])
                        ploca[i, j] = kojiLik;
                    else if (!koji.Celije[k, l] && ploca[i, j] == kojiLik)
                        ploca[i, j] = Kvadrat.Slobodan;
                }    
        }

        private bool mozePomak(Kvadrat kojiLik, Smjerovi smjer){
            if (Nivo().Smjer == suprotanSmjer(smjer) && nagradni_bodovi <= 0)
                return false;

            for (int i = 1; i < tip_igre.Redaka + 1; ++i)
                for (int j = 1; j < tip_igre.Stupaca + 1; ++j)
                    if (ploca[i, j] == kojiLik)
                    {
                        var sljedeciIndeksi = nxt(i,j, smjer);
                        if (!uGranicama(sljedeciIndeksi) || zauzet(ploca[sljedeciIndeksi.Item1, sljedeciIndeksi.Item2]))
                        {
                            return false;
                        }
                    }
            return true;
        }

        private bool zauzet(Kvadrat k)
        {
            switch (k)
            {
                case Kvadrat.DeaktiviraniPrvi:
                case Kvadrat.DeaktiviraniDrugi:
                case Kvadrat.OkupiraPrepreka:
                    return true;
                default:
                    return false;
            }
        }

        private void pomakni(Kvadrat kojiLik, Smjerovi smjer)
        {
            Oblik oblik = kojiLik == Kvadrat.OkupiraPrviLik ? aktivniOblikPrvi : aktivniOblikDrugi;
            if (oblik == null)
                return;

            if (Nivo().Smjer == suprotanSmjer(smjer))
                nagradni_bodovi--;

            oblik.Pozicija = nxt(oblik.Pozicija.Item1, oblik.Pozicija.Item2, smjer);

            var trenutne_koord = koordinateAktivnogLika(kojiLik);
            var sljedece_koord = new List<Tuple<int, int>>();
            foreach(var k in trenutne_koord){
                var sljedeciIndeksi = nxt(k.Item1, k.Item2, smjer);
                sljedece_koord.Add(sljedeciIndeksi);
                ploca[sljedeciIndeksi.Item1, sljedeciIndeksi.Item2] = kojiLik;
            }

            foreach (var k in trenutne_koord)
            {
                if (!sljedece_koord.Contains(k))
                {
                    ploca[k.Item1, k.Item2] = Kvadrat.Slobodan;
                }
            }
        }

        private List<Tuple<int, int>> koordinateAktivnogLika(Kvadrat kojiLik)
        {
            var lista = new List<Tuple<int, int>>();
            for (int i = 1; i < tip_igre.Redaka + 1; ++i)
                for (int j = 1; j < tip_igre.Stupaca + 1; ++j)
                    if (ploca[i, j] == kojiLik)
                    {
                        lista.Add(new Tuple<int, int>(i, j));
                    }
            return lista;
        }

        private void deaktiviraj(Kvadrat kojiLik)
        {
            for (int i = 1; i < tip_igre.Redaka + 1; ++i)
                for (int j = 1; j < tip_igre.Stupaca + 1; ++j)
                    if (ploca[i, j] == kojiLik)
                        if (kojiLik == Kvadrat.OkupiraPrviLik)
                            ploca[i, j] = Kvadrat.DeaktiviraniPrvi;
                        else
                            ploca[i, j] = Kvadrat.DeaktiviraniDrugi;
        }

        private bool inicijaliziraj(Kvadrat kojiLik)
        {
            urediLikove();

            switch (Nivo().Smjer)
            {
                case Smjerovi.Dolje:
                    for (int i = 1, k = 0; i < 5; ++i, ++k)
                        for (int j = tip_igre.Stupaca / 2 - 2, l = 0; j < tip_igre.Stupaca / 2 + 2; ++j, ++l)
                        {
                            if (ploca[i, j] != Kvadrat.Slobodan) return false;
                            ploca[i, j] = aktivniOblikPrvi.Celije[k, l] ? kojiLik : ploca[i, j];
                        } 
                    aktivniOblikPrvi.Pozicija = new Tuple<int, int>(1, tip_igre.Stupaca / 2 - 2);
                    break;
                case Smjerovi.Gore:
                    for (int i = tip_igre.Redaka-4, k = 0; i < tip_igre.Redaka; ++i, ++k)
                        for (int j = tip_igre.Stupaca / 2 - 2, l = 0; j < tip_igre.Stupaca / 2 + 2; ++j, ++l)
                        {
                            if (ploca[i, j] != Kvadrat.Slobodan) return false;
                            ploca[i, j] = aktivniOblikPrvi.Celije[k, l] ? kojiLik : ploca[i, j];
                        }
                    aktivniOblikPrvi.Pozicija = new Tuple<int, int>(tip_igre.Redaka-4, tip_igre.Stupaca / 2 - 2);
                    break;
                case Smjerovi.Desno:
                    for (int i = tip_igre.Redaka / 2 - 2, k = 0; i < tip_igre.Redaka / 2 + 2; ++i, ++k)
                        for (int j = 1, l = 0; j < 5; ++j, ++l)
                        {
                            if (ploca[i, j] != Kvadrat.Slobodan) return false;
                            ploca[i, j] = aktivniOblikPrvi.Celije[k, l] ? kojiLik : ploca[i, j];
                        }
                    aktivniOblikPrvi.Pozicija = new Tuple<int, int>(tip_igre.Redaka/2 -2, 1);
                    break;
                case Smjerovi.Lijevo:
                default:
                    for (int i = tip_igre.Redaka / 2 - 2, k = 0; i < tip_igre.Redaka / 2 + 2; ++i, ++k)
                        for (int j = tip_igre.Stupaca - 4, l = 0; j < tip_igre.Stupaca; ++j, ++l)
                        {
                            if (ploca[i, j] != Kvadrat.Slobodan) return false;
                            ploca[i, j] = aktivniOblikPrvi.Celije[k, l] ? kojiLik : ploca[i, j];
                        }
                    aktivniOblikPrvi.Pozicija = new Tuple<int, int>(tip_igre.Redaka / 2 - 2, tip_igre.Stupaca-4);
                    break;
            }
            return true;
        }

        private void urediLikove()
        {
            if (sljedeciOblikPrvi != null)
            {
                aktivniOblikPrvi = sljedeciOblikPrvi;
                sljedeciOblikPrvi = SljedeciOblik();
            }
            else
            {
                aktivniOblikPrvi = SljedeciOblik();
                sljedeciOblikPrvi = SljedeciOblik();
            }
        }

        private Tuple<int, int> nxt(int red, int stup, Smjerovi smjer)
        {
            switch (smjer)
            {
                case Smjerovi.Dolje:
                    return new Tuple<int, int>(red + 1, stup);
                case Smjerovi.Gore:
                    return new Tuple<int, int>(red - 1, stup);
                case Smjerovi.Desno:
                    return new Tuple<int, int>(red, stup + 1);
                case Smjerovi.Lijevo:
                default:
                    return new Tuple<int, int>(red, stup - 1);
            }
        }

        private Smjerovi suprotanSmjer(Smjerovi s)
        {
            switch (s)
            {
                case Smjerovi.Desno:
                    return Smjerovi.Lijevo;
                case Smjerovi.Lijevo:
                    return Smjerovi.Desno;
                case Smjerovi.Gore:
                    return Smjerovi.Dolje;
                default:
                case Smjerovi.Dolje:
                    return Smjerovi.Gore;
            }
        }

        private bool uGranicama(Tuple<int, int> poz){
            return poz.Item1 > 0 && poz.Item2 > 0 && poz.Item1 < tip_igre.Redaka + 1 && poz.Item2 < tip_igre.Stupaca + 1;
        }

        private bool postojiAktivan(Kvadrat kojiLik)
        {
            for (int i = 1; i < tip_igre.Redaka + 1; ++i)
                for (int j = 1; j < tip_igre.Stupaca + 1; ++j)
                    if (ploca[i, j] == kojiLik)
                        return true;
            return false;
        }

        private void pocistiPopunjeno()
        {
            double bonusMultiplier = 1.0;

            switch (Nivo().Smjer)
            {
                case Smjerovi.Dolje:
                case Smjerovi.Gore:
                    for (int i = 1; i < tip_igre.Redaka + 1; ++i){
                        bool isFull = true;
                        for (int j = 1; j < tip_igre.Stupaca + 1; ++j)
                        {
                            if (ploca[i, j] != Kvadrat.DeaktiviraniPrvi && ploca[i, j] != Kvadrat.DeaktiviraniDrugi)
                                isFull = false;
                        }
                        if (isFull)
                        {
                            pomakniDeaktivirano(i);
                            pribrojiBodove(bonusMultiplier);
                            bonusMultiplier += 0.05 * Nivo().Brzina;
                        }
                    }
                    break;
                case Smjerovi.Lijevo:
                case Smjerovi.Desno:
                    for (int i = 1; i < tip_igre.Stupaca + 1; ++i)
                    {
                        bool isFull = true;
                        for (int j = 1; j < tip_igre.Redaka + 1; ++j)
                        {
                            if (ploca[j, i] != Kvadrat.DeaktiviraniPrvi && ploca[j, i] != Kvadrat.DeaktiviraniDrugi)
                                isFull = false;
                        }
                        if (isFull)
                        {
                            pomakniDeaktivirano(i);
                            pribrojiBodove(bonusMultiplier);
                            bonusMultiplier += 0.1 * Nivo().Brzina;
                        }
                    }
                    break;       
            }
        }

        private void pomakniDeaktivirano(int iznad)
        {
            switch (Nivo().Smjer)
            {
                case Smjerovi.Dolje:
                    for (int i = iznad; i > 0; --i)
                        for (int j = 1; j < tip_igre.Stupaca + 1; ++j)
                        {
                            if (ploca[i - 1, j] == Kvadrat.DeaktiviraniPrvi || ploca[i - 1, j] == Kvadrat.DeaktiviraniDrugi)
                                ploca[i, j] = ploca[i - 1, j];
                            else
                                ploca[i, j] = Kvadrat.Slobodan;
                        }
                    break;
                case Smjerovi.Gore:
                    for (int i = iznad; i < tip_igre.Redaka + 1; ++i)
                        for (int j = 1; j < tip_igre.Stupaca + 1; ++j)
                        {
                            if (ploca[i + 1, j] == Kvadrat.DeaktiviraniPrvi || ploca[i + 1, j] == Kvadrat.DeaktiviraniDrugi)
                                ploca[i, j] = ploca[i + 1, j];
                            else
                                ploca[i, j] = Kvadrat.Slobodan;
                        }
                    break;
                case Smjerovi.Lijevo:
                    for (int i = iznad; i < tip_igre.Stupaca + 1; ++i)
                        for (int j = 1; j < tip_igre.Redaka + 1; ++j)
                        {
                            if (ploca[j, i + 1] == Kvadrat.DeaktiviraniPrvi || ploca[j, i + 1] == Kvadrat.DeaktiviraniDrugi)
                                ploca[j, i] = ploca[j, i + 1];
                            else
                                ploca[j, i] = Kvadrat.Slobodan;
                        }
                    break;
                case Smjerovi.Desno:
                    for (int i = iznad; i > 0; --i)
                            for (int j = 1; j < tip_igre.Redaka + 1; ++j)
                            {
                                if (ploca[j, i - 1] == Kvadrat.DeaktiviraniPrvi || ploca[j, i - 1] == Kvadrat.DeaktiviraniDrugi)
                                    ploca[j, i] = ploca[j, i - 1];
                                else
                                    ploca[j, i] = Kvadrat.Slobodan;
                            }
                    break;
            }
        }

        private void pribrojiBodove(double multiplier){
            rezultat += (int)(100 * multiplier);
            if (multiplier > 1) 
            { 
                nagradni_bodovi += 5; 
            }
        }

        void PohraniRezultat()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Upisite ime:", "Pohrana rezultata", "");

            Postavke.DodajRezultat(tip_igre.Ime, input, trenutni_nivo, rezultat);
            Postavke.Pohrani();
        }
    }
}
