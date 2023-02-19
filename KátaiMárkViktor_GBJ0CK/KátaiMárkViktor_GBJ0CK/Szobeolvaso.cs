using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KátaiMárkViktor_GBJ0CK
{
    class Szobeolvaso
    {
        private string szavak;
        private int szamlalo;
        private string kezdoszo;

        public Szobeolvaso()
        {
            Beolvasas(szavak, szamlalo, kezdoszo);
        }

        public void Beolvasas(string sorok, int db, string randomszo)
        {
            StreamReader sr = new StreamReader("magyarszavak.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                sorok += sr.ReadLine() + ";";
                db++;
            }
            sr.Close();

            this.szamlalo = db;
            this.szavak = sorok;

            //Kezdoszo

            Random r = new Random();
            

            for (int i = 0; i < Szavak.Length; i++)
            {
                randomszo = Szavak[r.Next(0, Szavak.Length)];
            }
            this.kezdoszo = randomszo;
        }

        public string[] Szavak
        {
            get
            {
                return szavak.Substring(0, szavak.Length - 1).Split(';');
            }
        }

        public int Szamlalo
        {
            get
            {
                return szamlalo;
            }
            set
            {
                szamlalo = value;
            }
        }

        public string Kezdoszo
        {
            get
            {
                return kezdoszo;
            }
            set
            {
                kezdoszo = value;
            }
        }

        public bool Bennevane(string mondat)
        {
            Szobeolvaso ketjatekosseged = new Szobeolvaso();

            int j = 0;
            while (j < ketjatekosseged.Szavak.Length && mondat != ketjatekosseged.Szavak[j])
            {
                j++;
            }
            if (j < ketjatekosseged.Szavak.Length)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string Kivalaszto(Random r, string elsoszohelye, string tartalmazza)
        {
            Szobeolvaso kivalaszto = new Szobeolvaso();

            char jatekosutolsobetuje = char.Parse(elsoszohelye.Substring(elsoszohelye.Length - 1));

            string segedstring = "";
            int db = 0;

            for (int i = 0; i < kivalaszto.Szavak.Length; i++)
            {
                char robotszoelsobetuje = char.Parse(kivalaszto.Szavak[i].Substring(0, 1));
                if (jatekosutolsobetuje == char.ToLower(robotszoelsobetuje) && !tartalmazza.Contains(kivalaszto.Szavak[i]))
                {
                    segedstring += kivalaszto.Szavak[i] + ";";
                    db++;

                }
                else
                {
                    continue;
                }

            }

            if (segedstring != "")
            {
                string[] segedtomb = new string[db];
                segedtomb = segedstring.Substring(0, segedstring.Length - 1).Split(';');
                string vegso = "";
                for (int i = 0; i < db; i++)
                {
                    vegso = segedtomb[r.Next(0, db)];

                }
                return vegso;
            }
            else
            {
                return "#";
            }

        }

        public void Eredmenykiir(string elsojatekosneve, int elsojatekospontszama, string masodikjatekosneve, int masodikjatekospontszama, int szolanchossza, string vegsoszolanc)
        {
            Console.Write("{0} pontszáma: {1} \t", elsojatekosneve, elsojatekospontszama);
            Console.Write("{0} pontszáma: {1} \t", masodikjatekosneve, masodikjatekospontszama);
            Console.WriteLine("Eddig {0} elemű a szólánc.", szolanchossza);

            if (vegsoszolanc != "")
            {
                Console.WriteLine(vegsoszolanc.Substring(0, vegsoszolanc.Length - 1));
            }
            if (elsojatekospontszama > masodikjatekospontszama)
            {
                Console.WriteLine("\n \t \t \tNyertél {0}!\n", elsojatekosneve);
            }
            else if (elsojatekospontszama < masodikjatekospontszama)
            {
                Console.WriteLine("\n \t \t \tNyertél {0}!\n", masodikjatekosneve);
            }
            else if (elsojatekospontszama == masodikjatekospontszama)
            {
                Console.WriteLine("\n \t \t \tDöntetlen!\n");
            }
        }

        public void EredmenykiirRobot(string elsojatekosneve, int elsojatekospontszama, int robotpontszama, int szolanchossza, string vegsoszolanc)
        {
            Console.Write("{0} pontszáma: {1} \t", elsojatekosneve, elsojatekospontszama);
            Console.Write("A számítógép pontszáma: {0} \t", robotpontszama);
            Console.WriteLine("Eddig {0} elemű a szólánc.", szolanchossza);
            if (vegsoszolanc != "")
            {
                Console.WriteLine(vegsoszolanc.Substring(0, vegsoszolanc.Length - 1));
            }
            if (elsojatekospontszama > robotpontszama)
            {
                Console.WriteLine("\n \t \t \tNyertél {0}!\n", elsojatekosneve);
            }
            else if (elsojatekospontszama < robotpontszama)
            {
                Console.WriteLine("\n \t \t \tNyert a számítógép!\n");
            }
            else if (elsojatekospontszama == robotpontszama)
            {
                Console.WriteLine("\n \t \t \tDöntetlen!\n");
            }
        }

        public void Szotarfrissito(string szotarfrissitoszavak)
        {
            if (szotarfrissitoszavak != "")
            {
                string[] szotarfirssitotomb = szotarfrissitoszavak.Substring(0, szotarfrissitoszavak.Length - 1).Split(';');

                StreamWriter sw = new StreamWriter("magyarszavak.txt", true, Encoding.UTF8);
                for (int i = 0; i < szotarfirssitotomb.Length; i++)
                {
                    sw.WriteLine(szotarfirssitotomb[i]);
                }
                sw.Close();
            }
        }

        public void KetjatekosMod()
        {
            Szobeolvaso ketjatekos = new Szobeolvaso();

            char kezdoszoutolsobetuje = char.Parse(ketjatekos.kezdoszo.Substring(ketjatekos.kezdoszo.Length - 1));

            string bennevanetomb = "";
            string vegsoszolanc = "";

            int elsopontszama = 0;
            int masodikpontszama = 0;
            int szolanchossza = 0;

            Console.WriteLine("\n \t \t \t \tKÉTJÁTÉKOS MÓD");
            Console.WriteLine("\nA játékosok nevét szeretném kérni!");

            Console.Write("1. Játékos neve: ");
            string elsojatekosneve = Console.ReadLine();
            Console.Write("2. Játékos neve: ");
            string masodikbeolvas = Console.ReadLine();

            char subkettonegy = ' ';

            Console.WriteLine("A gép által generált első szó: {0}", ketjatekos.kezdoszo);

            for (int i = 0; i < ketjatekos.Szavak.Length; i++)
            {
                string elsobeker = Console.ReadLine();
                char subegy = char.Parse(elsobeker.Substring(elsobeker.Length - 1));
                char subegyharom = char.Parse(elsobeker.Substring(0, 1));

                if (ketjatekos.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza < 1 && kezdoszoutolsobetuje == char.ToLower(subegyharom))
                {
                    elsopontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                }
                else if (ketjatekos.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza > 1 && szolanchossza < 10 && subkettonegy == char.ToLower(subegyharom))
                {
                    elsopontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                }
                else
                {
                    i = ketjatekos.Szavak.Length;
                }

                if (i < ketjatekos.Szavak.Length)
                {
                    masodikbeolvas = Console.ReadLine();
                    char subketto = char.Parse(masodikbeolvas.Substring(0, 1));
                    subkettonegy = char.Parse(masodikbeolvas.Substring(masodikbeolvas.Length - 1));

                    if (ketjatekos.Bennevane(masodikbeolvas) && szolanchossza < 10 && !bennevanetomb.Contains(masodikbeolvas) && subegy == char.ToLower(subketto))
                    {
                        masodikpontszama += masodikbeolvas.Length;
                        bennevanetomb += masodikbeolvas;
                        vegsoszolanc += masodikbeolvas + "-";
                        szolanchossza++;
                    }
                    else
                    {
                        i = ketjatekos.Szavak.Length;
                    }
                }
            }
            ketjatekos.Eredmenykiir(elsojatekosneve, elsopontszama, masodikbeolvas, masodikpontszama, szolanchossza, vegsoszolanc);
        }

        public void JatekosVsGep()
        {
            Szobeolvaso egyjatekos = new Szobeolvaso();

            Random r = new Random();

            string kezdoszoitt = egyjatekos.Kezdoszo;
            char kezdoszoutolsobetuje = char.Parse(kezdoszoitt.Substring(kezdoszoitt.Length - 1));

            string bennevanetomb = "";
            string vegsoszolanc = "";

            int elsojatekospontszama = 0;
            int robotpontszama = 0;
            int szolanchossza = 0;

            Console.WriteLine("\n \t \t \t \tEGYJÁTÉKOS VS SZÁMÍTÓGÉP MÓD");
            Console.WriteLine("\nA játékos nevét szeretném kérni!");

            Console.Write("1. Játékos neve: ");
            string elsojatekosneve = Console.ReadLine();

            Console.WriteLine("A gép által generált első szó: {0}", kezdoszoitt);
            char subkettonegy = ' ';

            for (int i = 0; i < egyjatekos.Szavak.Length; i++)
            {
                string elsobeker = Console.ReadLine();
                char subegy = char.Parse(elsobeker.Substring(elsobeker.Length - 1));
                char subegyharom = char.Parse(elsobeker.Substring(0, 1));

                if (egyjatekos.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza < 1 && kezdoszoutolsobetuje == char.ToLower(subegyharom))
                {
                    elsojatekospontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                }
                else if (egyjatekos.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza > 1 && szolanchossza < 10 && subkettonegy == char.ToLower(subegyharom))
                {
                    elsojatekospontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                }
                else
                {
                    i = egyjatekos.Szavak.Length;
                }

                if (i < egyjatekos.Szavak.Length)
                {
                    string robotbeker = egyjatekos.Kivalaszto(r, elsobeker, bennevanetomb);
                    char subketto = char.Parse(robotbeker.Substring(0, 1));
                    subkettonegy = char.Parse(robotbeker.Substring(robotbeker.Length - 1));

                    if (!bennevanetomb.Contains(robotbeker) && subegy == char.ToLower(subketto) && szolanchossza < 10)
                    {
                        robotpontszama += robotbeker.Length;
                        bennevanetomb += robotbeker;
                        vegsoszolanc += robotbeker + "-";
                        szolanchossza++;
                        Console.WriteLine(robotbeker);
                    }
                    else
                    {
                        i = egyjatekos.Szavak.Length;
                    }
                }

            }
            egyjatekos.EredmenykiirRobot(elsojatekosneve, elsojatekospontszama, robotpontszama, szolanchossza, vegsoszolanc);
        }

        public void Szotarbovitomod()
        {
            Szobeolvaso szotar = new Szobeolvaso();

            Random r = new Random();

            char kezdoszoutolsobetuje = char.Parse(szotar.Kezdoszo.Substring(szotar.Kezdoszo.Length - 1));
            string bennevanetomb = "";
            string vegsoszolanc = "";
            string szotarfrissito = "";
            int elsojatekospontszama = 0;
            int robotpontszama = 0;
            int szolanchossza = 0;

            Console.WriteLine("\n \t \t \t \tSZÓTÁRBŐVÍTŐ MÓD");
            Console.WriteLine("\nA játékos nevét szeretném kérni!");
            Console.Write("1. Játékos neve: ");
            string elsojatekosneve = Console.ReadLine();
            Console.WriteLine("A gép által generált első szó: {0}", szotar.Kezdoszo);

            char subkettonegy = ' ';

            for (int i = 0; i < szotar.Szavak.Length; i++)
            {
                string elsobeker = Console.ReadLine();
                char subegy = char.Parse(elsobeker.Substring(elsobeker.Length - 1));
                char subegyharom = char.Parse(elsobeker.Substring(0, 1));

                if (szotar.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza < 1 && kezdoszoutolsobetuje == char.ToLower(subegyharom))
                {
                    elsojatekospontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                }
                else if (!szotar.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza < 1 && kezdoszoutolsobetuje == char.ToLower(subegyharom))
                {
                    elsojatekospontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                    szotarfrissito += elsobeker + ";";
                }
                else if (szotar.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza > 1 && subkettonegy == char.ToLower(subegyharom))
                {
                    elsojatekospontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                }
                else if (!szotar.Bennevane(elsobeker) && !bennevanetomb.Contains(elsobeker) && szolanchossza > 1 && subkettonegy == char.ToLower(subegyharom))
                {
                    elsojatekospontszama += elsobeker.Length;
                    bennevanetomb += elsobeker;
                    vegsoszolanc += elsobeker + "-";
                    szolanchossza++;
                    szotarfrissito += elsobeker + ";";
                }
                else
                {
                    i = szotar.Szavak.Length;
                }

                if (i < szotar.Szavak.Length)
                {
                    string robotbeker = szotar.Kivalaszto(r, elsobeker, bennevanetomb);
                    char subketto = char.Parse(robotbeker.Substring(0, 1));
                    subkettonegy = char.Parse(robotbeker.Substring(robotbeker.Length - 1));

                    if (!bennevanetomb.Contains(robotbeker) && subegy == char.ToLower(subketto))
                    {
                        robotpontszama += robotbeker.Length;
                        bennevanetomb += robotbeker;
                        vegsoszolanc += robotbeker + "-";
                        szolanchossza++;
                        Console.WriteLine(robotbeker);
                    }
                    else
                    {
                        i = szotar.Szavak.Length;
                    }
                }
            }
            szotar.EredmenykiirRobot(elsojatekosneve, elsojatekospontszama, robotpontszama, szolanchossza, vegsoszolanc);
            szotar.Szotarfrissito(szotarfrissito);
        }
    }
}
