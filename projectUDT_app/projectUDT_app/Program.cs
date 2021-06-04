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

        public static string ResolveFigureType()
        {
            int option;
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                //Console.Clear();
                throw new ArgumentException("Wprowadzono niepoprawne dane!");
            }

            string figura = "";

            switch (option)
            {
                case 1:
                    figura = Figury.Shape.Punkt.ToString();
                    break;
                case 2:
                    figura = Figury.Shape.Prosta.ToString();
                    break;
                case 3:
                    figura = Figury.Shape.Trojkat.ToString();
                    break;
                case 4:
                    figura = Figury.Shape.Kwadrat.ToString();
                    break;
                case 5:
                    figura = Figury.Shape.Prostokat.ToString();
                    break;
                case 6:
                    figura = Figury.Shape.Rownoleglobok.ToString();
                    break;
                case 7:
                    figura = Figury.Shape.Trapez.ToString();
                    break;
                case 8:
                    figura = Figury.Shape.Kolo.ToString();
                    break;
                case 9:
                    //Console.Clear();
                    throw new ArgumentException("Powrot do menu...");
                default:
                    //Console.Clear();
                    throw new ArgumentException("Wybrano niewlasciwa opcje!");
            }
            return figura;
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
                if (option == 4) throw new StoppAppException("Exit...");

                //Console.Clear();

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
                //Console.Clear();
                string err_mssg;
                if (!e.Message.Equals(""))
                {
                    err_mssg = e.Message;
                }
                else {
                    err_mssg = "Wprowadzono nieprawidlowe dane!";
                }

                if (e.Message.Equals("Exit...")) throw new StoppAppException();
                throw new ArgumentException(err_mssg);
            }
        }

        public static void WyswietlMenuInsert()
        {
            Console.WriteLine(@"
    Menu FIGUREXX
    Wprowadz nowe dane.
    Wybierz figure.");
            WyswietlFigury();
            string figura = ResolveFigureType();
            WprowadzDane(figura);
        }

        public static void WprowadzDane(string figura) {
            string query = "INSERT INTO dbo." + figura + " VALUES('";

            Console.WriteLine(@"
    Prosze wprowadzic po przecinku
    kolejne wspolrzedne figury.");

            string[] wspolrzedne = Console.ReadLine().Split(',');
            for (int i = 0; i < wspolrzedne.Length - 1; i++) {
                query += wspolrzedne[i] + "/";
            }

            query += wspolrzedne[wspolrzedne.Length - 1];

            query += "');";

            DBConnection database = new DBConnection();
            database.InsertQuery(query);

        }

        public static void WyswietlMenuSelect()
        {
            Console.WriteLine(@"
    Menu FIGUREXX
    Wyswietl dane figur.
    Wybierz figure.");
            WyswietlFigury();
            string figura = ResolveFigureType();
            WybierzPolecenie(figura);
        }

        public static void WybierzPolecenie(string figura) {
            Console.WriteLine(@"
    Menu FIGUREXX
    Wyswietl dane figur.
    Wybierz opcje.
    
    1. Wyswietl wspolrzedne zadanej figury.
    2. Wyswietl obwody figur.
    3. Wyswietl pola figur.
    4. Wyswietl obwody figur(posortowane).
    5. Wyswietl pola figur(posortowane).
    6. Wyswietl figury o obwodzie mniejszym od zadanej wartosci.
    7. Wyswietl figury o obwodzie wiekszym od zadanej wartosci.
    8. Wyswietl figury o polu mniejszym od zadanej wartosci.
    9. Wyswietl figury o polu wiekszym od zadanej wartosci.
    10. Wyswietl figury o obwodzie rownym zadanej wartosci.
    11. Wyswietl figury o polu rownym zadanej wartosci.
    12. Wyswietl wszystkie rekordy dla zadanej figury.

    13. Powrot do menu.");

            int option;
            List<string> atrybuty = new List<string>();
            string query = "SELECT " + figura + ".ToString() AS Info ";
            string query_if_sort = "";
            string query_where_condition = "";

            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {
                throw new ArgumentException("Wprowadzono niepoprawne dane!");
            }

            atrybuty.Add("Info");

            switch (option) {
                case 1:
                    break;
                case 2:
                    atrybuty.Add("Obwod");
                    query += ", " + figura + ".Obwod() AS Obwod ";
                    break;
                case 3:
                    atrybuty.Add("Pole");
                    query += ", " + figura + ".Pole() AS Pole ";
                    break;
                case 4:
                    atrybuty.Add("Obwod");
                    query += ", " + figura + ".Obwod() AS Obwod ";
                    query_if_sort = SortChoice("Obwod");
                    break;
                case 5:
                    atrybuty.Add("Pole");
                    query += ", " + figura + ".Pole() AS Pole ";
                    query_if_sort = SortChoice("Pole");
                    break;
                case 6:
                    atrybuty.Add("Obwod");
                    query += ", " + figura + ".Obwod() AS Obwod ";
                    query_where_condition = WhereCondition(figura, "Obwod", "<");
                    break;
                case 7:
                    atrybuty.Add("Obwod");
                    query += ", " + figura + ".Obwod() AS Obwod ";
                    query_where_condition = WhereCondition(figura, "Obwod", ">");
                    break;
                case 8:
                    atrybuty.Add("Pole");
                    query += ", " + figura + ".Pole() AS Pole ";
                    query_where_condition = WhereCondition(figura, "Pole", "<");
                    break;
                case 9:
                    atrybuty.Add("Pole");
                    query += ", " + figura + ".Pole() AS Pole ";
                    query_where_condition = WhereCondition(figura, "Pole", ">");
                    break;
                case 10:
                    atrybuty.Add("Obwod");
                    query += ", " + figura + ".Obwod() AS Obwod ";
                    query_where_condition = WhereCondition(figura, "Obwod", "=");
                    break;
                case 11:
                    atrybuty.Add("Pole");
                    query += ", " + figura + ".Pole() AS Pole ";
                    query_where_condition = WhereCondition(figura, "Pole", "=");
                    break;
                case 12:
                    atrybuty.Add("Obwod");
                    atrybuty.Add("Pole");  
                    query += ", " + figura + ".Obwod() AS Obwod";
                    query += ", " + figura + ".Pole() AS Pole ";
                    break;
                case 13:
                    throw new ArgumentException("Powrot do menu..");
                default:
                    throw new ArgumentException("Wybrano niewlasciwa opcje!");
            }
            query += "FROM dbo." + figura;

            if (!query_where_condition.Equals(""))
            {
                query += query_where_condition;
            }

            if (!query_if_sort.Equals(""))
            {
                query += query_if_sort;
            }

            query += ";";

            Console.WriteLine(query);

            DBConnection database = new DBConnection();
            database.SelectQuery(query, atrybuty);
        }

        public static string SortChoice(string thing) {
            string query = " ORDER BY " + thing;
            Console.WriteLine(@"
    Menu FIGUREXX
    Wyswietl dane figur.
    Sortuj:

    1. Rosnaco.
    2. Malejaco.");

            int option;

            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {
                throw new ArgumentException("Wprowadzono niepoprawne dane!");
            }

            switch (option)
            {
                case 1:
                    return query;
                case 2:
                    return query + " DESC";
                default:
                    throw new ArgumentException("Wybrano niewlasciwa opcje!");
            }
        }

        public static string WhereCondition(string figura, string thing, string delimiter) {
            double value;
            Console.WriteLine(@"
    Menu FIGUREXX
    Wyswietl dane figur.
    Prosze podac wartosc:
            ");

            try
            {
                value = double.Parse(Console.ReadLine());
            }
            catch
            {
                throw new ArgumentException("Wprowadzono niepoprawne dane!");
            }

            return " WHERE " + figura + ".Wyznacz" + thing + "() " + delimiter + " CONVERT(NVARCHAR, " + value.ToString() + ") ";
        }

        public static void WyswietlMenuDelete()
        {
            Console.WriteLine(@"
    Menu FIGUREXX
    Usun dane wybranej figury.
    Wybierz figure.");
            WyswietlFigury();
            string figura = ResolveFigureType();
            DeleteOptions(figura);
        }

        public static void DeleteOptions(string figura) {
            Console.WriteLine(@"
    Menu FIGUREXX
    Usun dane wybranej figury.
    Wybierz opcje:

    1. Usun figure o zadanym obwodzie.
    2. Usun figure o zadanym polu.
    3. Usun wszystkie rekordy.

    4. Powrot do menu.
        ");
            int option;
            string query = "DELETE dbo." + figura;

            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                throw new ArgumentException("Wprowadzono niepoprawne dane!");
            }

            switch (option)
            {
                case 1:
                    query += WhereCondition(figura, "Obwod", "=");
                    break;
                case 2:
                    query += WhereCondition(figura, "Pole", "=");
                    break;
                case 3:
                    break;
                case 4:
                    throw new ArgumentException("Powrot do menu...");
                default:
                    throw new ArgumentException("Wybrano niewlasciwa opcje!");
            }

            query += ";";
            Console.WriteLine(query);
            DBConnection database = new DBConnection();
            database.DeleteQuery(query);
        }

        static void Main(string[] args)
        {
            while (true){
                try
                {
                    WyswietlMenu();
                }
                catch (StoppAppException) {
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
