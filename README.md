# Windows Forms Tetris


## Sadržaj
 1. Zahthjevi
 2. Organizacija
 3. Opis dijelova
 	1. Zajednička osnova (L. M.)
 	2. Logika igre (B. P.)
 	3. Prikaz igre (G. G.)
 4. Slike sučelja


## Zahtjevi
Radi se o dobro poznatoj igri Tetris. Ovdje navodimo specifičnosti ove implementacije.

 * Korisnik ima mogućnost definiranja igre (za svaki nivo odvojeno):
   * Moguć odabir likova s kojima će se igrati.
   * Definiranje nestandardnih likova 
   * Manje prepreke koje povremeno mijenjaju mjesto. 
   * Na nekom nivou u isto vrijeme spuštaju po dva lika,
   * Na pozadini se pojavljuju nagradni kvadratići. 
   * Brzina padanja
 * Iskorištavanje dodatnih bodova nagradnih kvadratića:
   * Lik se u nekom trenutku pomakne nekoliko redaka prema gore.
 * Omogućena promjena pogleda na igru, npr. likovi se kreću prema gore
 * Za određen tip igre, treba prikazati popis najboljih dosadašnjih rezultata.

## Organizacija

Igru su izradili (studenti 2. godine diplomskog studija Računarstvo i Matematika) Goran Gosarić, Luka Mikec i Bojan Popović. 

Koristili smo C# i WinForms API .NET-a. Za izradu smo koristili Visual Studio, a za verzioniranje Git. 

Zajedničke klase, forme za uređivanje i prikaz igara, oblika i rezultata, te upravljanje konfiguracijom je napravio Luka Mikec. 
Logiku igre (*engine*) koja uključuje i ranije navedene posebnosti je implementirao Bojan Popović. Formu za prikaz igre uključno s dizajnom grafičkih elemenata je izradio Goran Gosarić.


## Opis dijelova

### Zajednička osnova (L. M.)
Ovaj dio projekta uključuje zajedničke klase za komunikaciju *enginea* i prikaza igre: Oblik, TipIgre, TipNivoa i Postavke. U sve te klase implementirana je XML serijalizacija i deserijalizacija svih podataka kojima igra barata (definicije igara, nivoa, oblika; te rezultati). Zatim, to su forme UredivanjeTipova, UredivanjeOblika, korisnička kontrola PrikazRezultata i početna forma igre. 

Što se tiče zajedničkih klasa, možda je zanimljivo istaknuti serijalizaciju. Kao podjednako pristupačne opcije (za koje .NET nudi pomoćne funkcije) su se osim XML-a nudile i baze podataka (ADO .NET). Kako se ovdje ne radi puno s manipulacijom podataka brzina nije imperativ, a XML se može i ručno čitati, pa je odabran XML. Do C# verzije 3.0 nudio se XMLDocument API za uređivanje XML dokumenata. Od tada se nudi nešto elegantniji XDocument API. Potonji je korišten kroz ovaj projekt, odnosno klase za pohranu tipova igara, nivoa, oblika i rezultata.

Kod formi iz ovog dijela projekta možda je najzanimljivija korisnička kontrola PrikazRezultata. Ona je implementirana kao korisnička kontrola (umjesto kao dio početne forme) jer smo htjeli ostaviti mogućnost da ćemo rezultate prikazivati i drugdje. Na toj se kontroli dinamički stvaraju tabovi za svaki tip igre, te ispunjavaju podacima o rezultatima odigranih igara toga tipa.

Od ostalih formi možda je zanimljivo izdvojiti dizajn ćelija oblika na formi UredivanjeOblika, gdje su pojedine ćelije zapravo *checkboxevi* prikazani u *flat button* stilu.

### Logika igre (B. P.)
(dovršiti)

### Prikaz igre (G. G.)

Ovaj dio projekta je dizajn forme na kojoj će se prikazivati igra, te iscrtavanje trenutnog stanja igre.

Sama forma podijeljena je na dva dijela. U lijevom dijelu forme nalazi se glavni *panel* na kojem crtamo stanje igre. Na desnom dijelu nam se nalaze važne informacije koje se tiču tijeka igre. Imamo redom: panel za prikaz rezultata koji prikazuje trenutni rezultat igre, nakon toga imamo dva labela koja služe za prikaz trenutnog nivoa te brzine igre. Bonus label nam prikazuje bonus bodove koje kasnije igrač može iskoristiti za neke specijalne pokrete. Također imamo, ovisno o igri i jedan, odnosno dva panela koja nam prikazuju sljedeći oblik koji nam dolazi u igri. Ako nivo ima mogućnost pojave dva oblika istovremeno tada se na formi pojavljuju dva panela. Na dnu desne strane forme, nalazi nam se pictureBox koji ovisno o smjeru kretanja oblika unutar određenog nivoa prikazuje odgovarajuću sliku smjera.

Glavni panel, koji nam služi za crtanje stanja igre, mijenja veličinu ovisno o broju redaka i stupaca koje su zadane za neku vrstu igre. Sastavljen je od niza kvadratića veličine 24px ili manje, na način da slobodno polje prikazujemo kao gotov uzorak, dok ostala polja ovisno jesu li zauzeta od strane nekog oblika ili prepreke crtamo na način da prvo kreiramo kvadrat određene boje a zatim na njega nacrtamo još i „uzorak“ (okvir).

## Slike sučelja
 1. Početni zaslon
    ![Screenshot](/doc/pocetna.png "Screenshot")
 2. Prikaz igre
    ![Screenshot](/doc/prikaz_igre.png "Screenshot")
 3. Uređivanje tipova
    ![Screenshot](/doc/uredivanje_tipova.png "Screenshot")
 4. Uređivanje oblika
    ![Screenshot](/doc/uredivanje_oblika.png "Screenshot")

