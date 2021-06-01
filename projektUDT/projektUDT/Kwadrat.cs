using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Kwadrat : INullable
{
    private double bok_a;
    private double bok_b;
    private double bok_c;
    private double bok_d;

    private double wspolrz_x1;
    private double wspolrz_x2;
    private double wspolrz_x3;
    private double wspolrz_x4;

    private double wspolrz_y1;
    private double wspolrz_y2;
    private double wspolrz_y3;
    private double wspolrz_y4;

    public Kwadrat(List<double> args)
    {
        m_Null = false;

        wspolrz_x1 = args[0];
        wspolrz_y1 = args[1];
        wspolrz_x2 = args[2];
        wspolrz_y2 = args[3];
        wspolrz_x3 = args[4];
        wspolrz_y3 = args[5];
        wspolrz_x4 = args[6];
        wspolrz_y4 = args[7];

        this.WyznaczBoki();
    }

    public void WyznaczBoki(){
        bok_a = this.WyznaczDlugosc(wspolrz_x1, wspolrz_y1, wspolrz_x2, wspolrz_y2);
        bok_b = this.WyznaczDlugosc(wspolrz_x2, wspolrz_y2, wspolrz_x3, wspolrz_y3);
        bok_c = this.WyznaczDlugosc(wspolrz_x3, wspolrz_y3, wspolrz_x4, wspolrz_y4);
        bok_d = this.WyznaczDlugosc(wspolrz_x4, wspolrz_y4, wspolrz_x1, wspolrz_y1);
    }

    public double WyznaczDlugosc(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public bool Validator() {
        return bok_a == bok_b
            && bok_b == bok_c
            && bok_c == bok_d
            && bok_d == bok_a;
    }

    public double WyznaczObwod()
    {
        return 4*bok_a;
    }

    public double WyznaczPole()
    {
        return Math.Pow(bok_a, 2);
    }

    public override string ToString()
    {
        // Replace the following code with your code
        return "";
    }

    public bool IsNull
    {
        get
        {
            // Put your code here
            return m_Null;
        }
    }

    public static Kwadrat Null
    {
        get
        {
            Kwadrat h = new Kwadrat();
            h.m_Null = true;
            return h;
        }
    }

    public static Kwadrat Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;

        string[] arguments = s.Value.Split("/".ToCharArray());

        if (arguments.Length != arguments_amount)
        {
            throw new ArgumentException("Niepoprawna liczba argumentów! (wymagane " + arguments_amount.ToString() + ")");
        }

        List<double> tmp = new List<double>();

        try
        {
            foreach (var x in arguments)
            {
                tmp.Add(double.Parse(x));
            }
        }
        catch
        {
            throw new ArgumentException("Niepoprawny typ danych!");
        }

        Kwadrat u = new Kwadrat(tmp);
        if (u.Validator() == false) throw new ArgumentException("Nie da sie utworzyc kwadratu z podanych punktow!");
        return u;
    }

    // This is a place-holder field member
    public static int arguments_amount = 8;
    private bool m_Null;
}


