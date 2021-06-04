using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Trojkat : INullable
{
    private double bok_a;
    private double bok_b;
    private double bok_c;

    private double wspolrz_x1;
    private double wspolrz_x2;
    private double wspolrz_x3;

    private double wspolrz_y1;
    private double wspolrz_y2;
    private double wspolrz_y3;

    public Trojkat(List<double> args)
    {
        m_Null = false;

        wspolrz_x1 = args[0];
        wspolrz_y1 = args[1];
        wspolrz_x2 = args[2];
        wspolrz_y2 = args[3];
        wspolrz_x3 = args[4];
        wspolrz_y3 = args[5];

        bok_a = .0;
        bok_b = .0;
        bok_c = .0;

        this.WyznaczBoki();
    }

    public void WyznaczBoki()
    {
        this.bok_a = this.WyznaczDlugosc(this.wspolrz_x1, this.wspolrz_y1, this.wspolrz_x2, this.wspolrz_y2);
        this.bok_b = this.WyznaczDlugosc(this.wspolrz_x2, this.wspolrz_y2, this.wspolrz_x3, this.wspolrz_y3);
        this.bok_c = this.WyznaczDlugosc(this.wspolrz_x3, this.wspolrz_y3, this.wspolrz_x1, this.wspolrz_y1);
    }

    public double WyznaczDlugosc(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public double WyznaczObwod()
    {
        return Math.Round(this.bok_a + this.bok_b + this.bok_c, 2);
    }

    public double WyznaczPole()
    {
        double p = 0.5 * this.WyznaczObwod();
        return Math.Round(Math.Sqrt(p * (p - this.bok_a) * (p - this.bok_b) * (p - this.bok_c)), 2);
    }

    public string Pole() {
        return "Pole trojkata: " + WyznaczPole().ToString();
    }

    public string Obwod()
    {
        return "Obwod trojkata: " + WyznaczObwod().ToString();
    }

    public bool Validator() {
        return (this.bok_a + this.bok_b) > this.bok_c
                && (this.bok_a + this.bok_c) > this.bok_b
                && (this.bok_c + this.bok_b) > this.bok_a;
    }


    public override string ToString()
    {
        string returning_str = "Trojkat o wspolrzednych (" + this.wspolrz_x1.ToString()
                + ", " + this.wspolrz_y1.ToString() + "), ("
                + this.wspolrz_x2.ToString()
                + ", " + this.wspolrz_y2.ToString() + ") oraz ("
                + this.wspolrz_x3.ToString()
                + ", " + this.wspolrz_y3.ToString() + ").";
        return returning_str;
    }

    /*public string boki() {
        return this.bok_a.ToString() + ", " + this.bok_b.ToString() + ", " + this.bok_c.ToString();
    }*/

    public bool IsNull
    {
        get
        {
            // Put your code here
            return m_Null;
        }
    }

    public static Trojkat Null
    {
        get
        {
            Trojkat h = new Trojkat();
            h.m_Null = true;
            return h;
        }
    }

    public static Trojkat Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;

        string[] arguments = s.Value.Split("/".ToCharArray());

        if (arguments.Length != 6)
        {
            throw new ArgumentException("$Niepoprawna liczba argumentów! (wymagane 6)$");
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

        Trojkat u = new Trojkat(tmp);
        if (u.Validator() == false) throw new ArgumentException("$Nie da sie utworzyc trojkata z podanych punktow!$");
        // Put your code here
        return u;
    }

    // This is a place-holder field member
    private bool m_Null;
}


