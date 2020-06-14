using System;
using System.Collections.Generic;
using SQLite;
using System.IO;
using SQLiteNetExtensions.Attributes;
using Android.Database;


namespace KochBuch
{
    class DbRezept
    {
        //database path
        string dbPath = Path.Combine(
        System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"RezeptTest26'.db3");

        public DbRezept()
        {
            // Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Rezept>();
            }
        }
        [Table("Rezept")]
        public class Rezept
        {
            [PrimaryKey, AutoIncrement, Column("RezeptID")]
            public int RezeptID { get; set; }
            [MaxLength(40), Column("RezeptName")]
            public string RezeptName { get; set; }
            [Column("Dauer")]
            public int Dauer { get; set; }
            [MaxLength(500), Column("Zutaten")]
            public string Zutaten { get; set; }
            [MaxLength(1000), Column("RezeptText")]
            public string RezeptText { get; set; }
            [MaxLength(500), Column("Image")]
            public string Image { get; set; }
            [MaxLength(500), Column("Land")]
            public string Land { get; set; }
        }
        // prüfen ob die tabelle Rezepte elemente enthält
        public Boolean empty()
        {
            var db = new SQLiteConnection(dbPath);
            if (db.Table<Rezept>().Count() == 0) {
                return true;
            }
            return false;
        }
        // Count Table
        public int Count()
        {
            var db = new SQLiteConnection(dbPath);
            int counter = 0;
            counter = db.Table<Rezept>().Count();
            return counter;
        }

