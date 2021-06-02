using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectUDT_app
{
    class Program
    {

        public static void WyswietlFigury() {
            Console.WriteLine(@"
    1. Punkt.
    2. Prosta.
    3. Trojkat.
    4. Kwadrat.
    5. Prostokat.
    6. Rownoleglobok.
    7. Trapez.
    8. Kolo.

    9. Powrot do menu.
            ");
        }

        public static void WyswietlMenu() {
            Console.WriteLine(@"
    Menu FIGUREXX
    
    1. Wprowadz nowa figure.
    2. Wyswietl dane figur.
    3. Usun wybrane figury.
    4. Zakoncz.
            ");
            ResolveMenuOption();
        }

        public static void ResolveMenuOption() {
            try
            {
                int option = int.Parse(Console.ReadLine());
                if (option > 4 || option < 1) throw new ArgumentException("Podano nieprawidlowy numer opcji!");
                if (option == 4) throw new StoppAppException("Exit");

                Console.Clear();

                switch (option) {
                    case 1:
                        WyswietlMenuInsert();
                        break;
                    case 2:
                        WyswietlMenuSelect();
                        break;
                    case 3:
                        WyswietlMenuDelete();
                        break;
                }
            }
            catch(Exception e) {
                if (e.Message.Equals("Exit")) throw new StoppAppException();
                throw new ArgumentException("Wprowadzono nieprawidlowe dane!");
            }
        }

        public static void WyswietlMenuInsert()
        {
            Console.WriteLine(@"
    Menu FIGUREXX
    Wprowadz nowe dane.");
            WyswietlFigury();
        }

        public static void WyswietlMenuSelect()
        {
            Console.WriteLine(@"
    Menu FIGUREXX
    Wyswietl dane figur.");
            WyswietlFigury();
        }

        public static void WyswietlMenuDelete()
        {
            Console.WriteLine(@"
    Menu FIGUREXX
    Usun dane wybranej figury.");
            WyswietlFigury();
        }

        static void Main(string[] args)
        {
            while (true){
                try
                {
                    WyswietlMenu();
                }
                catch (StoppAppException e) {
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}
