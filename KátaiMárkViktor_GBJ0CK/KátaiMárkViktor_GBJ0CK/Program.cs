using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KátaiMárkViktor_GBJ0CK
{
    class Program
    {
        static void Main(string[] args)
        {
            Szobeolvaso szobeolvaso = new Szobeolvaso();

            Console.WriteLine("\t \t \t Üdvözöllek a játékban ifjú szóharcos!\n Az itt látható számok küzöl válassz ki egyet, attól függően, hogy melyik játékmódot szeretnéd játszani!\n");

            Console.WriteLine("1 (Kétjátékos mód) \t 2 (Egyjátékos vs számítógép) \t 3 (Szótárbővítő mód)\n");

            Console.Write("A választott játék száma: ");

            int beirtszam = int.Parse(Console.ReadLine());
            if(beirtszam==1)
            {
                szobeolvaso.KetjatekosMod();
            }
            else if(beirtszam==2)
            {
                szobeolvaso.JatekosVsGep();
            }
            else if (beirtszam == 3)
            {
                szobeolvaso.Szotarbovitomod();
            }
            Console.ReadLine();    
            
            //A kétjátékos móban illetve az egyjátékos müdban 10 elem a maximum ameddig el lehet menni, a szótárbővítőben akármeddig.
            //Nincs "Y" kezdetű szó a szótárban így PL.: Sey => ezzel véget lehet vetni a játéknak.
            //Csak nevek (nagybetűvel kezdődik) vannak a szótárban, de a program más szavakkal is kompatibilis a betűk átalakítása végett.
            // A szótár a \bin\Debug mappán belül van elhelyezve.
        }
    }
}