        // Sql Querries
        // Select Inhalt Von Rezepte
        public string selectZutaten(string etwas)
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            var ListeQuery = db.Query<Rezept>("SELECT Zutaten FROM Rezept WHERE RezeptName = ?", etwas);
            foreach (var s in ListeQuery)
            {
                data += s.Zutaten;
            }
            return data;
        }

        // Select Inhalt Von Rezepte
        public string selectDauer(string etwas)
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            var ListeQuery = db.Query<Rezept>("SELECT Dauer FROM Rezept WHERE RezeptName = ?", etwas);
            foreach (var s in ListeQuery)
            {
                data += s.Dauer;
            }
            return data;
        }


        // Select Inhalt Von Rezepte
        public string select(string etwas)
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            var ListeQuery = db.Query<Rezept>("SELECT * FROM Rezept WHERE RezeptName = ?", etwas);
            foreach (var s in ListeQuery)
            {
                data += s.RezeptText;
            }
            return data;
        }

        // Select Name nach ID
        public string selectNameNachID(int ID)
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            var ListeQuery = db.Query<Rezept>("SELECT * FROM Rezept WHERE RezeptID = ?", ID);
            foreach (var s in ListeQuery)
            {
                data += s.RezeptName;
            }
            return data;
        }

        // Select Dauer nach Id
        public string selectDauerNachID(int ID)
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);

            var ListeQuery = db.Query<Rezept>("SELECT * FROM Rezept WHERE RezeptID = ?", ID);
            foreach (var s in ListeQuery)
            {
                data += s.Dauer;
            }
            return data;
        }

        // Select Image nach Id
        public string selectImageNachID(int ID)
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            var ListeQuery = db.Query<Rezept>("SELECT * FROM Rezept WHERE RezeptID = ?", ID);
            foreach (var s in ListeQuery)
            {
                data += s.Image;
            }
            return data;
        }

        // Select Imae nach Name
        public string selectImageNachName(string name)
        {
            string data = "";
            var db = new SQLiteConnection(dbPath);
            var ListeQuery = db.Query<Rezept>("SELECT * FROM Rezept WHERE RezeptName = ?", name);
            foreach (var s in ListeQuery)
            {
                data += s.Image;
            }
            return data;
        }
        public void Insert()
        {
            var db = new SQLiteConnection(dbPath);
            var rezept = new Rezept();

            // Italien Index 1
            //Rezept 1
            rezept.RezeptName = " Panna Cotta – italienisches Dessert für Genießer";
            rezept.Dauer = 15;
            rezept.Zutaten = "Für 4 Personen 750 g Schlagsahne 100 g Zucker 2 Päckchen Vanillezucker 6 Blatt weiße Gelatine 2–3 EL lösliches Espressopulver 16  mit Schokolade überzogene Espressobohnen zum Verzieren ";
            rezept.RezeptText = " Sahne, Zucker und Vanillezucker aufkochen und ca. 10 Minuten köcheln.Gelatine in kaltem Wasser einweichen.Sahne in eine Schüssel gießen und ca. 5 Minuten abkühlen lassen.Espressopulver und ausgedrückte Gelatine einrühren. Timbaleförmchen oder kleine Tassen(à 150–200 ml Inhalt) mit kaltem Wasser ausspülen. Creme einfüllen und mind. 4 Stunden, am besten über Nacht, kalt -stellen.Vor dem Servieren Panna cotta auf Teller stürzen und mit - Espressobohnen verzieren.";
            rezept.Image = "Panna_Cotta";
            db.Insert(rezept);
            //Rezept 2
            rezept.RezeptName = " Tiramisu - verführerisches Dessert aus Bella Italia";
            rezept.Dauer = 35;
            rezept.Zutaten = "Für 8 Personen \n 4  frische Eigelb \n 4 EL Zucker \n 500 g Mascarpone \n abgeriebene Schale von 1 Bio - Zitrone \n 150 g Löffelbiskuits \n 200 ml kalter Espresso \n 4 EL Marsala oder Weinbrand(ital.Dessertwein) \n 2 EL Kakaopulver ";
            rezept.RezeptText = "Eigelb und Zucker mit den Schneebesen des Handrührgerätes mind. 5 Minuten dickcremig schlagen. Mascarpone löffelweise unterrühren. Zitronenschale zufügen. Hälfte der Löffelbiskuits nebeneinander in eine flache Form(ca. 25x18 cm) legen.Espresso und Marsala mischen und die Hälfte über die Biskuits träufeln. Hälfte Mascarponecreme auf die Biskuits streichen. Übrige Kekse nebeneinander darauf verteilen und mit Rest Espresso beträufeln. Übrige Creme daraufstreichen. Tiramisu mind. 3 Stunden kalt stellen.Vorm Servieren mit Kakao bestäuben.";
            rezept.Image = "Tiramisu";
            db.Insert(rezept);
            //Rezept 3
            rezept.RezeptName = " Risotto-Rezepte - Klassiker in köstlichen Variationen";
            rezept.Dauer = 60;
            rezept.Zutaten = "Für 4 Personen \n 500 g Maronen-Röhrlinge \n 1  Zwiebel \n 2  Knoblauchzehen \n 4–5 EL Olivenöl \n 250 g Risottoreis \nfrisch gemahlener schwarzer Pfeffer \n 500 ml Gemüsefond \n 200 ml trockener Weißwein \n50 g frisch geriebener Parmesankäse \nSalz \n 125 g geräucherter durchwachsener Speck \n 8 Stiel(e) Thymian ";
            rezept.RezeptText = " Pilze putzen, säubern und eventuell waschen (dann aber sehr gut abtropfen lassen). Zwiebel schälen und fein würfeln. Knoblauch schälen und fein hacken. 2–3 EL Olivenöl in einem Topf erhitzen, Hälfte der Pilze zufügen und unter Wenden anbraten. Zwiebel und Knoblauch zufügen und bei schwacher Hitze ca. 4 Minuten unter Wenden dünsten Reis zufügen, kurz mit anschwitzen. Mit Pfeffer würzen.Nach und nach Fond und Wein zugießen, dabei ab und zu umrühren.Nächste Portion Flüssigkeit immer erst zugießen, wenn der Reis die Flüssigkeit aufgenommen hat. Insgesamt 30–35 Minuten garen. Am Ende der Garzeit den Parmesan unterrühren.Nochmals mit Salz und Pfeffer abschmecken Inzwischen Speck in feine Würfel schneiden.Thymian waschen, trocken schütteln und die Blättchen von den Stielen zupfen. Speck in einer Pfanne knusprig auslassen, herausnehmen. 2 EL Olivenöl in das Bratfett geben, erhitzen, restlichen Pilze zufügen, unter Wenden anbraten.Thymian zufügen, kurz mit anbraten. Speck zufügen, nochmals erhitzen, mit Salz und Pfeffer würzen.Risotto mit Speck - Maronen - Röhrlingen auf Tellern anrichten";
            db.Insert(rezept);
            rezept.Image = "Risotto";
            //Rezept 4
            rezept.RezeptName = " Tramezzini - Sandwich goes Italy";
            rezept.Dauer = 25;
            rezept.Zutaten = "Für 4 Personen 1  Stange Staudensellerie \n1  kleiner Apfel \n1 EL Zitronensaft \n1 Bund Schnittlauch \n 200 g Salatmayonnaise 1–2 TL Currypulver \nSalz \nPfeffer \n Zucker \n kleiner Kopf Eisberg - Salat \n 12 Scheiben Sandwichtoast \n 250 g französischer Rosé - Schinken \n Holzspießchen ";
            rezept.RezeptText = " Sellerie putzen, waschen und fein würfeln. Apfel waschen, grob vom Kerngehäuse reiben und sofort mit Zitronensaft vermengen. Schnittlauch waschen, trocken schütteln, in Röllchen schneiden. Sellerie, Schnittlauch, Apfel-Mischung, Mayonnaise und 1 TL Currypulver verrühren, mit Salz, Pfeffer, Currypulver und Zucker würzig abschmecken Salat putzen, waschen, evtl. halbieren, Blätter einzeln vom Kopf lösen. 24 Blätter flach drücken. 4 kleinere Blätter als Schalen zum Servieren beiseitelegen.Übrigen Salat anderweitig verwenden. 8 Toastscheiben mit je 1 / 2 EL Apfel-Creme bestreichen, mit je 1 / 8 des Schinkens und jeweils 3 Salatblättern belegen Je 2 belegte Toastscheiben übereinanderlegen, mit je 1 unbestrichenen Toastscheibe belegen.Jedes Sandwich diagonal an 4 Ecken mit Holzspießchen feststecken. Ränder von den Sandwiches schneiden, Sandwiches vierteln, anrichten. Übrige Creme in den Blattschalen anrichten, dazureichen..";
            rezept.Image = "Tramezzini";
            db.Insert(rezept);
            //Rezept 5
            rezept.RezeptName = " Antipasti - italienische Vorspeisenvielfalt";
            rezept.Dauer = 20;
            rezept.Zutaten = "Für 4 Personen \n  1  Knoblauchzehe \n 3 EL Olivenöl \n 4  Ciabattabrötchen \n 1 Dose(n)(à 425 ml) Artischockenherzen \n 140 g Röstpaprika(Glas) \n 6 Scheibe / n Parmaschinken \n 2  Tomaten \n 1 TL Tomatenmark \n Salz \n Pfeffer \n 300 g Taleggio(italienischer Weichkäse) \n 2 Stiel / e glatte Petersilie Backpapier ";
            rezept.Image = "Antipasti";
            rezept.RezeptText = " Knoblauch schälen, fein hacken und mit Öl mischen. Brötchen waagerecht halbieren, auf ein mit Backpapier ausgelegtes Backblech legen und die Schnittflächen mit Öl beträufeln. Unter dem Backofengrill kurz rösten. Inzwischen Artischocken abtropfen lassen, halbieren. Röstpaprika eventuell in breite Streifen schneiden.Schinken zerzupfen. Tomaten waschen und pürieren oder auf einer Reibe grob reiben. Mit Tomatenmark verrühren und mit Salz und Pfeffer würzen.Die Brote damit bestreichen. Mit Artischocken, Paprika und Schinken belegen.Taleggio in Stücke schneiden, auf den Broten verteilen und unter dem Backofengrill goldbraun überbacken. ¬Petersilie waschen, trocken schütteln, Blättchen abzupfen und darüberstreuen..";
            db.Insert(rezept);
            //Rezept 6
            rezept.RezeptName = " Bruschetta - italienischer Klassiker und neue Varianten";
            rezept.Dauer = 35;
            rezept.Zutaten = "Für 8 Personen 1 Ciabatta 5 EL + 3TL Olivenöl \n 2 Zehen Knoblauch \n 1 Zwiebel \n 6 aromatische Tomaten \n 8 Stiele Basilikum \n Salz, Pfeffer, Zucker";
            rezept.RezeptText = " Den Ofen auf 180° C (Umluft) vorheizen. Ciabatta in 16 gleichgroße Scheiben schneiden und mit ca. 5 EL Olivenöl leicht einpinseln. Knoblauch abziehen und halbieren. Das Brot auf ein Backblech legen und im Ofen wenige Minuten rösten, bis es knusprig ist. Direkt von einer Seite mit der halbierten Knoblauchzehe einreiben. Tomaten abwaschen, halbieren, den grünen Strunk sowie die Kerne entfernen. Das Fruchtfleisch in kleine Würfel schneiden.Zwiebel putzen und fein würfeln.Basilikum waschen, trocken schütteln, Blätter von den Stielen zupfen, einige Beiseite legen, den Rest in dünne Streifen schneiden.Tomatenwürfel, Zwiebelwürfel und Basilikum in einer Schüssel mischen. 3 TL Olivenöl hinzufügen, unterheben und alles mit Salz, Pfeffer und Zucker abschmecken.  Die Tomatenmischung gleichmäßig auf dem gerösteten Brot anrichten. Mit übrigem Basilikum und nach Belieben mit, in Ringe geschnittenen Lauchzwiebeln garnieren. Sofort servieren.";
            rezept.Image = "Bruschetta";
            db.Insert(rezept);

            // SPanisch Index 7
            //rezept 1
            rezept.RezeptName = "Papas Arrugadas";
            rezept.Dauer = 30;
            rezept.Zutaten = "Für 3 Personen\n1 kg Kartoffel(n),\n1 Liter Wasser\n300 g Salz\nSesam ";
            rezept.RezeptText = " Tontopf und Deckel evtl. 10-15 Minuten (s. Anweisung) kalt wässern, dann herausnehmen Keulen im Gelenk halbieren, waschen, trockentupfen. Mit Salz und Pfeffer würzen. Im heißen Öl rundum kräftig anbraten Kartoffeln schälen und waschen. Knoblauchknollen waschen und quer halbieren. Minze abspülen. Zitrone heiß waschen. Eine Hälfte in Spalten schneiden, eine Hälfte auspressen Kartoffeln, Knoblauch, Hälfte Minze, Die Kartoffeln waschen, aber nicht schälen. Die Kartoffeln in einem nicht zu kleinen Topf von ca. 22 cm mit Wasser bedecken, es sollten ca. 800 ml bis 1 Liter sein. Dann das ganze Salz dazugeben. Das hört sich viel an und das ist es auch, es ist aber richtig. Kleiner Exkurs: Salz hat eine Löslichkeit von 356 g/L, man stellt also genau eine gesättigte Lösung her. Deckel drauflegen. Dann die Kartoffeln in ca. 20 Minuten gar kochen.Den Deckel abnehmen und ganz kurz, ca. 2 - 3 Minuten, aufkochen lassen. Auf keinen Fall weit einkochen, sonst hat man eine Salzpampe.Das Salzwasser abgießen und die Kartoffeln in einen anderen Behälter umfüllen, das ist wichtig. Beim trocknen bekommen die Kartoffeln dann eine feine Salzkruste. Kleiner Exkurs zum ursprünglichen Rezept: Normalerweise werden Kartoffeln in Meerwasser gekocht deshalb sind Kartoffeln auf Schiffen so beliebt, es ist fast das einzige Lebensmittel, welches in Meerwasser gegart werden kann, versucht das mal mit Reis oder Pasta. Auf den Kanaren genauso. Meerwasser hat ca. 35 g Salz pro Liter 3,5 %.Um eine Salzkruste zu erzeugen muss das Wasser also weiter reduziert werden, auf ein Zehntel, das dauert. Mit der o.g.Variante mit gesättigter Salzlösung 35 % geht das viel schneller..";
            rezept.Image = "Sp_Papas_Arrugadas";
            db.Insert(rezept);
            //rezept 2
            rezept.RezeptName = " Rafis Fisch Paella";
            rezept.Dauer = 30;
            rezept.Zutaten = "Für 4 Personen\n8 große Gambas\n250g Gambas, kleine 300g Muschel(n) (Greenshell), TK\n500g Hähnchenbrustfilet(s), gewürfelt\n2 Paprikaschote(n), rot, in Streifen geschnitten\n6 Tomate(n), gewürfelt\n2 Zwiebel(n), gewürfelt\n300 g Reis (Rundkorn-), spanischer\n1 Zehe/n Knoblauch, grob gehackt\n2 EL Tomatenmark\n100g Erbsen, TK\n1 Liter	Fischbrühe\n1 TL Kurkuma\n2 TL Salz\netwas Pfeffer\n1 Dose Safran\n6 EL Olivenöl\n2  Zitrone ";
            rezept.RezeptText = " Die Gambas und die Muscheln auftauen, säubern und beiseite stellen.Hähnchen, Paprika, Tomaten und Zwiebeln in einer Partypfanne mit Olivenöl scharf anbraten. Dann den Reis kurz darin anschwitzen, 2/3 der Brühe hinzufügen und Knoblauch, Tomatenmark, Erbsen und den Gewürze dazugeben. 15 Minuten bei geschlossenem Deckel köcheln lassen. Wie beim Risotto immer ein wenig von der restlichen Brühe nachgießen.Die kleinen Gambas untermischen. Die großen Gambas mit den Muscheln dekorativ oben drauf setzen und weitere fünf Minuten leicht köcheln lassen.Mit Zitronenspalten servieren.";
            rezept.Image = "Sp_Rafis_Fisch_Paella";
            db.Insert(rezept);
            //rezept 3
            rezept.RezeptName = "Datteln im Speckmantel";
            rezept.Dauer = 20;
            rezept.Zutaten = "Für 4 Personen\n2 Pkt.Dattel(n), ohne Kerne\nSpeck, einige Scheiben";
            rezept.RezeptText = "Den Backofen auf 200°C vorheizen. Um jede Dattel ein Stück Speck wickeln.Die Speckdatteln für 15 - 20 Minuten auf einem Blech in die Mitte des Ofens schieben und warm servieren ";
            rezept.Image = "Sp_Datteln_im_Speckmantel";
            db.Insert(rezept);
            //rezept 4
            rezept.RezeptName = "Garnelen in Knoblauch";
            rezept.Dauer = 15;
            rezept.Zutaten = "Für 4 Personen\n400 g Garnele(n)\nküchenfertig\n4 Knoblauchzehe(n)\n3Chilischote(n), rot\n200 ml Olivenöl\n4 Scheibe/n Weißbrot";
            rezept.RezeptText = "Garnelen waschen und trocknen. Knoblauch in Scheiben schneiden, Chilischoten waschen, entkernen und in Streifen schneiden.  Olivenöl erhitzen, Knoblauch, Chili und die Garnelen zugeben und je nach Größe 2 - 3 Min.braten.Sofort mit Weißbrot servieren.";
            rezept.Image = "Sp_Garnelen_in_Knoblauch";
            db.Insert(rezept);
            //rezept 5
            rezept.RezeptName = " Gefülltes Rinderfilet mediterran";
            rezept.Dauer = 40;
            rezept.Zutaten = "Für 4 Personen\n800 g Rinderfilet(s)\n6 Tomate(n), getrocknete und in Öl eingelegte\n2  Tomate(n)\n150 g Blattspinat, frischer\n100 g Parmaschinken oder Serranoschinken\n2 EL Crème fraîche\n Pfeffer, schwarz\n Meersalz\n3 EL Olivenöl\n einige Stiele Zosmarin\neinige Stiele Thymian\n2 Zehe\n Knoblauch";
            rezept.RezeptText = " Das Rinderfilet längs zu einer großen Roulade schneiden, dafür knapp 1 cm über dem Schneidebrett den Schnitt ansetzen und nicht komplett durchschneiden, das dicke obere Stück nach hinten klappen und immer so weiter schneiden, bis das gesamte Filet zu einer großen Platte geschnitten ist. So bekommt man eine große, flache Scheibe aus dem Filet. Die Tomaten enthäuten und entkernen, mit den eingelegten, getrockneten Tomaten mit dem Pürierstab zerkleinern.Den Spinat 2 Sekunden in kochendem Wasser blanchieren, in Eiswasser geben und gut abtropfen lassen. Die Blätter auseinanderbreiten und trocken tupfen.Das Fleisch mit Salz und Pfeffer würzen.Die Tomatenmasse gleichmäßig auf dem Fleisch verteilen.Darüber die Spinatblätter auslegen, dann den Serranoschinken darauf verteilen und die Creme fraiche darüber verstreichen. Mit Salz und Pfeffer würzen. Den Backofen auf 80° Ober / Unterhitze vorheizen.Es ist ratsam, ein Backofenthermometer zu verwenden um die erforderliche Temperatur genau einzustellen. Das Fleisch nun wieder aufrollen und mit Küchengarn binden.Von außen noch mit Salz und Pfeffer würzen.In einer Pfanne Olivenöl erhitzen, die Filetrolle darin rundherum anbraten.Den Rosmarin und Thymian sowie den Knoblauch nach dem Anbraten in die Pfanne geben.Ein Bratenthermometer in die Mitte der Rolle stecken und für etwa 90 Minuten bei 80° in den Ofenschieben. Die Rolle ist gut, wenn eine Kerntemperatur von 60° erreicht ist.Dazu passt Blattspinat und Kartoffelgratin oder Sahnekartoffeln..";
            rezept.Image = "Sp_Gefuelltes_Rinderfilet_mediterran";
            db.Insert(rezept);
            //rezept 6
            rezept.RezeptName = "Spanische Tortilla";
            rezept.Dauer = 20;
            rezept.Zutaten = "500 g Kartoffel(n), vorwiegend festkochend\n150 g Zwiebel(n)\n4 Ei(er)\n250 ml\nOlivenöl\nSalz ";
            rezept.RezeptText = "Die Kartoffeln schälen, in kleine (0,5 - 1 cm) Würfel schneiden und mit einem gestrichenen Teelöffel Salz bestreuen. Die Zwiebeln fein hacken. Ca. 250 ml Olivenöl in einer Pfanne(24 cm Durchmesser) erhitzen und die Kartoffelwürfel zugeben.Die Kartoffeln sollten mit Öl gerade bedeckt sein. Die Temperatur auf mittlere Hitze zurückstellen und die Kartoffeln etwa 12 - 15 Minuten garen. Die Zwiebeln in einer zweiten Pfanne mit ein wenig Olivenöl 10 - 15 Minuten glasig und goldbraun anschwitzen.Die Eier in einer Schüssel geben und mit einem Schneebesen kräftig schlagen und salzen. Die Kartoffeln mit einem Sieb vom Olivenöl trennen. Kartoffeln und Zwiebeln zu den Eiern in die Schüssel geben und 3 - 5 Minuten ziehen lassen.Ca. 2 - 3 Esslöffel Olivenöl stark erhitzen, die Tortillamasse in die Pfanne geben und 2 Minuten braten. Wenn die Masse anfängt zu bräunen(die Eier nicht stocken lassen), die Tortilla mithilfe eines Tellers umdrehen.  Einfach den Teller auf die Tortilla legen und die Pfanne umdrehen, sodass die Tortilla auf dem Teller liegt.Dann die Tortilla in die Pfanne gleiten lassen. Von der Rückseite 1 Minute braten. Die Tortilla soll innen noch flüssig sein.Als Beilagen Brot oder Salat reichen..";
            rezept.Image = "Sp_Traditionelle_spanische_Tortilla";
            db.Insert(rezept);

            // Deutsche Rezepte index 13
            //rezept 1
            rezept.RezeptName = "Grunkohl-wrap mit kabanossi";
            rezept.Dauer = 30;
            rezept.Zutaten = "Für 3 Personen\n720 mlKÜHNE 2 Min. Grünkohl\n4Wrap(s) (à 70 g)  \n2Kabanos (à 150 g) \n200 gCrème fraîche\n2 El.Senf mittelscharf\n Salz \n Pfeffer ";
            rezept.RezeptText = ". Die Wraps von jeder Seite ca. 30 Sekunden in einer Pfanne mit heißem Öl anrösten.Die Crème fraîche mit dem Kühne Senf verrühren und mit etwas Salz und Pfeffer abschmecken. Die Kabanos in kleine Stücke schneiden und in einer Pfanne anbraten. Anschließend den Kühne Grünkohl Fix & Fertig dazugeben und kurz mit erhitzen. Die Wrap(s) mit der Crème fraîche dünn bestreichen und mit dem Grünkohl und den Kabanos belegen. Die Wrap(s) einrollen (siehe Verpackungsanleitung der Wraps). ";
            rezept.Image = "De_Grunkohl";
            db.Insert(rezept);
            //rezept 2
            rezept.RezeptName = "Rindsteak mit Gegrillten Zwiebel und Blattsalat";
            rezept.Dauer = 35;
            rezept.Zutaten = "Für 4 Personen Für die Steaks\n KÜHNE Würzsauce - z.B. Steak Saucen\nKÜHNE Gewürzgurken Auslese \n4 Steaks aus dem Rinderrücken (inkl. Fettrand) \n20 ml Oliven öl \n2 ZweigeRosmarin \n Salz \n Pfeffer aus der Mühle \n Für den Salat \n KÜHNE Dressing - z.B. Joghurt Dressing\n0,5 St.Lollo Bionda\n 0,5Kopfsalat\n2 St.Baby-Romanasalat\n1 SchaleKirschtomaten";
            rezept.RezeptText = "Die Salate putzen, waschen und anschließend trocken schleudern. Die Steaks mit Salz und Pfeffer würzen und in einer Pfanne in Olivenöl von beiden Seiten anbraten. Dann die Rosmarinzweige zugeben und bei 170 Grad für ca. 8–10 Min. in den Ofen geben. Wenn die Steaks aus dem Ofen kommen, in Alufolie einschlagen und 5 Min. ruhen lassen. In der Zwischenzeit den Salat in einer Schüssel mit Ihrem Lieblings - Kühne - Dressing marinieren und mit den halbierten Kirschtomaten auf Tellern anrichten. Zum Schluss die Rindersteaks dazulegen und mit Kühne Würzsaucen und Gewürzgurken servieren. ";
            rezept.Image = "De_Rindsteak";
            db.Insert(rezept);
            //rezept 3
            rezept.RezeptName = "EXOTISCHE HÄHNCHENSPIESSE MIT GURKENSALAT";
            rezept.Dauer = 45;
            rezept.Zutaten = "Für 4 Personen\n1Salatgurke(n)\n200 gKÜHNE Gewürzgurken Auslese \n1 Tl.KÜHNE Senf \n mittelschar/n6 El.Pflanzenöl/\n Salz \n Pfeffer\n500 gHähnchenbrustfilet\n2 El.Currypulver\n8kleine Tomate(n),\n200g Materialien\n4 Schaschlikspieße ";
            rezept.RezeptText = " Salatgurke waschen, halbieren, Kerne mit einem kleinen Löffel entfernen, schräg in Scheiben schneiden und in eine Schüssel geben. KÜHNE Gewürzgurken Auslese in dünne Scheiben schneiden und zur Salatgurke geben. Für das Dressing 6 EL Aufguss der KÜHNE Gewürzgurken in einer Schüssel mit KÜHNE Senf mittelscharf und 2 EL Öl glattrühren, salzen und pfeffern. Hähnchen in mundgerechte Würfel schneiden, mit 2 EL Öl und Currypulver vermengen. Tomaten waschen, halbieren, abwechselnd mit Hähnchen auf Spieße verteilen und mit Salz und Pfeffer würzen.Restliches Öl in einer Pfanne erhitzen und Spieße darin bei mittlerer Hitze rundherum ca. 10 Minuten goldbraun braten. Gurkensalat zu den Spießen servieren..";
            rezept.Image = "De_EXOTISCHE";
            db.Insert(rezept);
            //rezept 4
            rezept.RezeptName = " PUTEN-PAPRIKA-FRIKADELLEN MIT GEMISCHTEM SALAT";
            rezept.Dauer = 35;
            rezept.Zutaten = "Für 4 Personen\n2 El.Kühne Condimento Balsamico Bianco\n7 El.Pflanzenöl\n1 GlasSenf mittelscharf\n Salz \n Pfeffer \n1 PriseZucker\n1Zwiebel, 100g\n1 El.Pflanzen öl\n1Paprika, 250g \n500 gPutenbrustfilet \n 1Ei\n ca 100 gSemmelbrösel\n etwas Muskatnuss \n300 ggemischter Salat \n1 BundRadieschen";
            rezept.RezeptText = " Für das Dressing KÜHNE Condimento Balsamico Bianco, 4 EL Öl und 1 TL KÜHNE Senf mittelscharf mit dem Schneebesen zu einer Vinaigrette verrühren. Mit Salz, Pfeffer und Zucker abschmecken. Zwiebel schälen, fein würfeln und in 1 EL Öl 5 Minuten bei mittlerer Hitze glasig dünsten. Paprika waschen, entkernen und grob würfeln.Fleisch ebenfalls grob würfeln und beides portionsweise im Blitzhacker fein hacken und in eine Schüssel geben.Gebratene Zwiebel, Ei und 1 EL KÜHNE Senf mittelscharf zugeben, alles gründlich vermengen und so viel Semmelbrösel zugeben, dass eine formbare Masse entsteht. Mit Salz, Pfeffer und frisch geriebener Muskatnuss abschmecken. 8 Frikadellen formen, und in restlichem Öl in einer Pfanne portionsweise bei mittlerer Hitze ca. 15 Minuten von beiden Seiten goldbraun braten und warmstellen. Salat waschen, abtropfen lassen und in mundgerechte Stücke zupfen.Radieschen waschen, in feine Scheiben schneiden und zum Salat geben.Beides mit Dressing vermengen und zu den Frikadellen servieren.Dazu KÜHNE Senf mittelscharf reichen  ca 100 gSemmelbrösel etwas Muskatnuss 300 ggemischter Salat 1 BundRadieschen * Tipp: Wer keinen Blitzhacker hat, kann ersatzweise einen Standmixer nehmen oder die Zutaten mit einem scharfen Messer per Hand hacken "; 
              rezept.Image = "De_PUTEN";
            db.Insert(rezept);
            //rezept 5
            rezept.RezeptName = " SAUERKRAUT-SELLERIE-SÜPPCHEN MIT NORDSEEKRABBEN";
            rezept.Dauer = 35;
            rezept.Zutaten = "Für 4 Personen\n150 gKnollensellerie \n1Karotte (à 100 g)  \n1Gemüsezwiebel (à 250 g) \n 200 gKartoffeln \n200 gKÜHNE Fasskraut  \n2 El.Butter  \n1 lGemüsebrühe  \n1 El.KÜHNE Condimento Balsamico Bianco \nSalz  \nPfeffer  \nZucker \n100 gNordseekrabben \n4 ZweigeDill";
            rezept.RezeptText = " Knollensellerie, Karotte, Zwiebel und Kartoffeln schälen und grob würfeln. Kühne Fasskraut natürlich mild abtropfen lassen. Zwiebel in Butter 5 Minuten bei mittlerer Hitze glasig dünsten. Kühne Fasskraut natürlich mild, Kartoffeln, Karotten und Sellerie zugeben und 5 Minuten mitdünsten. Gemüsebrühe aufgießen und 20 Minuten mit Deckel weich kochen.";
            rezept.Image = "De_SAUERKRAUT";
            db.Insert(rezept);
            //rezept 6
            rezept.RezeptName = " KARTOFFELSUPPE MIT GEBRATENEN CHORIZOWÜRFELN";
            rezept.Dauer = 25;
            rezept.Zutaten = "Für 8 Personen\n150 gKnollensellerie \n1Karotte (à 50 g) \n1Gemüsezwiebel (à 250 g) \n2Knoblauchzehen \n350 gKartoffeln, mehligkochend \n2 ZweigeRosmarin \n2 El.Butter \n2 BlätterSalbei  \n100 mlWeißwein \n750 mlGemüsebrühe  100 gChorizo (spanische Paprikawurst) / 1 El.Oliven öl /4 Zweigeglatte Petersilie / \nSalz \n1 Tl.KÜHNE Tafel Meerrettich\nPfeffer";
            rezept.RezeptText = " Knollensellerie, Karotte, Zwiebel, Knoblauch und Kartoffeln schälen und grob würfeln. Zwiebel und Knoblauch mit Rosmarin in Butter 5 Minuten glasig schwitzen.Kartoffeln, Karotten, Salbei und Sellerie zugeben und 5 Minuten mitdünsten. Weißwein zugeben, einmal aufkochen, Gemüsebrühe aufgießen und 20 Minuten mit Deckel weich kochen. Chorizo in kleine Würfel schneiden und in Öl 5 Minuten kross braten.Auf etwas Küchenpapier abtropfen lassen.Petersilienblätter fein hacken. Rosmarin und Salbei entfernen, Suppe mit einem Pürierstab fein pürieren, Kühne Tafelmeerrettich zugeben, mit Salz und Pfeffer abschmecken und mit Chorizo und Petersilie als Garnitur servieren. Tipp: Wenn Sie keine Chorizo bekommen, nehmen Sie einfach Baconstreifen oder Schinkenwürfel.*.";
            rezept.Image = "De_KARTOFFELSUPPE";
            db.Insert(rezept);

            // Französische Rezepte index 19
            //rezept 1
            rezept.RezeptName = "Französischer_Kartoffelsalat";
            rezept.Dauer = 30;
            rezept.Zutaten = "Für 4 Personen 720 ml Kühne 2 Min Grünkol \n 1,5 kg festkochende Kartoffeln \n 2  rote Zwiebeln \n 1  Knoblauchzehe \n 1 Bund Schnittlauch \n 5 EL Öl \n 1 TL Honig \n4 EL Weißweinessig \nTL Gemüsebrühe(instant) \n 3 EL körniger Senf Salz und Pfeffer ";
            rezept.RezeptText = " Die Kartoffeln waschen und ungeschält in einem Topf mit reichlich Wasser weich kochen.Die weichen Kartoffeln abschütten, etwas ausdampfen lassen und pellen. Je nach Größe halbieren oder vierteln und in eine Schale geben. (Tipp: festkochende Kartoffeln eignen sich am besten, da sie nicht zerfallen, wenn sie nach dem Kochen in Scheiben geschnitten und mit den übrigen Zutaten gemischt werden) Senf - Dressing Die Schalotten schälen und in Würfel schneiden. In eine kleine Schüssel geben.Die Petersilienblättchen von den Zweigen zupfen und grob/ fein hacken.Gemeinsam mit einem Löffel(bestenfalls frisch gehackten) Thymian in die Schüssel geben. 3 EL braunen Zucker, 7 Esslöffel Weisswein Essig und 10 Esslöffel Pflanzenöl hinzufügen und kurz verrühren. Mit Salz und Pfeffer verfeinern.Zuletzt ca. 7 EL Senf hinzufügen und alles gut verrühren.Das Senf Dressing zu den Kartoffeln dazugeben und vermengen. Den Kartoffelsalat mindestens 30 Minuten ziehen lassen.Vor dem Servieren nochmals mit Salz, Pfeffer und ggfls. Öl / Essig abschmecken.Gutes Gelingen :) Videoanleitung gibts";
            rezept.Image = "Fr_Flad";
            db.Insert(rezept);
            // Rezept 2
            rezept.RezeptName = " Französische Zwiebelsuppe";
            rezept.Dauer = 35;
            rezept.Zutaten = "Für 4 Personen \n 600 g Zwiebeln\n 3  Knoblauchzehen\n 3 Stiele Thymian\n 2 EL Öl \n 850 ml Gemüsebrühe \n 4 EL dunkler Balsamico Essig \n 150 ml trockener Weißwein \n Salz \n Pfeffer \n 1 Prise Zucker \n 300 g Bauernbrot \n 200g Greyerzer Käse ";    
            rezept.RezeptText = " Zwiebeln und Knoblauch schälen. Zwiebeln in Ringe schneiden, Knoblauch fein hacken. Thymian waschen, trocken schütteln und fein hacken. Öl in einem Topf erhitzen.Zwiebeln und Knoblauch darin bei schwacher Hitze ca. 10 Minuten weich schmoren, ohne dass sie braun werden.Ca. 2 / 3 des Thymians zufügen und kurz mitschmoren. Mit Brühe, Essig und Wein ablöschen, mit Salz, Pfeffer und Zucker würzen.Suppe zugedeckt ca. 15 Minuten köcheln.2. Brot grob zerzupfen.Käse reiben. Suppe in 4 ofenfeste Förmchen füllen, Brot darüber verteilen und Käse großzügig darüberstreuen.Im vorgeheizten Backofen(E - Herd: 225 °C / Umluft: 200 °C / Gas: s.Hersteller) 5–7 Minuten überbacken. Suppe vorsichtig aus dem Ofen nehmen und anrichten. .";
            rezept.Image = "Fr_Flad";
            db.Insert(rezept);
            // Rezept 3
            rezept.RezeptName = " Fladenbrotpizza französische Art ";
            rezept.Dauer = 30;
            rezept.Zutaten = "Für 4 Personen \n 2  kleine, runde Fladenbrote(ca. 200 g)  \n 150 g Crème fraîche \n 100 g Radicchio-Salat \n 2  reife Birnen \n 2–3 EL Zitronensaft \n 40 g Walnusskerne \n 150 g Gorgonzola-Käse \n 3–4 EL Honig \n Backpapier ";
            rezept.RezeptText = " Fladenbrote waagerecht halbieren und mit den Schnittflächen nach oben auf ein mit Backpapier ausgelegtes Backblech legen. Mit Crème fraîche bestreichen.2. Radicchio putzen, waschen und abtropfen lassen.Radicchioblätter in Stücke zupfen. Birnen waschen, trocken reiben und in dünne Spalten schneiden und mit Zitronensaft beträufeln.Walnusskerne grob hacken.3. Fladenbrote mit Salat und Birnenspalten belegen. Gorgonzola in Würfel schneiden und darauf verteilen.Mit Walnusskernen bestreuen und mit Honig beträufeln. Im vorgeheizten Backofen(E - Herd: 225 °C / Umluft: 200 °C / Gas: s.Hersteller) ca. 20 Minuten backen.";
            rezept.Image = "Fr_Flad";
            db.Insert(rezept);
            // Rezept 4
            rezept.RezeptName = "SAUERKRAUT-SELLERIE-SÜPPCHEN";
            rezept.Dauer = 30;
            rezept.Zutaten = "Für 4 Personen \n 300 g Kastenweißbrot \n 4 Eier(Größe M) \n 200 g Schlagsahne \n 1–2 TL Zimtpulver \n 1 EL Zucker \n 1 Päckchen Vanillin-Zucker \n 40 g Butterschmalz \n 500 g Aprikosen \n 4 EL flüssiger Honig \n Puderzucker ";
            rezept.RezeptText = "Brot in 4 dicke Scheiben schneiden.Jede Scheibe in 5 gleichbreite Sticks schneiden.Eier, Sahne, Zimt, Zucker und Vanillin - Zucker gut verquirlen. Brotsticks nebeneinander in eine flache Form legen. Mit Eiersahne gleichmäßig begießen.2. Nach ca. 5 Minuten Sticks wenden, nochmals ca. 5 Minuten ziehen lassen.bis die Brotsticks die Eiersahne komplett aufgesogen haben. Butterschmalz in 3–4 Portionen in einer Pfanne erhitzen.Sticks darin portionsweise unter Wenden bei mittlerer Hitze goldgelb braten.3. Herausnehmen und warm halten.4. Aprikosen waschen, abtropfen lassen, halbieren und Stein herauslösen. Aprikosen in Spalten schneiden. Brot - Sticks und Aprikosen auf Tellern anrichten.Mit Honig beträufeln und eventuell mit Puderzucker bestäuben";
            rezept.Image = "Fr_Flad";
            db.Insert(rezept);
            //rezept 5
            rezept.RezeptName = "Französisches Pizza-Naan-Brot ";
            rezept.Dauer = 90;
            rezept.Zutaten = "Für 6 Personen \n 75 ml Milch \n Zucker, Salz \n 1 TL Trockenhefe \n 250 g + etwas Mehl \n 1 EL Öl \n 75 g Vollmilchjoghurt\n 1  Ei(Gr.M) \n Tomatensoße \n 125 g Mozzarella \n 1 Dose(n)(185 g) Thunfisch im eigenen Saft \n 3 EL Kapern(Glas) \n Salz, Pfeffer\n Backpapier ";
            rezept.RezeptText = " Für den Grundteig Backofen vorheizen (E-Herd: ca. 50 °C). Milch lauwarm erwärmen. Milch, 1 TL Zucker und Hefe verrühren und ca. 25 Minuten ruhen lassen. 250 g Mehl und 1⁄2 TL Salz mischen. Hefemilch, Öl, Joghurt und Ei zugeben.2. Zuerst die Zutaten mit einem Kochlöffel verrühren.Dann mit den Händen zu einem glatten und geschmeidigen Teig verkneten.3. Den Teig mit einem Küchentuch abdecken und im warmen Ofen ca. 1 Stunde gehen lassen, bis sich das Volumen verdoppelt hat.4. Nach dem Gehen auf bemehlter Arbeitsfläche noch einmal kräftig durchkneten. Dadurch wird der Teig elas¬tischer und besser formbar. Dann zu 6 Kugeln formen und nochmals ca. 15 Minuten ruhen lassen.5. Käse in dünne Scheiben schneiden.Thunfisch und Kapern in einem Sieb gut abtropfen lassen.6. Für die Pizzasoße: Je 1 Zwiebel und Knoblauchzehe schälen, fein würfeln. 1 EL Öl in einem Topf erhitzen.Zwiebel und Knoblauch darin glasig dünsten. 1 Dose(425 ml) Tomaten zugeben, mit einem Pfannenwender etwas zerkleinern.7. Aufkochen und 30–40 Minuten leicht dicklich einköcheln. (Vorsicht – die Soße spritzt!). Je 4 Stiele Oregano und Basilikum waschen, trocken schütteln, Blättchen abzupfen und fein hacken. Unter die fertige Soße rühren.8. Mit Salz, Pfeffer und Zucker abschmecken.9. Jede Kugel mit der Teigrolle zu ca. 1⁄2 cm dünnen ovalen Fladen(ca. 18x10 cm) ausrollen.Eine Pfanne(Gusseisen ist aufgrund der natürlichen Beschichtung am besten geeignet) ohne Fett erhitzen10. Brotfladen darin bei starker Hitze nacheinander von jeder Seite 1–2 Minuten goldbraun braten.Wenn das Brot Blasen wirft, wenden und von der anderen Seite braten.Ofen vorheizen(E-Herd: 225°C / Umluft: 200°C / Gas: s.11. Hersteller). Blech mit Backpapier auslegen. Brote mit Pizzasoße, Thunfisch, Kapern und Käse belegen. Mit Salz und Pfeffer würzen.Auf dem Blech im heißen Ofen 8–10 Minuten backen. Evtl.mit Basilikumblättchen bestreuen";
            rezept.Image = "Fr_Flad";
            db.Insert(rezept);
            // Rezept 6
            rezept.RezeptName = "Kartoffelküchlein_mit_Zwiebeln_Feldsalat";
            rezept.Dauer = 60;
            rezept.Zutaten = " 1  Knoblauchzehe \n 3  Zweige Rosmarin \n 50 ml + 2 EL Olivenöl \n 200 g rote Zwiebeln \n 800 g Kartoffeln \n Salz \n 500 g Schweinefilet \n 3–4 Stiel(e) Thymian \n Pfeffer \n 1 EL Öl \n 2  Lauchzwiebeln \n 75 g Doppelrahm-Frischkäse \n 150 g Feldsalat \n 1  Tomate \n 2 EL Weißwein-Essig\n 1 TL Honig \n Küchengarn";
            rezept.RezeptText = " Knoblauch schälen und in kleine Stücke schneiden. 1 Zweig Rosmarin waschen, trocken schütteln, Nadeln abstreifen und hacken. Mit 50 ml Olivenöl und Knoblauch in einen kleinen Topf geben und bei geringer Temperatur ca. 15 Minuten durchziehen lassen, vom Herd nehmen.2. Eine Springform(26 cm Ø) mit ca. 1 EL Rosmarin-Olivenöl auspinseln.3. Zwiebeln schälen und in dünne Scheiben hobeln.Kartoffeln schälen, waschen und dünn hobeln.Ca. 1 / 3 der Kartoffelscheiben auf dem Boden der Springform verteilen, mit Salz würzen, mit etwas Rosmarin-Olivenöl beträufeln.4. Ca.die Hälfte der Zwiebelringe auf die Kartoffelschicht legen, mit etwas Rosmarin - Öl beträufeln.Vorgang wiederholen, mit einer Kartoffelschicht abschließen.Restliches Rosmarin-Olivenöl darüberträufeln, mit Salz würzen.5. Im vorgeheizten Backofen(E - Herd: 200 °C / Umluft: 175 °C / Gas: s.Hersteller) 35–40 Minuten backen.6. Fleisch waschen, trocken tupfen und in Medaillons schneiden. Thymian und 2 Zweige Rosmarin waschen, trocken schütteln. In Stücke auf ca. die Dicke der Medaillons schneiden.Mit Küchengarn um das Fleisch binden.. Medaillons mit Salz und Pfeffer würzen. Öl in einer Pfanne erhitzen.Fleisch darin unter Wenden 7–8 Minuten braten.8. Lauchzwiebeln putzen, waschen und in dünne Röllchen schneiden.Fleisch herausnehmen und warm halten.Lauchzwiebeln ins Bratfett geben, darin 1–2 Minuten andünsten. Frischkäse und 4–5 EL Wasser einrühren, aufkochen und ca. 2 Minuten köcheln lassen, mit Salz und Pfeffer abschmecken.9. Salat putzen, waschen und gut abtropfen lassen. Tomate putzen, waschen und in kleine Würfel schneiden.Essig und Honig verrühren. 2 EL Olivenöl tröpfchenweise unterrühren, mit Salz und Pfeffer abschmecken.10. Salat, Tomate und Vinaigrette vermengen.11. Kartoffelkuchen aus dem Ofen nehmen, in Stücke schneiden, mit Medaillons, Soße und Salat anrichten. ";
            rezept.Image = "Fr_Flad";
            db.Insert(rezept);
        }
    }
}