using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Trapez : INullable
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

    public Trapez(List<double> args)
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

        bok_a = .0;
        bok_b = .0;
        bok_c = .0;
        bok_d = .0;

        this.WyznaczBoki();
    }

    public void WyznaczBoki()
    {
        bok_a = this.WyznaczDlugosc(wspolrz_x1, wspolrz_y1, wspolrz_x2, wspolrz_y2);
        bok_b = this.WyznaczDlugosc(wspolrz_x2, wspolrz_y2, wspolrz_x3, wspolrz_y3);
        bok_c = this.WyznaczDlugosc(wspolrz_x3, wspolrz_y3, wspolrz_x4, wspolrz_y4);
        bok_d = this.WyznaczDlugosc(wspolrz_x4, wspolrz_y4, wspolrz_x1, wspolrz_y1);
    }

    public double WyznaczDlugosc(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public double WyznaczObwod()
    {
        return Math.Round(this.bok_a + this.bok_b + this.bok_c + this.bok_d, 2);
    }

    private double PoleTrojkata(double p, double a, double b, double c) {
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public double WyznaczPole()
    {
        double przekatna = this.WyznaczDlugosc(wspolrz_x1, wspolrz_y1, wspolrz_x3, wspolrz_y3);
        double p1 = bok_a + bok_b + przekatna;
        double p2 = przekatna + bok_c + bok_d;

        return Math.Round(this.PoleTrojkata(0.5 * p1, bok_a, bok_b, przekatna) + this.PoleTrojkata(0.5 * p2, bok_c, bok_d, przekatna), 2);
    }

    public string Pole()
    {
        return "Pole trapezu: " + WyznaczPole().ToString();
    }

    public string Obwod()
    {
        return "Obwod trapezu: " + WyznaczObwod().ToString();
    }

    public bool Validator() {
        double a_a1 = Math.Abs((wspolrz_y2 - wspolrz_y1) / (wspolrz_x2 - wspolrz_x1));
        double a_a2 = Math.Abs((wspolrz_y4 - wspolrz_y3) / (wspolrz_x4 - wspolrz_x3));

        double a_b1 = Math.Abs((wspolrz_y3 - wspolrz_y2) / (wspolrz_x3 - wspolrz_x2));
        double a_b2 = Math.Abs((wspolrz_y1 - wspolrz_y4) / (wspolrz_x1 - wspolrz_x4));

        return (a_a1 == a_a2 || a_b1 == a_b2) && this.WyznaczPole() != 0;
    }

    public override string ToString()
    {
        string returning_str = "Trapez o wspolrzednych (" + this.wspolrz_x1.ToString()
                + ", " + this.wspolrz_y1.ToString() + "), ("
                + this.wspolrz_x2.ToString()
                + ", " + this.wspolrz_y2.ToString() + "), ("
                + this.wspolrz_x3.ToString()
                + ", " + this.wspolrz_y3.ToString() + ") oraz ("
                + this.wspolrz_x4.ToString()
                + ", " + this.wspolrz_y4.ToString() + ").";
        return returning_str;
    }

    public bool IsNull
    {
        get
        {
            // Put your code here
            return m_Null;
        }
    }

    public static Trapez Null
    {
        get
        {
            Trapez h = new Trapez();
            h.m_Null = true;
            return h;
        }
    }

    public static Trapez Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;

        string[] arguments = s.Value.Split("/".ToCharArray());

        if (arguments.Length != 8)
        {
            throw new ArgumentException("$Niepoprawna liczba argumentów! (wymagane 8)$");
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
            throw new ArgumentException("$Niepoprawny typ danych!$");
        }

        Trapez u = new Trapez(tmp);
        if (u.Validator() == false) throw new ArgumentException("$Nie da sie utworzyc trapezu z podanych punktow!$");
        return u;
    }

    private bool m_Null;
}


