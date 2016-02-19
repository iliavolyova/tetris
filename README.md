# Windows Forms Tetris


## Sadržaj
 1. Zahtjevi
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

Kada se odabere konfiguracija, korisničko sučelje instancira objekt igre, tj. klasu Tetris. Konstruktor prima slijed odabranih nivoa, te njihove posebnosti ovisno o tome kakav je tip igre odabran (sve je sadržano u objektu TipIgre). Također, stvara se centralni dio ove klase: dvodimenzionalno polje *ploca* na kojem je prikazano trenutno stanje igre. Korisničko sučelje nakon toga aktivira *timer* koji u klasi Tetris periodično zove metodu Korak. Ova metoda, ovisno o brzini trenutnog nivoa odlučuje hoće li se stvarno dogoditi korak u životnom ciklusu igre, ili se neće dogoditi ništa. Ako se treba dogoditi korak, poziva se privatna metoda gravitacijaAktivni čiji je zadatak spustiti sve aktivne likove u smjeru u kojem je definirano padanje likova u trenutnom nivou.

Prije svake kretnje aktivnih likova (pomaka, rotacije, ili gravitacije), *engine* prvo simulira navedenu akciju i gleda jesu li polja na ploči gdje bi se lik trebao naći u idućem koraku slobodna. U slučaju gravitacije, ako se lik ne može pomaknuti, on postaje deaktiviran. Ako nema aktivnih likova, inicijaliziraju se novi.

Korisničko sučelje također presreće pritiske na tipkovnicu, te na određene tipke šalje zahtjeve za akcijom klasi Tetris, koja ih nakon uspješne simulacije i provodi. Simulacije su sadržane u privatnim metodama mozePomak i mozeRotacija, koje vraćaju bool vrijednost ovisno o ishodu. Postoje i pomoćne metode koje enkapsuliraju neke česte akcije, kao što su uGranicama (provjerava je li neka simulirana pozicija likova još uvijek na ploči), te urediLikove, koja generira sljedeće oblike, te postavlja aktivne.

Kako bi kod bio čitljiv, postoji nekoliko enumeracija koje sadrže vrste objekata i radnji, kao što su primjerice smjerovi, stanja polja na igraćoj ploči, te tipovi korisničkih interakcija (pomak ili rotacija). 

### Prikaz igre (G. G.)

Ovaj dio projekta je dizajn forme na kojoj će se prikazivati igra, te iscrtavanje trenutnog stanja igre.

Sama forma podijeljena je na dva dijela. U lijevom dijelu forme nalazi se glavni *panel* na kojem crtamo stanje igre. Na desnom dijelu nam se nalaze važne informacije koje se tiču tijeka igre. Imamo redom: panel za prikaz rezultata koji prikazuje trenutni rezultat igre, nakon toga imamo dva labela koja služe za prikaz trenutnog nivoa te brzine igre. Bonus label nam prikazuje bonus bodove koje kasnije igrač može iskoristiti za neke specijalne pokrete. Također imamo, ovisno o igri i jedan, odnosno dva panela koja nam prikazuju sljedeći oblik koji nam dolazi u igri. Ako nivo ima mogućnost pojave dva oblika istovremeno tada se na formi pojavljuju dva panela. Na dnu desne strane forme, nalazi nam se pictureBox koji ovisno o smjeru kretanja oblika unutar određenog nivoa prikazuje odgovarajuću sliku smjera.

Glavni panel, koji nam služi za crtanje stanja igre, mijenja veličinu ovisno o broju redaka i stupaca koje su zadane za neku vrstu igre. Sastavljen je od niza kvadratića veličine 24px ili manje, na način da slobodno polje prikazujemo kao gotov uzorak, dok ostala polja ovisno jesu li zauzeta od strane nekog oblika ili prepreke crtamo na način da prvo kreiramo kvadrat određene boje a zatim na njega nacrtamo još i „uzorak“ (okvir).

## Slike sučelja
 1. Početni zaslon <br />
    ![Screenshot](/doc/pocetna.png "Screenshot")
 2. Prikaz igre <br />
    ![Screenshot](/doc/prikaz_igre.png "Screenshot")
 3. Uređivanje tipova <br />
    ![Screenshot](/doc/uredivanje_tipova.png "Screenshot")
 4. Uređivanje oblika <br />
    ![Screenshot](/doc/uredivanje_oblika.png "Screenshot")

