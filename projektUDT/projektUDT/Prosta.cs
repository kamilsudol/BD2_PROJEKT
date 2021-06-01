using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Prosta : INullable
{
    private double wspolrz_x1;
    private double wspolrz_x2;

    private double wspolrz_y1;
    private double wspolrz_y2;

    public Prosta(List<double> args)
    {
        m_Null = false;

        wspolrz_x1 = args[0];
        wspolrz_y1 = args[1];
        wspolrz_x2 = args[2];
        wspolrz_y2 = args[3];
    }

    public double WyznaczDlugosc()
    {
        return Math.Sqrt(Math.Pow(wspolrz_x2 - wspolrz_x1, 2) + Math.Pow(wspolrz_y2 - wspolrz_y1, 2));
    }

    public double WyznaczObwod()
    {
        return 0.0;
    }

    public double WyznaczPole()
    {
        return 0.0;
    }

    public override string ToString()
    {
        string returning_str = "Prost o dlugosci " + this.WyznaczDlugosc().ToString()
                + " o wspolrzednych (" + this.wspolrz_x1.ToString()
                + ", " + this.wspolrz_y1.ToString() + ") oraz ("
                + this.wspolrz_x2.ToString()
                + ", " + this.wspolrz_y2.ToString() + ").";
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

    public static Prosta Null
    {
        get
        {
            Prosta h = new Prosta();
            h.m_Null = true;
            return h;
        }
    }

    public static Prosta Parse(SqlString s)
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

        Prosta u = new Prosta(tmp);
        // Put your code here
        return u;
    }

    // This is a place-holder field member
    public static int arguments_amount = 4;
    private bool m_Null;
}


